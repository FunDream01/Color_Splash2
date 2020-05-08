using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameAnalyticsSDK;
using Facebook.Unity;
using System;
public class Analytics : MonoBehaviour
{
    // Start is called before the first frame update
    public bool SdkReady = false;
    public void LogLevelStarted(int level)
    {
       
            GameAnalytics.NewProgressionEvent(GAProgressionStatus.Start, level.ToString());
            var facebookParams = new Dictionary<string, object>();
            facebookParams[AppEventParameterName.ContentID] = "LevelStarted";
            facebookParams[AppEventParameterName.Description] = "User has loaded the level.";
            facebookParams[AppEventParameterName.Success] = "1";
            facebookParams[AppEventParameterName.Level] = level;

            FB.LogAppEvent(
                "StartedLevel",
                parameters: facebookParams
            );

    }


    public IEnumerator waitToCall(Action<int> SDKFunction, int level)
    {
        while (!SdkReady)
        {
            yield return new WaitForSeconds(0.05f);
        }
        SDKFunction(level);
    }
    public void LogLevelFailed(int level)
    {
        GameAnalytics.NewProgressionEvent(GAProgressionStatus.Fail, level.ToString());
        var facebookParams = new Dictionary<string, object>();
        facebookParams[AppEventParameterName.ContentID] = "Level Failed";
        facebookParams[AppEventParameterName.Description] = "User has failed the level.";
        facebookParams[AppEventParameterName.Success] = "1";
        facebookParams[AppEventParameterName.Level] = level;

        FB.LogAppEvent(
            "FailedLevel",
            parameters: facebookParams
        );
    }

    public void LogLevelSucceeded(int level)
    {
        GameAnalytics.NewProgressionEvent(GAProgressionStatus.Complete, level.ToString());
        var facebookParams = new Dictionary<string, object>();
        facebookParams[AppEventParameterName.ContentID] = "Level Succeeded";
        facebookParams[AppEventParameterName.Description] = "User has completed the level.";
        facebookParams[AppEventParameterName.Success] = "1";
        facebookParams[AppEventParameterName.Level] = level;

        FB.LogAppEvent(
            "SucceededLevel",
            parameters: facebookParams
        );
    }

    void Awake()
    {
        DontDestroyOnLoad(gameObject);
        if (!FB.IsInitialized)
        {
            // Initialize the Facebook SDK
            FB.Init(InitCallback, OnHideUnity);
        }
        else
        {
            // Already initialized, signal an app activation App Event
            FB.ActivateApp();
            SdkReady = true;
        }
        GameAnalytics.Initialize();
    }



    private void InitCallback()
    {
        if (FB.IsInitialized)
        {
            // Signal an app activation App Event
            FB.ActivateApp();
            SdkReady = true;

        }
        else
        {
            Debug.Log("Failed to Initialize the Facebook SDK");
        }
    }

    private void OnHideUnity(bool isGameShown)
    {
        if (!isGameShown)
        {
            // Pause the game - we will need to hide
            Time.timeScale = 0;
        }
        else
        {
            // Resume the game - we're getting focus again
            Time.timeScale = 1;
        }
    }
}
