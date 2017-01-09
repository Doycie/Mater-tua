using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;

class Footman : BasicMeleeUnit
{//basic melee unit van de Humans

    public Footman(Level level,Vector2 Position)
        : base(level)
    {
        _faction = faction.Human;
        _position = Position;
        _sprite = GameEnvironment.getAssetManager().GetSprite("Human");
        _description = "The is most basic infantry unit. They are used for close combat. They fight in formations so that they can take down the more powerful opponents.";
    }
}

