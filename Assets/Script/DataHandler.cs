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
using System.Threading;
using static DataHandler;
using System.Security.Cryptography.X509Certificates;
using static OVRPlugin;

public class DataHandler : MonoBehaviour
{
    //public TextMeshProUGUI timerText;
    public AnchorWithoutPassword anchorWithoutPassword;
    private Scene GetScene;
    private bool isTimerRunning = false;
    public float elapsedTime = 0f;
    private ApiManager apiManager;
    private StepsCalculator stepCalculator;
    private string completesStatus;
    private string phonenumber;
    public TMP_InputField phoneNumnerInput;
    public TMP_InputField userName, Password;
    public SessionTimer sessionTimer;
    public float totalSessionTimer;
    public GameObject LoginSuccessText, IncorrectText, PhoneNumberPanel, PhoneNumberPanelparent,LoginPanel, BackButton;
    public UnityEvent DeviceLockedEvent;
    public TextMeshProUGUI CompanyName;
    [HideInInspector]
    public string companyNameOfUser;
    public string nameOfUser;
    public string passwordOfUser;
    public bool isLastLoad;
    private bool WrongCred;
    private bool isFirstTime;
    public bool LearningScene = false;
    public bool EvaluationScene = false;
    public bool LoginPanelUI = false;


    public bool LearningStartTime = false;
    public bool IsSession;

    public GameObject AnchorBtnParent;
    public bool isStart;

    public bool isRestartBtn;

    public bool isNextSceneBtn;
    public bool isNextSceneOBBtn;

    public UnityEvent RestartDataSentWithInternet;
    public UnityEvent RestartDataSentWithNoInternet;

    public UnityEvent NextSceneDataSentWithInternet;
    public UnityEvent NextSceneDataSentWithNoInternet;

    public UnityEvent NextSceneDataOBSentWithInternet;
    public UnityEvent NextSceneDataSentOBWithNoInternet;
    public void Start()
    {
        isStart = true;
        InitializeGameData();
        elapsedTime = 0f;
    }
    public void InitializeGameData()
    {
        // script------------------
        if (FindAnyObjectByType<ApiManager>() != null)
            apiManager = FindAnyObjectByType<ApiManager>();

        if (FindAnyObjectByType<StepsCalculator>() != null)
            stepCalculator = FindAnyObjectByType<StepsCalculator>();

        string sceneName = SceneManager.GetActiveScene().name;
        if (sceneName == "OnBoarding,Learning")
        {
            GetScene = Scene.Learning;
        }

        // Assign Scene name
        if (sceneName == "WorkAtHeight_POC_Julika_Evaluation")
            GetScene = Scene.Evaluation;

        // Timer data
        if (FindAnyObjectByType<SessionTimer>() != null)
        {
            sessionTimer = FindAnyObjectByType<SessionTimer>();
        }
        else
        {
            StartCoroutine("AssignValues");
        }

        FetchCompanyData();

    }
    public void FetchCompanyData()
    {
        isFirstTime = true;
        companyNameOfUser = PlayerPrefs.GetString("CompanyName");
        nameOfUser = PlayerPrefs.GetString("UserName");
        passwordOfUser = PlayerPrefs.GetString("Password");
        AutomaticLogin();

    }

    IEnumerator AssignValues()
    {
        yield return new WaitForSeconds(1f);
        sessionTimer = FindAnyObjectByType<SessionTimer>();
    }

    public void AddTraineeS()
    {
        AddTrainee addTrainee = new AddTrainee();
        //phonenumber = phoneNumnerInput.text;
       // addTrainee.phoneNumber = "8999989999";
        addTrainee.phoneNumber = phoneNumnerInput.text;
      //  Debug.Log("Nummm " +  addTrainee.phoneNumber);
       // addTrainee.company = "65573defb4f4b1afa02fda45";
        addTrainee.type = "work-at-height";
        addTrainee.sessionId ="";
        string jsonData = JsonConvert.SerializeObject(addTrainee);
        StartCoroutine(apiManager.WebPostResponseAddTrainee("https://www.xrtraining.in/api/trainee/add", jsonData));
     
    }
    public enum Scene
    {
        Learning,
        Evaluation
    }
   
    public class Learning
    {
        private int SessionID;
        private string startTimer;
        private string endTimer;
        private string LanguageSelected;
        private string SessionTimer;
        private string ProductType;

        public int sessionId
        {
            get { return SessionID; }
            set { SessionID = value; }
        }
        public string startTime
        {
            get { return startTimer; }
            set { startTimer = value; }
        }

