using UnityEngine;

public class Fail : MonoBehaviour
{
    private Animator _anim;

    private void Awake()
    {
        if (!TryGetComponent(out _anim))
        {
            Debug.Log("Alert.cs - Awake() - anim 참조 실패");
        }
    }

    public void MatchFail()
    {
        _anim.SetTrigger(nameof(Fail));
    }
}
