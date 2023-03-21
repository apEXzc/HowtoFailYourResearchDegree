using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class acceleratedMove : MonoBehaviour
{
    public bool isClick = false;

    public RectTransform r;
    public Vector2 target;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (isClick)
        {
            r.anchoredPosition = Vector2.Lerp(r.anchoredPosition,
                target, Time.deltaTime * 10);
            if (Vector2.Distance(r.anchoredPosition, target) < 1)
            {
                r.anchoredPosition = target;
                isClick = false;
            }
        }
    }

    public void Click(GameObject g, Vector2 target1)
    {
        r = g.GetComponent<RectTransform>();
        target = target1;
        isClick = true;
    }
    
}
