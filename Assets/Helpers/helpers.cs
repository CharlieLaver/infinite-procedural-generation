using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

class helpers : MonoBehaviour {

    public static string[] filterMetaFiles(string[] files) {
        List<string> filteredFiles = new List<string>();
        for(int i = 0; i < files.Length; i++) {
            if(Path.GetExtension(files[i]) != ".meta") {
                filteredFiles.Add(files[i]);
            }
        }
        return filteredFiles.ToArray();        
    }

}