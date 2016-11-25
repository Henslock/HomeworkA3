using UnityEngine;
using System.Collections;
using System.Text;
using System.IO;

public class LevelLoader : MonoBehaviour {

    public string FileName = "LevelFile";
    private TextAsset Levelcsv;
    public GameObject[] blocks;
    private GameObject go, levelBlocks;
    private int xOffset, yOffset = 0;

	void Awake()
    {
        Levelcsv = Resources.Load("LevelFile") as TextAsset;
        levelBlocks = new GameObject("LevelBlocks");
        ReadLevel(FileName);
    }

    public void ReadLevel(string file)
    {
        Levelcsv = Resources.Load(file) as TextAsset;
        string[] lines = Levelcsv.text.Split("\n"[0]);

        for (var i = 0; i < lines.Length; ++i)
        {
            string[] parts = lines[i].Split(","[0]);
            for (var x = 0; x < parts.Length; ++x)
            {
                //Spaghetti
                switch (parts[x])
                {
                    case "0":
                        //Basic Block
                        go = Instantiate(blocks[0]);
                        go.transform.position = new Vector3(xOffset, yOffset, 0);
                        go.transform.parent = levelBlocks.transform;
                        break;
                    case "1":
                        //Spawn Point
                        blocks[1].transform.position = new Vector3(xOffset, yOffset, 0);
                        go.transform.parent = levelBlocks.transform;
                        break;
                    case "2":
                        //Super Bounce Block
                        go = Instantiate(blocks[2]);
                        go.transform.position = new Vector3(xOffset, yOffset, 0);
                        go.transform.parent = levelBlocks.transform;
                        break;
                    case "3":
                        //Checkpoint
                        go = Instantiate(blocks[3]);
                        go.transform.position = new Vector3(xOffset, yOffset, 0);
                        go.transform.parent = levelBlocks.transform;
                        break;
                    case "4":
                        //Death Block
                        go = Instantiate(blocks[4]);
                        go.transform.position = new Vector3(xOffset, yOffset, 0);
                        go.transform.parent = levelBlocks.transform;
                        break;
                    case "5":
                        //Bounce Block
                        go = Instantiate(blocks[5]);
                        go.transform.position = new Vector3(xOffset, yOffset, 0);
                        go.transform.parent = levelBlocks.transform;
                        break;
                    case "6":
                        //Light Source
                        go = Instantiate(blocks[6]);
                        go.transform.position = new Vector3(xOffset, yOffset, -1);
                        go.transform.parent = levelBlocks.transform;
                        break;
                    case "7":
                        //Enemy
                        go = Instantiate(blocks[7]);
                        go.transform.position = new Vector3(xOffset, yOffset, 0);
                        go.transform.parent = levelBlocks.transform;
                        break;
                    case "8":
                        //End Goal
                        go = Instantiate(blocks[8]);
                        go.transform.position = new Vector3(xOffset, yOffset, 0);
                        go.transform.parent = levelBlocks.transform;
                        break;
                }
                xOffset++;
            }
            xOffset = 0;
            yOffset--;
        }
    }
}
