using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Part_7_keyboard_and_mouse_inputs
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        Texture2D pacTexture;
        Texture2D pacSleep;
        Texture2D pacRight;
        Texture2D pacLeft;
        Texture2D pacUp;
        Texture2D pacDown;
        Rectangle pacLocation;

        KeyboardState keyboardState;
        MouseState mouseState;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
            pacLocation = new Rectangle(10, 10, 75, 75);
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here

            pacSleep = Content.Load<Texture2D>("PacSleep");
            pacRight = Content.Load<Texture2D>("PacRight");
            pacDown = Content.Load<Texture2D>("PacDown");
            pacUp = Content.Load<Texture2D>("PacUp");
            pacLeft = Content.Load<Texture2D>("PacLeft");           
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here

            keyboardState = Keyboard.GetState();
            mouseState = Mouse.GetState();

            if (keyboardState.IsKeyDown(Keys.Up) || keyboardState.IsKeyDown(Keys.Left) || keyboardState.IsKeyDown(Keys.Right) || keyboardState.IsKeyDown(Keys.Right) != true)
                pacTexture = pacSleep;


            if (keyboardState.IsKeyDown(Keys.Up))
            {
                pacLocation.Y -= 2;
                pacTexture = pacUp;
            }

            if (keyboardState.IsKeyDown(Keys.Down))
            {
                pacLocation.Y += 2;
                pacTexture = pacDown;
            }

            if (keyboardState.IsKeyDown(Keys.Left))
            {
                pacLocation.X -= 2;
                pacTexture = pacLeft;
            }

            if (keyboardState.IsKeyDown(Keys.Right))
            {
                pacLocation.X += 2;
                pacTexture = pacRight;
            }

            if (mouseState.LeftButton == ButtonState.Pressed)
            {
                pacLocation.X = mouseState.X - 37;
                pacLocation.Y = mouseState.Y - 37;
                pacTexture = pacSleep;
            }

            if (pacLocation.Left > _graphics.PreferredBackBufferWidth)
            {
                pacLocation.X = -pacLocation.Width;
            }

            if (pacLocation.Right < 0)
            {
                pacLocation.X = _graphics.PreferredBackBufferWidth;
            }

            if (pacLocation.Top > _graphics.PreferredBackBufferHeight)
            {
                pacLocation.Y = -pacLocation.Height;
            }

            if (pacLocation.Bottom < 0)
            {
                pacLocation.Y = _graphics.PreferredBackBufferHeight;
            }

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here

            _spriteBatch.Begin();


            _spriteBatch.Draw(pacTexture, pacLocation, Color.White);


            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
