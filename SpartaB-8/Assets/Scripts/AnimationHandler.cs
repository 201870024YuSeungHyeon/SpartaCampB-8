using UnityEngine;

public class AnimationHandler : MonoBehaviour
{
    public void TimerStart()
    {
        GameManager.Instance.animEnd = false;
    }
}