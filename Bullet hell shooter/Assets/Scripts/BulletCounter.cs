using UnityEngine;
using TMPro;

public class BulletCounter : MonoBehaviour
{
    public TextMeshProUGUI bulletCountText; // Referencia al objeto Text (TMP)
    private int bulletCount = 0; // Contador de balas

    // Llama a este método cuando el jugador dispara una bala
    public void IncrementBulletCount()
    {
        bulletCount++;
        UpdateBulletCountText();
    }

    // Actualiza el texto en pantalla
    private void UpdateBulletCountText()
    {
        bulletCountText.text = "Balas disparadas: \n " + bulletCount.ToString();
    }
}
