namespace Autocorrect;

public class Benchmark
{
    public static string[] testWords = { "add", "rin", "tust", "weehy", "bruhh" };
    const string DICTIONARY_PATH = "D:/Projects/Autocorrect/dictionary.txt";


    public static void Test()
    {
        
        WordDictionary dictionary = new WordDictionary(DICTIONARY_PATH);
        
        var watch = System.Diagnostics.Stopwatch.StartNew();
        
        foreach (var word in testWords)
        {
            Corrector.ClosestWords(word, ref dictionary);
        }
        watch.Stop();
        var elapsedMs = watch.ElapsedMilliseconds;
        
        Console.WriteLine($"Compute Time: {elapsedMs} ms");
    }
}