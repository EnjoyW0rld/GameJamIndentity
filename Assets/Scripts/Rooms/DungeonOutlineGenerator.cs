using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DungeonOutlineGenerator : MonoBehaviour
{
    private int[,] _placedRooms;
    [SerializeField] private int _xExtent, _zExtent;
    [SerializeField] private GameObject _gameObj;
    private void Start()
    {
        _placedRooms = new int[_xExtent, _zExtent];
        FillArrWith(_placedRooms, 1);
        DoDungeon();
    }
    private void DoDungeonTwo()
    {
        Vector2 currentTile = Vector2.zero;
        bool spawned = false;
        while (!spawned)
        {
            int direction = Random.Range(0, 4);
            Vector2 dir = Vector2.zero;
            if (direction == 3) dir.x = -1;
            else if (direction == 1) dir.x = 1;
            if (direction == 0) dir.y = -1;
            else if (direction == 2) dir.y = 1;

            if (dir.x + currentTile.x < _xExtent || dir.x + currentTile.x >= 0)
            {
                //if (_placedRooms[dir.x + currentTile.x,dir.y + currentTile.y] == 0)
            }
        }
    }
    private void DoDungeon()
    {
        for (int x = 0; x < _xExtent; x++)
        {
            for (int z = 0; z < _zExtent; z++)
            {
                EvaluateRoom(x, z);
            }
        }
        for (int x = 0; x < _xExtent; x++)
        {
            for (int z = 0; z < _zExtent; z++)
            {
                if (_placedRooms[x, z] == 1)
                {
                    Instantiate(_gameObj, new Vector3(x, z, 0), Quaternion.identity);
                }
            }
            string str = "";
            for (int z = 0; z < _zExtent; z++)
            {
                str += _placedRooms[x, z] + " ";
            }
            print(str);
        }
    }
    private void EvaluateRoom(int pCurrentX, int pCurrentZ)
    {
        bool doDelete = Random.Range(0, 2) == 1;
        int roomsNearby = 0;
        if (doDelete)
        {
            for (int x = -1; x < 2; x += 2)
            {
                if (x + pCurrentX >= _xExtent || x + pCurrentX < 0) continue;
                for (int z = -1; z < 2; z += 2)
                {
                    if (z + pCurrentZ >= _zExtent || z + pCurrentZ < 0)
                    {
                        continue;
                    }
                    if (_placedRooms[x + pCurrentX, z + pCurrentZ] == 1)
                    {
                        roomsNearby++;
                    }
                }
            }
            if (roomsNearby >= 2)
                _placedRooms[pCurrentX, pCurrentZ] = 0;

        }
    }
    private void FillArrWith(int[,] pArr, int pValue)
    {
        for (int x = 0; x < pArr.GetLength(0); x++)
        {
            for (int z = 0; z < pArr.GetLength(1); z++)
            {
                pArr[x, z] = pValue;
            }
        }
    }
}