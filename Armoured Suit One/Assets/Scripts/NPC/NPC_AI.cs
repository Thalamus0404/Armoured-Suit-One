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
    public Vector3 rndDirection;

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
        StartCoroutine("MakeRndDirection");
    }

    void Update()
    {
        if (isCrashed) // �浹 �� ���� �浹 ����� �ϰԲ� ���� �߰�.
        {
            curTime += Time.deltaTime;
            if (npcSpeedX >= 0)
            {
                npcSpeedX += -acceleration * npcSpeed;
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
                    stateCurTime += Time.deltaTime;
                    if (stateCurTime > stateCoolTime)
                    {                        
                        mainTarget = radarMgr.targets[0];
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
                        if (npcSpeedX <= npcSpeed)
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
                            npcState = NPCSTATE.ATTACK;
                            attackCurTime = 0;
                        }
                    }
                    else if (!frontRangeCheck.isRanged)
                    {
                        chaseCurTime += Time.deltaTime;
                        if (chaseCurTime < chaseCoolTime)
                        {

                        }
                        else
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
                StartCoroutine("MakeRndDirection");
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
                    StartCoroutine("NPCDie"); // ���� �� ���� �ð� ���� �� ������ �ϱ� ���� �ڷ�ƾ ���.
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

    IEnumerator MakeRndDirection()
    {
        int rnd = Random.Range(0, 3);
        switch (rnd)
        {
            case 0:
                rndDirection = transform.up;
                break;
            case 1:
                rndDirection = -transform.up;
                break;
            case 2:
                rndDirection = transform.right;
                break;
            case 3:
                rndDirection = -transform.right;
                break;
            default:
                break;
        }
        evasionDirection = rndDirection;
        yield return new WaitForEndOfFrame();
    }
}
