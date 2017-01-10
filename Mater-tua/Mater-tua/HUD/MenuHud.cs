using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Input;

class MenuHud : HUD
{
    private Texture2D _BGTex;


    public MenuHud()
    {
        _BGTex = GameEnvironment.getAssetManager().GetSprite("Sprites/UI/MenuBG");
        //TODO: Fix position of the buttons
        _buttons = new List<Button>();
        /* 1 play*/
        _buttons.Add(new Button(new Rectangle(96, - 40, 192, 64), GameEnvironment.getAssetManager().GetSprite("Sprites/Buttons/playButton"), GameEnvironment.getAssetManager().GetSprite("Sprites/Buttons/playButtonPressed"),true));
        /* 2 settings*/
        _buttons.Add(new Button(new Rectangle(96, -104 , 192, 64), GameEnvironment.getAssetManager().GetSprite("Sprites/Buttons/settingsButton"), GameEnvironment.getAssetManager().GetSprite("Sprites/Buttons/settingsButtonPressed"),true));
        /* 3 exit*/
        _buttons.Add(new Button(new Rectangle(96, -168, 192, 64), GameEnvironment.getAssetManager().GetSprite("Sprites/Buttons/exitButton"), GameEnvironment.getAssetManager().GetSprite("Sprites/Buttons/exitButtonPressed"),true));

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