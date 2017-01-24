using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

internal class Resources
{
    private int _resourceNumber;
    protected Level _level;


    public int getNumber()
    {
        return _resourceNumber;
    }

    public void setNumber(int number)
    {
        _resourceNumber = number;
    }

    public Resources(int number, Level level)
    {
        _resourceNumber = number;
        _level = level;
       
    }

    public void draw(SpriteBatch s)
    {
        switch (getNumber())
        {
            default:
                break;

            case 1: /* gold */
                s.Draw(GameEnvironment.getAssetManager().GetSprite("Sprites/HUD/gold"), new Rectangle((int)GameEnvironment.getCamera().getScreenSize().X - 435, 10, 30, 30), Color.White);
                s.DrawString(GameEnvironment.getAssetManager().getFont("Warcraft Font"), "Gold: " + _level.Player.Gold, new Vector2((int)GameEnvironment.getCamera().getScreenSize().X - 405, 10), Color.DarkOrange);
                break;

            case 2: /* wood */
                s.Draw(GameEnvironment.getAssetManager().GetSprite("Sprites/HUD/wood"), new Rectangle((int)GameEnvironment.getCamera().getScreenSize().X - 290, 10, 30, 30), Color.White);
                s.DrawString(GameEnvironment.getAssetManager().getFont("Warcraft Font"), "Wood: " + _level.Player.Wood, new Vector2((int)GameEnvironment.getCamera().getScreenSize().X - 260, 10), Color.DarkOrange);
                break;

            case 3: /* food */
                s.Draw(GameEnvironment.getAssetManager().GetSprite("Sprites/HUD/foodSprite"), new Rectangle((int)GameEnvironment.getCamera().getScreenSize().X - 145, 10, 30, 30), Color.White);
                s.DrawString(GameEnvironment.getAssetManager().getFont("Warcraft Font"), "Food: " + _level.Player.UsedFood + "/" + _level.Player.Food, new Vector2((int)GameEnvironment.getCamera().getScreenSize().X - 115, 10), Color.DarkOrange);
                break;
        }
    }
}