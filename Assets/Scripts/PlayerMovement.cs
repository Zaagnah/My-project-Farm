using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f; // �������� �������� ������
    private Vector2 targetPosition; // ������� ������� ��� �����������
    private bool isMoving = false; // ����, ����������� �� ��, �������� �� �����
    public Animator animator;

    private void Update()
    {
        // ��������� ����� ����
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            targetPosition = new Vector2(mousePos.x, mousePos.y);
            isMoving = true; // �������� ��������
        }

        // �������� � ������� �������
        if (isMoving)
        {
            animator.Play("Run");
            MoveToTarget();
        }
    }

    private void MoveToTarget()
    {
        // �������� ������� ��������� ������
        Vector2 currentPosition = transform.position;

        // ��������� ����������� ��������
        Vector2 direction = (targetPosition - currentPosition).normalized;

        // ���������, ����� �� ����������� ������
        FlipSprite(direction.x);

        // �������� � ����
        float distance = moveSpeed * Time.deltaTime;
        transform.position = Vector2.MoveTowards(currentPosition, targetPosition, distance);

        // ���������, ������ �� ����� ����
        if (Vector2.Distance(currentPosition, targetPosition) < 0.1f)
        {
            isMoving = false;
            animator.Play("Idle"); // ������������� ��������
        }
    }

    private void FlipSprite(float directionX)
    {
        if (directionX > 0)
        {
            transform.localScale = new Vector3(1, 1, 1); // ������������� ������
        }
        else if (directionX < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1); // ������������� �����
        }
    }
}
