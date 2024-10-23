using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

/// <summary>
/// Ёффект размыти€ и небольшой тр€ски камеры. —крипт навешиваетс€ на Main camera 
/// </summary>
public class BlurEffect : MonoBehaviour
{
    private Transform _trans;

    // Start is called before the first frame update
    void Start()
    {
        _trans = GetComponent<Transform>();
        var prefab = Resources.Load<BlurEffect>("PostProsess");
        Instantiate(prefab);
    }

    public void Blure(float time, float speed, float amplitude)
    {
        StartCoroutine(_Blure(time, speed, amplitude));
    }

    // Update is called once per frame
    private IEnumerator _Blure(float time, float speed, float amplitude)
    {
        Vector3 startPose = _trans.position;
        float start = time;

        float y = startPose.y;

        while (time > 0)
        {
            yield return null;

            if (time >= start/2) y += 0.1f;
            else y -= 0.1f;
            float x = UnityEngine.Random.Range(-amplitude, amplitude);

            Vector3 distance = new Vector3(x, startPose.y + y, startPose.z);

            Vector3 newPos = Vector3.Lerp(_trans.position, distance, speed * Time.deltaTime);

            _trans.position = newPos;

            time -= Time.deltaTime;
        }
    }
}
