using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Move : MonoBehaviour // 플레이어의 이동과 충돌 시 반작용 기작을 구현함.
{
    public float speed = 10f;
    public float speedX;
    public float acceleration = 0.1f;
    public float rotSpeed = 30f;
    public float busterRegen = 100f;

    public Vector3 moveDirection;

    public float curTime;
    public float coolTime = 1f;

    public bool isCrashed = false;
    public bool isBoosterOver = false;
    public GameObject boosterEffect;

    public Player_Mgr player;
    public GameObject boosterOverText;

    void Start()
    {
        player = GetComponent<Player_Mgr>();
        boosterOverText = GameObject.Find("BoosterOverText");
        speed = player.flightSpeed;
        speedX = speed;
        moveDirection = Vector3.forward;
    }

    void Update()
    {
        PlayerMove(speed);
        Equilibrate(speed);
    }

    public void PlayerMove(float speed)
    {
        if (isCrashed)
        {
            curTime += Time.deltaTime;
            if (speedX >= 0)
            {
                speedX += -10f * acceleration * speed;
            }
            if (curTime > coolTime)
            {
                curTime = 0;
                isCrashed = false;
                moveDirection = Vector3.forward;
            }
        }

        transform.Translate(moveDirection * speedX * Time.deltaTime);

        if (Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.LeftShift) && !isCrashed)
        {
            var emission = boosterEffect.GetComponent<ParticleSystem>().emission;
            emission.rateOverTime = 60f;
            if (speedX > 1.5f * speed)
            {
                speedX += -acceleration * speed;
            }
            else if (speedX <= 1.5f * speed)
            {
                speedX += acceleration * speed;
            }
        }
        else if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.LeftShift) && isBoosterOver && !isCrashed)
        {
            var emission = boosterEffect.GetComponent<ParticleSystem>().emission;
            emission.rateOverTime = 60f;
            if (speedX > 1.5f * speed)
            {
                speedX += -acceleration * speed;
            }
            else if (speedX <= 1.5f * speed)
            {
                speedX += acceleration * speed;
            }
        }
        if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.LeftShift) && !isCrashed && !isBoosterOver && player.flightBooster > 0)
        {
            var emission = boosterEffect.GetComponent<ParticleSystem>().emission;
            emission.rateOverTime = 120f;
            player.flightBooster -= 1;            
            if (speedX <= 2f * speed)
            {
                speedX += 2f * acceleration * speed;
            }
        }
        else
        {
            if (player.flightBooster < player.maxflightBooster)
            {
                isBoosterOver = true;
                boosterOverText.SetActive(true);
            }
            else
            {
                isBoosterOver = false;
                boosterOverText.SetActive(false);
            }
        }
        if (player.flightBooster < player.maxflightBooster)
        {
            if (isBoosterOver)
            {
                player.flightBooster += (int)(busterRegen * Time.deltaTime);
            }
        }
        else
        {
            player.flightBooster = player.maxflightBooster;
        }
        if (Input.GetKey(KeyCode.S) && !isCrashed)
        {
            if (speedX >= 0)
            {
                speedX += -acceleration * speed;
            }
        }
        if (Input.GetKey(KeyCode.A) && !isCrashed)
        {
            transform.Rotate(0, 0, rotSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.D) && !isCrashed)
        {
            transform.Rotate(0, 0, -rotSpeed * Time.deltaTime);
        }
    }

    public void Equilibrate(float speed) //정상 속도로 돌려주는 기능
    {
        if (!Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.S))
        {
            var emission = boosterEffect.GetComponent<ParticleSystem>().emission;
            emission.rateOverTime = 30f;
            if (speedX > speed)
            {
                speedX += -acceleration * speed;
            }
            else if (speedX <= speed)
            {
                speedX += acceleration * speed;
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag != "PlayerBullet" || collision.gameObject.tag != "EnemyBullet")
        {
            Vector3 dir = collision.transform.position - transform.position;
            moveDirection = Vector3.Reflect(dir, collision.contacts[0].normal);
            isCrashed = true;
            //Debug.Log("충돌함");
        }
    }
}
