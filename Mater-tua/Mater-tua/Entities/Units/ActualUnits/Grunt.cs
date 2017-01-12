using Microsoft.Xna.Framework;

internal class Grunt : BasicMeleeUnit
{//Basic melee unit van de Orcs
    public Grunt(Level level, Vector2 Position)
        : base(level)
    {
        _faction = faction.Orc;
        _position = Position;
        _sprite = GameEnvironment.getAssetManager().GetSprite("Sprites/Units/Orc");
        _description = "The first type of warriors that the Orc faction unlocks. They are trained in close combat and using an axe combined with a shield is their specialty.";
    }
}