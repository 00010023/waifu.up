using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackCharacter : MonoBehaviour
{
    public GameObject player;
    public Transform tracker;
    public float distance = 5;
    
    void Update()
    {
        if (player.transform.position.y - distance > transform.position.y)
        {
            tracker.position = new Vector3(0, player.transform.position.y - distance, 0);
        }
    }
}
