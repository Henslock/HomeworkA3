using UnityEngine;
using UnityEditor;

public class LoadLevel_Editor : EditorWindow
{
    /*
    Excel Level Assignment - This script reads the CSV file and places collision blocks ONLY so that we can generate a NavMesh.

    Josh Bellyk - 100526009
    Owen Meier  - 100538643    
    */
    string levelFileName = "File Name...";
    int xOffset, yOffset = 0;
    TextAsset navLevel;

    [MenuItem("Window/Level Options/Generate Navmesh Level")]
    public static void ShowWindow()
    {
        LoadLevel_Editor window = GetWindow<LoadLevel_Editor>();
        window.titleContent.text = "Generate Level Options";
    }

    void OnGUI()
    {

        levelFileName = GUILayout.TextField(levelFileName);

        if (GUILayout.Button("Spawn Navigation Prefabs"))
        {
            navLevel = Resources.Load(levelFileName) as TextAsset;

            GameObject navParent = new GameObject("Navmesh Blocks");

            string[] lines = navLevel.text.Split("\n"[0]);

            for (var i = 0; i < lines.Length; ++i)
            {
                string[] parts = lines[i].Split(","[0]);
                for (var x = 0; x < parts.Length; ++x)
                {
                    if (parts[x] == "0" || parts[x] == "2" || parts[x] == "5")
                    {
                        Object navBlock = AssetDatabase.LoadAssetAtPath("Assets/Prefabs/BasicBlock.prefab", typeof(GameObject));
                        GameObject go = Instantiate(navBlock) as GameObject;
                        go.transform.position = new Vector3(xOffset, yOffset, 0);
                        go.transform.parent = navParent.transform;
                    }
                    xOffset++;
                }
                xOffset = 0;
                yOffset--;

                Debug.Log("Finish Building Navigation Blocks");
            }
        }
    }
}
