using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LooseSC : MonoBehaviour
{
    [HideInInspector] GenMNSC genCtr;
    [HideInInspector] ArcadeSC arcadeCtrl;
    [HideInInspector] ChallengeSC challengeCtr;
    private int gameMode;
    void Start() 
    {
        genCtr = GameObject.Find("GenMN").GetComponent<GenMNSC>();
    }

    public void OnContinue()
    { 
        genCtr.OnCallbackShowAdsReward();
        genCtr.OnHideLose();
    }
    public void OnHome() => genCtr.OnLoadHome();
    public void OnNewGame() => genCtr.OnLoadArcade();
}
