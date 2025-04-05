using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public float health;

    void Start()
    {
        health = 100;
    }

    public void LoseLife(float damage)
    {
        health -= damage;
        if (health < 0)
        {
            Destroy(gameObject);
        }
    }
}
