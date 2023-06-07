using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ButtonEdit : MonoBehaviour
{
    [SerializeField] private GameObject edit;
    [SerializeField] private GameObject calendar;
    [SerializeField] private GameObject delete;

    private InputField[] inputFields;

    private readonly int PLACEHOLDER = 0;
    private readonly int NAME        = 1;

    private void Awake()
    {
        inputFields = transform.parent.GetComponentsInChildren<InputField>();
    }

    private void Start()
    {
        propertyActivate(false);
    }

    public void OnClickEdit()
    {
        propertyActivate(true);
        EventSystem.current.SetSelectedGameObject(inputFields[0].gameObject);
        inputFields[0].OnPointerClick(new PointerEventData(EventSystem.current));
    }

    public void OnEndEdit()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            propertyActivate(false);
            edit.SetActive(false);
            calendar.SetActive(false);
            delete.SetActive(false);
        }
    }

    private void propertyActivate(bool boolean)
    {
        foreach (var item in inputFields)
        {
            item.interactable = boolean;
            item.shouldActivateOnSelect = boolean;

            var inputFieldChildren = item.transform.GetComponentsInChildren<Text>();
            inputFieldChildren[PLACEHOLDER].raycastTarget = boolean;
            inputFieldChildren[NAME].raycastTarget = boolean;
        }
    }
}
