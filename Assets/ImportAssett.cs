using System.IO;
using UnityEditor;
using UnityEngine;
using System;
using System.Threading;

public class ImportAssett : MonoBehaviour
{
    // [MenuItem("APIExamples/ImportAsset")]
    private int nextUpdate=1;
    void ImportAssetOnlyImportsSingleAsset()
    {
        // string[] fileNames = new[] { "test_file01.txt", "test_file02.txt" };
        //
        // for (int i = 0; i < fileNames.Length; ++i)
        // {
        //     var unimportedFileName = fileNames[i];
        //     var assetsPath = Application.dataPath + "/Artifacts/" + unimportedFileName;
        //     File.WriteAllText(assetsPath, "Testing 123");
        // }
        // for (int i = 0; i < 3; i++)
        // {
        //     // Console.Log("Sleep for 5 seconds.");
        //     Debug.Log("Sleep for 5 seconds.");
        //     // Thread.Sleep(5000);
        //
        // }
        var relativePath = "Assets/ply-common/3.ply";
        AssetDatabase.ImportAsset(relativePath);
    }

    void Update()
    {
        // // ImportAssetOnlyImportsSingleAsset();
        // for (int i = 0; i < 3; i++)
        // {
        //     // Console.Log("Sleep for 5 seconds.");
        //     Debug.Log("Sleep for 5 seconds.");
        //     Thread.Sleep(5000);
        //     // var relativePath = "Assets/ply-common/3.ply";
        //     // AssetDatabase.ImportAsset(relativePath);
        // }
        if(Time.time>=nextUpdate){
            Debug.Log(Time.time+">="+nextUpdate);
            // Change the next update (current second+1)
            nextUpdate=Mathf.FloorToInt(Time.time)+1;
            // Call your fonction
            ImportAssetOnlyImportsSingleAsset();
        }
    }
}
