using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Media;

class GameEnvironment : Game
{
    protected GraphicsDeviceManager graphics;
    protected SpriteBatch spriteBatch;
    protected InputHelper inputHelper;
    protected Point windowSize;
    protected Matrix spriteScale;
    
    protected static Camera2D camera;
    protected static Point screen;
    protected static GameStateManager gameStateManager;
    protected static Random random;
    protected static AssetManager assetManager;
    protected static GameSettingsManager gameSettingsManager;

    static public Random getRandom()
    {
        return random;
    }
    static public Camera2D getCamera()
    {
        return camera;
    }

    static public AssetManager getAssetManager()
    {
        return assetManager;
    }
    public GameEnvironment()
    {
        graphics = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";

       // IsMouseVisible = true;

        inputHelper = new InputHelper();
        camera = new Camera2D();

        gameStateManager = new GameStateManager();

        random = new Random();
        assetManager = new AssetManager(Content,graphics);
        gameSettingsManager = new GameSettingsManager();

        this.playBGM();
       
    }
    public bool FullScreen
    {
        get { return graphics.IsFullScreen; }
        set
        {
            ApplyResolutionSettings(value);
        }
    }

    protected void playBGM()
    {
        assetManager.RandomiseBGM();
    }


    public void ApplyResolutionSettings(bool fullScreen = false)
    {
        if (!fullScreen)
        {
            graphics.PreferredBackBufferWidth = windowSize.X;
            graphics.PreferredBackBufferHeight = windowSize.Y;
            graphics.IsFullScreen = false;
            graphics.ApplyChanges();
        }
        else
        {
            graphics.PreferredBackBufferWidth = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width;
            graphics.PreferredBackBufferHeight = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height;
            graphics.IsFullScreen = true;
            graphics.ApplyChanges();
        }

        float targetAspectRatio = (float)screen.X / (float)screen.Y;
        int width = graphics.PreferredBackBufferWidth;
        int height = (int)(width / targetAspectRatio);
        if (height > graphics.PreferredBackBufferHeight)
        {
            height = graphics.PreferredBackBufferHeight;
            width = (int)(height * targetAspectRatio);
        }

        Viewport viewport = new Viewport();
        viewport.X = (graphics.PreferredBackBufferWidth / 2) - (width / 2);
        viewport.Y = (graphics.PreferredBackBufferHeight / 2) - (height / 2);
        viewport.Width = width;
        viewport.Height = height;
        GraphicsDevice.Viewport = viewport;

        inputHelper.Scale = new Vector2((float)GraphicsDevice.Viewport.Width / screen.X,
                                        (float)GraphicsDevice.Viewport.Height / screen.Y);
        //inputHelper.Offset = new Vector2(viewport.X, viewport.Y);

        camera.initCamera(inputHelper.Scale.X, Vector2.Zero, new Vector2(width,height));
        spriteScale = Matrix.CreateScale(inputHelper.Scale.X, inputHelper.Scale.Y, 1);


    }

    protected override void LoadContent()
    {

        DrawingHelper.Initialize(this.GraphicsDevice);
        spriteBatch = new SpriteBatch(GraphicsDevice);

        screen = new Point(1440, 810);
        windowSize = new Point(1024, 576);
        FullScreen = false;

        gameStateManager.changeGameState();
    }

    protected void HandleInput()
    {
        inputHelper.Update();
        if (inputHelper.KeyPressed(Keys.Escape))
        {
            Exit();
        }
        if (inputHelper.KeyPressed(Keys.F5))
        {
            FullScreen = !FullScreen;
        }

        gameStateManager.handleInput(inputHelper);
    }

    protected override void Update(GameTime gameTime)
    {

        HandleInput();
        gameStateManager.update(gameTime);

        if (MediaPlayer.State == MediaState.Stopped)
            this.playBGM();
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.Black);
        spriteBatch.Begin(SpriteSortMode.Deferred, null, null, null, null, null, camera.getMatrix());
        gameStateManager.draw(gameTime, spriteBatch);
        spriteBatch.End();
        spriteBatch.Begin();
        gameStateManager.drawHUD(spriteBatch);
        spriteBatch.End();
    }
}

