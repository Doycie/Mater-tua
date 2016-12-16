using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

public class SpriteEntity : Entity
{
    protected SpriteSheet _sprite;
    protected Vector2 _origin;

    public SpriteEntity(string assetName, int layer = 0,  int sheetIndex = 0)
        : base(layer)
    {
        if (assetName != "")
        {
            _sprite = new SpriteSheet(assetName, sheetIndex);
        }
        else
        {
            _sprite = null;
        }
    }

    public virtual void Draw( SpriteBatch spriteBatch)
    {
        if (_sprite == null)
        {
            return;
        }
        _sprite.Draw(spriteBatch, this.Position, _origin - _origin/ 2.0f);
    }

    public SpriteSheet Sprite
    {
        get { return _sprite; }
    }

    public Vector2 Center
    {
        get { return new Vector2(Width, Height) / 2; }
    }

    public int Width
    {
        get { return _sprite.Width; }
    }

    public int Height
    {
        get { return _sprite.Height; }
    }


    public Vector2 Origin
    {
        get { return _origin; }
        set { _origin = value; }
    }

    public Rectangle BoundingBox
    {
        get
        {
            int left = (int)(Position.X - _origin.X);
            int top = (int)(Position.Y - _origin.Y);
            return new Rectangle(left, top, Width, Height);
        }
    }

}

