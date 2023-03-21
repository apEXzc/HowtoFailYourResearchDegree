using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToggleGroup : MonoBehaviour
{
    public Toggle[] toggles;
    // Start is called before the first frame update
    void Awake()
    {
        toggles = transform.GetComponentsInChildren<Toggle>();
        for (int i = 0; i < toggles.Length; i++)
        {
            Toggle toggle = toggles[i];
            toggle.onValueChanged.AddListener((bool value) => OnToggleClick(toggle, value));
        }
    }
    void Start()
    {
    }

    public void OnToggleClick(Toggle toggle, bool isSwitch)
    {
        Debug.Log("toogle group name:"+ toggle.name + isSwitch);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
