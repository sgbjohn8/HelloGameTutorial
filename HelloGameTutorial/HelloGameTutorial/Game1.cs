using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace HelloGameTutorial
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private Texture2D _ballTexture;
        private Vector2 _ballPosition;
        private Vector2 _ballVelocity;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            _ballPosition = new Vector2((_graphics.GraphicsDevice.Viewport.Width - 64) / 2, (_graphics.GraphicsDevice.Viewport.Height - 64) / 2);
            System.Random rand = new System.Random();
            _ballVelocity = new Vector2((float)rand.NextDouble(), (float)rand.NextDouble());
            _ballVelocity.Normalize();
            _ballVelocity *= 100;
            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            _ballTexture = Content.Load<Texture2D>("ball");
            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            _ballPosition += _ballVelocity * (float)gameTime.ElapsedGameTime.TotalSeconds;

            if (_ballPosition.X < _graphics.GraphicsDevice.Viewport.X || _ballPosition.X > _graphics.GraphicsDevice.Viewport.Width - 64)
            {
                _ballVelocity.X *= -1;
            }
            if (_ballPosition.Y < _graphics.GraphicsDevice.Viewport.Y || _ballPosition.Y > _graphics.GraphicsDevice.Viewport.Height - 64)
            {
                _ballVelocity.Y *= -1;
            }
            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            _spriteBatch.Begin();
            _spriteBatch.Draw(_ballTexture, _ballPosition, Color.White);
            _spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
