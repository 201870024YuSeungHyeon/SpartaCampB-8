using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
   
    public Card firstCard;
    public Card secondCard;
    public Text timeTxt;
    public GameObject endTxt;   
    public int cardCount = 0;

    float time = 30.00f;

    AudioSource audioSource;
    public AudioClip clip;

    private Alert alert;
    private GameObject obj;

    bool isPause;

    private void Awake()
    {
        if (Instance == null) 
        {
            Instance = this;
        }

        if (obj = GameObject.Find("TimeTxt"))
        {
            if (!obj.TryGetComponent<Alert>(out alert))
            {
                Debug.Log("GameManager.cs - Awake() - alert 참조 실패");
            }
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1.0f;
        audioSource = GetComponent<AudioSource>();
        isPause = false;
    }

    // Update is called once per frame
    void Update()
    {        
        time -= Time.deltaTime;
        timeTxt.text = time.ToString("N2");

        if(time > 0.0f && time <= 5.0f)
        {
            alert.AlertTIme();
        }
        else if(time <= 0.0f)
        {
            GameOver();
        }
    }

    public void Matched()
    {        
        
        if (firstCard.idx == secondCard.idx)
        {
            Debug.Log("같음");
            audioSource.PlayOneShot(clip);

            firstCard.DestroyCard();
            secondCard.DestroyCard();

            cardCount -= 2;
            if (cardCount == 0)
            {                
                GameOver();
            }
        }        
        else
        {
            firstCard.CloseCard();
            secondCard.CloseCard();
        }
       
        firstCard = null;
        secondCard = null;
    }

    void GameOver() 
    {        
        Time.timeScale = 0.0f;
        endTxt.SetActive(true);
    }

   public void Pause()
    {
        if(isPause == false)
        {
            Time.timeScale = 0.0f;
            isPause = true;
            return;
        }
        if(isPause == true)
        {
            Time.timeScale = 1.0f;
            isPause = false;
            return;
        }
    }

}
