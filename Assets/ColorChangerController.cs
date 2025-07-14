using UnityEngine;

public class ColorChangerController : MonoBehaviour
{
    public Material targetMaterial;
    public float speed = 1.0f;      
    private Color colorA = Color.red;
    private Color colorB = Color.blue;
    private float t = 0f;
    private bool forward = true;

    void Update()
    {
        if (targetMaterial == null)
            return;

        t += (forward ? 1 : -1) * Time.deltaTime * speed;
        t = Mathf.Clamp01(t);

        targetMaterial.color = Color.Lerp(colorA, colorB, t);

        if (t >= 1f || t <= 0f)
        {
            forward = !forward;
        }
    }
}