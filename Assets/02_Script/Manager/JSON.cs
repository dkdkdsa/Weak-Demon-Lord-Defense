using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;

public static class JSON
{
    public static void WriteObject(string path, object obj)
    {

        var text = JsonUtility.ToJson(obj);

        try
        {
            File.WriteAllText(path, text);

#if UNITY_EDITOR

            AssetDatabase.Refresh();

#endif

        }
        catch (System.Exception e)
        {

            throw e;

        }


    }

    public static void WriteText(string path, string text)
    {

        File.WriteAllText(path, text);

    }

    public static string ReadJson(string path)
    {

        return File.ReadAllText(path);

    }

    public static T ReadJson<T>(string path)
    {

        var str = ReadJson(path);

        return JsonUtility.FromJson<T>(str);

    }

}
