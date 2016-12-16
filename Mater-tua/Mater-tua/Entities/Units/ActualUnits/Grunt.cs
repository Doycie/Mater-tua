using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;


class Grunt : BasicMeleeUnit
{
    public Grunt(Vector2 Position)
        : base()
    {
        _faction = faction.Orc;
        _position = Position;
        _sprite = new SpriteSheet("birb");
    }
}

