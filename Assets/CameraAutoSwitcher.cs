using UnityEngine;
using Unity.Cinemachine;

public class CameraAutoSwitcher : MonoBehaviour
{
    public CinemachineCamera[] cameras;
    public float switchInterval = 4f;

    private int currentIndex = 0;
    private float timer = 0f;

    void Start()
    {
        SwitchToCamera(0);
    }

    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= switchInterval)
        {
            timer = 0f;
            currentIndex = (currentIndex + 1) % cameras.Length;
            SwitchToCamera(currentIndex);
        }
    }

    void SwitchToCamera(int index)
    {
        for (int i = 0; i < cameras.Length; i++)
        {
            cameras[i].Priority = (i == index) ? 10 : 0;
        }
    }
}
