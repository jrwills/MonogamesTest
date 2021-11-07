using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace DonutClickerV1
{
    public class Game1 : Game
    {

        Texture2D donutTexture;
        Texture2D bankTexture;

        Vector2 mainDonutPos;
        Vector2 bankPos;

        Vector2 scalingDonut; //idk bout this one
        Vector2 scalingBank;

        private SpriteFont font; //For the "Score :"
        private int clickScore = 0; //initially zero

        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            mainDonutPos = new Vector2(350, 150); //300, 160 original
            scalingBank = new Vector2(3f, 3f);

            bankPos = new Vector2(450,100);
            scalingDonut = new Vector2(1f, 1f);

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            donutTexture = Content.Load<Texture2D>("DonutSprite2"); //argh
            bankTexture = Content.Load<Texture2D>("BankSprite");
            font = Content.Load<SpriteFont>("Score"); //Score = name of file
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            // if (Keyboard.GetState().IsKeyDown(Keys.Space))
            // clickScore++;

            MouseInput.LastMouseState = MouseInput.MouseState;

            // Get the mouse state relevant for this frame
            MouseInput.MouseState = Mouse.GetState();

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            var mouseState = Mouse.GetState();
            GraphicsDevice.Clear(Color.CornflowerBlue);

            _spriteBatch.Begin();
            _spriteBatch.Draw(donutTexture, mainDonutPos, null, Color.White, 0f, Vector2.Zero, scalingDonut, SpriteEffects.None, 0f); //This sucks
            _spriteBatch.Draw(bankTexture, bankPos, null, Color.White, 0f, Vector2.Zero, scalingBank, SpriteEffects.None, 0f); //This sucks too
            _spriteBatch.DrawString(font, "Score: " + clickScore, new Vector2(0, 0), Color.Black);
            _spriteBatch.End();

            // TODO: Add your drawing code here
            if (MouseInput.LastMouseState.LeftButton == ButtonState.Released && MouseInput.MouseState.LeftButton == ButtonState.Pressed && 
                    MouseInput.MouseState.X >= 150 && MouseInput.MouseState.X <= 450 &&
                        MouseInput.MouseState.Y >= 80 && MouseInput.MouseState.Y <= 240)
                clickScore++;

            base.Draw(gameTime);
        }
    }
}
