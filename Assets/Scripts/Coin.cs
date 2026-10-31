using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 30f;
    [SerializeField] private int coinValue = 10;
    [SerializeField] private float rotationSpeed = 5f;
    private GameManager gameManager;
    private AudioManager audioManager;
    private bool collected = false;

    public float MoveSpeed
    {
        get => moveSpeed;
        set => moveSpeed = value;
    }

    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        audioManager = AudioManager.Instance;
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

            if (gameManager != null)
            {
                gameManager.AddCoins(coinValue);
            }

            if (audioManager != null)
            {
                audioManager.PlayCoinSound();
            }

            Destroy(gameObject);
        }
    }
}
