

using TicTacToe.Enums;
using TicTacToe.Interfaces;

namespace TicTacToe.Models;

public class Board : IBoard
{
    private readonly Mark[][] _grid = new Mark[3][];

    public Board()
    {
        for (int i = 0; i < 3; i++)
        {
            _grid[i] = new Mark[3];
            Array.Fill(_grid[i], Mark.EMPTY);
        }
    }

    public bool IsFree(int row, int col)
    {
        return InBounds(row, col) && _grid[row][col] == Mark.EMPTY;
    }

    public void Place(int row, int col, Mark mark)
    {
        if (!IsFree(row, col))
        {
            throw new ArgumentException("Cell occupied");
        }
        _grid[row][col] = mark;
    }

    public Mark Get(int row, int col) => _grid[row][col];

    public bool IsFull()
    {
        foreach (Mark[] row in _grid)
        {
            foreach (Mark m in row)
            {
                if (m == Mark.EMPTY)
                {
                    return false;
                }
            }
        }
        return true;
    }

    private static bool InBounds(int row, int col) =>
        row >= 0 && row < 3 && col >= 0 && col < 3;

    public void Print()
    {
        for (int r = 0; r < 3; r++)
        {
            for (int c = 0; c < 3; c++)
            {
                char ch = _grid[r][c] switch
                {
                    Mark.X => 'X',
                    Mark.O => 'O',
                    _ => '.'
                };
                Console.Write(c < 2 ? $"{ch} " : $"{ch}");
            }
            Console.WriteLine();
        }
    }


}
