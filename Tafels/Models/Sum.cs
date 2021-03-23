namespace Tafels.Models
{
    public class Sum
    {
        public int A { get; init; }
        public int B { get; init; }

        public int Answer => A * B;

        public int? UserAnswer { get; set; }

        public bool Correct => Answer == UserAnswer;

        public bool EqualTo(Sum other)
        {
            return A == other.A && B == other.B || A == other.B && B == other.A;
        }

        public static implicit operator Sum((int A, int B) s)
        {
            return new() {A = s.A, B = s.B};
        }
    }
}