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
    private int _foodCount;

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
}