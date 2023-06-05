using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ButtonEdit : MonoBehaviour
{
    [SerializeField] private GameObject edit;
    [SerializeField] private GameObject delete;

    private InputField inputField;
    private Text[] inputFieldChildren;

    private readonly int PLACEHOLDER = 0;
    private readonly int NAME        = 1;

    private void Awake()
    {
        inputField = transform.parent.GetComponentInChildren<InputField>();
        inputFieldChildren = inputField.transform.GetComponentsInChildren<Text>();
    }

    private void Start()
    {
        propertyActivate(false);
    }

    public void OnClickEdit()
    {
        propertyActivate(true);
        EventSystem.current.SetSelectedGameObject(inputField.gameObject);
        inputField.OnPointerClick(new PointerEventData(EventSystem.current));
    }

    public void OnEndEdit()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            propertyActivate(false);
            edit.SetActive(false);
            delete.SetActive(false);
        }
    }

    private void propertyActivate(bool boolean)
    {
        inputField.interactable = boolean;
        inputField.shouldActivateOnSelect = boolean;
        inputFieldChildren[PLACEHOLDER].raycastTarget = boolean;
        inputFieldChildren[NAME].raycastTarget = boolean;
    }
}
