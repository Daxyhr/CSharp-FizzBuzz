using System;
using System.Linq;

namespace FizzBuzz
{
    public class FizzBuzzService
    {
        public Func<int, string>[] Rules { get; init; }

        public FizzBuzzService()
        {
            //Use default FizzBuzz rules
            Rules = new Func<int, string>[] {
                (int i) => (i % 3) == 0 ? "Fizz" : null,
                (int i) => (i % 5) == 0 ? "Buzz" : null
            };
        }

        public FizzBuzzService(Func<int, string>[] rules)
        {
            Rules = rules;
        }

        public void Run(int start, int end)
        {
            for (int i = start; i <= end; i++)
            {
                Console.WriteLine($"{ i }: { Parse(i) }");
            }
        }

        public string Parse(int step)
        {
            string result = string.Join("", from rule in Rules select rule(step));
            return (result != "") ? result : step.ToString();
        }
    }
}