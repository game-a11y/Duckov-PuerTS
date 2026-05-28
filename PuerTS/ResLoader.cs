using Puerts;
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
        var dir = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        if (string.IsNullOrEmpty(dir))
        {
            dir = System.Text.RegularExpressions.Regex.Replace(
                Path.GetDirectoryName(Assembly.GetExecutingAssembly().GetName().CodeBase) ?? "",
                "^file:(\\\\)?", ""
            );
        }
        return Path.Combine(dir ?? ".", appendix);
    }
    private string root = PathToBinDir("upm/Runtime/Resources");
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

    private string? TryResolve(string specifier)
    {
        string path = Path.Combine(root, specifier);
        if (File.Exists(path))
        {
            return path.Replace("\\", "/");
        }
        path = Path.Combine(editorRoot, specifier);
        if (File.Exists(path))
        {
            return path.Replace("\\", "/");
        }

        path = Path.Combine(scriptsRoot, specifier);
        if (File.Exists(path))
        {
            return path.Replace("\\", "/");
        }

        if (mockFileContent.ContainsKey(specifier))
        {
            return specifier;
        }
        return null;
    }

    public string? Resolve(string specifier, string referrer)
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

    public string? ReadFile(string filepath, out string debugpath)
    {
        if (nullFiles.Contains(filepath))
        {
            debugpath = string.Empty;
            return null;
        }

        string mockContent;
        if (mockFileContent.TryGetValue(filepath, out mockContent))
        {
            debugpath = filepath;
            return mockContent;
        }

        var resolved = TryResolve(filepath);
        if (resolved != null)
        {
            debugpath = resolved;
        }
        else
        {
            debugpath = Path.Combine(root, filepath);
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
