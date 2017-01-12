using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

public partial class Level
{
    //Hold information about the current level
    private int _mapWidth, _mapHeight;

    private byte[,] _mapData;

    //Hold the dirt texture
    private Texture2D _tex;

    //List of entities kept inside the level, like units and buildings. DO NOT PUT THE HUD ELEMENTS, PARTICLES OR PROJECTILES IN HERE
    public List<BuildingAndUnit> entities = new List<BuildingAndUnit>();

    public List<Entity> specialFX = new List<Entity>();

    public Player Player;

    public Level()
    {
    }

    

    //Init the leve based on the width and height and then generate it based on Perlin
    public void init(int mapWidth, int mapHeight)
    {
        _tex = GameEnvironment.getAssetManager().GetSprite("circle");
        generateMap(mapWidth, mapHeight);
    }

    //Init the level based on a level text file
    public void init(string mapPath)
    {
        _tex = GameEnvironment.getAssetManager().GetSprite("Sprites/Tiles/dirt");
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
        Farm orcFarm = new Farm(this, new Vector2(10 * data.tSize(), 3 * data.tSize()), BuildingAndUnit.faction.Orc);
        entities.Add(orcFarm);
        Farm humanFarm = new Farm(this, new Vector2(8 * data.tSize(), 8 * data.tSize()), BuildingAndUnit.faction.Human);
        entities.Add(humanFarm);

        Mine Mine = new Mine(this, new Vector2(64, 64), BuildingAndUnit.faction.Neutral);
        entities.Add(Mine);
        Townhall Townhall = new Townhall(this, new Vector2(384, 384), BuildingAndUnit.faction.Human);
        entities.Add(Townhall);
        Peon peon = new Peon(this, new Vector2(704, 192));
        entities.Add(peon);
        Peasant peasant = new Peasant(this, new Vector2(192, 704));
        entities.Add(peasant);
        Tree Tree1 = new Tree(new Vector2(512, 64));
        entities.Add(Tree1);
        Tree Tree2 = new Tree(new Vector2(64, 512));
        entities.Add(Tree2);

        
    }

    //Load the map from the text file into the mapdata array
    private void loadMap(string mapPath)
    {
        System.IO.StreamReader file = new System.IO.StreamReader(mapPath);
        if (file != null)
        {
            for (int i = 0; i < _mapWidth; i++)
            {
                for (int j = 0; j < _mapHeight; j++)
                {
                    file.Read();
                    _mapData[i, j] = (byte)file.Read();
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
}