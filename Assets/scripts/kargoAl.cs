using UnityEngine;

public class kargoAl : MonoBehaviour
{
    public bool hasCargo = false;

    public SpriteRenderer spriterend;
    public SpriteRenderer spriterendkargoplayer;


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !hasCargo)
        {
            hasCargo = true;
            Debug.Log("Kargo alındı!");
            // Buraya animasyon, ses, veya UI güncellemesi ekleyebilirsin
        }
    }

    void Update()
    {
        if (hasCargo == true)
        {
            spriterend.enabled = false;
            spriterendkargoplayer.enabled = true;
        }
        else if(hasCargo == false)
        {
            spriterend.enabled = true;
            spriterendkargoplayer.enabled = false;
        }
    }
}