using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace DonutClickerV1
{
    public class Game1 : Game
    {
        //http://www.alecjacobson.com/weblog/?p=539
        enum ButtState
        {
            HOVER,
            UP,
            JUST_RELEASED,
            DOWN
        }

        const int NUMBER_OF_BUTTONS = 3,
            COP_BUTTON_INDEX = 0,
            ALIEN_BUTTON_INDEX = 1,
            BOSTON_BUTTON_INDEX = 2,
            BUTTON_HEIGHT = 40,
            BUTTON_WIDTH = 88;
        Color background_color;
        Color[] button_color = new Color[NUMBER_OF_BUTTONS];
        Rectangle[] button_rectangle = new Rectangle[NUMBER_OF_BUTTONS];
        ButtState[] button_state = new ButtState[NUMBER_OF_BUTTONS];
        Texture2D[] button_texture = new Texture2D[NUMBER_OF_BUTTONS];
        double[] button_timer = new double[NUMBER_OF_BUTTONS];
        //mouse pressed and mouse just pressed
        bool mpressed, prev_mpressed = false;
        //mouse location in window
        int mx, my;
        double frame_time;

        Texture2D donutTexture;
        Texture2D bankTexture;
        Texture2D policeTexture;

        Vector2 mainDonutPos;
        Vector2 bankPos;
        Vector2 policePos;
        Vector2 policePos2;

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
            policePos2 = new Vector2(0, 200);
            scalingPolice = new Vector2(1f, 1f);

            // starting x and y locations to stack buttons (see link above)
            // vertically in the middle of the screen
            int x = Window.ClientBounds.Width / 2 - BUTTON_WIDTH / 2;
            int y = Window.ClientBounds.Height / 2 -
                NUMBER_OF_BUTTONS / 2 * BUTTON_HEIGHT -
                (NUMBER_OF_BUTTONS % 2) * BUTTON_HEIGHT / 2;
            for (int i = 0; i < NUMBER_OF_BUTTONS; i++)
            {
                button_state[i] = ButtState.UP;
                button_color[i] = Color.White;
                button_timer[i] = 0.0;
                button_rectangle[i] = new Rectangle(x, y, BUTTON_WIDTH, BUTTON_HEIGHT);
                y += BUTTON_HEIGHT;
            }
            IsMouseVisible = true;
            background_color = Color.CornflowerBlue;

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            donutTexture = Content.Load<Texture2D>("DonutSprite2"); //argh
            bankTexture = Content.Load<Texture2D>("BankSprite");
            policeTexture = Content.Load<Texture2D>("PoliceSprite");
            button_texture[COP_BUTTON_INDEX] = Content.Load<Texture2D>("CopButton");

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

           
            if(clickScore == 10 && MouseInput.MouseState.X >= 450 && MouseInput.MouseState.X <= 500 && MouseInput.MouseState.Y <= 500)
                _spriteBatch.Draw(policeTexture, policePos2, null, Color.White, 0f, Vector2.Zero, scalingPolice, SpriteEffects.None, 0f); //This sucks too-er-er

            _spriteBatch.DrawString(font, "Score: " + clickScore, new Vector2(0, 0), Color.Black);
            //_spriteBatch.DrawString(font, text, new Vector2(0, 400), Color.Black);
            /*for (int i = 0; i < NUMBER_OF_BUTTONS; i++)
                _spriteBatch.Draw(button_texture[i], button_rectangle[i], button_color[i]);*/
            _spriteBatch.Draw(button_texture[COP_BUTTON_INDEX], new Vector2(550,-5), button_color[COP_BUTTON_INDEX]);
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
