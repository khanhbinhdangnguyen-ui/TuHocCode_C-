using System;

namespace TuHocCode.Core.Models
{
    [Serializable]
    public class DocumentIndexCollection
    {
        public string version;
        public DocumentIndexItem[] documents;
    }

    [Serializable]
    public class DocumentIndexItem
    {
        public string id;
        public string command;
        public string title;
        public string[] tags;
        public int difficulty;
        public string file;
    }

    [Serializable]
    public class CommandDocument
    {
        public string id;
        public string command;
        public string title;
        public CommandContent content;
        public string[] tags;
        public string[] related_commands;
    }

    [Serializable]
    public class CommandContent
    {
        public string what_it_does;
        public string origin;
        public CommandExample[] examples;
        public string[] combinations;
        public string[] notes;
        public string[] avoid_when;
        public string[] use_when;
        public Popularity popularity;
    }

    [Serializable]
    public class CommandExample
    {
        public string title;
        public string code;
        public string explanation;
    }

    [Serializable]
    public class Popularity
    {
        public int score;
        public string level;
    }
}
