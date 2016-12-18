using System.Collections.Generic;
using Microsoft.Xna.Framework;
using System;
using Microsoft.Xna.Framework.Graphics;

class Button
{
    private Rectangle _position;
    private Texture2D _tex;
    private Texture2D _texPressed;
    private bool pressed;

    public Button(Rectangle position, Texture2D tex, Texture2D texPressed)
    {
        _texPressed = texPressed;
        _position = position;
        _tex = tex;
    }

    public bool click(Point p)
    {
        //Console.WriteLine("ASDSADSAD");
        if (_position.Contains(p))
        {
            //Console.WriteLine("CLICKED");
            pressed = true;
            return true;
        }
        pressed = false;
        return false;
    }
    public void draw(SpriteBatch s)
    {
        if(pressed)
            s.Draw(_texPressed, _position, Color.White);
        else
            s.Draw(_tex, _position, Color.White);
    }
}
class HUD
{
    protected List<Button> _buttons;
    public HUD()
    {

    }
    public void draw(SpriteBatch s)
    {
        foreach (Button b in _buttons)
        {
            b.draw(s);
        }
    }

    public void update(InputHelper inputHelper)
    {

       if (inputHelper.MouseLeftButtonPressed())
        {
           
            foreach (Button b in _buttons)
            {
                // Console.WriteLine(new Point((int)inputHelper.MousePosition.X, (int)inputHelper.MousePosition.Y));
                if(b.click(new Point((int)inputHelper.realMousePosition.X, (int)inputHelper.realMousePosition.Y)))
                {
                   // Console.WriteLine("ASD");
                }
            }
        }
    }
}

class HudUnit : HUD
{
    public HudUnit()
    {
        _buttons = new List<Button>();
        _buttons.Add(new Button(new Rectangle(32, (int)GameEnvironment.getCamera().getScreenSize().Y - 128, 100, 100), GameEnvironment.getAssetManager().GetSprite("Button"), GameEnvironment.getAssetManager().GetSprite("ButtonPressed")));
        _buttons.Add(new Button(new Rectangle(168, (int)GameEnvironment.getCamera().getScreenSize().Y - 128, 100, 100), GameEnvironment.getAssetManager().GetSprite("Button"), GameEnvironment.getAssetManager().GetSprite("ButtonPressed")));
        _buttons.Add(new Button(new Rectangle(296, (int)GameEnvironment.getCamera().getScreenSize().Y - 128, 100, 100), GameEnvironment.getAssetManager().GetSprite("Button"), GameEnvironment.getAssetManager().GetSprite("ButtonPressed")));
        //_buttons.Add(new Button(new Rectangle(0,0, 100, 100), GameEnvironment.getAssetManager().GetSprite("Button"), GameEnvironment.getAssetManager().GetSprite("ButtonPressed")));
    }

}
class HudManager
{


    //Holds the texture for the HUD background, which is always the same while playing the game.
    private Texture2D _tex;
    private HUD _hud = new HudUnit();

    public HudManager()
    {
      
        _tex = GameEnvironment.getAssetManager().GetSprite("WoodTextureTest");
    }

    public void draw(SpriteBatch spriteBatch)
    {
        for (int i = 0; i + _tex.Width <= GameEnvironment.getCamera().getScreenSize().X; i += _tex.Width) // repeats the HUD texture till edge of screen
            spriteBatch.Draw(_tex, new Rectangle(i, (int)GameEnvironment.getCamera().getScreenSize().Y - _tex.Height, _tex.Width, _tex.Height), Color.White);

        // spriteBatch.Draw(_tex, new Vector2(0, 450), Color.White);

        _hud.draw(spriteBatch);
    }

    public void updateHandleInput(InputHelper inputHelper)
    {
       
        _hud.update(inputHelper);

    }

}
