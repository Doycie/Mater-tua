using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

class Resources
{
    private int _resourceNumber;
    private Texture2D _resourceTex;
    
    public int getNumber()
    {
        return _resourceNumber;
    }

    public void setNumber(int number)
    {
        _resourceNumber = number;
    }

    public Resources(int number, Texture2D resourceTex)
    {
        _resourceTex = resourceTex;
        _resourceNumber = number;
    }

    public void draw(SpriteBatch s)
    {
       if (getNumber() == 1)
        {
            s.Draw(_resourceTex, new Rectangle((int)GameEnvironment.getCamera().getScreenSize().X / 2, (int)GameEnvironment.getCamera().getScreenSize().Y - 100, 30, 30), Color.White);
        }
    }
}