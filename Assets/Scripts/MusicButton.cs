using UnityEngine;
using UnityEngine.UI;

public class MusicButton : MonoBehaviour
{
    private Button musicButton;

    void Start()
    {
        musicButton = GetComponent<Button>();
        if (musicButton != null && MusicController.instance != null)
        {
            musicButton.onClick.AddListener(() => MusicController.instance.ToggleMusic());
        }
    }
}
