using Newtonsoft.Json;
using System;
using System.IO;
using UnityEngine;

namespace Manager
{
    public class TestManager : Singleton<TestManager>
    {
        private string localFilePath = "Assets/Test/Test.json";
        Test jsonDataObject;

        public void ReadLocalJSON()
        {

            string jsonData = File.ReadAllText(localFilePath);
            Debug.Log(jsonData);
            //jsonDataObject = JsonUtility.FromJson<Test>(jsonData);
            jsonDataObject = JsonConvert.DeserializeObject<Test>(jsonData);

            ShowProperties();
        }

        public void WriteLocalJSON()
        {
            //string jsonText = JsonUtility.ToJson(jsonDataObject, true);
            string jsonText = JsonConvert.SerializeObject(jsonDataObject, Formatting.Indented);
            Debug.Log(jsonText);
            File.WriteAllText(localFilePath, jsonText);

            ShowProperties();
            Debug.Log("���� JSON ������ ���������� �����߽��ϴ�.");
        }

        public void ProcessData()
        {
            // ���� ������ ó�� ������ ���⿡ �ۼ�
            jsonDataObject.SetProperty(true, 1, "success");
        }

        private void ShowProperties()
        {
            Debug.Log(jsonDataObject.IsChecked + "\n"
                + jsonDataObject.TestID + "\n"
                + jsonDataObject.TestName + "\n"
                + "-----------------------");
        }
    }
}

[Serializable]
public class Test
{
    [JsonProperty("isChecked")]
    public bool IsChecked { get; private set; }

    [JsonProperty("testID")]
    public int TestID { get; private set; }

    [JsonProperty("testName")]
    public string TestName { get; private set; }

    public void SetProperty(bool isChecked, int id, string name)
    {
        IsChecked = isChecked;
        TestID = id;
        TestName = name;
    }
}
