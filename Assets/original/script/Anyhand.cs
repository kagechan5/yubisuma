using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Leap;
using Leap.Unity;



public class Anyhand : MonoBehaviour
{

    Controller controller;
    static public int select = 0;   //1のときじゃんけん、2のときいっせいのーせ
    int countR = 0;
    int countS = 0;
    int countP = 0;
    int[] count3 = { 0, 0, 0 };     //count3[0]はグー、count3[1]はチョキ、count3[2]はパー
    const string defaultComent = "グー,チョキ,パー";
    public static readonly string[] Coment = defaultComent.Split(',');

    int count_First = 0;    //一つ目の手の親指が立ってるか数える
    int count_Second = 0;   //二つ目の手の親指が立ってるか数える

    int count_I = 0;    //手が一本になったときに自分の手数える

    public GameObject[] FingerObjects;

    int CheckThumbs(int thumbA,int thumbB)
    {
        int num = 0;

        if (thumbA > 10)
        {
            num++;

        }

        if (thumbB > 10)
        {
            num++;
          
        }

        return num;

    }

    int CheckThumb(int thumb)
    {
        int num = 0;
        if (thumb > 10)
        {
            num++;
           
        }
        return num;
    }


    void Start()
    {
        controller = new Controller();
        

    }

    void OnApplicationQuit()
    {
        if (controller != null)
        {
            controller.StopConnection();
            controller.Dispose();
            controller = null;
        }
    }

    void Check(int[] count)
    {
        int i = 3;
        for (i = 0; i < 3; i++)
        {
            if (20 < count[i])
            {
                
                GameController.hand = i+1;
                
                count[i] = 0;
            }
        }
    }

    


    void Update()
    {
        Frame frame = controller.Frame();
        List<Hand> hands = frame.Hands;

        switch (select) {             //select=1ならじゃんけん、2ならいっせいのーせ
             
            case 1:
                int count;
                
                if (0 < hands.Count)
                  {
                     Hand firstHand = hands[0];
                    List<Finger> fingers = firstHand.Fingers;

                    count = 0;


                  for (int ii = 0; ii < fingers.Count; ++ii)
                   {
                     Finger finger = fingers[ii];
                  if (finger.IsExtended == true)
                      {
                           count++;

                         }

                       //var fingerObj = FingerObjects[ii];
                        Vector v = finger.TipPosition;

                        //   fingerObj.transform.position = UnityVectorExtension.ToVector3(v) / 10;
                  }   //指の数を数える

                    switch (count)
                       {
                         case 0:
                           count3[0]++;
                           count3[1] = 0;
                             count3[2] = 0;
                              break;
                          case 2:
                          count3[0] = 0;
                          count3[1]++;
                          count3[2] = 0;
                          break;
                         case 5:
                            count3[0] = 0;
                           count3[1] = 0;
                         count3[2]++;
                         break;
                        default:
                          count3[0] = 0;
                            count3[1] = 0;
                            count3[2] = 0;
                            break;
                        }

                          Check(count3);
                    

                 }
                break;

            case 2:
                

                if ( hands.Count==2)        //まだ自分の手が二本あるとき
                {

                    


                    Hand firstHand = hands[0];
                    Hand secondHand = hands[1];
                    List<Finger> firstFingers = firstHand.Fingers;
                    List<Finger> secondFingers = secondHand.Fingers;


                    Finger firstHand_thumb = firstFingers[0];
                    Finger secondHand_thumb = secondFingers[0];

                    if (firstHand_thumb.IsExtended == true)
                    {
                        count_First++;
                    }
                    else { count_First = 0; }

                    if (secondHand_thumb.IsExtended == true)
                    {
                        count_Second++;
                    }
                    else { count_Second = 0; }

                     Gamecontroller_I.thumbcount = CheckThumbs(count_First, count_Second); //指の本数確定
                    

                }

                if (hands.Count == 1)        //自分の手が1本あるとき
                {




                    Hand Hand = hands[0];
                    
                    List<Finger> Fingers = Hand.Fingers;
                   

                    Finger Hand_thumb = Fingers[0];
                   
                    if (Hand_thumb.IsExtended == true)
                    {
                        count_I++;
                    }
                    else { count_I = 0; }


                    Gamecontroller_I.thumbcount = CheckThumb(count_I);
                   

                }

                

                break;

        }
        

    }
}
