using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DungeonSpawnTest : MonoBehaviour
{
    //private Dictionary<Vector2, bool> _visitedRooms;
    [SerializeField] private int _xExtent, _zExtent;
    private List<Vector2> _visited;
    private List<Vector2> _doorsPos;
    Dictionary<int, Action<Vector2>> _actions = new Dictionary<int, Action<Vector2>>();
    private void Start()
    {
        _actions.Add(0, EvaluateRightRoom);
        _actions.Add(1, EvaluateLeftRoom);
        _actions.Add(2, EvaluateTopRoom);
        _actions.Add(3, EvaluateBottomRoom);
        _visited = new List<Vector2>();
        _doorsPos = new List<Vector2>();
        //_visitedRooms = new Dictionary<Vector2, bool>();
        //_visitedRooms.Add(Vector2.zero, true);
        _visited.Add(Vector2.zero);
        //_visited.Add(new Vector2(3, 2));
        CheckRoom(Vector2.zero);
    }
    private void CheckRoom(Vector2 pCurrentRoom)
    {
        int[] execOrder = new int[] { 0, 1, 2, 3 };
        int[] shuffledOrder = Shuffle(execOrder);
        for (int i = 0; i < shuffledOrder.Length; i++)
        {
            _actions[shuffledOrder[i]].Invoke(pCurrentRoom);
        }
        //EvaluateRightRoom(pCurrentRoom);
        //EvaluateLeftRoom(pCurrentRoom);
        //EvaluateTopRoom(pCurrentRoom);
        //EvaluateBottomRoom(pCurrentRoom);
    }

    private void EvaluateBottomRoom(Vector2 pCurrentRoom)
    {
        if (pCurrentRoom.y - 1 >= 0 && !_visited.Contains(pCurrentRoom + new Vector2(0, -1)))
        {
            _visited.Add(pCurrentRoom + new Vector2(0, -1));
            _doorsPos.Add(pCurrentRoom + new Vector2(0, -.5f));
            CheckRoom(pCurrentRoom + new Vector2(0, -1));
        }
    }

    private void EvaluateTopRoom(Vector2 pCurrentRoom)
    {
        if (pCurrentRoom.y + 1 < _zExtent && !_visited.Contains(pCurrentRoom + new Vector2(0, 1)))
        {
            _visited.Add(pCurrentRoom + new Vector2(0, 1));
            _doorsPos.Add(pCurrentRoom + new Vector2(0, .5f));
            CheckRoom(pCurrentRoom + new Vector2(0, 1));
        }
    }

    private void EvaluateLeftRoom(Vector2 pCurrentRoom)
    {
        if (pCurrentRoom.x - 1 >= 0 && !_visited.Contains(pCurrentRoom + new Vector2(-1, 0)))
        {
            _visited.Add(pCurrentRoom + new Vector2(-1, 0));
            _doorsPos.Add(pCurrentRoom + new Vector2(-.5f, 0));
            CheckRoom(pCurrentRoom + new Vector2(-1, 0));
        }
    }

    private void EvaluateRightRoom(Vector2 pCurrentRoom)
    {
        if (pCurrentRoom.x + 1 < _xExtent && !_visited.Contains(pCurrentRoom + new Vector2(1, 0)))
        {
            _visited.Add(pCurrentRoom + new Vector2(1, 0));
            _doorsPos.Add(pCurrentRoom + new Vector2(.5f, 0));
            CheckRoom(pCurrentRoom + new Vector2(1, 0));
        }
    }
    private void OnDrawGizmosSelected()
    {
        if (_doorsPos == null || _visited == null) return;
        Gizmos.color = Color.red;
        for (int i = 0; i < _doorsPos.Count; i++)
        {
            Gizmos.DrawCube(new Vector3(_doorsPos[i].x, 0, _doorsPos[i].y), new Vector3(.5f, .5f, .5f));
        }
        Gizmos.color = Color.white;
        for (int x = 0; x < _xExtent; x++)
        {
            for (int z = 0; z < _zExtent; z++)
            {
                Gizmos.DrawWireCube(new Vector3(x, 0, z), new Vector3(.5f, 0, .5f));
            }
        }
    }
    public int[] Shuffle(int[] Sequence)
    {
        // public method's arguments validation
        if (null == Sequence)
            throw new System.Exception(nameof(Sequence));

        // No need in Array if you want to modify Sequence

        for (int s = 0; s < Sequence.Length - 1; s++)
        {
            int GenObj = GenerateAnotherNum(s, Sequence.Length); // pleace, note the range

            // swap procedure: note, var h to store initial Sequence[s] value
            var h = Sequence[s];
            Sequence[s] = Sequence[GenObj];
            Sequence[GenObj] = h;
        }

        return Sequence;
    }
    private static int GenerateAnotherNum(int from, int to) => UnityEngine.Random.Range(from, to);
}
