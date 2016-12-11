using System.Collections.Generic;
using System;
using Microsoft.Xna.Framework;


public class Node {
public Node(Node parent, Point x, float f, float g, float h)
    {
        _parent = parent;
        _x = x;
        _f = f;
        _g = g;
        _h = h;
    }
    public  Node _parent;
    public Point _x;
    public float _f, _g, _h;
}
class Pathfind
{
    List<Point> findPath(Point start, Point end)
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

    int calculateH(Point x, Point y)
    {
        
        return (int)Math.Abs(Math.Pow(x.X - y.Y,2) + Math.Pow(x.Y - y.Y,2));
    }
}