        public string endTime
        {
            get { return endTimer; }
            set { endTimer = value; }
        }
        public string languageSelected
        {
            get { return LanguageSelected; }
            set { LanguageSelected = value; }
        }
        public string sessionTimer
        {
            get { return SessionTimer; }
            set { SessionTimer = value; }
        }
        public string productType
        {
            get { return ProductType; }
            set { ProductType = value; }
        }

    }
    public class LearningTimerData
    {
        public Learning Learning { get; set; }
        public TimerData TimerData { get; set; }
    }
    public class EvaluvationTimerData
    {
        public Evaluation Evaluation { get; set; }
        public TimerData TimerData { get; set; }

    }
    public class Evaluation
    {
        private int SessionID;
    
        private string startTimer;
        private string endTimer;
        private string Score;
       // private string SessionTimer;
        //   private string completionStatus;



        public int sessionId
        {
            get { return SessionID; }
            set { SessionID = value; }
        }
        public string startTime
        {
            get { return startTimer; }
            set { startTimer = value; }
        }

        public string endTime
        {
            get { return endTimer; }
            set { endTimer = value; }
        }
        public string score
        {
            get { return Score; }
            set { Score = value; }
        }
        /*  public string CompletionStatus
          {
              get { return completionStatus; }
              set { completionStatus = value; }
          }*/
      /*  public string sessionTimer
        {
            get { return SessionTimer; }
            set { SessionTimer = value; }
        }*/


    }
    public class Timer
    {
        private string startTimer;
        private string endTimer;

        public string startTime
        {
            get { return startTimer; }
            set { startTimer = value; }
        }

        public string endTime
        {
            get { return endTimer; }
            set { endTimer = value; }
        }
    }
    public class TimerData
    {
        public Timer Timer { get; set; }
    }
    public class AddTrainee
    {
        private string PhoneNumber;
       // private string Company;
        private string Type;
        private string SessionId;

        public string phoneNumber
        {
            get { return PhoneNumber; }
            set { PhoneNumber = value; }
        }

       /* public string company
        {
            get { return Company; }
            set { Company = value; }
        }*/
        public string type
        {
            get { return Type; }
            set { Type = value; }
        }
        public string sessionId
        {
            get { return SessionId; }
            set { SessionId = value; }
        }
    }
    public class UserInput
    {
        public string username;
        public string password;
    }
    public class SessionTimers
    {
        public string startTime;
        public string endTime;
        public int sessionId;
        public string productType;
    }

    public void LearningSceneEnable()
    {
        LearningScene = true;
    }
    public void EvaluationSceneEnable()
    {
        EvaluationScene = true;
    }
    public void SetLearningData()
    {
       /* LearningTimerData learningData = new LearningTimerData
        {
            Learning = new Learning
            {
                languageSelected = PlayerPrefs.GetString("Language"),// Set the desired language name
            },
            TimerData = new TimerData
            {
                Timer = new Timer
                {
                    startTime = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss"),
                    endTime = DateTime.Now.AddSeconds(elapsedTime).ToString("yyyy-MM-dd hh:mm:ss")
                }
            }
        };*/
       Learning learning = new Learning();
        {
            learning.sessionId = PlayerPrefs.GetInt("SessionId"); 
            learning.startTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
           // learning.startTime = DateTimeOffset.Now.ToUnixTimeSeconds().ToString();
            learning.endTime = DateTime.Now.AddSeconds(elapsedTime).ToString("yyyy-MM-dd HH:mm:ss");
            // learning.endTime = DateTimeOffset.Now.AddSeconds(elapsedTime).ToUnixTimeSeconds().ToString();
            //learning.languageSelected = "English";
            learning.languageSelected = PlayerPrefs.GetString("Language");
            learning.productType = "work-at-height";
          //  learning.sessionTimer = totalSessionTimer.ToString();
        }

        string jsonData = JsonConvert.SerializeObject(learning);
        StartCoroutine(apiManager.WebPostResponse("https://www.xrtraining.in/api/learning", jsonData));

       
    }
    public void SetEvaluationData()
    {
        //if (stepCalculator.Score == 5)
        //{
        //    completesStatus = "Complete";
        //}
        //else
        //{
        //    if(stepCalculator.Score == 0)
        //    {
        //        stepCalculator.Score = 0;
        //    }
        //    completesStatus = "Incomplete";
        //}
        Evaluation evaluation = new Evaluation();
        {
            evaluation.sessionId = PlayerPrefs.GetInt("SessionId");
            evaluation.startTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            evaluation.endTime = DateTime.Now.AddSeconds(elapsedTime).ToString("yyyy-MM-dd HH:mm:ss");
            evaluation.score = stepCalculator.Score.ToString() + "/5";
           // evaluation.sessionTimer = sessionTimer.ToString();
        }
       /* EvaluvationTimerData evaluationData = new EvaluvationTimerData
        {
            Evaluation = new Evaluation
            {
                sessionId = "7955",
               // CompletionStatus = completesStatus,
                score = stepCalculator.Score.ToString()+ "/5"


            },
            TimerData = new TimerData
            {
                Timer = new Timer
                {
                    startTime = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss tt"),
                    endTime = DateTime.Now.AddSeconds(elapsedTime).ToString("yyyy-MM-dd hh:mm:ss tt")
                }
            }
        };*/

        string jsonData = JsonConvert.SerializeObject(evaluation);
        StartCoroutine(apiManager.WebPostResponse("https://www.xrtraining.in/api/work-at-height-evaluation", jsonData));
    }

