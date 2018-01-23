using UnityEngine;

public class CameraFollow : MonoBehaviour {
    public Transform target;
    public float speed =.125f;
    public Vector3 offset;

    void FixedUpdate()
    {
        Vector3 desiredPos = target.position + offset;
        Vector3 smoothPos = Vector3.Lerp(transform.position, desiredPos, speed);
        transform.position = smoothPos;
        transform.LookAt(target);
    }
}
