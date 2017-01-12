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

            case 1: /* gold */
                s.Draw(GameEnvironment.getAssetManager().GetSprite("Sprites/HUD/gold"), new Rectangle((int)GameEnvironment.getCamera().getScreenSize().X - 330, 10, 30, 30), Color.White);
                s.DrawString(GameEnvironment.getAssetManager().getFont("Warcraft Font"), "Gold: " + Player.Gold, new Vector2((int)GameEnvironment.getCamera().getScreenSize().X - 300, 10), Color.Red);
                break;

            case 2: /* wood */
                s.Draw(GameEnvironment.getAssetManager().GetSprite("Sprites/HUD/wood"), new Rectangle((int)GameEnvironment.getCamera().getScreenSize().X - 220, 10, 30, 30), Color.White);
                s.DrawString(GameEnvironment.getAssetManager().getFont("Warcraft Font"), "Wood: " + Player.Wood, new Vector2((int)GameEnvironment.getCamera().getScreenSize().X - 190, 10), Color.Red);
                break;

            case 3: /* food */
                s.Draw(GameEnvironment.getAssetManager().GetSprite("Sprites/HUD/foodSprite"), new Rectangle((int)GameEnvironment.getCamera().getScreenSize().X - 110, 10, 30, 30), Color.White);
                s.DrawString(GameEnvironment.getAssetManager().getFont("Warcraft Font"), "Food: " + Player.Food, new Vector2((int)GameEnvironment.getCamera().getScreenSize().X - 80, 10), Color.Red);
                break;
        }
    }
}