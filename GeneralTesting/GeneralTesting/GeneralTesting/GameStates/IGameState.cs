using System;
using System.Collections.Generic;
using System.Text;
//always add these :)
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

/// <summary>
/// always think header files in C, interfaces are used to... 501 stuff
/// </summary>
namespace GeneralTesting.GameStates
{
    interface IGameState
    {
        void Initialize();
        void LoadContent(ContentManager content);
        void UnloadContent();
        void Update(GameTime gameTime);
        void Draw(SpriteBatch sb);
    }
}
