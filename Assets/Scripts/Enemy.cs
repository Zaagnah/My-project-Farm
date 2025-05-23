using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 2f; // �������� �����
    public int health = 10;  // �������� �����

    private Transform target; // ���� ����� (�������)

    void Start()
    {
        target = GameObject.FindWithTag("Trader").transform; // ������� ������ �� ����
    }

    void Update()
    {
        // �������� � ��������
        if (target != null)
        {
            Vector2 currentPosition = transform.position;
            Vector2 targetPosition = target.position;

            // ��������� ����������� ��������
            Vector2 direction = (targetPosition - currentPosition).normalized;

            // ������� �����
            transform.position = Vector3.MoveTowards(currentPosition, targetPosition, speed * Time.deltaTime);

            // ������������ ����� � ����������� ��������
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
                shop.StealMoneyFromPlayer(); // ����� ������ ����� �����
            }
            Destroy(gameObject); // ���������� �����
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
        // ������������� ����� � ������� ��������
        if (directionX > 0)
        {
            transform.localScale = new Vector3(1, 1, 1); // �������
        }
        else if (directionX < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1); // ������
        }
    }
}
