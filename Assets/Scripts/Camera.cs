
using UnityEngine;
[System.Serializable]

public class Camera : MonoBehaviour
{

    public Transform target;
    public float positionSpeed = 5.0f;

    void FixedUpdate()
    {

        transform.position = Vector3.Lerp(transform.position, target.position, Time.deltaTime * positionSpeed);

    }
}