using UnityEngine;

public class Camera_Follow : MonoBehaviour
{
    [SerializeField] private Transform Camera_Target;

    [SerializeField] private Vector3 Offset;

    [SerializeField] [Range(0.01f, 1f)] private float Smooth_Speed = 0.125f;

    private Vector3 Velocity = Vector3.zero;

    private void LateUpdate()
    {
        Vector3 Desired_Position = Camera_Target.position + Offset;
        transform.position = Vector3.SmoothDamp(transform.position, Desired_Position, ref Velocity, Smooth_Speed);
    }

}
