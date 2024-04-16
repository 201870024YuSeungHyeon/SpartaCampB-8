using UnityEngine;
using UnityEngine.SceneManagement;

public class Card : MonoBehaviour
{
    public int idx;
    int stageNumber;

    public GameObject front;
    public GameObject back;

    public Animator anim;

    private AudioSource _audioSource;
    public AudioClip clip;

    public SpriteRenderer frontImage;
    private static readonly int IsOpen = Animator.StringToHash("isOpen");

    private void Awake()
    {
        if (SceneManager.GetActiveScene().name == "SeungHyeonScene") stageNumber = 0;
        else if (SceneManager.GetActiveScene().name == "ChihoonScene") stageNumber = 10;
        else if (SceneManager.GetActiveScene().name == "MoojinScene") stageNumber = 20;
        else if (SceneManager.GetActiveScene().name == "NakwonScene") stageNumber = 30;
        else if (SceneManager.GetActiveScene().name == "TaeilScene") stageNumber = 40;
    }

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    public void Setting(int number)
    {       
        idx = number;
        frontImage.sprite = Resources.Load<Sprite>($"rtan{idx + stageNumber}");
    }

    public void OpenCard()
    {
        ColorUtility.TryParseHtmlString("#C0C0C0", out var color);  // 16진수 색상코드(옅은 회색)를 Color로 변환
        back.GetComponent<SpriteRenderer>().color = color;  // 뒤집었던 카드 색상 변경
        if (GameManager.Instance.secondCard != null) return;

        _audioSource.PlayOneShot(clip);

        anim.SetBool(IsOpen, true);

        front.SetActive(true);
        back.SetActive(false);

        if (GameManager.Instance.firstCard == null)
        {
            GameManager.Instance.firstCard = this;
        }      
        else
        {
            GameManager.Instance.secondCard = this;            
            GameManager.Instance.Matched();
        }
        
    }

    public void DestroyCard()
    {          
        Invoke(nameof(DestroyCardInvoke), 1.0f);
    }

    private void DestroyCardInvoke()
    {
        Destroy(gameObject);
    }

    public void CloseCard()
    {
        Invoke(nameof(CloseCardInvoke), 1.0f);
    }

    public void CloseCardInvoke()
    {
        anim.SetBool(IsOpen, false);

        front.SetActive(false);
        back.SetActive(true);
    }
}
