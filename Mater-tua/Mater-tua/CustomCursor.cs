//using Microsoft.Xna.Framework.Graphics;
//using Microsoft.Xna.Framework;
//using System;
//using Microsoft.Xna.Framework.Input;

//class CustomCursor
//{
//    private Texture2D _tex;
//    private Vector2 mousePos;
//    private MouseState _mouseState;
//    private PlayingState playingState;
    
//    public CustomCursor()
//    {
//        _tex = GameEnvironment.getAssetManager().GetSprite("CursorTest");
//        _mouseState = Mouse.GetState();
//    }

//    public void updateCursorPosition()
//    {
//        mousePos = new Vector2(_mouseState.X, _mouseState.Y);
//        Console.WriteLine(_mouseState.X + _mouseState.Y);
//    }

//    public void draw(SpriteBatch s)
//    {
//        s.Draw(_tex, playingState.mousePos, Color.White);
//    }
//}

