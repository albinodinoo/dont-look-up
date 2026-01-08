using UnityEngine;

public class BlueEye : IsCollectible
{
    private int RealCode = 812;
    [SerializeField] private EnemyNavmesh Enemy;

    public override void TryingToAwnser(int Awnser)
    {
        print("Real Answer " + RealCode);
        print("Your Answer " + Awnser);
        if(Awnser == RealCode)
        {
            print("Red Eye Optained");
            GetD();
        } 
        else
        {   
            Enemy.Agent.SetDestination(transform.position);
        }
    }
    void GetD()
    {
        Destroy(this.gameObject);
        CodeUI.Instance.Invisable();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
