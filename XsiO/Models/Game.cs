
using XsiO.Enums;

namespace XsiO.Models
{

    public class Game
    {
        private readonly Board _board = new();
        private Mark _turn = Mark.X;
        private GameStatus _status = GameStatus.ONGOING;
        public Board Board => _board;
        public GameStatus Status => _status;


        public Mark GetTurn() => _turn;
        public GameStatus GetStatus() => _status;

        public GameStatus Play(int row, int col)
        {
            if (_status != GameStatus.ONGOING)
            {
                throw new InvalidOperationException("Game over");
            }

            if (!_board.IsFree(row, col))
            {
                throw new ArgumentException("Cell occupied");
            }

            _board.Place(row, col, _turn);

            if (IsWinningMove(row, col, _turn))
            {
                _status = _turn == Mark.X ? GameStatus.X_WINS : GameStatus.O_WINS;
                return _status;
            }

            if (_board.IsFull())
            {
                _status = GameStatus.DRAW;
                return _status;
            }

            _turn = _turn == Mark.X ? Mark.O : Mark.X;
            return _status;
        }

        private bool IsWinningMove(int row, int col, Mark mark)
        {
            return LineCount(row, 0, row, 1, row, 2, mark) == 3
                || LineCount(0, col, 1, col, 2, col, mark) == 3
                || (row == col && LineCount(0, 0, 1, 1, 2, 2, mark) == 3)
                || (row + col == 2 && LineCount(0, 2, 1, 1, 2, 0, mark) == 3);
        }

        private int LineCount(int r1, int c1, int r2, int c2, int r3, int c3, Mark mark)
        {
            int count = 0;
            if (_board.Get(r1, c1) == mark) count++;
            if (_board.Get(r2, c2) == mark) count++;
            if (_board.Get(r3, c3) == mark) count++;
            return count;
        }
    }

}
