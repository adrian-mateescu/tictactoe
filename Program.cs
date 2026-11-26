using XsiO.Enums;
using XsiO.Models;
namespace XsiO
{


    internal class Program
    {

        static void Main(string[] args)
        {
            Game game = new();

            while (game.GetStatus() == GameStatus.ONGOING)
            {
                Console.WriteLine($"Player {game.GetTurn()}: enter row and col (0-2)");

                if (!int.TryParse(Console.ReadLine(), out int row) ||
                    !int.TryParse(Console.ReadLine(), out int col))
                {
                    Console.WriteLine("Invalid number input");
                    continue;
                }

                try
                {
                    game.Play(row, col);
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine($"Illegal move: {ex.Message}");
                }

                game.Board.Print();
            }

            Console.WriteLine($"Result: {game.Status}");
        }
    }
}
