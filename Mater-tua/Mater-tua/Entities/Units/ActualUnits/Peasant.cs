using Microsoft.Xna.Framework;

internal class Peasant: WorkerUnit
{//basic worker unit van de Humans
    public Peasant(Level level, Vector2 Position)
        : base(level)
    {
        _faction = faction.Human;
        _entityType = entityType.Worker;
        _position = Position;
        _sprite = GameEnvironment.getAssetManager().GetSprite("Sprites/Units/Peasant");
        _description = "The lowest ranked unit of the Human Alliance. They are used to construct buildings, cut wood and mine gold.";
    }
}

