using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

internal class Farm : StaticBuilding
{// de basis voor de orc/human farms
    private int _Timer;

    public Farm(Level level, Vector2 position, faction faction)
        : base(level)
    {
        _size = 2;
        _position = position;
        _faction = faction;
        _maxhp = 2500;
        _lumberCost = 400;
        _goldCost = 400;
        _buildTime = 1000;
        _armor = 0;
        _ableToProduce = false;
        this.Reset();
        

        if (_faction == faction.Human)
        {
            _description = "This is where food for the army is produced. You must produce enough food for all Units otherwise they will die off.";
            _sprite = GameEnvironment.getAssetManager().GetSprite("Sprites/Buildings/HumanFarm");
        }

        if (_faction == faction.Orc)
        {
            _description = "Farms produce the grain and animals needed to keep the army well fed. You must produce enough food to supply all Orcs you control.";
            _sprite = GameEnvironment.getAssetManager().GetSprite("Sprites/Buildings/OrcFarm");
        }

        FoodCreate();
    }

    public override void Reset()
    {
        _hp = _maxhp;
    }

    public override void Draw(SpriteBatch spriteBatch)
    {
        base.Draw(spriteBatch);
    }

    public override void Update()
    {
        base.Update();
        //FoodCreate();
        if ((float)_maxhp / (float)_hp > 2.0f)
        {
            if (_faction == faction.Orc)
            {
                _sprite = GameEnvironment.getAssetManager().GetSprite("Sprites/Buildings/OrcFarmConstruction");
            }
            if (_faction == faction.Human)
            {
                _sprite = GameEnvironment.getAssetManager().GetSprite("Sprites/Buildings/HumanFarmConstruction");
            }
        }
    }

    private void FoodCreate()
    {
        if (_faction == faction.Human)
        { 
                _level.Player.AddFood(10);
                //Console.WriteLine("Food:" + Player.Food);
                
            
            
        }
    }
}