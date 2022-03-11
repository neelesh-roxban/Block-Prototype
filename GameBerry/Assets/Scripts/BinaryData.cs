using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;

public class BinaryData
{

    public static void Save<T>(T serilizedObject, string fileName)
    {
        string path = Application.persistentDataPath + "/SaveFile/";
        Directory.CreateDirectory(path);


        BinaryFormatter formater = new BinaryFormatter();
        FileStream fileStreme = new FileStream(path+fileName+ ".dat", FileMode.Create);

        try
        {
            formater.Serialize(fileStreme, serilizedObject);
        }
        catch (SerializationException e)
        {
            Debug.Log("Save Failed" + e.Message);           
         
        }

        finally
        {
            fileStreme.Close();

        }
    }

    public static bool Exists(string fileName)
    {
        string path=Application.persistentDataPath + "/SaveFile/";
        string fullFileName = fileName+ ".dat";
        return File.Exists(path + fullFileName);
    }

    public static T Read<T>(string fileName)
    {
        string path=Application.persistentDataPath + "/SaveFile/";
         BinaryFormatter formater = new BinaryFormatter();
         FileStream fileStreme = new FileStream(path+fileName+ ".dat", FileMode.Open);
         
         T returnType = default(T);

        try
        {
            returnType = (T)formater.Deserialize(fileStreme);
        }
        catch (SerializationException e)
        {
            Debug.Log("Read Failed" + e.Message);           
         
        }

        finally
        {
            fileStreme.Close();

        }

        return returnType;


    }
    
}
