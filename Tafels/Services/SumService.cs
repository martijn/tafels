using System;
using System.Collections.Generic;
using System.Linq;
using Tafels.Models;

namespace Tafels.Services;

public class SumService
{
    private readonly Queue<(int, int)> _history = new();
    private readonly Random _rand = new();

    public List<Sum> Random(int sumCount, List<int> tables)
    {
        var sums = new List<Sum>();

        for (var i = 0; i < sumCount; i++)
        {
            Sum sum;

            var tries = 0;
            do
            {
                sum = (_rand.Next(1, 11), tables[_rand.Next(tables.Count)]);
            } while (_history.Contains((sum.A, sum.B)) &&
                     ++tries < sumCount); // try to be unique within the requested set

            sums.Add(sum);
            _history.Enqueue((sum.A, sum.B));

            // If user is practicing 4 multiplication table, keep the last 40 sums in the history
            FlushHistory(tables.Count * 10);
        }

        return sums;
    }

    public void RemoveFromHistory(Sum sum)
    {
        var newHistory = _history.Where(s => !sum.EqualTo(s)).ToList();

        _history.Clear();

        foreach (var s in newHistory)
            _history.Enqueue(s);
    }

    public static List<Sum> FullTable(int number)
    {
        return Enumerable.Range(1, 10).Select(a => (Sum)(a, number)).ToList();
    }

    private void FlushHistory(int keep)
    {
        while (_history.Count > keep)
            _history.Dequeue();
    }
}
