using UnityEngine;
using UnityEngine.UI;
using Manager;

public class BackButtonHandler : MonoBehaviour
{
    // ��ư ����
    public Button backButton;

    public void Start()
    {
        // ��ư�� OnClick �̺�Ʈ ���
        backButton.onClick.AddListener(OnClickGoToSignInScene);
    }

    // ��ư Ŭ�� �̺�Ʈ ó��
    public void OnClickGoToSignInScene()
    {
        // �� �Ŵ������� LoadSceneC() �Լ� ȣ��
        ScenesManager.Instance.LoadScene(0);
    }
}