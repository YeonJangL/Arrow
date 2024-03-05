using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public GameObject ArrowPrefab;
    public Transform Arrow_transform;
    public float shoot_speed;
    
    void LookAt()
    {
        Vector2 mouse_position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 dir = new Vector2(mouse_position.x - Arrow_transform.position.x, mouse_position.y - Arrow_transform.position.y);
        Arrow_transform.right = dir;
    }

    void Fire()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GameObject go = Instantiate(ArrowPrefab, Arrow_transform.position, Arrow_transform.rotation);
            go.GetComponent<Rigidbody2D>().velocity = Arrow_transform.transform.right * shoot_speed;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        LookAt();
        Fire();
    }
}
