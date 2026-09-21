using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;
using SimpleJSON;
using UnityEngine.Events;
using Newtonsoft.Json;
using System.IO;
using TMPro;
using UnityEngine.UI;
using System;
using System.Reflection.Emit;
using System.Security.Cryptography.X509Certificates;


public class ApiManager : MonoBehaviour
{
    public string JsonData;
    public string Response;
    private int sessionId;
    private string token;
    public DataHandler dataHandler;
    public string companyname;
    [HideInInspector]
    public string isSubscription;
    private string workAtH = null;
    private string fireS;

    public IEnumerator WebPostResponse(string api, string jsonData)
    {
        var req = new UnityWebRequest(api, "POST");    //UnityWebRequest handles the flow of HTTP communication with web servers.
        byte[] jsonToSend = new System.Text.UTF8Encoding().GetBytes(jsonData); //To calculate the exact size required by GetBytes to store the resulting bytes
        req.uploadHandler = (UploadHandler)new UploadHandlerRaw(jsonToSend); //This subclass copies input data into a native-code memory buffer at construction time,
                                                                             //and transmits that data verbatim as HTTP request body data.
        req.downloadHandler = (DownloadHandler)new DownloadHandlerBuffer();
        req.SetRequestHeader("Content-Type", "application/json");
        req.SetRequestHeader("Authorization", "Bearer " + PlayerPrefs.GetString("Token"));

        //Send the request then wait here until it returns
        yield return req.SendWebRequest();
        if (req.isNetworkError) // error in request
        {
            if (dataHandler.isRestartBtn)
            {
                dataHandler.RestartDataSentWithNoInternet.Invoke();

            }
            else if (dataHandler.isNextSceneBtn)
            {
                dataHandler.NextSceneDataSentWithNoInternet.Invoke();
            }
            //Debug.Log("Error While Sending: " + req.error);
        }
        else // done
        {
            if (dataHandler.isRestartBtn)
            {
                dataHandler.RestartDataSentWithInternet.Invoke();
                dataHandler.elapsedTime = 0;
            }
            else if (dataHandler.isNextSceneBtn)
            {
                dataHandler.NextSceneDataSentWithInternet.Invoke();
                dataHandler.elapsedTime = 0;
            }
            //Debug.Log("return" + req.downloadHandler.text);
            Response = req.downloadHandler.text;
            JsonParser(Response);
            //string strOutput = JsonUtility.ToJson(Response);
        }
        yield return new WaitForSeconds(0.5f);
    }
   
    public IEnumerator WebPostResponseAddTrainee(string api, string jsonData)
    {
        var req = new UnityWebRequest(api, "POST");    //UnityWebRequest handles the flow of HTTP communication with web servers.
        byte[] jsonToSend = new System.Text.UTF8Encoding().GetBytes(jsonData); //To calculate the exact size required by GetBytes to store the resulting bytes
        req.uploadHandler = (UploadHandler)new UploadHandlerRaw(jsonToSend); //This subclass copies input data into a native-code memory buffer at construction time,
                                                                             //and transmits that data verbatim as HTTP request body data.
        req.downloadHandler = (DownloadHandler)new DownloadHandlerBuffer();

        req.SetRequestHeader("Content-Type", "application/json");
        req.SetRequestHeader("Authorization", "Bearer " + PlayerPrefs.GetString("Token"));
        //Send the request then wait here until it returns
        yield return req.SendWebRequest();
        if (req.isNetworkError) // error in request
        {
            //Debug.Log("Error While Sending: " + req.error);
        }
        else // done
        {

            //Debug.Log("return" + req.downloadHandler.text);
            Response = req.downloadHandler.text;
            JsonParserLog(Response);
            //setData(Response);
            //Checker();
            //string strOutput = JsonUtility.ToJson(Response);
        }

        yield return new WaitForSeconds(0.5f);
    }
    public void JsonParserLog(string _webData)
    {
        var Jn_Object = JSONNode.Parse(_webData);
        sessionId = int.Parse(Jn_Object["data"]["sessionId"].Value);
        PlayerPrefs.SetInt("SessionId", sessionId);

        //  collector.SessionId = intValue;

    }
    public void JsonParser(string _webData)
    {
        var Jn_Object = JSONNode.Parse(_webData);

        //  collector.SessionId = intValue;

    }

