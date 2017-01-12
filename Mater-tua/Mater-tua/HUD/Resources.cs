using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

internal class Resources
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
                s.Draw(GameEnvironment.getAssetManager().GetSprite("Sprites/HUD/gold"), new Rectangle((int)GameEnvironment.getCamera().getScreenSize().X - 420, 10, 30, 30), Color.White);
                s.DrawString(GameEnvironment.getAssetManager().getFont("Warcraft Font"), "Gold: " + _level.Player.Gold, new Vector2((int)GameEnvironment.getCamera().getScreenSize().X - 390, 10), Color.Red);
                break;

            case 2: /* wood */
                s.Draw(GameEnvironment.getAssetManager().GetSprite("Sprites/HUD/wood"), new Rectangle((int)GameEnvironment.getCamera().getScreenSize().X - 275, 10, 30, 30), Color.White);
                s.DrawString(GameEnvironment.getAssetManager().getFont("Warcraft Font"), "Wood: " + _level.Player.Wood, new Vector2((int)GameEnvironment.getCamera().getScreenSize().X - 245, 10), Color.Red);
                break;

            case 3: /* food */
                s.Draw(GameEnvironment.getAssetManager().GetSprite("Sprites/HUD/foodSprite"), new Rectangle((int)GameEnvironment.getCamera().getScreenSize().X - 130, 10, 30, 30), Color.White);
                s.DrawString(GameEnvironment.getAssetManager().getFont("Warcraft Font"), "Food: " + _level.Player.Food, new Vector2((int)GameEnvironment.getCamera().getScreenSize().X - 100, 10), Color.Red);
                break;
        }
    }
}