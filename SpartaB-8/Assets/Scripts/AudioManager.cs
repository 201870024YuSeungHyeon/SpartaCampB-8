using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;


    public AudioSource audioSource;

   

    public AudioClip clip;

    private void Awake()
    {
        if (Instance == null)
        {
            if (Instance == null)
            {
                Instance = this;
                DontDestroyOnLoad(gameObject);
            }
            else
            {
                Destroy(gameObject);
            }

        }
        else 
        {
           
            Destroy(gameObject);
            
        }
    
    }

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = this.clip;
        audioSource.Play();

    }

    // Update is called once per frame
    void Update()
    {
      

    }
}
