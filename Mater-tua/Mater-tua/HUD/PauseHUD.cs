using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;

class PauseHud : HUD
{
    private Texture2D _tex;
   
    public PauseHud()
    {
        _tex = GameEnvironment.getAssetManager().GetSprite("WoodTextureTest");

        _buttons = new List<Button>();
        /* 1*/
        //TODO: een continue button maken en posities fixen in fullscreen
        _buttons.Add(new Button(new Rectangle((int)(GameEnvironment.getCamera().getScreenSize().X / 2) - 96, (int)(GameEnvironment.getCamera().getScreenSize().Y / 2) + 160, 192, 64), GameEnvironment.getAssetManager().GetSprite("playButton"), GameEnvironment.getAssetManager().GetSprite("playButtonPressed")));
        /* 2 */
        _buttons.Add(new Button(new Rectangle((int)(GameEnvironment.getCamera().getScreenSize().X / 2) - 96, (int)(GameEnvironment.getCamera().getScreenSize().Y / 2) + 80, 192, 64), GameEnvironment.getAssetManager().GetSprite("exitButton"), GameEnvironment.getAssetManager().GetSprite("exitButtonPressed")));

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
            b.draw(spriteBatch);
        }
    }
}