using UnityEngine;
using TMPro;
using System.Collections;

public class GolemCollision : MonoBehaviour
{
    [SerializeField] private GameObject messagePanel;
    [SerializeField] private TextMeshProUGUI messageText;

    [SerializeField] private string damageMessage = "Damage dealt to Golem: -1% HP";
    [SerializeField] private float displayTime = 2f;

    private Coroutine hideCoroutine;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (messagePanel != null && messageText != null)
            {
                messagePanel.SetActive(true);
                messageText.text = damageMessage;

                if (hideCoroutine != null)
                    StopCoroutine(hideCoroutine);

                hideCoroutine = StartCoroutine(HideMessageAfterSeconds(displayTime));
            }
        }
    }

    private IEnumerator HideMessageAfterSeconds(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        if (messagePanel != null)
            messagePanel.SetActive(false);
    }
}
