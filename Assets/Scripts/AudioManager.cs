using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private AudioClip coinSound;
    [SerializeField] private AudioClip jumpSound;
    [SerializeField] private AudioClip crashSound;
    [SerializeField] private AudioClip backgroundMusic;
    
    private AudioSource audioSource;
    private static AudioManager instance;

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
        PlayBackgroundMusic();
    }

    public void PlayCoinSound()
    {
        audioSource.PlayOneShot(coinSound);
    }

    public void PlayJumpSound()
    {
        audioSource.PlayOneShot(jumpSound);
    }

    public void PlayCrashSound()
    {
        audioSource.PlayOneShot(crashSound);
    }

    void PlayBackgroundMusic()
    {
        audioSource.clip = backgroundMusic;
        audioSource.loop = true;
        audioSource.Play();
    }
}
