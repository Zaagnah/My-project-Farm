using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundDestroy : MonoBehaviour
{
   

    // Update is called once per frame
    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }
}
