using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Media;
using System;
//Interface for all the gamestates with the required methods
internal interface GameState
{
    void update(GameTime gameTime);

    void draw(GameTime gameTime, SpriteBatch spriteBatch);

    void handleInput(InputHelper inputHelper);

    void drawHUD(SpriteBatch spriteBatch);
}

internal class GameStateManager : GameState
{
    //Hold the current gamestate object
    public enum state { Playing, Menu, Pause, Settings, PauseSettings, Victory, Defeat }

    public state State;
    public PlayingState playingState;
    public MenuState menuState;
    public PauseState pauseState;
    public SettingsState settingsState;
    public PauseSettingsState pausesettingsState;
    public VictoryState victoryState;
    public DefeatState defeatState;

    public GameStateManager()
    {
        State = state.Menu;
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

            case state.Pause:
                playingState.draw(gameTime, spriteBatch);
                break;

            case state.Settings:
                settingsState.draw(gameTime, spriteBatch);
                break;

            case state.PauseSettings:
                playingState.draw(gameTime, spriteBatch);
                break;

            case state.Victory:
                victoryState.draw(gameTime, spriteBatch);
                break;

            case state.Defeat:
                defeatState.draw(gameTime, spriteBatch);
                break;

        }
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

            case state.Pause:
                pauseState.handleInput(inputHelper);
                break;

            case state.Settings:
                settingsState.handleInput(inputHelper);
                break;

            case state.PauseSettings:
                pausesettingsState.handleInput(inputHelper);
                break;

            case state.Victory:
                victoryState.handleInput(inputHelper);
                break;

            case state.Defeat:
                defeatState.handleInput(inputHelper);
                break;
        }
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

            case state.Pause:
                break;

            case state.Settings:
                break;

            case state.PauseSettings:
                break;

            case state.Victory:
                break;

            case state.Defeat:
                break;
        }
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

            case state.Pause:
                pauseState.drawHUD(spriteBatch);
                break;

            case state.Settings:
                settingsState.drawHUD(spriteBatch);
                break;

            case state.PauseSettings:
                pausesettingsState.drawHUD(spriteBatch);
                break;

            case state.Victory:
                victoryState.drawHUD(spriteBatch);
                break;

            case state.Defeat:
                defeatState.drawHUD(spriteBatch);
                break;
        }
    }

    public void initGameState()
    {
        playingState = new PlayingState();
        menuState = new MenuState();
        pauseState = new PauseState();
        settingsState = new SettingsState();
        pausesettingsState = new PauseSettingsState();
        victoryState = new VictoryState();
        defeatState = new DefeatState();

        Console.WriteLine("SET VOLUME TO 0 FOR DEBUGGING");
        MediaPlayer.Volume = 0.0f;
    }
}