    // Custom method to handle file download in WebGL
    public IEnumerator WebPostResponseLogin(string api, string jsonData)
    {

        var req = new UnityWebRequest(api, "POST");    //UnityWebRequest handles the flow of HTTP communication with web servers.
        byte[] jsonToSend = new System.Text.UTF8Encoding().GetBytes(jsonData); //To calculate the exact size required by GetBytes to store the resulting bytes
        req.uploadHandler = (UploadHandler)new UploadHandlerRaw(jsonToSend); //This subclass copies input data into a native-code memory buffer at construction time,
                                                                             //and transmits that data verbatim as HTTP request body data.
        req.downloadHandler = (DownloadHandler)new DownloadHandlerBuffer();
        req.SetRequestHeader("Content-Type", "application/json");
        //Send the request then wait here until it returns
        yield return req.SendWebRequest();
        if (req.isNetworkError) // error in request
        {
            //dataHandler.InternetPanel.SetActive(true);
            //Debug.Log("Error While Sending: " + req.error);
        }
        else // done
        {

            //Debug.Log("return" + req.downloadHandler.text);
            Response = req.downloadHandler.text;
           
           
           
            //string strOutput = JsonUtility.ToJson(Response);
        }
        if (req.downloadHandler.text.Contains("Incorrect Credentials"))
        {
            //Debug.Log("Incorrect email or password");
            dataHandler.IncorrectCredentials();
            
        }
        if(req.downloadHandler.text.Contains("Login Success"))
        {
            JsonParserLogin(Response);
            dataHandler.AssignCorrectCredentialsAfterResponse();
            setData(Response);
            Checker();
        }
        yield return new WaitForSeconds(0.5f);
    }
    public void Checker()
    {
        
        if(workAtH == "work-at-height" && workAtH!=null)
        {
            //dataHandler.PhoneNumberPanel.SetActive(true);
        }
        else
        {
            dataHandler.DeviceLockedEvent.Invoke();

        }

    }

    public void JsonParserLogin(string _webData)
    {
        var Jn_Object = JSONNode.Parse(_webData);

        token = Jn_Object["token"].Value;
        companyname = Jn_Object["data"]["companyname"].Value;
        PlayerPrefs.SetString("CompanyName", companyname); 
        isSubscription = Jn_Object["data"]["active"].Value;
        /* workAtH = Jn_Object["data"]["products"][0]["name"].Value;
         fireS= Jn_Object["data"]["products"][1]["name"].Value;*/

        PlayerPrefs.SetString("Token",token);
        //  collector.SessionId = intValue;
        //if (_webData == null)
        //{
        //    dataHandler.LoginPanel.SetActive(true);
        //}
        //else
        //{
        //    dataHandler.PhoneNumberPanel.SetActive(true);
        //}

    }

    [System.Serializable]
    public class Product
    {
        public string _id;
        public string name;
    }

    [System.Serializable]
    public class UserData
    {
        public string username;
        public string role;
        public string companyname;
        public bool active;
        public Product[] products;
    }

    [System.Serializable]
    public class ApiResponse
    {
        public string message;
        public UserData data;
        public string token;
    }

    void setData(string apiResponseJson)
    {
        // Parse the JSON response
        ApiResponse apiResponse = JsonUtility.FromJson<ApiResponse>(apiResponseJson);

        // Access the data
        string message = apiResponse.message;
        UserData userData = apiResponse.data;
        string token = apiResponse.token;
        workAtH = null;

        foreach (var item in userData.products)
        {

            if (item.name == "work-at-height")
            {
               workAtH = item.name;

            }
           
        }

       
    }
}
