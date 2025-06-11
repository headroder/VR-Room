using UnityEngine;

public class AlignCanvasToCamera : MonoBehaviour
{
    void Start()
    {
        Transform cam = Camera.main.transform;
        Vector3 forward = cam.forward;
        forward.y = 0;

        transform.position = cam.position + forward.normalized * 2f;
        transform.LookAt(cam.position);
        transform.Rotate(0, 180, 0);
    }
}
