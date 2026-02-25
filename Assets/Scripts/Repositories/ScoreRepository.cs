using System.IO;
using TuHocCode.Core.Models;
using TuHocCode.Core.Utils;
using UnityEngine;

namespace TuHocCode.Repositories
{
    public class ScoreRepository
    {
        public ScoreData Load()
        {
            if (!File.Exists(PathHelper.ScorePath))
            {
                return new ScoreData { username = "User", completed_exercises = new CompletedExercise[0], total_score = 0 };
            }

            return JsonLoader.LoadFromFile<ScoreData>(PathHelper.ScorePath);
        }

        public void Save(ScoreData data)
        {
            var json = JsonUtility.ToJson(data, true);
            File.WriteAllText(PathHelper.ScorePath, json);
        }
    }
}
