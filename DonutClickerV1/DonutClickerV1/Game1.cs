using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace DonutClickerV1
{
    public class Game1 : Game
    {

        Texture2D donutTexture;
        Texture2D bankTexture;
        Texture2D policeTexture;

        Vector2 mainDonutPos;
        Vector2 bankPos;
        Vector2 policePos;

        Vector2 scalingDonut; //idk bout this one
        Vector2 scalingBank;
        Vector2 scalingPolice;

        private SpriteFont font; //For the "Score :"
        private int clickScore = 0; //initially zero

        private SpriteFont purchases;
        private string text = "policeman purchased!";

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

            policePos = new Vector2(456, -5);
            scalingPolice = new Vector2(1f, 1f);

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            donutTexture = Content.Load<Texture2D>("DonutSprite2"); //argh
            bankTexture = Content.Load<Texture2D>("BankSprite");
            policeTexture = Content.Load<Texture2D>("PoliceSprite");
            font = Content.Load<SpriteFont>("Score"); //Score = name of file
            purchases = Content.Load<SpriteFont>("Purchases");
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

            if (clickScore >= 10 && MouseInput.MouseState.RightButton == ButtonState.Pressed && MouseInput.MouseState.RightButton == ButtonState.Released)
            {
                _spriteBatch.Begin();


                _spriteBatch.DrawString(font, text, new Vector2(0, 150), Color.Black);

                _spriteBatch.End();
            }

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            var mouseState = Mouse.GetState();
            GraphicsDevice.Clear(Color.CornflowerBlue);

            _spriteBatch.Begin();
            _spriteBatch.Draw(donutTexture, mainDonutPos, null, Color.White, 0f, Vector2.Zero, scalingDonut, SpriteEffects.None, 0f); //This sucks
            _spriteBatch.Draw(bankTexture, bankPos, null, Color.White, 0f, Vector2.Zero, scalingBank, SpriteEffects.None, 0f); //This sucks too
            _spriteBatch.Draw(policeTexture, policePos, null, Color.White, 0f, Vector2.Zero, scalingPolice, SpriteEffects.None, 0f); //This sucks too-er
            _spriteBatch.DrawString(font, "Score: " + clickScore, new Vector2(0, 0), Color.Black);
            //_spriteBatch.DrawString(font, text, new Vector2(0, 400), Color.Black);
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
