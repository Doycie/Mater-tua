using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;

public enum NodeState { Untested, Open, Closed }

internal class Node
{
    //NOT USED CODED for future astar pathfinding
    public Node(Node parent, Point x, float f, float g, float h)
    {
        _parent = parent;
        _x = x;
        _f = f;
        _g = g;
        _h = h;
    }

    public Node _parent;
    public Point _x;
    public float _f, _g, _h;
}

//Class that contains all the pathfinding methods
 class Pathfind
{

 

    //Method that returns a very simple path in the form of a list of points.
    //Only goes directly to its target, and no further then 10 tiles
    public List<Point> findPathSimple(Point start, Point end)
    {


        //Variable for the path
        List<Point> path = new List<Point>();

        Point a = start;

        //While to search trough the tiles
        while (a != end && !(path.Count >= 10))
        {
            if (a.X < end.X)
                a.X++;
            else if (a.X > end.X)
                a.X--;

            if (a.Y < end.Y)
                a.Y++;
            else if (a.Y > end.Y)
                a.Y--;

            //Add the current tile to the path
            path.Add(a);
        }

        return path;
    }

   

    //NOT USED CODE Started working on Astar pathfinding algorithm
    public List<Point> findPathAStar(Point start, Point end, byte[,] map,Level level)
    {
        List<Node> openList = new List<Node>();
        List<Node> closedList = new List<Node>();
        List<Point> path = new List<Point>();

        openList.Clear();
        closedList.Clear();

        openList.Add(new Node(null, start, 0, 0, 0));
        //Node tmpn = new Node(null, Point.Zero, 999999.9f, 0, 0);

        Node Q = null;

        while (openList.Count > 0 && openList.Count < 150)
        {
            float lowestF = 99999.0f;
            foreach (var n in openList)
            {
                if (n._f < lowestF)
                {
                    Q = n;
                    lowestF = n._f;
                }
            }

            // Q = tileList[tileList.Count - 1];

            for (int i = openList.Count - 1; i >= 0; i--)
            {
                if (openList[i]._x == Q._x)
                    openList.RemoveAt(i);
            }

            List<Node> children = new List<Node>();

            Point loc = Q._x;

            for (int i = -1; i < 2; i++)
            {
                for (int k = -1; k < 2; k++)
                {
                    if (!(loc.X + i < 0 || loc.Y + k < 0 || loc.X + i > map.GetLength(0) || loc.Y +k > map.GetLength(1)))
                    {
                        if (!(i == 0 && k == 0))
                        {
                            if (map[loc.X + i, loc.Y + k] == 0)
                            {
                                bool skip = false;
                                foreach (BuildingAndUnit e in level.entities.OfType<BuildingAndUnit>())
                                {
                                    if (!(e is WorkerUnit))
                                    {
                                        int x = (int)e.Position.X / 64;
                                        int y = (int)e.Position.Y / 64;
                                        for (int xx = 0; xx < e.Size; xx++)
                                        {
                                            for (int yy = 0; yy < e.Size; yy++)
                                            {
                                                if ((x + xx == loc.X + i && y + yy == loc.Y + k) && !(loc.X + i == end.X && loc.Y + k == end.Y))
                                                {
                                                    skip = true;
                                                }
                                            }
                                        }
                                    }
                                }
                                if (skip)
                                {
                                    continue;
                                }
                                int eg = 0;
                                if (!(k == 0 || i == 0))
                                    eg += 6;
                                children.Add(new Node(Q, new Point(loc.X + i, loc.Y + k), eg, 0, 0));
                            }
                        }
                    }
                }
            }

            foreach (var child in children)
            {
                if (child._x == end)
                {
                    path.Clear();
                    path.Add(child._x);

                    Node np = Q;

                    while (np._x != start)
                    {
                        path.Add(np._x);

                        np = np._parent;

                        if (np._parent == null)
                        {
                            return path;
                        }
                    }
                    return path;
                }
            }
            foreach (var child in children)
            {
                child._g += Q._g + 10;
                child._h = calculateH(child._x, start) * 10;
                child._f = child._g + child._h;

                bool skipChild = false;

                foreach (var n in openList)
                {
                    if (n._x == child._x && n._f < child._f)
                    {
                        skipChild = true;
                    }
                }

                foreach (var n in closedList)
                {
                    if (n._x == child._x)
                    {
                        skipChild = true;
                    }
                }
                if (skipChild)
                    continue;

                openList.Add(child);
            }

            closedList.Add(Q);
        }

        return path;
    }

    public void draw(SpriteBatch s)
    {
        //foreach (var e in openList)
        //{
        //    s.Draw(GameEnvironment.getAssetManager().GetSprite("Sprites/UI/selectbox"), new Rectangle(e._x.X * 64 + 1, e._x.Y * 64 + 1, 64 - 2, 64 - 2), Color.White);
        //}
        //foreach (var e in closedList)
        //{
        //    s.Draw(GameEnvironment.getAssetManager().GetSprite("Sprites/UI/selectbox"), new Rectangle(e._x.X * 64, e._x.Y * 64, 64, 64), Color.Blue);
        //    s.DrawString(GameEnvironment.getAssetManager().getFont("Warcraft Font"), "F: " + e._f, new Vector2(e._x.X * 64 + 5, e._x.Y * 64 + 5), Color.White, 0.0f, Vector2.Zero, 0.5f, SpriteEffects.None, 0.0f);
        //    s.DrawString(GameEnvironment.getAssetManager().getFont("Warcraft Font"), "G: " + e._g, new Vector2(e._x.X * 64 + 5, e._x.Y * 64 + 23), Color.White, 0.0f, Vector2.Zero, 0.5f, SpriteEffects.None, 0.0f);
        //    s.DrawString(GameEnvironment.getAssetManager().getFont("Warcraft Font"), "H: " + e._h, new Vector2(e._x.X * 64 + 5, e._x.Y * 64 + 40), Color.White, 0.0f, Vector2.Zero, 0.5f, SpriteEffects.None, 0.0f);
        //}
    }

    //Simple method for the H value only pythagoras for now
    private float calculateH(Point x, Point y)
    {
        return (float)Math.Sqrt(Math.Pow(x.X - y.X, 2) + Math.Pow(x.Y - y.Y, 2));
    }
}