using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TargetManager : MonoBehaviour
{
    public Transform player;
    public Transform cargoZone;
    public List<Transform> randomTargets;
    public okGosterme arrow;
    public kargoAl kargo;

    public TMP_Text kazanmaText;
    public TMP_Text kaybetmeText;



    public int maxDeliveries = 5;   // Toplam teslim edilmesi gereken ev sayısı
    public float timeLimit = 60f;   // Süre sınırı (saniye)

    private int deliveriesDone = 0; // Yapılan teslim sayısı
    private float timer = 0f;
    private bool gameEnded = false;

    
    public TMP_Text timerText;


    private int currentPhase = 0;
    private Transform currentTarget;

    void Start()
    {
        SetTarget(cargoZone);
    }

    void Update()
    {
        if (gameEnded) return;  // Oyun bitti mi kontrol et

        timer += Time.deltaTime;

        if (timer > timeLimit)
        {
            GameOver(false);  // Süre doldu, kaybettin
            return;
        }

        timerText.text = "Kalan Süre: " + Mathf.Ceil(timeLimit - timer).ToString();

        float distance = Vector2.Distance(player.position, currentTarget.position);
        if (distance < 1f)
        {
            AdvanceToNextTarget();
        }
    }

    void SetTarget(Transform target)
    {
        currentTarget = target;
        arrow.target = currentTarget;
    }

    void AdvanceToNextTarget()
    {
        if (currentTarget == cargoZone)
        {
            if (randomTargets == null || randomTargets.Count == 0)
            {
                Debug.LogError("randomTargets listesi boş veya null!");
                return;
            }

            Transform random = randomTargets[Random.Range(0, randomTargets.Count)];
            if (random == null)
            {
                Debug.LogError("randomTargets içinde null eleman var!");
                return;
            }

            SetTarget(random);
        }
        else
        {
            // Rastgele hedefe ulaştın, teslim yapıldı
            deliveriesDone++;

            if (deliveriesDone >= maxDeliveries)
            {
                GameOver(true);  // Kazandın
                return;
            }

            kargo.hasCargo = false;
            SetTarget(cargoZone);
        }
    }

void GameOver(bool won)
{
    gameEnded = true;

    if (won)
    {
        Debug.Log("Tebrikler! Kazandın!");
        kazanmaText.gameObject.SetActive(true);  // Kazanma yazısını göster
    }
    else
    {
        Debug.Log("Süre doldu! Kaybettin!");
        kaybetmeText.gameObject.SetActive(true);  // Kaybetme yazısını göster
    }
}


}