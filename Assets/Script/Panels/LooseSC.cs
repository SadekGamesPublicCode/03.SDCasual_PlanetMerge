using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LooseSC : MonoBehaviour
{
    [HideInInspector] GenMNSC genCtr;
    private int gameMode;
    void Start()
    {
        genCtr = GameObject.Find("GenMN").GetComponent<GenMNSC>();
        //gameMode = 0;
    }
    public void OnContinue()
    {
        genCtr.OnCallbackShowAdsReward();
        genCtr.OnHideLose();
    }
    public void OnHome() 
    {
        print("in OnHome, call from " + genCtr.curGameMode);
        genCtr.OnLoadHome();
        genCtr.OnHideLose();
    } 
    public void OnNewGame()
    {
        if(gameMode== 2)
        {
            genCtr.OnLoadArcade();
            genCtr.OnHideLose();
        }
        else if(gameMode == 3)
        {
            genCtr.OnLoadChallenge();
            genCtr.OnHideLose();
        }
    }
    public void AssignGamemode()
    {
        gameMode = genCtr.curGameMode;
    }
}
