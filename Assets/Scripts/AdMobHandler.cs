using UnityEngine;
using System.Collections;
using GoogleMobileAds.Api;

public class AdMobHandler : MonoBehaviour {

	public static BannerView bannerView;

	public static void RequestBanner()
	{
		#if UNITY_ANDROID
		string adUnitId = "ca-app-pub-4315560601834132/8312580200";
		#elif UNITY_IPHONE
		string adUnitId = "ca-app-pub-4315560601834132/7787969001";
		#else
		string adUnitId = "unexpected_platform";
		#endif

		bannerView = new BannerView(adUnitId, AdSize.Banner, AdPosition.Bottom);
		// Create an empty ad request.
		//AdRequest request = new AdRequest.Builder().Build();
		AdRequest request = new AdRequest.Builder()
		.AddTestDevice(AdRequest.TestDeviceSimulator)       // Simulator.
		.AddTestDevice("D26FFA174BA25D3C52C6D38CA410B17F")  // My test device.
		.Build();
		// Load the banner with the request.
		bannerView.LoadAd (request);
	}
}
