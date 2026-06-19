using System.IO;
using Autocorrect;

const string DICTIONARY_PATH = "D:/Projects/Autocorrect/dictionary.txt";

WordDictionary dictionary = new WordDictionary(DICTIONARY_PATH);

dictionary.PrecomputeWordLengthFrequency();

var words = Corrector.ClosestWords("rin",ref dictionary);

foreach (var word in words)
{
    Console.WriteLine(word);
}
