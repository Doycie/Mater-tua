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
        _tex = GameEnvironment.getAssetManager().GetSprite("WoodTextureTest");
    }

    public void draw(SpriteBatch spriteBatch)
    {
        spriteBatch.Draw(_tex, new Vector2(0 , 486), new Rectangle(0, 486, _tex.Width, _tex.Height), Color.White);
    }

}
