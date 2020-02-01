using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager: MonoBehaviour
{
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
            case "drillUsed":
                audioSource.clip = drillSound;
                break;
            case "wandUsed":
                audioSource.clip = wandSound;
                break;
            case "noTool":
                audioSource.clip = noToolSound;
                break;
        }

        audioSource.Play();
    }
}
