using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 30f;
    [SerializeField] private int coinValue = 10;
    [SerializeField] private float rotationSpeed = 5f;
    private GameManager gameManager;
    private bool collected = false;

    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    void Update()
    {
        // Move coin towards player
        transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime, Space.World);
        
        // Rotate coin
        transform.Rotate(Vector3.up * rotationSpeed * 50f * Time.deltaTime);
    }

    void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("Player") && !collected)
        {
            collected = true;
            gameManager.AddCoins(coinValue);
            Destroy(gameObject);
        }
    }
}
