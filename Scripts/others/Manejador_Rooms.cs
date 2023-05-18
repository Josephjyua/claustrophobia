using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manejador_Rooms : MonoBehaviour
{

    public GameObject[] walls;
    public GameObject[] doors;

    void Start()
    {
     
    }

    void Update()
    {
        
    }

   public void UpdateRoom(bool[] status) {
        for (int i = 0; i < status.Length; i++) {
            doors[i].SetActive(status[i]);
            walls[i].SetActive(!status[i]);

        }
    }
}
