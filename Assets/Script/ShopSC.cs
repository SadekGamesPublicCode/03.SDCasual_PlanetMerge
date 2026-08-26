using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopSC : MonoBehaviour
{
    [HideInInspector] GenMNSC genCtr;
    [HideInInspector] HomeSC homeCtr;
    [HideInInspector] DataSC data;
    [SerializeField] GameObject powerupPnl, moneypackPnl, outOfMoneyPnl;
    [SerializeField] Text pGemTxt, pMOneyTxt;
    [SerializeField] Text priceGuideTxt, priceClockTxt, priceMatchTxt;
    int pCurMoney, pCurGem;
    int itemPriceGuide, itemPriceClock, itemPriceMatch;
    int curItemToBuyOrder;
    void Start()
    {
        genCtr = GameObject.Find("GenMN").GetComponent<GenMNSC>();
        data = GameObject.Find("GenMN").GetComponent<DataSC>();
        homeCtr = GameObject.Find("MenuMN").GetComponent<HomeSC>();
        moneypackPnl.gameObject.SetActive(false);
        outOfMoneyPnl.gameObject.SetActive(false);
        SetPrice();
        LoadPlayerData();
    }
    void Update()
    {     }

    public void OnClosePanel() => homeCtr.UpdateHomeInfo();

    void LoadPlayerData()
    {
        pCurGem = data.pGems;
        pCurMoney = data.pTotalScore;

        pGemTxt.text = pCurGem.ToString();
        pMOneyTxt.text = pCurMoney.ToString();
    }
    void SetPrice()
    {
        itemPriceGuide = 10;
        itemPriceClock = 30;
        itemPriceMatch = 50;

        priceGuideTxt.text = itemPriceGuide.ToString();
        priceClockTxt.text = itemPriceClock.ToString();
        priceMatchTxt.text = itemPriceMatch.ToString();
    }
    bool IsEnoughMoney(int price, int type)
    {
        //Check this everytime buy anything
        if(type == 1)
        {
            //Buy point
            if (pCurMoney >= price)
            {
                return true;
            }
            else return false;
        }else if (type == 2)
        {
            if (pCurGem >= price)
            {
                return true;
            }
            return false;
        }
        return false;
    }
    void HandleBuy(int vaule, int type)
    {
        //Update UI here
        switch (type)
        {
            case 1:
                pCurMoney = vaule;
                pMOneyTxt.text = vaule.ToString();
                data.UpdateTotalScore(pCurMoney);
                break;
            case 2:
                pCurGem = vaule;
                pGemTxt.text = vaule.ToString();
                data.UpdateTotalGem(pCurGem);
                break;
        }
        LoadPlayerData();
        curItemToBuyOrder = -1;
    }

    #region Handle Power Up
    public void OnBuyLine()
    {
        curItemToBuyOrder = 0;
        if (IsEnoughMoney(itemPriceGuide, 1) == true)
        {
            int tempNewCurrency = pCurMoney - itemPriceGuide;
            pCurMoney = tempNewCurrency;
            HandleBuy(pCurMoney, 1);
            //Update PlayPrefs Power Ups
        }
        else
        {
            //Show no enough money
            OnShowOutOfMoney();
        }
    }
    public void OnBuyClock()
    {
        curItemToBuyOrder = 0;
        if (IsEnoughMoney(itemPriceClock, 1) == true)
        {
            int tempNewCurrency = pCurMoney - itemPriceClock;
            pCurMoney = tempNewCurrency;
            HandleBuy(pCurMoney, 1);
            //Update PlayPrefs Power Ups
        }
        else
        {
            //Show no enough money
            OnShowOutOfMoney();
        }
    }
    public void OnBuyMatch()
    {
        curItemToBuyOrder = 0;
        if (IsEnoughMoney(itemPriceMatch, 1) == true)
        {
            int tempNewCurrency = pCurMoney - itemPriceMatch;
            pCurMoney = tempNewCurrency;
            HandleBuy(pCurMoney, 1);
            //Update PlayPrefs Power Ups
        }
        else
        {
            //Show no enough money
            OnShowOutOfMoney();
        }
    }
    #endregion

    private void OnShowOutOfMoney()
    {
        outOfMoneyPnl.SetActive(true);
    }
    public void OnBuyByAds()
    {
        genCtr.OnCallbackShowAdsReward();
        if(curItemToBuyOrder == 0)
        {
            //Update PlayPrefs Power Ups
        }
        else if(curItemToBuyOrder == 1)
        {
            //Update PlayPrefs Power Ups
        }
        else if(curItemToBuyOrder == 2)
        {
            //Update PlayPrefs Power Ups
        }
        curItemToBuyOrder = 0;
    }
}
