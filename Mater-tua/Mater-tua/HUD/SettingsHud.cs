using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Media;
using System;
using System.Collections.Generic;

internal class SettingsHud : HUD
{
    private bool updateButtonPosition = false;
    private Texture2D _BGTex;

    public SettingsHud()
    {
        _BGTex = GameEnvironment.getAssetManager().GetSprite("Sprites/UI/MenuBG");

        _buttons = new List<Button>();
        initButtons();
    }

    private void initButtons()
    {
        _buttons.Clear();
        /* 1 fullscreen*/
        _buttons.Add(new Button(new Rectangle(96, -40, 192, 64), GameEnvironment.getAssetManager().GetSprite("Sprites/Buttons/fullscreenButton"), GameEnvironment.getAssetManager().GetSprite("Sprites/Buttons/fullscreenButtonPressed"), true));
        /* 2 back*/
        _buttons.Add(new Button(new Rectangle(96, -104, 192, 64), GameEnvironment.getAssetManager().GetSprite("Sprites/Buttons/backButton"), GameEnvironment.getAssetManager().GetSprite("Sprites/Buttons/backButtonPressed"), true));
        /* 3 volume up */
        _buttons.Add(new Button(new Rectangle(-32, -168, 64, 64), GameEnvironment.getAssetManager().GetSprite("Sprites/Buttons/VolumeUp"), GameEnvironment.getAssetManager().GetSprite("Sprites/Buttons/VolumeUpPressed"), true));
        /* 4 volume down */
        _buttons.Add(new Button(new Rectangle(32, -168, 64, 64), GameEnvironment.getAssetManager().GetSprite("Sprites/Buttons/VolumeDown"), GameEnvironment.getAssetManager().GetSprite("Sprites/Buttons/VolumeDownPressed"), true));
        /* 5 volume mute */
        _buttons.Add(new Button(new Rectangle(96, -168, 64, 64), GameEnvironment.getAssetManager().GetSprite("Sprites/Buttons/VolumeMute"), GameEnvironment.getAssetManager().GetSprite("Sprites/Buttons/VolumeMutePressed"), true));
    }

    public new bool update(InputHelper inputHelper)
    {
        int j = base.update(inputHelper);

        if (updateButtonPosition)
        {
            initButtons();
            updateButtonPosition = false;
        }

        switch (j)
        {
            case 0:
                break;

            case 1:
                GameEnvironment.fullScreen(true);
                Console.WriteLine("Fullscreen pressed");
                // updateButtonPosition = true;

                break;

            case 2:
                Console.WriteLine("Back pressed");
                GameEnvironment.gameStateManager.State = GameStateManager.state.Menu;
                break;

            case 3:
                MediaPlayer.Volume += (float)0.1;
                try
                {
                    SoundEffect.MasterVolume += (float)0.1;
                }
                catch
                {
                    SoundEffect.MasterVolume = 1;
                }
                break;

            case 4:
                MediaPlayer.Volume -= (float)0.1;
                try
                {
                    SoundEffect.MasterVolume -= (float)0.1;
                }
                catch
                {
                    SoundEffect.MasterVolume = 0;
                }
                break;

            case 5:
                MediaPlayer.Volume = (float)0.0;
                SoundEffect.MasterVolume = (float)0.0;
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