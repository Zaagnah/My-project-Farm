using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 2f; // Скорость врага
    public int health = 10;  // Здоровье врага

    private Transform target; // Цель врага (магазин)

    void Start()
    {
        target = GameObject.FindWithTag("Trader").transform; // Находим объект по тегу
    }

    void Update()
    {
        // Движение к магазину
        if (target != null)
        {
            Vector2 currentPosition = transform.position;
            Vector2 targetPosition = target.position;

            // Вычисляем направление движения
            Vector2 direction = (targetPosition - currentPosition).normalized;

            // Двигаем врага
            transform.position = Vector3.MoveTowards(currentPosition, targetPosition, speed * Time.deltaTime);

            // Поворачиваем врага в направлении движения
            FlipSprite(direction.x);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Trader"))
        {
            Debug.Log("Enemy reached the shop!");
            Shop shop = other.GetComponent<Shop>();
            if (shop != null)
            {
                shop.StealMoneyFromPlayer(); // Вызов метода кражи денег
            }
            Destroy(gameObject); // Уничтожаем врага
        }
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Debug.Log("Enemy died");
        Destroy(gameObject);
    }

    private void FlipSprite(float directionX)
    {
        // Разворачиваем врага в сторону движения
        if (directionX > 0)
        {
            transform.localScale = new Vector3(1, 1, 1); // Направо
        }
        else if (directionX < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1); // Налево
        }
    }
}
