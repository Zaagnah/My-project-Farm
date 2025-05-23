using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f; // Скорость движения игрока
    private Vector2 targetPosition; // Целевая позиция для перемещения
    private bool isMoving = false; // Флаг, указывающий на то, движется ли игрок
    public Animator animator;

    private void Update()
    {
        // Обработка клика мыши
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            targetPosition = new Vector2(mousePos.x, mousePos.y);
            isMoving = true; // Начинаем движение
        }

        // Движение к целевой позиции
        if (isMoving)
        {
            animator.Play("Run");
            MoveToTarget();
        }
    }

    private void MoveToTarget()
    {
        // Получаем текущее положение игрока
        Vector2 currentPosition = transform.position;

        // Вычисляем направление движения
        Vector2 direction = (targetPosition - currentPosition).normalized;

        // Проверяем, нужно ли перевернуть спрайт
        FlipSprite(direction.x);

        // Движемся к цели
        float distance = moveSpeed * Time.deltaTime;
        transform.position = Vector2.MoveTowards(currentPosition, targetPosition, distance);

        // Проверяем, достиг ли игрок цели
        if (Vector2.Distance(currentPosition, targetPosition) < 0.1f)
        {
            isMoving = false;
            animator.Play("Idle"); // Останавливаем движение
        }
    }

    private void FlipSprite(float directionX)
    {
        if (directionX > 0)
        {
            transform.localScale = new Vector3(1, 1, 1); // Разворачиваем вправо
        }
        else if (directionX < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1); // Разворачиваем влево
        }
    }
}
