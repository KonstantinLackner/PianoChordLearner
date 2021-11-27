using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chord
{
    private String name;
    private ArrayList notes;

    public Chord(string name, ArrayList notes)
    {
        this.name = name;
        this.notes = notes;
    }

    public bool checkChord(String notesGiven)
    {
        foreach (String note in notes) 
        {
            if (!notesGiven.Contains(note))
            {
                return false;
            }
            // Remove so chords can't have more notes than needed
            notesGiven = notesGiven.Replace(note, "");
        }

        return notesGiven.Length <= 0;
    }

    public override string ToString()
    {
        return name;
    }
}
