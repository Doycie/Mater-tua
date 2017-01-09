using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;

class WorkerUnit : Unit
{
    Vector2 _TownhallPosition;
    Vector2 _MinePosition;
    Vector2 _TreePosition;
    int _FirstTime;
    int _FirstTimeTree;
    int _TimerTree;
    int _Timer;

    public WorkerUnit(Vector2 Position, faction faction)
        : base()
    {
        _sprite = GameEnvironment.getAssetManager().GetSprite("Human");
        _maxhp = 40;
        _armor = 0;
        _armorType = armorType.Light;
        _goldCost = 400;
        _lumberCost = 0;
        _damage = 10;
        _damageType = damageType.Piercing;
        _productionTime = 750;
        _range = 1;
        _position = Position;
        Reset();
        _FirstTime = 0;
        _Timer = 60;
        _FirstTimeTree = 0;
        _TimerTree= 60;
    }

    public override void Reset()
    {
        _hp = _maxhp;
    }

    public override void Update()
    {
        base.Update();
        Mining();
        
    }

    private void Mining()
    {
        _TownhallPosition = new Vector2(384, 384);
        _MinePosition = new Vector2(64, 64);

        if (_position != _MinePosition && _position != _TownhallPosition && _FirstTime == 0)
        {
            orderMove(new Point((int)_MinePosition.X / data.tSize(), (int)_MinePosition.Y / data.tSize()));
            _FirstTime = 1;
        }

        if (_position.X == _MinePosition.X && _position.Y == _MinePosition.Y)
        {
            if (_Timer == 0)
            {
                orderMove(new Point((int)_TownhallPosition.X / data.tSize(), (int)_TownhallPosition.Y / data.tSize()));
                _Timer = 60;
            }
            _Timer--;
        }
        if (_position.X  == _TownhallPosition.X && _position.Y == _TownhallPosition.Y)
        {
            
                orderMove(new Point((int)_MinePosition.X / data.tSize(), (int)_MinePosition.Y / data.tSize()));               
                              
        } 
    }

    private void CuttingWood()
    {
        _TownhallPosition = new Vector2(384, 384);
        _TreePosition = new Vector2(64, 64); 
        

        if (_position != _TreePosition && _position != _TownhallPosition && _FirstTimeTree == 0)
        {
            orderMove(new Point((int)_TreePosition.X / data.tSize(), (int)_TreePosition.Y / data.tSize()));
            _FirstTimeTree = 1;
        }

        if (_position.X == _TreePosition.X && _position.Y == _TreePosition.Y)
        {
            if (_TimerTree == 0)
            {
                orderMove(new Point((int)_TownhallPosition.X / data.tSize(), (int)_TownhallPosition.Y / data.tSize()));
                _TimerTree = 60;
            }
            _TimerTree--;
        }
        if (_position.X == _TownhallPosition.X && _position.Y == _TownhallPosition.Y )
        {
            
                orderMove(new Point((int)_TreePosition.X / data.tSize(), (int)_TreePosition.Y / data.tSize()));
            
        }
    }



}