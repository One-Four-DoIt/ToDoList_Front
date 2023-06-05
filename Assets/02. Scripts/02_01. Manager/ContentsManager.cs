using UnityEngine;
using UnityEngine.UI;

namespace Manager
{
    public class ContentsManager : Singleton<ContentsManager>
    {
        public RectTransform ListContent { get { return listPrefab; } private set { listPrefab = value; } }
        [SerializeField] private RectTransform listContent;
        public RectTransform ListPrefab { get { return listPrefab; } private set { listPrefab = value; } }
        [SerializeField] private RectTransform listPrefab;

        public RectTransform TaskContent { get { return listContent; } private set { listContent = value; } }
        [SerializeField] private RectTransform taskContent;
        public RectTransform TaskPrefab { get { return taskPrefab; } private set { taskPrefab = value; } }
        [SerializeField] private RectTransform taskPrefab;

        private void Awake()
        {
            SetContentSize(EContentType.List);
            SetContentSize(EContentType.Task);
        }

        public void ResizelistContent()
        {
            if (0 < listContent.childCount)
            {
                SetContentSize(EContentType.List);
            }
            
        }

        public void ResizeTaskContent()
        {
            if (0 < taskContent.childCount)
            {
                SetContentSize(EContentType.Task);
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
