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
    public PlayingState playingState;
    public MenuState menuState;

    bool menu;
    bool playing;

    public GameStateManager()
    {


    }


    //Draw the gamestate every loop
    public void draw(GameTime gameTime, SpriteBatch spriteBatch)
    {
        if (!menu)
        {
            playingState.draw(gameTime, spriteBatch);
        }
        else
        {
            menuState.draw(gameTime, spriteBatch);
        }


    }

    //Handle the input for the gamestate
    public void handleInput(InputHelper inputHelper)
    {
        if (!menu)
        {
            playingState.handleInput(inputHelper);
        }
        else
        {
            menuState.handleInput(inputHelper);
        }



    }

    //Update the gamestate
    public void update(GameTime gameTime)
    {



        if (menuState.playingState())
        {
            playing = true;
        }
        else playing = false;

        if (playingState.menuState())
        {
            menu = true;
        }
        else menu = false;

        if (playing == true)
            menu = false;
        else if (menu == true)
            playing = false;
        else if (menu == false)
            playing = true;
        else if (playing == false)
            menu = true;

        if (!menu)
        {
            playingState.update(gameTime);
        }
        else
        {
            menuState.update(gameTime);
        }



    }


    public void drawHUD(SpriteBatch spriteBatch)
    {
        if (!menu)
        {
            playingState.drawHUD(spriteBatch);
        }
        if (menu)
        {
            menuState.drawHUD(spriteBatch);
        }


    }

    public void initGameState()
    {
        playingState = new PlayingState();
        menuState = new MenuState();
    }
}

