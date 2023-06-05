using UnityEngine;
using UnityEngine.UI;
using Manager;

public class BackButtonHandler : MonoBehaviour
{
    // 버튼 참조
    public Button backButton;

    public void Start()
    {
        // 버튼에 OnClick 이벤트 등록
        backButton.onClick.AddListener(OnClickGoToSignInScene);
    }

    // 버튼 클릭 이벤트 처리
    public void OnClickGoToSignInScene()
    {
        // 씬 매니저에서 LoadSceneC() 함수 호출
        ScenesManager.Instance.LoadScene(0);
    }
}