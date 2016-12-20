﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Linq;
using System.Collections.Generic;

class PlayingState : GameState
{
    private Vector2 _camSpeed = new Vector2(4.0f, 4.0f);
    private int _previousScrollValue;
    private MouseState _mouseState;
    private Level level;
    private List<Entity> _selectedEntities = new List<Entity>();
    CustomCursor _customCursor;
    HudManager _hudManager;
    Vector2 _lastMousePos;
    Vector2 _currentMousePos;
    bool _mouseReleased;
    Texture2D _selectTex;

    private bool menu = false;

    
    public bool menuState()
    {
        return menu;
    }
    //Construct a new state and set the level and all the needed variables
    public PlayingState()
    {
        _customCursor = new CustomCursor();
        _hudManager = new HudManager();
        _mouseState = Mouse.GetState();
        level = new Level();
        level.init("lvl.txt");
        _selectTex = GameEnvironment.getAssetManager().GetSprite("selectbox");
    }

    //Update the level
    public void update(GameTime gameTime)
    {
        level.update();
        // GameEnvironment.getCamera().getScreenSize();
        // Console.WriteLine(mousePos);
    }

    //Special function to draw the HUD 

    public void drawHUD(SpriteBatch spriteBatch)
    {
        _hudManager.draw(spriteBatch);
        _customCursor.draw(spriteBatch);
    }

