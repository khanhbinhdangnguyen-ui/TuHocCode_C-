using System;

namespace TuHocCode.Core.Models
{
    [Serializable]
    public class SynonymCollection
    {
        public SynonymEntry[] entries;
    }

    [Serializable]
    public class SynonymEntry
    {
        public string key;
        public string[] values;
    }

    public class ChatAnswer
    {
        public string title;
        public string summary;
        public string codeExample;
        public string[] relatedCommands;
    }
}
