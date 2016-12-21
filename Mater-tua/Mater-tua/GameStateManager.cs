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
    public enum state { Playing, Menu }
    public state State;
    public PlayingState playingState;
    public MenuState menuState;


    //bool menu;
    //bool playing;

    public GameStateManager()
    {
        State = state.Playing;

    }

    public state curState
    {
        get { return State; }
        set { State = value; }
    }

    //Draw the gamestate every loop
    public void draw(GameTime gameTime, SpriteBatch spriteBatch)
    {
        switch (State)
        {
            case state.Playing:
                playingState.draw(gameTime, spriteBatch);
                break;
            case state.Menu:
                menuState.draw(gameTime, spriteBatch);
                break;
        }

        /*if (!menu)
        {
            playingState.draw(gameTime, spriteBatch);
        }
        else
        {
            menuState.draw(gameTime, spriteBatch);
        }*/

    }

    //Handle the input for the gamestate
    public void handleInput(InputHelper inputHelper)
    {
        switch (State)
        {
            case state.Playing:
                playingState.handleInput(inputHelper);
                break;
            case state.Menu:
                menuState.handleInput(inputHelper);
                break;
        }/*
        if (!menu)
        {
            playingState.handleInput(inputHelper);
        }
        else
        {
            menuState.handleInput(inputHelper);
        }*/


    }

    //Update the gamestate
    public void update(GameTime gameTime)
    {
        switch (State)
        {
            case state.Playing:
                playingState.update(gameTime);
                break;
            case state.Menu:
                menuState.update(gameTime);
                break;
        }
        /*
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
        */

    }


    public void drawHUD(SpriteBatch spriteBatch)
    {
        switch (State)
        {
            case state.Playing:
                playingState.drawHUD(spriteBatch);
                break;
            case state.Menu:
                menuState.drawHUD(spriteBatch);
                break;
        }/*
        if (!menu)
        {
            playingState.drawHUD(spriteBatch);
        }
        if (menu)
        {
            menuState.drawHUD(spriteBatch);
        }*/
        
    }

    public void initGameState()
    {
        playingState = new PlayingState();
        menuState = new MenuState();
    }
}

