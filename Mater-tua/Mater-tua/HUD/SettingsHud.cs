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
    public SettingsHud()
    {
        _buttons = new List<Button>();
        /* 1*/
        _buttons.Add(new Button(new Rectangle((int)(GameEnvironment.getCamera().getScreenSize().X / 2), (int)(GameEnvironment.getCamera().getScreenSize().Y / 2), 192, 64), GameEnvironment.getAssetManager().GetSprite("playButton"), GameEnvironment.getAssetManager().GetSprite("playButtonPressed")));
        /* 2 */
        _buttons.Add(new Button(new Rectangle((int)(GameEnvironment.getCamera().getScreenSize().X / 2), (int)(GameEnvironment.getCamera().getScreenSize().Y / 2) - 80, 192, 64), GameEnvironment.getAssetManager().GetSprite("backButton"), GameEnvironment.getAssetManager().GetSprite("backButtonPressed")));
        /* 3 */
         _buttons.Add(new Button(new Rectangle(450, 400, 40, 40), GameEnvironment.getAssetManager().GetSprite("VolumeUp"), GameEnvironment.getAssetManager().GetSprite("VolumeUpPressed")));
        /* 4 */
        _buttons.Add(new Button(new Rectangle(400, 400, 40, 40), GameEnvironment.getAssetManager().GetSprite("VolumeDown"), GameEnvironment.getAssetManager().GetSprite("VolumeDownPressed")));

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
                Console.WriteLine("Back pressed");
                GameEnvironment.gameStateManager.State = GameStateManager.state.Menu;
                break;
            case 3:
                MediaPlayer.Volume += (float)0.1;
                break;
            case 4:
                MediaPlayer.Volume -= (float)0.1;
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
