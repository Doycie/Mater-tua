using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Media;

class MenuHud : HUD
{

    public MenuHud()
    { //TODO: Fix position of the buttons
        _buttons = new List<Button>();
        /* 1*/
        _buttons.Add(new Button(new Rectangle((int)(GameEnvironment.getCamera().getScreenSize().X / 2), (int)(GameEnvironment.getCamera().getScreenSize().Y / 2), 192, 64), GameEnvironment.getAssetManager().GetSprite("playButton"), GameEnvironment.getAssetManager().GetSprite("playButtonPressed")));
        /* 2 */
        _buttons.Add(new Button(new Rectangle((int)(GameEnvironment.getCamera().getScreenSize().X / 2), (int)(GameEnvironment.getCamera().getScreenSize().Y / 2) - 80, 192, 64), GameEnvironment.getAssetManager().GetSprite("settingsButton"), GameEnvironment.getAssetManager().GetSprite("settingsButtonPressed")));
        /* 3 */
        _buttons.Add(new Button(new Rectangle((int)(GameEnvironment.getCamera().getScreenSize().X / 2), (int)(GameEnvironment.getCamera().getScreenSize().Y / 2) - 160, 192, 64), GameEnvironment.getAssetManager().GetSprite("exitButton"), GameEnvironment.getAssetManager().GetSprite("exitButtonPressed")));

    }

    public new bool update(InputHelper inputHelper)
    {
        int j = base.update(inputHelper);

        switch (j)
        {
            case 0:
                break;
            case 1:
                Console.WriteLine("Play pressed");
                GameEnvironment.gameStateManager.State = GameStateManager.state.Playing;
                break;
            case 2:
                GameEnvironment.gameStateManager.State = GameStateManager.state.Settings;
                Console.WriteLine("Settings pressed");
                break;
            case 3:
                //TODO: actually exit the game
                Console.WriteLine("Exit button pressed");
                break;
        }
        return false;
    }

    public override void draw(SpriteBatch spriteBatch)
    {
        foreach (Button b in _buttons)
        {
            //TODO sprite beweegt mee als in de playingstate de camera wordt bewogen
            b.draw(spriteBatch);
        }
    }
}