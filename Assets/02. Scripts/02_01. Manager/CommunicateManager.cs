using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

namespace Manager
{
    public enum EDomainType
    {
        User,
        Task,
    }


    public class CommunicateManager : Singleton<CommunicateManager>
    {
        static readonly private string CREATE = UnityWebRequest.kHttpVerbCREATE;
        static readonly private string DELETE = UnityWebRequest.kHttpVerbDELETE;
        static readonly private string GET    = UnityWebRequest.kHttpVerbGET;
        static readonly private string HEAD   = UnityWebRequest.kHttpVerbHEAD;
        static readonly private string POST   = UnityWebRequest.kHttpVerbPOST;
        static readonly private string PUT    = UnityWebRequest.kHttpVerbPUT;

        static readonly private string IP_ADDRESS_USER = "http://3.39.180.61/user/";
        static readonly private string IP_ADDRESS_TASK = "http://3.39.180.61/tasl/";
        static readonly private string IP_ADDRESS_TODO = "http://3.39.180.61/todo/";

        static private UnityWebRequest www;

        #region Common Method

        private string EmailToQueryParameter(string email)
        {
            string queryParam = $"?email={UnityWebRequest.EscapeURL(email)}";
            return queryParam;
        }

        #endregion

        #region Template
        private void SendRequestToServer_<T>(string methodType, string baseURL, RQ_Base requestBody) where T : RP_Base
        {
            StartCoroutine(SendRequestCoroutine_<T>(methodType, baseURL, requestBody));
        }

        private IEnumerator SendRequestCoroutine_<T>(string methodType, string baseURL, RQ_Base requestBody) where T : RP_Base
        {
            string requestURL = baseURL;
            string jsonText = JsonConvert.SerializeObject(requestBody);

            using (UnityWebRequest www = UnityWebRequest.PostWwwForm(requestURL, methodType))
            {
                www.SetRequestHeader("Content-Type", "application/json");
                www.uploadHandler = new UploadHandlerRaw(System.Text.Encoding.UTF8.GetBytes(jsonText));

                yield return www.SendWebRequest();

                if (www.result == UnityWebRequest.Result.Success)
                {
                    Debug.Log(www.result.ToString());

                    var responseBodyJSON = www.downloadHandler.text;
                    var responseBody = JsonConvert.DeserializeObject<T>(responseBodyJSON);
                }
                else
                {
                    Debug.Log($"{www.result}\n{www.error}");
                }

                www.Dispose();
            }
        }
        #endregion


        #region



        #endregion

        #region USER API

        #region Email
        string email_SendEmailCode = string.Empty;

        public void SendEmailCode()
        {
            RQ_Base email = new RQ_SendEmailCode(email_SendEmailCode);
            SendRequestToServer_SendEmailCode<RP_SendEmailCode>(POST, IP_ADDRESS_USER + "email/", email);
        }

        public void SetEmail_SendEmailCode(InputField inputField) => email_SendEmailCode = inputField.text;

        private void SendRequestToServer_SendEmailCode<T>(string methodType, string baseURL, RQ_Base requestBody) where T : RP_Base
        {
            StartCoroutine(SendRequestCoroutine_SendEmailCode<T>(methodType, baseURL, requestBody));
        }

        private IEnumerator SendRequestCoroutine_SendEmailCode<T>(string methodType, string baseURL, RQ_Base requestBody) where T : RP_Base
        {
            string requestURL = baseURL;
            string jsonText = JsonConvert.SerializeObject(requestBody);

            using (www = UnityWebRequest.PostWwwForm(requestURL, methodType.ToString()))
            {
                www.SetRequestHeader("Content-Type", "application/json");
                www.uploadHandler = new UploadHandlerRaw(System.Text.Encoding.UTF8.GetBytes(jsonText));

                yield return www.SendWebRequest();

                if (www.result == UnityWebRequest.Result.Success)
                {
                    Debug.Log(www.result.ToString());

                    var responseBodyJSON = www.downloadHandler.text;
                    var responseBody = JsonConvert.DeserializeObject<T>(responseBodyJSON);

                }
                else
                {
                    Debug.Log($"{www.result}\n{www.error}");
                }

                www.Dispose();
            }
        }
        #endregion

