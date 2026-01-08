using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

public class MainMenuEvent : MonoBehaviour
{
    private UIDocument Document;

    private Button SButton;
    void Awake()
    {
        Document = GetComponent<UIDocument>();
        SButton = Document.rootVisualElement.Q("StartButton") as Button;
        SButton.RegisterCallback<ClickEvent>(OnClick);
    }

    void OnClick(ClickEvent Event)
    {
        SceneManager.LoadScene("Maze Runner");

    }
    void Update()
    {
        
    }
}
