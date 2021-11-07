using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace GeneralTesting.GameStates
{
    class GameStateManager
    {
        private static GameStateManager _instance;
        private ContentManager _content;

        private Stack<GameState> _screens = new Stack<GameState>();

        public static GameStateManager Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new GameStateManager();
                return _instance;
            }
        }

        public void SetContent(ContentManager content)
        {
            _content = content;
        }

        /// <summary>
        /// Unloads content from screen
        /// </summary>
        public void UnloadContent()
        {
            foreach(GameState screen in _screens)
            {
                screen.UnloadContent();
            }
        }

        /// <summary>
        /// Adds screen to top of stack
        /// </summary>
        /// <param name="screen"></param>
        public void AddScreenToStack(GameState screen)
        {
            try
            {
                _screens.Push(screen); //Push screen onto stack
                _screens.Peek().Initialize(); //initialize TOP screen
                if (_content != null)
                    _screens.Peek().LoadContent(_content);
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.ToString());
            }
        }

        /// <summary>
        /// Removes top screen from stack
        /// </summary>
        public void RemoveScreenFromStack()
        {
            if(_screens.Count > 0)
            {
                try
                {
                    var screen = _screens.Peek();
                    _screens.Pop();
                }
                catch (Exception e)
                {
                    Console.WriteLine("Error: " + e.ToString());
                }
            }
        }

        /// <summary>
        /// Clears screens from Stack
        /// </summary>
        public void ClearStack()
        {
            while (_screens.Count > 0)
                _screens.Pop();
        }

        /// <summary>
        /// let us clear all the screens before we add a new one
        /// </summary>
        /// <param name="screen"></param>
        public void ChangeScreens(GameState screen)
        {
            try
            {
                ClearStack();
                AddScreenToStack(screen);
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e);
            }
        }

        /// <summary>
        /// Update top screen on stack
        /// </summary>
        /// <param name="gameTime"></param>
        public void Update(GameTime gameTime)
        {
            try
            {
                if (_screens.Count > 0)
                    _screens.Peek().Update(gameTime);
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e);
            }
        }

        public void Draw(SpriteBatch sb)
        {
            try
            {
                if (_screens.Count > 0)
                    _screens.Peek().Draw(sb);
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e);
            }
        }
    }
}
