using Microsoft.Xna.Framework;
using System;
using Microsoft.Xna.Framework.Graphics;

internal class WorkerUnit : Unit
{
    private Vector2 _TownhallPosition;
    private Vector2 _MinePosition;
    private Vector2 _TreasurePosition;
    private Vector2 _TreePosition;
    private Vector2 _TargetPosition;
    private int _FirstTime;
    private int _FirstTimeTree;

    private int _MaxTimer =1;
    private int _Timer = 0;
    private int _OrderLevel;

    private int _FirstTimeTreasure;

    private Tree _tree;
    private Mine _mine;
    private TreasureChest _treasure;
    private bool _moveToBulding = false;
    private bool _building = false;
    private int _buildingIndex;

    public WorkerUnit(Level level)
        : base(level)
    {
        _maxhp = 40;
        _armor = 0;
        _armorType = armorType.Light;
        _goldCost = 400;
        _lumberCost = 0;
        _foodCost = 1;
        _damage = 10;
        _damageType = damageType.Piercing;
        _entityType = entityType.Worker;
        _productionTime = 750;
        _range = 1;
        Reset();
        _FirstTime = 0;
        _Timer = 0;
        _FirstTimeTree = 0;

        _OrderLevel = -1;
        _level = level;
        _moveButton = true;
        _stopButton = true;
        _mineGoldButton = true;
        _cutWoodButton = true;
        _healthbar = GameEnvironment.getAssetManager().GetSprite("Sprites/HUD/healthbar");
        _buildBuildingButton = true;
       
    }

    public override void Reset()
    {
        _hp = _maxhp;
    }

    public override void Update(GameTime gameTime)
    {
        base.Update(gameTime);

        if (_OrderLevel == 0)
        {
            Mining();
        }
        else if (_OrderLevel == 1)
        {
            CuttingWood();
        }
        else if (_OrderLevel == 2)
        {
            Build();
        }
        else if (_OrderLevel == 3)
        {
            OpenChest();
        }
    }



    public void MineOrder(Mine m, Vector2 PositionTarget, Vector2 PositionTownhall)
    {
        _OrderLevel = 0;
        _MinePosition = PositionTarget;
        _TownhallPosition = PositionTownhall;
        _MaxTimer = 300;
        _Timer = 300;
        _mine = m;
    }

    public void CutWoodOrder(Tree t, Vector2 PositionTarget, Vector2 PositionTownhall)
    {
        _OrderLevel = 1;
        _TreePosition = PositionTarget;
        _tree = t;
        _TownhallPosition = PositionTownhall;
        _Timer = 480;
        _MaxTimer = 480;
    }

    public void BuildOrder(Vector2 PositionTarget, int b)
    {
        _OrderLevel = 2;
        _TargetPosition = PositionTarget;
        _buildingIndex = b;
        _Timer = 300;
        _MaxTimer = 300;
        _building = false;
        _moveToBulding = false;
    }

    public void TreasureOrder(TreasureChest T, Vector2 PositionTarget, Vector2 PositionTownhall)
    {
        _treasure = T;
        _OrderLevel = 3;
        _TreasurePosition = PositionTarget;
        _TownhallPosition = PositionTownhall;
        _Timer = 60;
        _MaxTimer = 60;
    }

    public void OrderReset()
    {
        _FirstTime = 0;
        _FirstTimeTree = 0;
        _FirstTime = 0;
        _FirstTimeTreasure = 0;
        _Timer = 0;
        _OrderLevel = -1;
        _building = false;
        _moveToBulding = false;

    }

    private void Mining()
    {
        if (_mine.MineAmount > 0)
        {
            if (_position != _MinePosition && _position != _TownhallPosition && _FirstTime == 0)
            {
                orderMove(new Point((int)_MinePosition.X / data.tSize(), (int)_MinePosition.Y / data.tSize()));
                _FirstTime = 1;
            }

            if (_position == _MinePosition)
            {
                if (_Timer == 0)
                {
                    orderMove(new Point((int)_TownhallPosition.X / data.tSize(), (int)_TownhallPosition.Y / data.tSize()));
                    _Timer = 300;
                    _mine.MineUseage();
                }
                _Timer--;
            }
            if (_position == _TownhallPosition)
            {
                orderMove(new Point((int)_MinePosition.X / data.tSize(), (int)_MinePosition.Y / data.tSize()));
                _level.Player.AddGold(100);
                Console.WriteLine("Gold:" + _level.Player.Gold);
            }
        }
        else if (_mine.MineAmount == 0)
        {
            if (_position == _TownhallPosition)
            {
                _level.Player.AddGold(100);
                orderMove(new Point((int)_MinePosition.X / data.tSize(), (int)_MinePosition.Y / data.tSize()));
            }
        }
    }

