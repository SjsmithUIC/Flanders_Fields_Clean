using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIControl : MonoBehaviour {


    public void ChangeScene(string sceneName)
    {
        Application.LoadLevel(sceneName);
    }

    public void quitButtonClick()
    {
        Application.Quit();
    }

}
