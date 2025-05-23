using UnityEngine;
using TMPro; // Для работы с текстом

public class GardenBed : MonoBehaviour
{
    public GameObject vegetablePrefab; // Префаб овоща
    public Transform growthPoint; // Точка, где будет расти овощ
    public Inventory playerInventory; // Ссылка на инвентарь игрока
    public int unlockCost = 5; // Стоимость разблокировки грядки
    public TMP_Text unlockText; // Текст с ценой разблокировки

    private bool isUnlocked = false; // Флаг разблокировки
    private Vegetable currentVegetable; // Ссылка на текущий овощ
    [SerializeField]
    GameObject littlePanel;

    private void Start()
    {
        // Обновляем текст с ценой разблокировки
        if (unlockText != null)
        {
            unlockText.text = $"{unlockCost}";
        }

        if (isUnlocked)
        {
            GrowVegetable();
            HideUnlockText();
        }
    }

    private void GrowVegetable()
    {
        if (isUnlocked && currentVegetable == null)
        {
            // Создаем овощ на точке роста
            GameObject vegetable = Instantiate(vegetablePrefab, growthPoint.position, Quaternion.identity);
            currentVegetable = vegetable.GetComponent<Vegetable>(); // Сохраняем ссылку на овощ
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (!isUnlocked)
            {
                UnlockBed();
            }
            else if (currentVegetable != null && currentVegetable.IsGrown())
            {
                CollectVegetable();
            }
        }
    }

    private void UnlockBed()
    {
        if (playerInventory.totalCoins >= unlockCost)
        {
            playerInventory.totalCoins -= unlockCost;
            isUnlocked = true;
            playerInventory.UpdateCoinText();
            GrowVegetable();
            HideUnlockText();
            Debug.Log("Грядка разблокирована!");
        }
        else
        {
            Debug.Log("Недостаточно монет для разблокировки!");
        }
    }

    private void HideUnlockText()
    {
        if (unlockText != null)
        {
            unlockText.gameObject.SetActive(false); // Скрываем текст
            littlePanel.SetActive(false);
        }
    }

    private void CollectVegetable()
    {
        // Логика сбора овоща
        playerInventory.AddVegetable(currentVegetable.name);
        Destroy(currentVegetable.gameObject); // Уничтожаем овощ
        currentVegetable = null; // Убираем ссылку на собранный овощ
        Invoke("GrowVegetable", 1f);
        Debug.Log("Овощ собран!");
    }
}
