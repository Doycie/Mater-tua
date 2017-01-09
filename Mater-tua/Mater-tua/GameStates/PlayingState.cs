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
    HUD _hud;
    Vector2 _lastMousePos;
    Vector2 _currentMousePos;
    bool _mouseReleased;
    Texture2D _selectTex;

  
    //Construct a new state and set the level and all the needed variables
    public PlayingState()
    {
        _customCursor = new CustomCursor();
        _hud = new PlayingHUD();
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
        _hud.draw(spriteBatch);
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

        (_hud as PlayingHUD).update(inputHelper, _selectedEntities);

        if (!_hud.HUDSize().Contains(inputHelper.realMousePosition))
        {

            //Make an order on th selected units
            if (inputHelper.MouseRightButtonPressed() && _selectedEntities.Count > 0)
            {

                foreach (Unit e in _selectedEntities.OfType<Unit>())
                {
                    if (e.Faction == BuildingAndUnit.faction.Human)
                    {
                        Point pos = new Point((int)_currentMousePos.X, (int)_currentMousePos.Y);
                        bool attack = false;
                        foreach (BuildingAndUnit g in level.entities.OfType<BuildingAndUnit>())
                        {
                            if (g.Faction == BuildingAndUnit.faction.Orc)
                            {
                                if ((new Rectangle((int)g.Position.X, (int)g.Position.Y, g.Size * data.tSize(), g.Size * data.tSize()).Contains(pos)))
                                {
                                    Console.WriteLine("CHAARARRGGEEE   ");
                                    attack = true;
                                    (e as CombatUnit).orderAttack(g);
                                    break;
                                }
                            }
                        }
                        //werk nog niet
                        
                        ///////////
                        if (!attack)
                        {
                            e.removeTarget();
                            e.orderMove(new Point((int)_currentMousePos.X / data.tSize(), (int)_currentMousePos.Y / data.tSize()));
                        }
                    }
                }
                foreach (WorkerUnit q in level.entities.OfType<WorkerUnit>())
                {
                    Point pos1 = new Point((int)_currentMousePos.X, (int)_currentMousePos.Y);
                    foreach (Mine w in level.entities.OfType<Mine>())
                    {
                        foreach (Townhall r in level.entities.OfType<Townhall>())
                        {
                            if ((new Rectangle((int)w.Position.X, (int)w.Position.Y, w.Size * data.tSize(), w.Size * data.tSize()).Contains(pos1)))
                            {
                                q.OrderReset();
                                q.Order(0, w.Position, r.Position);
                                break;
                            }
                        }
                    }
                    foreach (Tree n in level.entities.OfType<Tree>())
                    {
                        foreach (Townhall r in level.entities.OfType<Townhall>())
                        {
                            if ((new Rectangle((int)n.Position.X, (int)n.Position.Y, n.Size * data.tSize(), n.Size * data.tSize()).Contains(pos1)))
                            {
                                q.OrderReset();
                                q.Order(1, n.Position, r.Position);
                                break;
                            }
                        }
                    }
                }

            }

            //Order a stop on the selected entities
            if (inputHelper.KeyPressed(Keys.S))
            {
                if (_selectedEntities.Count > 0)
                {
                    foreach (Unit e in _selectedEntities.OfType<Unit>())
                    {
                        e.StopMove();
                    }
                    foreach (WorkerUnit q in level.entities.OfType<WorkerUnit>())
                    {
                        q.OrderReset();
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
                        if ((e as BuildingAndUnit).Faction == BuildingAndUnit.faction.Human)
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

        if (inputHelper.KeyPressed(Keys.Back))
        {
            GameEnvironment.gameStateManager.State = GameStateManager.state.Pause;
        }
        if (inputHelper.KeyPressed(Keys.F1))
        {
            GameEnvironment.gameStateManager.State = GameStateManager.state.Menu;
        }

    }

}