using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
namespace Juego_2D
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private int Vidas;
        private SpriteFont _myFont;
        Jugador myPlayer;
        Enemy myEnemy;
        Enemy2 myEnemy2;
        Enemy3 myEnemy3;
        Texture2D _Texture2D;
        
        Song song1;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            _graphics.IsFullScreen = false;
            _graphics.PreferredBackBufferWidth = 1360;
            _graphics.PreferredBackBufferHeight = 730;
            _graphics.ApplyChanges();
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            Vidas = 1;
            myPlayer = new Jugador(this, new Point(10));
            myEnemy = new Enemy(this, new Point(this.Window.ClientBounds.Width, 100));
            myEnemy2 = new Enemy2(this, new Point(this.Window.ClientBounds.Width, 500));
            myEnemy3 = new Enemy3(this, new Point(this.Window.ClientBounds.Width, 200));
            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            _myFont = Content.Load<SpriteFont>("File");
            song1 =this.Content.Load<Song>("Sound1");
            _Texture2D = Content.Load<Texture2D>("background");
            MediaPlayer.Play(song1);
            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            myPlayer.Update(gameTime);
            myEnemy.Update(gameTime);
            myEnemy2.Update(gameTime);
            myEnemy3.Update(gameTime);
            if (myPlayer.PositionRectangle.Intersects(myEnemy.PositionRectangle))
            {
                Vidas=-1;
            }
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            // TODO: Add your drawing code here
            _spriteBatch.Begin();
            _spriteBatch.Draw(_Texture2D, new Vector2(0, 0), Color.White);
            myPlayer.Draw(gameTime, _spriteBatch);

            myEnemy.Draw(gameTime, _spriteBatch,Color.White);
            myEnemy2.Draw(gameTime, _spriteBatch, Color.White);
            myEnemy3.Draw(gameTime, _spriteBatch, Color.White);
            _spriteBatch.DrawString(_myFont, "NUMERO DE VIDAS " + Vidas,new Vector2(50, 20), Color.Blue);
            if (Vidas <= 0)
            {
                Vidas = 0;
                _spriteBatch.DrawString(_myFont, "GAME OVER ", new Vector2(80, 80), Color.Red);
                MediaPlayer.Stop();
            }
            
            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
