using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationHandler : MonoBehaviour
{
  public Animator boardAnim;

    void Awake() 
    {
      boardAnim = GetComponent<Animator>();
    }

    public void timerStart()
    {
      GameManager.Instance.animEnd = false;
    }
    
}
