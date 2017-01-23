using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

public partial class Level
{
    //Hold information about the current level
    private int _mapWidth, _mapHeight;

    public FogOfWar _fog;

    public byte[,] _mapData;

    //Hold the dirt texture
    private Texture2D _dirtTex;
    private Texture2D _waterTex;
    private Texture2D _mountainTex;

    public BuildingAndUnit _tempBuilding;
    //List of entities kept inside the level, like units and buildings. DO NOT PUT THE HUD ELEMENTS, PARTICLES OR PROJECTILES IN HERE
    public List<BuildingAndUnit> entities = new List<BuildingAndUnit>();

    public List<Entity> specialFX = new List<Entity>();

    public List<Entity> Projectiles = new List<Entity>();

    public Player Player;

    
    public Level()
    {
    }

    //Init the leve based on the width and height and then generate it based on Perlin
    public void init(int mapWidth, int mapHeight)
    {
     
        _dirtTex = GameEnvironment.getAssetManager().GetSprite("circle");
        generateMap(mapWidth, mapHeight);
    }

    //Init the level based on a level text file
    public void init(string mapPath)
    {
        _mountainTex = GameEnvironment.getAssetManager().GetSprite("Sprites/Tiles/Mountain");
        _waterTex = GameEnvironment.getAssetManager().GetSprite("Sprites/Tiles/water");
        _dirtTex = GameEnvironment.getAssetManager().GetSprite("Sprites/Tiles/dirt");
        _mapWidth = data.tSize();
        _mapHeight = data.tSize();
        GameEnvironment.getCamera().SetMaxBounds(data.tSize() * data.tSize() + data.tSize(), data.tSize() * data.tSize() + data.tSize());
        _mapData = new byte[_mapWidth, _mapHeight];
        loadMap(mapPath);

        for (int i = 0; i < 20; i++)
        {
            if (i < 10)
            {
                Footman e = new Footman(this, new Vector2(GameEnvironment.getRandom().Next(10) * data.tSize(), GameEnvironment.getRandom().Next(10) * data.tSize()));
                entities.Add(e);
            }
            if (i >= 10)
            {
                Grunt e = new Grunt(this, new Vector2((GameEnvironment.getRandom().Next(10) + 10) * data.tSize(), (GameEnvironment.getRandom().Next(10) + 10) * data.tSize()));
               entities.Add(e);
            }
            //Unit e = new Unit();
            //e.init(new Vector2(GameEnvironment.getRandom().Next(18) * data.tSize(), GameEnvironment.getRandom().Next(18) * data.tSize()), "birb");
            //entities.Add(e);
        }
        Player = new Player(this);
        Farm orcFarm = new Farm(this, new Vector2(16 * data.tSize(), 17 * data.tSize()), BuildingAndUnit.faction.Orc);
        entities.Add(orcFarm);
        Farm humanFarm = new Farm(this, new Vector2(5 * data.tSize(), 8 * data.tSize()), BuildingAndUnit.faction.Human);
        entities.Add(humanFarm);

        Mine Mine = new Mine(this, new Vector2(1 * data.tSize(), 1 * data.tSize()), BuildingAndUnit.faction.Neutral);
        entities.Add(Mine);
        Townhall Townhall = new Townhall(this, new Vector2(7 * data.tSize(), 3 * data.tSize()), BuildingAndUnit.faction.Human);
        entities.Add(Townhall);
        Townhall orcTownhall = new Townhall(this, new Vector2(20 * data.tSize(), 22 * data.tSize()), BuildingAndUnit.faction.Orc);
        entities.Add(orcTownhall);
        Barracks humanBarracks = new Barracks(this, new Vector2(12 * data.tSize(), 6 * data.tSize()), BuildingAndUnit.faction.Human);
        entities.Add(humanBarracks);
        Barracks orcBarracks = new Barracks(this, new Vector2(18 * data.tSize(), 18 * data.tSize()), BuildingAndUnit.faction.Orc);
        entities.Add(orcBarracks);
        Peasant Worker = new Peasant(this, new Vector2(10 * data.tSize(), 7 * data.tSize()));
        entities.Add(Worker);
        Peon Worker1 = new Peon(this, new Vector2(15 * data.tSize(), 15 * data.tSize()));
        entities.Add(Worker1);
        
        TreasureChest Chest1 = new TreasureChest(this, new Vector2(5 * data.tSize(), 2 * data.tSize()));
        entities.Add(Chest1);

        Tree Tree1 = new Tree(this,new Vector2(9 * data.tSize(), 1 * data.tSize()));
        entities.Add(Tree1);
        Tree Tree2 = new Tree(this,new Vector2(2 * data.tSize(), 5 * data.tSize()));
        entities.Add(Tree2);

        Archer archer = new Archer(this, new Vector2(5 * data.tSize(), 10 * data.tSize()));
        entities.Add(archer);
       // Projectile projectile = new Projectile(this, Mine, Tree2);
       // Projectiles.Add(projectile);
    }

    //Load the map from the text file into the mapdata array
    private void loadMap(string mapPath)
    {
        System.IO.StreamReader file = new System.IO.StreamReader(mapPath);
        if (file != null)
        {
            for (int i = 0; i < _mapHeight; i++)
            {
                //char[] c = new char[1];
                //file.Read(c,0,1);
                string a = file.ReadLine();
                //_mapData[j, i] =(byte)( (byte)c[0] - (byte)48);
                int x = 0;
                foreach (char c in a)
                {
                   
                    _mapData[x, i] = (byte)((byte)c - (byte)48);
                    x++;
                    if (x == 64)
                        break;
                }
            }
            file.Close();
        }
    }

    //Generate the map with Perlin
    private void generateMap(int w, int h)
    {
        _mapWidth = w;
        _mapHeight = h;
        _mapData = new byte[_mapWidth, _mapHeight];

        Perlin perlin = new Perlin();
        //Color[] data = new Color[_mapWidth * 64 *( _mapHeight * 64)];

        for (int i = 0; i < _mapWidth; i++)
        {
            for (int j = 0; j < _mapHeight; j++)
            {
                _mapData[i, j] = (byte)(255 * perlin.perlinNoise((float)i / _mapWidth * 4, (float)j / _mapHeight * 4));
                //Color c = getColor((byte)(255 * perlin.perlinNoise((float)i / _mapWidth, (float)j / _mapHeight)));

                //for (int x = 0; x < 64; x++)
                //{
                //    for (int y = 0; y < 64; y++)
                //    {
                //        data[i*64+x +  (j*64 + y)*_mapWidth *64 ] = c;
                //    }
                //}
            }
        }
        //_tex.SetData(data);
    }
    public void setFog(FogOfWar fog)
    {
        _fog = fog;
    }
}