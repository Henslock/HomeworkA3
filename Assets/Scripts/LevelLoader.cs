using UnityEngine;
using System.Collections;
using System.Text;
using System.IO;

public class LevelLoader : MonoBehaviour {

    public TextAsset Levelcsv;
    public GameObject[] blocks;
    private GameObject go;
    private int xOffset, yOffset = 0;

	void Awake()
    {
        ReadLevel();
    }

    void ReadLevel()
    {
        string[] lines = Levelcsv.text.Split("\n"[0]);

        for (var i = 0; i < lines.Length; ++i)
        {
            string[] parts = lines[i].Split(","[0]);
            for (var x = 0; x < parts.Length; ++x)
            {

                switch (parts[x])
                {
                    case "0":
                        //Basic Block
                        go = Instantiate(blocks[0]);
                        go.transform.position = new Vector3(xOffset, yOffset, 0);
                        break;
                    case "1":
                        //Spawn Point
                        blocks[1].transform.position = new Vector3(xOffset, yOffset, 0);
                        break;
                    case "2":
                        //Super Bounce Block
                        go = Instantiate(blocks[2]);
                        go.transform.position = new Vector3(xOffset, yOffset, 0);
                        break;
                    case "3":
                        //Checkpoint
                        go = Instantiate(blocks[3]);
                        go.transform.position = new Vector3(xOffset, yOffset, 0);
                        break;
                    case "4":
                        //Death Block
                        go = Instantiate(blocks[4]);
                        go.transform.position = new Vector3(xOffset, yOffset, 0);
                        break;
                    case "5":
                        //Bounce Block
                        go = Instantiate(blocks[5]);
                        go.transform.position = new Vector3(xOffset, yOffset, 0);
                        break;
                    case "6":
                        //Light Source
                        go = Instantiate(blocks[6]);
                        go.transform.position = new Vector3(xOffset, yOffset, -1);
                        break;
                    case "7":
                        //Enemy
                        go = Instantiate(blocks[7]);
                        go.transform.position = new Vector3(xOffset, yOffset, 0);
                        break;
                    case "8":
                        //End Goal
                        go = Instantiate(blocks[8]);
                        go.transform.position = new Vector3(xOffset, yOffset, 0);
                        break;
                }
                xOffset++;
            }
            xOffset = 0;
            yOffset--;
        }
    }
}
