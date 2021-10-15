using UnityEngine;
using System;
using GoogleMobileAds.Api;

public class AdManager : MonoBehaviour
{
    private InterstitialAd interstitial;
    private BannerView bannerAd;


    private string bannerAdId = "ca-app-pub-3940256099942544/6300978111";
    private string intersitialAdId = "ca-app-pub-3940256099942544/1033173712";


    void Start()
    {

        MobileAds.Initialize(InitializationStatus => { });
        this.RequestInterstitial();
        this.RequestBanner();
    }


    private void RequestInterstitial()
    {
        string adUnitId = intersitialAdId;
        //Clean up interstitial ad before creating a new one
        if (this.interstitial != null)
            this.interstitial.Destroy();

        this.interstitial = new InterstitialAd(adUnitId);
        // Create an empty ad request.
        AdRequest request = new AdRequest.Builder().Build();
        // Load the interstitial with the request.
        this.interstitial.LoadAd(request);
    }

    public void InterestitialShow()
    {
        if (this.interstitial.IsLoaded())
        {
            this.interstitial.Show();
        }
        else
        {
            Debug.Log("Interstitial AD is not ready yet ");
        }
        RequestInterstitial();
    }


    private void RequestBanner()
    {
        string adUnitId = bannerAdId;
        this.bannerAd = new BannerView(adUnitId, AdSize.SmartBanner, AdPosition.Bottom);
        AdRequest request = new AdRequest.Builder().Build();
        this.bannerAd.LoadAd(request);

    }

}
