using UnityEngine;
using System;
using System.IO;
using System.Collections;

public class ScreenShoots : MonoBehaviour
{    
    [SerializeField] private Camera SecretCamara;
    [SerializeField] private Camera MainCamara;
    public InvisEnemy invis;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            StartCoroutine(WaitToRender());
            print("Hello");
        }
    }

    IEnumerator WaitToRender()
    {
        SecretCamara.enabled = true;
        MainCamara.enabled = false;

        yield return new WaitForEndOfFrame();

        string FolderPath = Path.Combine(Application.persistentDataPath, "Screenshoots");

        //This If-statement was created with the help of AI to prevent the script for failing if the path didnt exist
        if (!Directory.Exists(FolderPath))
        {
            Directory.CreateDirectory(FolderPath);
        }

        ScreenCapture.CaptureScreenshot(Path.Combine(FolderPath,"Screenshoots-" + DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss") + ".png"));
        print(FolderPath);

        SecretCamara.enabled = false;
        MainCamara.enabled = true;

        invis.NewDistinaion();
    }
}
