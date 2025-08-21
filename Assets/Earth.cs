using UnityEngine;

public class Orbit : MonoBehaviour
{
    [SerializeField] private Transform target; // The object to rotate around
    [SerializeField] private float rotationSpeed = 45f; // Rotation speed in degrees per second

    void Update()
    {
        if (target != null)
        {
            // Rotate the object around the target's position on the Y-axis
            transform.RotateAround(target.position, Vector3.up, rotationSpeed * Time.deltaTime);
        }
    }
}