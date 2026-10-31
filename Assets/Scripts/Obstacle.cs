using UnityEngine;

public class Obstacle : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 30f;
    private PlayerController playerController;
    private GameManager gameManager;

    public float MoveSpeed
    {
        get => moveSpeed;
        set => moveSpeed = value;
    }

    void Start()
    {
        playerController = FindObjectOfType<PlayerController>();
        gameManager = FindObjectOfType<GameManager>();
    }

    void Update()
    {
        // Move obstacle towards player (simulate world movement)
        transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime, Space.World);
    }

    void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (playerController != null && playerController.IsSliding())
            {
                Destroy(gameObject);
                return;
            }

            if (gameManager != null)
            {
                gameManager.GameOver();
            }
        }
    }
}
