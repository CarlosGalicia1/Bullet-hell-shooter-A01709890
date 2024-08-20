using UnityEngine;
using TMPro;

public class HealthDisplay : MonoBehaviour
{
    // Referencias a los objetos TextMeshPro para mostrar la salud
    public TextMeshProUGUI playerHealthText;
    public TextMeshProUGUI bossHealthText;

    public GameOverScreen gameOverScreen; // Referencia al script GameOverScreen

    // Referencias a los scripts de salud del jugador y del jefe
    public Health playerHealth; 
    public Health bossHealth;   

    void Update()
    {
        // Actualiza los textos con los valores actuales de salud
        playerHealthText.text = "Player Health: " + playerHealth.currentHealth;
        bossHealthText.text = "HP del jefe final: " + bossHealth.currentHealth;
        if (playerHealth.currentHealth == 0 || bossHealth.currentHealth == 0)
        {
            gameOverScreen.Setup();
        }
    }
}