using TicTacToe.Enums;

namespace TicTacToe.Interfaces;

public interface IBoard
{
    bool IsFree(int row, int col);
    void Place(int row, int col, Mark mark);
    Mark Get(int row, int col);
    bool IsFull();
    void Print();
}