using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Arrow : MonoBehaviour
{
    public float destroyTime = 2f; // ȭ���� ������� �ð� (��)
    public int damageAmount = 10; // �����
    public int scoreValue = 5; // ��ü�� �ı��� �� ���� ����

    // Start is called before the first frame update
    void Start()
    {
        // ���� �ð��� ���� �� ȭ���� �ı�
        Destroy(gameObject, destroyTime);
    }

    // �浹 ����
    void OnTriggerEnter2D(Collider2D other)
    {
        // �浹�� ����� "Enemy" �±׸� ���� ��쿡�� ó��
        if (other.CompareTag("Enemy"))
        {
            // ����� ����
            EnemyHealth enemyHealth = other.GetComponent<EnemyHealth>();
            if (enemyHealth != null)
            {
                enemyHealth.TakeDamage(damageAmount);

                // �������� ���� ��ġ �̻��̸� ��ü�� �ı��ϰ� ������ �߰�
                if (enemyHealth.GetCurrentHealth() <= 0)
                {
                    DestroyEnemy(other.gameObject);
                    UpdateScore();
                }
            }

            // ȭ�� �ı�
            Destroy(gameObject);
        }
    }

    // ��ü �ı� �� ���� ����
    void DestroyEnemy(GameObject enemy)
    {
        // �ڵ� �߰�
        Destroy(enemy);
    }

    // UI �ؽ�Ʈ���� ���� ����
    void UpdateScore()
    {
        // ���⿡ UI �ؽ�Ʈ���� ������ �����ϴ� ó���� �߰��� �� �ֽ��ϴ�.
        // ���� ���, ScoreManager.AddScore(scoreValue) ���� �޼��带 ȣ���մϴ�.
    }

    void Update()
    {
        transform.right = GetComponent<Rigidbody2D>().velocity;
    }
}
