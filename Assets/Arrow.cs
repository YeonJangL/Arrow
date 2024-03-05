using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Arrow : MonoBehaviour
{
    public float destroyTime = 2f; // 화살이 사라지는 시간 (초)
    public int damageAmount = 10; // 대미지
    public int scoreValue = 5; // 물체를 파괴할 때 얻을 점수

    // Start is called before the first frame update
    void Start()
    {
        // 일정 시간이 지난 후 화살을 파괴
        Destroy(gameObject, destroyTime);
    }

    // 충돌 감지
    void OnTriggerEnter2D(Collider2D other)
    {
        // 충돌한 대상이 "Enemy" 태그를 가진 경우에만 처리
        if (other.CompareTag("Enemy"))
        {
            // 대미지 적용
            EnemyHealth enemyHealth = other.GetComponent<EnemyHealth>();
            if (enemyHealth != null)
            {
                enemyHealth.TakeDamage(damageAmount);

                // 데미지가 일정 수치 이상이면 물체를 파괴하고 점수를 추가
                if (enemyHealth.GetCurrentHealth() <= 0)
                {
                    DestroyEnemy(other.gameObject);
                    UpdateScore();
                }
            }

            // 화살 파괴
            Destroy(gameObject);
        }
    }

    // 물체 파괴 및 점수 갱신
    void DestroyEnemy(GameObject enemy)
    {
        // 코드 추가
        Destroy(enemy);
    }

    // UI 텍스트에서 점수 갱신
    void UpdateScore()
    {
        // 여기에 UI 텍스트에서 점수를 갱신하는 처리를 추가할 수 있습니다.
        // 예를 들어, ScoreManager.AddScore(scoreValue) 등의 메서드를 호출합니다.
    }

    void Update()
    {
        transform.right = GetComponent<Rigidbody2D>().velocity;
    }
}
