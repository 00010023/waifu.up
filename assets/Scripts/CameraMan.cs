using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMan : MonoBehaviour
{
    public GameObject player;
    public Transform tracker;
    public float xPosition;
    public float zPosition;
    public float lift;
    
    void Update()
    {
        if (player.transform.position.y + lift > transform.position.y)
        {
            tracker.position = new Vector3(xPosition, player.transform.position.y + lift, zPosition);
        }
    }
}
