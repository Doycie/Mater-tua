using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;


class RangedUnit : CombatUnit
{

    protected int isAttacking;
    protected int isAttackingBack;
    private bool PlayedAttackSound1 = false;
    private bool playedAttackSound2 = true;

    public RangedUnit(Level level)
        : base(level)
    {
        _maxhp = 40;
        _armor = 0;
        _armorType = armorType.Light;
        _entityType = entityType.Combat;
        _goldCost = 400;
        _lumberCost = 50;
        _damage = 10;
        _damageType = damageType.Piercing;
        _productionTime = 750;
        _range = 4;
        Reset();
        _level = level;
        _position = Position;
        _attackButton = true;
        _moveButton = true;
        _stopButton = true;
        _patrolButton = true;
        _holdPositionButton = true;
        _visionRange = 5;

    }

    public override void Reset()
    {
        _hp = _maxhp;
    }

    public override void Draw(SpriteBatch s)
    {
        base.Draw(s);
    }

    public override void doattack()
    {
        bool PlayedAttackSound = false;
        //Console.WriteLine("ENGAGING FIST TO MOUTH COMBAT WITH THE ENEMY");
        _path.Clear();
        if (_attackCooldown < 0)
        {

            if (PlayedAttackSound1 == false && playedAttackSound2 == true && PlayedAttackSound == false)
            { GameEnvironment.getAssetManager().PlaySoundEffect("Sounds/Soundeffects/SwordDraw"); PlayedAttackSound1 = true; playedAttackSound2 = false; PlayedAttackSound = true; }
            if (playedAttackSound2 == false && PlayedAttackSound1 == true && PlayedAttackSound == false)
            { GameEnvironment.getAssetManager().PlaySoundEffect("Sounds/Soundeffects/SwordClashHit"); PlayedAttackSound1 = false; playedAttackSound2 = true; PlayedAttackSound = true; }
            _attackCooldown = 120;
            isAttacking = 60;
        }
        //isAttacking--;
        if (isAttacking > 0)
        {
            if (isAttacking == 30)
            {
                Projectile projectile = new Projectile(_level, _target, new Vector2(_position.X + data.tSize() * 3 / 4, _position.Y + data.tSize() / 2));
                _level.Projectiles.Add(projectile);
            }
            isAttacking--;
        }
    }

    public override void Update(GameTime gameTime)
    {
        _defendCooldown--;
        _attackCooldown--;
        if (_target != null && (_target as BuildingAndUnit).HitPoints > 0)
        {
            if (_target.Size >= 2)
            {
                if (calculateH(new Point((int)Position.X, (int)Position.Y), new Point((int)_target.Position.X, (int)_target.Position.Y)) < data.tSize() * _range ||
                    calculateH(new Point((int)Position.X, (int)Position.Y), new Point((int)_target.Position.X + 68, (int)_target.Position.Y)) < data.tSize() * _range ||
                    calculateH(new Point((int)Position.X, (int)Position.Y), new Point((int)_target.Position.X, (int)_target.Position.Y + 68)) < data.tSize() * _range ||
                    calculateH(new Point((int)Position.X, (int)Position.Y), new Point((int)_target.Position.X + 68, (int)_target.Position.Y + 68)) < data.tSize() * _range)
                {
                    StopMove();
                    doattack();
                }
            }
            else
            //  Console.WriteLine("THE ENEMY IS SIGHTED " + calculateH(new Point((int)Position.X, (int)Position.Y), new Point((int)_target.Position.X, (int)_target.Position.Y)) + " UNITS AWAY, AATTTTTTAACCCK!");
            if (calculateH(new Point((int)_position.X, (int)_position.Y), new Point((int)_target.Position.X, (int)_target.Position.Y)) < (double)(data.tSize() * _range))
            {
                StopMove();
                doattack();
            }
        }
        else
        {
            _attackCooldown = 0;
            isAttacking = 0;
        }

        base.Update(gameTime);
    }


    public override void orderAttack(BuildingAndUnit e)
    {
        _target = e;

        if (typeof(SpriteEntity).IsAssignableFrom(e.GetType()))
        {
            if (e.Size >= 2)
            {
                Point a = new Point((int)e.Position.X / data.tSize(), (int)e.Position.Y / data.tSize());
                if (e.Position.X < _position.X)
                    a.X += 2;
                else if (e.Position.Y < _position.Y)
                    a.Y += 2;

                orderMove(a);
            }
            else
            {
                orderMove(new Point((int)e.Position.X / data.tSize(), (int)e.Position.Y / data.tSize()));
            }
        }
    }

    private double calculateH(Point x, Point y)
    {
        return Math.Sqrt(Math.Pow(x.X - y.X, 2) + Math.Pow(x.Y - y.Y, 2));
    }
}

