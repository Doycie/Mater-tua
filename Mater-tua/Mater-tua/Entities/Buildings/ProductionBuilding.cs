using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

internal class ProductionBuilding : StaticBuilding
{
    private bool _producingArcher = false;
    private bool _archerReady = false;
    private bool _producingFootman = false;
    private bool _footmanReady = false;
    private bool _producingUnit = false;
    private int _footmanCreationTimer;
    private int _archerCreationTimer;
    private Vector2 _footmanPosition;
    private Vector2 _archerPosition;

    public ProductionBuilding(Level level) : base(level)
    {
    }

    public void produceFootman(Level level, Vector2 position)
    {
        _footmanPosition = position;
        _level = level;
        if (level.Player.Gold >= 400 && level.Player.Food >= 0 && _producingFootman == false && _producingUnit == false)
        {
            Console.WriteLine("Creating Footman");
            level.Player.AddGold(-400);
            level.Player.AddFood(-1);

            _producingFootman = true;
            _producingUnit = true;
        }

        if (_footmanReady)
        {
            _footmanCreationTimer = 0;
            _producingFootman = false;
            _footmanReady = false;
            _producingUnit = false;
            Footman e = new Footman(level, new Vector2(position.X + 2 * data.tSize(), position.Y + data.tSize()));
            level.entities.Add(e);
        }
    }

    public void produceRangedUnit(Level level, Vector2 position)
    {
        _archerPosition = position;
        _level = level;
        if (level.Player.Gold >= 400 && level.Player.Food >= 0 && level.Player.Wood >= 50 && _producingArcher == false && _producingUnit == false)
        {
            Console.WriteLine("Creating ranged unit.");
            level.Player.AddGold(-400);
            level.Player.AddWood(-50);
            level.Player.AddFood(-1);

            _producingArcher = true;
            _producingUnit = true;
        }

        if (_archerReady)
        {
            _archerCreationTimer = 0;
            _producingArcher = false;
            _archerReady = false;
            _producingUnit = false;
            RangedUnit e = new RangedUnit(level, new Vector2(position.X + 2 * data.tSize(), position.Y + data.tSize()), faction.Human);
            level.entities.Add(e);
        }
        
    }

    public override void Update()
    {
        base.Update();
        if (_producingFootman)
        {
            _footmanCreationTimer += 1;
            if (_footmanCreationTimer >= 600)
            {
                _producingFootman = false;
                _footmanReady = true;
                produceFootman(_level, _footmanPosition);
            }
        }

        if (_producingArcher)
        {
            _archerCreationTimer += 1;
            if (_archerCreationTimer >= 750)
            {
                _producingArcher = false;
                _archerReady = true;
                produceRangedUnit(_level, _archerPosition);
            }
        }
    }
}  