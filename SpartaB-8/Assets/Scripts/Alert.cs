using UnityEngine;

public class Alert : MonoBehaviour
{
    private Animator _anim;

    private void Awake()
    {
        if (!TryGetComponent(out _anim))
        {
            Debug.Log("Alert.cs - Awake() - anim ���� ����");
        }
    }

    public void AlertTime()
    {
        _anim.SetTrigger(nameof(Alert));
    }
}
