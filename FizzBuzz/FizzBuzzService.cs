using System;
using System.Linq;

namespace FizzBuzz
{
    public class FizzBuzzService
    {
        public int Start { get; init; }
        public int End { get; init; }
        public Func<int, string>[] Rules { get; init; }

        public FizzBuzzService(int Start, int End)
        {
            this.Start = Start;
            this.End = End;
            //Use default FizzBuzz rules
            this.Rules = new Func<int, string>[] {
                (int i) => (i % 3) == 0 ? "Fizz" : null,
                (int i) => (i % 5) == 0 ? "Buzz" : null
            };
        }

        public FizzBuzzService(int Start, int End, Func<int, string>[] Rules)
        {
            this.Start = Start;
            this.End = End;
            this.Rules = Rules;
        }

        public void Run()
        {
            for (int i = Start; i <= End; i++)
            {
                Console.WriteLine($"{ i }: { Parse(i) }");
            }
        }

        public string Parse(int i)
        {
            string result = string.Join("", from rule in Rules select rule(i));
            return (result != "") ? result : i.ToString();
        }
    }
}