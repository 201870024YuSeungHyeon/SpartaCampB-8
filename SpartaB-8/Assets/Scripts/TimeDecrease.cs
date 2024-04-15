using TMPro;
using UnityEngine;

public class TimeDecrease : MonoBehaviour
{
    private float _moveSpeed;
    private float _alphaSpeed;
    private TextMeshPro _content;
    private Color _alpha;

    private void Start()
    {
        _moveSpeed = 1.0f;
        _alphaSpeed = 1.0f;
        _content = GetComponent<TextMeshPro>();
        _content.text = "-2";
        _alpha = _content.color;
        Invoke(nameof(DestroyObject), 3.0f);
    }

    private void Update()
    {
        transform.Translate(new Vector3(0, _moveSpeed * Time.deltaTime, 0));
        _alpha.a = Mathf.Lerp(_alpha.a, 0, Time.deltaTime * _alphaSpeed);
        _content.color = _alpha;
    }

    private void DestroyObject()
    {
        Destroy(gameObject);
    }
}