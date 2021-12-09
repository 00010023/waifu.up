using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Movement : MonoBehaviour
{
    private Rigidbody _player;
    
    // Start is called before the first frame update
    private void Start()
    {
        _player = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxisRaw("Horizontal");
        _player.AddForce(new Vector3(x, 0f, 0f) * 20);
        _player.velocity = new Vector3(Mathf.Clamp(_player.velocity.x, -3, 3), _player.velocity.y, Mathf.Clamp(_player.velocity.z, -20, 20));
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Platform") && _player.velocity.y <= 0f) _player.AddForce(new Vector3(0f, 1f, 0f) * 500);
        
        if (_player.gameObject.CompareTag("Platform")) Debug.Log("Platform");   
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PlatformTrigger")) Physics.IgnoreCollision(other.transform.parent.GetChild(0).GetComponent<Collider>(), _player.GetComponent<Collider>(), true);
        
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("PlatformTrigger")) Physics.IgnoreCollision(other.transform.parent.GetChild(0).GetComponent<Collider>(), _player.GetComponent<Collider>(), false);
    }
}
