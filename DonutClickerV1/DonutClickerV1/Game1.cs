using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace DonutClickerV1
{
    public class Game1 : Game
    {

        Texture2D donutTexture;
        Vector2 mainDonutPos;
        Vector2 scaling; //idk bout this one

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
            mainDonutPos = new Vector2(300, 160);
            scaling = new Vector2(1f, 1f);

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            donutTexture = Content.Load<Texture2D>("DonutSprite2"); //argh
            font = Content.Load<SpriteFont>("Score"); //Score = name of file
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            _spriteBatch.Begin();
            _spriteBatch.Draw(donutTexture, mainDonutPos, null, Color.White, 0f, Vector2.Zero, scaling, SpriteEffects.None, 0f); //This sucks
            _spriteBatch.DrawString(font, "Score: " + clickScore, new Vector2(0, 0), Color.Black);
            _spriteBatch.End();

            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}
