using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;

public class Unit : AnimatedEntity
{
    protected int _faction;
    protected int _hp;
    protected int _armor;
    protected float _productionTime;
    protected int _lumberCost;
    protected int _goldCost;
    protected float _moveSpeed;

    protected List<Point> _path = new List<Point>();
    Pathfind pathfinder = new Pathfind();

    public enum armorType { Light, Heavy }
    protected armorType _armorType;

    public enum faction { Orc, Human, Neutral }
    protected faction _faction;

    public Unit()
        : base()
    {

    }

    public void init(Vector2 pos, string tex)
    {
        _position = pos;
        _sprite = new SpriteSheet(tex);
    }


    public void Update(GameTime gameTime)
    {
        this.UpdatePath();
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
        //Console.WriteLine(_path.Count);
        if (_path.Count > 0)
        {
            if (_path[0].X < (int)(_position.X / data.tSize()))
            {
                _position.X -= 1.0f;
            }
            else if (_path[0].X > (int)_position.X / data.tSize())
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


            if (new Point((int)_position.X / data.tSize(), (int)_position.Y / data.tSize()) == _path[0])
            {
                _path.RemoveAt(0);
            }

        }
    }

    public void OrderMove(Point target)
    {
        _path = pathfinder.findPathSimple(new Point((int)_position.X / data.tSize(), (int)_position.Y / data.tSize()), target);
    }
    private void move()
    {
        int x = (int)_position.X / data.tSize();
        int y = (int)_position.Y / data.tSize();
    }
}

