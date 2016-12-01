using UnityEngine;
using System.Collections;

public class DeathBlock : MonoBehaviour {

    /*
    Excel Level Assignment - Die.

    Josh Bellyk - 100526009
    Owen Meier  - 100538643    
    */

    void OnTriggerEnter(Collider collider)
    {
        Player player = collider.GetComponent<Player>();
        if(player)
        {
            player.Death();
        }
    }
}
