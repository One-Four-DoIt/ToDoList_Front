using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;

namespace Manager
{
    public class DataManager : Singleton<DataManager>
    {
        readonly string PATH_LIST_OBJECT = "Assets/Data/ListObject";
        readonly string PATH_TASK_OBJECT = "Assets/Data/TaskObject";

        private void Awake()
        {
            LoadData();
        }

        public void CreateCopyData(List_JSON listData, string saveFileName)
        {
            List_JSON listObject = ScriptableObject.CreateInstance<List_JSON>();

            #region Copy Values
            listObject.SetListObjectID(listData.ListObjectID);
            listObject.SetListObjectName(listData.ListObjectName);
            listObject.IsActive = listData.IsActive;
            listObject.SetTaskDict(listData.TaskDict);
            #endregion

            AssetDatabase.CreateAsset(listObject, $"{PATH_LIST_OBJECT}/{saveFileName}.asset");
            SaveData();
        }

        public void SaveData()
        {
            AssetDatabase.SaveAssets();
        }

        public void LoadData()
        {
            string[] guids = AssetDatabase.FindAssets("t:ScriptableObject", new[] { PATH_LIST_OBJECT });

            foreach (string guid in guids)
            {
                string path = AssetDatabase.GUIDToAssetPath(guid);
                List_JSON listData = AssetDatabase.LoadAssetAtPath<List_JSON>(path);

                ContentsManager.Instance.CreateList(listData);
            }
        }
    }
}
