using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1._2024_01_23
{
    public class Graph
    {

        //인접리스트 : 단점 , 전부 탐색해야하기 때문에 느림, 직관적이지 않음.

        public class Node<T> //연결그래프
        {
            public T vertex;
            public List<Node<T>> edge;

        }

        public class GraphNode<T> //가중치 그래프
        {
            public T vertex;
            public List<(Node<T>, int)> edge; //간선,가중치

        }

        //인접 행렬 그래프 
        bool[,] matrixGraph = new bool[5, 5]
        {
            { false, false, false, false, true  },
            { false, false, true,  false, false },
            { false, true,  false, true,  false },
            { false, false, true,  false, true  },
            { true,  false, false, true,  false },
        };

        const int INF = int.MaxValue;

        int[,] matrixGraph2 = new int[5, 5] //가중치가 있는 그래프 maxValue는 연결x
        {
            { 0,    132,    INF,    INF,    16      },
            { 12,   0,      INF,    INF,    INF     },
            { INF,  38,     0,      INF,    INF     },
            { INF,  12,     INF,    0,      54      },
            { INF,  INF,    INF,    INF,    0       }
        };



        bool[,] NumOne = new bool[8, 8]
        {       // 0    1       2       3       4      5    6       7
           /*0*/ {false, false, true,  false, true,  false, false, false },

           /*1*/ {false, false, true,  false, false, true,  false, false },

           /*2*/ {true,  true,  false, false, false, true,  true,  false}, 

           /*3*/ {false, false, false, false, false, false, false, true},

           /*4*/ {true,  false, false, false, false, false, false, true},

           /*5*/ {false, true,  true,  false, false, false, false, false},

           /*6*/ {false, true,  false, false, false, false, false, false},

           /*7*/ {false, false, false, true,  true,  false, false, false},
        };

        bool[,] NumTwo = new bool[8, 8]
        {
                //  0       1       2       3       4       5       6       7
            /*0*/{ false,  false,  false,  false,  false,  false,  false,  false},

            /*1*/{ false,  false,  false,  false,  false,  false,  false,  false},

            /*2*/{ false,  false,  false,  false,  true,   true,   false,  false},

            /*3*/{ false,  true,   false,  false,  false,  true,   false,  true},

            /*4*/{ false,  false,  false,  false,  false,  false,  false,  false},

            /*5*/{ false,  true,   false,  false,  false,  false,  false,  false},

            /*6*/{ false,  false,  true,   false,  false,  true,   false,  false},

            /*7*/{ false,  false,  false,  false,  false,  false,  true,   false}
        };
        int[,] NumThree = new int[8, 8]
        {
            //0     1       2       3       4       5       6       7
        /*0*/{INF,   4,      INF,    INF,    6,      INF,    INF,    INF },

        /*1*/{4,     INF,    5,      4,      INF,    8,      2,      INF },

        /*2*/{INF,   5,      INF,    INF,    9,      INF,    INF,    INF },

        /*3*/{INF,   4,      INF,    INF,    INF,    INF,    INF,    INF },

        /*4*/{6,     INF,    9,      INF,    INF,    INF,    5,      INF },

        /*5*/{INF,   8,      INF,    INF,    INF,    INF,      INF,    1 },

        /*6*/{INF,   2,      INF,    INF,    5,      INF,    INF,    INF },

        /*7*/{INF,   INF,    INF,    INF,    INF,    1,     INF,     INF }
        };

        bool[,] matrixGraph1 = new bool[7, 7]
            {
                //0         1      2    3       4       5       6
                { false, false, false, false, true,  true,  true},
                { false, false, true,  false, false, true,  false},
                { false, true,  false, true,  false, false, false},
                {false,  false, true,  false, true,  false, false },
                {true,   false, false, true,  false, false, false },
                {true,   false, false, true,  false, false, false },
                {true,   true,  true,  true,  false, false, true },
            };





    }
}
