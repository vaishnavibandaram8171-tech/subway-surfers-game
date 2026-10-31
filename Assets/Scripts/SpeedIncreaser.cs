using UnityEngine;

public class SpeedIncreaser : MonoBehaviour
{
    [SerializeField] private float initialSpeed = 30f;
    [SerializeField] private float speedIncreaseRate = 0.5f;
    [SerializeField] private float maxSpeed = 60f;

    private float currentSpeed;
    private GameManager gameManager;

    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        currentSpeed = initialSpeed;
        ApplySpeed();
    }

    void Update()
    {
        if (gameManager == null || gameManager.isGameOver)
        {
            return;
        }

        // Increase speed based on score
        float targetSpeed = initialSpeed + (gameManager.score / 100f) * speedIncreaseRate;
        currentSpeed = Mathf.Min(targetSpeed, maxSpeed);
        ApplySpeed();
    }

    void ApplySpeed()
    {
        Obstacle[] allObstacles = FindObjectsOfType<Obstacle>();
        foreach (Obstacle obstacle in allObstacles)
        {
            obstacle.MoveSpeed = currentSpeed;
        }

        Coin[] allCoins = FindObjectsOfType<Coin>();
        foreach (Coin coin in allCoins)
        {
            coin.MoveSpeed = currentSpeed;
        }
    }
}
