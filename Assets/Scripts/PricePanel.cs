using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PricePanel : MonoBehaviour
{
    public GameObject _pricePanel_ru;
    public GameObject _pricePanel_eng;
    private GameObject currentpanel;
    private void Start()
    {
       /* if (Language.Instance.CurrentLanguage == "ru")
        {
            currentpanel = _pricePanel_ru;
        }
        else currentpanel = _pricePanel_eng;
       */
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.CompareTag("Player"))
        {
            currentpanel.SetActive(true);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            currentpanel.SetActive(false);
        }
    }
}
