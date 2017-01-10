using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

class Minimap
{

    private Texture2D _minimap;

    private int _size;


    public Minimap(int size)
    {
        _size = size;
        _minimap = new Texture2D(GameEnvironment.graphics.GraphicsDevice, size, size);
        Color[] data = new Color[_size * _size];

        for (int i = 0; i < data.Length; ++i) data[i] = Color.Chocolate;
        _minimap.SetData(data);

    }

    public void draw(SpriteBatch s)
    {
        s.Draw(_minimap, new Rectangle((int)GameEnvironment.getCamera().getScreenSize().X - _size, (int)GameEnvironment.getCamera().getScreenSize().Y - _size, _size, _size), Color.White);

    }

    public void update(Level level)
    {
        Color[] data = new Color[_size * _size];

        for (int i = 0; i < data.Length; ++i) data[i] = Color.Chocolate;

        foreach (BuildingAndUnit e in level.entities)
        {
            Color c = Color.White;
            if (e.Faction == BuildingAndUnit.faction.Human)
            {
                c = Color.Blue;
            }
            else if (e.Faction == BuildingAndUnit.faction.Orc)
            {
                c = Color.Red;
            }
            else
            {
                c = Color.SandyBrown;
            }
            int a = (int)(e.Position.X / 64) * 4 + (((int)e.Position.Y / 64) * 64 * 4) * 4;

            for (int i = 0; i < 4; i++)
            {
                int b = a;
                b += i % 2;
                b += i / 2 * 256;

                if (!(b < 0 || b > 256 * 256 - 1))

                    data[b] = c;
            }


        }



        _minimap.SetData(data);
    }

}


