using UnityEngine;
using System.Collections;

public class EnemyKnight : MonoBehaviour
{
    public GameObject plr;
    private Player player;
    NavMeshAgent agent;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        plr = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        if (plr)
        {
            if (Vector3.Distance(transform.position, plr.transform.position) <= 3.0f)
            {
                player = plr.GetComponent<Player>();
                if (!player.isDead)
                {
                    transform.position = Vector3.MoveTowards(transform.position, plr.transform.position, 0.02f);
                }
            }
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        Player player = collision.collider.GetComponent<Player>();

        if (player)
        {
            player.Death();
            
        }
    }
}
