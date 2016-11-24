using UnityEngine;
using System.Collections;

public class DeathBlock : MonoBehaviour {


    void OnTriggerEnter(Collider collider)
    {
        Player player = collider.GetComponent<Player>();
        if(player)
        {
            player.Death();
        }
    }
}
