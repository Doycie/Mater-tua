using Microsoft.Xna.Framework.Graphics;
using System;
using Microsoft.Xna.Framework;

partial class Level
{
    private int _mapWidth, _mapHeight;
    private byte[,] _mapData;
    private Texture2D _tex;
    

    public Level()
    {

    }
    public void init(int mapWidth, int mapHeight )
    {
        _tex = GameEnvironment.getAssetManager().GetSprite("circle");
        generateMap(mapWidth, mapHeight);
  


    }
    public void init(string mapPath)
    {
        _tex = GameEnvironment.getAssetManager().GetSprite("grass");

        loadMap(mapPath);
    }
    private void loadMap(string mapPath)
    {
        //TODO Write level loading
    }

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
                 _mapData[i, j] = (byte)(255 * perlin.perlinNoise((float)i/_mapWidth*4, (float)j/_mapHeight*4));
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

