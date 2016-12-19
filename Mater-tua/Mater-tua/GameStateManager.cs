using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

//Interface for all the gamestates with the required methods
interface GameState
{
    void update(GameTime gameTime);
    void draw(GameTime gameTime, SpriteBatch spriteBatch);
    void handleInput(InputHelper inputHelper);
    void drawHUD(SpriteBatch spriteBatch);
}

class GameStateManager : GameState
{
    //Hold the current gamestate object
    public GameState gameState;

    public bool menuState;
    public bool playingState;

    //Method to change the current gamestate
    public void changeGameState()
    {
        playingState = true;
        if (menuState == true)
        {
            gameState = new MenuState();
        }
        else if (playingState == true)
        {
            gameState = new PlayingState();
        }

    }

    //Draw the gamestate every loop
    public void draw(GameTime gameTime, SpriteBatch spriteBatch)
    {
        if (gameState != null)
        {
            gameState.draw(gameTime, spriteBatch);
        }
    }

    //Handle the input for the gamestate
    public void handleInput(InputHelper inputHelper)
    {
        if (gameState != null)
            gameState.handleInput(inputHelper);
    }

    //Update the gamestate
    public void update(GameTime gameTime)
    {
        if (gameState != null)
            gameState.update(gameTime);
    }

    public void drawHUD(SpriteBatch spriteBatch)
    {
        if (gameState != null)
        {
            gameState.drawHUD(spriteBatch);
        }
    }
}

