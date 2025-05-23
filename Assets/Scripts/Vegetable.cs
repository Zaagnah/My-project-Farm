using System.Collections;
using UnityEngine;

public class Vegetable : MonoBehaviour
{
    public float growthTime = 10f; // Время роста в секундах
    public Sprite grownSprite; // Спрайт для взрослого овоща
    public int cost = 10; // Стоимость овоща
    private SpriteRenderer spriteRenderer;
    private bool isGrown = false; // Флаг, вырос ли овощ
    private Vector3 initialScale; // Начальный размер
    private Vector3 finalScale; // Конечный размер
    [SerializeField]
    ParticleSystem growParticle;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        initialScale = transform.localScale * 0.5f; // Начальный размер - половина оригинального
        finalScale = transform.localScale; // Конечный размер - оригинальный
        transform.localScale = initialScale; // Устанавливаем начальный размер

        StartCoroutine(Grow());
    }

    private IEnumerator Grow()
    {
        float elapsedTime = 0f;

        // Постепенное изменение размера
        while (elapsedTime < growthTime)
        {
            transform.localScale = Vector3.Lerp(initialScale, finalScale, elapsedTime / growthTime);
            elapsedTime += Time.deltaTime;
            yield return null; // Ждем следующий кадр
        }

        // Устанавливаем окончательный размер и спрайт
        transform.localScale = finalScale;
        spriteRenderer.sprite = grownSprite;
        isGrown = true; // Устанавливаем флаг о том, что овощ вырос
        Debug.Log("Овощ вырос!");
        growParticle.Play();

    }
    
    public bool IsGrown()
    {

        return isGrown; // Возвращаем состояние роста овоща
        
    }

    public int GetCost()
    {
        return cost; // Возвращаем стоимость овоща
    }
}
