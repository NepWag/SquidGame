using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds.Api;
using System;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class AdManager : MonoBehaviour
{
    string Banner_AD_ID = "ca-app-pub-8290710233235536/3249808938";
    string Interstitial_AD_ID = "ca-app-pub-8290710233235536/1343004350";
    string Video_AD_ID = "ca-app-pub-8290710233235536/1487765583";
    public static AdManager instance;
    private BannerView bannerView;
    private InterstitialAd interstitial;
    private RewardedAd rewardedAd;
    void Awake()
    {
        if (instance == null) 
        {
            instance = this;
        } 
    }
    void Start()
    {
       MobileAds.Initialize(initStatus => { });
        // // Called when an ad request has successfully loaded.
        // rewardBasedVideo.OnAdLoaded += HandleRewardBasedVideoLoaded;
        // // Called when an ad request failed to load.
        // rewardBasedVideo.OnAdFailedToLoad += HandleRewardBasedVideoFailedToLoad;
        //  // Called when the user should be rewarded for watching a video.
        // rewardBasedVideo.OnAdRewarded += HandleRewardBasedVideoRewarded;
        // // Called when the ad is closed.
        // rewardBasedVideo.OnAdClosed += HandleRewardBasedVideoClosed;   
         RequestRewardBasedVideo();
    }
    public void RequestBanner()
    {
        // Create a 320x50 banner at the top of the screen.
        this.bannerView = new BannerView(Banner_AD_ID, AdSize.Banner, AdPosition.Bottom);
        // Called when an ad request has successfully loaded.
        this.bannerView.OnAdLoaded += this.HandleOnAdLoaded;
        // Called when an ad request failed to load.
        this.bannerView.OnAdFailedToLoad += this.HandleOnAdFailedToLoad;
        // Called when an ad is clicked.
        this.bannerView.OnAdOpening += this.HandleOnAdOpened;
        // Called when the user returned from the app after an ad click.
        this.bannerView.OnAdClosed += this.HandleOnAdClosed;
        // Called when the ad click caused the user to leave the application.
        // this.bannerView.OnAdLeavingApplication += this.HandleOnAdLeavingApplication;
        Debug.Log("............RequestBanner...............");
    }
    public void ShowBannerAD()
    {
        // Create an empty ad request.
        AdRequest request = new AdRequest.Builder().Build();
        // Load the banner with the request.
        this.bannerView.LoadAd(request);
        Debug.Log("..............ShowBanner......................");
    }
    public void DestroyBanner()
    {
        if(this.bannerView!=null)
        {
            this.bannerView.Destroy();
            Debug.Log("..............DestroyBanner......................");
        }
    }
    public void RequestInterstitial()
    {
        // Initialize an InterstitialAd.
        this.interstitial = new InterstitialAd(Interstitial_AD_ID);
        // Called when an ad request has successfully loaded.
        this.interstitial.OnAdLoaded += HandleOnAdLoaded;
        // Called when an ad request failed to load.
        this.interstitial.OnAdFailedToLoad += HandleOnAdFailedToLoad;
        // Called when an ad is shown.
        this.interstitial.OnAdOpening += HandleOnAdOpened;
        // Called when the ad is closed.
        this.interstitial.OnAdClosed += HandleOnAdClosed;
        // Called when the ad click caused the user to leave the application.
        // this.interstitial.OnAdLeavingApplication += HandleOnAdLeavingApplication;
        AdRequest request = new AdRequest.Builder().Build();
        this.interstitial.LoadAd(request);
        Debug.Log("..............IntersititialRequest......................");
    }
    public void ShowInterstitialAd()
    {
        if (this.interstitial.IsLoaded())
        {
            this.interstitial.Show();
            Debug.Log("..............IntersititialShow......................");
        }
    }
    public void NotShowIntersititialAd()
    {
        if (this.interstitial.IsLoaded())
        {
            this.interstitial.Destroy();
            Debug.Log("..............IntersititialDestroy......................");
        }
    }

    public void RequestRewardBasedVideo()
    {
        // rewardBasedVideo = RewardBasedVideoAd.Instance;
        // // Called when an ad request has successfully loaded.
        // rewardBasedVideo.OnAdLoaded += HandleRewardBasedVideoLoaded;
        // // Called when an ad request failed to load.
        // rewardBasedVideo.OnAdFailedToLoad += HandleRewardBasedVideoFailedToLoad;
        //  // Called when the user should be rewarded for watching a video.
        // rewardBasedVideo.OnAdRewarded += HandleRewardBasedVideoRewarded;
        // // Called when the ad is closed.
        // rewardBasedVideo.OnAdClosed += HandleRewardBasedVideoClosed;
        // // Create an empty ad request.
        // AdRequest request = new AdRequest.Builder().Build();
        // // Load the rewarded video ad with the request.
        // this.rewardBasedVideo.LoadAd(request, Video_AD_ID);

         this.rewardedAd = new RewardedAd(Video_AD_ID);
         // Called when an ad request has successfully loaded.
        this.rewardedAd.OnAdLoaded += HandleRewardedAdLoaded;
        // Called when an ad request failed to load.
        // this.rewardedAd.OnAdFailedToLoad += HandleRewardedAdFailedToLoad;
        // Called when an ad is shown.
        this.rewardedAd.OnAdOpening += HandleRewardedAdOpening;
        // Called when an ad request failed to show.
        this.rewardedAd.OnAdFailedToShow += HandleRewardedAdFailedToShow;
        // Called when the user should be rewarded for interacting with the ad.
        this.rewardedAd.OnUserEarnedReward += HandleUserEarnedReward;
        // Called when the ad is closed.
        this.rewardedAd.OnAdClosed += HandleRewardedAdClosed;

        // Create an empty ad request.
        AdRequest request = new AdRequest.Builder().Build();
        // Load the rewarded ad with the request.
        this.rewardedAd.LoadAd(request);
        Debug.Log("..............RewardedRequest......................");
    }

    public void ShowVideoRewardAd()
    {
         if (this.rewardedAd.IsLoaded()) 
         {
             this.rewardedAd.Show();
              Debug.Log("..............RewardedShow......................");
         }
    }
    // FOR EVENTS AND DELEGATES FOR ADS
    public void HandleOnAdLoaded(object sender, EventArgs args)
    {
        // if (this.interstitial.IsLoaded())
        // {
        //     this.interstitial.Show();
        // }
    }
    public void HandleOnAdFailedToLoad(object sender, AdFailedToLoadEventArgs args)
    {
        
    }
    public void HandleOnAdOpened(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleAdOpened event received");
    }
    public void HandleOnAdClosed(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleAdClosed event received");
    }
    public void HandleOnAdLeavingApplication(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleAdLeavingApplication event received");
    }
    public void HandleRewardBasedVideoLoaded(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleRewardBasedVideoLoaded event received");
    }
    public void HandleRewardBasedVideoFailedToLoad(object sender, AdFailedToLoadEventArgs args)
    {
        // MonoBehaviour.print("HandleRewardBasedVideoFailedToLoad event received with message: "+ args.Message);
    }
    public void HandleRewardBasedVideoClosed(object sender, EventArgs args)
    {
    }
    public void HandleRewardBasedVideoRewarded(object sender, Reward args)
    {
    }
     public void HandleRewardedAdLoaded(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleRewardedAdLoaded event received");
    }
    public void HandleRewardedAdFailedToLoad(object sender, AdFailedToLoadEventArgs args)
    {
        MonoBehaviour.print(
            "HandleRewardedAdFailedToLoad event received with message: "
                             + args.Message);
    }
    public void HandleRewardedAdOpening(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleRewardedAdOpening event received");
    }
    public void HandleRewardedAdFailedToShow(object sender, AdErrorEventArgs args)
    {
        MonoBehaviour.print(
            "HandleRewardedAdFailedToShow event received with message: "
                             + args.Message);
    }
    public void HandleRewardedAdClosed(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleRewardedAdClosed event received");
        
    }
    public void HandleUserEarnedReward(object sender, Reward args)
    {
         MoneyManager.instance.RewardedMoney();
         SceneManager.LoadScene ("Main");
    }
}

