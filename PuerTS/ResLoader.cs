using Puerts;
using Puerts.ThirdParty;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

/*
    修改自 https://github.com/Tencent/puerts/blob/f1088993639c353e9d2a0fb8d792592aa8bd1538/unity/test/dotnet/Src/TxtLoader.cs
 */
public class ResLoader : IResolvableLoader, ILoader, IModuleChecker
{
    public static string PathToBinDir(string appendix)
    {
        return Path.Combine(
            System.Text.RegularExpressions.Regex.Replace(
                Path.GetDirectoryName(Assembly.GetExecutingAssembly().GetName().CodeBase), "^file:(\\\\)?", ""
            ),
            appendix
        );
    }
    private string root = PathToBinDir("upm/Runtime/Resources");
    private string commonjsRoot = PathToBinDir("upm/Runtime/Resources/");
    private string editorRoot = PathToBinDir("upm/Editor/Resources");
    private string scriptsRoot = PathToBinDir("Scripts");

    public bool IsESM(string filepath)
    {
        return !filepath.EndsWith(".cjs");
    }

    public bool FileExists(string specifier)
    {
        if (nullFiles.Contains(specifier))
        {
            Console.WriteLine("FileExists return null for " + specifier);
            return true;
        }
        var res = !System.String.IsNullOrEmpty(Resolve(specifier, "."));
        return res;
    }

    private string TryResolve(string specifier)
    {
        string path = Path.Combine(root, specifier);
        if (System.IO.File.Exists(path))
        {
            return path.Replace("\\", "/");
        }
        path = Path.Combine(commonjsRoot, specifier);
        if (System.IO.File.Exists(path))
        {
            return path.Replace("\\", "/");
        }
        path = Path.Combine(editorRoot, specifier);
        if (System.IO.File.Exists(path))
        {
            return path.Replace("\\", "/");
        }

        path = Path.Combine(scriptsRoot, specifier);
        if (System.IO.File.Exists(path))
        {
            return path.Replace("\\", "/");
        }

        else if (mockFileContent.ContainsKey(specifier))
        {
            return specifier;
        }
        return null;
    }

    public string Resolve(string specifier, string referrer)
    {
        if (nullFiles.Contains(specifier))
        {
            return specifier;
        }
        if (PathHelper.IsRelative(specifier))
        {
            specifier = PathHelper.normalize(PathHelper.Dirname(referrer) + "/" + specifier);
        }

        var specifier1 = TryResolve(specifier);
        if (specifier1 == null) specifier1 = TryResolve(specifier + ".txt");
        if (specifier1 == null) specifier1 = TryResolve(specifier + "/index.js.txt");
        if (specifier1 != null) return specifier1;
        return null;
    }

    public string ReadFile(string filepath, out string debugpath)
    {
        if (nullFiles.Contains(filepath))
        {
            debugpath = string.Empty;
            return null;
        }
        debugpath = Path.Combine(root, filepath);
        if (File.Exists(Path.Combine(editorRoot, filepath)))
        {
            debugpath = Path.Combine(editorRoot, filepath);
        }
        if (File.Exists(Path.Combine(scriptsRoot, filepath)))
        {
            debugpath = Path.Combine(scriptsRoot, filepath);
        }

        string mockContent;
        if (mockFileContent.TryGetValue(filepath, out mockContent))
        {
            return mockContent;
        }

        using (StreamReader reader = new StreamReader(debugpath))
        {
            return reader.ReadToEnd();
        }
    }

    private Dictionary<string, string> mockFileContent = new Dictionary<string, string>();
    public void AddMockFileContent(string fileName, string content)
    {
        mockFileContent.Add(fileName, content);
    }

    private HashSet<string> nullFiles = new HashSet<string>();
    public void AddNullFile(string fileName)
    {
        nullFiles.Add(fileName);
    }
}

namespace UnityEngine.Scripting
{
    class PreserveAttribute : System.Attribute
    {

    }
}
