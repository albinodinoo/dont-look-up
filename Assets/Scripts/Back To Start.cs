using UnityEngine;
using UnityEngine.SceneManagement;
public class BackToStart : MonoBehaviour
{
    public void LoadScene(string Scene){
        SceneManager.LoadScene(Scene);
    }

}
