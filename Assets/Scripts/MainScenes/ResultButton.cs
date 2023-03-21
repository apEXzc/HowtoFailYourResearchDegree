using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;

public class ResultButton : MonoBehaviour
{
    public ActiveCardManager activeCardManager;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClick()
    {
        //Calculate the number of thesis;
        int countThesis = 0;
        List<int> thesisLength = new List<int>();
        foreach (GameObject writeUpCardObj in activeCardManager.currentWriteUpCards)
        {
            
            if (writeUpCardObj != null)
            {
                WriteUpCard writeUpCard = writeUpCardObj.gameObject.GetComponent<ShowCard>().card as WriteUpCard;
                if (writeUpCard.Thesis)
                {
                    countThesis++;
                }
                else if (!writeUpCard.Thesis)
                {
                    thesisLength.Add(countThesis);
                    countThesis = 0;
                }
            }
            else
            {
                thesisLength.Add(countThesis);
                countThesis = 0;
            }

        }
        thesisLength.Sort();

        MainSceneGameData.Instance.thesisNumber = thesisLength[thesisLength.Count - 1];// pass the thesis data to the next scene
        CaptureScreenshot();
        SceneManager.LoadScene("ResultScenes");
    }
    
    
    public int superSize = 1;

    public void CaptureScreenshot()
    {
        string filename = "Screenshot_result.png";
        string filePath = Path.Combine(Application.dataPath, filename);
        ScreenCapture.CaptureScreenshot(filePath, superSize);
    }
}
