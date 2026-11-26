using TicTacToe.Enums;

namespace TicTacToe.Interfaces;

public interface IGame
{
    IBoard Board { get; }
    Mark GetTurn();
    GameStatus GetStatus();
    GameStatus Play(int row, int col);
}