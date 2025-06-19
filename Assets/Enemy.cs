using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float health = 100f;          // ��������� �������� �����
    public float moveSpeed = 2f;        // �������� �������� �����
    private Rigidbody2D rb;             // ������ �� Rigidbody2D ��� ��������

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // ������ �������� ���������: ���� ��������� �����
        rb.linearVelocity = new Vector2(-moveSpeed, rb.linearVelocity.y);

        // ���� �������� <= 0, ���������� �����
        if (health <= 0)
        {
            Die();
        }
    }

    // ����� ��������� �����
    public void TakeDamage(float damage)
    {
        health -= damage;
        Debug.Log("Enemy Health: " + health);
    }

    // ����� ����������� �����
    void Die()
    {
        Debug.Log("Enemy died!");
        Destroy(gameObject);  // ���������� �����
    }
}
