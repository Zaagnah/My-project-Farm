using System.Collections.Generic;
using TMPro; // Для работы с TMP Text
using UnityEngine;


public class Inventory : MonoBehaviour
{
    // Словарь для хранения количества собранных овощей по типу
    private Dictionary<string, int> vegetableCounts;
    public int maxVegetables = 15; // Максимум овощей для каждого типа
    public int totalCoins = 0; // Сумма монет
    public TextMeshProUGUI coinText; // Текст для отображения монет
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
            Debug.Log($"Добавлен {vegetableType}. Количество: {vegetableCounts[vegetableType]}");
        }
        else
        {
            Debug.Log($"Максимальное количество {vegetableType} достигнуто.");
        }
    }

    public int SellAllVegetables()
    {
        int totalSold = 0;

        // Собираем все ключи в список перед перебором
        var vegetablesToSell = new List<string>(vegetableCounts.Keys);

        foreach (var vegetable in vegetablesToSell)
        {
            // Получаем стоимость овоща через ссылку на объект Vegetable
            Vegetable vegScript = GameObject.Find(vegetable).GetComponent<Vegetable>(); // Находим объект овоща и получаем компонент
            totalSold += vegetableCounts[vegetable] * vegScript.GetCost(); // Умножаем на стоимость овоща
            vegetableCounts[vegetable] = 0; // Обнуляем количество после продажи
        }

        totalCoins += totalSold; // Прибавляем проданные монеты
        UpdateCoinText(); // Обновляем текст монет
        Debug.Log($"Продано {totalSold} овощей!");

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

    // Метод для обновления текста с количеством монет
    public void UpdateCoinText()
    {
        
            if (coinText != null && !missionComplete)
            {
                coinText.text = $"Монеты: {totalCoins} / {targetCoins} ";
            }
            else coinText.text = $"Уровень пройден. Ваш баланс: {totalCoins}";

        if (totalCoins >= targetCoins && !missionComplete)
        {
            Time.timeScale = 0;
            winPanel.SetActive(true);
            panels.SetActive(false);
            missionComplete = true;
            coinText.text = $"Уровень пройден. Ваш баланс: {totalCoins}";
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
