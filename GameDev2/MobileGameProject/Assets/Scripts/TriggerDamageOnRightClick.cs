using UnityEngine;

public class TriggerDamageOnRightClick : MonoBehaviour
{
    public float damageAmount = 10f;  // Amount of damage to deal to enemies
    private Collider[] enemiesInRange; // Array to hold enemies inside the trigger

    void Update()
    {
        // Check for right-click (Mouse Button 1) to trigger the damage action
        if (Input.GetMouseButtonDown(1))  // 1 = Right mouse button
        {
            DealDamageToEnemies();
        }
    }

    void DealDamageToEnemies()
    {
        // Get all colliders within the trigger area
        enemiesInRange = Physics.OverlapBox(transform.position, transform.localScale / 2, Quaternion.identity);

        // Loop through all colliders and apply damage if they are tagged as "Enemy"
        foreach (Collider col in enemiesInRange)
        {
            if (col.CompareTag("Enemy"))
            {
                // Assuming the enemy has a health script with a TakeDamage method
                EnemyHealth enemyHealth = col.GetComponent<EnemyHealth>();
                if (enemyHealth != null)
                {
                    enemyHealth.TakeDamage(damageAmount);  // Deal damage to the enemy
                }
            }
        }
    }

    void OnDrawGizmos()
    {
        // Optionally visualize the trigger area in the scene view for easier debugging
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(transform.position, transform.localScale);
    }
}