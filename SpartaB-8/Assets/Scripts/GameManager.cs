using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public Card firstCard;
    public Card secondCard;

    public Text timeTxt;
    public Text matchTxt;
    public Text correctTxt;

    public GameObject result;
    public GameObject popUpBg;
    
    public int cardCount;
    private int _matchCount;

    public int best;

    public string key = DataManager.Instance.key;
    public Text nowScore;
    public float getScore;
    public Text bestScore;

    private const int MaxScore = 100; // 획득 가능한 최대 점수
    private const int MaxTimes = 8; // 짝을 맞출 수 있는 최대 횟수

    public float time;

    private AudioSource _audioSource;
    public AudioClip clip;
    public AudioClip unMatch;

    private Alert _alert;
    private Fail _fail;
    private GameObject _obj;

    private bool _isPause;
    public bool animEnd = true;

    public GameObject hudTimeDecreaseTxt;

    public Text matchTimeTxt;
    private float _matchTime = 5.00f;

    public bool isGameOver;
    private bool _bgmChanged;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }

        if ((_obj = GameObject.Find("TimeTxt")) == true)
        {
            if (!_obj.TryGetComponent(out _alert))
            {
                Debug.Log("GameManager.cs - Awake() - alert 참조 실패");
            }
        }

        if ((_obj = GameObject.Find("FailImage")) == true)
        {
            if (!_obj.TryGetComponent(out _fail))
            {
                Debug.Log("GameManager.cs - Awake() - fail 참조 실패");
            }
        }

        time = 60.0f;
        popUpBg.SetActive(false);
    }


    private void Start()
    {
        Time.timeScale = 1.0f;

        StartCoroutine(nameof(TimeCheck));

        _matchCount = 0;
        _audioSource = GetComponent<AudioSource>();
        _isPause = false;
        _bgmChanged = false;
        AudioManager.Instance.StartBGM(BGM_Type.BGM_Normal);

        if (!PlayerPrefs.HasKey(key))
        {
            PlayerPrefs.SetInt(key, 0);
        }
    }

    private void Update()
    {
        if (animEnd == false)
        {
            time -= Time.deltaTime;
            timeTxt.text = time.ToString("N2");

            if (time <= 0.0f) timeTxt.text = "0.00";
        }

        MatchTime();
    }

    private IEnumerator TimeCheck()
    {
        var stopFlag = false;
        while (true)
        {
            switch (time)
            {
                case > 10.0f and <= 12.0f:
                    if (!_bgmChanged)
                    {
                        AudioManager.Instance.ChangeBGM(BGM_Type.BGM_NoTime);
                        _bgmChanged = true;
                    }

                    break;
                case > 0.0f and <= 10.0f:
                    _alert.AlertTime();
                    break;
                case <= 0.0f:
                    GameOver();
                    stopFlag = true;
                    break;
            }

            if (stopFlag) break;
            yield return new WaitForSeconds(0.1f);
        }
    }

    public void Matched()
    {
        if (firstCard.idx == secondCard.idx)
        {
            _audioSource.PlayOneShot(clip);
            CorrectCard(firstCard.idx);

            firstCard.DestroyCard();
            secondCard.DestroyCard();
            GetScore();
            cardCount -= 2;
            if (cardCount == 0)
            {
                GameOver();
            }
        }
        else
        {
            _audioSource.PlayOneShot(unMatch);

            Instantiate(hudTimeDecreaseTxt,
                GameObject.FindGameObjectWithTag("Canvas").transform); // 시간 감소 효과 텍스트 생성

            if (time >= 2.0f)
            {
                time -= 2.0f;
            }
            else
            {
                time = 0.0f;
            }

            _fail.MatchFail();
            firstCard.CloseCard();
            secondCard.CloseCard();
        }

        _matchCount++;
    }

    private void GameOver()
    {
        getScore -= _matchCount / MaxTimes * 2.5f; // 매칭 횟수가 짝을 맞출 수 있는 최대 횟수 초과할 때마다 2.5점 감소
        if (getScore < 0.0f)
        {
            getScore = 0.0f;
        }
        var score = (int)getScore;
        Debug.Log(score);
        Time.timeScale = 0.0f;
        matchTxt.text = "매칭시도: " + _matchCount;
        nowScore.text = "Score : " + score;
        key = DataManager.Instance.key;

        if (PlayerPrefs.HasKey(DataManager.Instance.key))
        {
            best = PlayerPrefs.GetInt(key);
            if (best < getScore)
            {
                PlayerPrefs.SetInt(key, score);
                Debug.Log($"1 이름 : {key} , 점수 : {score}");
                bestScore.text = "BEST : " + score;
            }
            else
            {
                Debug.Log($"2 이름 : {key} , 점수 : {score}");
                bestScore.text = "BEST : " + score;
            }
        }
        else
        {
            Debug.Log($"3 이름 : {key} , 점수 : {score}");
            PlayerPrefs.SetInt(key, score);
            bestScore.text = "BEST : " + score;
        }

        PlayerPrefs.Save();
        MatchTimeOver();
        _fail.gameObject.SetActive(false);
        isGameOver = true;
        result.SetActive(true);
        popUpBg.SetActive(true);
        AudioManager.Instance.audioSource.Stop();
    }

    public void Pause()
    {
        if (!_isPause)
        {
            Time.timeScale = 0.0f;
            popUpBg.SetActive(true);
            _isPause = true;
        }
        else
        {
            Time.timeScale = 1.0f;
            popUpBg.SetActive(false);
            _isPause = false;
        }
    }

    private void GetScore()
    {
        const float score = MaxScore / (float)MaxTimes;
        switch (time)
        {
            case >= 30.0f: // 60-30초
                getScore += score;
                break;
            case > 0.0f: // 30-0초
                getScore += score - 5.0f;
                break;
        }

        Debug.Log(getScore);
    }

    private void MatchTime()
    {
        if (!firstCard) return;
        matchTimeTxt.gameObject.SetActive(true);

        _matchTime -= Time.deltaTime;
        matchTimeTxt.text = _matchTime.ToString("N2");

        if (!(_matchTime <= 0.00f)) return;
        MatchTimeOver();

        firstCard.CloseCardInvoke();
        firstCard = null;
    }

    public void MatchTimeOver()
    {
        matchTimeTxt.gameObject.SetActive(false);
        _matchTime = 5.00f;

        if (Time.timeScale == 0) firstCard = null;
    }

    private void CorrectCard(int idx)
    {
        switch (idx)
        {
            case 0:
                correctTxt.gameObject.SetActive(true);
                correctTxt.text = "취미!";
                Invoke(nameof(DeleteText), 1);
                break;
            case 1:
                correctTxt.gameObject.SetActive(true);
                correctTxt.text = "좋아하는 음식!";
                Invoke(nameof(DeleteText), 1);
                break;
            case 2:
                correctTxt.gameObject.SetActive(true);
                correctTxt.text = "MBTI!";
                Invoke(nameof(DeleteText), 1);
                break;
            case 3:
                correctTxt.gameObject.SetActive(true);
                correctTxt.text = "좋아하는 가수!";
                Invoke(nameof(DeleteText), 1);
                break;
            case 4:
                correctTxt.gameObject.SetActive(true);
                correctTxt.text = "좋아하는 게임!";
                Invoke(nameof(DeleteText), 1);
                break;
            case 5:
                correctTxt.gameObject.SetActive(true);
                correctTxt.text = "인상깊게 봤던 영화!";
                Invoke(nameof(DeleteText), 1);
                break;
            case 6:
                correctTxt.gameObject.SetActive(true);
                correctTxt.text = "본인 사진!";
                Invoke(nameof(DeleteText), 1);
                break;
            case 7:
                correctTxt.gameObject.SetActive(true);
                correctTxt.text = "우리의 꿈!";
                Invoke(nameof(DeleteText), 1);
                break;
        }
    }

    private void DeleteText()
    {
        correctTxt.gameObject.SetActive(false);
    }
}