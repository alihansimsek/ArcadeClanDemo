using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public GameObject player;
    public float zOffset = 10;
    public float xOffset = 2;
    // Update is called once per frame
    void LateUpdate()
    {
        gameObject.transform.position = Vector3.Lerp(gameObject.transform.position, new Vector3(xOffset, gameObject.transform.position.y, player.gameObject.transform.position.z - zOffset), Time.deltaTime * 100);
    }
}
