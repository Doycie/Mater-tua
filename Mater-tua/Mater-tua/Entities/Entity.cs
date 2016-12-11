using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

class Entity
{
    Vector2 _position;
    Texture2D _tex;
    Point _tilePos;
    

    public void init(Vector2 pos, Texture2D tex)
    {
        _position = pos;
        _tex = tex;
    }

    public void update()
    {
        
    }

    private void move()
    {
        int x = (int)_position.X / data.tSize();
        int y = (int)_position.Y / data.tSize();

    }

    public void draw(SpriteBatch s)
    {
        s.Draw(_tex, new Rectangle((int)_position.X,(int)_position.Y,(int)_position.X + data.tSize(), (int)_position.Y+ data.tSize()), Color.White);
    }
}

