using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessLogic {
    public class King : Piece {
        public override PieceType Type => PieceType.King;
        public override Player Color { get; }
        private static readonly Direction[] dirs = new Direction[] {
            Direction.North,
            Direction.NorthEast,
            Direction.East,
            Direction.SouthEast,
            Direction.South,
            Direction.SouthWest,
            Direction.West,
            Direction.NorthWest
        };
        public King(Player color)
        {
            Color = color;
        }
        public override Piece Copy()
        {
            King copy = new King(Color);
            copy.HasMoved = HasMoved;
            return copy;
        }

        private IEnumerable<Position> MovePositions(Position form, Board board)
        {
            foreach (Direction dir in dirs)
            {
                Position to = form + dir;
                if (!Board.IsInside(to))
                {
                    continue;
                }
                if (board.IsEmpty(to) || board[to].Color != Color)
                {
                    yield return to;
                }
            }
        }
        public override IEnumerable<Move> GetMoves(Position from, Board board)
        {
            foreach (Position to in MovePositions(from, board))
            {
                yield return new NormalMove(from, to);
            }
        }
    }
}