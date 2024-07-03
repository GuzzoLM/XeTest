using System;
using System.Collections.Generic;
using System.Linq;

Console.WriteLine("Hello, World!");

var sol = new Solution();
int[] A = [ 2, 3, 7, 15, 19 ];
Console.WriteLine(sol.solution(A));
Console.ReadLine();

class Solution {
    public int solution(int[] A)
    {
        if (A.Length == 1)
        {
            return A[0];
        }

        var elements = A.Select(num => num.ToString()).ToArray();

        var possibilities = new List<string[]>();

        possibilities.Add(["0", elements[0], elements[0] + elements[1]]);

        for (int i = 1; i < elements.Length - 1; i++)
        {
            var h = i - 1;
            var j = i + 1;

            var possiblePairs = new List<string>();
            possiblePairs.Add(elements[h] + elements[i]);
            possiblePairs.Add(elements[i]);
            possiblePairs.Add(elements[i] + elements[j]);

            possibilities.Add(possiblePairs.ToArray());
        }

        possibilities.Add([elements[^2] + elements[^1], elements[^1], "0"]);

        var sums = GetSums(0, possibilities);
        var sumsResults = sums.Select(x => x.Sum());

        return sumsResults.Max();
    }

    private List<List<int>> GetSums(int start, IEnumerable<string[]> elements)
    {
        if (!elements.Any())
        {
            return new List<List<int>> { new List<int> { 0 } };
        }

        var sums = new List<List<int>>();

        if (start == 3)
        {
            return GetSums(1, elements.Skip(1));
        }

        for (int i = start; i <= 2; i++)
        {
            var j = i + 1;
            var pair = int.Parse(elements.First()[i]);
            var sum = GetSums(j, elements.Skip(1));
            foreach (var sumItem in sum)
            {
                sumItem.Add(pair);
            }
            sums.AddRange(sum);
        }

        return sums;
    }
}