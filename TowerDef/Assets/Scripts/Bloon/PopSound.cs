using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopSound : MonoBehaviour
{
    private AudioSource audioSource;

    void Start()
    {
        audioSource = this.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!audioSource.isPlaying)
        {
            Destroy(gameObject);
        }
    }
}