    public void UpdateDetails()
    {
        UpdateScene(GetScene);
    }
    public void LastLoad(bool isTrue)
    {
        isLastLoad = isTrue;
    }

    public void ActiveSessionTimer(bool enable)
    {
        IsSession = enable;
    }
    public void UpdateScene(Scene scene)
    {
        if (LearningScene)
        {
            if (!isLastLoad)
            {
                sessionTimer.isSessionTimerRunning = false;
                //isTimerRunning = false;
                sessionTimer.GetTotalTime();
                UpdateSessionTimer();
            }
        }
       
        switch (scene)
        {
            case Scene.Learning:
                SetLearningData();
                break;
            case Scene.Evaluation:
                SetEvaluationData();
                break;
            default:
                //Debug.LogError("Invalid Scene type");
                break;
        }
    }
    public void UpdateSessionTimer()
    {
        if (!IsSession)
        {
            SessionTimers sessionTimersNew = new SessionTimers();
            {
                sessionTimersNew.startTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                sessionTimersNew.endTime = DateTime.Now.AddSeconds(sessionTimer.elapsedTime).ToString("yyyy-MM-dd HH:mm:ss");
                sessionTimersNew.sessionId = PlayerPrefs.GetInt("SessionId");
                sessionTimersNew.productType = "work-at-height";

            }
            string jsonData = JsonConvert.SerializeObject(sessionTimersNew);
            StartCoroutine(apiManager.WebPostResponse("https://www.xrtraining.in/api/trainee/total-session-time", jsonData));
        }
    }
    public void UpdateTimer()
    {

        Timer postData = new Timer
        {
            startTime = "your_start_time_value",
            endTime = "your_end_time_value"
        };

        string mydate = JsonConvert.SerializeObject(postData);
       // StartCoroutine(WebPostResponse("http://ec2-3-110-42-131.ap-south-1.compute.amazonaws.com:8080/api/evaluation/add", mydate));
    }

    public void SessionTimeUpdate()
    {
        sessionTimer.GetTotalTime();
        UpdateSessionTimer();
    }

    void Update()
    {
        if (isTimerRunning)
        {
            elapsedTime += Time.deltaTime;
            UpdateTimerDisplay();
        }
    }

    void UpdateTimerDisplay()
    {
        int hours = Mathf.FloorToInt(elapsedTime / 3600);
        int minutes = Mathf.FloorToInt((elapsedTime % 3600) / 60);
        int seconds = Mathf.FloorToInt(elapsedTime % 60);

        //if(timerText != null) 
        //timerText.text = string.Format("{0:00}:{1:00}:{2:00}", hours, minutes, seconds);
    }

    public void StartTimer()
    {
        if (LearningScene)
        {
            sessionTimer.isSessionTimerRunning = true;
            if (LearningStartTime)
            {
                isTimerRunning = true;
                LearningStartTime = false;
            }
        }
        if (EvaluationScene)
        {
            if (LearningStartTime)
            {
                isTimerRunning = true;
                LearningStartTime = false;
            }
        }
    }

    public void LearningTimeStart()
    {
        LearningStartTime = true;
    }

    public void StopTimer()
    {
        isTimerRunning = false;
        //elapsedTime = 0f; 
    }

    public void SelectLanguage(string language)
    {

        PlayerPrefs.SetString("Language",language);
       
    }
    public void AutomaticLogin()
    {
        if (string.IsNullOrEmpty(nameOfUser))
        {
            GuestLogin();
        }
        else
        {
            GetLogin();
        }
    }

    public void GetLogin()
    {
       
        nameOfUser = PlayerPrefs.GetString("UserName");
        passwordOfUser = PlayerPrefs.GetString("Password");
        companyNameOfUser = PlayerPrefs.GetString("CompanyName");
        if (CompanyName != null)
        {
            CompanyName.text = companyNameOfUser;
        }

        UserInput userInput = new UserInput();
        userInput.username = nameOfUser;
        userInput.password = passwordOfUser;
        string mydata = JsonUtility.ToJson(userInput);
        StartCoroutine(apiManager.WebPostResponseLogin("https://www.xrtraining.in/api/auth/login", mydata));
    }

