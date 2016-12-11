using System;
using Microsoft.Xna.Framework;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;
using Microsoft.Xna.Framework.Graphics;

partial class Level
{

    public void draw(SpriteBatch s)
    {

        Rectangle bounds = GameEnvironment.getCamera().getView();
        bounds.X -= data.tSize();
        bounds.Y -= data.tSize();
       // Console.WriteLine("X: " + bounds.X + " Y: "  + bounds.Y + " Z: " + bounds.Width + " W: " + bounds.Height);
        for (int i = 0; i < _mapWidth; i++)
        {
            for (int j = 0; j < _mapHeight; j++)
            {
                if (bounds.Contains(i * data.tSize(), j * data.tSize())) 
                s.Draw(_tex, new Vector2(i * data.tSize(), j * data.tSize()), Color.White);
                // s.Draw(_tex, new Rectangle(i * 64, j * 64, i * 64 + 64, j * 64 + 64), getColor(_mapData[i, j]));
            }

        }



        //TESTUNG / DEBUGING PURPOSES
        s.Draw(_tex, new Rectangle(128, 0, 64, 64), Color.Black);
        s.Draw(_tex, new Rectangle(0, 0, 64, 64), Color.Black);
        s.Draw(_tex, new Rectangle(512, 512, 64, 64), Color.Black);
        s.Draw(_tex, new Rectangle(0, 580, 1000, 6), Color.Black);


        foreach(Entity e in entities)
        {
            e.draw(s);
        }
       
    }



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
