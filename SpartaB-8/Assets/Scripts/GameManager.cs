using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public Card firstCard;
    public Card secondCard;
    public Text timeTxt;
    public Text matchTxt;
    public GameObject result;
    public int cardCount;
    private int _matchCount;

    public float time;

    private AudioSource _audioSource;
    public AudioClip clip;

    private Alert _alert;
    private GameObject _obj;

    private bool _isPause;

    public GameObject hudTimeDecreaseTxt;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }

        if (!(_obj = GameObject.Find("TimeTxt"))) return;
        if (!_obj.TryGetComponent(out _alert))
        {
            Debug.Log("GameManager.cs - Awake() - alert ÂüÁ¶ ½ÇÆÐ");
        }
        
        time = 60.0f;
    }


    private void Start()
    {
        Time.timeScale = 1.0f;
        _matchCount = 0;
        _audioSource = GetComponent<AudioSource>();
        _isPause = false;
    }

    private void Update()
    {
        time -= Time.deltaTime;
        timeTxt.text = time.ToString("N2");

        switch (time)
        {
            case > 0.0f and <= 5.0f:
                _alert.AlertTime();
                break;
            case <= 0.0f:
                GameOver();
                break;
        }
    }

    public void Matched()
    {
        if (firstCard.idx == secondCard.idx)
        {
            _audioSource.PlayOneShot(clip);

            firstCard.DestroyCard();
            secondCard.DestroyCard();

            cardCount -= 2;
            if (cardCount == 0)
            {
                GameOver();
            }
        }
        // 카드 매칭 실패 시
        else
        {
            Instantiate(hudTimeDecreaseTxt,
                GameObject.FindGameObjectWithTag("Canvas").transform); // 시간 감소 효과 텍스트 생성(미완성)
            // 제한시간 2초 감소
            if (time >= 2.0f)
            {
                time -= 2.0f;
            }
            else
            {
                time = 0.0f;
            }

            firstCard.CloseCard();
            secondCard.CloseCard();
        }

        _matchCount++;

        firstCard = null;
        secondCard = null;
    }

    private void GameOver()
    {
        Time.timeScale = 0.0f;
        matchTxt.text = "매칭시도: " + _matchCount;
        result.SetActive(true);
        AudioManager.Instance.audioSource.Stop();
    }


    public void Pause()
    {
        if (!_isPause)
        {
            Time.timeScale = 0.0f;
            _isPause = true;
        }
        else
        {
            Time.timeScale = 1.0f;
            _isPause = false;
        }
    }
}