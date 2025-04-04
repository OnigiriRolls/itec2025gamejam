using System.Collections;
using UnityEngine;

public class EnemyFollow : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float delay = 0.1f;
    public GameObject target;
    public GameObject enemy;
    public float safeDistance = 2f;
    public float deadZone = 0.1f;

    private Rigidbody rb;
    private Vector3 movement;
    private Vector3 lastTargetPosition;
    private bool isDelayed = false;

    void OnEnable()
    {
        rb = enemy.GetComponent<Rigidbody>();
        if (target != null)
        {
            lastTargetPosition = target.transform.position;
        }
    }

    void Update()
    {
        if (target == null) return;

        if (!isDelayed)
        {
            StartCoroutine(UpdateTargetAfterDelay());
        }

        Vector3 bossPosition = enemy.transform.position;
        Vector3 direction = lastTargetPosition - bossPosition;

        float distanceToPlayer = direction.magnitude;

        if (distanceToPlayer < safeDistance - deadZone)
        {
            movement = -direction.normalized * moveSpeed;
        }
        else if (distanceToPlayer > safeDistance + deadZone)
        {
            movement = direction.normalized * moveSpeed;
        }
        else
        {
            movement = Vector3.zero;
        }
    }

    void FixedUpdate()
    {
        rb.linearVelocity = movement;
    }

    IEnumerator UpdateTargetAfterDelay()
    {
        isDelayed = true;
        yield return new WaitForSeconds(delay);

        if (target != null)
        {
            lastTargetPosition = target.transform.position;
        }

        isDelayed = false;
    }
}
