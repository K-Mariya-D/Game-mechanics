using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;

public class ButtonAction : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        this.GetComponent<Button>().onClick.AddListener(()=> Debug.Log("Нажатие на кнопку обработано!"));
        Debug.Log(this.GetComponent<Button>().onClick.GetPersistentEventCount());
    }

}
