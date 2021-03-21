namespace Tafels.Models
{
    public record Sum
    {
        public int A { get; init; }
        public int B { get; init; }

        public int Answer => A * B;
    }
}