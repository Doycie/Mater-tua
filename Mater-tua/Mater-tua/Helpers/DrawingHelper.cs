using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

public class DrawingHelper
{
    protected static Texture2D pixel;

    //Initialize the drawing helper with the current screen
    public static void Initialize(GraphicsDevice graphics)
    {
        pixel = new Texture2D(graphics, 1, 1);
        pixel.SetData(new[] { Color.White });
    }

    //Simple function to draw a rectangle
    public static void DrawRectangle(Rectangle r, SpriteBatch spriteBatch, Color col, int bw = 2)
    {
        spriteBatch.Draw(pixel, new Rectangle(r.Left, r.Top, bw, r.Height), col); // Left
        spriteBatch.Draw(pixel, new Rectangle(r.Right, r.Top, bw, r.Height), col); // Right
        spriteBatch.Draw(pixel, new Rectangle(r.Left, r.Top, r.Width, bw), col); // Top
        spriteBatch.Draw(pixel, new Rectangle(r.Left, r.Bottom, r.Width, bw), col); // Bottom
    }
}