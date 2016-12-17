using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

class Button
{
    private Rectangle _position;
    private Texture2D _tex;

    Button()
    {

    }

    public void init(Rectangle position, Texture2D tex)
    {
        _position = position;
        _tex = tex;
    }

    public bool click(Point p)
    {
        if (_position.Contains(p))
        {
            return true;
        }

        return false;
    }

}
class HUD
{
    private List<Button> _buttons;

    public void draw()
    {
        foreach (Button b in _buttons)
        {
            
        }
    }


}
class HudManager
{


    //Holds the texture for the HUD background, which is always the same while playing the game.
    private Texture2D _tex;


    public HudManager()
    {
        _tex = GameEnvironment.getAssetManager().GetSprite("WoodTextureTest");
    }

    public void draw(SpriteBatch spriteBatch)
    {
        spriteBatch.Draw(_tex, new Rectangle(0, (int)GameEnvironment.getCamera().getScreenSize().Y - _tex.Height, (int)GameEnvironment.getCamera().getScreenSize().X, _tex.Height), Color.White);
       // spriteBatch.Draw(_tex, new Vector2(0, 450), Color.White);
    }

    public void updateHandleInput(InputHelper inputHelper)
    {
        if (inputHelper.MouseLeftButtonPressed())
        {
           // foreach (Button b in _buttons)
            {
                //if (click(GameEnvironment.getCamera()))
                //{

                //}

            }
        }

    }

}
