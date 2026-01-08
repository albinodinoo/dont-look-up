using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class InvisEnemy : MonoBehaviour
{
    public Transform Player;
    public TileManager WalkManager;
    private Vector3 DirToPlayer;
    private float Distance;
    private bool PlayerDetected;
    [SerializeField] AudioSource whissle;
    void Start()
    {
        NewDistinaion();
    }

    // Update is called once per frame
    void Update()
    {
        CheckForPlayer();
       // print(Vector3.Distance(Player.transform.position, transform.position));
        if(Vector3.Distance(Player.transform.position, transform.position) < 50f){
            if(whissle.isPlaying == false)
            {   
                print("Play");
                 whissle.Play();
            }
        }
        else
        {
            //print("Trying to");
            if(whissle.isPlaying == true)
            {
                print("Pause");
                 whissle.Pause();
            }
        }
    }
    public void NewDistinaion()
    {   
        Tile NewDist = GetRandomTile();
        if(Vector3.Distance(Player.transform.position, NewDist.Position) > 50f){
        transform.position = NewDist.Position;
        StartCoroutine(TeleportTimer());
        }
        else
        {
        NewDistinaion();
        }
    }

    IEnumerator TeleportTimer()
    {   
        yield return new WaitForSeconds(30f);
        if(!PlayerDetected){
        NewDistinaion();
        }
        else
        {
        StartCoroutine(TeleportTimer());    
        }
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

    bool LineOfSight()
    {   
        Vector3 Target = new Vector3(Player.position.x, Player.position.y - 1.5f, Player.position.z);
        DirToPlayer = (Target - transform.position).normalized;
        Distance = Vector3.Distance(transform.position, Target);
        if(Physics.Raycast(transform.position + Vector3.up, DirToPlayer, out RaycastHit hit)){
            if (hit.collider.CompareTag("Player"))
            {
                Debug.DrawRay(transform.position + Vector3.up, DirToPlayer * 20f, Color.green);
                return true;
            }
            else
            {   
                Debug.DrawRay(transform.position + Vector3.up, DirToPlayer * 20f, Color.red);
            }
        }
        return false;
    }
    void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            print("Player Dead");
                if(LineOfSight()){
                SceneManager.LoadScene("Death By Invis");
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
            }
        }
    }
    void CheckForPlayer()
    {
        if(Vector3.Distance(Player.transform.position, transform.position) < 50f){
            //print("Trying to stop");
            PlayerDetected = true;
        }
        else
        {
            PlayerDetected = false;
        }
    }
}
