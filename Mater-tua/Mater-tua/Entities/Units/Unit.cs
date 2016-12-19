using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;

public class Unit : AnimatedEntity
{


    protected Entity _target;
    protected int _hp;
    protected int _armor;
    protected float _productionTime;
    protected int _lumberCost;
    protected int _goldCost;
    protected float _moveSpeed = 2.0f;
    protected string _description;

    protected List<Point> _path = new List<Point>();
    Pathfind pathfinder = new Pathfind();

    public enum armorType { Light, Heavy, Fortified }
    protected armorType _armorType;

    public enum faction { Orc, Human, Neutral }
    protected faction _faction;

    protected Texture2D _tex;

    public Unit()
        : base()
    {

    }

    public void init(Vector2 pos, string tex)
    {
        _position = pos;
        _tex = GameEnvironment.getAssetManager().GetSprite(tex);
    }

    public void hurt(int a)
    {
        _hp -= a;
    }
    public virtual void Update()
    {

        this.UpdatePath();
    }

    public string Description
    {
        get { return _description; }
    }
    public int LumberCost
    {
        get { return _lumberCost; }
    }

    public int GoldCost
    {
        get { return _goldCost; }
    }

    public int HitPoints
    {
        get { return _hp; }
        set { _hp = value; }
    }

    public int Armor
    {
        get { return _armor; }
    }

    public armorType ArmorType
    {
        get { return _armorType; }
    }

    public faction Faction
    {
        get { return _faction; }
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
            if (_path[0].X * 64  < (_position.X ))
            {
                _position.X -= _moveSpeed;
            }
            else if (_path[0].X * 64 > (_position.X ))
            {
                _position.X += _moveSpeed;
            }
            if (_path[0].Y * 64< (_position.Y ))
            {
                _position.Y -= _moveSpeed;
            }
            else if (_path[0].Y * 64> (_position.Y ))
            {
                _position.Y += _moveSpeed;
            }

            if (new Point((int)(_position.X  ), (int)(_position.Y)) == new Point( _path[0].X * 64, _path[0].Y * 64))
            {
                _path.RemoveAt(0);
            }

        }
    }
    public void removeTarget()
    {
        _target = null;
    }
    public void orderMove(Point target)
    {
       
        _path = pathfinder.findPathSimple(new Point((int)_position.X / data.tSize(), (int)_position.Y / data.tSize()), target);
    }


    public override void Draw(SpriteBatch s)
    {
        foreach (Point p in _path)
        {
            s.Draw(_sprite, new Rectangle((int)p.X * 64, (int)p.Y * 64, data.tSize(), data.tSize()), Color.Blue);
        }

        // Console.WriteLine("SAD");
        s.Draw(_sprite, new Rectangle((int)_position.X, (int)_position.Y, data.tSize(), data.tSize()), Color.White);
    }


}

