using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuButtonCallbacks : MonoBehaviour
{
    public void TravelToGameDelayed()
    {
        Invoke("TravelToGameLevel", .1f);
    }
    public void TravelToGameLevel()
    {
        // https://docs.unity3d.com/ScriptReference/SceneManagement.SceneManager.html
        SceneManager.LoadScene("AdvancedInputSystem");
    }
}
