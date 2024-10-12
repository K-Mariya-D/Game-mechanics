using System.Collections;
using System.Collections.Generic;
using UnityEditor.U2D.Animation;
using UnityEngine;
using UnityEngine.VFX;

public class Player : MonoBehaviour
{
    [SerializeField] private GameObject camera;
    private float timer;

    // Start is called before the first frame update
    void Start()
    {
        timer = 2.5f;
        camera.GetComponent<CameraEffects>().FadeScreen(0.5f);
        camera.GetComponent<CameraEffects>().ShakeCamera(0.7f, 0.6f);
    }
    private void Update()
    {
        if (timer <= 0)
            camera.GetComponent<CameraEffects>().FadeScreen(1f);
        else timer -= Time.deltaTime;
    }
}
