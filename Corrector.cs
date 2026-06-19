using System;
using System.Diagnostics.CodeAnalysis;

namespace Autocorrect;

public class Corrector
{
    public static string[] ClosestWords(string word, ref WordDictionary dictionary)
    {
        int closest = int.MaxValue;

        List<string> closestWords = new List<string>();
        
        word = word.ToLower();

        foreach (string compWord in dictionary.Words)
        {
            if (compWord == word)
            {
                string[] ret = new string[1];
                ret[0] = word;
                return ret;
            }
            
            int levDist = LevenshteinDistance(compWord, word);

            if (levDist < closest)
            {
                closest = levDist;
                closestWords.Clear();
                closestWords.Add(compWord);
            }
            else if (levDist == closest)
            {
                closestWords.Add(compWord);
            }
        }
        
        
        return closestWords.ToArray();
    }

    public static int LevenshteinDistance(string word1, string word2)
    {
        if (word1.Length == 0)
        {
            return word2.Length;
        }
        else if (word2.Length == 0)
        {
            return word1.Length;
        }

        else if (head(word1) == head(word2))
        {
            return LevenshteinDistance(tail(word1), tail(word2));
        }


        return (1 + Math.Min(
            LevenshteinDistance(tail(word1), word2),
            Math.Min(
            LevenshteinDistance(word1, tail(word2)),
            LevenshteinDistance(tail(word1), tail(word2))
            )));
        
    }

    private static char head(string word)
    {
        return word.Length == 0 ? '\0' : word[0];
    }

    private static string tail(string word)
    {
        if (word.Length < 2)
        {
            return "";
        }

        string retWord = "";
        for (int i = 1; i < word.Length; i++)
        {
            retWord += word[i];
        }
        
        return retWord;
    }
}