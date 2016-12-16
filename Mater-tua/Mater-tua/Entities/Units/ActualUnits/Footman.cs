using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;

class Footman : BasicMeleeUnit
{
    public Footman(Vector2 Position)
        : base()
    {
        _position = Position;
        _sprite = new SpriteSheet("birb");
    }
}

