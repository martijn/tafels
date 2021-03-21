using System;
using System.Collections.Generic;
using Tafels.Models;

namespace Tafels.Services
{
    public class SumService
    {
        private readonly Random _rand = new();
        private Queue<(int, int)> _history = new();

        public List<Sum> Generate(int number, List<int> tables)
        {
            var sums = new List<Sum>();

            for (var i = 0; i < number; i++)
            {
                Sum sum;

                var tries = 0;
                do
                {
                   sum = new Sum {A = _rand.Next(1, 10), B = tables[_rand.Next(tables.Count)]};
                } while (_history.Contains((sum.A, sum.B)) && ++tries < 3);

                sums.Add(sum);
                _history.Enqueue((sum.A, sum.B));
                FlushHistory(number * 2);
            }

            return sums;
        }

        private void FlushHistory(int keep)
        {
            while (_history.Count > keep)
                    _history.Dequeue();
        }
    }
}