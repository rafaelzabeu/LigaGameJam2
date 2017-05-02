using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestBehaviour : MonoBehaviour {

    public PlayerDetectorBehaviour playerDetector;

    public GameObject winSprite;

    private void Awake()
    {


    }

    private void onPlayerEnter()
    {
        AudioClip audio = Resources.Load<AudioClip>("SoundEffects/Victory_jam");
    }

}
