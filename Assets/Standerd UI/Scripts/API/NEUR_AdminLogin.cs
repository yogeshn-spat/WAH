using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Networking;
using TMPro;

public class NEUR_AdminLogin : MonoBehaviour
{
    public string AdminLoginURL = "https://www.xrtraining.in/api/auth/login";
    public TMP_InputField UserNameInput, PasswordInput;
    public TMP_Text CompanyName;
    public string token;
    private string _UserName, _Password, _CompanyName;
    public UnityEvent LoginSuccessful, NoProductAvailable, NoInternet;
    public GameObject IncorrectCredentials;

    private void Awake()
    {
        if (IsUserLoggedIn())
        {
            AutoLogin();
        }
        else
        {
            GuestLogin();
        }
    }

    public void AutoLogin()
    {
        string savedUserName = PlayerPrefs.GetString(NEUR_Constant.NEUR_AdminName, "");
        string savedPassword = PlayerPrefs.GetString(NEUR_Constant.NEUR_Password, "");

        if (!string.IsNullOrEmpty(savedUserName) && !string.IsNullOrEmpty(savedPassword))
        {
            AdminInput(savedUserName, savedPassword);
        }
    }

    public bool IsUserLoggedIn()
    {
        return PlayerPrefs.GetInt(NEUR_Constant.NEUR_IsLoggedIn, 0) == 1;
    }

    public void NewLogin()
    {
        if (!string.IsNullOrEmpty(UserNameInput.text) && !string.IsNullOrEmpty(PasswordInput.text))
        {
            AdminInput(UserNameInput.text, PasswordInput.text);
        }
    }

    public void GuestLogin()
    {
        AdminInput("Guest", "Guest");
    }

    private void AdminInput(string name, string password)
    {
        _UserName = name;
        _Password = password;

        NEURAdminInput userInput = new NEURAdminInput { username = name, password = password };
        string jsonData = JsonUtility.ToJson(userInput);

        StartCoroutine(WebPostResponseLogin(AdminLoginURL, jsonData));
    }

    private IEnumerator WebPostResponseLogin(string api, string jsonData)
    {
        using (var req = new UnityWebRequest(api, "POST"))
        {
            byte[] jsonToSend = new System.Text.UTF8Encoding().GetBytes(jsonData);
            req.uploadHandler = new UploadHandlerRaw(jsonToSend);
            req.downloadHandler = new DownloadHandlerBuffer();
            req.SetRequestHeader("Content-Type", "application/json");

            yield return req.SendWebRequest();

            if (req.isNetworkError)
            {
                NoInternet.Invoke();
                Debug.LogError($"Error While Sending: {req.error}");
            }
            else
            {
                HandleResponse(req.downloadHandler.text);
            }
        }
    }

    private void HandleResponse(string response)
    {
        if (response.Contains("Incorrect Credentials"))
        {
            StartCoroutine(ShowIncorrectCredentials());
        }
        else if (response.Contains("Login Success"))
        {
            NEURApiResponse apiResponse = JsonUtility.FromJson<NEURApiResponse>(response);
            _CompanyName = "Welcome  " + apiResponse.data.companyname;
            token = apiResponse.token;

            SaveAdminData(apiResponse.data);
            CheckProducts(apiResponse.data.products);
        }
    }

    private IEnumerator ShowIncorrectCredentials()
    {
        IncorrectCredentials.SetActive(true);
        yield return new WaitForSeconds(3);
        IncorrectCredentials.SetActive(false);
    }

    private void CheckProducts(NEURProduct[] products)
    {
        bool productFound = false;

        foreach (var item in products)
        {
            if (item.name == NEUR_Constant.NEUR_ProductName)
            {
                productFound = true;
                break;
            }
        }

        if (!productFound)
        {
            NoProductAvailable.Invoke();
        }
        else
        {
            LoginSuccessful.Invoke();

        }
        ClearInput();
    }

    private void SaveAdminData(NEURUserData userData)
    {
        PlayerPrefs.SetString(NEUR_Constant.NEUR_AdminName, _UserName);
        PlayerPrefs.SetString(NEUR_Constant.NEUR_Password, _Password);
        PlayerPrefs.SetString(NEUR_Constant.NEUR_CompanyName, _CompanyName);
        PlayerPrefs.SetString(NEUR_Constant.NEUR_Token, token);
        PlayerPrefs.SetInt(NEUR_Constant.NEUR_IsLoggedIn, 1);
        PlayerPrefs.Save();
        CompanyName.text = _CompanyName;
    }

    public void ClearInput()
    {
        UserNameInput.text = string.Empty;
        PasswordInput.text = string.Empty;
    }
}

[System.Serializable]
public class NEURAdminInput
{
    public string username;
    public string password;
}

[System.Serializable]
public class NEURProduct
{
    public string _id;
    public string name;
}

[System.Serializable]
public class NEURUserData
{
    public string username;
    public string role;
    public string companyname;
    public bool active;
    public NEURProduct[] products;
}

[System.Serializable]
public class NEURApiResponse
{
    public string message;
    public NEURUserData data;
    public string token;
}
