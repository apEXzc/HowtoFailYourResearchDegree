using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardBgClick : MonoBehaviour
{
    public RoundButton roundButton;

    // Start is called before the first frame update
    void Start()
    {
        roundButton = GameObject.Find("ButtonManager").GetComponent<RoundButton>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnclickCard()
    {
        gameObject.transform.Find("BlockBg").gameObject.SetActive(true);
        gameObject.GetComponent<Button>().enabled = false;
    }

    public void OnclickEventCard()
    {
        gameObject.GetComponent<Button>().enabled = false;
        roundButton.EventContextCardObjects[2].GetComponent<Button>().onClick.Invoke();
    }

    public void OnclickEventImpCard()
    {
        gameObject.GetComponent<Button>().enabled = false;
        roundButton.EventImpCardObjects[2].GetComponent<Button>().onClick.Invoke();
    }

    public void OnclickEventWriteUpCard()
    {
        gameObject.GetComponent<Button>().enabled = false;
        roundButton.EventWriteUpObjects[2].GetComponent<Button>().onClick.Invoke();
    }
}
