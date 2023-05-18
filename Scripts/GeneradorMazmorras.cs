using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneradorMazmorras : MonoBehaviour
{
    public GameObject room;
    public float factor1 = 5.6f;
    public float factor2 = 5.6f;
    public float factor3 = 5.6f;

    GameObject r = null;


    void Start()
    {
      
        

    }
    private void Update() {
            if (Input.GetKeyUp(key:KeyCode.Space)) {
                if (r !=null) {
                    Destroy(r);
                }
           
                InstanciarMazmorra();
            }  
    }


    void InstanciarMazmorra() {

        int x = Random.Range(70, 100);
        int y = Random.Range(70, 100);
        int maxRooms = Random.Range(40, 60);
        int c = 0;
        
        r = Instantiate(new GameObject("dungeon"));
        Dungeon dungeon = new Dungeon();
        dungeon.Generar(x, y, maxRooms);
        for (int i = 0; i < dungeon.dungeon.GetUpperBound(0); i++) {
            for (int j = 0; j < dungeon.dungeon.GetUpperBound(1); j++) {
                if (dungeon.dungeon[i, j].active) {
                    c++;
                    Debug.Log($"Sala {i},{j}:");
                    Debug.Log($"Norte: {dungeon.dungeon[i, j].n}");
                    Debug.Log($"Sur: {dungeon.dungeon[i, j].s}");
                    Debug.Log($"Este: {dungeon.dungeon[i, j].e}");
                    Debug.Log($"Oeste: {dungeon.dungeon[i, j].o}");
                    Debug.Log("--------");
                    //Vector3 pos = new Vector3(i, j, 0);
                    //GameObject sala = Instantiate(room, pos*8, Quaternion.identity);

                    Vector3 pos = new Vector3((i * factor1)- (j * factor2), (j * factor2) + (i * factor3), 0);
                    //Quaternion r = Quaternion.Euler(0, 0, 45);
                    GameObject sala = Instantiate(room, pos, Quaternion.identity);
                    sala.transform.SetParent(r.transform);

                    if (dungeon.dungeon[i, j].n) {
                        sala.GetComponent<Room>().u.transform.GetChild(1).gameObject.SetActive(false);
                        sala.GetComponent<Room>().u.transform.GetChild(3).gameObject.SetActive(true);

                    }
                    if (dungeon.dungeon[i, j].s) {
                        sala.GetComponent<Room>().d.transform.GetChild(1).gameObject.SetActive(false);
                        sala.GetComponent<Room>().d.transform.GetChild(3).gameObject.SetActive(true);
                    }
                    if (dungeon.dungeon[i, j].e) {
                        sala.GetComponent<Room>().r.transform.GetChild(1).gameObject.SetActive(false);
                        sala.GetComponent<Room>().r.transform.GetChild(3).gameObject.SetActive(true);
                    }
                    if (dungeon.dungeon[i, j].o) {
                        sala.GetComponent<Room>().l.transform.GetChild(1).gameObject.SetActive(false);
                        sala.GetComponent<Room>().l.transform.GetChild(3).gameObject.SetActive(true);
                    }
                }
            }
        }

        Debug.Log($"Total de salas: {c}");
    }
}
