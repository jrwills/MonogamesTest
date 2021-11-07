using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace GeneralTesting.GameStates
{
    class GameStateOne : GameState
    {
        public GameStateOne(GraphicsDevice gd) : base(gd) { } //idk what this does

        public override void Initialize()
        {

        }

        protected override void LoadContent(ContentManager content)
        {
            //SpriteBatch spriteBatch = new SpriteBatch(GraphicsDevice);
            //GameStateManager.Instance.SetContent(content);
        }

        public override void UnloadContent()
        {

        }

        public override void Update(GameTime gameTime)
        {

        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            _graphicsDevice.Clear(Color.Black);
            spriteBatch.Begin();
            spriteBatch.End();
        }
    }
}
