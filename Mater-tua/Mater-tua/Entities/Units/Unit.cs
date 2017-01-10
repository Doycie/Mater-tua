using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

public class Unit : BuildingAndUnit
{
    protected float _productionTime;
    protected float _moveSpeed = 2.0f;
    protected Level _level;

    protected List<Point> _path = new List<Point>();
    private Pathfind pathfinder = new Pathfind();

    public Unit(Level level)
        : base()
    {
        _level = level;
    }

    public void StopMove()
    {
        while (_path.Count > 1)
        {
            _path.RemoveAt(1);
        }
    }

    public void init(Vector2 pos, string tex)
    {
        //_level = level;
        _position = pos;
        _sprite = GameEnvironment.getAssetManager().GetSprite(tex);
    }

    public override void Update()
    {
        this.UpdatePath();
    }

    public float ProductionTime
    {
        get { return _productionTime; }
        set { _productionTime = value; }
    }

    public float MoveSpeed
    {
        get { return _moveSpeed; }
        set { _moveSpeed = value; }
    }

    public List<Point> Path
    {
        get { return _path; }
        set { _path = value; }
    }

    private void UpdatePath()
    {
        // Console.WriteLine(_path.Count);
        if (_path.Count > 0)
        {
            if (_path[0].X * 64 < (_position.X))
            {
                _position.X -= _moveSpeed;
            }
            else if (_path[0].X * 64 > (_position.X))
            {
                _position.X += _moveSpeed;
            }
            if (_path[0].Y * 64 < (_position.Y))
            {
                _position.Y -= _moveSpeed;
            }
            else if (_path[0].Y * 64 > (_position.Y))
            {
                _position.Y += _moveSpeed;
            }

            if (new Point((int)(_position.X), (int)(_position.Y)) == new Point(_path[0].X * 64, _path[0].Y * 64))
            {
                _path.RemoveAt(0);
            }
        }
    }

    public void orderMove(Point target)
    {
        _path = pathfinder.findPathSimple(new Point((int)_position.X / data.tSize(), (int)_position.Y / data.tSize()), target);
    }

    public override void Draw(SpriteBatch s)
    {
        base.Draw(s);
        Healthbar(s);

        /*foreach (Point p in _path)
        {
            s.Draw(_sprite, new Rectangle((int)p.X * 64, (int)p.Y * 64, data.tSize(), data.tSize()), Color.Blue);
        }

        // Console.WriteLine("SAD");
        s.Draw(_sprite, new Rectangle((int)_position.X, (int)_position.Y, data.tSize(), data.tSize()), Color.White);*/
    }
}