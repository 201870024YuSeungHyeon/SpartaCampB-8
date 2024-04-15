using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEditor.Experimental.GraphView;

public class PauseButton : MonoBehaviour
{
    public AudioSource audioSource;
    public GameObject goMainBtn;
    public GameObject pauseTxt;

    GameManager gameManager;
    bool isPause;

    // Start is called before the first frame update
    void Start()
    {

        gameManager = FindObjectOfType<GameManager>();
        goMainBtn.SetActive(false);
        pauseTxt.SetActive(false);
        isPause = false;
        if (audioSource == null)
        {
            audioSource = AudioManager.Instance.audioSource;
            audioSource.Play();
        }

    }

    public void pauseButton()
    {

       
        if (!isPause)
        {
            audioSource.Pause();
            goMainBtn.SetActive(true);
            pauseTxt.SetActive(true);
            gameManager.Pause();
            isPause = true;
        }
        else
        {
            resumeButton();
            isPause = false;
        }
    }

    public void resumeButton()
    {
        Debug.Log("µø¿€«‘");
        gameManager.Pause();
        goMainBtn.SetActive(false);
        pauseTxt.SetActive(false);
        audioSource.Play();
    }
}
