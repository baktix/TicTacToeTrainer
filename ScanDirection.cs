namespace TicTacToeTrainer;

public enum ScanDirection
{
    Horizontal,
    Vertical,
    DiagonalLeft,
    DiagonalRight
}

public static class ScanDirectionExtensions
{
    public static (int RowStep, int ColStep) GetStep(this ScanDirection scanDirection) =>
        scanDirection switch
        {
            ScanDirection.DiagonalLeft => (1, 1),
            ScanDirection.DiagonalRight => (-1, 1),
            ScanDirection.Horizontal => (0, 1),
            ScanDirection.Vertical => (1, 0),
            _ => throw new NotSupportedException(scanDirection.ToString())
        };
}