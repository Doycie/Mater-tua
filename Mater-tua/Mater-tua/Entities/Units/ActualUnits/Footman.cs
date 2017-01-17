using Microsoft.Xna.Framework;

internal class Footman : BasicMeleeUnit
{//basic melee unit van de Humans
    public Footman(Level level, Vector2 Position)
        : base(level)
    {
        _faction = faction.Human;
        _entityType = entityType.Combat;
        _position = Position;
        _sprite = GameEnvironment.getAssetManager().GetSprite("Sprites/Units/Human");
        _description = "The is most basic infantry unit. They are used for close combat. They fight in formations so that they can take down the more powerful opponents.";
    }
}