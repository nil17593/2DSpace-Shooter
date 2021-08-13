using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float deactivateTimer;

    private void Start()
    {
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

}
