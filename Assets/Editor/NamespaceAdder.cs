using UnityEditor;
using UnityEngine;
using System.IO;

public class NamespaceAdder : EditorWindow
{
    [MenuItem("Tools/Add Namespaces")]
    static void AddNamespaces()
    {
        string basePath = Path.Combine(Application.dataPath, "Scripts");
        string namespaceRoot = "AsteroidsTest";

        var scripts = Directory.GetFiles(basePath, "*.cs", SearchOption.AllDirectories);

        foreach (var path in scripts)
        {
            string relativePath = path.Replace(basePath + Path.DirectorySeparatorChar, "");
            string folderStructure = Path.GetDirectoryName(relativePath).Replace(Path.DirectorySeparatorChar, '.');
            string fullNamespace = string.IsNullOrEmpty(folderStructure) ? namespaceRoot : $"{namespaceRoot}.{folderStructure}";

            var lines = File.ReadAllLines(path);
            if (System.Array.Exists(lines, l => l.TrimStart().StartsWith("namespace")))
                continue; // скип если уже есть namespace

            using (var writer = new StreamWriter(path))
            {
                // Пишем using'и как есть
                int i = 0;
                for (; i < lines.Length; i++)
                {
                    writer.WriteLine(lines[i]);
                    if (string.IsNullOrWhiteSpace(lines[i])) { i++; break; }
                }

                writer.WriteLine($"namespace {fullNamespace}");
                writer.WriteLine("{");

                // Остальной код с отступом
                for (; i < lines.Length; i++)
                    writer.WriteLine("    " + lines[i]);

                writer.WriteLine("}");
            }
        }

        AssetDatabase.Refresh();
        Debug.Log("Namespaces added with root: " + namespaceRoot);
    }
}