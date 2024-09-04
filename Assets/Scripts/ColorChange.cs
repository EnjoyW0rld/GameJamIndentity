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
        
    }
    public void ChangeColor()
    {
        hair.GetComponent<SpriteRenderer>().color = newcolor;
    }
}