        /*--------------------*/

        #region Check Email Duplicated
        string email_CheckEmailDuplicated;

        public void CheckEmailDuplicated()
        {
            SendRequestToServer_CheckEmailDuplicated<RP_CheckEmailDuplicated>(GET, $"{IP_ADDRESS_USER}email/duplicate");
        }

        public void SetEmail_CheckEmailDuplicated(InputField inputField) => email_CheckEmailDuplicated = inputField.text;


        private void SendRequestToServer_CheckEmailDuplicated<T>(string methodType, string baseURL) where T : RP_Base
        {
            StartCoroutine(SendRequestCoroutine_CheckEmailDuplicated<T>(methodType, baseURL));
        }

        private IEnumerator SendRequestCoroutine_CheckEmailDuplicated<T>(string methodType, string baseURL) where T : RP_Base
        {
            string requestURL = $"{baseURL}{EmailToQueryParameter(email_CheckEmailDuplicated)}";

            using (UnityWebRequest www = UnityWebRequest.Get(requestURL))
            {
                yield return www.SendWebRequest();

                if (www.result == UnityWebRequest.Result.Success)
                {
                    Debug.Log(www.result.ToString());

                    var responseBodyJSON = www.downloadHandler.text;
                    var responseBody = JsonConvert.DeserializeObject<T>(responseBodyJSON) as RP_CheckEmailDuplicated;

                    if (responseBody.Data == false)
                    {
                        SendEmailCode();
                    }
                    else
                    {
                        Debug.Log("Email Duplicated");
                    }
                }
                else
                {
                    Debug.Log($"{www.result}\n{www.error}");
                }

                www.Dispose();
            }
        }

        #endregion

        /*--------------------*/

        #region Sign In
        private string email_SignIn = string.Empty;
        private string password_SignIn = string.Empty;
        
        public void SignIn()
        {
            RQ_Base signInfo = new RQ_SignIn(email_SignIn, password_SignIn);
            SendRequestToServer_SingIn<RP_SignIn>(DELETE, IP_ADDRESS_USER + "login", signInfo);
        }

        public void SetEmail_SignIn(InputField email) => email_SignIn = email.text;

        public void SetPassword_SignIn(InputField password) => password_SignIn = password.text;

        private void SetToken_SignIn(RP_SignIn responseBody)
        {
            PlayerPrefs.SetString("AccessToken", responseBody.Data.AccessToken);
            PlayerPrefs.SetString("RefreshToken", responseBody.Data.RefreshToken);
            PlayerPrefs.Save();
        }
        
        private void SendRequestToServer_SingIn<T>(string methodType, string baseURL, RQ_Base requestBody) where T : RP_Base
        {
            StartCoroutine(SendRequestCoroutine_SignIn<T>(methodType, baseURL, requestBody));
        }

        private IEnumerator SendRequestCoroutine_SignIn<T>(string methodType, string baseURL, RQ_Base requestBody) where T : RP_Base
        {
            string requestURL = baseURL;
            string jsonText = JsonConvert.SerializeObject(requestBody);

            using (www = UnityWebRequest.PostWwwForm(requestURL, methodType.ToString()))
            {
                www.SetRequestHeader("Content-Type", "application/json");
                www.uploadHandler = new UploadHandlerRaw(System.Text.Encoding.UTF8.GetBytes(jsonText));

                yield return www.SendWebRequest();

                if (www.result == UnityWebRequest.Result.Success)
                {
                    Debug.Log(www.result.ToString());

                    var responseBodyJSON = www.downloadHandler.text;
                    var responseBody = JsonConvert.DeserializeObject<T>(responseBodyJSON);

                    SetToken_SignIn(responseBody as RP_SignIn);
                }
                else
                {
                    Debug.Log($"{www.result}\n{www.error}");
                }

                www.Dispose();
            }
        }
        #endregion

        /*--------------------*/

        #endregion


    }
}
