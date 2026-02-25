using System;
using System.Collections.Generic;
using System.Linq;
using TuHocCode.Core.Models;
using TuHocCode.Repositories;

namespace TuHocCode.Services
{
    public class ScoreService
    {
        private readonly ScoreRepository _repository = new ScoreRepository();

        public ScoreData Load()
        {
            return _repository.Load();
        }

        public void SaveExerciseResult(string exerciseId, int score, int passed, int total)
        {
            var data = _repository.Load();
            var items = (data.completed_exercises ?? Array.Empty<CompletedExercise>()).ToList();

            var existing = items.FirstOrDefault(x => x.exercise_id == exerciseId);
            if (existing == null)
            {
                existing = new CompletedExercise { exercise_id = exerciseId };
                items.Add(existing);
            }

            existing.score = score;
            existing.passed_testcases = passed;
            existing.total_testcases = total;
            existing.last_attempt = DateTime.UtcNow.ToString("o");

            data.completed_exercises = items.ToArray();
            data.total_score = CalculateTotalScore(items);
            _repository.Save(data);
        }

        private static int CalculateTotalScore(List<CompletedExercise> items)
        {
            if (items.Count == 0)
            {
                return 0;
            }

            var average = items.Average(x => x.score);
            return Math.Clamp((int)Math.Round(average), 0, 100);
        }
    }
}
