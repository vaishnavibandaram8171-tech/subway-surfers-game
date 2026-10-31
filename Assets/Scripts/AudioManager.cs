using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private AudioClip coinSound;
    [SerializeField] private AudioClip jumpSound;
    [SerializeField] private AudioClip crashSound;
    [SerializeField] private AudioClip backgroundMusic;

    private AudioSource audioSource;
    private static AudioManager instance;

    public static AudioManager Instance => instance;

    void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(gameObject);
    }

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        if (audioSource != null)
        {
            PlayBackgroundMusic();
        }
    }

    public void PlayCoinSound()
    {
        if (audioSource != null && coinSound != null)
        {
            audioSource.PlayOneShot(coinSound);
        }
    }

    public void PlayJumpSound()
    {
        if (audioSource != null && jumpSound != null)
        {
            audioSource.PlayOneShot(jumpSound);
        }
    }

    public void PlayCrashSound()
    {
        if (audioSource != null && crashSound != null)
        {
            audioSource.PlayOneShot(crashSound);
        }
    }

    void PlayBackgroundMusic()
    {
        if (audioSource == null || backgroundMusic == null)
        {
            return;
        }

        audioSource.clip = backgroundMusic;
        audioSource.loop = true;
        audioSource.Play();
    }
}
