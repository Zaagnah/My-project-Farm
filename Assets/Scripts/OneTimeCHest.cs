using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class OneTimeCHest : MonoBehaviour
{
    public Animator animator;
    [SerializeField]
    Inventory playerInventory;
   
    public int maxCoins = 30; // ������������ ���������� �����
    

    
    private bool isOpened;
    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            isOpened = true;
            OpenChest();
            
        }
    }
    public bool IsOpened
    {
        get { return isOpened; }
        set
        {
            isOpened = value;
            animator.SetBool("IsOpened", isOpened);
        }
    }

    private void OpenChest()
    {
        IsOpened = true;
        GiveCoins();
        
    }

    private void GiveCoins()
    {
        
            int coinsToGive = maxCoins;
            playerInventory.totalCoins += coinsToGive; // ����������� ������
            playerInventory.UpdateCoinText(); // ��������� �����
            Debug.Log($"������ ��������! ��������� {coinsToGive} �����.");
        Invoke("DestroyChest", 2f);
        
    }
    private void DestroyChest()
    {
        Destroy(gameObject);
    }
}
