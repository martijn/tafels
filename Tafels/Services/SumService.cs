using System;
using System.Collections.Generic;
using Tafels.Models;

namespace Tafels.Services
{
    public class SumService
    {
        private readonly Random _rand = new();
        private List<Sum> _history = new();

        public List<Sum> Generate(int number, List<int> tables)
        {
            var sums = new List<Sum>();

            for (var i = 0; i < number; i++)
            {
                var sum = new Sum {A = _rand.Next(10) + 1, B = tables[_rand.Next(tables.Count)]};
                // Retry once if sum is in history
                if (_history.Contains(sum))
                    sum = new Sum {A = _rand.Next(10) + 1, B = tables[_rand.Next(tables.Count)]};

                sums.Add(sum);
                _history.Add(sum);
            }

            if (_history.Count > number * 3)
                _history = _history.GetRange(0, number * 3);

            return sums;
        }
    }
}