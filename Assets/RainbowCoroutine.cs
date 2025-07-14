using System.Collections;
using TMPro;
using UnityEngine;

public class TestComponent : MonoBehaviour
{
    [SerializeField] private float _timer;
    [SerializeField] private TMP_Text _text;

    [Header("Coroutine")]
    [SerializeField] private Renderer _renderer;
    [SerializeField] private float _coroutineDuration = 3f;

    private float _currentTime = 0f;
    private int _counter = 0;

    private void Start()
    {
        StartCoroutine(RainbowCoroutine(_renderer, _coroutineDuration));
        Application.targetFrameRate = 60;
    }

    private void Update()
    {
        _currentTime += Time.deltaTime;

        if (_currentTime >= _timer)
        {
            TestFunction();
        }
    }

    private void TestFunction()
    {
        Debug.Log("hello");
        _currentTime = 0f;

        _counter++;
        _text.text = "I'm executed " + _counter.ToString() + " times";
    }

    private IEnumerator RainbowCoroutine(Renderer renderer, float duration)
    {
        yield return new WaitForSeconds(1f); // можно убрать

        while (true)
        {
            float currentTime = 0f;

            while (currentTime < duration)
            {
                float hue = Mathf.Repeat(currentTime / duration, 1f); // 0 → 1
                Color rainbowColor = Color.HSVToRGB(hue, 1f, 1f);
                renderer.material.color = rainbowColor;

                currentTime += Time.deltaTime;
                yield return null;
            }
        }
    }
}
