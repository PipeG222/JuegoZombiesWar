using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Input;

namespace Juego_2D
{
    /// <summary>
    /// Sprite base class, conta
    /// </summary>
    class Sprite
    {
        
        /// <summary>
        /// the current position of the sprite
        /// </summary>
        protected Point position;
        /// <summary>
        /// thethe name of the sprite image
        /// </summary>
        protected string imageName;
        /// <summary>
        /// the image texture for the player sprite
        /// </summary>
        protected Texture2D SpriteImage;
       
        /// <summary>
        /// this is a variable to idicates the scale of player
        /// e.g. a size of 30 will tell us that
        /// the heiht and the width of player is 30
        /// </summary>
        public int Size { get; set; }
        /// <summary>
        /// the property scaled position rectangle for the player sprite
        /// </summary>
        public Rectangle PositionRectangle
        {
            get
            {
                return new Rectangle(position, new Point(Size));
                //return new Rectangle(position.X,position.Y,Size,Size);
            }
        }
        /// <summary>
        /// initializa sprite  
        /// </summary>
        /// <param name="_root">this is the class that manipulates the game loops
        /// </param>
        public Sprite(Point _position, int _Size)
        {
            this.position = _position;
            Size = _Size;
        }
        public void Draw(GameTime gameTime, SpriteBatch spriteBatch, Color _color)
        {
            spriteBatch.Draw(SpriteImage, PositionRectangle, _color);
        }
        
       
        
    }
}
