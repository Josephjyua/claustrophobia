using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public GameObject player;
    public float speed = 5f;
    public float offset = 4f;
    public float alcance = 2f;


    void Start() {
    
    }


    void Update() {
        Vector3 mira = player.transform.Find("p").transform.position;

        if (player != null) {
            Vector3 playerPos = player.transform.position;

            Vector3 desirePos = (playerPos + mira) / offset;
            desirePos.x = Mathf.Clamp(desirePos.x, playerPos.x - alcance, playerPos.x + alcance);
            desirePos.y = Mathf.Clamp(desirePos.y, playerPos.y - alcance, playerPos.y + alcance);
            desirePos.z = -10;

            this.transform.position = Vector3.Lerp(this.transform.position, desirePos, Time.deltaTime * speed);
        }

    }
}
