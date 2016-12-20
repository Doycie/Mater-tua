using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;


class CombatUnit : Unit
{

    protected int _attackCooldown;
    protected int isAttacking;

    public CombatUnit()
        : base()
    {

    }


    public override void Draw(SpriteBatch s)
    {
        //s.Draw(_sprite, new Rectangle((int)_position.X, (int)_position.Y, data.tSize(), data.tSize()), new Color(1.0f, isAttacking/60.0f == 0 ? 1.0f: isAttacking/ 60.0f , isAttacking / 60.0f==0 ? isAttacking /60.0f:1.0f, 1.0f));
        base.Draw(s);
        s.Draw(_sprite, new Rectangle((int)_position.X + data.tSize()/2, (int)_position.Y + data.tSize() / 2, data.tSize()/2, data.tSize()/2), null, new Color(1.0f,1.0f,1.0f,0.1f), (float)isAttacking, Vector2.Zero, SpriteEffects.None, 0.0f);

    }

    public override void Update()
    {

        _attackCooldown--;
        if (_target != null)
        {
          //  Console.WriteLine("THE ENEMY IS SIGHTED " + calculateH(new Point((int)Position.X, (int)Position.Y), new Point((int)_target.Position.X, (int)_target.Position.Y)) + " UNITS AWAY, AATTTTTTAACCCK!");
            if (calculateH(new Point((int)Position.X, (int)Position.Y), new Point((int)_target.Position.X, (int)_target.Position.Y)) < data.tSize())
            {
                //Console.WriteLine("ENGAGING FIST TO MOUTH COMBAT WITH THE ENEMY");
                _path.Clear();
                if (_attackCooldown < 0)
                {
                    _attackCooldown = 60;
                    isAttacking = 30;

                }
                isAttacking--;
                if (isAttacking <0)
                {
                    (_target as BuildingAndUnit).hurt(_damage);
                }
            }

        }else
        {
            _attackCooldown = 0;
            isAttacking = 0;
        }


        base.Update();
    }

    public void orderAttack(BuildingAndUnit e)
    {
        _target = e;
        orderMove(new Point((int)e.Position.X / data.tSize(), (int)e.Position.Y / data.tSize()));

    }
    
    double calculateH(Point x, Point y)
    {
        return Math.Sqrt(Math.Pow(x.X - y.X, 2) + Math.Pow(x.Y - y.Y, 2));
    }
}

