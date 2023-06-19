using UnityEngine;
using UnityEngine.UI;

namespace Manager
{
    public class ContentsManager : Singleton<ContentsManager>
    {
        public RectTransform ListContent { get { return listContent; } private set { listContent = value; } }
        [SerializeField] private RectTransform listContent;

        public RectTransform ListPrefab { get { return listPrefab; } private set { listPrefab = value; } }
        [SerializeField] private RectTransform listPrefab;

        public RectTransform TaskContent { get { return taskContent; } private set { taskContent = value; } }
        [SerializeField] private RectTransform taskContent;

        public RectTransform TaskPrefab { get { return taskPrefab; } private set { taskPrefab = value; } }
        [SerializeField] private RectTransform taskPrefab;

        private void Awake()
        {
            SetContentSize(EContentType.List);
            SetContentSize(EContentType.Task);
        }

        public void CreateList()
        {
            Instantiate(listPrefab.gameObject, listContent);
            SetContentSize(EContentType.List);
        }

        public void CreateList(List_JSON saveData)
        {
            Instantiate(listPrefab.gameObject, listContent).GetComponentInChildren<ListDataContainer>().listData = saveData;
            SetContentSize(EContentType.List);
        }

        public void CreateTask()
        {
            Instantiate(taskPrefab.gameObject, taskContent);
            SetContentSize(EContentType.Task);
        }

        public void ClearChildren()
        {
            Transform[] children = TaskContent.GetComponentsInChildren<Transform>();
            if (children.Length == 1)
            {
                return;
            }

            for (int index = 1; index < children.Length; index++)
            {
                children[index].gameObject.SetActive(false);
            }
        }

        public void ActivateTaskOfList()
        {
            if (ToDoManager.Instance.TaskDict.Count == 0)
            {
                return;
            }

            foreach (var task in ToDoManager.Instance.TaskDict)
            {
                //task
            }
        }

        private void SetContentSize(EContentType contentType)
        {
            switch (contentType)
            {
                case EContentType.List:
                    listContent.sizeDelta = new Vector2(listContent.sizeDelta.x, listContent.childCount * (listPrefab.sizeDelta.y + listContent.gameObject.GetComponent<VerticalLayoutGroup>().spacing));
                    break;
                case EContentType.Task:
                    taskContent.sizeDelta = new Vector2(taskContent.sizeDelta.x, taskContent.childCount * (taskPrefab.sizeDelta.y + taskContent.gameObject.GetComponent<VerticalLayoutGroup>().spacing));
                    break;
                default:
                    Debug.LogError("SetContentSize Error : " + contentType.ToString());
                    break;
            }
        }
    }
}
