using Microsoft.Xna.Framework;
using System;
internal class Camera2D
{
    //Holds the camera position based on 1.0f zoom
    private Vector3 _position;

    //Variable for the zoom
    private float _scale;

    //Vector to hold the middle of the screen
    private Vector3 _origin;

    private Point _maxBounds;

    private Vector2 _screenSize;

    //Initialize the camera on its proper position and set the origin
    public void initCamera(float scale, Vector2 position, Vector2 screenSize)
    {
        _position = new Vector3(position, 0.0f);
        _scale = 1;
        //Console.WriteLine(scale);
        // Console.WriteLine(" x: " + screenSize.X /2f + " y: " + screenSize.Y/ 2f);
        _origin = new Vector3((screenSize.X) / 2f, (screenSize.Y) / 2f, 0.0f);
        _screenSize = screenSize;
    }

    public Vector2 getScreenSize()
    {
        //Console.WriteLine(_screenSize);
        return _screenSize;
    }

    //Compute a matrix for the spritebatch based on all the variables
    public Matrix getMatrix()
    {
        Console.WriteLine(_position);
        return Matrix.CreateTranslation(-_position) * Matrix.CreateTranslation(-_origin) * Matrix.CreateRotationZ(0.0f) * Matrix.CreateScale(_scale, _scale, 1) * Matrix.CreateTranslation(_origin);
    }

    internal void SetMaxBounds(int x, int y)
    {
        _maxBounds.X = x;
        _maxBounds.Y = y;
    }

    //Move the camera a desired vector
    public void move(Vector2 mov)
    {
        int x = (int)(_position.X - (_origin.X / _scale - _origin.X));
        int y = (int)(_position.Y - (_origin.Y / _scale - _origin.Y));

        //if (_position.X + mov.X > 0)
        if (x + mov.X > 0 && (int)(x + mov.X + (_origin.X * 2 / _scale)) < _maxBounds.X)
        {
            _position.X += mov.X;
        }

        // if( _position.Y + mov.Y > 0)
        if (y + mov.Y > 0 && (int)(y + mov.Y + (_origin.Y * 2 / _scale)) < _maxBounds.Y)
        {
            _position.Y += mov.Y;
        }
    }

    public void setPos(Vector2 pos)
    {
        _position = new Vector3(pos, 0.0f);
        
    }

    //Zoom the camera a desired value but limited for performance and game breaking reasons
    public void zoom(float v)
    {
        int x = (int)(_position.X - (_origin.X / (_scale + v) - _origin.X));
        int y = (int)(_position.Y - (_origin.Y / (_scale + v) - _origin.Y));

        //TODO Only zoom when the camera is in bounds
        //if (_scale + v > 0.1f)
        //    _scale = _scale + v;
    }

    //Returns a rectangle properly calculated from the positon and the zoom
    //WARNING the width and height seem to be not working correctly on very high levels of zoom
    public Rectangle getView()
    {
        int x = (int)(_position.X - (_origin.X / _scale - _origin.X));
        int y = (int)(_position.Y - (_origin.Y / _scale - _origin.Y));
        return new Rectangle(x, y, (int)(x + (_origin.X * 2 / _scale)), (int)(y + (_origin.Y * 2 / _scale)));
    }

    public float getZoom()
    {
        return _scale;
    }
}