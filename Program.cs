using System.IO;
using Autocorrect;

const string DICTIONARY_PATH = "D:/Projects/Autocorrect/dictionary.txt";

WordDictionary dictionary = new WordDictionary(DICTIONARY_PATH);

dictionary.PrecomputeWordLengthFrequency();
