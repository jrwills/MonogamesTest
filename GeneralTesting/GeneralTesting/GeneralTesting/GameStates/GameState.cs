//https://rareelementgames.wordpress.com/2017/04/21/game-state-management/

using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;

namespace GeneralTesting.GameStates
{
    abstract class GameState : IGameState //abstract = all gamestate use all methods
    {
        protected GraphicsDevice _graphicsDevice;

        public GameState(GraphicsDevice gd)
        {
            _graphicsDevice = gd;
        }

        public abstract void Initialize();
        public abstract void LoadContent(ContentManager content);
        public abstract void UnloadContent();
        public abstract void Update(GameTime gameTime);
        public abstract void Draw(SpriteBatch sb);
    }
}
