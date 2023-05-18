using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomTemplates : MonoBehaviour {

	// Crear dinamicamente las rooms
	public GameObject[] bottomRooms;
	public GameObject[] topRooms;
	public GameObject[] leftRooms;
	public GameObject[] rightRooms;

	public GameObject closedRoom;

	public List<GameObject> rooms;

	public GameObject boss;


    private void Start() {
        Invoke("SpawnBoss", 2f);
    }


    void SpawnBoss() {
		Instantiate(boss, rooms[rooms.Count -1].transform.position, Quaternion.identity);
    }
}
