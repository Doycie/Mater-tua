using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
class Camera2D
{
    private Vector3 _position;
    private float _scale;

    private Vector3 _origin;

    public void initCamera(float scale, Vector2 position, Vector2 screenSize)
    {
        _position = new Vector3(position,0.0f);
        _scale = 1;
        //Console.WriteLine(scale);
       // Console.WriteLine(" x: " + screenSize.X /2f + " y: " + screenSize.Y/ 2f);
        _origin = new Vector3((screenSize.X ) / 2f , (screenSize.Y ) / 2f, 0.0f);
    }

    public Matrix getMatrix()
    {
       return Matrix.CreateTranslation(-_position) * Matrix.CreateTranslation(-_origin) * Matrix.CreateRotationZ(0.0f) * Matrix.CreateScale(_scale,_scale,1) * Matrix.CreateTranslation(_origin);
     
    }
    public void move(Vector2 mov)
    {

        //if (_position.X + mov.X > 0)
            _position.X += mov.X;
       // if( _position.Y + mov.Y > 0)
       
            _position.Y += mov.Y;
        

        
    }

    public void zoom(float v)
    {
       if(_scale + v > 0.25f)
            _scale = _scale + v;
    }
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
