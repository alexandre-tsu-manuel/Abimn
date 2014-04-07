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
    public class Entity
    {
        /// <summary>
        /// Récupère ou définit la visibilité de l'entity
        /// </summary>
        public bool Visible
        {
            get { return _visible; }
            set { _visible = value; }
        }
        private bool _visible;

        /// <summary>
        /// Récupère ou définit la position de l'entity
        /// </summary>
        public Pos Position
        {
            get { return _position; }
            set { _position = value; }
        }
        private Pos _position;

        /// <summary>
        /// Récupère ou définit la direction de l'entity. Lorsque la direction est modifiée, elle est automatiquement normalisée.
        /// </summary>
        public Vector2 Direction
        {
            get { return _direction; }
            set { _direction = Vector2.Normalize(value); }
        }
        private Vector2 _direction;

        /// <summary>
        /// Récupère ou définit la vitesse de déplacement de l'entity.
        /// </summary>
        public float Speed
        {
            get { return _speed; }
            set { _speed = value; }
        }
        private float _speed;

        /// <summary>
        /// Hitbox de l'entity
        /// </summary>
        public Rectangle Rect
        {
            get { return _rect; }
            set { _rect = value; }
        }
        private Rectangle _rect;

        private int _id;
        private int _tilesRef;

        public Entity(bool visible = true) { this.Initialize(visible); }
        public Entity(Pos position, bool visible = true) { this.Initialize(position, visible); }
        public Entity(Pos position, Vector2 direction, float speed, bool visible = true) { this.Initialize(position, direction, speed, visible); }

        /// <summary>
        /// Initialise les variables de l'entity
        /// </summary>
        public virtual void Initialize(bool visible = true)
        {
            _position = new Pos();
            _direction = Vector2.Zero;
            _speed = 0;
            _rect = new Rectangle();
            _visible = visible;
        }

        /// <summary>
        /// Initialise les variables de l'entity
        /// <param name="position">La position à laquelle sera placée l'entity</param>
        /// </summary>
        public virtual void Initialize(Pos position, bool visible = true)
        {
            _position = position;
            _direction = Vector2.Zero;
            _speed = 0;
            _rect = new Rectangle((int)_position.X, (int)_position.Y, 0, 0);
            _visible = visible;
        }

        /// <summary>
        /// Initialise les variables de l'entity
        /// <param name="direction">La direction de l'entity</param>
        /// <param name="speed">La vitesse de l'entity</param>
        /// </summary>
        public virtual void Initialize(Pos position, Vector2 direction, float speed, bool visible = true)
        {
            _position = position;
            _direction = direction;
            _speed = speed;
            _rect = new Rectangle();
            _visible = visible;
        }

        /// <summary>
        /// Charge l'image voulue grâce au ContentManager donné en plaçant son centre sur sa position
        /// </summary>
        /// <param name="content">Le ContentManager qui chargera l'image</param>
        /// <param name="assetName">L'asset name de l'image à charger pour ce Sprite</param>
        /// <param name="center"> Permet de centrer l'image par rapport à se position</param>
        public virtual void LoadContent(int id, Tiles tilesRef, Center center = Center.None)
        {
            _id = --id;
            _tilesRef = (int)tilesRef;
            _rect.Width = G.tiles[_tilesRef][id].Texture.Width;
            _rect.Height = G.tiles[_tilesRef][id].Texture.Height;
            if (center == Center.Horizontal || center == Center.All)
                _position.X = _rect.X = _rect.X - _rect.Width / 2;
            if (center == Center.Vertical || center == Center.All)
                _position.Y = _rect.Y = _rect.Y - _rect.Height / 2;
        }

        /// <summary>
        /// Met à jour les variables du sprite
        /// </summary>
        /// <param name="gameTime">Le GameTime associé à la frame</param>
        public virtual void Update(GameTime gameTime)
        {
            _position += _direction * _speed * (float)gameTime.ElapsedGameTime.TotalMilliseconds;
            _rect.X = (int) _position.X;
            _rect.Y = (int) _position.Y;
        }

        /// <summary>
        /// Permet de gérer les entrées du joueur
        /// </summary>
        /// <param name="keyboardState">L'état du clavier à tester</param>
        /// <param name="mouseState">L'état de la souris à tester</param>
        /// <param name="joueurNum">Le numéro du joueur qui doit être surveillé</param>
        public virtual void HandleInput()
        {
        }

        public virtual bool IntersectsWith(Entity entity)
        {
            return _rect.Intersects(entity.Rect);
        }

        /// <summary>
        /// Dessine le sprite en utilisant ses attributs et le spritebatch donné
        /// </summary>
        /// <param name="spriteBatch">Le spritebatch avec lequel dessiner</param>
        /// <param name="gameTime">Le GameTime de la frame</param>
        public virtual void Draw()
        {
            if (this.Visible)
                G.tiles[_tilesRef][_id].Draw(_position);
        }
    }
}
