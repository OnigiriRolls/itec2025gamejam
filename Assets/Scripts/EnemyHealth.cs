using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public float health;
    [SerializeField]
    private Animator animator;
    private bool die = false;
    void Start()
    {
        health = 40;
    }

    // public void LoseLife(float damage)
    // {
    //     health -= damage;
    //     if (health < 0)
    //     {
    //         Destroy(gameObject);
    //     }
    // }
    void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public void LoseLife(float damage)
    {
        if (die) return;

        health -= damage;

        if (health <= 0)
        {
            die = true;
            animator.SetTrigger("die"); 
            GetComponent<UnityEngine.AI.NavMeshAgent>().enabled = false;
            StartCoroutine(DestroyAfterDeath()); 
        }
    }

    private System.Collections.IEnumerator DestroyAfterDeath()
    {
        yield return new WaitForSeconds(3f);
        Destroy(gameObject);
    }
}
