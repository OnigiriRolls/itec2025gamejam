using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed = 20f;
    private float damage;

    public void Initialize(float dmg)
    {
        damage = dmg;
        Destroy(gameObject, 5f);
    }

    void Update()
    {
        transform.position += transform.forward * speed * Time.deltaTime;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            other.GetComponent<EnemyHealth>().LoseLife(damage);
            Debug.Log("Hit enemy for " + damage + " damage!");
            Destroy(gameObject);
        }
    }
}
