using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
class Camera2D
{
    //Holds the camera position based on 1.0f zoom
    private Vector3 _position;
    //Variable for the zoom
    private float _scale;
    //Vector to hold the middle of the screen
    private Vector3 _origin;

    //Initialize the camera on its proper position and set the origin
    public void initCamera(float scale, Vector2 position, Vector2 screenSize)
    {
        _position = new Vector3(position,0.0f);
        _scale = 1;
        //Console.WriteLine(scale);
       // Console.WriteLine(" x: " + screenSize.X /2f + " y: " + screenSize.Y/ 2f);
        _origin = new Vector3((screenSize.X ) / 2f , (screenSize.Y ) / 2f, 0.0f);
    }

    //Compute a matrix for the spritebatch based on all the variables
    public Matrix getMatrix()
    {
       return Matrix.CreateTranslation(-_position) * Matrix.CreateTranslation(-_origin) * Matrix.CreateRotationZ(0.0f) * Matrix.CreateScale(_scale,_scale,1) * Matrix.CreateTranslation(_origin);
     
    }

    //Move the camera a desired vector
    public void move(Vector2 mov)
    {
        //if (_position.X + mov.X > 0)
            _position.X += mov.X;
        // if( _position.Y + mov.Y > 0)
        _position.Y += mov.Y;
    }

    //Zoom the camera a desired value but limited for performance and game breaking reasons
    public void zoom(float v)
    {
       if(_scale + v > 0.25f)
            _scale = _scale + v;
    }

    //Returns a rectangle properly calculated from the positon and the zoom
    //WARNING the width and height seem to be not working correctly on very high levels of zoom
    public Rectangle getView()
    {
        int x = (int)(_position.X - (_origin.X / _scale - _origin.X));
        int y = (int)(_position.Y - (_origin.Y / _scale - _origin.Y));
        return new Rectangle(x,y,(int)(x + (_origin.X / _scale * 2 ) ),(int) (y + (_origin.Y /_scale * 2)));
    }

    
    public float getZoom()
    {
        return _scale;
    }
}
