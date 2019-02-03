using UnityEngine;
using System.Collections;
using System.IO;
using UnityEngine.Networking;
using System;
using System.Collections.Generic;
using UnityEngine.UI;
using Newtonsoft.Json;

public class CallApi : MonoBehaviour
{

    string visionKey = "visionKEY"; // replace with your Vision API Key
    string resourceURL = "https://westeurope.api.cognitive.microsoft.com/vision/v2.0/analyze?details=Landmarks&language=en";

    public string imageName { get; private set; }
    string responseData;

    // Use this for initialization
    void Start()
    {
        imageName = Path.Combine(Application.streamingAssetsPath, "foto.jpeg");
    }

    IEnumerator GetInfo()
    {
        imageName = Path.Combine(Application.streamingAssetsPath, "foto.jpeg"); 
        byte[] bytesImage = UnityEngine.Windows.File.ReadAllBytes(imageName);

        var headers = new Dictionary<string, string>() {
            { "Ocp-Apim-Subscription-Key", visionKey },
            { "Content-Type", "application/octet-stream" }
        };

        WWW www = new WWW(resourceURL, bytesImage, headers);

        yield return www;
        responseData = www.text;
        Debug.Log(responseData);
        JSONApi answer = JsonConvert.DeserializeObject<JSONApi>(www.text);

        GameObject.Find("Response").GetComponent<Text>().text = answer.categories[0].detail.landmarks[0].name.ToString().ToUpper();
    }


    public void Analyze()
    {
        StartCoroutine(GetInfo());
    }



}
