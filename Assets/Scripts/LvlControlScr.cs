using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Runtime.InteropServices;



public class LvlControlScr : MonoBehaviour
{
    public int defaultLevel = 0; // Начальный уровень по умолчанию
    

    


    void Awake()
    {
        
        Time.timeScale = 1;
        AudioListener.volume = 1f;

        // Проверяем сохранённый уровень и загружаем его
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
            nextSceneIndex = 1; // Циклическая загрузка, если это последний уровень
        }
        PlayerPrefs.SetInt("Level", nextSceneIndex);
        PlayerPrefs.Save();
        // Загружаем следующий уровень после рекламы
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
            nextSceneIndex = 0; // Циклическая загрузка, если это последний уровень
        }
        PlayerPrefs.SetInt("Level", nextSceneIndex);
        PlayerPrefs.Save();
        // Загружаем следующий уровень после рекламы
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
        // ТУТ БЫЛА РЕКЛАМА
        SceneManager.LoadScene(0);
    }
    public void LoadFirstLevelAfterWin()
    {
        // ТУТ БЫЛА РЕКЛАМА
        SceneManager.LoadScene(0);
    }

    public void LoadNextLevel()
    {
        // ТУТ БЫЛА РЕКЛАМА

        // Сохраняем индекс следующего уровня


        // Загружаем следующий уровень

    }

    public void LoadLevel()
    {
        // ТУТ БЫЛА РЕКЛАМА

        // Загружаем сохранённый уровень
        int savedLevel = PlayerPrefs.GetInt("Level", defaultLevel);
        SceneManager.LoadScene(savedLevel);
    }

    public void SkipLvl()
    {
        // ТУТ БЫЛА РЕКЛАМА ревард

        // Вычисляем индекс следующего уровня
        /*int nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;
        if (nextSceneIndex >= SceneManager.sceneCountInBuildSettings)
        {
            nextSceneIndex = 1; // Циклическая загрузка
        }

        // Сохраняем индекс следующего уровня
        PlayerPrefs.SetInt("Level", nextSceneIndex);
        PlayerPrefs.Save();

        // Загружаем следующий уровень
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
            nextSceneIndex = 1; // Циклическая загрузка
        }

        // Сохраняем уровень
        PlayerPrefs.SetInt("Level", nextSceneIndex);
        PlayerPrefs.Save();

        SceneManager.LoadScene(nextSceneIndex);
    }

    private void OnRewardedVideoSuccess()
    {
        Debug.Log("Rewarded video successfully completed.");
        Time.timeScale = 1;
        AudioListener.volume = 1f;

        // Загружаем следующий уровень
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    
}
