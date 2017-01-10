using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

public class SpriteEntity : Entity
{
    protected Texture2D _sprite;
    protected int _size = 1;

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

    public virtual void Draw(SpriteBatch spriteBatch)
    {
        spriteBatch.Draw(_sprite, new Rectangle((int)_position.X, (int)_position.Y, _size * data.tSize(), _size * data.tSize()), Color.White);
    }

    public int Size
    {
        get { return _size; }
    }

    public Texture2D Sprite
    {
        get { return _sprite; }
    }

    public Vector2 Center
    {
        get { return new Vector2(_position.X + Width / 2, _position.Y + Height / 2); }
    }

    public virtual int Width
    {
        get { return _size * data.tSize(); }
    }

    public virtual int Height
    {
        get { return _size * data.tSize(); }
    }
}