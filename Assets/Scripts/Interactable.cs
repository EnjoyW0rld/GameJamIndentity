using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Interactable : MonoBehaviour
{
    public UnityEvent OnInteraction;
    private void Start()
    {
        if (OnInteraction == null) OnInteraction = new UnityEvent();
    }
    public void DoInteraction()
    {
        OnInteraction?.Invoke();

    }
}
