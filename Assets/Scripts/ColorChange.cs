using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ColorChange : MonoBehaviour
{
    public GameObject hair;
    public Color32 newcolor;
    public string PlayScene;
    // Start is called before the first frame update
    void Start()
    {
        hair = GameObject.FindGameObjectWithTag("Player");
        hair.GetComponent<SpriteRenderer>().color = newcolor;
    }

    IEnumerator LoadYourAsyncScene()
    {
        // Set the current Scene to be able to unload it later
        Scene currentScene = SceneManager.GetActiveScene();

        // The Application loads the Scene in the background at the same time as the current Scene.
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(PlayScene, LoadSceneMode.Additive);

        // Wait until the last operation fully loads to return anything
        while (!asyncLoad.isDone)
        {
            yield return null;
        }

        // Move the GameObject (you attach this in the Inspector) to the newly loaded Scene
        SceneManager.MoveGameObjectToScene(hair, SceneManager.GetSceneByName(PlayScene));
        // Unload the previous Scene
        SceneManager.UnloadSceneAsync(currentScene);
    }

    // Update is called once per frame
    public void NextScene()
    {
        StartCoroutine(LoadYourAsyncScene());
    }
}
