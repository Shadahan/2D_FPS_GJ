using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    public static AudioController instance;
    public AudioSource ammo, health, enemyDeath, enemyShot, gunShot, playerHurt;

    private void Awake() {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayAudio(AudioSource audio)
    {
        audio.Stop();
        audio.Play();
    }
}