    private void GuestLogin()
    {
        UserInput userInput = new UserInput();
        userInput.username = "Guest";
        userInput.password = "Guest";

        PlayerPrefs.SetString("UserName", userInput.username);
        PlayerPrefs.SetString("Password", userInput.password);
        companyNameOfUser = PlayerPrefs.GetString("CompanyName");
        string mydata = JsonUtility.ToJson(userInput);
        StartCoroutine(apiManager.WebPostResponseLogin("https://www.xrtraining.in/api/auth/login",mydata));

    }

    public void NewLogin(bool Bool)
    {
        UserInput userInput = new UserInput();
        userInput.username = userName.text;
        userInput.password = Password.text;
        string mydata = JsonUtility.ToJson(userInput);
        StartCoroutine(apiManager.WebPostResponseLogin("https://www.xrtraining.in/api/auth/login", mydata));
        CompanyName.text = PlayerPrefs.GetString("CompanyName");
        isStart = Bool;
        //Debug.Log("NameUser" + userName.text);
        //Debug.Log("PassUser" + Password.text);
    }
    public void SceneLoading()
    {
        SceneManager.LoadScene("WorkAtHeight_POC_Julika_Evaluation");
    }

    public void IncorrectCredentials()
    {
       
        if (LoginPanelUI == true)
        {
            //incorrect credential function
            Incorrecttext();
            LoginSuccessText.SetActive(false);
            WrongCred = true;
            LoginPanelUI = false;
            Invoke("EmptyStringAdminField", 1);
        }
        else if (LoginPanelUI == false)
        {
            LockedDevice();
            //credential removed function
        }
    }

    public void LoginPanelUITrue()
    {
        LoginPanelUI = true;
    }
    public void AssignCorrectCredentialsAfterResponse()
    {
        if (apiManager.companyname != null)
        {
            companyNameOfUser = apiManager.companyname;
        }
          if(companyNameOfUser!=null)
        {
            CompanyName.text = companyNameOfUser;
        }
           
        if (isFirstTime)
        {          
            isFirstTime=false;
        }
        else
        {
            PlayerPrefs.SetString("UserName", userName.text);
            PlayerPrefs.SetString("Password", Password.text);
        }
        if (LoginSuccessText != null && !isStart)
        {
            LoginSuccessText.SetActive(true);
            anchorWithoutPassword.LoginSuccess(true);
            Invoke("EmptyStringAdminField", 1);
            //LoginPanel.SetActive(false);
        }
        if (PhoneNumberPanel != null )
        {
            //PhoneNumberPanel.SetActive(true);
            //PhoneNumberPanelparent.SetActive(true);
        }


        //if (AnchorBtnParent != null )
        //{
        //    AnchorBtnParent.SetActive(false);
        //}

        //if (companyNameOfUser != null)
     
        WrongCred = false;
    }

    public void LockedDevice()
    {
        DeviceLockedEvent.Invoke();
    }

    public void Incorrecttext()
    {
        IncorrectText.SetActive(true);
    }

    public void WrongCredBoolTrue()
    {
        WrongCred = true;
    }

    public void PreviousLogin()
    {
        if (WrongCred)
        {
            UserInput userInput = new UserInput();
        
            userInput.username = PlayerPrefs.GetString("UserName");
            userInput.password = PlayerPrefs.GetString("Password");
            if (userInput.username=="" && userInput.password=="")
            {
                userName.text = "Guest";
                Password.text = "Guest";
                PlayerPrefs.SetString("CompanyName", "Guest");
                userInput.username = "Guest";
                userInput.password = "Guest";
            }
            else
            {   
                userName.text = PlayerPrefs.GetString("UserName");
                Password.text = PlayerPrefs.GetString("Password");
                companyNameOfUser = apiManager.companyname;
                if (CompanyName.text == "" && userName.text == "Guest")
                {
                    CompanyName.text = "Guest";
                }
            }         
            string mydata = JsonUtility.ToJson(userInput);
            StartCoroutine(apiManager.WebPostResponseLogin("https://www.xrtraining.in/api/auth/login", mydata));
            WrongCred = false;

        }


    }
    public void isRestartBtnEnable()
    {
        isRestartBtn = true;
        isNextSceneBtn = false;
        isNextSceneOBBtn = false;
    }

    public void isNextSceneBtnEnable()
    {
        isRestartBtn = false;
        isNextSceneBtn = true;
        isNextSceneOBBtn = false;
    }
    public void isNextSceneOBBtnEnable()
    {
        isRestartBtn = false;
        isNextSceneBtn = false;
        isNextSceneOBBtn = true;
    }

    public void EmptyStringAdminField()
    {
        userName.text = null;
        Password.text = null;
    }

    public void MakeEmptyInputfield()
    {
        phoneNumnerInput.text = null;      
    }

}
