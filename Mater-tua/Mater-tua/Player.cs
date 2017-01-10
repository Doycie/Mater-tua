public class Player
{
    static private int _Wood;
    static private int _Gold;
    static private int _Food;

    public Player()
    {
    }

    static public int Wood
    {
        get { return _Wood; }
    }

    static public int Gold
    {
        get { return _Gold; }
    }

    static public int Food
    {
        get { return _Food; }
    }

    public void AddWood(int Amount)
    {
        _Wood = _Wood + Amount;
    }

    public void AddGold(int Amount)
    {
        _Gold = _Gold + Amount;
    }

    public void AddFood(int Amount)
    {
        _Food = _Food + Amount;
    }
}