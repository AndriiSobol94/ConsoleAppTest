using System;

namespace ConsoleAppTest {
public class Program {
       public static void Main(string[] args) {
            try {
                ParseArguments(args, out int a, out int b);
                Console.WriteLine($"Entered numbers: {a} {b}");

                Console.WriteLine($"Sum: {a + b}");
                Console.WriteLine($"Subtraction: {a - b}");
                Console.WriteLine($"Multiplication: {a * b}");
                if (b != 0) {
                    Console.WriteLine($"Division: {a / b}");
                } else {
                    Console.WriteLine($"Division could not be calculated because of zero argument.");
                }
            } catch (Exception ex) {
                Console.WriteLine(ex.Message);
            }
        }

        private static void ParseArguments(string[] args, out int a, out int b) {
            if (args.Length != 2) {
                throw new ArgumentException("Two numeric arguments must be entered", nameof(args));
            }
            if (!int.TryParse(args[0], out a)) {
                throw new ArgumentException("First argument is not valid");
            }
            if (!int.TryParse(args[1], out b)) {
                throw new ArgumentException("Second argument is not valid");
            }
        }
    }
}
