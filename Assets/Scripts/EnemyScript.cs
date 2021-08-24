using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float rotateSpeed;
    [SerializeField] private float boundX;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform firePoint;

    public bool canShoot;
    public bool canRotate;
    private bool canMove = true;
    private Animator anim;
    private AudioSource explosionSound;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        explosionSound = GetComponent<AudioSource>();
    }

    private void Start()
    {
        if (canRotate)
        {
            if (Random.Range(0, 2) > 0)
            {
                rotateSpeed = Random.Range(rotateSpeed, rotateSpeed + 20f);
                rotateSpeed *= -1f;
            }
            else
            {
                rotateSpeed = Random.Range(rotateSpeed, rotateSpeed + 20f);
            }
        }

        if (canShoot)
        {
            Invoke("StartShooting", Random.Range(1f, 3f));
        }
    }

    void Update()
    {
        Move();
        RotateEnemy();
    }

    private void Move()
    {
        if (canMove)
        {
            Vector2 temp = transform.position;
            temp.x -= speed * Time.deltaTime;
            transform.position = temp;

            if (temp.x < boundX)
            {
                gameObject.SetActive(false);
            }
        }
    }

    void RotateEnemy()
    {
        if (canRotate)
        {
            transform.Rotate(new Vector3(0f, 0f, rotateSpeed * Time.deltaTime), Space.World);
        }

    }

    void StartShooting()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, Quaternion.identity);
        bullet.GetComponent<Bullet>().is_EnemyBullet=true;

        if (canShoot)
        {
            Invoke("StartShooting", Random.Range(1f, 3f));
        }
    }

    void TurnOffGameObject()
    {
        gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D target)
    {
        if (target.tag=="Bullet")
        {
            canMove = false;

            if (canShoot)
            {
                canShoot = false;
                CancelInvoke("StartShooting");
            }
            Invoke("TurnOffGameObject",1f);

            anim.Play("Destroy");
        }
    }
}
