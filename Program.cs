namespace MLExperiments;

internal class Program
{
    private static void Main(string[] args)
    {
        GameBoard board = new();

        Console.WriteLine(board.ToString());
    }
}


// using Microsoft.ML;

// MLContext ctx = new(seed: 0);

// var data = ctx.Data.LoadFromTextFile<InputData>(
//     "Starbucks Dataset.csv",
//     hasHeader: true,
//     separatorChar: ','
// );

// var trainTestData = ctx.Data.TrainTestSplit(data, testFraction: 0.2, seed: 0);
// var trainData = trainTestData.TrainSet;
// var testData = trainTestData.TestSet;

// var pipeline =
//     ctx.Transforms.NormalizeMinMax(nameof(InputData.AdjClose))
//     .Append(ctx.Transforms.NormalizeMinMax(nameof(InputData.Close)))
//     .Append(ctx.Transforms.NormalizeMinMax(nameof(InputData.High)))
//     .Append(ctx.Transforms.NormalizeMinMax(nameof(InputData.Low)))
//     .Append(ctx.Transforms.NormalizeMinMax(nameof(InputData.Volume)))
//     //.Append(ctx.Transforms.Concatenate("Features", Close, High etc))
//     .Append(ctx.Regression.Trainers.OnlineGradientDescent())
//     ;

// var model = pipeline.Fit(data);

// 0s and crosses:
/*

    Input array [0-2] blank, noughts, crosses
    [n, ..9] each cell in the array
    Output label [0-9] which cell to place a mark on

    Train it with a perfect algorithm that follows best practices

    Part-train it to get different levels of difficulty

    Is this sane? Worth doing? How big is a perfect data set?

    for every cell 9, for every state 3, number of possible states equals...

    just 9 * 3 I think..., oh it's logarithmic because the combined possibilities,
    god so since the players take turns there are no asymmetric combinations, so rule those out

    Someone scripted it for us:
    https://www.reddit.com/r/explainlikeimfive/comments/15rlp9e/eli5_how_many_total_combinations_are_there_in_tic/
    Total board positions: 19683
    Positions reachable in game: 8533

    8533, think that's okay as a training set. 1000 for easy mode, 3000 for medium and 6000 for hard..
    tweak as necesarry. not a massive data set and god knows if an RNN can work with predictions
    in this space. let's try.

    So let's pause to write an algorithm that can play tic-tac-toe with you on the console
    Then we'll feed its CPU-play predictions into ML.net and see if we can play the neural net instead

*/

