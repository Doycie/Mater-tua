using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
class Entity
{
    Vector2 _position;
    Texture2D _tex;
    Point _tilePos;
    Pathfind pathfinder = new Pathfind();
    List<Point> _path = new List<Point>();

    public Vector2 getPosition()
    {
        return _position;
    }

    public void init(Vector2 pos, Texture2D tex)
    {
        _position = pos;
        _tex = tex;
    }

    public void update()
    {
        //Console.WriteLine(_path.Count);
        if(_path.Count > 0)
        {
            if(_path[0].X < (int)(_position.X / data.tSize()))
            {
                _position.X -= 1.0f;
            }else if(_path[0].X > (int)_position.X / data.tSize())
            {
                _position.X += 1.0f;
            }
            if (_path[0].Y < (int)(_position.Y / data.tSize()))
            {
                _position.Y -= 1.0f;
            }
            else if (_path[0].Y > (int)_position.Y / data.tSize())
            {
                _position.Y += 1.0f;
            }

            if (new Point((int)(_position.X / data.tSize() ) , (int)(_position.Y / data.tSize())) == _path[0])
            {
                _path.RemoveAt(0);
            }

        }
    }

    public void orderMove(Point target)
    {
        _path = pathfinder.findPathSimple(new Point((int)_position.X / data.tSize(), (int)_position.Y / data.tSize()), target);
    }
    private void move()
    {
        int x = (int)_position.X / data.tSize();
        int y = (int)_position.Y / data.tSize();

    }

    public void draw(SpriteBatch s)
    {
        foreach (Point p in _path)
        {
            s.Draw(_tex, new Rectangle((int)p.X * 64, (int)p.Y * 64, data.tSize(), data.tSize()), Color.Blue);
        }
        s.Draw(_tex, new Rectangle((int)_position.X, (int)_position.Y,  data.tSize(), data.tSize()), Color.White);
    }
}

