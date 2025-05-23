using System.Collections;
using UnityEngine;
using TMPro;

namespace Cainos.PixelArtPlatformer_VillageProps
{
    public class Chest : MonoBehaviour
    {
        [Header("References")]
        public Animator animator;
        public TMP_Text timerText; // Текст для отображения таймера
        public int minCoins = 5; // Минимальное количество монет
        public int maxCoins = 15; // Максимальное количество монет
        public float timeToOpen = 10f; // Таймер для открытия сундука

        private float timer;
        private bool isOpened;
        private Inventory playerInventory; // Ссылка на инвентарь игрока

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
            playerInventory = FindObjectOfType<Inventory>(); // Поиск объекта с инвентарем
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
                    timer = timeToOpen; // Сброс таймера
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
                    int coinsToGive = Random.Range(minCoins, maxCoins + 1); // Случайное количество монет
                    playerInventory.totalCoins += coinsToGive; // Увеличиваем монеты
                    playerInventory.UpdateCoinText(); // Обновляем текст
                    Debug.Log($"Сундук открылся! Добавлено {coinsToGive} монет.");
                }
            
            else
            {
                if (playerInventory != null)
                {
                    int coinsToGive = Random.Range(minCoins, maxCoins + 1); // Случайное количество монет
                    playerInventory.totalCoins += coinsToGive; // Увеличиваем монеты
                    playerInventory.UpdateCoinText(); // Обновляем текст
                    Debug.Log($"Chest opened! You get {coinsToGive} coins.");
                }
            }
        }

        private IEnumerator CloseAfterDelay()
        {
            yield return new WaitForSeconds(2f); // Задержка перед закрытием
            IsOpened = false;
        }

        private void UpdateTimerText()
        {
            
                if (timerText != null)
                {
                    timerText.text = $"До открытия: {Mathf.Ceil(timer)}";
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
