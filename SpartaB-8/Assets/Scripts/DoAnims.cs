using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoAnims : MonoBehaviour
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

    public void Fail()
    {
        anim.SetTrigger("Fail");
    }
}
