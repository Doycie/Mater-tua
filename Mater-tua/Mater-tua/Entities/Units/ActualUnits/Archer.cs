using Microsoft.Xna.Framework;

internal class Archer : RangedUnit
{//basic melee unit van de Humans
    public Archer(Level level, Vector2 Position)
        : base(level)
    {
        _faction = faction.Human;
        _position = Position;
        _sprite = GameEnvironment.getAssetManager().GetSprite("Sprites/Units/Archer");
        _description = "This is first unit capable of ranged attacks. Ranged attacks are this units specialty so it want to maintain its distance to the opponent.";
    }
}