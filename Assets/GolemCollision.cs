using UnityEngine;
using TMPro;

public class GolemCollision : MonoBehaviour
{
    public GameObject messagePanel;
    public TextMeshProUGUI messageText;

    public string damageMessage = "Damage dealt to Golem: -1% HP";
    public float displayTime = 2f;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("💥 Collision with player!");

            if (messagePanel != null && messageText != null)
            {
                messagePanel.SetActive(true);
                messageText.text = damageMessage;
                Invoke(nameof(HideMessage), displayTime);
            }
        }
    }

    private void HideMessage()
    {
        if (messagePanel != null)
            messagePanel.SetActive(false);
    }
}
