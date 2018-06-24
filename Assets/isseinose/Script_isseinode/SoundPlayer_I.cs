using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundPlayer_I : MonoBehaviour
{

    public AudioClip kakegoe;
    public AudioClip zero;
    public AudioClip one;
    public AudioClip two;
    public AudioClip three;
    public AudioClip four;
    public AudioClip pardon;
    public AudioClip onemore;
    public AudioClip joy;
    public AudioClip sad;
    public AudioClip win;
    public AudioClip lose;
    public AudioClip yaru;
    public AudioClip osi;


    private AudioSource audioSource;

    public void Onemore()
    {
        audioSource.Play();
    }



    public void Call(string str)
    {

        if (str == "kakegoe") audioSource.clip = kakegoe;
        if (str == "joy") audioSource.clip = joy;
        if (str == "sad") audioSource.clip = sad;
        if (str == "win") audioSource.clip = win;
        if (str == "lose") audioSource.clip = lose;
        if (str == "yaru") audioSource.clip =yaru;
        if (str == "osi") audioSource.clip =osi;
        
       

        
            audioSource.Play();
            
        
       
    }

    public void Call_Enemy(int num)         //てきのターンの声
    {

        if (num == 0) audioSource.clip = zero;
        if (num==1) audioSource.clip = one;
        if (num==2) audioSource.clip = two;
        if (num==3) audioSource.clip = three;
        if (num==4) audioSource.clip = four;

            audioSource.Play();
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

