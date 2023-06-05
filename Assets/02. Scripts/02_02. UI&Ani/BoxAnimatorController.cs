using UnityEngine;

public class BoxAnimatorController : MonoBehaviour
{
    public Animator DisappearBox;

    public void SetIsRejectTrue()
    {
        DisappearBox.SetBool("isReject", true);
    }

    public void SetIsRejectFalse()
    {
        DisappearBox.SetBool("isReject", false);
    }
}
