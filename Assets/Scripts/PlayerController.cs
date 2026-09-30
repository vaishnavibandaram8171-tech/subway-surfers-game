using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float laneDistance = 3f;
    [SerializeField] private float moveSpeed = 10f;
    [SerializeField] private float jumpForce = 5f;
    [SerializeField] private float slideDistance = 2f;
    [SerializeField] private float slideDuration = 0.5f;
    
    private int desiredLane = 1; // 0=Left, 1=Middle, 2=Right
    private int currentLane = 1;
    private Rigidbody rb;
    private bool isJumping = false;
    private bool isSliding = false;
    private float slideTimer = 0f;
    private Vector3 originalScale;
    private GameManager gameManager;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        gameManager = FindObjectOfType<GameManager>();
        originalScale = transform.localScale;
    }

    void Update()
    {
        if (gameManager.isGameOver) return;

        HandleInput();
        HandleMovement();
        HandleSlide();
    }

    void HandleInput()
    {
        // Keyboard input
        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            desiredLane--;
        }
        if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            desiredLane++;
        }

        // Jump
        if ((Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.UpArrow)) && !isJumping && !isSliding)
        {
            Jump();
        }

        // Slide
        if ((Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow)) && !isSliding && !isJumping)
        {
            StartSlide();
        }

        // Clamp lane
        desiredLane = Mathf.Clamp(desiredLane, 0, 2);
    }

    void HandleMovement()
    {
        // Calculate target position
        float targetX = (desiredLane - 1) * laneDistance;
        Vector3 targetPosition = new Vector3(targetX, transform.position.y, transform.position.z);

        // Smooth movement between lanes
        transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime * moveSpeed);
        currentLane = desiredLane;
    }

    void Jump()
    {
        if (isSliding) return;
        isJumping = true;
        rb.velocity = new Vector3(rb.velocity.x, jumpForce, rb.velocity.z);
    }

    void StartSlide()
    {
        isSliding = true;
        slideTimer = slideDuration;
        transform.localScale = new Vector3(originalScale.x, originalScale.y * 0.5f, originalScale.z);
    }

    void HandleSlide()
    {
        if (isSliding)
        {
            slideTimer -= Time.deltaTime;
            if (slideTimer <= 0)
            {
                isSliding = false;
                transform.localScale = originalScale;
            }
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isJumping = false;
        }

        if (collision.gameObject.CompareTag("Obstacle"))
        {
            gameManager.GameOver();
        }
    }

    public bool IsSliding()
    {
        return isSliding;
    }
}
