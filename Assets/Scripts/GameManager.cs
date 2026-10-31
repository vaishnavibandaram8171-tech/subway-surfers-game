using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Text scoreText;
    [SerializeField] private Text coinsText;
    [SerializeField] private Text gameOverText;
    [SerializeField] private Button restartButton;
    [SerializeField] private Camera mainCamera;

    public int score = 0;
    public int coins = 0;
    public bool isGameOver = false;
    private PlayerController playerController;
    private float scoreIncreaseTimer = 0f;
    [SerializeField] private float scoreIncreaseInterval = 0.1f;
    private AudioManager audioManager;

    void Start()
    {
        playerController = FindObjectOfType<PlayerController>();
        audioManager = AudioManager.Instance;

        if (gameOverText != null)
        {
            gameOverText.gameObject.SetActive(false);
        }

        if (restartButton != null)
        {
            restartButton.gameObject.SetActive(false);
            restartButton.onClick.AddListener(RestartGame);
        }

        UpdateScoreUI();
        UpdateCoinsUI();
    }

    void Update()
    {
        if (!isGameOver)
        {
            scoreIncreaseTimer += Time.deltaTime;
            if (scoreIncreaseTimer >= scoreIncreaseInterval)
            {
                score += 10;
                scoreIncreaseTimer = 0f;
                UpdateScoreUI();
            }
        }
    }

    public void AddCoins(int amount)
    {
        coins += amount;
        UpdateCoinsUI();
    }

    public void GameOver()
    {
        if (isGameOver) return;

        isGameOver = true;

        if (audioManager != null)
        {
            audioManager.PlayCrashSound();
        }

        if (gameOverText != null)
        {
            gameOverText.gameObject.SetActive(true);
            gameOverText.text = $"Game Over!\nScore: {score}\nCoins: {coins}";
        }

        if (restartButton != null)
        {
            restartButton.gameObject.SetActive(true);
        }

        Time.timeScale = 0f; // Pause the game
    }

    void UpdateScoreUI()
    {
        if (scoreText != null)
        {
            scoreText.text = "Score: " + score;
        }
    }

    void UpdateCoinsUI()
    {
        if (coinsText != null)
        {
            coinsText.text = "Coins: " + coins;
        }
    }

    void RestartGame()
    {
        Time.timeScale = 1f; // Resume the game
        UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);
    }
}
