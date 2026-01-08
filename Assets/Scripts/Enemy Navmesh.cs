using UnityEngine;
using UnityEngine.AI;
using System.Collections;
using UnityEngine.SceneManagement;

public class EnemyNavmesh : MonoBehaviour
{
    public Transform Player;
    public NavMeshAgent Agent;
    public TileManager WalkManager;

    //Used To calulate Line of Sigth
    private Vector3 DirToPlayer;
    private float Distance;
    private float Angle;
    [Header("Enemy Vision")]
    public float SightRange;
    public float SightAngle;
    public Light MonsterLight;
    private bool IsAttacking = false;


    void Start()
    {
        Agent = GetComponent<NavMeshAgent>();
        NewDistinaion();
    }

    
    void Update()
    {   
        Vision();
        if(Agent.remainingDistance < 2 && !Agent.isStopped && !Agent.pathPending)
        {   
            StartCoroutine(Resume());
        }
        if (IsAttacking)
        {
            Agent.SetDestination(Player.position);
        }
    }
    IEnumerator Resume()
    {   
        Agent.isStopped = true;
        yield return new WaitForSeconds(1f);
        NewDistinaion();
        Agent.isStopped = false;
    }
    void NewDistinaion()
    {   
        Tile NewDist = GetRandomTile();
        Debug.Log(NewDist.Position);
        Agent.SetDestination(NewDist.Position);
    }
    Tile GetRandomTile()
    {
        int W = Random.Range(0, WalkManager.Width);
        int H = Random.Range(0, WalkManager.Height);
        if(WalkManager.Array[W,H] != null && WalkManager.Array != null)
        {
        Tile RandomTile = WalkManager.Array[W,H];
        return RandomTile;
        }
        return null;
    }
    void Vision()
    {   
        Vector3 Target = new Vector3(Player.position.x, Player.position.y - 1.5f, Player.position.z);
        DirToPlayer = (Target - transform.position).normalized;
        Distance = Vector3.Distance(transform.position, Target);
        Angle = Vector3.Angle(transform.forward, DirToPlayer);

        if(Distance <= SightRange && Angle <= SightAngle)
        {   
            if(Physics.Raycast(transform.position + Vector3.up, DirToPlayer, out RaycastHit hit, SightRange)){
                if (hit.collider.CompareTag("Player"))
                {
                    Debug.DrawRay(transform.position + Vector3.up, DirToPlayer * SightRange, Color.green);
                    Attack();
                }
                else
                {   
                    Debug.DrawRay(transform.position + Vector3.up, DirToPlayer * SightRange, Color.red);
                }
            }
        }
    }

    void Attack()
    {
        Agent.SetDestination(Player.position);
        if (!IsAttacking)
        {
            IsAttacking = true;
            StartCoroutine(AttackTimer());
        }

    }
    IEnumerator AttackTimer()
    {   
        MonsterLight.color = Color.red;
        yield return new WaitForSeconds(15f);
        Agent.isStopped = true;
        MonsterLight.color = Color.white;
        yield return new WaitForSeconds(5f);
        NewDistinaion();
        Agent.isStopped = false;
        IsAttacking = false;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            print("Player Dead");
            SceneManager.LoadScene("Death By Monster");
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }

    }


}

