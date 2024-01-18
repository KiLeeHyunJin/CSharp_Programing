/*< 실습 >
아래와 같은 코드가 있을 때 출력을 생각해보자 : 



아래와 같은 힙이 있을때

힙에 7의 값을 추가하는 경우 단계를 작성하시오.
힙에서 최소값을 제거하는 경우 단계를 작성하시오.
힙을 배열로 표현하시오.
////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

아래 문제를 풀어보자

https://www.acmicpc.net/problem/13904




using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _99._Test
{
    public class Problem3
    {
        public struct Homework
        {
            public string name;
            public int deadline;
            public int score;

            public Homework(string name, int deadline, int score)
            {
                this.name = name;
                this.deadline = deadline;
                this.score = score;
            }
        }

        public void Run()
        {
            int sumScore = 0;
            List<Homework> homeworks = new List<Homework>();

            homeworks.Add(new Homework("A", 4, 60));
            homeworks.Add(new Homework("B", 4, 40));
            homeworks.Add(new Homework("C", 1, 20));
            homeworks.Add(new Homework("D", 2, 50));
            homeworks.Add(new Homework("E", 3, 30));
            homeworks.Add(new Homework("F", 4, 10));
            homeworks.Add(new Homework("G", 6, 5));

            // 마감일이 많이 남은 순서대로 꺼내기 위해 내림차순 우선순위 큐에 추가
            PriorityQueue<Homework, int> remainPQ = new PriorityQueue<Homework, int>();
            foreach (Homework work in homeworks)
            {
                remainPQ.Enqueue(work, -work.deadline);
            }

            // 뒤에서부터 가장 높은 점수 순서대로 처리
            PriorityQueue<Homework, int> scorePQ = new PriorityQueue<Homework, int>();
            for (int day = remainPQ.Peek().deadline; day >= 1; day--)
            {
                while (remainPQ.Count > 0 && remainPQ.Peek().deadline == day)
                {
                    Homework homework = remainPQ.Dequeue();
                    scorePQ.Enqueue(homework, -homework.score);
                }

                if (scorePQ.Count > 0)
                {
                    Homework target = scorePQ.Dequeue();
                    sumScore += target.score;
                    Console.WriteLine($"{target.name} 과제를 {day} 일차에 수행해야 한다. 총점 : {sumScore}");
                }

                if (remainPQ.Count == 0)
                    break;
            }
        }
    }
}





최소 회의실 갯수

https://www.acmicpc.net/problem/19598



using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _99._Test
{
    public class Problem4
    {
        public struct Meeting
        {
            public string name;
            public int start;
            public int end;

            public Meeting(string name, int start, int end)
            {
                this.name = name;
                this.start = start;
                this.end = end;
            }
        }

        public void Run()
        {
            List<Meeting> meetings = new List<Meeting>();

            meetings.Add(new Meeting("A", 0, 40));
            meetings.Add(new Meeting("B", 15, 30));
            meetings.Add(new Meeting("C", 5, 10));
            meetings.Add(new Meeting("D", 20, 40));
            meetings.Add(new Meeting("E", 1, 5));

            PriorityQueue<Meeting, int> remainMeeting = new PriorityQueue<Meeting, int>();
            foreach (Meeting meeting in meetings)
            {
                remainMeeting.Enqueue(meeting, meeting.start);
            }

            PriorityQueue<Meeting, int> doMeeting = new PriorityQueue<Meeting, int>();
            while (remainMeeting.Count > 0)
            {
                Meeting nextStartMeeting = remainMeeting.Dequeue();
                if (doMeeting.Count == 0)
                {
                    Console.WriteLine($"{nextStartMeeting.name}회의를 열기에 비어있는 회의실이 없습니다.");
                    doMeeting.Enqueue(nextStartMeeting, nextStartMeeting.end);
                    Console.WriteLine($"회의실을 추가로 확보하여 {doMeeting.Count}개의 회의실을 사용합니다.");
                }
                else
                {
                    Meeting nextEndMeeting = doMeeting.Peek();
                    if (nextEndMeeting.end <= nextStartMeeting.start)
                    {
                        Console.WriteLine($"{nextEndMeeting.name}이 끝난 회의실에 {nextStartMeeting.name}이 시작합니다.");
                        doMeeting.Dequeue();
                        doMeeting.Enqueue(nextStartMeeting, nextStartMeeting.end);
                    }
                    else
                    {
                        Console.WriteLine($"{nextStartMeeting.name}회의를 열기에 비어있는 회의실이 없습니다.");
                        doMeeting.Enqueue(nextStartMeeting, nextStartMeeting.end);
                        Console.WriteLine($"회의실을 추가로 확보하여 {doMeeting.Count}개의 회의실을 사용합니다.");
                    }
                }
            }

            Console.WriteLine($"필요한 회의실의 갯수는 {doMeeting.Count}개 입니다");
        }
    }
}





/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

A +.중앙값 구하기

https://www.acmicpc.net/problem/2696


*/