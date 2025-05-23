using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartEdu : MonoBehaviour
{
    [SerializeField]
    GameObject beginningPanel;

    private void Start()
    {
        beginningPanel.SetActive(true);
        if (beginningPanel)
        {
            Time.timeScale = 0;
        }
    }

    // Update is called once per frame
    public void StartGameEpta()
    {
        Time.timeScale = 1;
    }
}
