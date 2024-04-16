using UnityEngine;

public class PauseButton : MonoBehaviour
{
    private AudioSource _audioSource;
    public GameObject goMainBtn;
    public GameObject pauseTxt;

    private GameManager _gameManager;
    private bool _isPause;

    private void Start()
    {
        _gameManager = FindObjectOfType<GameManager>();
        goMainBtn.SetActive(false);
        pauseTxt.SetActive(false);
        _isPause = false;
        if (_audioSource != null) return;
        _audioSource = AudioManager.Instance.audioSource;
        _audioSource.Play();
    }

    public void pauseButton()
    {
        if (!_isPause)
        {
            _audioSource.Pause();
            goMainBtn.SetActive(true);
            pauseTxt.SetActive(true);
            _gameManager.Pause();
            _isPause = true;
        }
        else
        {
            resumeButton();
            _isPause = false;
        }
    }

    private void resumeButton()
    {
        _gameManager.Pause();
        goMainBtn.SetActive(false);
        pauseTxt.SetActive(false);
        _audioSource.Play();
    }
}