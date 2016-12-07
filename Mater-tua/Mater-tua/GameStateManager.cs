using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
interface GameState
{
    void update(GameTime gameTime);
    void draw(GameTime gameTime, SpriteBatch spriteBatch);
    void handleInput(InputHelper inputHelper);
}


class GameStateManager : GameState
{
    GameState gameState;
    public void changeGameState()
    {
        gameState = new PlayingState();
    }
    public void draw(GameTime gameTime, SpriteBatch spriteBatch)
    {

        if (gameState != null)
        {
         
            gameState.draw(gameTime, spriteBatch);
        }
    }

    public void handleInput(InputHelper inputHelper)
    {
        if (gameState != null)
            gameState.handleInput(inputHelper);
    }

    public void update(GameTime gameTime)
    {
        if (gameState != null)
            gameState.update(gameTime);
    }
}

