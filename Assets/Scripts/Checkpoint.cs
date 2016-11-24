using UnityEngine;
using System.Collections;

public class Checkpoint : MonoBehaviour
{
    private float speed = 100.0f;
    private bool active, flashyspinning = false;

    private float t = 0.0f;
    private Vector3 rotation;
    void Update()
    {
        if (!active && !flashyspinning)
        {
            transform.Rotate(Vector3.up * Time.deltaTime * speed / 3);
        }
        
        if(active && !flashyspinning)
        {
            transform.Rotate(Vector3.up * Time.deltaTime * speed);
        }

        if(flashyspinning)
        {
            SpinToWin();
        }
    }

    void OnTriggerEnter(Collider collider)
    {
        Player player = collider.GetComponent<Player>();
        if (player)
        {
            //print("Checkpoint!");
            player.CheckpointCoords = transform.position;
            player.activeCheckpoint = true;
            active = true;
            flashyspinning = true;
            transform.localScale = new Vector3(1.1f, 1.1f, 1.1f);

            SpinToWin();
        }
    }

    void SpinToWin()
    {
        rotation = Vector3.Lerp(Vector3.up * Time.deltaTime * speed * 8, Vector3.up * Time.deltaTime * speed * 1, t);

        transform.Rotate(rotation);
        t += Time.deltaTime;
        if(t >= 2.0f)
        {
            flashyspinning = false;
        }
    }
}
