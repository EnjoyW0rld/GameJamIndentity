using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomsManager : MonoBehaviour
{
    [SerializeField] private RoomInstance[] _roomInstances;
    private GameObject _character;
    private RoomInstance _currentRoom;

    private void Start()
    {
        _character = FindObjectOfType<CharacterMover>().gameObject;
        EventManager.Instance.OnAllEnemyKilled.AddListener(OnRoomComplete);
        if (_character == null) Debug.LogError("Could not find character in scene");
        CreateRoom();
    }
    private void CreateRoom()
    {
        if (_roomInstances == null || _roomInstances.Length == 0)
        {
            Debug.LogError("RoomInstances were null in " + name);
            return;
        }
        _currentRoom = Instantiate(_roomInstances[Random.Range(0, _roomInstances.Length)]);
        _character.transform.position = _currentRoom.PlayerSpawnPoint;
    }
    private void ResetRoom()
    {
        print("destroying");
        Destroy(_currentRoom.gameObject);
        CreateRoom();
    }
    private void OnRoomComplete(RoomInstance pInstance)
    {
        ResetRoom();
        print("room is complete");
    }
}