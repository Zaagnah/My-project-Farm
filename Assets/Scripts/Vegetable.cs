using System.Collections;
using UnityEngine;

public class Vegetable : MonoBehaviour
{
    public float growthTime = 10f; // ����� ����� � ��������
    public Sprite grownSprite; // ������ ��� ��������� �����
    public int cost = 10; // ��������� �����
    private SpriteRenderer spriteRenderer;
    private bool isGrown = false; // ����, ����� �� ����
    private Vector3 initialScale; // ��������� ������
    private Vector3 finalScale; // �������� ������
    [SerializeField]
    ParticleSystem growParticle;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        initialScale = transform.localScale * 0.5f; // ��������� ������ - �������� �������������
        finalScale = transform.localScale; // �������� ������ - ������������
        transform.localScale = initialScale; // ������������� ��������� ������

        StartCoroutine(Grow());
    }

    private IEnumerator Grow()
    {
        float elapsedTime = 0f;

        // ����������� ��������� �������
        while (elapsedTime < growthTime)
        {
            transform.localScale = Vector3.Lerp(initialScale, finalScale, elapsedTime / growthTime);
            elapsedTime += Time.deltaTime;
            yield return null; // ���� ��������� ����
        }

        // ������������� ������������� ������ � ������
        transform.localScale = finalScale;
        spriteRenderer.sprite = grownSprite;
        isGrown = true; // ������������� ���� � ���, ��� ���� �����
        Debug.Log("���� �����!");
        growParticle.Play();

    }
    
    public bool IsGrown()
    {

        return isGrown; // ���������� ��������� ����� �����
        
    }

    public int GetCost()
    {
        return cost; // ���������� ��������� �����
    }
}
