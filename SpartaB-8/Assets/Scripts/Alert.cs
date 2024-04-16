using UnityEngine;

public class Alert : MonoBehaviour
{
    private Animator anim;

    private void Awake()
    {
        if (!TryGetComponent(out anim))
        {
            Debug.Log("Alert.cs - Awake() - anim ���� ����");
        }
    }

    public void AlertTime()
    {
        anim.SetTrigger("Alert");
    }
}
