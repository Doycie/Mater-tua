using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

internal class Spritesheet : SpriteEntity
{
    protected int _alivefor;
    protected int _lifespan;
    protected int _rows;
    protected int _texSize;
    protected int _amountOfTex;


    public Spritesheet(string assetName, Vector2 pos, int size, int rows,int texSize, int amountOfTex,int lifeSpan, int layer = 0) : base(assetName, layer)
    {
        _position = pos;
        _lifespan = lifeSpan;
        _size = size;
        _rows = rows;
        _texSize = texSize;
        _alivefor = 0;
        _amountOfTex = amountOfTex;
    }

    public override void Update(GameTime gameTime)
    {
        _alivefor++;
    }

    public override void Draw(SpriteBatch spriteBatch)
    {
        int index = (int)_alivefor / _amountOfTex;
        spriteBatch.Draw(_sprite, new Rectangle((int)_position.X, (int)_position.Y, _size * data.tSize(), _size * data.tSize()), new Rectangle((index % _rows) * _texSize, (int)((index / _rows)) * _texSize, _texSize, _texSize), Color.White);
    }

    public bool remove()
    {
        if (_alivefor > _lifespan)
        {
            return true;
        }
        else return false;
    }
}