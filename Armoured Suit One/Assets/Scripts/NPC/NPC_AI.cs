using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC_AI : MonoBehaviour // NPC�� ���� �� �ൿ�� ������
{
    public enum NPCSTATE
    {
        IDLE = 0,
        MOVE,
        SEARCH,
        CHASE,
        ATTACK,
        EVASION,
        DESTROY
    }

    [SerializeField]
    public NPCSTATE npcState;

    public float npcSpeed = 10f;
    public float npcSpeedX;
    public float npcRotSpeed = 0.1f;
    public float acceleration = 0.001f;

    public GameObject mainTarget;
    public GameObject fallingEffect;
    public GameObject deathEffect;

    public Radar_Mgr radarMgr;
    public Front_Range_Check frontRangeCheck;
    public NPC_Weapon_Mgr weaponMgr;
    public NPC_Mgr npc;
    public NPC_HitCheck hitCheck;

    public float stateCurTime;
    public float stateCoolTime = 5f;
    public float attackCurTime;
    public float attackCoolTime = 5f;
    public float deathTime = 3f;

    public Vector3 evasionDirection;
    public Vector3 moveDirection;    

    public bool isCrashed = false;

    public float curTime;
    public float coolTime = 1f;

    public float chaseCurTime;
    public float chaseCoolTime = 10f;
    public float evasionCurTime;
    public float evasionCoolTime = 10f;

    void Start()
    {
        moveDirection = Vector3.forward;
        npc = GetComponent<NPC_Mgr>();
        npcSpeed = npc.speed; // ������ ���̽����� ������ ������
        npcSpeedX = npcSpeed;
    }

    void Update()
    {
        if (isCrashed) // �浹 �� ���� �浹 ����� �ϰԲ� ���� �߰�.
        {
            curTime += Time.deltaTime;
            if (npcSpeedX >= 0)
            {
                npcSpeedX += - acceleration * npcSpeed;
            }
            if (curTime > coolTime)
            {
                curTime = 0;
                isCrashed = false;
                moveDirection = Vector3.forward;
            }
        }
        NPCMove(npcSpeedX);
        if (!isCrashed)
        {
            NPCLogic();
        }
    }

    public void NPCLogic()
    {
        switch (npcState)
        {
            case NPCSTATE.IDLE:
                mainTarget = null;
                hitCheck.isDamaged = false;
                npcState = NPCSTATE.MOVE;
                break;
            case NPCSTATE.MOVE:
                if (npcSpeedX <= npcSpeed)
                {
                    npcSpeedX += acceleration * npcSpeed;
                }
                else
                {
                    npcSpeedX = npcSpeed;
                }
                if (radarMgr.targets.Count > 0 && radarMgr.targets[0] != null)
                {
                    int rnd = Random.Range(0, radarMgr.targets.Count);
                    stateCurTime += Time.deltaTime;
                    if (stateCurTime > stateCoolTime)
                    {                        
                        mainTarget = radarMgr.targets[rnd];
                        npcState = NPCSTATE.SEARCH;
                        stateCurTime = 0;
                    }
                }                
                break;
            case NPCSTATE.SEARCH: // ���� ������ ����.
                npcState = NPCSTATE.CHASE;
                break;
            case NPCSTATE.CHASE:
                if (mainTarget != null)
                {
                    Vector3 dir = mainTarget.transform.position - transform.position;
                    Debug.DrawLine(mainTarget.transform.position, transform.position, Color.red);
                    dir.Normalize();
                    transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(dir), npcRotSpeed * Time.deltaTime);
                    if (frontRangeCheck.isRanged)
                    {
                        if (npcSpeedX <= 1.5f * npcSpeed)
                        {
                            npcSpeedX += acceleration * npcSpeed;
                        }
                        else
                        {
                            npcSpeedX = npcSpeed;
                        }
                        attackCurTime += Time.deltaTime;
                        if (attackCurTime > attackCoolTime)
                        {
                            chaseCurTime = 0;
                            attackCurTime = 0;
                            npcState = NPCSTATE.ATTACK;
                        }
                    }
                    else if (!frontRangeCheck.isRanged)
                    {
                        chaseCurTime += Time.deltaTime;
                        if (chaseCurTime >= chaseCoolTime)
                        {
                            chaseCurTime = 0;
                            npcState = NPCSTATE.EVASION;
                        }
                    }
                    else
                    {
                        npcState = NPCSTATE.IDLE;
                    }
                }
                else
                {
                    npcState = NPCSTATE.IDLE;
                }
                break;
            case NPCSTATE.ATTACK:
                weaponMgr.mainTarget = mainTarget;
                weaponMgr.NPCBulletFire();
                attackCurTime += Time.deltaTime;
                if (attackCurTime > attackCoolTime)
                {
                    attackCurTime = 0;
                    npcState = NPCSTATE.IDLE;
                }
                break;
            case NPCSTATE.EVASION:
                evasionCurTime += Time.deltaTime;                
                transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(evasionDirection), npcRotSpeed * Time.deltaTime);
                npcSpeedX = 1.2f * npcSpeed;
                if (evasionCurTime > evasionCoolTime)
                {
                    evasionCurTime = 0;
                    npcState = NPCSTATE.IDLE;
                }
                break;
            case NPCSTATE.DESTROY:                
                npcSpeedX = 1.5f * npcSpeed;
                if (!hitCheck.isDead)
                {
                    hitCheck.isDead = true;
                    StartCoroutine("NPCDie"); // ���� �� ���� �ð� ���� �� ������ �ϱ� ���� �ڷ�ƾ ���.                    
                }
                break;
            default:
                break;
        }
    }

    public void NPCMove(float speed)
    {
        transform.Translate(moveDirection * speed * Time.deltaTime);
    }

    IEnumerator NPCDie()
    {
        fallingEffect.SetActive(true);
        yield return new WaitForSeconds(deathTime);
        Instantiate(deathEffect, transform.position, transform.rotation);
        gameObject.SetActive(false);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag != "PlayerBullet" || collision.gameObject.tag != "EnemyBullet" || collision.gameObject.tag != "AllyBullet")
        {
            Vector3 dir = collision.transform.position - transform.position;
            moveDirection = Vector3.Reflect(dir, collision.contacts[0].normal);
            isCrashed = true;
        }
    }
}
