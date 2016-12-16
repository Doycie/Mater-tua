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
   // public bool PerPixelCollisionDetection = true;

    public SpriteEntity(string assetName, int layer = 0, string id = "", int sheetIndex = 0)
        : base(layer, id)
    {
        if (assetName != "")
        {
            _sprite = new global::SpriteSheet(assetName, sheetIndex);
        }
        else
        {
            _sprite = null;
        }
    }

    public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
    {
        if (!Visible || _sprite == null)
        {
            return;
        }
        _sprite.Draw(spriteBatch, this.GlobalPosition, _origin);
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

    public bool Mirror
    {
        get { return _sprite.Mirror; }
        set { _sprite.Mirror = value; }
    }

    public Vector2 Origin
    {
        get { return _origin; }
        set { _origin = value; }
    }

    public override Rectangle BoundingBox
    {
        get
        {
            int left = (int)(GlobalPosition.X - _origin.X);
            int top = (int)(GlobalPosition.Y - _origin.Y);
            return new Rectangle(left, top, Width, Height);
        }
    }

/*    public bool CollidesWith(SpriteEntity obj)
    {
        if (!Visible || !obj.Visible || !BoundingBox.Intersects(obj.BoundingBox))
        {
            return false;
        }
        if (!PerPixelCollisionDetection)
        {
            return true;
        }
        Rectangle b = Collision.Intersection(BoundingBox, obj.BoundingBox);
        for (int x = 0; x < b.Width; x++)
        {
            int thisx = b.X - (int)(GlobalPosition.X - _origin.X) + x;
            int thisy = b.Y - (int)(GlobalPosition.Y - _origin.Y) + y;
            int objx = b.X - (int)(obj.GlobalPosition.X - obj._origin.X) + x;
            int objy = b.Y - (int)(obj.GlobalPosition.Y - obj._origin.Y) + y;
            if (_sprite.IsTranslucent(thisx, thisy) && obj._sprite.IsTranslucent(objx, objy))
            {
                return true;
            }
        }

        return false;
    }
*/

}

