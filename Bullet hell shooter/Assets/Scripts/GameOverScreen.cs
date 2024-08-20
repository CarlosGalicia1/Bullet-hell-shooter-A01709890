using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement; // Importante para reiniciar la escena

public class GameOverScreen : MonoBehaviour
{
    public Text resultText; // Texto que mostrará el contador de daño

    // Referencias a los scripts de salud del jugador y del jefe
    public Health playerHealth;
    public Health bossHealth;

    public void Setup()
    {
        gameObject.SetActive(true);

        if (playerHealth.currentHealth <= 0)
        {
            resultText.text = "you lost...";
        }

        else if (bossHealth.currentHealth <= 0)
        {
            resultText.text = "you won!";
        }

        Time.timeScale = 0f; // Detener el tiempo del juego
    }

}
