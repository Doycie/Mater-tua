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
class PlayingState : GameState
{
    public void draw(GameTime gameTime, SpriteBatch spriteBatch)
    {

    }

    public void handleInput(InputHelper inputHelper)
    {
        if(inputHelper.IsKeyDown(Keys.A))
        {
            GameEnvironment.getCamera().move(new Vector2(-0.1f, 0.0f));
        }
       else if (inputHelper.IsKeyDown(Keys.D))
        {
            GameEnvironment.getCamera().move(new Vector2(0.1f, 0.0f));

        }
        else if (inputHelper.IsKeyDown(Keys.S))
        {
            GameEnvironment.getCamera().move(new Vector2(0.0f, 0.1f));
        }
        else if (inputHelper.IsKeyDown(Keys.W))
        {
            GameEnvironment.getCamera().move(new Vector2(0.0f, -0.1f));
        }
    }

    public void update(GameTime gameTime)
    {
       
    }
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
        if(gameState != null)
             gameState.draw(gameTime, spriteBatch);
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

