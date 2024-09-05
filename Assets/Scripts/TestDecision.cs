using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestDecision : MonoBehaviour
{
    private Dictionary<Vector3, GameObject> _result;
    /*        = new Dictionary<Vector3, string>()
        {
            {new Vector3(-1,-1,-1),"buddy"},
            {new Vector3(-1,1,-1),"Fireball"},
            {new Vector3(-1,1,1),"Butcher"},
            {new Vector3(-1,-1,1),"Saviour"},

            {new Vector3(1,-1,-1),"Mom friend"},
            {new Vector3(1,1,-1),"Champion"},
            {new Vector3(1,-1,1),"Stickler"},
            {new Vector3(1,1,1),"Maniac"}

        };*/
    [SerializeField] private GameObject _fireball;
    [SerializeField] private GameObject _butcher;
    [SerializeField] private GameObject _buddy;
    [SerializeField] private GameObject _saviour;
    [SerializeField] private GameObject _champion;
    [SerializeField] private GameObject _maniac;
    [SerializeField] private GameObject _momFriend;
    [SerializeField] private GameObject _stickler;

    CounterManager _counter => CounterManager.Instance;
    private void Start()
    {
        _result = new Dictionary<Vector3, GameObject>();
        _result.Add(new Vector3(-1, 1, -1), _fireball);
        _result.Add(new Vector3(-1, -1, -1), _buddy);
        _result.Add(new Vector3(-1, 1, 1), _butcher);
        _result.Add(new Vector3(-1, -1, 1), _saviour);
        _result.Add(new Vector3(1, -1, -1), _momFriend);
        _result.Add(new Vector3(1, 1, -1), _champion);
        _result.Add(new Vector3(1, -1, 1), _stickler);
        _result.Add(new Vector3(1, 1, 1), _maniac);
    }
    public void EvaluationTest()
    {
        int accuracy = _counter.Accuracy > 0 ? 1 : -1;
        int killAmount = _counter.KilledAmount > 0 ? 1 : -1;
        int obsessivnes = _counter.Obsesivnes > 0 ? 1 : -1;
        _result[new Vector3(accuracy, killAmount, obsessivnes)].SetActive(true);
        //print(Evaluate());
    }
    private string Evaluate()
    {
        //return _result[new Vector3(accuracy, killAmount, obsessivnes)];
        return " ";
    }
}
