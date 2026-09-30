using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform playerTransform;
    [SerializeField] private Vector3 offset = new Vector3(0, 5, -10);
    [SerializeField] private float smoothSpeed = 5f;

    void Start()
    {
        if (playerTransform == null)
        {
            playerTransform = FindObjectOfType<PlayerController>().transform;
        }
    }

    void LateUpdate()
    {
        if (playerTransform == null) return;

        Vector3 desiredPosition = playerTransform.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, Time.deltaTime * smoothSpeed);
        transform.position = smoothedPosition;

        // Look at player
        transform.LookAt(playerTransform.position + Vector3.up * 2);
    }
}
