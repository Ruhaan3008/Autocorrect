namespace Autocorrect;

public class WordDictionary
{

    private string[] words;

    public string[] Words
    {
        get => words;
        private set => words = value;
    }

    private int[] wordLengthFrequency;
    
    private int maxWordLength;

    public int MaxWordLength
    {
        get => maxWordLength;
        private set => maxWordLength = value;
    }
    
    
    public WordDictionary(string path)
    {
        words = File.ReadAllLines(path);
        wordLengthFrequency = new int[0];
        maxWordLength = 0;
    }

    public void PrecomputeWordLengthFrequency()
    {
        int largestWordLength = 0;
        foreach (string word in words)
        {
            int wordLength = word.Length;
            if (wordLength > largestWordLength)
            {
                largestWordLength = wordLength;
            }
        }
        
        maxWordLength = largestWordLength;
        
        wordLengthFrequency = new int[largestWordLength];
        Array.Fill(wordLengthFrequency, 0);
        
        foreach (var word in words)
        {
            int wordLength = word.Length;
            wordLengthFrequency[wordLength - 1] += 1;
        }
    }
    
    public int WordLengthFrequency(int length) => wordLengthFrequency[length - 1];
}