    //Draw the level then the cursor and the slected entities 
    public void draw(GameTime gameTime, SpriteBatch spriteBatch)
    {
        level.draw(spriteBatch);

        if (_mouseReleased)
            DrawingHelper.DrawRectangle(new Rectangle((int)_lastMousePos.X, (int)_lastMousePos.Y, (int)(_currentMousePos.X - _lastMousePos.X), (int)(_currentMousePos.Y - _lastMousePos.Y)), spriteBatch, Color.Red);

        //spriteBatch.Draw(_selectTex, new Rectangle((int)_lastMousePos.X, (int)_lastMousePos.Y, (int)(_currentMousePos.X - _lastMousePos.X), (int)(_currentMousePos.Y - _lastMousePos.Y)), Color.White);
        if (_selectedEntities.Count > 0)
            foreach (SpriteEntity e in _selectedEntities)
            {
                DrawingHelper.DrawRectangle(new Rectangle((int)e.Position.X, (int)e.Position.Y, e.Size * data.tSize(), e.Size * data.tSize()), spriteBatch, Color.Red);
                //spriteBatch.Draw(_selectTex, new Rectangle((int)e.Position.X, (int)e.Position.Y, 64, 64), Color.White);
            }
    }

    
    //Handle the camera movement and the selecting units
    public void handleInput(InputHelper inputHelper)
    {

        _customCursor.updateCursorPosition(inputHelper);
        _mouseState = Mouse.GetState();

        _currentMousePos = _customCursor.getMousePos();

        _hudManager.updateHandleInput(inputHelper, _selectedEntities);

        if (!_hudManager.HUDSize().Contains(inputHelper.realMousePosition))
        {

            //Make an order on th selected units
            if (inputHelper.MouseRightButtonPressed())
            {
                if (_selectedEntities.Count > 0)
                {
                    foreach (Unit e in _selectedEntities.OfType<Unit>())
                    {
                        if (e.Faction == BuildingAndUnit.faction.Human)
                        {
                            Point pos = new Point((int)_currentMousePos.X , (int)_currentMousePos.Y );
                            bool attack = false;
                            foreach (BuildingAndUnit g in level.entities.OfType<BuildingAndUnit>())
                            {
                                if (g.Faction == BuildingAndUnit.faction.Orc)
                                {
                                    if ((new Rectangle((int)g.Position.X, (int)g.Position.Y, g.Size * 64, g.Size * 64).Contains(pos)))
                                    {
                                        Console.WriteLine("CHAARARRGGEEE   ");
                                        attack = true;
                                        (e as CombatUnit).orderAttack(g);
                                        break;
                                    }
                                }
                            }
                            if (!attack)
                            {
                                e.removeTarget();
                                e.orderMove(new Point((int)_currentMousePos.X / data.tSize(), (int)_currentMousePos.Y / data.tSize()));
                            }
                        }
                    }
                }
            }

            //Order a stop on the selected entities
            if (inputHelper.KeyPressed(Keys.S))
            {
                if(_selectedEntities.Count > 0)
                {
                    foreach (Unit e in _selectedEntities.OfType<Unit>())
                    {
                        e.StopMove();
                    }
                }
            }

            //Drag the selection box to include multiple entities
            if (!inputHelper.MouseLeftButtonDown())
            {
                if (_mouseReleased)
                {
                    Rectangle r = new Rectangle((int)_lastMousePos.X, (int)_lastMousePos.Y, (int)(_currentMousePos.X - _lastMousePos.X), (int)(_currentMousePos.Y - _lastMousePos.Y));
                    foreach (SpriteEntity e in level.entities)
                        if ((r.Contains(e.Center)))
                        {
                            _selectedEntities.Add(e);
                        }
                }
                _mouseReleased = false;
            }

            //Check if the mouse is pressed for the selection
            if (inputHelper.MouseLeftButtonDown())
            {
                if (_mouseReleased == false)
                {
                    _mouseReleased = true;
                    _lastMousePos = _customCursor.getMousePos();
                }


            }

            //One click on a unit to select/deselect them
            if (inputHelper.MouseLeftButtonPressed())
            {

                Vector2 pos = _customCursor.getMousePos();

                bool clickedOnEntity = false;
                foreach (SpriteEntity e in level.entities)
                {
                    if ((new Rectangle((int)e.Position.X, (int)e.Position.Y, e.Size * data.tSize(), e.Size * data.tSize()).Contains(pos)))
                    {
                        clickedOnEntity = true;
                        if (inputHelper.IsKeyDown(Keys.LeftControl))
                        {
                            if (!_selectedEntities.Contains(e))
                            {
                                _selectedEntities.Add(e);
                            }
                        }
                        else
                        {
                            _selectedEntities.Clear();
                            _selectedEntities.Add(e);
                        }
                    }
                }
                if (!clickedOnEntity)
                {
                    _selectedEntities.Clear();
                }
            }
        }

        int x = 0;
        int y = 0;

        if (inputHelper.IsKeyDown(Keys.Right))
        {
            x++;
        }
        if (inputHelper.IsKeyDown(Keys.Left))
        {
            x--;
        }
        if (inputHelper.IsKeyDown(Keys.Up))
        {
            y--;
        }
        if (inputHelper.IsKeyDown(Keys.Down))
        {
            y++;
        }

        // Mouse moves camera, +/- 20 for ease of use
        if (inputHelper.realMousePosition.Y <= 0 + 20)
        {
            y--;
        }
        if (inputHelper.realMousePosition.X <= 0 + 20)
        {
            x--;
        }
        if (inputHelper.realMousePosition.Y >= GameEnvironment.getCamera().getScreenSize().Y - 20)
        {
            y++;
        }
        if (inputHelper.realMousePosition.X >= GameEnvironment.getCamera().getScreenSize().X - 20)
        {
            x++;
        }
        Vector2 camspeedmultiplier = new Vector2(1.0f, 1.0f);
        if (inputHelper.IsKeyDown(Keys.LeftShift))
        {
            camspeedmultiplier = new Vector2(2.0f, 2.0f);
        }
        //Simple camera movement
        Vector2 mov = new Vector2(x, y);
        if (mov != Vector2.Zero)
        {
            mov.Normalize();
            mov *= _camSpeed;
            GameEnvironment.getCamera().move(Vector2.Normalize(mov) * _camSpeed * camspeedmultiplier);
        }

        //Zoomon scroll wheel
        if (_mouseState.ScrollWheelValue < _previousScrollValue)
        {
            GameEnvironment.getCamera().zoom(-.04f);
        }
        else if (_mouseState.ScrollWheelValue > _previousScrollValue)
        {
            GameEnvironment.getCamera().zoom(0.04f);
        }
        _previousScrollValue = _mouseState.ScrollWheelValue;

        if( inputHelper.KeyPressed(Keys.Back))
        {
            menu = true;
        }

    }

}