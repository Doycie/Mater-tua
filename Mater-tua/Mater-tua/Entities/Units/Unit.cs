using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

public class Unit : BuildingAndUnit
{
    protected int _productionTime = 400;
    protected float _moveSpeed = 2.0f;


    protected List<Point> _path = new List<Point>();
    private Pathfind pathfinder = new Pathfind();

    public Unit(Level level)
        : base(level)
    {
        
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

    public int ProductionTime
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
            int last = _path.Count - 1;
            if (_path[last].X * 64 < (_position.X))
            {
                _position.X -= _moveSpeed;
            }
            else if (_path[last].X * 64 > (_position.X))
            {
                _position.X += _moveSpeed;
            }
            if (_path[last].Y * 64 < (_position.Y))
            {
                _position.Y -= _moveSpeed;
            }
            else if (_path[last].Y * 64 > (_position.Y))
            {
                _position.Y += _moveSpeed;
            }

            if (new Point((int)(_position.X), (int)(_position.Y)) == new Point(_path[last].X * 64, _path[last].Y * 64))
            {
                _path.RemoveAt(last);
            }
        }
    }

    public void orderMove(Point target)
    {
        _path = pathfinder.findPathAStar(new Point((int)_position.X / data.tSize(), (int)_position.Y / data.tSize()), target,_level._mapData,_level);
    }

    public override void Draw(SpriteBatch s)
    {
        if (_visible)
        {
            base.Draw(s);
            //Healthbar(s);

            pathfinder.draw(s);

            //foreach (Point p in _path)
            // {
            //     s.Draw(_sprite, new Rectangle((int)p.X * 64, (int)p.Y * 64, data.tSize(), data.tSize()), Color.Yellow);
            // }

            // Console.WriteLine("SAD");
            // s.Draw(_sprite, new Rectangle((int)_position.X, (int)_position.Y, data.tSize(), data.tSize()), Color.White);*/
        }
    }
}