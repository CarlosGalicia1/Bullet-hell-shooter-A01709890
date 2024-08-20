using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int damage = 1;

    void OnCollisionEnter(Collision collision)
    {
        if (gameObject.layer == LayerMask.NameToLayer("PlayerBullets") && collision.gameObject.layer == LayerMask.NameToLayer("Boss"))
        {
            Health health = collision.gameObject.GetComponent<Health>();
            if (health != null)
            {
                health.TakeDamage(damage);
            }
            Destroy(gameObject);
        }
        else if (gameObject.layer == LayerMask.NameToLayer("BossBullets") && collision.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            Health health = collision.gameObject.GetComponent<Health>();
            if (health != null)
            {
                health.TakeDamage(damage);
            }
            Destroy(gameObject);
        }

        else if (gameObject.layer == LayerMask.NameToLayer("PlayerBullets") && collision.gameObject.layer == LayerMask.NameToLayer("Enemies"))
        {
            Destroy(gameObject);
            Destroy(collision.gameObject);
        }
    } 

}
