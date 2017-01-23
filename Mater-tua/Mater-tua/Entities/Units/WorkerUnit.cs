using Microsoft.Xna.Framework;
using System;

internal class WorkerUnit : Unit
{
    private Vector2 _TownhallPosition;
    private Vector2 _MinePosition;
    private Vector2 _TreasurePosition;
    private Vector2 _TreePosition;
    private Vector2 _TargetPosition;
    private int _FirstTime;
    private int _FirstTimeTree;
    private int _TimerTree;
    private int _Timer;
    private int _OrderLevel;
    private int _BuildLevel;
    private bool _done;
    private int _FirstTimeTreasure;
    private int _TimerTreasure;
    private Tree _tree;
    private Mine _mine;
    private TreasureChest _treasure;

    public WorkerUnit(Level level)
        : base(level)
    {
        _maxhp = 40;
        _armor = 0;
        _armorType = armorType.Light;
        _goldCost = 400;
        _lumberCost = 0;
        _damage = 10;
        _damageType = damageType.Piercing;
        _entityType = entityType.Worker;
        _productionTime = 750;
        _range = 1;
        Reset();
        _FirstTime = 0;
        _Timer = 60;
        _FirstTimeTree = 0;
        _TimerTree = 60;
        _OrderLevel = -1;
        _level = level;
        _moveButton = true;
        _stopButton = true;
        _mineGoldButton = true;
        _cutWoodButton = true;
        _buildBuildingButton = true;
 
    }

    public override void Reset()
    {
        _hp = _maxhp;
    }

    public override void Update()
    {
        base.Update();

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
            Build(_BuildLevel, _TargetPosition, _done);
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
        _mine = m;
    }

    public void CutWoodOrder(Tree t, Vector2 PositionTarget, Vector2 PositionTownhall )
    {
        _OrderLevel = 1;
        _TreePosition = PositionTarget;
        _tree = t;
        _TownhallPosition = PositionTownhall;
    }

    public void BuildOrder(Vector2 PositionTarget, Vector2 PositionTownhall, int BuildLevel = 0)
    {
        _OrderLevel = 2;
        _TargetPosition = PositionTarget;
        _BuildLevel = BuildLevel;
        _done = false;
    }

    public void TreasureOrder(TreasureChest T, Vector2 PositionTarget, Vector2 PositionTownhall)
    {
        _treasure = T;
        _OrderLevel = 3;
        _TreasurePosition = PositionTarget;
        _TownhallPosition = PositionTownhall;
    }

    public void OrderReset()
    {
        _FirstTime = 0;
        _FirstTimeTree = 0;
        _OrderLevel = -1;
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
                    _Timer = 60;
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
                if (_TimerTree == 0)
                {
                    orderMove(new Point((int)_TownhallPosition.X / data.tSize(), (int)_TownhallPosition.Y / data.tSize()));
                    _TimerTree = 60;
                    _tree.TreeUseage();
                }
                _TimerTree--;
            }
            if (_position == _TownhallPosition)
            {
                _level.Player.AddWood(10);
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
                if (_TimerTreasure == 0)
                {
                    orderMove(new Point((int)_TownhallPosition.X / data.tSize(), (int)_TownhallPosition.Y / data.tSize()));
                    _TimerTreasure = 60;
                    _treasure.TreasureUseage();
                }
                _TimerTreasure--;
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

    private void Build(int BuildLevel, Vector2 TargetPosition, bool done)
    {
        if (done != true)
        {
            orderMove(new Point((int)TargetPosition.X / data.tSize(), (int)TargetPosition.Y / data.tSize()));
            if (_position == TargetPosition)
            {
                if (BuildLevel == 0)
                {
                    Farm farm = new Farm(_level, TargetPosition, _faction);
                    _level.entities.Add(farm);
                    _done = true;
                }
                if (BuildLevel == 1)
                {
                }
            }
        }
    }
}