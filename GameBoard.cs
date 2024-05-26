using System.Text;
using System.Globalization;

namespace MLExperiments;

public class GameBoard
{
    public const int Rows = 3, Columns = 3;

    public enum State : int
    {
        Empty = 0,
        Nought,
        Cross
    }

    public State this[int row, int column]
    {
        get
        {
            if (row < 0 || row > Rows - 1)
                throw new IndexOutOfRangeException($"{nameof(row)}: value: {row}, range: [0-{Rows - 1}]");

            if (column < 0 || column > Columns - 1)
                throw new IndexOutOfRangeException($"{nameof(column)}: value: {column}, range: [0-{Columns - 1}]");

            return states[row, column];
        }
    }

    public int[] AsVector() => states.Cast<int>().ToArray();

    public override string ToString()
    {
        StringBuilder sb = new();
        sb.AppendLine(GetColumnHeaderLine());
        string separatorLine = GetRowSeparatorLine();

        for (int r = 0; r < Rows; r++)
        {
            for (int c = 0; c < Columns; c++)
            {
                if (c == 0)
                {
                    sb.Append(FixString($"R{r + 1}", RowLeaderWidth));
                    sb.Append(" ");
                }

                sb.Append(states[r, c] switch
                {
                    State.Empty => Empty,
                    State.Nought => Nought,
                    State.Cross => Cross,
                    _ => throw new NotSupportedException()
                });

                if (c < Columns - 1)
                    sb.Append(VerticalSeparator);
            }
            sb.AppendLine();

            if (r < Rows - 1)
                sb.AppendLine(separatorLine);
        }
        return sb.ToString();
    }

    private string GetRowLeaderSpacer() => new string(' ', RowLeaderWidth + 1);

    private string GetRowSeparatorLine() =>
        GetRowLeaderSpacer()
        + string.Join(
            CrossPiece,
            Enumerable.Repeat(HorizontalSeparator, Columns)
            );

    private string GetColumnHeaderLine() =>
        GetRowLeaderSpacer()
        + string.Join(
            HeaderSeparator,
            Enumerable.Range(0, Columns).Select(
                c => FixString($"C{c + 1}", GetColumnCharWidth()
                )));

    private int GetColumnCharWidth() =>
        HorizontalSeparator.Sum(c => StringInfo.GetNextTextElementLength(c.ToString()));

    private string FixString(string s, int length) =>
        string.Concat(s, new string(' ', length)).Substring(0, length);

    private const int RowLeaderWidth = 2;

    private const string
        HorizontalSeparator = "━━",
        VerticalSeparator = "┃",
        HeaderSeparator = " ",
        CrossPiece = "╋",
        Nought = "⭕",
        Cross = "❌",
        Empty = "  ";

    private State[,] states = new State[Rows, Columns];
}