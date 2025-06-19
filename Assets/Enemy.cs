using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float health = 100f;          // Начальное здоровье врага
    public float moveSpeed = 2f;        // Скорость движения врага
    private Rigidbody2D rb;             // Ссылка на Rigidbody2D для движения

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Пример простого поведения: враг двигается влево
        rb.linearVelocity = new Vector2(-moveSpeed, rb.linearVelocity.y);

        // Если здоровье <= 0, уничтожаем врага
        if (health <= 0)
        {
            Die();
        }
    }

    // Метод получения урона
    public void TakeDamage(float damage)
    {
        health -= damage;
        Debug.Log("Enemy Health: " + health);
    }

    // Метод уничтожения врага
    void Die()
    {
        Debug.Log("Enemy died!");
        Destroy(gameObject);  // Уничтожаем врага
    }
}
