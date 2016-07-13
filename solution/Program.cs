using System;
using System.Collections.Generic;

namespace SegmentsIntersections
{


    class Solution
    {
        public int solution(int[] A)
        {
            var list = new List<Segment>();
            int n = A.Length;
            for (int i = 0; i < n; ++i)
                list.Add(new Segment(i, - A[i], A[i]));
            list.Sort((s1, s2) => s1.StartPoint.CompareTo(s2.StartPoint));
            
            int answer = 0;

            for (int i = 0; i < n; ++i)
            {
                int curR = list[i].EndPoint;
                int j = i + 1;
                while(j < n && list[j].StartPoint <= curR)
                {
                    answer++;
                    if (answer > 10000000)
                        return -1;
                    j++;
                }
            }

            return answer;
        }
    }

    struct Segment
    {
        public int StartPoint { get; set; }
        public int EndPoint { get; set; }

        public Segment(int sP, int eP)
        {
            StartPoint = sP;
            EndPoint = eP;
        }

        public Segment(int center, int dL, int dR)
        {
            StartPoint = (center + dL <= center) ? (center + dL) : int.MinValue;
            EndPoint = (center + dR >= center) ? (center + dR) : int.MaxValue;
        }

    }

    class Program
    {
        static void Main()
        {
            Solution s = new Solution();
            Console.WriteLine(s.solution(new int[] { 1, 5, 2, 1, 4, 0 }));
            Console.ReadLine();
        }

    }
}
