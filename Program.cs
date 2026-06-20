using System.IO;
using Autocorrect;

const string DICTIONARY_PATH = "D:/Projects/Autocorrect/dictionary.txt";

var shouldBenchmark = true;

WordDictionary dictionary = new WordDictionary(DICTIONARY_PATH);

dictionary.PrecomputeWordLengthFrequency();

if (shouldBenchmark)
{
    Benchmark.Test();
}
else
{
    Console.Write("Enter Word to Correct: ");
    string input = Console.ReadLine().ToLower();


    var watch = System.Diagnostics.Stopwatch.StartNew();
    var words = Corrector.ClosestWords(input, ref dictionary);
    watch.Stop();
    var elapsedMs = watch.ElapsedMilliseconds;

    Console.WriteLine($"Compute Time: {elapsedMs} ms");
    Console.WriteLine($"Words found: {words.Length}");
    foreach (var word in words)
    {
        Console.WriteLine(word);
    }
}