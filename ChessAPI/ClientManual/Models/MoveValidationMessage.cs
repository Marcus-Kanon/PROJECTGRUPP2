namespace ClientManual.Models
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
