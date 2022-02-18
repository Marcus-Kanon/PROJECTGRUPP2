namespace ChessAPI.Models
{
    public enum MoveValidationMessage
    {
        Succeeded,
        InvalidMoveOutsideBoard,
        InvalidMoveBlocked,
        IllegalMove,
        WillCheckOneself
    }
}
