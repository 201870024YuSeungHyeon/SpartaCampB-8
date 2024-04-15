using System.Collections;
using System.Collections.Generic;
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
            Debug.Log("1");
            Instance = this;            
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

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
      
    }
}
