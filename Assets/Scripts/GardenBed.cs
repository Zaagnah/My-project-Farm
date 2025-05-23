using UnityEngine;
using TMPro; // ��� ������ � �������

public class GardenBed : MonoBehaviour
{
    public GameObject vegetablePrefab; // ������ �����
    public Transform growthPoint; // �����, ��� ����� ����� ����
    public Inventory playerInventory; // ������ �� ��������� ������
    public int unlockCost = 5; // ��������� ������������� ������
    public TMP_Text unlockText; // ����� � ����� �������������

    private bool isUnlocked = false; // ���� �������������
    private Vegetable currentVegetable; // ������ �� ������� ����
    [SerializeField]
    GameObject littlePanel;

    private void Start()
    {
        // ��������� ����� � ����� �������������
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
            // ������� ���� �� ����� �����
            GameObject vegetable = Instantiate(vegetablePrefab, growthPoint.position, Quaternion.identity);
            currentVegetable = vegetable.GetComponent<Vegetable>(); // ��������� ������ �� ����
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
            Debug.Log("������ ��������������!");
        }
        else
        {
            Debug.Log("������������ ����� ��� �������������!");
        }
    }

    private void HideUnlockText()
    {
        if (unlockText != null)
        {
            unlockText.gameObject.SetActive(false); // �������� �����
            littlePanel.SetActive(false);
        }
    }

    private void CollectVegetable()
    {
        // ������ ����� �����
        playerInventory.AddVegetable(currentVegetable.name);
        Destroy(currentVegetable.gameObject); // ���������� ����
        currentVegetable = null; // ������� ������ �� ��������� ����
        Invoke("GrowVegetable", 1f);
        Debug.Log("���� ������!");
    }
}
