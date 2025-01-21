using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public float health = 10f;
    public void TakeDamage(float damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Destroy(gameObject);
        }
        else
        {
            Debug.Log("I took" + damage + " damage");
        }
    }
}
