using UnityEngine;

public class AnimationHandler : MonoBehaviour
{
    public Animator boardAnim;

    private void Awake()
    {
        boardAnim = GetComponent<Animator>();
    }

    public void timerStart()
    {
        GameManager.Instance.animEnd = false;
    }
}