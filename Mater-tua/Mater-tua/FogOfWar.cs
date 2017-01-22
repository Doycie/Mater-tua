using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Linq;
using System.Collections.Generic;

class FogOfWar
{
    protected Level level;
    protected int[,] _fog;
    protected Texture2D _fogFull, _fogHalf;

    public FogOfWar(Level lvl)
    {
        level = lvl;
        _fog = new int[level._mapData.GetLength(0), level._mapData.GetLength(1)];
        for (int x = 0; x < level._mapData.GetLength(0); x++)
        {
            for (int y = 0; y < level._mapData.GetLength(1); y++)
            {
                _fog[x, y] = 0;
            }
        }
        _fogFull = GameEnvironment.getAssetManager().GetSprite("Sprites/Misc/FogFull");
        _fogHalf = GameEnvironment.getAssetManager().GetSprite("Sprites/Misc/FogHalf");

    }


    public int[,] Fog
    {
        get { return _fog; }
    }

    public void Draw(SpriteBatch s)
    {
        //Get the view so we dont do unneccssary drawing
        Rectangle bounds = GameEnvironment.getCamera().getView();
        //Adjust the view slightly to see everything
        bounds.X -= data.tSize();
        bounds.Y -= data.tSize();
        // Console.WriteLine("X: " + bounds.X + " Y: "  + bounds.Y + " Z: " + bounds.Width + " W: " + bounds.Height);

        //Draw all the tiles
        for (int x = 0; x < _fog.GetLength(0); x++)
        {
            for (int y = 0; y < _fog.GetLength(1); y++)
            {
                if (bounds.Contains(x * data.tSize(), y * data.tSize()))

                {
                    if (_fog[x, y] == 0)
                        s.Draw(_fogFull, new Vector2(x * data.tSize(), y * data.tSize()), Color.White);
                    else if (_fog[x, y] == 1)
                        s.Draw(_fogHalf, new Vector2(x * data.tSize(), y * data.tSize()), Color.White);
                    //s.Draw(_tex, new Rectangle(i * 64, j * 64, i * 64 + 64, j * 64 + 64), getColor(_mapData[i, j]));

                }
            }
        }
    }

    public void Update()
    {
        for (int x = 0; x < _fog.GetLength(0); x++)
        {
            for (int y = 0; y < _fog.GetLength(1); y++)
            {
                foreach (BuildingAndUnit e in level.entities)
                {
                    if (e.Faction == BuildingAndUnit.faction.Human && _fog[x, y] != 3)
                    {
                        if (Distance(new Point((int)(x * data.tSize()), (int)(y * data.tSize())), new Point((int)e.Position.X, (int)e.Position.Y)) < 5 * data.tSize())
                        {
                            _fog[x, y] = 3;
                            continue;
                        }
                        else
                        {
                            if (_fog[x, y] == 2 || _fog[x, y] == 1)
                            {
                                _fog[x, y] = 1;
                                continue;
                            }
                            else
                            {
                                _fog[x, y] = 0;
                                continue;
                            }
                        }
                    }
                }
            }
        }
        for (int x = 0; x < _fog.GetLength(0); x++)
        {
            for (int y = 0; y < _fog.GetLength(1); y++)
            {
                if (_fog[x,y] == 3)
                {
                    _fog[x, y] = 2;
                }
            }
        }

        foreach(Unit f in level.entities.OfType<Unit>())
        {
            if (f.Faction != BuildingAndUnit.faction.Human)
            {
                if (_fog[((int)f.Position.X / data.tSize()), ((int)f.Position.Y / data.tSize())] <= 1)
                {
                    f.Visible = false;
                }
                else
                {
                    f.Visible = true;
                }
            }
        }
    }

    private double Distance(Point x, Point y)
    {
        return Math.Sqrt(Math.Pow(x.X - y.X, 2) + Math.Pow(x.Y - y.Y, 2));
    }

}

