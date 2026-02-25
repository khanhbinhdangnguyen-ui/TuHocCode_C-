using TuHocCode.Core.Models;
using TuHocCode.Core.Utils;

namespace TuHocCode.Repositories
{
    public class ExerciseRepository
    {
        public ExerciseCollection LoadAll()
        {
            return JsonLoader.LoadFromFile<ExerciseCollection>(PathHelper.ExercisesPath);
        }
    }
}
