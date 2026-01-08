using UnityEngine;

public abstract class IsCollectible : MonoBehaviour
{   
    void OnTriggerEnter(Collider Other)
    {
        if (Other.CompareTag("Player"))
        {
            CodeUI.Instance.Visable();
        }
    }

    void OnTriggerExit(Collider Other)
    {
        if (Other.CompareTag("Player"))
        {
            CodeUI.Instance.Invisable();
        }
    }

    void OnTriggerStay(Collider Other)
    {
        if (Other.CompareTag("Player"))
        {
            if (Input.GetKeyDown(KeyCode.Return))
            {
                int Answer = CodeUI.Instance.GetCode();
                TryingToAwnser(Answer);
            }
        }
    }
    public abstract void TryingToAwnser(int Answer);
}
