using System.Collections.Generic;
using System.Linq;

namespace Tafels.Models
{
    public class Round
    {
        public List<Sum> Sums { get; set; }
        public bool ShowResults { get; set; }

        public bool Completed => Sums.All(s => s.Correct);
    }
}