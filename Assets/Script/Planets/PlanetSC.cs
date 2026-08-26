using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;

public class PlanetSC : MonoBehaviour
{
    [HideInInspector] internal ArcadeSC arcadeCtrl;
    [HideInInspector] internal ChallengeSC challengeCtr;
    [HideInInspector] internal GenMNSC genCtr;

    internal float collisionStart = -0.5f;
    internal GameObject otherObject;
    internal float selfScore;
    public int planetID;
    internal int gameMode;
    internal bool isCheckDead;
    protected virtual void Start()
    {
        genCtr = GameObject.Find("GenMN").GetComponent<GenMNSC>();
        selfScore = 0.5f;
        isCheckDead = false;
        StartCoroutine(EnableCheckLoose());
        CheckGameomde();
    }
    private void CheckGameomde()
    {
        if (genCtr.curGameMode == 2)
        {
            gameMode = 2;
            arcadeCtrl = GameObject.Find("ArcadeMN").GetComponent<ArcadeSC>();
        }
        else if (genCtr.curGameMode == 3)
        {
            gameMode = 3;
            challengeCtr = GameObject.Find("ChallengeMN").GetComponent<ChallengeSC>();
        }
    }
    void Update()
    {
        CheckLoose();
    }
    internal void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject == otherObject)
        {
            if (Time.time - collisionStart >= 0.25f)
            {
                AddScoring();
                if(gameMode == 2)
                {
                    arcadeCtrl.PlaySFX();
                }else if(gameMode == 3)
                {
                    challengeCtr.PlaySFX();
                    challengeCtr.OnCompareTarget(gameObject.name);
                }

                Destroy(gameObject);
                Destroy(collision.gameObject);
            }
        }
    }
    private void AddScoring()
    {
        print("gamemode = " + gameMode);
        if (gameMode == 2)
        {
            arcadeCtrl.IncreaseScore(selfScore);
            arcadeCtrl.OnStartCountStreak();
        }
        else if (gameMode == 3) 
        {
            challengeCtr.IncreaseScore(selfScore);
            //challengeCtr.OnStartCountStreak() //Not write yet
        }
    }
    private void CheckLoose()
    {
        if (isCheckDead == true)
        {
            if (gameObject.transform.position.y >= 2.5f)
            {
                genCtr.OnShowLose();
            }
        }
    }
    IEnumerator EnableCheckLoose()
    {
        yield return new WaitForSeconds(1f);
        isCheckDead = true;
    }
}
