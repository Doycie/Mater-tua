using System;
class Perlin
    //Ik ga perlin niet uitleggen als je dat wil begrijpen google het maar
{
    private float Noise(int x, int y)
    {
        int n = x + y * 57;
        n = (n << 13) ^ n;
        return (float)(1.0 - ((n * (n * n * 15731 + 789221) + 1376312589) & (int)0x7fffffff) / 1073741824.0);
    }

    private float SmoothNoise_1(int x, int y)
    {
        float corners = (Noise(x - 1, y - 1) + Noise(x + 1, y - 1) + Noise(x - 1, y + 1) + Noise(x + 1, y + 1)) / 16;
        float sides = (Noise(x - 1, y) + Noise(x + 1, y) + Noise(x, y - 1) + Noise(x, y + 1)) / 8;
        float center = Noise(x, y) / 4;
        return corners + sides + center;
    }
    private float Interpolate(float a, float b, float x)
    {
        float ft = x * 3.1415927f;
        float f = (1 - (float)Math.Cos(ft)) * .5f;
        return a * (1 - f) + b * f;
    }

    private float InterpolatedNoise_1(float x, float y)
    {

        int integer_X = (int)(x);
        float fractional_X = x - integer_X;

        int integer_Y = (int)(y);
        float fractional_Y = y - integer_Y;

        float v1 = SmoothNoise_1(integer_X, integer_Y);
        float v2 = SmoothNoise_1(integer_X + 1, integer_Y);
        float v3 = SmoothNoise_1(integer_X, integer_Y + 1);
        float v4 = SmoothNoise_1(integer_X + 1, integer_Y + 1);

        float i1 = Interpolate(v1, v2, fractional_X);
        float i2 = Interpolate(v3, v4, fractional_X);

        return Interpolate(i1, i2, fractional_Y);

    }


    public float perlinNoise(float x, float y)
    {

        float total = 0;
        float p = 0.25f;
        int n = 8 - 1;

        for (int i = 0; i < n; i++)
        {

            int frequency = 2 ^ i;
            float amplitude = (float)Math.Pow(p, i);

            total = total + (InterpolatedNoise_1(x * frequency, y * frequency) * amplitude);

        }
        return total + 0.5f;



    }
}