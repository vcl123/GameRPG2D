using UnityEngine;

public class SlimeKingBoss : MonoBehaviour
{
    public float moveSpeed = 1.5f;
    public float attackRange = 2f;
    public Transform player;

    private Animator animator;
    private Rigidbody2D rb;
    private Vector2 movement;
    private float attackCooldown = 2f;
    private float lastAttackTime;

    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        if (player == null) return;

        float distance = Vector2.Distance(transform.position, player.position);
        Vector2 direction = (player.position - transform.position).normalized;

        if (distance <= attackRange && Time.time - lastAttackTime >= attackCooldown)
        {
            // Attack
            movement = Vector2.zero;
            animator.SetBool("IsAttacking", true);
            lastAttackTime = Time.time;
        }
        else if (distance > attackRange)
        {
            // Move
            movement = direction;
            animator.SetBool("IsAttacking", false);
        }

        animator.SetFloat("Speed", movement.magnitude);
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }
}
