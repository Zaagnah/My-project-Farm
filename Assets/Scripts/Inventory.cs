using System.Collections.Generic;
using TMPro; // ��� ������ � TMP Text
using UnityEngine;


public class Inventory : MonoBehaviour
{
    // ������� ��� �������� ���������� ��������� ������ �� ����
    private Dictionary<string, int> vegetableCounts;
    public int maxVegetables = 15; // �������� ������ ��� ������� ����
    public int totalCoins = 0; // ����� �����
    public TextMeshProUGUI coinText; // ����� ��� ����������� �����
    [SerializeField]
    int targetCoins;
    [SerializeField]
    GameObject winPanel;
    [SerializeField]
    GameObject winPanel_Eng;
    bool missionComplete;
    [SerializeField]
    GameObject panels;

    private void Awake()
    {
        vegetableCounts = new Dictionary<string, int>();
        coinText.text = $" ";
        UpdateCoinText();
        missionComplete = false;
       
    }
    private void Start()
    {
        UpdateCoinText();
    }

    public void AddVegetable(string vegetableType)
    {
        if (!vegetableCounts.ContainsKey(vegetableType))
        {
            vegetableCounts[vegetableType] = 0;
        }

        if (vegetableCounts[vegetableType] < maxVegetables)
        {
            vegetableCounts[vegetableType]++;
            Debug.Log($"�������� {vegetableType}. ����������: {vegetableCounts[vegetableType]}");
        }
        else
        {
            Debug.Log($"������������ ���������� {vegetableType} ����������.");
        }
    }

    public int SellAllVegetables()
    {
        int totalSold = 0;

        // �������� ��� ����� � ������ ����� ���������
        var vegetablesToSell = new List<string>(vegetableCounts.Keys);

        foreach (var vegetable in vegetablesToSell)
        {
            // �������� ��������� ����� ����� ������ �� ������ Vegetable
            Vegetable vegScript = GameObject.Find(vegetable).GetComponent<Vegetable>(); // ������� ������ ����� � �������� ���������
            totalSold += vegetableCounts[vegetable] * vegScript.GetCost(); // �������� �� ��������� �����
            vegetableCounts[vegetable] = 0; // �������� ���������� ����� �������
        }

        totalCoins += totalSold; // ���������� ��������� ������
        UpdateCoinText(); // ��������� ����� �����
        Debug.Log($"������� {totalSold} ������!");

        return totalSold;
    }
    public int LostAllMoney()
    {
        int totalLost = 0;
        totalCoins = totalCoins - totalCoins- totalLost;
        UpdateCoinText();

        return totalLost;
    }



    public int GetVegetableCount(string vegetableType)
    {
        return vegetableCounts.ContainsKey(vegetableType) ? vegetableCounts[vegetableType] : 0;
    }

    // ����� ��� ���������� ������ � ����������� �����
    public void UpdateCoinText()
    {
        
            if (coinText != null && !missionComplete)
            {
                coinText.text = $"������: {totalCoins} / {targetCoins} ";
            }
            else coinText.text = $"������� �������. ��� ������: {totalCoins}";

        if (totalCoins >= targetCoins && !missionComplete)
        {
            Time.timeScale = 0;
            winPanel.SetActive(true);
            panels.SetActive(false);
            missionComplete = true;
            coinText.text = $"������� �������. ��� ������: {totalCoins}";
        }
        
        else
        {
            if (coinText != null && !missionComplete)
            {
                coinText.text = $"Coins: {totalCoins} / {targetCoins} ";
            }
            else coinText.text = $"Level Completed. Your balance: {totalCoins}";

            if (totalCoins >= targetCoins && !missionComplete)
            {
                Time.timeScale = 0;
                winPanel_Eng.SetActive(true);
                panels.SetActive(false);
                missionComplete = true;
                coinText.text = $"Level Completed. Your balance: {totalCoins}";
            }
        }
       
    }
    public void GetRevMoney()
    {
        totalCoins += 50;
        UpdateCoinText();
    }
    
}
