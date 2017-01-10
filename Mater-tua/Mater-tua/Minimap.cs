﻿using System;
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
        s.Draw(_minimap, new Rectangle((int) GameEnvironment.getCamera().getScreenSize().X - _size -32,(int) GameEnvironment.getCamera().getScreenSize().Y-_size - 32, _size, _size), Color.White);

    }

    public void update(Level level)
    {
        Color[] data = new Color[_size * _size];

        for (int i = 0; i < data.Length; ++i) data[i] = Color.Chocolate;

        foreach (Entity e in level.entities)
        {
            for(int i = 0; i < 4; i++)
            {
                int a = (int)(e.Position.X / 256)*4  + (((int)e.Position.Y / 256) * 64 * 4) ;
                a += i % 2;
                a += i / 2 * 256;
                if( !(a <0 || a > 256*256 - 1))
                data[a] = Color.Blue;
            }
          

        }
            


        _minimap.SetData(data);
    }

}


