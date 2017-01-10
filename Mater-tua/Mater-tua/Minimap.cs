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
    // private Texture2D _mapborder; ??

    private int _size;


    public Minimap(int size)
    {
        _size = size;
        _minimap = new Texture2D(GameEnvironment.graphics.GraphicsDevice, size, size);
        Color[] data = new Color[_size * _size];

        for (int i = 0; i < data.Length; ++i) data[i] = Color.Chocolate;


      //  _mapborder = GameEnvironment.getAssetManager().GetSprite("Sprites/HUD/placeholderborder"); ?????
        _minimap.SetData(data);
    }
    public void draw(SpriteBatch s)
    {
        s.Draw(_minimap, new Rectangle((int) GameEnvironment.getCamera().getScreenSize().X - _size,(int) GameEnvironment.getCamera().getScreenSize().Y-_size, _size, _size), Color.White);
       // s.Draw(_mapborder, new Rectangle((int)GameEnvironment.getCamera().getScreenSize().X - _mapborder.Width, (int)GameEnvironment.getCamera().getScreenSize().Y - _mapborder.Height, 256, 256)); ??
    }

    public void update(Level level)
    {
        Color[] data = new Color[_size * _size];

        for (int i = 0; i < data.Length; ++i) data[i] = Color.Chocolate;

        foreach (Entity e in level.entities)
        {
            for(int i = 0; i < 4; i++)
            {
                int a = (int)(e.Position.X / 64)  *4 + (((int)e.Position.Y / 64) * 64 * 4) * 4;
                a += i % 2;
                a += i / 2 * 256;
                if( !(a <0 || a > 256*256 - 1)) 
                data[a] = Color.Blue; 
            }
          

        }
            


        _minimap.SetData(data);
    }

}


