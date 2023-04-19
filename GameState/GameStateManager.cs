using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Untitled_Project.GameState
{
    internal class GameStateManager
    {
        private GameMain game;
        private IGameState gameState;
        private Stack<IGameState> savedStates = new Stack<IGameState>();
        private int level = 0;

        public GameStateManager(GameMain game)
        {
            this.game = game;
        }
        
        internal void Initialize()
        {
            gameState = new TitleGameState();
        }

        internal void Update() {
            MyKeyboard.Update();
            GameStateTransition(gameState.Update());
            
        }

        internal void Draw() {
            gameState.Draw();
        }

        /* GameStateTransition*/
        internal void GameStateTransition(int stateFlag)
        {
            //TITLE SCREEN
            if (gameState.GetType() == typeof(TitleGameState))
            {
                //If we are at the Title, then Escape exits the game and any other key goes to the Menu
                if (MyKeyboard.WasKeyPressed(Keys.Escape))
                    game.Exit();

                if (MyKeyboard.WasAnyKeyPressed())
                    gameState = new MainMenuGameState();
            }
            //MAIN MENU
            else if (gameState.GetType() == typeof(MainMenuGameState))
            {
                //if we are at the Menu, then Escape goes to Title
                if (MyKeyboard.WasKeyPressed(Keys.Escape))
                    gameState = new TitleGameState();
                else if (stateFlag == 0 && MyKeyboard.WasKeyPressed(Keys.Enter))
                    gameState = new LevelGameState(game.Levels[level]);
                else if (stateFlag == 1 && MyKeyboard.WasKeyPressed(Keys.Enter)){    
                    savedStates.Push(gameState);
                    gameState = new SettingsGameState();
                }
                else if (stateFlag == 2 && MyKeyboard.WasKeyPressed(Keys.Enter))
                    game.Exit();
            }
            //SETTINGS MENU
            else if (gameState.GetType() == typeof(SettingsGameState))
            {
                // TODO: stateFlag == 1 relies on the displayStrings, should be something like stateFlag == displayStrings.indexOf("Return to Main Menu")
                if (MyKeyboard.WasKeyPressed(Keys.Escape) || (stateFlag == 2 && MyKeyboard.WasKeyPressed(Keys.Enter)))
                    gameState = savedStates.Pop();
            }
            else if (gameState.GetType() == typeof(LevelGameState))
            {
                if(stateFlag == 1)
                {
                    if (level++ < GameMain.Instance.Levels.Length - 1)
                        gameState = new LevelGameState(game.Levels[level]);
                    else
                        game.Exit();
                }
                if (MyKeyboard.WasKeyPressed(Keys.Escape))
                {
                    savedStates.Push(gameState);
                    gameState = new PauseGameState();
                }
            }
            else if (gameState.GetType() == typeof(PauseGameState))
            {
                if (stateFlag == 0 && MyKeyboard.WasEnterPressed())
                    gameState = savedStates.Pop();
                else if (stateFlag == 1 && MyKeyboard.WasEnterPressed())
                {
                    savedStates.Push(gameState);
                    gameState = new SettingsGameState();
                }
                else if (stateFlag == 2 && MyKeyboard.WasEnterPressed())
                {
                    savedStates.Clear();
                    gameState = new MainMenuGameState();
                    LevelGameState.Reset();
                }
                else if (stateFlag == 3 && MyKeyboard.WasEnterPressed())
                    game.Exit();
            }
        }
    }
}
