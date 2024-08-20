using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public float spawnRate = .2f;
    public float spawnDistance = 50f;
    public float moveSpeed = 10f;

    private float timeSinceLastSpawn = 0f;

    void Update()
    {
        timeSinceLastSpawn += Time.deltaTime;

        if (timeSinceLastSpawn >= spawnRate)
        {
            SpawnEnemy();
            timeSinceLastSpawn = 0f;
        }
    }

    void SpawnEnemy()
    {

        // Calcula una posición de spawn aleatoria
        Vector3 spawnPosition = new Vector3(
            Random.Range(-spawnDistance, spawnDistance),
            0f,
            Random.Range(-spawnDistance, spawnDistance)
        );

        // Instancia el enemigo en la posición calculada
        GameObject enemy = Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);

        // Calcula la dirección de movimiento hacia la cámara (o hacia el centro, si lo prefieres)
        Vector3 moveDirection = -spawnPosition.normalized;

        // Ajusta la velocidad del Rigidbody para mover el enemigo
        Rigidbody rb = enemy.GetComponent<Rigidbody>();
        rb.velocity = moveDirection * moveSpeed;

        // Ajusta la rotación del enemigo para que mire en la dirección de movimiento
        if (rb != null)
        {
            // Calcula la rotación en base a la dirección de movimiento
            Quaternion targetRotation = Quaternion.LookRotation(moveDirection, Vector3.up);

            // Ajusta la rotación para que el frente del enemigo (eje X) mire en la dirección de movimiento
            enemy.transform.rotation = Quaternion.Euler(targetRotation.eulerAngles.x, targetRotation.eulerAngles.y + 90f, targetRotation.eulerAngles.z);
        }
    }
}
