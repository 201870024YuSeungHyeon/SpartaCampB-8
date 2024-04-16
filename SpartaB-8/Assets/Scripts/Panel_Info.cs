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
        //int score = FindObjectOfType<���ھ�����>.//���ھ��������κ��� ���� �ҷ�����
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
