using UnityEngine;
using System.Collections;

public class Goal : MonoBehaviour {

    void OnTriggerEnter(Collider collider)
    {

        /*
        Excel Level Assignment - This script which "ends the game" respawns the player to the start of the level after collision.

        Josh Bellyk - 100526009
        Owen Meier  - 100538643    
        */

        Player player = collider.GetComponent<Player>();
        if (player)
        {
            player.CheckpointCoords = player.SpawnPos.transform.position;
            player.Death();
        }
    }
}
