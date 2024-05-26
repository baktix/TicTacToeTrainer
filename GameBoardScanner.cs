namespace TicTacToeTrainer;

public class GameBoardScanner(GameBoard gameBoard)
{
    public GameBoard GameBoard { get; private init; } =
        gameBoard ?? throw new ArgumentNullException(nameof(gameBoard));

    public IDictionary<State, int> Count(
        int startCol1 = 1, int startRow1 = 1,
        ScanDirection scanDirection = ScanDirection.Horizontal
        )
    {
        if (startCol1 != 1 && startRow1 != 1)
            throw new InvalidOperationException(
                "Scan must start from first column or row"
                );

        (int rowStep, int colStep) = scanDirection.GetStep();

        Dictionary<State, int> counts =
            Enum.GetValues<State>().ToDictionary(k => k, v => 0);

        for (int r = startRow1 - 1, c = startCol1 - 1;
            r < gameBoard.Rows && c < gameBoard.Columns;
            r += rowStep, c += colStep)
        {
            State state = GameBoard[r, c];
            counts[state]++;
        }

        return counts;
    }
}