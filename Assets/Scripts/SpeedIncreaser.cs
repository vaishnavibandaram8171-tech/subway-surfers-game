using UnityEngine;

public class SpeedIncreaser : MonoBehaviour
{
    [SerializeField] private Obstacle[] obstacles;
    [SerializeField] private Coin[] coins;
    [SerializeField] private float initialSpeed = 30f;
    [SerializeField] private float speedIncreaseRate = 0.5f;
    [SerializeField] private float maxSpeed = 60f;
    
    private float currentSpeed;
    private GameManager gameManager;

    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        currentSpeed = initialSpeed;
    }

    void Update()
    {
        if (gameManager.isGameOver) return;

        // Increase speed based on score
        float targetSpeed = initialSpeed + (gameManager.score / 100f) * speedIncreaseRate;
        currentSpeed = Mathf.Min(targetSpeed, maxSpeed);

        // Update speed for all obstacles and coins
        Obstacle[] allObstacles = FindObjectsOfType<Obstacle>();
        foreach (Obstacle obstacle in allObstacles)
        {
            // You would need to expose moveSpeed as a property in Obstacle script
        }

        Coin[] allCoins = FindObjectsOfType<Coin>();
        foreach (Coin coin in allCoins)
        {
            // You would need to expose moveSpeed as a property in Coin script
        }
    }
}
