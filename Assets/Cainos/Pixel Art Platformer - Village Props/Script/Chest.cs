using System.Collections;
using UnityEngine;
using TMPro;

namespace Cainos.PixelArtPlatformer_VillageProps
{
    public class Chest : MonoBehaviour
    {
        [Header("References")]
        public Animator animator;
        public TMP_Text timerText; // ����� ��� ����������� �������
        public int minCoins = 5; // ����������� ���������� �����
        public int maxCoins = 15; // ������������ ���������� �����
        public float timeToOpen = 10f; // ������ ��� �������� �������

        private float timer;
        private bool isOpened;
        private Inventory playerInventory; // ������ �� ��������� ������

        public bool IsOpened
        {
            get { return isOpened; }
            set
            {
                isOpened = value;
                animator.SetBool("IsOpened", isOpened);
            }
        }

        private void Start()
        {
            timer = timeToOpen;
            playerInventory = FindObjectOfType<Inventory>(); // ����� ������� � ����������
            UpdateTimerText();
        }

        private void Update()
        {
            if (!IsOpened)
            {
                timer -= Time.deltaTime;

                if (timer <= 0)
                {
                    OpenChest();
                    timer = timeToOpen; // ����� �������
                }

                UpdateTimerText();
            }
        }

        private void OpenChest()
        {
            IsOpened = true;
            GiveCoins();
            StartCoroutine(CloseAfterDelay());
        }

        private void GiveCoins()
        {
           
                if (playerInventory != null)
                {
                    int coinsToGive = Random.Range(minCoins, maxCoins + 1); // ��������� ���������� �����
                    playerInventory.totalCoins += coinsToGive; // ����������� ������
                    playerInventory.UpdateCoinText(); // ��������� �����
                    Debug.Log($"������ ��������! ��������� {coinsToGive} �����.");
                }
            
            else
            {
                if (playerInventory != null)
                {
                    int coinsToGive = Random.Range(minCoins, maxCoins + 1); // ��������� ���������� �����
                    playerInventory.totalCoins += coinsToGive; // ����������� ������
                    playerInventory.UpdateCoinText(); // ��������� �����
                    Debug.Log($"Chest opened! You get {coinsToGive} coins.");
                }
            }
        }

        private IEnumerator CloseAfterDelay()
        {
            yield return new WaitForSeconds(2f); // �������� ����� ���������
            IsOpened = false;
        }

        private void UpdateTimerText()
        {
            
                if (timerText != null)
                {
                    timerText.text = $"�� ��������: {Mathf.Ceil(timer)}";
                }
            
            else
            {
                if (timerText != null)
                {
                    timerText.text = $"Time left: {Mathf.Ceil(timer)}";
                }
            }
        }
    }
}
