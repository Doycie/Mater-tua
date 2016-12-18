using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework;

//Class that is used to load new  textures and sounds

public class AssetManager
{
    protected ContentManager contentManager;
    protected GraphicsDeviceManager graphicsDevice;

    //Setup the AssetManager
    public AssetManager(ContentManager content, GraphicsDeviceManager graphics)
    {
        contentManager = content;
        graphicsDevice = graphics;
    }

    //Get a texture from file
    public Texture2D GetSprite(string assetName)
    {
        if (assetName == "")
        {
            return null;
        }
        return contentManager.Load<Texture2D>(assetName);
    }

    //Make a new texture based on width and height
    public Texture2D GetTex(int w, int h)
    {

        return new Texture2D(graphicsDevice.GraphicsDevice, w, h);
    }

    //Play sounds from file
    public void PlaySound(string assetName)
    {
        SoundEffect snd = contentManager.Load<SoundEffect>(assetName);
        snd.Play();
    }

    //Play music from file
    public void PlayMusic(string assetName, bool repeat = true)
    {
        MediaPlayer.IsRepeating = repeat;
        MediaPlayer.Play(contentManager.Load<Song>(assetName));
    }

    //Handler to use the ContentManager in other classes
    public ContentManager Content
    {
        get { return contentManager; }
    }
    
    public void RandomiseBGM()
    {
        int trackNO = GameEnvironment.getRandom().Next(0, 3);

        switch(trackNO)
        {
            default:
                this.PlayMusic("Music/MaterTua_BGM_1", false);
                break;
            case 1:
                this.PlayMusic("Music/MaterTua_BGM_1", false);
                break;
            case 2:
                this.PlayMusic("Music/MaterTua_BGM_2", false);
                break;
        }
    }
    
}