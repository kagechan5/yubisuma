using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;





public class GameController : MonoBehaviour
{

    //GameObject unitychan = GameObject.Find("unitychan");
    public bool judge = true;
    static public int hand = 0; //自分の出した手
    private GameObject Panel;
    private GameObject Image;
    private GameObject Text1;
    private GameObject Text2;
    private GameObject Text3;






    GameObject unitychan;
   

    SoundPlayer sp;
    // Update is called once per frame
    private void Move_Lose()
    {
        Gamecontroller_I.Turn = false;
        SceneManager.LoadScene("isseinose");
        Anyhand.select = 2;
    }

    private void Move_Win()
    {
        Gamecontroller_I.Turn = true;
        SceneManager.LoadScene("isseinose");
        Anyhand.select = 2;
    }

    private void WinVoice()
    {
        sp.Call("Win");
        Sampleanimation.finish = 2;
        Invoke("Move_Lose", 2.0f);
         
    }


    private void LoseVoice()
    {
        sp.Call("Lose");
        Sampleanimation.finish = 1;
        Invoke("Move_Win", 2.0f);
        
    }

    private void AikoVoice()
    {
        sp.Call("Aiko");
    }

    private void judgetrue()
    {
        judge = true;
        hand = 0;
    }

    

    private void Intro()
    {
        Text2.SetActive(false);
        Text3.SetActive(false);
        Invoke("To2", 2.0f);

    }

    private void To2()
    {
        Text1.SetActive(false);
        Text2.SetActive(true);
        Invoke("To3", 2.0f);

    }

    private void To3()
    {
        Text2.SetActive(false);
        Text3.SetActive(true);
        Invoke("Finish", 2.0f);
    }

    private void Finish()
    {
        
        Panel.SetActive(false);
        Image.SetActive(false);
        Text1.SetActive(false);
        Text2.SetActive(false);
        Text3.SetActive(false);
        Invoke("GameStart",1.5f);
        sp.Call("Janken");
       
    }


    private void GameStart()
    {
        judge = true;
        hand = 0;
    }
   

    private void Judge(int hand, int i)
    {
        int a;
        a = hand - i;
        
        if (a == -1 || a == 2)   //勝ち
        {
            
            Invoke("LoseVoice", 1.0f);
            judge = false;
           // Gamecontroller_I.Turn = true;
          //  SceneManager.LoadScene("isseinose");
           // Anyhand.select = 2;
        }
        else if (a == 1 || a == -2) //負け
        {
           
            Invoke("WinVoice", 1.0f);
            judge = false;
          //  Gamecontroller_I.Turn = false;
          //  SceneManager.LoadScene("isseinose");
          //  Anyhand.select = 2;
        }
        else //あいこ
        {
            judge = false;
            
            Invoke("AikoVoice", 1.0f);
            Invoke("judgetrue", 3.0f);
            Sampleanimation.aiko = 1;
        }
    }

    private void Motion(int i)
    {
        switch (i)
        {
            case 1:
                sp.Call("Gu");
                Sampleanimation.motion = 1;
                break;
            case 2:
               sp.Call("Choki");
                Sampleanimation.motion = 2;
                break;
            case 3:
               sp.Call("Per");
                Sampleanimation.motion = 3;
                break;
        }
    }

    private void Start()
    {



        unitychan = GameObject.Find("unitychan");
        sp = GameObject.Find("SoundManager").GetComponent<SoundPlayer>();
        hand = 0;
        Panel = GameObject.Find("Panel_J");
        Image = GameObject.Find("Image_J");
        Text1 = GameObject.Find("Text_J");
        Text2 = GameObject.Find("Text1_J");
        Text3 = GameObject.Find("Text2_J");

        judge = false;

        Intro();
        

    }
        void Update()
    {
        if (!judge) return;

        if (hand == 0) return;
        
        int i = UnityEngine.Random.Range(1, 4);


        Motion(i);
        
        Judge(hand, i);
        
        


    }
}
