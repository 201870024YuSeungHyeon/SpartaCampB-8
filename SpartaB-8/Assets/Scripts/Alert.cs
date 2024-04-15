using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alert : MonoBehaviour
{
    private Animator anim;

    private void Awake()
    {
        if (!TryGetComponent<Animator>(out anim))
        {
            Debug.Log("Alert.cs - Awake() - anim 참조 실패");
        }
    }

    public void AlertTIme()
    {
        anim.SetTrigger("Alert");
    }
}
