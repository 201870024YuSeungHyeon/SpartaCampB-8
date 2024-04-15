using UnityEngine;

public class AudioManager : MonoBehaviour
{
    private static AudioManager _instance;

<<<<<<< HEAD
    private AudioSource _audioSource;
=======
    public AudioSource audioSource;
>>>>>>> 8938b5a7de8c26d1f9beda4dc96b0e11818aff9c
    public AudioClip clip;

    private void Awake()
    {
        if (_instance == null)
        {
<<<<<<< HEAD
            _instance = this;            
=======
            Debug.Log("1");
            Instance = this;            
>>>>>>> 8938b5a7de8c26d1f9beda4dc96b0e11818aff9c
            DontDestroyOnLoad(gameObject);
            audioSource = GetComponent<AudioSource>();

            audioSource.clip = this.clip;
            audioSource.Play();

        }
        else 
        {
            Debug.Log("2");
            Destroy(gameObject);
            
        }
    
    }

    private void Start()
    {
<<<<<<< HEAD
        _audioSource = GetComponent<AudioSource>();

        _audioSource.clip = this.clip;
        _audioSource.Play();
=======
       
    }

    // Update is called once per frame
    void Update()
    {
      
>>>>>>> 8938b5a7de8c26d1f9beda4dc96b0e11818aff9c
    }
}
