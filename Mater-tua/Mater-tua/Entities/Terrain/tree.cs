using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

class Tree : BuildingAndUnit
{
    public Tree(Vector2 Position)
        : base()
    {
        _sprite = GameEnvironment.getAssetManager().GetSprite("tree");
        _position = Position;
        _maxhp = 25000;
        this.Reset();
    }
    public override void Reset()
    {
        _hp = _maxhp;
    }

    public override void Draw(SpriteBatch spriteBatch)
    {
        base.Draw(spriteBatch);
    }

}

