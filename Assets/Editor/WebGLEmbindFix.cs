using UnityEditor;
using UnityEditor.Build;
using UnityEditor.Build.Reporting;

public class WebGLEmbindFix : IPreprocessBuildWithReport
{
    public int callbackOrder => 0;

    public void OnPreprocessBuild(BuildReport report)
    {
        if (report.summary.platform == BuildTarget.WebGL)
        {
            string currentArgs = PlayerSettings.WebGL.emscriptenArgs;
            if (!currentArgs.Contains("--bind"))
            {
                PlayerSettings.WebGL.emscriptenArgs = (currentArgs + " --bind").Trim();
            }
        }
    }
}