using System.Collections;
using System.IO;
using System.Collections.Generic;
using UnityEngine;

public static class SaveMachine
{
    public static void SaveByJson(string fileName,object data)
    {
        var json = JsonUtility.ToJson(data,true);
        var path = Path.Combine(Application.persistentDataPath, fileName);
        try
        {
            Debug.Log(json);
            File.WriteAllText(path, json);

        
        }catch(System.Exception exception)
        {
            Debug.LogError($"failed to save{path}.\n{exception}");
        }
    }
    public static T LoadFormJson<T>(string fileName)
    {
        var path = Path.Combine(Application.persistentDataPath, fileName);
        try
        {
            var json = File.ReadAllText(path);
            var data = JsonUtility.FromJson<T>(json);
            return data;
        }
        catch (System.Exception e)
        {
            Debug.LogError($"file to loao.{path},\n{e}");
            return default;
        }
    }
}
