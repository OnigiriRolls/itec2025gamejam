using UnityEngine;
using UnityEngine.AI;

public class Agent : MonoBehaviour
{
    [SerializeField]
    private Transform destination;
    public NavMeshAgent agent;
    public Animator animator;

    public float attackDistance = 2f;
    public float attackRate = 1f;
    public float damage = 10f;
    private float nextAttackTime = 5f;
    private bool isDead = false;
    // [SerializeField]
    private PlayerHealth playerHealth;



    void Start()
    {
        agent.stoppingDistance = attackDistance - 1.5f;

        if (destination == null)
            destination = GameObject.FindWithTag("Player").transform;

        if (playerHealth == null && destination != null)
            playerHealth = destination.GetComponent<PlayerHealth>();
    }
    void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {

        if (isDead || destination == null) return;

        float distance = Vector3.Distance(transform.position, destination.position);
        agent.SetDestination(destination.position);

        animator.SetBool("run", agent.velocity.magnitude > 0.1f);
        Debug.Log(distance+"---dist");
        if (distance <= 20f)
        {
            agent.isStopped = true;
            animator.SetBool("attack", true);

            if (Time.time >= nextAttackTime)
            {
                nextAttackTime = Time.time + attackRate;

                if (playerHealth != null)
                {
                    playerHealth.LoseLife(damage);
                    Debug.Log("Enemy attacked player for " + damage);
                }
            }
        }
        else
        {
            agent.isStopped = false;
            animator.SetBool("attack", false);
        }
    }
}
