using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Runtime.InteropServices;



public class LvlControlScr : MonoBehaviour
{
    public int defaultLevel = 0; // ��������� ������� �� ���������
    

    


    void Awake()
    {
        
        Time.timeScale = 1;
        AudioListener.volume = 1f;

        // ��������� ���������� ������� � ��������� ���
        int savedLevel = PlayerPrefs.GetInt("Level", defaultLevel);
        if (savedLevel != SceneManager.GetActiveScene().buildIndex)
        {
            SceneManager.LoadScene(savedLevel);
        }
    }
    private void Start()
    {
        
    }
    public void ToNextLvlAfterWin()
    {
        int nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;
        if (nextSceneIndex >= SceneManager.sceneCountInBuildSettings)
        {
            nextSceneIndex = 1; // ����������� ��������, ���� ��� ��������� �������
        }
        PlayerPrefs.SetInt("Level", nextSceneIndex);
        PlayerPrefs.Save();
        // ��������� ��������� ������� ����� �������
        SceneManager.LoadScene(nextSceneIndex);
    }

    public void BackToGame()
    {
        Time.timeScale = 1;
        AudioListener.volume = 1f;
    }

    public void OnResumeGame()
    {
        Debug.Log("Resuming game...");
        Time.timeScale = 1;
        AudioListener.volume = 1f;

        int nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;
        if (nextSceneIndex >= SceneManager.sceneCountInBuildSettings)
        {
            nextSceneIndex = 0; // ����������� ��������, ���� ��� ��������� �������
        }
        PlayerPrefs.SetInt("Level", nextSceneIndex);
        PlayerPrefs.Save();
        // ��������� ��������� ������� ����� �������
        SceneManager.LoadScene(nextSceneIndex);

    }

    public void OnPauseGame()
    {
        Debug.Log("Pausing game...");
        Time.timeScale = 0;
        AudioListener.volume = 0f;
    }

    public void LoadFirstLevelAfterAd()
    {
        // ��� ���� �������
        SceneManager.LoadScene(0);
    }
    public void LoadFirstLevelAfterWin()
    {
        // ��� ���� �������
        SceneManager.LoadScene(0);
    }

    public void LoadNextLevel()
    {
        // ��� ���� �������

        // ��������� ������ ���������� ������


        // ��������� ��������� �������

    }

    public void LoadLevel()
    {
        // ��� ���� �������

        // ��������� ���������� �������
        int savedLevel = PlayerPrefs.GetInt("Level", defaultLevel);
        SceneManager.LoadScene(savedLevel);
    }

    public void SkipLvl()
    {
        // ��� ���� ������� ������

        // ��������� ������ ���������� ������
        /*int nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;
        if (nextSceneIndex >= SceneManager.sceneCountInBuildSettings)
        {
            nextSceneIndex = 1; // ����������� ��������
        }

        // ��������� ������ ���������� ������
        PlayerPrefs.SetInt("Level", nextSceneIndex);
        PlayerPrefs.Save();

        // ��������� ��������� �������
        SceneManager.LoadScene(nextSceneIndex);*/
    }

    public void SkiplvlFinally()
    {
        Time.timeScale = 1;
        AudioListener.volume = 1f;

        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int nextSceneIndex = currentSceneIndex + 1;
        if (nextSceneIndex >= SceneManager.sceneCountInBuildSettings)
        {
            nextSceneIndex = 1; // ����������� ��������
        }

        // ��������� �������
        PlayerPrefs.SetInt("Level", nextSceneIndex);
        PlayerPrefs.Save();

        SceneManager.LoadScene(nextSceneIndex);
    }

    private void OnRewardedVideoSuccess()
    {
        Debug.Log("Rewarded video successfully completed.");
        Time.timeScale = 1;
        AudioListener.volume = 1f;

        // ��������� ��������� �������
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    
}
