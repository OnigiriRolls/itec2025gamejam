using UnityEngine;

public class ActivateEnemy : MonoBehaviour
{
    public GameObject enemy;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
            enemy.SetActive(true);
        if (other.CompareTag("Enemy"))
            other.gameObject.SetActive(false);
    }
}
