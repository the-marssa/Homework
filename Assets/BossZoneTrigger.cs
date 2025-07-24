using UnityEngine;
using TMPro;
using System.Collections;

public class BossZoneTrigger : MonoBehaviour
{
    [Header("UI")]
    public GameObject messagePanel;
    public TextMeshProUGUI messageText;

    [Header("Message Settings")]
    public string message = "You’ve entered the floor boss zone. Golem senses your presence...";
    public float displayDuration = 3f;

    private Coroutine hideCoroutine;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            ShowMessage();

            if (hideCoroutine != null)
                StopCoroutine(hideCoroutine);

            hideCoroutine = StartCoroutine(HideMessageAfterSeconds(displayDuration));
        }
    }

    private void ShowMessage()
    {
        if (messagePanel != null && messageText != null)
        {
            messagePanel.SetActive(true);
            messageText.text = message;
        }
    }

    private IEnumerator HideMessageAfterSeconds(float seconds)
    {
        yield return new WaitForSeconds(seconds);

        if (messagePanel != null)
        {
            messagePanel.SetActive(false);
        }
    }
}
