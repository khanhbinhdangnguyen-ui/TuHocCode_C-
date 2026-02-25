using System;

namespace TuHocCode.Core.Models
{
    [Serializable]
    public class ScoreData
    {
        public string username;
        public CompletedExercise[] completed_exercises;
        public int total_score;
    }

    [Serializable]
    public class CompletedExercise
    {
        public string exercise_id;
        public int score;
        public int passed_testcases;
        public int total_testcases;
        public string last_attempt;
    }
}
