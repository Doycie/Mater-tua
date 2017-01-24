using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;

internal class MenuHud : HUD
{
    private Texture2D _BGTex;

    public MenuHud()
    {
        _BGTex = GameEnvironment.getAssetManager().GetSprite("Sprites/UI/MenuBG");
        _buttons = new List<Button>();
        /* 1 play*/
        _buttons.Add(new Button(new Rectangle(550, 170, 250, 130), GameEnvironment.getAssetManager().GetSprite("Sprites/Buttons/playButton"), GameEnvironment.getAssetManager().GetSprite("Sprites/Buttons/playButtonPressed"), false));
        /* 2 settings*/
        _buttons.Add(new Button(new Rectangle(170, 170, 250, 130), GameEnvironment.getAssetManager().GetSprite("Sprites/Buttons/settingsButton"), GameEnvironment.getAssetManager().GetSprite("Sprites/Buttons/settingsButtonPressed"), false));
        /* 3 exit*/
        _buttons.Add(new Button(new Rectangle(930, 170, 250, 130), GameEnvironment.getAssetManager().GetSprite("Sprites/Buttons/exitButton"), GameEnvironment.getAssetManager().GetSprite("Sprites/Buttons/exitButtonPressed"), false));
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
                GameEnvironment.exit();
                Console.WriteLine("Exit button pressed");
                break;
        }
        return false;
    }

    public override void draw(SpriteBatch spriteBatch)
    {
        spriteBatch.Draw(_BGTex, new Rectangle(0, 0, (int)GameEnvironment.getCamera().getScreenSize().X, (int)GameEnvironment.getCamera().getScreenSize().Y), Color.White);

        foreach (Button b in _buttons)
        {
            b.draw(spriteBatch);
        }
    }
}