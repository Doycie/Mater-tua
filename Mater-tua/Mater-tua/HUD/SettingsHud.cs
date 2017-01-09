using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Media;


class SettingsHud : HUD
{

    private Texture2D _BGTex;

    public SettingsHud()
    {
        _BGTex = GameEnvironment.getAssetManager().GetSprite("MenuBG");

        _buttons = new List<Button>();
        /* 1 fullscreen*/
        _buttons.Add(new Button(new Rectangle((int)(GameEnvironment.getCamera().getScreenSize().X / 2) - 96, (int)(GameEnvironment.getCamera().getScreenSize().Y / 2) - 32, 192, 64), GameEnvironment.getAssetManager().GetSprite("fullscreenButton"), GameEnvironment.getAssetManager().GetSprite("fullscreenButtonPressed")));
        /* 2 back*/
        _buttons.Add(new Button(new Rectangle((int)(GameEnvironment.getCamera().getScreenSize().X / 2) - 96, (int)(GameEnvironment.getCamera().getScreenSize().Y / 2) - 96, 192, 64), GameEnvironment.getAssetManager().GetSprite("backButton"), GameEnvironment.getAssetManager().GetSprite("backButtonPressed")));
        /* 3 volume up */
        _buttons.Add(new Button(new Rectangle((int)(GameEnvironment.getCamera().getScreenSize().X / 2) + 32, (int)(GameEnvironment.getCamera().getScreenSize().Y / 2) - 160, 64, 64), GameEnvironment.getAssetManager().GetSprite("VolumeUp"), GameEnvironment.getAssetManager().GetSprite("VolumeUpPressed")));
        /* 4 volume down */
        _buttons.Add(new Button(new Rectangle((int)(GameEnvironment.getCamera().getScreenSize().X / 2) - 32, (int)(GameEnvironment.getCamera().getScreenSize().Y / 2) - 160, 64, 64), GameEnvironment.getAssetManager().GetSprite("VolumeDown"), GameEnvironment.getAssetManager().GetSprite("VolumeDownPressed")));
        /* 5 volume mute */
        _buttons.Add(new Button(new Rectangle((int)(GameEnvironment.getCamera().getScreenSize().X / 2) - 96, (int)(GameEnvironment.getCamera().getScreenSize().Y / 2) - 160, 64, 64), GameEnvironment.getAssetManager().GetSprite("VolumeMute"), GameEnvironment.getAssetManager().GetSprite("VolumeMutePressed")));

    }

    public new bool update(InputHelper inputHelper)
    {
        int j = base.update(inputHelper);

        switch (j)
        {
            case 0:
                break;
            case 1:
                Console.WriteLine("Fullscreen pressed");
                GameEnvironment.graphics.ToggleFullScreen();
                break;
            case 2:
                Console.WriteLine("Back pressed");
                GameEnvironment.gameStateManager.State = GameStateManager.state.Menu;
                break;
            case 3:
                MediaPlayer.Volume += (float)0.1;
                break;
            case 4:
                MediaPlayer.Volume -= (float)0.1;
                break;
            case 5:
                MediaPlayer.Volume = (float)0.0;
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
