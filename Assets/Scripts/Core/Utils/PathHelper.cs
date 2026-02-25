using System.IO;
using UnityEngine;

namespace TuHocCode.Core.Utils
{
    public static class PathHelper
    {
        public static string DataRoot => Path.Combine(Application.streamingAssetsPath, "Data");
        public static string DocumentsRoot => Path.Combine(DataRoot, "Documents");
        public static string ExercisesPath => Path.Combine(DataRoot, "Exercises", "exercises.json");
        public static string ScorePath => Path.Combine(DataRoot, "Score", "score.json");
        public static string SynonymsPath => Path.Combine(DataRoot, "Synonyms", "synonyms.json");
        public static string DocumentIndexPath => Path.Combine(DocumentsRoot, "index.json");
    }
}
