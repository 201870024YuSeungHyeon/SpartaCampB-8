using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum BGM_Type
{
    BGM_Normal = 0,
    BGM_NoTime,
}

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;
    public AudioSource audioSource;
    public AudioClip clip;

    [SerializeField]
    private List<AudioClip> bgmList;

    private float _current;
    private float _percent;
    private const float ChangeDuration = 1f;

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

    public void ChangeBGM(BGM_Type newBGM)
    {
        StartCoroutine(ChangeBGMClip(bgmList[(int)newBGM]));
    }

    private IEnumerator ChangeBGMClip(AudioClip newClip)
    {
        _current = 0f;
        _percent = 0f;

        while (_percent < 1)  // ������ BGM�� ������ �ٿ�������
        {
            _current += Time.deltaTime;
            _percent = _current /  ChangeDuration;
            audioSource.volume = Mathf.Lerp(1f, 0f, _percent);
            yield return null;
        }

        audioSource.clip = newClip;
        audioSource.Play();
        _current = 0f;
        _percent = 0f;

        while (_percent < 1)  // ���ο� BGM�� ������ Ű��������
        {
            _current += Time.deltaTime;
            _percent = _current / ChangeDuration;
            audioSource.volume = Mathf.Lerp(0f, 1f, _percent);
            yield return null;
        }
    }
}