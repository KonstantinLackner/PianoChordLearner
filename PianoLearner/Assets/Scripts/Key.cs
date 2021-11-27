using System;
using UnityEngine;

public class Key : MonoBehaviour
{
    private bool active = false;
    public String note;
    public Guesser guesser;

    private void OnMouseDown()
    {
        if (!active)
        {
            guesser.activeKeys.Add(this);
            active = true;
            GetComponent<SpriteRenderer>().color = Color.yellow;
        }
        else
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
}