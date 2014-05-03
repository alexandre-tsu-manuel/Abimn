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
    public class Button
    {
        private int _tilesRef;

        /// <summary>
        /// Récupère ou définit la visibilité du button
        /// </summary>
        /// // bat les couilles.
        public bool Visible
        {
            get { return _visible; }
            set { _visible = value; }
        }
        private bool _visible;

        /// <summary>
        /// Récupère ou définit l'image du button normal
        /// </summary>
        public int IdTextureNormal
        {
            get { return _idTextureNormal; }
            set { _idTextureNormal = value; }
        }
        private int _idTextureNormal;

        /// <summary>
        /// Récupère ou définit l'image du button survolé
        /// </summary>
        public int IdTextureOver
        {
            get { return _idTextureOver; }
            set { _idTextureOver = value; }
        }
        private int _idTextureOver;

        /// <summary>
        /// Récupère ou définit l'image du button appuyé
        /// </summary>
        public int IdTexturePushed
        {
            get { return _idTexturePushed; }
            set { _idTexturePushed = value; }
        }
        private int _idTexturePushed;

        /// <summary>
        /// Récupère ou définit la position du button
        /// </summary>
        public Pos Pos
        {
            get { return _pos; }
            set { _pos = value; }
        }
        private Pos _pos;

        /// <summary>
        /// Récupère ou définit la hitbox du button
        /// </summary>
        public Rectangle Rect
        {
            get { return _rect; }
            set { _rect = value; }
        }
        private Rectangle _rect;

        public Button(bool visible = true) { this.Initialize(visible); }
        public Button(Pos position, bool visible = true) { this.Initialize(position, visible); }

        /// <summary>
        /// Initialise les variables du Sprite
        /// </summary>
        public virtual void Initialize(bool visible = true)
        {
            _pos = new Pos();
            _rect = new Rectangle();
            _visible = visible;
        }

        /// <summary>
        /// Initialise les variables du Button
        /// </summary>
        /// <param name="position">La position à laquelle sera placé le button</param>
        public virtual void Initialize(Pos position, bool visible = true)
        {
            _pos = position;
            _rect = new Rectangle((int)_pos.X, (int)_pos.Y, 0, 0);
            _visible = visible;
        }

        /// <summary>
        /// Charge l'image voulue grâce au ContentManager donné
        /// </summary>
        /// <param name="content">Le ContentManager qui chargera l'image</param>
        /// <param name="assetName">L'asset name de l'image à charger pour ce Sprite</param>
        /// <param name="center"> Permet de centrer l'image par rapport à se position. Par défaut l'image n'est pas centrée</param>
        public virtual void LoadContent(int idNormal, Tiles tilesRef, Center center = Center.None) { this.LoadContent(idNormal, idNormal, idNormal, tilesRef, center); }
        public virtual void LoadContent(int idNormal, int idOver, int idPushed, Tiles tilesRef, Center center = Center.None)
        {
            _idTextureNormal = --idNormal;
            _idTextureOver = --idOver;
            _idTexturePushed = --idPushed;
            _tilesRef = (int) tilesRef;
            _rect.Width = G.tiles[_tilesRef][idNormal].Texture.Width;
            _rect.Height = G.tiles[_tilesRef][idNormal].Texture.Height;
            if (center == Center.Horizontal || center == Center.All)
                _pos.X = _rect.X = _rect.X - _rect.Width / 2;
            if (center == Center.Vertical || center == Center.All)
                _pos.Y = _rect.Y = _rect.Y - _rect.Height / 2;
        }

        /// <summary>
        /// Indique si la souris survole le button
        /// </summary>
        public virtual bool mouseOver()
        {
            return E.GetMousePosX() >= _pos.X
                && E.GetMousePosX() <= _pos.X + _rect.Width
                && E.GetMousePosY() >= _pos.Y
                && E.GetMousePosY() <= _pos.Y + _rect.Height;
        }

        public virtual bool IntersectsWith(Entity entity)
        {
            return _rect.Intersects(entity.Rect);
        }

        /// <summary>
        /// Dessine le button en utilisant ses attributs et le spritebatch donné
        /// </summary>
        /// <param name="spriteBatch">Le spritebatch avec lequel dessiner</param>
        public virtual void Draw()
        {
            if (this.Visible)
                if (this.mouseOver())
                    if (E.LeftIsDown())
                        G.tiles[_tilesRef][_idTexturePushed].Draw(_pos);
                    else
                        G.tiles[_tilesRef][_idTextureOver].Draw(_pos);
                else
                    G.tiles[_tilesRef][_idTextureNormal].Draw(_pos);
        }
    }
}
