using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using System.Linq;
using System;

public class Unit : BuildingAndUnit
{
    protected int _productionTime = 400;
    protected float _moveSpeed = 2.0f;
    protected int _foodCost = 1;
    protected bool soundEffectCooldown;
    protected int soundEffectCooldownTimer;

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

    public override void Update(GameTime gameTime)
    {
        this.UpdatePath();
        if (soundEffectCooldown)
        {
            soundEffectCooldownTimer -= 1;
            if (soundEffectCooldownTimer <= 0)
                soundEffectCooldown = false;
        }
    }

    public int ProductionTime
    {
        get { return _productionTime; }
        set { _productionTime = value; }
    }

    public int FoodCost
    {
        get { return _foodCost; }
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
        if (_level._mapData[target.X, target.Y] == 0)
        {
            if (this is WorkerUnit)
            {
                _path = pathfinder.findPathAStar(new Point((int)_position.X / data.tSize(), (int)_position.Y / data.tSize()), target, _level._mapData, _level);
                if (_path.Count == 0)
                {
                    (this as WorkerUnit).OrderReset();
                }
            }
            else if (_level._entitiesData[target.X, target.Y] != (int)'t')
            {
                bool buildingInTheWay = false;
                foreach (StaticBuilding e in _level.entities.OfType<StaticBuilding>())
                {
                    if (_faction == e.Faction || _faction == BuildingAndUnit.faction.Neutral)
                    {
                        for (int j = 0; j < e.Size * e.Size; j++)
                        {
                            if (target == new Point((int)e.Position.X / 64 + (int)j / e.Size, (int)e.Position.Y / 64 + (int)j % e.Size))
                            {
                                buildingInTheWay = true;
                            }
                        }
                    }
                }

                if (!buildingInTheWay)
                {
                    if (!soundEffectCooldown && this._faction != BuildingAndUnit.faction.Orc)
                    {
                        soundEffectCooldownTimer = 300;
                        soundEffectCooldown = true;
                        int soundEffectNo = GameEnvironment.getRandom().Next(1, 3);

                        switch (soundEffectNo)
                        {
                            default:
                                    break;
                            case 1:
                                GameEnvironment.getAssetManager().PlaySoundEffect("Sounds/Soundeffects/Yes");
                                break;
                            case 2:
                                GameEnvironment.getAssetManager().PlaySoundEffect("Sounds/Soundeffects/Allright");
                                break;
                        }

                    }

                    _path = pathfinder.findPathAStar(new Point((int)_position.X / data.tSize(), (int)_position.Y / data.tSize()), target, _level._mapData, _level);
                }


            }
        }
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


