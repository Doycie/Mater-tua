using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

class HudManager
{
    private List<Entity> _buttons = new List<Entity>();

    //Holds the texture for the HUD background, which is always the same while playing the game.
    private Texture2D _tex;
   
        
    public HudManager()
    {
        _tex = GameEnvironment.getAssetManager().GetSprite("HUDsizeTest");
    }

    public void draw(SpriteBatch spriteBatch)
    {
        spriteBatch.Draw(_tex, new Vector2(0 + GameEnvironment.getCamera().getView().X, 486 + GameEnvironment.getCamera().getView().Y), new Rectangle(0, 486, _tex.Width, _tex.Height), Color.White);
    }

}
