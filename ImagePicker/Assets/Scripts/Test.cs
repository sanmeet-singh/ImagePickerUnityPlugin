using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Text;
using System;

public class Test : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;

    public void Fetch()
    {
        #if UNITY_ANDROID
        AndroidJavaClass unityPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
        AndroidJavaObject activity = unityPlayer.GetStatic<AndroidJavaObject>("currentActivity");
        activity.Call("AskGalleryPermission", "Main Camera", "ImagePath");
        #endif
    }

    public void ImagePath(string path)
    {
        LoadThumbnailImage(path);
    }

    void LoadThumbnailImage(string imageString)
    {
        byte[] bArray = Convert.FromBase64String(imageString);
        
        Texture2D tex = new Texture2D(0, 0);
        tex.LoadImage(bArray);
            
        //rescale image accordingly
        TextureScale.Bilinear(tex, 500, 500);
        
        spriteRenderer.sprite = Sprite.Create(tex, new Rect(0.0f, 0.0f, tex.width, tex.height), new Vector2(0.5f, 0.5f), 100.0f);
    }
}


