using UnityEngine;
using TMPro;

public class CounterView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _text;
    [SerializeField] private Counter _counter;
    [SerializeField] private Animator _animator;
    [SerializeField] private AnimationClip _textResizeAnimation;

    private void Start()
    {
        _text.text = _counter.CountStartValue.ToString();
    }

    private void OnValueChanged(int value)
    {
        _text.text = value.ToString();
        _animator.Play(_textResizeAnimation.name);
    }

    private void OnEnable()
    {
        _counter.ValueChanged += OnValueChanged;
    }

    private void OnDisable()
    {
        _counter.ValueChanged -= OnValueChanged;
    }
}
