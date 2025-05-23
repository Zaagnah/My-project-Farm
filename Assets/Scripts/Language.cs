using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.InteropServices;

using UnityEngine.UI;


public class Language : MonoBehaviour
{
    

    
    public static Language Instance;
    void Start()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);

            // ТУТ БЫло определение языка

            
        }
        else Destroy(gameObject);
        //Application.targetFrameRate = 60;
    }


}
