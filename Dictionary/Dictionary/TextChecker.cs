using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Dictionary
{
    class TextChecker
    {
        private String[] allWords;
        public ConcurrentDictionary<string, long> WordCount { get; }
        int WORD_COUNTER;
        public TextChecker()
        {
            allWords = File.ReadAllLines("C:/Users/Kamil/source/repos/Dictionary/Dictionary/Resources/allwords.txt");
            WordCount = new ConcurrentDictionary<string, long>();
        }

        public List<String> CheckText(String[] words, IProgress<int> progress)
        {
            WordCount.Clear();
            WORD_COUNTER = 0;
            List<String> errorList = new List<string>();
            Parallel.ForEach<String>(words, (currString) =>
             {
                 if (allWords.Contains(currString))
                 {
                     WordCount.AddOrUpdate(currString, 1, (key, oldValue) => oldValue + 1);
                 }
                 else errorList.Add(currString);

                 if (progress != null)
                 {
                     Interlocked.Increment(ref WORD_COUNTER);
                     progress.Report(WORD_COUNTER/words.Length*100);
                     
                 }
             });
            
            return errorList;
        }
        
    }
}
