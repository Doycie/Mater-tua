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
    private RangedUnit _shooter;

    public Projectile(Level level, BuildingAndUnit target, int layer = 0)
        : base("", layer)
    {
        _level = level;
        _target = target;
        //_shooter = shooter;
        _sprite = GameEnvironment.getAssetManager().GetSprite("Sprites/Units/Birb");

        /*
                if (_shooter.Position.X < _target.Position.X)
                {
                    if (_shooter.Position.Y < _target.Position.Y)
                    {
                        _rotation = (float)Math.Atan2((_target.Position.X - _shooter.Position.X), (_target.Position.Y - _shooter.Position.Y));
                        Console.WriteLine(_rotation);
                    }

                }

                _velocity = new Vector2((float)Math.Cos(_rotation), (float)Math.Sin(_rotation)) * 5f;
        */
        //_velocity = _target.Position - _shooter.Position;

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
        _position = _position * _velocity * 5f ;
    }

}

