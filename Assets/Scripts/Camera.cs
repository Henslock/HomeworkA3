
using UnityEngine;
[System.Serializable]

public class Camera : MonoBehaviour
{
    /*
    Excel Level Assignment - Simple camera functionality for tracking the player.

    Josh Bellyk - 100526009
    Owen Meier  - 100538643    
    */
    public Transform target;
    public float positionSpeed = 5.0f;

    void FixedUpdate()
    {

        transform.position = Vector3.Lerp(transform.position, target.position, Time.deltaTime * positionSpeed);

    }
}