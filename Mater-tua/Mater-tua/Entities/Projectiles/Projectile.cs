using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;



public class Projectile : SpriteEntity
{
    private Vector2 _velocity;
    private double _rotation;
    private float _delta;
    private Level _level;
    private BuildingAndUnit _target;
    


    public Projectile(Level level, BuildingAndUnit target, Vector2 pos, int layer = 0)
        : base("", layer)
    {
        _level = level;
        _target = target;
        _delta = 10;
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

      //  _rotation = (float)Math.Atan2(((_target.Position.X + _target.Size * data.tSize() / 2)  - _position.X), (_target.Position.Y  - (_position.Y + _target.Size * data.tSize() / 2)));

       // _velocity = new Vector2((float)Math.Sin(_rotation) * 64, (float)Math.Cos(_rotation) * 64) * 20f ;


    }

    public override void Update(GameTime gameTime)
    {
        base.Update(gameTime);
        _rotation = Math.Atan2((double)(_target.Position.Y + _target.Size * data.tSize() / 2) - _position.Y, (double)(_target.Position.X + _target.Size * data.tSize() / 2) - _position.X);
        _velocity = new Vector2(_delta * (float)Math.Cos(_rotation), _delta * (float)Math.Sin(_rotation));
        Move();
    }

    public override void Draw(SpriteBatch spriteBatch)
    {
        spriteBatch.Draw(_sprite, new Rectangle((int)Position.X, (int)Position.Y, _size * data.tSize() / 3, _size * data.tSize() / 3), null,Color.White,(float)_rotation, new Vector2(data.tSize() / 2f, data.tSize() / 2f),SpriteEffects.None,0f);
    }

    private void Move()
    {

        if (calculateH(new Point((int)_position.X, (int)_position.Y), new Point((int)_target.Position.X + _target.Size * data.tSize() / 2 , (int)_target.Position.Y + _target.Size * data.tSize() / 2))  < data.tSize() / 2)
        {
            _level.Projectiles.Remove(this);
            DamageEnemy();
            
        }
        else
        {
            _position +=  _velocity;
        }
    }
    
    private void DamageEnemy()
    {
        _target.hurt(15);
    }

    private double calculateH(Point x, Point y)
    {
        return Math.Sqrt(Math.Pow(x.X - y.X, 2) + Math.Pow(x.Y - y.Y, 2));
    }

}

