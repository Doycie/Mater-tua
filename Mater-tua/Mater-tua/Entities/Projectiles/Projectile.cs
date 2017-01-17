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
    private BuildingAndUnit _shooter;

    public Projectile(Level level, BuildingAndUnit target, BuildingAndUnit shooter, int layer = 0)
        : base("", layer)
    {
        _level = level;
        _target = target;
        _shooter = shooter;
        _position = _shooter.Position;
        _sprite = GameEnvironment.getAssetManager().GetSprite("Sprites/Units/Birb");

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

        _rotation = (float)Math.Atan2((_target.Position.X - _shooter.Position.X), (_target.Position.Y - _shooter.Position.Y));

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
        base.Draw(spriteBatch);
    }

    private void Move()
    {

        if (calculateH(new Point((int)_position.X, (int)_position.Y), new Point((int)_target.Position.X, (int)_target.Position.Y))  < 10)
        {

        }
        else
        {
            _position = _position + _velocity * 5f;
        }
    }

    private double calculateH(Point x, Point y)
    {
        return Math.Sqrt(Math.Pow(x.X - y.X, 2) + Math.Pow(x.Y - y.Y, 2));
    }

}

