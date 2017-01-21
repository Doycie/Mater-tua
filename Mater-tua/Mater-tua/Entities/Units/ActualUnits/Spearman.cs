using Microsoft.Xna.Framework;

internal class Spearman : RangedUnit
{//basic melee unit van de Humans
    public Spearman(Level level, Vector2 Position)
        : base(level)
    {
        _faction = faction.Orc;
        _position = Position;
        _sprite = GameEnvironment.getAssetManager().GetSprite("Sprites/Units/Spearman");
        _description = "This warrior type is trained in the use of the spear. They can throw their spear across the battlefield, making them a ranged unit.";
    }
}