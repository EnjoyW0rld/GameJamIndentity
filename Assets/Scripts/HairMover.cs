using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HairMover : MonoBehaviour
{
    public GameObject hair;
    public string PlayScene;
    GameObject hairOriginal;
    Transform HairTransform;

    string sceneName;
    private static HairMover instance;

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
        // SceneManager.MoveGameObjectToScene(hair, SceneManager.GetSceneByName(PlayScene));

        //StartCoroutine(LoadYourAsyncScene());
        MySceneManager.MoveToScene(PlayScene);
    }

    // Start is called before the first frame update
    void Start()
    {
        if (instance != null && instance != this)
        {
            //instance = null;
            //Destroy(gameObject);
            //return;
        }
        DontDestroyOnLoad(gameObject);
        instance = this;
        SceneManager.activeSceneChanged += SceneChange;
    }

    private void SceneChange(Scene prevScene, Scene nextScene)
    {
        if (prevScene.name == "TestScene")
        {
            //DestroyImmediate(instance.gameObject);
            //Destroy(instance.gameObject);
            SceneManager.activeSceneChanged -= this.SceneChange;
            instance = null;
            return;
        }

        Debug.Log(nextScene.name);
        hairOriginal = GameObject.FindGameObjectWithTag("Hair");
        HairTransform = hairOriginal.GetComponent<Transform>();
        Move(HairTransform);
        //Scene currentScene = nextScene;
        //sceneName = currentScene.name;

        //if (sceneName == "PlayScene")
        //{

        //}
    }

    public void Move(Transform newParent)
    {

        this.transform.SetParent(newParent, false);
    }


    // Update is called once per frame
    void Update()
    {

    }
}