    private void CuttingWood()
    {
        if (_tree.TreeAmount > 0)
        {
            if (_position != _TreePosition && _position != _TownhallPosition && _FirstTimeTree == 0)
            {
                orderMove(new Point((int)_TreePosition.X / data.tSize(), (int)_TreePosition.Y / data.tSize()));
                _FirstTimeTree = 1;
            }

            if (_position == _TreePosition)
            {
                if (_Timer == 0)
                {
                    orderMove(new Point((int)_TownhallPosition.X / data.tSize(), (int)_TownhallPosition.Y / data.tSize()));
                    _Timer= 480;
                    _tree.TreeUseage();
                }
                _Timer--;
            }
            if (_position == _TownhallPosition)
            {
                _level.Player.AddWood(100);
                orderMove(new Point((int)_TreePosition.X / data.tSize(), (int)_TreePosition.Y / data.tSize()));
                Console.WriteLine("Wood:" + _level.Player.Wood);
            }

        }
        else if (_tree.TreeAmount == 0)
        {
            if (_position == _TownhallPosition)
            {
                _level.Player.AddWood(10);
                orderMove(new Point((int)_TreePosition.X / data.tSize(), (int)_TreePosition.Y / data.tSize()));
            }
        }
    }
    private void OpenChest()
    {
        if (_treasure.TreasureAmount > 0)
        {
            if (_position != _TreasurePosition && _position != _TownhallPosition && _FirstTimeTreasure == 0)
            {
                orderMove(new Point((int)_TreasurePosition.X / data.tSize(), (int)_TreasurePosition.Y / data.tSize()));
                _FirstTimeTreasure = 1;
            }
            if (_position == _TreasurePosition)
            {
                if (_Timer == 0)
                {
                    orderMove(new Point((int)_TownhallPosition.X / data.tSize(), (int)_TownhallPosition.Y / data.tSize()));
                    _Timer = 60;
                    _treasure.TreasureUseage();
                }
                _Timer--;
            }
            if (_position == _TownhallPosition)
            {
                _level.Player.AddGold(100);
                orderMove(new Point((int)_TreasurePosition.X / data.tSize(), (int)_TreasurePosition.Y / data.tSize()));
                Console.WriteLine("Gold:" + _level.Player.Gold);
            }
        }
        else if (_treasure.TreasureAmount == 0)
        {
            if (_position == _TownhallPosition)
            {
                _level.Player.AddGold(100);
                orderMove(new Point((int)_TreasurePosition.X / data.tSize(), (int)_TreasurePosition.Y / data.tSize()));
            }
        }
    }

    private void Build()
    {
        if (_building)
        {
            if(Position == _TargetPosition)
            _Timer--;
            if (_Timer <= 0)
            {
                _building = false;
                if (_level._tempBuildings.Count > _buildingIndex && _level._tempBuildings[_buildingIndex] != null)
                {
                    _level.entities.Add(_level._tempBuildings[_buildingIndex]);
                    _level._tempBuildings.RemoveAt(_buildingIndex);
                    _moveToBulding = false;
                    _building = false;
                    _OrderLevel = -1;
                }
            }
        }
        else
        {
            if (!_moveToBulding)
            {

                orderMove(new Point((int)_TargetPosition.X / data.tSize(), (int)_TargetPosition.Y / data.tSize()));
                _moveToBulding = true;
            }
            if (_position == _TargetPosition)
            {
                _building = true;
                _Timer = 300;
            }
        }
    }

    public void Progressbar(SpriteBatch spriteBatch)
    {
        Vector2 pos = this.Position;
        int size = 1;


        DrawingHelper.DrawRectangle(new Rectangle((int)pos.X - 1, (int)pos.Y -8, (int)size * data.tSize() + 1, (int)data.tSize() / 10 + 1), spriteBatch, Color.White, 1);
        spriteBatch.Draw(_healthbar, new Rectangle((int)pos.X, (int)pos.Y - 7, (int)((float)(size * data.tSize()) * (1-((float)_Timer / (float)_MaxTimer))), data.tSize() / 10), Color.Red);

    }
    public override void Draw(SpriteBatch s)
    {
        base.Draw(s);
        if(_OrderLevel >= 0)
        this.Progressbar(s);
    }

}