using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;



public class Projectile : SpriteEntity
{
    private Vector2 _velocity;
    private float _rotation;
    private Level _level;
    private BuildingAndUnit _target;


    public Projectile(Level level, BuildingAndUnit target, Vector2 pos, int layer = 0)
        : base("", layer)
    {
        _level = level;
        _target = target;
 
        _position = pos;
        _sprite = GameEnvironment.getAssetManager().GetSprite("Sprites/Units/rock");

        /*
                if (_shooter.Position.X < _target.Position.X)
                {
                    if (_shooter.Position.Y > _target.Position.Y)
                    {
                        _rotation = (float)Math.Atan2((_target.Position.X - _shooter.Position.X), (_target.Position.Y - _shooter.Position.Y));
                        Console.WriteLine(_rotation);
                    }
                    if(_shooter.Position.Y < _target.Position.Y)
                    {
                        _rotation = (float)Math.Atan2((_target.Position.X - _shooter.Position.X), (_target.Position.Y - _shooter.Position.Y));
                        Console.WriteLine(_rotation);
                    }
                }
                 if (_shooter.Position.X > _target.Position.X)
                {
                    if (_shooter.Position.Y > _target.Position.Y)
                    {
                        _rotation = (float)Math.Atan2((_target.Position.X - _shooter.Position.X), (_target.Position.Y - _shooter.Position.Y));
                        Console.WriteLine(_rotation);
                    }
                    if(_shooter.Position.Y < _target.Position.Y)
                    {
                        _rotation = (float)Math.Atan2((_target.Position.X - _shooter.Position.X), (_target.Position.Y - _shooter.Position.Y));
                        Console.WriteLine(_rotation);
                    }
                }
                 */

        _rotation = (float)Math.Atan2((_target.Position.X  - Position.X), (_target.Position.Y  - Position.Y));

        _velocity = new Vector2((float)Math.Sin(_rotation) * 64, (float)Math.Cos(_rotation) * 64) * 20f ;

        if (_velocity != Vector2.Zero)
        {
            _velocity.Normalize();
        }
    }

    public override void Update()
    {
        base.Update();
        Move();
    }

    public override void Draw(SpriteBatch spriteBatch)
    {
        spriteBatch.Draw(_sprite, new Rectangle((int)_position.X, (int)_position.Y, _size * data.tSize() / 4, _size * data.tSize() / 4), Color.White);
    }

    private void Move()
    {

        if (calculateH(new Point((int)_position.X, (int)_position.Y), new Point((int)_target.Position.X , (int)_target.Position.Y))  < 5)
        {
            _level.Projectiles.Remove(this);
            DamageEnemey();
            
        }
        else
        {
            _position = _position + _velocity * 5f;
        }
    }
    
    private void DamageEnemey()
    {
        _target.hurt(10);
    }

    private double calculateH(Point x, Point y)
    {
        return Math.Sqrt(Math.Pow(x.X - y.X, 2) + Math.Pow(x.Y - y.Y, 2));
    }

}

