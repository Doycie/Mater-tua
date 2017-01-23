using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Runtime.CompilerServices;

partial class Level
{
    //Draw the level
    public void draw(SpriteBatch s)
    {
        //Get the view so we dont do unneccssary drawing
        Rectangle bounds = GameEnvironment.getCamera().getView();
        //Adjust the view slightly to see everything
        bounds.X -= data.tSize();
        bounds.Y -= data.tSize();
        // Console.WriteLine("X: " + bounds.X + " Y: "  + bounds.Y + " Z: " + bounds.Width + " W: " + bounds.Height);

        //Draw all the tiles
        for (int i = 0; i < _mapWidth; i++)
        {
            for (int j = 0; j < _mapHeight; j++)
            {
                if (bounds.Contains(i * data.tSize(), j * data.tSize()))

                {
                    if (_mapData[i, j] == 0)
                        s.Draw(_dirtTex, new Vector2(i * data.tSize(), j * data.tSize()), Color.White);
                    else if (_mapData[i, j] == 1)
                        s.Draw(_waterTex, new Vector2(i * data.tSize(), j * data.tSize()), Color.White);
                    else if (_mapData[i, j] == 2)
                        s.Draw(_mountainTex, new Vector2(i * data.tSize(), j * data.tSize()), Color.White);
                    //s.Draw(_tex, new Rectangle(i * 64, j * 64, i * 64 + 64, j * 64 + 64), getColor(_mapData[i, j]));

                }
            }
        }

        //TESTiNG / DEBUGING PURPOSES
        //s.Draw(_tex, new Rectangle(128, 0, 64, 64), Color.Black);
        //s.Draw(_tex, new Rectangle(0, 0, 64, 64), Color.Black);
        //s.Draw(_tex, new Rectangle(512, 512, 64, 64), Color.Black);
        //s.Draw(_tex, new Rectangle(0, 580, 1000, 6), Color.Black);
        //s.Draw(_tex, new Rectangle(0, 1000, 2000, 6), Color.Red);

        //s.Draw(_tex, new Rectangle(0, 500, 4096, 6), Color.Blue);
        //Draw all the entities in the level list
        foreach (SpriteEntity e in entities)
        {
            e.Draw(s);
        }
        foreach (SpriteEntity e in specialFX)
        {
            e.Draw(s);
        }
        foreach (SpriteEntity e in Projectiles)
        {
            e.Draw(s);
        }





    }

    //Method for colloring a perlin map based on height of a byte NOT USED CODE

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private Color getColor(byte a)
    {
        if (a < 25)
            return Color.DarkBlue;
        else if (a < 50)
            return Color.Blue;
        else if (a < 75)
            return Color.LightBlue;
        else if (a < 100)
            return Color.Yellow;
        else if (a < 125)
            return Color.LightGreen;
        else if (a < 150)
            return Color.Green;
        else if (a < 175)
            return Color.DarkGreen;
        else if (a < 200)
            return Color.Gray;
        else if (a < 225)
            return Color.LightGray;
        else if (a < 255)
            return Color.White;
        else
            return Color.Black;
    }
}