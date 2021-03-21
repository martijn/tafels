namespace Tafels.Models
{
    public class Sum
    {
        public int A { get; init; }
        public int B { get; init; }

        public int Answer => A * B;

        public int? UserAnswer { get; set; }

        public bool Correct => Answer == UserAnswer;
    }
}