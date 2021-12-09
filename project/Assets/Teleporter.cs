using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporter : MonoBehaviour
{
    public Transform _transform;
    
    // Update is called once per frame
    void Update()
    { 
        // Follow the transform of the player by  y axis
        transform.position = new Vector3(_transform.position.x, 2.40f, 0f);
    }
}
