using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager: MonoBehaviour
{
    public AudioClip rockAppearSound;
    public AudioClip woundAppearSound;
    public AudioClip drillSound;
    public AudioClip wandSound;
    public AudioClip noToolSound;
    AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlaySound(string clipName) {
        switch(clipName) {
            case "drillSound":
                audioSource.clip = drillSound;
                break;
            case "wandSound":
                audioSource.clip = wandSound;
                break;
            case "noToolSound":
                audioSource.clip = noToolSound;
                break;
            case "rockAppearSound":
                audioSource.clip = rockAppearSound;
                break;
            case "woundAppearSound":
                audioSource.clip = woundAppearSound;
                break;
        }

        audioSource.Play();
    }
}
