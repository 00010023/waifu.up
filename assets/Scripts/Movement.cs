using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Movement : MonoBehaviour
{
    private Rigidbody _player;
    public bool isPlaying = true;
    
    private void Start()
    {
        _player = GetComponent<Rigidbody>();
    }

    void Update()
    {
        float x = Input.GetAxisRaw("Horizontal");

        if (isPlaying)
        {
            _player.AddForce(new Vector3(x, 0f, 0f) * 20);
        }
        
        _player.velocity = new Vector3(Mathf.Clamp(_player.velocity.x, -3, 3), _player.velocity.y, Mathf.Clamp(_player.velocity.z, -20, 20));

        if (_player.position.x > 3.5)
        {
            _player.position = new Vector3((float)-3.5, _player.position.y, _player.position.z);
        }
        else if (_player.position.x < -3.5)
        {
            _player.position = new Vector3((float)3.5, _player.position.y, _player.position.z);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Platform") && _player.velocity.y <= 0f)
        {
            _player.AddForce(new Vector3(0f, 1f, 0f) * 500);
        }
        else if (collision.gameObject.CompareTag("End"))
        {
            isPlaying = false;
            FindObjectOfType<GameManager>().EndGame();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PlatformTrigger"))
        {
            Physics.IgnoreCollision(other.transform.parent.GetChild(0).GetComponent<Collider>(),
                _player.GetComponent<Collider>(), true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("PlatformTrigger")) Physics.IgnoreCollision(other.transform.parent.GetChild(0).GetComponent<Collider>(), _player.GetComponent<Collider>(), false);
    }
}
