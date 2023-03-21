using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.UI;

public class RankManager : MonoBehaviour
{
    List<Transform> AllRankList = new List<Transform>();

    List<Transform> Rank1List = new List<Transform>();
    List<Transform> Rank2List = new List<Transform>();
    List<Transform> Rank3List = new List<Transform>();
    List<Transform> Rank4List = new List<Transform>();
    
    public GameObject Photo;
    public GameObject name;
    

    // Start is called before the first frame update
    void Start()
    {
        GetAllRankObj();
        ShowRank();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GetAllRankObj()
    {
        int count = 0;
        foreach (Transform allChild in this.transform)
        {
            AllRankList.Add(allChild);
            foreach (Transform child in allChild)
            {
                if (count == 0)
                {
                    Rank1List.Add(child);
                }
                else if (count == 1)
                {
                    Rank2List.Add(child);
                }
                else if (count == 2)
                {
                    Rank3List.Add(child);
                }
                else
                {
                    Rank4List.Add(child);
                }

            }
            count++;
        }
    }
    public void ShowRank(){

        string thesisNumber = Convert.ToString(MainSceneGameData.Instance.thesisNumber);
        AllRankList[0].gameObject.SetActive(true);
        Rank1List[2].gameObject.GetComponent<Text>().text = thesisNumber;
        
        Sprite[] avatars = new Sprite[12];
        for (int i = 0; i < 12; i++)
        {
            avatars[i] = Resources.Load<Sprite>("AvatarJPG/pic" + (i + 1));
        }

        // Get the saved avatar index and display the corresponding avatar
        int avatarIndex = PlayerPrefs.GetInt("AvatarIndex", 0);
        Photo.gameObject.GetComponent<Image>().sprite = avatars[avatarIndex];

        // Get the saved username and display it in the Text component
        string username = PlayerPrefs.GetString("Username", "");
        name.GetComponent<Text>().text = username;
    }
}
