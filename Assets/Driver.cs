using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Driver : MonoBehaviour
{
    [SerializeField] float moveSpeed = 20f;
    [SerializeField] float steerSpeed = 100f;
    [SerializeField] float slowSpeed = 15f;
    [SerializeField] float boostSpeed = 30f;
    float moveSpeedBase = 20f;
    float timeToWait = 1f;

    [SerializeField] AudioClip crash;
    [SerializeField] AudioClip success;
    [SerializeField] AudioClip engineSound;

    AudioSource audiosrc;

    void Start() {
        audiosrc = GetComponent<AudioSource>();
    }

    void Update()
    {
        float steerAmount = Input.GetAxis("Horizontal") * steerSpeed * Time.deltaTime;
        float moveAmount = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;
        transform.Rotate(0,0,-steerAmount);
        transform.Translate(0,moveAmount,0);
        AudioCar();
    }

    void AudioCar()
    {
        if (Input.GetAxis("Vertical") != 0)
        {
            audiosrc.PlayOneShot(engineSound);
        }
        else
        {
            audiosrc.Stop();
        }
    }

    void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.tag == "Untagged")
        {
            moveSpeedBase = moveSpeed;
            audiosrc.Stop();
            audiosrc.PlayOneShot(crash);
            
            moveSpeed = moveSpeed - slowSpeed;
            // Debug.Log(moveSpeed);
            float timer = Time.time;
            // Debug.Log(timer);
            if (timer > timeToWait)
            {
                moveSpeed = moveSpeedBase;
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.tag == "Boost")
        {
            moveSpeedBase = moveSpeed;
            moveSpeed = boostSpeed;
            float timer = Time.time;
            // Debug.Log(timer);
            if (timer > timeToWait)
            {
                moveSpeed = moveSpeedBase;
            }
        }
        if (other.gameObject.tag == "Customer")
        {
            audiosrc.PlayOneShot(success);
        }
    }
}
