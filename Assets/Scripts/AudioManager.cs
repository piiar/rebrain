using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager: MonoBehaviour
{
    public AudioClip drillWarningSound;
    public AudioClip wandWarningSound;
    public AudioClip rockFixSound;
    public AudioClip woundFixSound;
    public AudioClip rockAppearSound;
    public AudioClip woundAppearSound;
    public AudioClip drillSound;
    public AudioClip wandSound;
    public AudioClip noToolSound;
    AudioSource audioSource;

    private static AudioManager _instance;
    public static AudioManager instance {
        get {
            if (_instance == null) {
                _instance = Object.FindObjectOfType<AudioManager>();

                //Tell unity not to destroy this object when loading a new scene!
                DontDestroyOnLoad(_instance.gameObject);
            }

            return _instance;
        }
    }

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
        AudioClip clip = null;
        switch (clipName) {
            case "drillSound":
                clip = drillSound;
                break;
            case "wandSound":
                clip = wandSound;
                break;
            case "noToolSound":
                clip = noToolSound;
                break;
            case "rockAppearSound":
                clip = rockAppearSound;
                break;
            case "woundAppearSound":
                clip = woundAppearSound;
                break;
            case "rockFixSound":
                clip = rockFixSound;
                break;
            case "woundFixSound":
                clip = woundFixSound;
                break;
            case "drillWarningSound":
                clip = drillWarningSound;
                break;
            case "wandWarningSound":
                clip = wandWarningSound;
                break;
        }

        audioSource.PlayOneShot(clip);
    }
}
