using UnityEngine;

public class MusicController : MonoBehaviour
{
    public static MusicController instance;
    [SerializeField]
     AudioSource audioSource;

    void Awake()
    {
        // Singleton pattern: сохраняем объект между сценами
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject); // Уничтожаем дубликаты MusicController
        }
    }

    void Start()
    {
        //audioSource = GetComponent<AudioSource>();
    }

    // Метод для включения/выключения музыки
    public void ToggleMusic()
    {
        if (audioSource.isPlaying)
        {
            audioSource.Pause(); // Останавливаем музыку, если она играет
        }
        else
        {
            audioSource.Play();  // Запускаем музыку, если она не играет
        }
    }
}
