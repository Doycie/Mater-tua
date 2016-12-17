using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

public class SpriteEntity : Entity
{
    protected Texture2D _sprite;

    public SpriteEntity(string assetName, int layer = 0)
        : base(layer)
    {
        if (assetName != "")
        {
            _sprite = GameEnvironment.getAssetManager().GetSprite(assetName); ;
        }
        else
        {
            _sprite = null;
        }
    }

    public virtual void Draw( SpriteBatch spriteBatch)
    {

    }

    public Texture2D Sprite
    {
        get { return _sprite; }
    }

    public Vector2 Center
    {
        get { return new Vector2(_position.X + Width / 2, _position.Y + Height / 2); }
    }

    public int Width
    {
        get { return data.tSize(); }
    }

    public int Height
    {
        get { return data.tSize(); }
    }

}

