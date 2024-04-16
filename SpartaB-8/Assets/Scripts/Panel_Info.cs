using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Panel_Info : MonoBehaviour
{
    public Text txt_HighScore;
    public GameObject Info_Panel;

    private void Awake()
    {

        Info_Panel.SetActive(false);
    }

    public void Show()
    {
        //int score = FindObjectOfType<스코어저장>.//스코어저장으로부터 점수 불러오기
        Info_Panel.SetActive(true);
        //txt_HighScore.text = "BEST\n" + score.Tostring();
    }

    public void OnClick_Play()
    {
        SceneManager.LoadScene("SeungHyeonScene");
    }

    public void OnClick_GoMain()
    {
        SceneManager.LoadScene("MainScene");
    }
}
