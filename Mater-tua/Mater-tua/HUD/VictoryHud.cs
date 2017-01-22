using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;

internal class VictoryHud : HUD
{
    private Texture2D _BGTex;

    public VictoryHud()
    {
        _BGTex = GameEnvironment.getAssetManager().GetSprite("Sprites/UI/Victory");
        //TODO: Fix position of the buttons
        _buttons = new List<Button>();
        
        /* 1 quit to menu*/
        _buttons.Add(new Button(new Rectangle(300, 150, 250, 130), GameEnvironment.getAssetManager().GetSprite("Sprites/Buttons/quitToMenuButton"), GameEnvironment.getAssetManager().GetSprite("Sprites/Buttons/quitToMenuButtonPressed"), false));
        /* 2 exit game */
        _buttons.Add(new Button(new Rectangle(800, 150, 250, 130), GameEnvironment.getAssetManager().GetSprite("Sprites/Buttons/exitButton"), GameEnvironment.getAssetManager().GetSprite("Sprites/Buttons/exitButtonPressed"), false));
    }

    public new bool update(InputHelper inputHelper)
    {
        int j = base.update(inputHelper);

        switch (j)
        {
            case 0:
                break;

            case 1:
                Console.WriteLine("Back to Menu pressed from Victory");
                GameEnvironment.gameStateManager.State = GameStateManager.state.Menu;
                break;

            case 2:
                GameEnvironment.exit();
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

