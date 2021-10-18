using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Audio;


namespace Juego_2D
{
    /// <summary>
    /// the player , controlled by the keyboard
    /// </summary>
    class Jugador
    {
        //SoundEffect BulletAudioEffect; 
        Texture2D[] Soldier;
        Rectangle[] Bullet;
        bool[] isBulletVisible;
        KeyboardState previousState;
        int BulletCount;
        const int Bulletnumber = 50;
        /// <summary>
        /// a reference to the game that will contain the player
        /// </summary>
        Game1 root; /// <summary>
                    /// the current position of the player
                    /// </summary>
        Point position; /// <summary>
                        /// the name of the sprite image
                        /// </summary>
        const String imageName = "Soldier";
        const String imagename = "Bullet";
        //byte imagename;
        /// <summary>
        /// an image texture for the player sprite
        /// </summary>
        Texture2D spriteImageInMemory; /// <summary>
                                       /// represents the number of pixels to move the player in the Y axis
                                       /// </summary>
        Point velocity; /// <summary>
                        /// to save the previos state of the keyboard to avoid undesired keyboard
                        /// </summary>
        KeyboardState previousKeyboardState; /// <summary>
                                             /// this is a variable that indicates the scale size of the player.
                                             /// e.g. a size of 30 will tell us that
                                             /// the height and the width of the player is 30
                                             /// </summary>
        public int Size { get; set; }
        /// <summary>
        /// the propierly scaled position rectangle for the jugador sprite
        /// </summary>
        public Rectangle PositionRectangle
        {
            get
            {
                return new Rectangle(position, new Point(Size));
                // return new Rectangle(position,x,position y,size,size);
            }
        } /// <summary>
          /// initialize
          /// </summary>
          /// <param name="_root">this is the class that manipulates the game loop</param>
        public Jugador(Game1 _root)
        {
            //initialize a player
            this.root = _root;
            Size = 150;
            velocity = new Point(10, 0);
            position = new Point(0, 450);
            previousKeyboardState = Keyboard.GetState();
            Bullet = new Rectangle[Bulletnumber];
            Soldier = new Texture2D[Bulletnumber];
            isBulletVisible = new bool[Bulletnumber];
            BulletCount = 0;
            for (int i = 0; i < Bulletnumber; i++)
            {
                Bullet[i] = new Rectangle(0, 0, 30, 30);
            }
            this.LoadContent();
        }
        /// <summary>
        /// initialize
        /// </summary>
        /// <param name="_root">this is the class that manipulates the game loop</param>
        /// <param name="_position">the initial position of the jugador </param>
        public Jugador(Game1 _root, Point _position)
        {
            //initialize values
            this.root = _root;
            Size = 150;
            velocity = new Point(0, 4);
            position = _position;
            previousKeyboardState = Keyboard.GetState();
            //initialize the bulletcode/rectangle  /number  /arrays
            Bullet = new Rectangle[Bulletnumber];
            Soldier = new Texture2D[Bulletnumber];
            isBulletVisible = new bool[Bulletnumber];
            BulletCount = 0;
            for (int i = 0; i < Bulletnumber; i++)
            {
                Bullet[i] = new Rectangle(0, 0, 30, 30);
            }
            this.LoadContent();
        }
        /// <summary>
        /// method to load external content
        /// </summary>
        private void LoadContent()
        {
            //BulletAudioEffect = this.root.Content.Load<SoundEffect>("disparo");
            spriteImageInMemory = this.root.Content.Load<Texture2D>(imageName);
            //array for make new bullet
            for (int i = 0; i < Bulletnumber; i++)
            {
                Soldier[i] = this.root.Content.Load<Texture2D>(imagename);
            }
        } /// <summary>
          /// this method will help us to detct what key or keys have been pressed and actuall
          /// </summary>
          /// <param name="currentkeyboardState">the current state of the keyboard</param>
        private void HandInput(KeyboardState currentkeyboardState)
        {

            if (currentkeyboardState.IsKeyDown(Keys.Up))
            {
                if (position.Y > 0)
                {
                    position = position - velocity;
                }
            }
            if (currentkeyboardState.IsKeyDown(Keys.Down))
            {
                if (position.Y < (root.Window.ClientBounds.Height - Size))
                {
                    position = position + velocity;
                }
            }
            //code to detect and control the amount of time the keyboard is pressed
            if (currentkeyboardState.IsKeyDown(Keys.Space) && !(previousState.IsKeyDown(Keys.Space)))
            {
                if (BulletCount < (Bulletnumber - 1))
                {
                    isBulletVisible[BulletCount] = true;
                    Bullet[BulletCount].X = position.X + (position.X / 20) - 10;
                    Bullet[BulletCount].Y = position.Y;
                    BulletCount++;
                    //BulletAudioEffect.Play();
                }
            }
            for (int i = 0; i < Bulletnumber; i++)
            {
                if (isBulletVisible[i])
                {
                    Bullet[i].X += 10;
                }
                if (Bullet[i].X < 0)
                {
                    isBulletVisible[i] = false;
                }
            }
            
            previousState = currentkeyboardState;
        }
        public void Update(GameTime gameTime)
        {
            //handle any move input
            HandInput(Keyboard.GetState());
        }
        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            //use the sprite batch to draw
            spriteBatch.Draw(spriteImageInMemory, PositionRectangle, Color.White);

            for (int i = 0; i < Bulletnumber; i++)
            {
                if (isBulletVisible[i])
                {
                    spriteBatch.Draw(Soldier[i], Bullet[i], Color.White);
                }
            }
        }
    }
}

