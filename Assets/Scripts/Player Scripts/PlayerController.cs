using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float min_Y, max_Y;
    [SerializeField] private GameObject playerBullet;
    [SerializeField] private Transform firePoint;
    [SerializeField] private float attackTimer;
    private float currentAttackTimer;
    private bool canFire;

    private void Start()
    {
        currentAttackTimer = attackTimer;
    }
    void Update()
    {
        PlayerMovement();
        FireBullet();
    }

    void PlayerMovement()
    {
        if (Input.GetAxisRaw("Vertical") > 0f)
        {
            Vector3 temp = transform.position;
            temp.y += speed * Time.deltaTime;


            if (temp.y > max_Y)
            {
                temp.y = max_Y;
            }

            transform.position = temp;
        }
        else if (Input.GetAxisRaw("Vertical") < 0f)
        {
            Vector3 temp = transform.position;
            temp.y -= speed * Time.deltaTime;


            if (temp.y < min_Y)
            {
                temp.y = min_Y;
            }

            transform.position = temp;
        }
    }//PlayerMovement
        private void FireBullet()
        {
            attackTimer += Time.deltaTime;
            if (currentAttackTimer < attackTimer)
            {
                canFire = true;

            }
            if (Input.GetKeyDown(KeyCode.F))
            {
                if (canFire)
                {
                    canFire = false;
                    attackTimer = 0f;
                    Instantiate(playerBullet, firePoint.position, Quaternion.identity);

                }
            }
        }//FireBullet
    
}//class