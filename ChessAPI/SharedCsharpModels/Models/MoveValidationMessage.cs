namespace SharedCsharpModels.Models
{
    public enum MoveValidationMessage
    {
        Succeeded,
        InvalidMoveOutsideBoard,
        InvalidMoveBlocked,
        IllegalMove,
        WillCheckOneself,
        WrongColor
    }
}
