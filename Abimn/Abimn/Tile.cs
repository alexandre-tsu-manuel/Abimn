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
    public enum Center { None, Horizontal, Vertical, All }

    public class Tile
    {
        /// <summary>
        /// Récupère ou définit l'image de la tile
        /// </summary>
        public Texture2D Texture
        {
            get { return _texture; }
            set { _texture = value; }
        }
        private Texture2D _texture;

        /// <summary>
        /// Charge l'image voulue grâce au ContentManager donné
        /// </summary>
        /// <param name="content">Le ContentManager qui chargera l'image</param>
        /// <param name="assetName">L'asset name de l'image à charger pour ce Sprite</param>
        public virtual void LoadContent(ContentManager content, string assetName)
        {
            _texture = content.Load<Texture2D>(assetName);
        }

        /// <summary>
        /// Dessine le sprite en utilisant ses attributs et le spritebatch donné
        /// </summary>
        /// <param name="spriteBatch">Le spritebatch avec lequel dessiner</param>
        /// <param name="gameTime">Le GameTime de la frame</param>
        public virtual void Draw(SpriteBatch spriteBatch, Pos pos, Center center = Center.None)
        {
            if (center == Center.Horizontal || center == Center.All)
                pos.X = pos.X = pos.X - _texture.Width / 2;
            if (center == Center.Vertical || center == Center.All)
                pos.Y = pos.Y = pos.Y - _texture.Height / 2;
            spriteBatch.Draw(_texture, pos.ToVector2(), Color.White);
        }
    }
}
