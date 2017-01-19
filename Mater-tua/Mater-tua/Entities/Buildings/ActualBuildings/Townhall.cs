using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

internal class Townhall : StaticBuilding
{
    private bool _producingWorker = false;
    private bool _workerReady = false;
    private int _workerCreationTimer;
    private Vector2 _workerPosition;

    public Townhall(Level level, Vector2 position, faction faction)
        : base(level)
    {
        _EnemycanWalktrough = false;
        _Friendcanwalktrough = true;
        _size = 3;
        _position = position;
        _faction = faction;
        _maxhp = 25000;
        _lumberCost = 400;
        _goldCost = 400;
        _buildTime = 1000;
        _armor = 0;
        _ableToProduce = true;
        this.Reset();
        if (_faction == faction.Human)
        {
            _description = "This is the main building of the Human Alliance. Each settlement can only have one Town hall. It can rebuild if it is destroyed through battle.";
            _sprite = GameEnvironment.getAssetManager().GetSprite("Sprites/Buildings/HumanTownHall");
        }

        if (_faction == faction.Orc)
        {
            _description = "This is the main building of the Orcish army. Each encampment can only have one town hall, but it can be replaced if it is destroyed in battle.";
            _sprite = GameEnvironment.getAssetManager().GetSprite("Sprites/Buildings/OrcTownHall");
        }

    }

    public override void Reset()
    {
        _hp = _maxhp;
    }
    public override void Update()
    {
        base.Update();
        //FoodCreate();
        if ((float)_hp / (float)_maxhp < 1.0f / 3.0f)
        {

            if (_faction == faction.Human)
            {
                _sprite = GameEnvironment.getAssetManager().GetSprite("Sprites/Buildings/HumanTownHallConstruction");
            }
            if (_faction == faction.Orc)
            {
                _sprite = GameEnvironment.getAssetManager().GetSprite("Sprites/Buildings/OrcTownHallConstruction");
            }
        }

        if (_producingWorker)
        {
            _workerCreationTimer += 1;
            if (_workerCreationTimer >= 750)
            {
                _workerReady = true;
                produceWorkerUnit(_level, _workerPosition);
            }
        }
    }

    public override void Draw(SpriteBatch spriteBatch)
    {
        base.Draw(spriteBatch);
        //Healthbar(spriteBatch);
    }

    public void produceWorkerUnit(Level level, Vector2 TownhallPosition)
    {
        _level = level;
        _workerPosition = TownhallPosition;
        if (_level.Player.Gold >= 400 && _level.Player.AvailableFood >= 1 && _producingWorker == false)
        {
            Console.WriteLine("Creating worker unit.");
            _level.Player.AddGold(-400);
            _level.Player.availableFood(1);

            _producingWorker = true;
        }
        if (_workerReady)
        {
            _workerCreationTimer = 0;
            _producingWorker = false;
            _workerReady = false;
            Peasant peasant = new Peasant(_level, new Vector2(TownhallPosition.X + 3 * data.tSize(), TownhallPosition.Y + 2 * data.tSize()));
            _level.entities.Add(peasant);
        }
    }
}