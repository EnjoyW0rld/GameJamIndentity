using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthUI : MonoBehaviour
{
    private GameObject[] _hearts;
    private int _toRemove = 0;
    private void Start()
    {
        _hearts = new GameObject[transform.childCount];
        print(transform.childCount);
        for (int i = 0; i < transform.childCount; i++)
        {
            _hearts[i] = transform.GetChild(i).gameObject;
        }
        FindObjectOfType<CharacterHealth>().OnDamageTaken.AddListener(DecreaseHealth);
    }
    public void DecreaseHealth()
    {
        print(_toRemove);
        _hearts[_toRemove].SetActive(false);
        //_toRemove++;
    }
}
