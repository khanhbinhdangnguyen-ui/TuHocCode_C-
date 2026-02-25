using System;

namespace TuHocCode.Core.Models
{
    [Serializable]
    public class ExerciseCollection
    {
        public string version;
        public ExerciseItem[] exercises;
    }

    [Serializable]
    public class ExerciseItem
    {
        public string id;
        public string title;
        public int difficulty;
        public string description;
        public string input_format;
        public string output_format;
        public int time_limit_ms;
        public int memory_limit_mb;
        public TestCase[] testcases;
        public string hint;
    }

    [Serializable]
    public class TestCase
    {
        public string input;
        public string expected_output;
    }
}
