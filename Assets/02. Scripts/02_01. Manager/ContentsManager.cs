using UnityEngine;
using UnityEngine.UI;

namespace Manager
{
    public class ContentsManager : Singleton<ContentsManager>
    {
        [SerializeField] public RectTransform ListContent { get; private set; }
        [SerializeField] public RectTransform listPrefab  { get; private set; }
        [SerializeField] public RectTransform TaskContent { get; private set; }
        [SerializeField] public RectTransform taskPrefab  { get; private set; }

        private void Awake()
        {
            SetContentSize(EContentType.List);
            SetContentSize(EContentType.Task);
        }

        public void ResizeListContent()
        {
            if (0 < ListContent.childCount)
            {
                SetContentSize(EContentType.List);
            }
            
        }

        public void ResizeTaskContent()
        {
            if (0 < TaskContent.childCount)
            {
                SetContentSize(EContentType.Task);
            }
        }

        private void SetContentSize(EContentType contentType)
        {
            switch (contentType)
            {
                case EContentType.List:
                    ListContent.sizeDelta = new Vector2(ListContent.sizeDelta.x, ListContent.childCount * (listPrefab.sizeDelta.y + ListContent.gameObject.GetComponent<VerticalLayoutGroup>().spacing));
                    break;
                case EContentType.Task:
                    TaskContent.sizeDelta = new Vector2(TaskContent.sizeDelta.x, TaskContent.childCount * (taskPrefab.sizeDelta.y + TaskContent.gameObject.GetComponent<VerticalLayoutGroup>().spacing));
                    break;
                default:
                    Debug.LogError("SetContentSize Error : " + contentType.ToString());
                    break;
            }
        }
    }
}
