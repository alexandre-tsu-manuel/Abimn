using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Abimn
{
    public enum Center { None, All }

    public enum Align
    {
        TopLeft, Top, TopRight,
        Left, Center, Right,
        BottomLeft, Bottom, BottomRight
    }

    public class Entity
    {
        /// <summary>
        /// Visibilité de l'entity
        /// </summary>
        public bool Visible
        {
            get { return _visible; }
            set { _visible = value; }
        }
        private bool _visible;

        /// <summary>
        /// Position de l'entity
        /// </summary>
        public Pos Pos
        {
            get { return _pos; }
            set { _pos = value; }
        }
        private Pos _pos;

        /// <summary>
        /// Delta de position à l'affichage
        /// </summary>
        public Pos Delta
        {
            get { return _delta; }
            set { _delta = value; }
        }
        private Pos _delta;

        /// <summary>
        /// Vecteur vitesse de l'entity
        /// </summary>
        public Vector2 Movement
        {
            get { return _movement; }
            set { _movement = value; }
        }
        private Vector2 _movement;

        /// <summary>
        /// Direction de l'entity
        /// Lorsque la direction est modifiée, elle est automatiquement normalisée.
        /// </summary>
        public Vector2 Direction
        {
            get { return Vector2.Normalize(_movement); }
            set { _movement = Vector2.Normalize(value) * this.Speed; }
        }

        /// <summary>
        /// Vitesse de déplacement de l'entity
        /// </summary>
        public float Speed
        {
            get { return _movement.Length(); }
            set { _movement = this.Direction * value; }
        }

        /// <summary>
        /// Rotation de l'entity au moment du Draw
        /// </summary>
        public float Rotation
        {
            get { return _rotation; }
            set { _rotation = value; }
        }
        private float _rotation;

        /// <summary>
        /// Zoom de l'entity au moment du Draw
        /// </summary>
        public float Scale
        {
            get { return _scale; }
            set { _scale = value; }
        }
        private float _scale;

        /// <summary>
        /// Hitbox de l'entity
        /// </summary>
        public Rectangle Rect
        {
            get { _rect.X = (int)Pos.X; _rect.Y = (int)Pos.Y; return _rect; }
            set { _rect = value; }
        }
        private Rectangle _rect;

        /// <summary>
        /// ID de l'image du button normal
        /// </summary>
        public int IdTextureNormal
        {
            get { return _idTextureNormal + 1; }
            set { _idTextureNormal = value - 1; }
        }
        private int _idTextureNormal;

        /// <summary>
        /// ID de l'image du button survolé
        /// </summary>
        public int IdTextureOver
        {
            get { return _idTextureOver + 1; }
            set { _idTextureOver = value - 1; }
        }
        private int _idTextureOver;

        /// <summary>
        /// ID de l'image du button appuyé
        /// </summary>
        public int IdTexturePushed
        {
            get { return _idTexturePushed + 1; }
            set { _idTexturePushed = value - 1; }
        }
        private int _idTexturePushed;

        public Tiles TilesRef
        {
            get { return (Tiles)_tilesRef; }
            set { _tilesRef = (int)value; }
        }
        private int _tilesRef;

        public Entity(bool visible = true) { this.Initialize(visible); }
        public Entity(Pos position, bool visible = true) { this.Initialize(position, visible); }
        public Entity(Pos position, Vector2 direction, float speed, bool visible = true) { this.Initialize(position, direction, speed, visible); }
        public Entity(Pos position, Vector2 movement, bool visible = true) { this.Initialize(position, movement, visible); }

        /// <summary>
        /// Initialise les variables de l'entity
        /// </summary>
        public virtual void Initialize(bool visible = true)
        {
            this.Initialize(new Pos(), visible);
        }

        /// <summary>
        /// Initialise les variables de l'entity
        /// <param name="position">Position à laquelle sera placée l'entity</param>
        /// <param name="visible">Définit si l'entity est visible ou non</param>
        /// </summary>
        public virtual void Initialize(Pos position, bool visible = true)
        {
            this.Initialize(position, new Vector2(), 0, visible);
        }

        /// <summary>
        /// Initialise les variables de l'entity
        /// <param name="direction">Direction de l'entity</param>
        /// <param name="speed">Vitesse de l'entity</param>
        /// <param name="visible">Définit si l'entity est visible ou non</param>
        /// </summary>
        public virtual void Initialize(Pos position, Vector2 direction, float speed, bool visible = true)
        {
            this.Initialize(position, direction * speed, visible);
        }

        /// <summary>
        /// Initialise les variables de l'entity
        /// <param name="position">Position à laquelle sera placée l'entity</param>
        /// <param name="movement">Vecteur mouvement de l'entity</param>
        /// <param name="visible">Définit si l'entity est visible ou non</param>
        /// </summary>
        public virtual void Initialize(Pos position, Vector2 movement, bool visible = true)
        {
            Pos = position;
            Movement = movement;
            Visible = visible;
            Rotation = 0;
            Scale = 0;
        }

        /// <summary>
        /// Charge l'image voulue grâce au ContentManager donné en plaçant son centre sur sa position
        /// </summary>
        /// <param name="id">Identifiant de l'image dans le tableau d'images</param>
        /// <param name="tilesRef">Référence vers le tableau d'images qui contient la tile voulue</param>
        /// <param name="center">Permet de centrer l'image par rapport à se position</param>
        public virtual void LoadContent(Tiles tilesRef, int idNormal, int idOver = 0, int idPushed = 0, Center center = Center.None)
        {
            _tilesRef = (int)tilesRef;
            IdTextureNormal = --idNormal;
            IdTextureOver = idOver > 0 ? --idOver : idNormal;
            IdTexturePushed = idOver > 0 ? --idPushed : idNormal;
            if (center != Center.None)
                Pos = new Pos(center == Center.All ? Pos.X - Rect.Width / 2 : Pos.X,
                              center == Center.All ? Pos.Y - Rect.Height / 2 : Pos.Y);
            Rect = new Rectangle(0, 0, G.tiles[_tilesRef][IdTextureNormal].Texture.Width, G.tiles[_tilesRef][IdTextureNormal].Texture.Height);
        }

        /// <summary>
        /// Met à jour l'entity en fonction de son vecteur position et de son vecteur vitesse
        /// </summary>
        /// <param name="gameTime">Le GameTime associé à la frame</param>
        public virtual void Update(GameTime gameTime)
        {
            Pos += Movement * (float)gameTime.ElapsedGameTime.TotalMilliseconds;
        }

        public virtual bool IntersectsWith(Entity entity)
        {
            return Rect.Intersects(entity.Rect);
        }

        /// <summary>
        /// Indique si la souris survole l'entity
        /// </summary>
        public virtual bool MouseIsOver(Pos strict = null)
        {
            if (Visible)
            {
                if (strict == null) strict = new Pos();
                return E.GetMousePosX() >= Pos.X + strict.X
                    && E.GetMousePosX() <= Pos.X + _rect.Width - strict.X
                    && E.GetMousePosY() >= Pos.Y + strict.Y
                    && E.GetMousePosY() <= Pos.X + _rect.Height - strict.Y;
            }
            return false;
        }

        /// <summary>
        /// Indique si l'entity est cliquée
        /// </summary>
        public virtual bool IsClicked(Pos strict = null)
        {
            return E.LeftIsReleased() && this.MouseIsOver(strict);
        }

        /// <summary>
        /// Dessine le sprite en utilisant ses attributs et le spritebatch donné
        /// </summary>
        public virtual void Draw()
        {
            if (this.Visible)
                if (this.MouseIsOver())
                    if (E.LeftIsDown())
                        Tile.Draw(TilesRef, IdTexturePushed, Pos + Delta, Rotation, Scale);
                    else
                        Tile.Draw(TilesRef, IdTextureOver, Pos + Delta, Rotation, Scale);
                else
                    Tile.Draw(TilesRef, IdTextureNormal, Pos + Delta, Rotation, Scale);
        }
    }
}
