using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hitGroundSound : MonoBehaviour
{

    AudioSource audioSource;
    public AudioClip impact;
    bool firstContact = false;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.gameObject.layer == LayerMask.NameToLayer("Ground") && !firstContact)
        {
            Debug.Log("the ball " + this.gameObject.name + " touched the ground");
            audioSource.PlayOneShot(impact, 4.0f);
            firstContact = true;
        }
    }
}
