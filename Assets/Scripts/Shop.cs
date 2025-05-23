using UnityEngine;

public class Shop : MonoBehaviour
{
    public static Shop Instance;
    public Inventory playerInventory;

    void Awake()
    {
        Instance = this;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            int totalSold = playerInventory.SellAllVegetables();
            Debug.Log($"Вы продали {totalSold} овощей!");
        }else if (collision.CompareTag("Enemy"))
        {
            int totalLost = playerInventory.LostAllMoney();
            StealMoneyFromPlayer();
            Destroy(collision);
        }
    }

    public void StealMoneyFromPlayer()
    {
        if (playerInventory != null)
        {
            Debug.Log("Enemy stole all the player's money!");
            playerInventory.LostAllMoney(); // Уменьшаем деньги в инвентаре
        }
    }
}
