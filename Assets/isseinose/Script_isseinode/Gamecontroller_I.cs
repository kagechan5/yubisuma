using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Gamecontroller_I : MonoBehaviour
{

    private bool judge = false;
    static public bool Turn = true;   //trueなら自分のターン、falseなら相手のターン
    public GameObject unitychan;
    static public int thumbcount = 0; //自分の出した手、いっせいのーせ
    static public int EnemyHands = 2;       //自分の残りの手
    static public int MyHands = 2;          //相手の残りの手
    static public int Myvoice = -1;         //自分の言った数字
    public int whichthumb = 0;         //これが1なら左指、2なら右指上げる
    public Animator FingerAnime;

    private GameObject Panel;
    private GameObject Image;
    private GameObject Text1;
    private GameObject Text2;
    private GameObject Text3;

    private bool flagForJudge = false;


    SoundPlayer_I sp;

    public void GoTitle()
    {
        SceneManager.LoadScene("Title");
    }
    public void judgeTrue()
    {
        judge = true;
    }

    public void Intro()
    {
        if (Turn)       //じゃんけんで勝った
        {
            Text2.SetActive(false);
            Text3.SetActive(false);
            Invoke("To2", 2.0f);
        }

        else 
        {
            Text1.SetActive(false);
            Text3.SetActive(false);
            Invoke("To2", 2.0f);
        }
    }

    public void To2()
    {
        Text1.SetActive(false);
        Text2.SetActive(false);
        Text3.SetActive(true);
        Invoke("Final", 2.0f);
    }

    public void Final()
    {
        
        Panel.SetActive(false);
        Image.SetActive(false);
        Text1.SetActive(false);
        Text2.SetActive(false);
        Text3.SetActive(false);
        Invoke("judgeTrue", 2.0f);
    }


    public void TwotoOne()
    {
        sp.Call("joy");
        if (whichthumb == 1) Animation_I.motion_I[4]=1;
        else if (whichthumb == 2) Animation_I.motion_I[3] = 1;
        EnemyHands = 1;

        Invoke("judgeTrue", 2.0f);

    }

    public void Return()
    {
        sp.Call("sad");
        Animation_I.motion_I[0] = 0;
        Animation_I.motion_I[1] = 0;
        Animation_I.motion_I[2] = 0;

        Invoke("judgeTrue", 2.0f);
    }

    public void EnemyWin()
    {
        sp.Call("win");
        Animation_I.motion_I[8] = 1;
        EnemyHands = 0;
        Invoke("GoTitle", 3.0f);
    }

    public void ReturnOne()
    {
        sp.Call("sad");
         Animation_I.motion_I[5] = 0;      //右指戻す
        Animation_I.motion_I[6] = 0;       //左指戻す
        Invoke("judgeTrue", 2.0f);
    }
    public void Judge_Enemy()       //敵のターンの判定
    {
        
        int sumHands = MyHands + EnemyHands;            //二人の合計の指
        int voice = UnityEngine.Random.Range(0,sumHands+1 );    //unityちゃんが発する声
        int fingers = UnityEngine.Random.Range(0, EnemyHands + 1);  //unityちゃんがあげる指


        if (voice == 4)
        {
            fingers = 2;
        }

        else if (voice == 3)
        {
            if (EnemyHands == 1)
            {
                fingers = 1;
            }
            else if (EnemyHands == 2)
            {
                fingers = UnityEngine.Random.Range(1, 3);
            }
        }

        else if (voice == 1)
        {
            fingers = UnityEngine.Random.Range(0, 2);
        }

        else if (voice == 0)
        {
            fingers = 0;
        }

        int mythumbs = thumbcount;
        Debug.Log(mythumbs);

        Debug.Log("   ");       

        switch (EnemyHands)
        {
            case 1:                 //敵の手が一つ

               

                sp.Call_Enemy(voice);
                if (fingers == 1)
                {
                     Animation_I.motion_I[5] = 1; //右指あげる
                     Animation_I.motion_I[6] = 1; //左指上げる
                }

                if (voice == fingers + mythumbs)            //敵の言った数と上がってる指同じ
                {
                    Invoke("EnemyWin", 1.0f);
                }

                else       //言った数と本数違う
                {
                    Invoke("ReturnOne", 1.0f);
                    
                }

                break;


            case 2:                     //敵の手が二つ
                
                sp.Call_Enemy(voice);
                whichthumb = UnityEngine.Random.Range(1,3);     //1なら左指が上がってる、2なら右指が上がってる

                if (fingers == 2)       //敵が指2本上げる
                {
                    Animation_I.motion_I[0] = 1; //両指上げる動き
                }

                else if (fingers == 1)
                {
                    if (whichthumb == 1) Animation_I.motion_I[1] = 1;
                    else if(whichthumb == 2) Animation_I.motion_I[2]=1;

                }

                if (voice == fingers + mythumbs)            //敵の言った数と上がってる指同じ
                {
                    Invoke("TwotoOne", 1.0f);
                }

                else       //言った数と本数違う
                {
                    Invoke("Return", 1.0f);
                    whichthumb = 0;
                }

                break;

            default:
                break;
        }




        
        


    }


    public void TwotoOne_Player()
    {
        sp.Call("yaru");
        MyHands = 1;
        Animation_I.motion_I[0] = 0;
        Animation_I.motion_I[1] = 0;
        Animation_I.motion_I[2] = 0;
        Animation_I.motion_I[5] = 0;
        Animation_I.motion_I[6] = 0;
        Invoke("judgeTrue", 2.0f);
    }

    public void Return_Player()
    {
        sp.Call("osi");
        Animation_I.motion_I[0] = 0;
        Animation_I.motion_I[1] = 0;
        Animation_I.motion_I[2] = 0;
        Animation_I.motion_I[5] = 0;
        Animation_I.motion_I[6] = 0;
        Invoke("judgeTrue", 2.0f);
        
    }

    public void PlayerWin()
    {
        sp.Call("lose");
        Animation_I.motion_I[7] = 1;
        MyHands = 0;
        Invoke("GoTitle", 3.0f);
    }
    public void Judge_Player()
    {
            
        int sumHands = MyHands + EnemyHands;            //二人の合計の指
        int fingers = UnityEngine.Random.Range(0, EnemyHands + 1);  //unityちゃんがあげる指
        int mythumbs = thumbcount;          //自分があげている指確定

        if ((Myvoice != 0) && (Myvoice != 1) && (Myvoice != 2) && (Myvoice != 3) && (Myvoice != 4))   //自分が声を発するとスタート
        {
            return;
        }

        Debug.Log(mythumbs);
        Debug.Log("   ");
        Turn = false;
        flagForJudge = false;
        judge = false;
        

      



        

        switch (MyHands)
        {
            case 1:                 //自分の手が1本あるとき

                if (EnemyHands == 2)        //敵の手が二本
                {
                    if (fingers == 2)       //敵が両指を上げた
                    {
                        Animation_I.motion_I[0] = 1;

                    }

                    if (fingers == 1)   //敵が片指上げた

                    {
                        whichthumb = UnityEngine.Random.Range(1, 3);    //1なら左指が上がる。2なら右指上がる
                        if (whichthumb == 1) Animation_I.motion_I[1] = 1;
                        if (whichthumb == 2) Animation_I.motion_I[1] = 2;
                        whichthumb = 0;
                    }

                }

                else if (EnemyHands == 1)       //敵の手が一本
                {
                    
                    if (fingers == 1)
                    {
                        if (whichthumb == 1) Animation_I.motion_I[5] = 1;
                        if (whichthumb == 2) Animation_I.motion_I[6] = 1;
                    }

                }

                if (Myvoice == mythumbs + fingers)  //自分の言った数と合計の指一致
                {
                    Invoke("PlayerWin", 1.0f);
                }

                else    //自分の言った数と合計の指違う
                {
                    Invoke("Return_Player", 1.0f);
                }

                break;
            case 2:                 //自分の手が二本あるとき


                if (EnemyHands == 2)        //敵の手が二本
                {
                    if (fingers == 2)       //敵が両指を上げた
                    {
                        Animation_I.motion_I[0] = 1;
                    }

                    else if (fingers == 1)   //敵が片指上げた

                    {
                        whichthumb = UnityEngine.Random.Range(1, 3);    //1なら左指が上がる。2なら右指上がる
                        if (whichthumb == 1) Animation_I.motion_I[1] = 1;
                        if (whichthumb == 2) Animation_I.motion_I[2] = 1;
                        whichthumb = 0;
                    }


                }

                else if (EnemyHands == 1)       //敵の手が一本
                {
                    
                    if (fingers == 1)
                    {
                        if (whichthumb == 1) Animation_I.motion_I[5] = 1;
                        if (whichthumb == 2) Animation_I.motion_I[6] = 1;
                    }

                }

                if (Myvoice == mythumbs + fingers)  //自分の言った数と合計の指一致
                {
                    Invoke("TwotoOne_Player", 1.0f);
                }

                else    //自分の言った数と合計の指違う
                {
                    Invoke("Return_Player", 1.0f);
                }
                break;

            default:
                break;

        }
        Myvoice = -1;
    }

    void Start()
    {
        unitychan = GameObject.Find("unitychan_I");
        sp = GameObject.Find("SoundManager_I").GetComponent<SoundPlayer_I>();
        Panel = GameObject.Find("Panel_I");
        Image = GameObject.Find("Image_I");
        Text1 = GameObject.Find("Text_I");
        Text2 = GameObject.Find("Text1_I");
        Text3 = GameObject.Find("Text2_I");

        thumbcount = 0;
        EnemyHands = 2;
        MyHands = 2;
        Myvoice = -1;

        Intro();
    }

    
    
    // Update is called once per frame
    void Update()
    {
       

        if (!judge) return;


        if (Turn)                   //Turnがtrueなら自分のターン、falseなら相手のターン
        {
            if (!flagForJudge)
            {
                


                


                sp.Call("kakegoe");
                flagForJudge = true;
            }
            else if (flagForJudge)
            {
                Invoke("Judge_Player", 2.0f);
            }



        }

        else if (!Turn)
        {
            judge = false;
            
            Turn = true;


            sp.Call("kakegoe");
            Invoke("Judge_Enemy", 2.0f);

        }




    }
}
