using System.Collections;
using TMPro;
using UnityEngine;

public class TreeLifeCycle : MonoBehaviour
{
    [SerializeField] private Renderer targetRenderer;
    [SerializeField] private TMP_Text popupText;
    [SerializeField] private float stageDuration = 2f;

    private Color[] lifeColors = new Color[]
    {
    new Color(0.4f, 1f, 0.4f),    
    new Color(1f, 0.9f, 0.4f),   
    new Color(1f, 0.4f, 0f),       
    new Color(0.4f, 0.2f, 0f),     
    new Color(0.5f, 0.5f, 0.5f), 
    new Color(0.3f, 0.6f, 1f),     
    new Color(0.7f, 0.4f, 1f),     
    new Color(1f, 1f, 1f)        
    };

    private string[] lifeMessages = new string[]
    {
        "Let’s pray this works",
        "Now it should work...",
        "Okay, seems like it’s working.",
        "I still don’t fully get how this works, but I tried..."
    };

    private void Start()
    {
        if (targetRenderer == null)
            targetRenderer = GetComponent<Renderer>();

        StartCoroutine(CycleLifeColors());
    }

    private IEnumerator CycleLifeColors()
    {
        int index = 0;

        while (true)
        {
            Color startColor = targetRenderer.material.color;
            Color targetColor = lifeColors[index];

            StartCoroutine(ShowPopup(lifeMessages[index], stageDuration));

            float time = 0f;
            while (time < stageDuration)
            {
                targetRenderer.material.color = Color.Lerp(startColor, targetColor, time / stageDuration);
                time += Time.deltaTime;
                yield return null;
            }

            targetRenderer.material.color = targetColor;
            index = (index + 1) % lifeColors.Length;
        }
    }

    private IEnumerator ShowPopup(string message, float duration)
    {
        popupText.text = message;

        Color c = popupText.color;
        c.a = 1f;
        popupText.color = c;

        yield return new WaitForSeconds(duration * 0.6f); // òåêñò äåðæèòñÿ 60% âðåìåíè

        while (popupText.color.a > 0f)
        {
            c.a -= Time.deltaTime * 2f;
            popupText.color = c;
            yield return null;
        }

        popupText.text = "";
    }
}
