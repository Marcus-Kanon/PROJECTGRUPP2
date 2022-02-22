﻿using SharedCsharpModels.Models;


namespace ChessAPI.GamePieces
{
    public class Rook : GamePiece
    {
        public override string Name { get => "\u265C"; }

        public Rook(GameState game, Color color) : base(game, color)
        {
            Type = PieceType.Rook;
        }

        public override MoveValidationMessage Move((int, int) oldCords, (int, int) newCords)
        {
            _game.Board[newCords.Item1, newCords.Item2] = _game.Board[oldCords.Item1, oldCords.Item2];
            _game.Board[oldCords.Item1, oldCords.Item2] = new NoPiece(_game, Color);
            return MoveValidationMessage.Succeeded;
        }
    }
}
