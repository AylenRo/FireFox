using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DetectorDeColisiones : MonoBehaviour
{

    public Transform respawnPoint;

    #if UNITY_ANDROID && !UNITY_EDITOR
    public static AndroidJavaClass unityplayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
    public static AndroidJavaObject currentActivity = unityplayer.GetStatic<AndroidJavaObject>("currentActivity");
    public static AndroidJavaObject vibrator = currentActivity.Call<AndroidJavaObject>("getSystemService", "Vibrator");
#else
    public static AndroidJavaClass unityplayer;
    public static AndroidJavaObject currentActivity;
    public static AndroidJavaObject vibrator;
#endif

    private void OnTriggerEnter(Collider collision)
    {
        if(collision.gameObject.tag=="Fuego"){
            
            Vibrate();
            SceneManager.LoadScene("SampleScene");
        }
        
    }

    public static void Vibrate(long millisecond=250)
    {
        if(Isandroid())
        {
            vibrator.Call("vibrate", millisecond);
        }
        else
        {
            Handheld.Vibrate();
        }
    }
    public static void Cancel()
    {
        if(Isandroid())
        {
            vibrator.Call("cancel");
        }
    }
    public static bool Isandroid()
    {
    #if UNITY_ANDROID && !UNITY_EDITOR
        return true;
    #else
        return false;
    #endif
    }

}
