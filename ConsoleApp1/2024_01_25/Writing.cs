using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1._2024_01_25
{
    public  class Writing
    {
        const int CostStraight = 10;
        const int CostDiagonal = 14;
        static int count;
        static Point[] Direction =
        {
            new Point(+1, 0), //상
            new Point(-1, 0), //하
            new Point( 0,-1), //좌
            new Point( 0,+1), //우

            new Point(-1,+1), //좌상
            new Point(-1,-1), //좌하
            new Point(+1,+1), //우상
            new Point(+1,-1), //우하
        };

        public bool PathFinding(bool[,] map,Pos start, Pos goal,out List<Pos> path )
        {
            int xSize = map.GetLength(0);
            int ySize = map.GetLength(1);
            bool[,] visited = new bool[ySize, xSize];
            MapNode[,] nodes = new MapNode[ySize,xSize];
            PriorityQueue<MapNode,int> qp = new PriorityQueue<MapNode,int>();

            MapNode startNode = new MapNode(start, new Pos(0, 0), 0, Heruistic(start, goal));
            qp.Enqueue(startNode, startNode.f);

            nodes[startNode.position.X, startNode.position.Y] = startNode;

            path = new List<Pos>();

            while (qp.Count > 0)
            { 
                MapNode next = qp.Dequeue();
                visited[next.position.Y, next.position.X] = true;


                if(next.position.X == goal.X  && next.position.Y == goal.Y)
                {

                    Pos prev = goal;
                    while(prev.X == start.X && prev.Y == start.Y)
                    {
                        path.Add(prev);
                        prev = nodes[prev.Y,prev.X].parent;
                    }
                    path.Add(start);
                    path.Reverse();
                    return true;
                }

                for (int i = 0; i < Direction.Length; i++)
                {
                    int x = Direction[i].x + next.position.X;
                    int y = Direction[i].y + next.position.Y;

                    if (x > xSize || x < 0 &&
                        y > ySize || y < 0)
                        continue;
                    else if (map[x, y] == false)
                        continue;
                    else if (visited[y, x] == true)
                        continue;
                    else if (i >= 4 &&
                        map[x, next.position.Y] == false &&
                        map[next.position.X, y] == false)
                        continue;

                    MapNode node = new MapNode(new Pos(y, x), next.position);
                    int cost = i <= 4 ? CostDiagonal : CostStraight;
                    int g = next.g + cost;
                    node.SetValue(Heruistic(new Pos(y, x), goal),g);

                    if (visited[y,x] == false && nodes[y,x].f > node.f)
                    {
                        qp.Enqueue(node,node.f);
                        nodes[y,x] = node;
                    }
                }
            }

            path = null;
            return false;
        }

         int Heruistic(Pos start, Pos end)
        {
            int x = start.X < end.X ? end.X - start.X : start.X - end.X;
            int y = start.Y < end.Y ? end.Y - start.Y : start.Y - end.Y;

            int straight = Math.Abs(x - y);
            int dialoge = Math.Max(x, y) - straight;

            return (straight * CostStraight) + (dialoge * CostDiagonal);
        }

        public class MapNode
        {
            public Pos position;
            public Pos parent;

            public int f;
            public int h;
            public int g;

            public MapNode(Pos position, Pos parent,  int h, int g)
            {
                this.position = position;
                this.parent = parent;
                this.f = h + g;
                this.h = h;
                this.g = g;
            }
            public MapNode(Pos position, Pos parent)
            {
                this.position = position;
                this.parent = parent;
            }

            public void SetValue(int h, int g)
            {
                this.h = h;
                this.g = g;
                this.f = h + g;
            }
        }


    }

    public struct Pos
    {
        int x;
        int y;
        public int X { get { return x; } }
        public int Y { get { return y; } }
        public Pos(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
    }


}
