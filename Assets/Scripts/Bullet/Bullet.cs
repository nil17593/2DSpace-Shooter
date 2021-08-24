using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float deactivateTimer;

    [HideInInspector] public bool is_EnemyBullet = false;

    private void Start()
    {
        if (is_EnemyBullet)
            speed *= -1f;
        Invoke("DeactivateBullet", deactivateTimer);

    }
    void Update()
    {
        Move();
    }

    void Move()
    {
        Vector2 temp = transform.position;
        temp.x += speed * Time.deltaTime;
        transform.position = temp;
    }

    void DeactivateBullet()
    {
        gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D target)
    {
        if (target.gameObject.GetComponent<EnemyScript>() != null && target.gameObject.GetComponent<Bullet>()!=null)
        {
            gameObject.SetActive(false);
        }
    }

}
