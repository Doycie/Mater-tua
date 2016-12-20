using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
class Explosion : SpriteEntity
{
    protected int alivefor;
    protected int lifespam;

    public Explosion(string assetName, Vector2 pos, int layer = 0) : base(assetName, layer)
    {
        _position = pos;
        lifespam = 180;

    }
    public override void Update()
    {
        alivefor++;
    }

    public override void Draw(SpriteBatch spriteBatch)
    {
        int index = (int)alivefor / 15;
        spriteBatch.Draw(_sprite, new Rectangle((int)_position.X, (int)_position.Y, _size * data.tSize(), _size * data.tSize()), new Rectangle( (index % 5 )* 96,(int)((index / 5) )* 96 , 96,96), Color.White);
   
    }
    public bool remove()
    {
        if (alivefor > lifespam)
        {
            return true;
        }
        else return false;
    }
}
