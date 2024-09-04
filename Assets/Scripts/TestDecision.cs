using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestDecision : MonoBehaviour
{
    private Dictionary<Vector3, string> _result = new Dictionary<Vector3, string>()
    {
        {new Vector3(-1,-1,-1),"Buddy"},
        {new Vector3(-1,1,-1),"Fireball"},
        {new Vector3(-1,1,1),"Butcher"},
        {new Vector3(-1,-1,1),"Saviour"},

        {new Vector3(1,-1,-1),"Mom friend"},
        {new Vector3(1,1,-1),"Champion"},
        {new Vector3(1,-1,1),"Stickler"},
        {new Vector3(1,1,1),"Maniac"}

    };
    CounterManager _counter => CounterManager.Instance;
    public void EvaluationTest()
    {
        print(Evaluate());
    }
    private string Evaluate()
    {
        int accuracy = _counter.Accuracy > 0 ? 1 : -1;
        int killAmount = _counter.KilledAmount > 0 ? 1 : -1;
        int obsessivnes = _counter.Obsesivnes > 0 ? 1 : -1;
        return _result[new Vector3(accuracy, killAmount, obsessivnes)];
    }
}
