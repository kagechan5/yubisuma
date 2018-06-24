using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VoiceInputTest : MonoBehaviour
{
    private PXCMSession session;
    private PXCMAudioSource source;
    private PXCMSpeechRecognition sr;
    private PXCMSpeechRecognition.Handler handler;


    private int start= 0;   //1ならじゃんけん、2ならいっせいのーで
    private const string matchstr1 = "スタート";
    private const string matchstr10 = "START";

    private const string matchstr2 = "すたーと";
    private const string matchstr3 = "0";
    private const string matchstr30 = "ぜろ";
    
    private const string matchstr4 = "1";
    private const string matchstr40 = "いち";
    private const string matchstr5 = "2";
    private const string matchstr50 = "に";
    private const string matchstr6 = "3";
    private const string matchstr60 = "さん";
    private const string matchstr7 = "4";
    private const string matchstr70 = "よん";


    public void Start()
    {
        session = PXCMSession.CreateInstance();
        source = session.CreateAudioSource();

        PXCMAudioSource.DeviceInfo dinfo = null;

        source.QueryDeviceInfo(0, out dinfo);
        source.SetDevice(dinfo);
        Debug.Log(dinfo.name);

        session.CreateImpl<PXCMSpeechRecognition>(out sr);

        PXCMSpeechRecognition.ProfileInfo pinfo;
        sr.QueryProfile(out pinfo);
        pinfo.language = PXCMSpeechRecognition.LanguageType.LANGUAGE_JP_JAPANESE;
        sr.SetProfile(pinfo);

        handler = new PXCMSpeechRecognition.Handler();
        handler.onRecognition = OnRecognition;
        sr.SetDictation();
        sr.StartRec(source, handler);
    }

    public void Update()
    {
        if (start == 1)
        {
            SceneManager.LoadScene("Locomotion");
        }

        

    }
    private void OnRecognition(PXCMSpeechRecognition.RecognitionData data)
    {


        Debug.Log(data.scores[0].sentence);
     
       if(data.scores[0].sentence.Contains(matchstr1))
        {
         
            Anyhand.select = 1;
            start = 1;
        }

       if (data.scores[0].sentence.Contains(matchstr10))
        {

            Anyhand.select = 1;
            start = 1;
        }

        if ( data.scores[0].sentence.Contains(matchstr2))
        {
            
            Anyhand.select = 1;
            start = 1;
        }
        if (data.scores[0].sentence.Contains(matchstr3))
        {

            Gamecontroller_I.Myvoice = 0;
        }

        if (data.scores[0].sentence.Contains(matchstr30))
        {

            Gamecontroller_I.Myvoice = 0;
        }

        if (data.scores[0].sentence.Contains(matchstr4))
        {
            Gamecontroller_I.Myvoice = 1;

        }
        if (data.scores[0].sentence.Contains(matchstr40))
        {
            Gamecontroller_I.Myvoice = 1;

        }
        if (data.scores[0].sentence.Contains(matchstr5))
        {
            Gamecontroller_I.Myvoice = 2;
        }
        if (data.scores[0].sentence.Contains(matchstr50))
        {
            Gamecontroller_I.Myvoice = 2;
        }
        if (data.scores[0].sentence.Contains(matchstr6))
        {
            Gamecontroller_I.Myvoice = 3;

        }
        if (data.scores[0].sentence.Contains(matchstr60))
        {
            Gamecontroller_I.Myvoice = 3;

        }

        if (data.scores[0].sentence.Contains(matchstr7))
        {
            Gamecontroller_I.Myvoice = 4;

        }
        if (data.scores[0].sentence.Contains(matchstr70))
        {
            Gamecontroller_I.Myvoice = 4;

        }




    }

    void OnDisable()
    {
        if (sr != null)
        {
            sr.StopRec();
            sr.Dispose();
        }

        if (session != null)
            session.Dispose();
    }

}