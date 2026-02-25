using System;
using System.IO;
using UnityEngine;

namespace TuHocCode.Core.Utils
{
    public static class JsonLoader
    {
        public static T LoadFromFile<T>(string absolutePath)
        {
            if (!File.Exists(absolutePath))
            {
                throw new FileNotFoundException($"File not found: {absolutePath}");
            }

            var json = File.ReadAllText(absolutePath);
            return JsonUtility.FromJson<T>(json);
        }

        public static bool TryLoadFromFile<T>(string absolutePath, out T value) where T : class
        {
            value = null;
            try
            {
                value = LoadFromFile<T>(absolutePath);
                return value != null;
            }
            catch (Exception ex)
            {
                Debug.LogWarning($"JSON load failed: {absolutePath}. {ex.Message}");
                return false;
            }
        }
    }
}
