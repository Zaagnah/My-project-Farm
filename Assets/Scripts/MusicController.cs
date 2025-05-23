using UnityEngine;

public class MusicController : MonoBehaviour
{
    public static MusicController instance;
    [SerializeField]
     AudioSource audioSource;

    void Awake()
    {
        // Singleton pattern: ��������� ������ ����� �������
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject); // ���������� ��������� MusicController
        }
    }

    void Start()
    {
        //audioSource = GetComponent<AudioSource>();
    }

    // ����� ��� ���������/���������� ������
    public void ToggleMusic()
    {
        if (audioSource.isPlaying)
        {
            audioSource.Pause(); // ������������� ������, ���� ��� ������
        }
        else
        {
            audioSource.Play();  // ��������� ������, ���� ��� �� ������
        }
    }
}
