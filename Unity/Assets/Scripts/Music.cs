using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Music : MonoBehaviour
{

    [SerializeField] private AudioSource track1;
    [SerializeField] private AudioSource track2;
    [SerializeField] private AudioSource track3;
    [SerializeField] private AudioSource track4;
    [SerializeField] private AudioSource track5;
    [SerializeField] private AudioSource track6;

    private int TrackSelector;
    private int TrackHistory;

    // Start is called before the first frame update
    void Start()
    {
        TrackSelector = Random.Range(0, 6);

        if (TrackSelector == 0)
        {
            track1.Play();
            TrackHistory = 0;
        }
        else if (TrackSelector == 1)
        {
            track2.Play();
            TrackHistory = 1;
        }
        else if (TrackSelector == 2)
        {
            track3.Play();
            TrackHistory = 2;
        }
        else if(TrackSelector == 3)
        {
            track4.Play();
            TrackHistory = 3;
        }
        else if (TrackSelector == 4)
        {
            track5.Play();
            TrackHistory = 4;
        }
        else if(TrackSelector == 5)
        {
            track6.Play();
            TrackHistory = 5;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (track1.isPlaying == false && track2.isPlaying == false && track3.isPlaying == false && track4.isPlaying == false && track5.isPlaying == false && track6.isPlaying == false )
        {
            TrackSelector = Random.Range(0, 6);

            if (TrackSelector == 0 && TrackHistory !=0)
            {
                track1.Play();
                TrackHistory = 0;
            }
            else if (TrackSelector == 1 && TrackHistory != 1)
            {
                track2.Play();
                TrackHistory = 1;
            }
            else if (TrackSelector == 2 && TrackHistory != 2)
            {
                track3.Play();
                TrackHistory = 2;
            }
            else if (TrackSelector == 3 && TrackHistory != 3)
            {
                track4.Play();
                TrackHistory = 3;
            }
            else if (TrackSelector == 4 && TrackHistory != 4)
            {
                track5.Play();
                TrackHistory = 4;
            }
            else if (TrackSelector == 5 && TrackHistory != 5)
            {
                track6.Play();
                TrackHistory = 5;
            }
        }
    }
}
