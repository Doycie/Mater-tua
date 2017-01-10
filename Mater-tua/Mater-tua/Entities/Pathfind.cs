using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;

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
internal class Pathfind
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
    private List<Point> findPathAStar(Point start, Point end, byte[,] map)
    {
        List<Point> path = new List<Point>();

        List<Node> tileList;
        List<Node> openList = new List<Node>();
        List<Node> closedList;

        openList.Add(new Node(null, start, 0, 0, 0));
        Node tmpn = new Node(null, Point.Zero, 999999.9f, 0, 0);

        Node Q = tmpn;

        while (Q._x != end && openList.Count > 0)
        {
        }

        return path;
    }

    //Simple method for the H value only pythagoras for now
    private int calculateH(Point x, Point y)
    {
        return (int)Math.Abs(Math.Pow(x.X - y.Y, 2) + Math.Pow(x.Y - y.Y, 2));
    }
}