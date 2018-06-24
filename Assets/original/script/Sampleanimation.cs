using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sampleanimation : MonoBehaviour {

    private Animator animator;

    private const string key_isRock = "isRock";
    private const string key_isScissors = "isScissors";
    private const string key_isPaper = "isPaper";
    private const string key_isWinner = "isWinner";
    private const string key_isLoser = "isLoser";

    static public int motion=0;
    static public int aiko = 0;
    static public int finish = 0;   //finish=1で勝ち、finish=2で負け
    
    


    private void Reset()
    {
        this.animator.SetBool(key_isRock, false);
        this.animator.SetBool(key_isScissors, false);
        this.animator.SetBool(key_isPaper, false);
        
    }

    void Start() {
        this.animator = GetComponent<Animator>();
        motion = 0;
        aiko = 0;
        finish = 0;
    }

    // Update is called once per frame
    void Update()
    {
   
        if (motion == 1)
        {
            this.animator.SetBool(key_isRock, true);

        }
        else if (motion == 2)
        {
            this.animator.SetBool(key_isScissors, true);
        }

        else if (motion == 3)
        {
            this.animator.SetBool(key_isPaper, true);

        }

        if (aiko == 1)
        {
            
            Invoke("Reset", 2.0f);
            motion = 0;
        }

        switch (finish)
        {
            case 2:
                this.animator.SetBool(key_isWinner, true);
                break;
            case 1:
                this.animator.SetBool(key_isLoser, true);
                break;
            default:
                break;
        }



        aiko = 0;
    }
}
