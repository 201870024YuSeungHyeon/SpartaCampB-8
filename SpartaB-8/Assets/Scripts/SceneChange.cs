using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
    public string sceneName;

    public void StartBtn()
    {
        SceneManager.LoadScene("MainScene");
    }

    public void SeungHyeonBtn()
    {
        SceneManager.LoadScene("SeungHyeonScene");
    }

    public void ChihoonBtn()
    {
        SceneManager.LoadScene("ChihoonScene");
    }

    public void MoojinBtn()
    {
        SceneManager.LoadScene("MoojinScene");
    }

    public void NakwonBtn()
    {
        SceneManager.LoadScene("NakwonScene");
    }

    public void TaeilScene()
    {
        SceneManager.LoadScene("TaeilScene");
    }
}
