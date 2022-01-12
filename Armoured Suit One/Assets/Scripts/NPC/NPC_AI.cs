using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC_AI : MonoBehaviour // NPC의 상태 및 행동을 결정함
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

    public Radar_Mgr radarMgr;
    public Front_Range_Check frontRangeCheck;
    public NPC_Weapon_Mgr weaponMgr;    

    public float stateCurTime;
    public float stateCoolTime = 5f;
    public float attackCurTime;
    public float attackCoolTime = 5f;
    public float deathTime = 3f;

    public Vector3 evasionDirection;
    public Vector3 moveDirection;    

    public bool isCrashed = false;
    public bool isDead = false;

    public float curTime;
    public float coolTime = 1f;

    public float chaseCurTime;
    public float chaseCoolTime = 10f;
    public float evasionCurTime;
    public float evasionCoolTime = 10f;

    void Start()
    {
        moveDirection = Vector3.forward;        
    }

    void Update()
    {
        if (isCrashed) // 충돌 시 오직 충돌 운동만을 하게끔 조건 추가.
        {
            curTime += Time.deltaTime;
            if (npcSpeedX >= 0)
            {
                npcSpeedX += - 10f * acceleration * npcSpeed;
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
            case NPCSTATE.SEARCH: // 현재 사용되지 않음.
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
                if (evasionCurTime > evasionCoolTime)
                {
                    evasionCurTime = 0;
                    npcState = NPCSTATE.IDLE;
                }
                break;
            case NPCSTATE.DESTROY:                
                npcSpeedX = npcSpeed;
                if (!isDead)
                {
                    StartCoroutine("NPCDie"); // 격추 시 일정 시간 비행 후 터지게 하기 위해 코루틴 사용.
                    isDead = true;
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
        yield return new WaitForSeconds(deathTime);
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
