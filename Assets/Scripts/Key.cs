using System;
using UnityEngine;

public class Key : MonoBehaviour
{
    private bool active = false;
    public String note;
    public Guesser guesser;
    public AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void OnMouseDown()
    {
        if (!active)
        {
            guesser.activeKeys.Add(this);
            active = true;
            GetComponent<SpriteRenderer>().color = Color.yellow;
            audioSource.Play();
        }
        else
        {
            Deactivate();
        }
    }

    public void Deactivate()
    {
        guesser.activeKeys.Remove(this);
        active = false;
        if (note.Contains("#"))
        {
            GetComponent<SpriteRenderer>().color = Color.black;
        }
        else
        {
            GetComponent<SpriteRenderer>().color = Color.white;
        }
    }
}