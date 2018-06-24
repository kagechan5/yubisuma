using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundPlayer : MonoBehaviour
{

    public AudioClip Janken;
    public AudioClip Pon;
    public AudioClip Aiko;
    public AudioClip Sho;
    public AudioClip Gu;
    public AudioClip Choki;
    public AudioClip Per;
    public AudioClip Win;
    public AudioClip Lose;

    private AudioSource audioSource;




    public void Call(string str)
    {
       
        if (str == "Janken") audioSource.clip = Janken;
        else if (str == "Pon") audioSource.clip = Pon;
        else if (str == "Aiko") audioSource.clip = Aiko;
        else if (str == "Sho") audioSource.clip = Sho;
        else if (str == "Gu") audioSource.clip = Gu;
        else if (str == "Choki") audioSource.clip = Choki;
        else if (str == "Per") audioSource.clip = Per;
        else if (str == "Win") audioSource.clip = Win;
        else if (str == "Lose") audioSource.clip = Lose;
        else audioSource.clip = null;

        if (audioSource.clip != null)
        {
            audioSource.Play();
            
        }
        }

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }



    // Update is called once per frame
    void Update()
    {

    }
}
