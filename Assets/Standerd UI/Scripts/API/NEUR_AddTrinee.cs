using OVRSimpleJSON;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Networking;

public class NEUR_AddTrainee : MonoBehaviour
{
    public string NEUR_AddTraineeURL = "https://www.xrtraining.in/api/trainee/add";
    public string token;
    public string Response;
    public int sessionId;
    public string ProductName;

    public TMP_InputField phoneNumberInput, userName;
    public UnityEvent TraineeAddedSuccessfully;

    private void SetToken()
    {
        token = PlayerPrefs.GetString(NEUR_Constant.NEUR_Token, "");
        ProductName = NEUR_Constant.NEUR_ProductName;
    }
    private void Update()
    {
        // Check if the 'T' key is pressed down
        if (Input.GetKeyDown(KeyCode.T))
        {
            // Call the AddTrainee method
            AddTrainee();
        }
    }
    public void AddTrainee()
    {
        SetToken();

        NEURAddTrainee newTrainee = new NEURAddTrainee
        {
            PhoneNumber = phoneNumberInput.text,
            Name = userName.text,
            Type = ProductName
        };

        string jsonData = newTrainee.ToJson();
        StartCoroutine(WebPostResponseAddTrainee(NEUR_AddTraineeURL, jsonData));
    }

    private IEnumerator WebPostResponseAddTrainee(string api, string jsonData)
    {
        using (var req = new UnityWebRequest(api, "POST"))
        {
            byte[] jsonToSend = new System.Text.UTF8Encoding().GetBytes(jsonData);

            req.uploadHandler = new UploadHandlerRaw(jsonToSend);
            req.downloadHandler = new DownloadHandlerBuffer();
            req.SetRequestHeader("Content-Type", "application/json");
            req.SetRequestHeader("Authorization", "Bearer " + token);

            yield return req.SendWebRequest();

            if (req.isNetworkError)
            {
                Debug.LogError("Error While Sending: " + req.error);
                // Optionally, handle the error with UI feedback
            }
            else
            {
                Debug.Log("Response: " + req.downloadHandler.text);
                Response = req.downloadHandler.text;

                TraineeAddedSuccessfully.Invoke();
                ClearInput();
                ParseJsonResponse(Response);
            }
        }
    }

    private void ParseJsonResponse(string responseData)
    {
        var jsonResponse = JSONNode.Parse(responseData);

        sessionId = jsonResponse["data"]["sessionId"].AsInt;
        PlayerPrefs.SetInt(NEUR_Constant.NEUR_SessionId, sessionId);
        PlayerPrefs.Save();
    }
    public void ClearInput()
    {
        userName.text = string.Empty;
        phoneNumberInput.text = string.Empty;
    }
}

public class NEURAddTrainee
{
    public string PhoneNumber { get; set; }
    public string Type { get; set; }
    public string Name { get; set; }

    public string ToJson()
    {
        JSONNode node = new JSONObject();
        node["phoneNumber"] = PhoneNumber;
        node["name"] = Name;
        node["type"] = Type;
        return node.ToString();
    }
}
