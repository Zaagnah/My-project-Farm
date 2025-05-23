using System.Collections;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject monsterPrefab; // Префаб монстра
    public Transform spawnPoint; // Точка спавна

    public float initialSpawnDelay = 5f; // Задержка перед первой волной
    public float waveInterval = 10f; // Интервал между волнами
    public float spawnDelayInWave = 0.5f; // Задержка между монстрами в одной волне
    public int minMonstersPerWave = 1; // Минимальное количество монстров в волне
    public int maxMonstersPerWave = 10; // Максимальное количество монстров в волне

    private void Start()
    {
        StartCoroutine(SpawnRoutine());
    }

    private IEnumerator SpawnRoutine()
    {
        // Задержка перед первой волной
        yield return new WaitForSeconds(initialSpawnDelay);

        while (true)
        {
            int monstersToSpawn = Random.Range(minMonstersPerWave, maxMonstersPerWave + 1);
            Debug.Log($"Спавним {monstersToSpawn} монстров");

            // Спавн монстров с задержкой
            for (int i = 0; i < monstersToSpawn; i++)
            {
                SpawnMonster();
                yield return new WaitForSeconds(spawnDelayInWave);
            }

            // Ожидание до следующей волны
            yield return new WaitForSeconds(waveInterval);
        }
    }

    private void SpawnMonster()
    {
        if (monsterPrefab != null && spawnPoint != null)
        {
            Instantiate(monsterPrefab, spawnPoint.position, spawnPoint.rotation);
        }
        else
        {
            Debug.LogError("Не задан префаб монстра или точка спавна!");
        }
    }
}
