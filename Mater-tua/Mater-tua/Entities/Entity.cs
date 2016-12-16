using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

public class Entity
{

    protected Vector2 _position, _velocity;
    protected int _layer;

    public Entity(int layer = 0)
    {
        this._layer = layer;
        Reset();
    }

    public virtual void Update(GameTime gameTime)
    {
        _position += _velocity * (float)gameTime.ElapsedGameTime.TotalSeconds;
    }

    public virtual void Reset()
    {
        _position = Vector2.Zero;
        _velocity = Vector2.Zero;
    }

    public virtual Vector2 Position
    {
        get { return _position; }
        set { _position = value; }
    }

    public virtual Vector2 Velocity
    {
        get { return _velocity; }
        set { _velocity = value; }
    }

    public virtual int Layer
    {
        get { return _layer; }
        set { _layer = value; }
    }

}


