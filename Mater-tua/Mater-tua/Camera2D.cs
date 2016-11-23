using Microsoft.Xna.Framework;

class Camera2D
{
    private Vector2 _position;
    private float _scale;

    public void initCamera(float scale, Vector2 position)
    {

        _position = position;

        _scale = scale;
    }

    public Matrix getMatrix()
    {
        Matrix mat = Matrix.CreateTranslation(_position.X, _position.Y, 0.0f) * Matrix.CreateScale(_scale);

        return mat;
    }
}
