using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MySceneManager : MonoBehaviour
{

    public static void MoveToScene(string pSceneName)
    {
        if (SceneManager.GetSceneByName(pSceneName) != null)
        {
            SceneManager.LoadScene(pSceneName);
        }
    }
}
