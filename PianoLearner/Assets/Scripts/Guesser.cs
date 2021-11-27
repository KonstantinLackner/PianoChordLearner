using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Guesser : MonoBehaviour
{
    public List<Key> activeKeys = new List<Key>();
    public List<Chord> allChords = new List<Chord>();
    private String path = "Assets/Resources/chords.txt";
    private bool guessedCurrent = true;
    private Chord chordToGuess;

    // Start is called before the first frame update
    void Start()
    {
        String[] chordStrings = System.IO.File.ReadAllLines(path);
        foreach (var chord in chordStrings)
        {
            String name = chord.Split('-')[0];
            String[] notes = chord.Split('-')[1].Split(',');
            allChords.Add(new Chord(name, new ArrayList(notes)));
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (guessedCurrent)
        {
            guessedCurrent = false;
            int rnd = Random.Range(0, allChords.Count - 1);
            chordToGuess = allChords[rnd];
            Debug.Log(chordToGuess);
        }
        else
        {
            String guess = "";
            foreach (var key in activeKeys)
            {
                guess += key.note;
            }
            if (chordToGuess.checkChord(guess))
            {
                guessedCurrent = true;
            }
        }
    }
}
