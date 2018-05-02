using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess
{
    public class TopPlayerPieceRulesProvider: IPlayerSetUpProvider
    {
        public TopPlayerPieceRulesProvider()
        {

        }
        public void Init(IBoard boardInput, IPlayer owner)
        {
            PawnPositionSetup(boardInput, owner);
            KnightPositionSetup(boardInput, owner);
            BishopPositionSetup(boardInput, owner);
            RookPositionSetup(boardInput, owner);
            KingPositionSetup(boardInput, owner);
            QueenPositionSetup(boardInput, owner);
        }

        public static List<MoveSet> PawnMoveSetSetup()
        {
            var pawnMoveSet1 = new MoveSet(1, 0, null);
            var pawnMoveSet2 = new MoveSet(1, -1, (IBoard board, IPiece piece) =>
            {
                return board.CheckSpaceforOpposingTeamPiece(new Position(piece.Position.Row + 1, piece.Position.Column - 1), piece); 
            });
            var pawnMoveSet3 = new MoveSet(1, 1, (IBoard board, IPiece piece) =>
            {
                return board.CheckSpaceforOpposingTeamPiece(new Position(piece.Position.Row + 1, piece.Position.Column + 1), piece);
                ;
            });
            var pawnMoveList = new List<MoveSet>()
            {
                pawnMoveSet1,
                pawnMoveSet2,
                pawnMoveSet3
            };
            return pawnMoveList;
        }
        public static void PawnPositionSetup(IBoard curBoard, IPlayer owner)
        {
            var pawnMoveList = PawnMoveSetSetup();

            for (var columnIdx = 0; columnIdx < curBoard.NumColumns; columnIdx++)
            {
                var pawnToAdd = new Piece(PieceType.Pawn, pawnMoveList, false, new Position(1, columnIdx), owner);
                curBoard.contents[1, columnIdx] = pawnToAdd;
            }

        }

        public static List<MoveSet> KnightMoveSetSetup()
        {
            var knightMoveList = new List<MoveSet>()
            {
                new MoveSet(-2, -1, null),
                new MoveSet(-2, 1, null),
                new MoveSet(2, -1, null),
                new MoveSet(2, 1, null),
                new MoveSet(-1, -2, null),
                new MoveSet(-1, 2, null),
                new MoveSet(1, -2, null),
                new MoveSet(1, 2, null)
            };

            return knightMoveList;
        }
        public static void KnightPositionSetup(IBoard curBoard, IPlayer owner)
        {

            var knightMoveList = KnightMoveSetSetup();
            var knightPosition1 = new Position(0, 1);
            var knightToAdd = new Piece(PieceType.Knight, knightMoveList, false, knightPosition1, owner);
            curBoard.contents[knightPosition1.Row, knightPosition1.Column] = knightToAdd;
            var knightPosition2 = new Position(0, curBoard.NumColumns - 2);
            var knightToAdd2 = new Piece(PieceType.Knight, knightMoveList, false, knightPosition1, owner);
            curBoard.contents[knightPosition2.Row, knightPosition2.Column] = knightToAdd2;

        }
        public static List<MoveSet> BishopMoveSetSetup()
        {

            return new List<MoveSet>()
            {
                new MoveSet(-1, -1, null),
                new MoveSet(-1, 1, null),
                new MoveSet(1, -1, null),
                new MoveSet(1, 1, null),

            };
        }
        public static void BishopPositionSetup(IBoard curBoard, IPlayer owner)
        {
            var bishopMoveList = BishopMoveSetSetup();
            var bishopPosition1 = new Position(0, 2);
            var bishopToAdd = new Piece(PieceType.Bishop, bishopMoveList, true, bishopPosition1, owner);
            curBoard.contents[bishopPosition1.Row, bishopPosition1.Column] = bishopToAdd;
            var bishopPosition2 = new Position(0, curBoard.NumColumns - 3);
            var bishopToAdd2 = new Piece(PieceType.Bishop, bishopMoveList, true, bishopPosition1, owner);
            curBoard.contents[bishopPosition2.Row, bishopPosition2.Column] = bishopToAdd2;

        }
        public static List<MoveSet> RookMoveSetSetup()
        {

            return new List<MoveSet>()
            {
                new MoveSet(-1, 0, null),
                new MoveSet(0, 1, null),
                new MoveSet(0, -1, null),
                new MoveSet(1, 0,null),

            };
        }
        public static void RookPositionSetup(IBoard curBoard, IPlayer owner)
        {

            var RookMoveList = RookMoveSetSetup();
            var RookPosition1 = new Position(0, 0);
            var RookToAdd = new Piece(PieceType.Rook, RookMoveList, true, RookPosition1, owner);
            curBoard.contents[RookPosition1.Row, RookPosition1.Column] = RookToAdd;
            var RookPosition2 = new Position(0, curBoard.NumColumns - 1);
            var RookToAdd2 = new Piece(PieceType.Rook, RookMoveList, true, RookPosition1, owner);
            curBoard.contents[RookPosition2.Row, RookPosition2.Column] = RookToAdd2;

        }
        public static List<MoveSet> KingMoveSetSetup()
        {

            return new List<MoveSet>()
            {
                new MoveSet(-1, 0, null),
                new MoveSet(0, 1, null),
                new MoveSet(0, -1, null),
                new MoveSet(1, 0,null),
                new MoveSet(-1, -1, null),
                new MoveSet(-1, 1, null),
                new MoveSet(1, -1, null),
                new MoveSet(1, 1, null),

            };
        }
        public static void KingPositionSetup(IBoard curBoard, IPlayer owner)
        {

            var KingMoveList = KingMoveSetSetup();
            var KingPosition1 = new Position(0, 4);
            var KingToAdd = new Piece(PieceType.King, KingMoveList, false, KingPosition1, owner);
            curBoard.contents[KingPosition1.Row, KingPosition1.Column] = KingToAdd;

        }
        public static List<MoveSet> QueenMoveSetSetup()
        {

            return new List<MoveSet>()
            {
                new MoveSet(-1, 0, null),
                new MoveSet(0, 1, null),
                new MoveSet(0, -1, null),
                new MoveSet(1, 0,null),
                new MoveSet(-1, -1, null),
                new MoveSet(-1, 1, null),
                new MoveSet(1, -1, null),
                new MoveSet(1, 1, null),

            };
        }
        public static void QueenPositionSetup(IBoard curBoard, IPlayer owner)
        {

            var QueenMoveList = QueenMoveSetSetup();
            var QueenPosition1 = new Position(0, 3);
            var QueenToAdd = new Piece(PieceType.Queen, QueenMoveList, true, QueenPosition1, owner);
            curBoard.contents[QueenPosition1.Row, QueenPosition1.Column] = QueenToAdd;

        }
    }
}
