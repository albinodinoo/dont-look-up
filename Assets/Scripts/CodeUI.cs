using UnityEngine;
using TMPro;

public class CodeUI : MonoBehaviour
{   
    public static CodeUI Instance;
    [SerializeField] private TMP_InputField Field;
    void Awake()
    {
        Instance = this;
        Field.gameObject.SetActive(false);
    }
    public void Visable()
    {
        Field.gameObject.SetActive(true);
        Field.text = Application.persistentDataPath;
        Field.Select();
        Field.ActivateInputField();
    }

    public void Invisable()
    {
        Field.gameObject.SetActive(false);
    }

    // Update is called once per frame
    public int GetCode()
    {
        int Code;
        int.TryParse(Field.text, out Code);
        return Code;
    }
}
