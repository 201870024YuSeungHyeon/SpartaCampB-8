using TMPro;
using UnityEngine;

public class TimeDecrease : MonoBehaviour
{
    private float _moveSpeed;
    private float _alphaSpeed;
    private TextMeshProUGUI _content;
    private Color _alpha;

    private void Awake()
    {
        _moveSpeed = 1.0f;
        _alphaSpeed = 1.0f;
        _content = GetComponent<TextMeshProUGUI>();
        _content.text = "-2";
        _alpha = _content.color;
    }
    
    private void Start()
    {
        InvokeDestroy();
    }

    private void Update()
    {
        if (GameManager.Instance.time <= 0.0f)
        {
            Destroy(gameObject);
        }
        transform.Translate(new Vector3(0, _moveSpeed * Time.deltaTime, 0));
        _alpha.a = Mathf.Lerp(_alpha.a, 0, Time.deltaTime * _alphaSpeed);
        _content.color = _alpha;
    }

    private void InvokeDestroy()
    {
        if (GameManager.Instance.time >= 2.4f)
        {
            Destroy(gameObject, 2.4f);
        }
        else
        {
            DestroyImmediate(gameObject, true);
        }
    }
}