using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Media;


class PauseSettingsHud : HUD
{
    private Texture2D _tex;

    public PauseSettingsHud()
    {
        _tex = GameEnvironment.getAssetManager().GetSprite("WoodTextureTest");

        _buttons = new List<Button>();
        /* 1 fullscreen*/
        _buttons.Add(new Button(new Rectangle(96, 160, 192, 64), GameEnvironment.getAssetManager().GetSprite("fullscreenButton"), GameEnvironment.getAssetManager().GetSprite("fullscreenButtonPressed"),true));
        /* 2 back*/
        _buttons.Add(new Button(new Rectangle(96, 96, 192, 64), GameEnvironment.getAssetManager().GetSprite("backButton"), GameEnvironment.getAssetManager().GetSprite("backButtonPressed"),true));
        /* 3 volume up */
        _buttons.Add(new Button(new Rectangle(-32, 32, 64, 64), GameEnvironment.getAssetManager().GetSprite("VolumeUp"), GameEnvironment.getAssetManager().GetSprite("VolumeUpPressed"),true));
        /* 4 volume down */
        _buttons.Add(new Button(new Rectangle(32, 32, 64, 64), GameEnvironment.getAssetManager().GetSprite("VolumeDown"), GameEnvironment.getAssetManager().GetSprite("VolumeDownPressed"),true));
        /* 5 volume mute */
        _buttons.Add(new Button(new Rectangle(96, 32, 64, 64), GameEnvironment.getAssetManager().GetSprite("VolumeMute"), GameEnvironment.getAssetManager().GetSprite("VolumeMutePressed"),true));

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
                GameEnvironment.gameStateManager.State = GameStateManager.state.Pause;
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
        for (int i = 0; i + _tex.Width <= GameEnvironment.getCamera().getScreenSize().X + _tex.Width; i += _tex.Width) // repeats the HUD texture till edge of screen
            spriteBatch.Draw(_tex, new Rectangle(i, (int)GameEnvironment.getCamera().getScreenSize().Y - _tex.Height, _tex.Width, _tex.Height), Color.White);

        foreach (Button b in _buttons)
        {
            b.draw(spriteBatch);
        }
    }
}
