using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonManager : MonoBehaviour
{
    private AudioSource mouseOnAudio;

    private void Start()
    {
        mouseOnAudio = GetComponent<AudioSource>();
    }

    public void OnMouseEnter()
    {
        mouseOnAudio.Play();
    }
}
