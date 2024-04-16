using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Panel_Info : MonoBehaviour
{
    public Text txt_HighScore;
    public GameObject Info_Panel;
    int score;

    private void Awake()
    {
        Info_Panel.SetActive(false);
    }

    public void Show(string name)
    {
        Debug.Log("여기까지");
        if (!PlayerPrefs.HasKey(name))
        {
            score = PlayerPrefs.GetInt(name);
            txt_HighScore.text = "BEST\n" + score.ToString();
        }
        else
        {
            score = PlayerPrefs.GetInt(name);
            txt_HighScore.text = "BEST\n" + score.ToString();
        }
        Info_Panel.SetActive(true);
      
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
