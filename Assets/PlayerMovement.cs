using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(BoxCollider2D), typeof(Animator))]
public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;         // Скорость перемещения
    public float jumpForce = 12f;        // Сила прыжка
    public LayerMask groundLayer;        // Слой земли
    public float strongAttackDamage = 20f; // Урон от сильного удара
    public float attackRadius = 1f;       // Радиус удара

    private Rigidbody2D rb;              // Ссылка на Rigidbody2D
    private BoxCollider2D box;           // Ссылка на BoxCollider2D
    private Animator animator;           // Ссылка на Animator

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        box = GetComponent<BoxCollider2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        // Движение
        float moveInput = Input.GetAxisRaw("Horizontal");
        rb.linearVelocity = new Vector2(moveInput * moveSpeed, rb.linearVelocity.y);  // Перемещение

        // Устанавливаем параметр "Speed" в аниматор
        animator.SetFloat("Speed", Mathf.Abs(rb.linearVelocity.x));

        // Прыжок
        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded())
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce); // Прыжок по оси Y
        }

        // Сильный удар (правый клик)
        if (Input.GetMouseButtonDown(1))  // 1 — правый клик мыши
        {
            StrongAttack();
        }
    }

    // Проверка, что персонаж находится на земле
    bool IsGrounded()
    {
        return box.IsTouchingLayers(groundLayer); // Проверка касания с землёй
    }

    // Метод сильного удара
    void StrongAttack()
    {
        // Проверка, есть ли враги в радиусе атаки
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(transform.position, attackRadius, LayerMask.GetMask("Enemy"));

        foreach (Collider2D enemy in hitEnemies)
        {
            Enemy enemyScript = enemy.GetComponent<Enemy>();
            if (enemyScript != null)
            {
                enemyScript.TakeDamage(strongAttackDamage);  // Наносим урон врагу
                Debug.Log("Enemy hit!");
            }
        }
    }

    // Для отладки: видим радиус сильного удара
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRadius);  // Радиус удара
    }
}
