using UnityEngine;

public class EnemyHealth
{
    public static void TakeDamage(float damage, EnemyData enemyData)
    {
        enemyData.EnemyCurrHealth -= damage;
        if (enemyData.EnemyCurrHealth <= 0)
        {
            enemyData.gameObject.SetActive(false);
        }
    }
}
