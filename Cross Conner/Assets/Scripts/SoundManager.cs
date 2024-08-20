using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
   public static SoundManager instance;

    [SerializeField] private AudioSource effectSound;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
            return;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void PlaySound(AudioClip clip)
    {
        effectSound.PlayOneShot(clip);
    }
    
}
