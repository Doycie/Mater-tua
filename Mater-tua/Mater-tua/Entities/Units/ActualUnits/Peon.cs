using Microsoft.Xna.Framework;

internal class Peon : WorkerUnit
{//basic worker unit van de Orcs
    public Peon(Level level, Vector2 Position)
        : base(level)
    {
        _faction = faction.Orc;
        _position = Position;
        _sprite = GameEnvironment.getAssetManager().GetSprite("Sprites/Units/Peon");
        _description = "The lowest ranked unit of the Orcish horde. They are used to construct buildings, cut wood and mine gold.";
    }
}

