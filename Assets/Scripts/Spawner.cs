using System.Collections;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject monsterPrefab; // ������ �������
    public Transform spawnPoint; // ����� ������

    public float initialSpawnDelay = 5f; // �������� ����� ������ ������
    public float waveInterval = 10f; // �������� ����� �������
    public float spawnDelayInWave = 0.5f; // �������� ����� ��������� � ����� �����
    public int minMonstersPerWave = 1; // ����������� ���������� �������� � �����
    public int maxMonstersPerWave = 10; // ������������ ���������� �������� � �����

    private void Start()
    {
        StartCoroutine(SpawnRoutine());
    }

    private IEnumerator SpawnRoutine()
    {
        // �������� ����� ������ ������
        yield return new WaitForSeconds(initialSpawnDelay);

        while (true)
        {
            int monstersToSpawn = Random.Range(minMonstersPerWave, maxMonstersPerWave + 1);
            Debug.Log($"������� {monstersToSpawn} ��������");

            // ����� �������� � ���������
            for (int i = 0; i < monstersToSpawn; i++)
            {
                SpawnMonster();
                yield return new WaitForSeconds(spawnDelayInWave);
            }

            // �������� �� ��������� �����
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
            Debug.LogError("�� ����� ������ ������� ��� ����� ������!");
        }
    }
}
