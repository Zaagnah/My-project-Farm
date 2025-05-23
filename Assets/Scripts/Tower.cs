using TMPro;
using UnityEngine;


public class Tower : MonoBehaviour
{
    public float range = 5f;           // Дальность стрельбы
    public float fireRate = 1f;       // Скорострельность
    public GameObject projectilePrefab; // Префаб снаряда
    public Transform firePoint;        // Точка выстрела
    public Inventory playerInventory;
    public int unlockCost = 5; 
    private bool isUnlocked = false;
    public TMP_Text unlockText; // Текст с ценой разблокировки

    private float fireCountdown = 0f;
    [SerializeField]
    GameObject littlePanel;
    public Animator anim;

    private void Start()
    {
        if (unlockText != null)
        {
            unlockText.text = $"{unlockCost}";
        }
        if (isUnlocked)
        {
           HideUnlockText();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (!isUnlocked)
            {
                UnlockTower();
            }
            else
            {

            }
        }
    }
    private void UnlockTower()
    {
        if (playerInventory.totalCoins >= unlockCost)
        {
            playerInventory.totalCoins -= unlockCost;
            isUnlocked = true;
            playerInventory.UpdateCoinText();
            HideUnlockText();
            Debug.Log("Грядка разблокирована!");
            anim.Play("Tower");
        }
        else
        {
            Debug.Log("Недостаточно монет для разблокировки!");
        }
    }
    void Update()
    {
        if (isUnlocked)
        {
            // Найти ближайшего врага
            Enemy nearestEnemy = FindNearestEnemy();
            if (nearestEnemy != null)
            {
                if (fireCountdown <= 0f)
                {
                    anim.Play("Tower");
                    Shoot(nearestEnemy);
                    fireCountdown = 1f / fireRate;
                }
                fireCountdown -= Time.deltaTime;
            }
        }
        else
        {
            //anim.Play("State");
            return;
        }
    }

    void Shoot(Enemy enemy)
    {
        // Создание снаряда
        
        GameObject projectile = Instantiate(projectilePrefab, firePoint.position, firePoint.rotation);
        Projectile proj = projectile.GetComponent<Projectile>();
        if (proj != null)
        {
            proj.Seek(enemy);
        }
        
    }

    Enemy FindNearestEnemy()
    {
        Enemy nearestEnemy = null;
        float shortestDistance = Mathf.Infinity;

        foreach (Enemy enemy in FindObjectsOfType<Enemy>())
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            if (distanceToEnemy < shortestDistance && distanceToEnemy <= range)
            {
                shortestDistance = distanceToEnemy;
                nearestEnemy = enemy;
            }
        }
        return nearestEnemy;
    }

    private void HideUnlockText()
    {
        if (unlockText != null)
        {
            unlockText.gameObject.SetActive(false); // Скрываем текст
            littlePanel.SetActive(false);
        }
    }
}
