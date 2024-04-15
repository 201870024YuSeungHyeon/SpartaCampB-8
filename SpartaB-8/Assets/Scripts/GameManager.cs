using System.Collections;
using System.Collections.Generic;
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

    float time = 0.00f;

    AudioSource audioSource;
    public AudioClip clip;

    private void Awake()
    {
        if (Instance == null) 
        {
            Instance = this;
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1.0f;
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {        
        time += Time.deltaTime;
        timeTxt.text = time.ToString("N2");
        
        if (time >= 30f)
        {            
            timeTxt.text = "30.00";
            GameOver();
        }
    }

    public void Matched()
    {        
        
        if (firstCard.idx == secondCard.idx)
        {
            Debug.Log("°°À½");
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
}
