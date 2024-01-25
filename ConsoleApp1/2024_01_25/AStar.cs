using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1._2024_01_25
{
    public class AStar
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

        public bool _PathFinding(bool[,] tilemap,Point start, Point end, out List<Point>path)
        {
            int ySize = tilemap.GetLength(0);
            int xSize = tilemap.GetLength(1);

            ASNode[,] nodes = new ASNode[ySize, xSize];
            bool[,] visited = new bool[ySize, xSize];
            
            path = new List<Point>();
            PriorityQueue<ASNode,int> nextPointPQ = new PriorityQueue<ASNode,int>();

            ASNode startNode = new ASNode(start, new Point(), 0, Heruistic(start,end));
            nodes[startNode.PosX, startNode.PosY] = startNode;
            
            nextPointPQ.Enqueue(startNode, startNode.f);

            while (nextPointPQ.Count > 0)
            {
                ASNode nextNode  = nextPointPQ.Dequeue();

                visited[nextNode.PosY, nextNode.PosX] = true;



                //도착
                if (nextNode.PosX == end.x && nextNode.PosY == end.y)
                {
                    return true;
                    Point point = end;

                    while(point.x == start.x && point.y == start.y)
                    {
                        path.Add(point);
                        point = nodes[point.y, point.x].parent;
                    }

                    path.Add(start);
                    path.Reverse();

                    return true;
                }

                //탐색
                for (int i = 0; i < Direction.Length; i++)
                {
                    int x = nextNode.PosX + Direction[i].x;
                    int y = nextNode.PosY + Direction[i].y;

                    if (x > xSize || x < 0 ||   //맵을 벗어나는 위치
                        y > ySize || y < 0)
                        continue;
                    else if 
                        (tilemap[y, x] == false)  //갈 수 없는 위치
                        continue;
                    else if 
                        (visited[y, x] == true) //이미 확인한 위치일 경우
                        continue;

                    else if
                        ( i >= 4 &&     //상하나 좌우가 막혀 있을 경우 대각선 이동 금지
                          tilemap[y,nextNode.PosX] == false && 
                          tilemap[nextNode.PosY,x] == false  )
                        continue;
                    
                    Draw(tilemap, ySize, xSize, visited, end);

                    int cost = i < 4 ? CostStraight : CostDiagonal; //대각선일경우 대각선 코스트를 전달
                    int g = nextNode.g + cost;
                    int h = Heruistic(new Point(x, y), end);
                    ASNode newNode = new ASNode(new Point(x, y), nextNode.pos, g, h);

                    if (nodes[y,x] == null || nodes[y, x].f > newNode.f) //계산이 안된위치이거나 
                    {                                                    //값이 높게 적혀있으면 갱신
                        nodes[y, x] = newNode;
                        nextPointPQ.Enqueue(newNode, newNode.f);
                    }
                }
            }
            path = null;
            return false;
        }

        public int Heruistic(Point start, Point end)
        {
            int xSize = start.x > end.x ? start.x - end.x : end.x - start.x;//Math.Abs(start.x - end.x);
            int ySize = start.y > end.y ? start.y - end.y : end.y - start.y;//Math.Abs(start.y - end.y);

            //return CostStraight * (xSize + ySize);//xSize + ySize;
            //return CostStraight * (int)Math.Sqrt(xSize * xSize + ySize * ySize);
            
            int straightCount = Math.Abs(xSize - ySize);
            int diagonalCount = Math.Max(xSize, ySize) - straightCount;
            return (CostStraight * straightCount) + (diagonalCount * CostDiagonal);
        }

        public class ASNode
        {
            public Point pos;
            public Point parent;
            public int f;
            public int g;
            public int h;
            public int PosX { get { return pos.x; } }       
            public int PosY { get { return pos.y; } }       

            public ASNode(Point pos, Point parent, int g, int h)
            {
                this.pos = pos;
                this.parent = parent;
                this.f = g + h;
                this.g = g;
                this.h = h;
            }
        }


        void Draw(bool[,] tilemap, int ySize, int xSize, bool[,] visited , Point end)
        {
            Thread.Sleep(100);
            StringBuilder stringBuilder = new StringBuilder();
            for (int i = 0; i < ySize; i++)
            {
                stringBuilder.Append("봟");
                for (int j = 0; j < xSize; j++)
                {
                    if(end.x == j && end.y == i)
                        stringBuilder.Append("&");
                    else if (visited[i, j])
                    {
                        stringBuilder.Append("O");
                    }
                    else if (tilemap[i, j] == true)
                    {
                        stringBuilder.Append(" ");
                    }
                    else
                    {
                        stringBuilder.Append("#");
                    }
                }
                stringBuilder.Append("봟");
                stringBuilder.Append("\n");
            }
        count++;
            Console.Clear();
            Console.Write(stringBuilder.ToString());
        }

    }
    public struct Point
    {
        public int x;
        public int y;
        public Point(int x,int y)
        {
            this.x = x;
            this.y = y;
        }
        public static bool operator == (Point left, Point right)
        {
            if(left.x == right.x && left.y == right.y)
                return true;
            return false;
        }
        public static bool operator != (Point left, Point right) 
        { 
            if(left.x == right.x && left.y == right.y)
                return false;
            return true;
        }
    }

}
