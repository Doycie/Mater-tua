using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

public class Entity
{

    protected Entity _parent;
    protected Vector2 _position, _velocity;
    protected string _id;
    protected bool _visible;
    protected int _layer;

    public Entity(int layer = 0, string id = "")
    {
        this._layer = layer;
        this._id = id;
        Reset();
    }

    public virtual void HandleInput(InputHelper inputHelper)
    {

    }

    public virtual void Update(GameTime gameTime)
    {
        _position += _velocity * (float)gameTime.ElapsedGameTime.TotalSeconds;
    }

    public virtual void Draw(GameTime gameTime, SpriteBatch spriteBatch)
    {

    }

    public virtual void Reset()
    {
        _visible = true;
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

    public bool Visible
    {
        get { return _visible; }
        set { _visible = value; }
    }

    public virtual Entity Parent
    {
        get { return _parent; }
        set { _parent = value; }
    }

    public string Id
    {
        get { return _id; }
    }

    public virtual Vector2 GlobalPosition
    {
        get
        {
            if(_parent != null)
            {
                return _parent.GlobalPosition + Position;
            }
            else
            {
                return Position;
            }
        }
    }

    public Entity Root
    {
        get
        {
            if(_parent != null)
            {
                return _parent.Root;
            }
            else
            {
                return this;
            }
        }
    }
    /*
    public Entity GameWorld
    {
        get
        {
            return Root as EntityList
        }
    } */

    public virtual Rectangle BoundingBox
    {
        get
        {
            return new Rectangle((int)GlobalPosition.X, (int)GlobalPosition.Y, 0, 0);
        }
    }
}


