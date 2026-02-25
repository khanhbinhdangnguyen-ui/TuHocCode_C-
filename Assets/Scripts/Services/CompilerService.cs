using System;
using System.Diagnostics;
using System.IO;
using System.Text;
using UnityEngine;

namespace TuHocCode.Services
{
    public class CompilerService
    {
        public (bool success, string output) Compile(string gppPath, string sourceFile, string outputExe, int timeoutMs = 5000)
        {
            if (!File.Exists(gppPath))
            {
                return (false, $"Không tìm thấy compiler: {gppPath}");
            }

            var psi = new ProcessStartInfo
            {
                FileName = gppPath,
                Arguments = $"\"{sourceFile}\" -o \"{outputExe}\"",
                RedirectStandardError = true,
                RedirectStandardOutput = true,
                UseShellExecute = false,
                CreateNoWindow = true,
                StandardOutputEncoding = Encoding.UTF8,
                StandardErrorEncoding = Encoding.UTF8
            };

            using var process = new Process { StartInfo = psi };
            process.Start();

            if (!process.WaitForExit(timeoutMs))
            {
                try { process.Kill(true); } catch (Exception ex) { Debug.LogWarning(ex.Message); }
                return (false, "Compile timeout");
            }

            var stdOut = process.StandardOutput.ReadToEnd();
            var stdErr = process.StandardError.ReadToEnd();
            var combined = string.Join("\n", new[] { stdOut, stdErr }).Trim();
            return (process.ExitCode == 0, combined);
        }
    }
}
