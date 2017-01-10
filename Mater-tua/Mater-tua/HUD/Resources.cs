using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

class Resources
{
    private int _resourceNumber;
    protected Level _level;
    private int wood;
    private int gold;
    private int food;

    public int getNumber()
    {
        return _resourceNumber;
    }

    public void setNumber(int number)
    {
        _resourceNumber = number;
    }

    public Resources(int number)
    {
        _resourceNumber = number;
    }

    public void draw(SpriteBatch s)
    {
        switch (getNumber())
        {
            default:
                break;
            case 1: /* wood */
                s.Draw(GameEnvironment.getAssetManager().GetSprite("Sprites/HUD/foodSprite"), new Rectangle((int)GameEnvironment.getCamera().getScreenSize().X / 2, (int)GameEnvironment.getCamera().getScreenSize().Y - 100, 30, 30), Color.White);
                s.DrawString(GameEnvironment.getAssetManager().getFont("Warcraft Font"), "Wood: " + Player.Wood, new Vector2((int)GameEnvironment.getCamera().getScreenSize().X / 2 + 35, (int)GameEnvironment.getCamera().getScreenSize().Y - 100), Color.Red);
                break;
            case 2: /* gold */
                s.Draw(GameEnvironment.getAssetManager().GetSprite("Sprites/HUD/foodSprite"), new Rectangle((int)GameEnvironment.getCamera().getScreenSize().X / 2, (int)GameEnvironment.getCamera().getScreenSize().Y - 70, 30, 30), Color.White);
                s.DrawString(GameEnvironment.getAssetManager().getFont("Warcraft Font"), "Gold: " + Player.Gold, new Vector2((int)GameEnvironment.getCamera().getScreenSize().X / 2 + 35, (int)GameEnvironment.getCamera().getScreenSize().Y - 70), Color.Red);
                break;
            case 3: /* food */
                s.Draw(GameEnvironment.getAssetManager().GetSprite("Sprites/HUD/foodSprite"), new Rectangle((int)GameEnvironment.getCamera().getScreenSize().X / 2, (int)GameEnvironment.getCamera().getScreenSize().Y - 40, 30, 30), Color.White);
                s.DrawString(GameEnvironment.getAssetManager().getFont("Warcraft Font"), "Food: " + Player.Food, new Vector2((int)GameEnvironment.getCamera().getScreenSize().X / 2 + 35, (int)GameEnvironment.getCamera().getScreenSize().Y - 40), Color.Red);
                break;
        }
    }
}