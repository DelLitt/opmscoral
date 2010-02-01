using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using NMG.Core.Reader;

namespace NMG.Core
{
    public class GlobalCache
    {
        private static GlobalCache instance = null;
        public IMetadataReader MetaDataReader { get; set;}
        public Dictionary<string, string> ReplaceWords { get; set; }    
        public static GlobalCache Instance
        {
            get
            {
                if(instance== null) instance = new GlobalCache();
                instance.Read();
                return instance;
            }
        }

        private void Read()
        {
            ReplaceWords = new Dictionary<string, string>();
            System.Reflection.Assembly a = System.Reflection.Assembly.GetEntryAssembly();
            string baseDir = System.IO.Path.GetDirectoryName(a.Location);
            string replaceWordsPath = baseDir + "\\" + "ReplaceWords.txt";
            ReadFileToList(ReplaceWords, replaceWordsPath);
        }

        private void ReadFileToList(Dictionary<string, string> dictionary, string replaceWordsPath)
        {
            StreamReader stream = new StreamReader(File.OpenRead(replaceWordsPath));

            while (!stream.EndOfStream)
            {
                string line = stream.ReadLine();
                string[] lines = line.Split('=');
                
                if (!dictionary.ContainsKey(lines[0]))
                {
                    if (lines.Length != 2)
                    {
                        dictionary.Add(lines[0], "");
                        continue;
                    }
                    dictionary.Add(lines[0], lines[1]);
                }
            }
        }

        public List<ApplicationPreferences> TablePreferences { get; set; }

        public void Clear()
        {
            TablePreferences = null;
            MetaDataReader = null;
        }
        public string ReplaceShortWords(string source)
        {
            foreach (var word in ReplaceWords.Keys)
            {
                source = source.Replace(word, ReplaceWords[word]);
            }
            return source;
        }
        
    }
}