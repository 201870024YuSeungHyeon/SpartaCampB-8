using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum BGM_Type
{
    BGM_Normal = 0,
    BGN_NoTime,

}
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

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = clip;
        audioSource.Play();
    }

    public void StartBGM(BGM_Type newBGM)
    {
        clip = bgmList[(int)newBGM];
        audioSource.clip = clip;
        audioSource.Play();
    }

    [SerializeField]
    private List<AudioClip> bgmList;

    public void ChangeBGM(BGM_Type newBGM)
    {
        StartCoroutine(ChangeBGMClip(bgmList[(int)newBGM]));
    }

    float current;
    float percent;
    public readonly float changeDuration = 1f;

    IEnumerator ChangeBGMClip(AudioClip newClip)
    {
        current = 0f;
        percent = 0f;

        while (percent < 1)  // 기존의 BGM의 볼륨을 줄여나간다
        {
            current += Time.deltaTime;
            percent = current /  changeDuration;
            audioSource.volume = Mathf.Lerp(1f, 0f, percent);
            yield return null;
        }

        audioSource.clip = newClip;
        audioSource.Play();
        current = 0f;
        percent = 0f;

        while (percent < 1)  // 새로운 BGM의 볼륨을 키워나간다
        {
            current += Time.deltaTime;
            percent = current / changeDuration;
            audioSource.volume = Mathf.Lerp(0f, 1f, percent);
            yield return null;
        }
    }
}