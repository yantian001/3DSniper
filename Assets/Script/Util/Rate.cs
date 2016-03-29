using UnityEngine;
using System.Collections;

public class Rate : MonoBehaviour
{
    public string bundleId;

    public string iOSId;

    public void OnRateClicked()
    {
#if UNITY_ANDROID
        Application.OpenURL("market://details?id=" + bundleId);
#elif UNITY_IOS
        Application.OpenURL("http://itunes.apple.com/us/app/id" + iOSId);
#endif

    }
}
