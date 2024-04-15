using UnityEngine;

public class Card : MonoBehaviour
{
    public int idx;

    public GameObject front;
    public GameObject back;

    public Animator anim;

    private AudioSource _audioSource;
    public AudioClip clip;

    public SpriteRenderer frontImage;
    private static readonly int IsOpen = Animator.StringToHash("isOpen");

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();

    }

    public void Setting(int number)
    {       
        idx = number;        
        frontImage.sprite = Resources.Load<Sprite>($"rtan{idx}");
    }

    public void OpenCard()
    {           
        if (GameManager.instance.secondCard != null) return;

        _audioSource.PlayOneShot(clip);

        anim.SetBool(IsOpen, true);

        front.SetActive(true);
        back.SetActive(false);

        if (GameManager.instance.firstCard == null)
        {
            GameManager.instance.firstCard = this;
        }      
        else
        {
            GameManager.instance.secondCard = this;            
            GameManager.instance.Matched();
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

    private void CloseCardInvoke()
    {
        anim.SetBool(IsOpen, false);

        front.SetActive(false);
        back.SetActive(true);
    }
}
