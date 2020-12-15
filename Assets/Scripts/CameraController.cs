using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform targetToFollow;

    void Update()
    {
        var position = targetToFollow.position;
        transform.position = new Vector2(
            Mathf.Clamp(position.x, -0.98f, 60.65f),
            Mathf.Clamp(position.y, 0f, 0f)
        );
    }
}
