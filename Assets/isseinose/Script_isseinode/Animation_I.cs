using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animation_I : MonoBehaviour {

    public Animator animator;

    public const string key_Lose = "Lose";             //8
    public const string key_Win = "Win";               //9
    public const string key_isTwothumbWake = "isTwothumbWake";         //motion_I=1 
    public const string key_isLeftthumb = "isLeftthumb";               //2
    public const string key_isRightthumb = "isRightthumb";               //3
    public const string key_isTwotoLeft = "isTwotoLeft";                 //4
    public const string key_isTwotoRight = "isTwotoRight";               //5
    public const string key_isRightthumb_single = "isRightthumb_single";       //6
    public const string key_isLeftthumb_single = "isLeftthumb_single";         //7

    static public int[] motion_I = { 0,0,0,0,0,0,0,0,0};        //上に割り振ってる番号に対応。1ならtrue,0ならfalse
    
    void Start () {
        this.animator = GetComponent<Animator>();
        for(int i = 0; i < 9; i++)
        {
            motion_I[i] = 0;
        }
    }

    // Update is called once per frame
    void Update () {

        if (motion_I[0] == 0)
        {
            this.animator.SetBool(key_isTwothumbWake, false);
        }
        else if(motion_I[0] == 1)
        {
            this.animator.SetBool(key_isTwothumbWake, true);
        }

        if (motion_I[1] == 0)
        {
            this.animator.SetBool(key_isLeftthumb, false);
        }
        else if (motion_I[1] == 1)
        {
            this.animator.SetBool(key_isLeftthumb, true);
        }

        if (motion_I[2] == 0)
        {
            this.animator.SetBool(key_isRightthumb, false);
        }
        else if (motion_I[2] == 1)
        {
            this.animator.SetBool(key_isRightthumb, true);
        }

        if (motion_I[3] == 0)
        {
            this.animator.SetBool(key_isTwotoLeft, false);
        }
        else if (motion_I[3] == 1)
        {
            this.animator.SetBool(key_isTwotoLeft, true);
        }

        if (motion_I[4] == 0)
        {
            this.animator.SetBool(key_isTwotoRight, false);
        }
        else if (motion_I[4] == 1)
        {
            this.animator.SetBool(key_isTwotoRight, true);
        }

        if (motion_I[5] == 0)
        {
            this.animator.SetBool(key_isRightthumb_single, false);
        }
        else if (motion_I[5] == 1)
        {
            this.animator.SetBool(key_isRightthumb_single, true);
        }

        if (motion_I[6] == 0)
        {
            this.animator.SetBool(key_isLeftthumb_single, false);
        }
        else if (motion_I[6] == 1)
        {
            this.animator.SetBool(key_isLeftthumb_single, true);
        }

        if (motion_I[7] == 0)
        {
            this.animator.SetBool(key_Lose, false);
        }
        else if (motion_I[7] == 1)
        {
            this.animator.SetBool(key_Lose, true);
        }

        if (motion_I[8] == 0)
        {
            this.animator.SetBool(key_Win, false);
        }
        else if (motion_I[8] == 1)
        {
            this.animator.SetBool(key_Win, true);
        }

       
    }
}
