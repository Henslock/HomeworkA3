using UnityEngine;
using System.Collections;

public class Goal : MonoBehaviour {

    void OnTriggerEnter(Collider collider)
    {
        Player player = collider.GetComponent<Player>();
        if (player)
        {
            player.CheckpointCoords = player.SpawnPos.transform.position;
            player.Death();
        }
    }
}
