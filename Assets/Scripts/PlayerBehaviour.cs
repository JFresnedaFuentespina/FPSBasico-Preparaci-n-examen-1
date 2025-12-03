using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    public List<AudioClip> audioClips;
    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Roca"))
        {
            audioSource.PlayOneShot(audioClips[0]);
        }
        else if (collision.gameObject.CompareTag("Arbol"))
        {
            audioSource.PlayOneShot(audioClips[1]);
        }
    }
}
