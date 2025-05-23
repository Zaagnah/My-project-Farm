using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed = 10f; // �������� �������
    private Enemy target;

    public void Seek(Enemy targetEnemy)
    {
        target = targetEnemy;
    }

    void Update()
    {
        if (target == null)
        {
            Destroy(gameObject);
            return;
        }

        // �������� � ����
        Vector3 direction = target.transform.position - transform.position;
        float distanceThisFrame = speed * Time.deltaTime;

        if (direction.magnitude <= distanceThisFrame)
        {
            HitTarget();
            return;
        }

        transform.Translate(direction.normalized * distanceThisFrame, Space.World);
    }

    void HitTarget()
    {
        target.TakeDamage(1); // ������� ����
        Destroy(gameObject);
    }
}
