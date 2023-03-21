/*using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;

public class RankManagerTests
{
    [UnityTest]
    public IEnumerator ShowRank_ShowsCorrectThesisNumber()
    {
        // Arrange
        var rankManagerObject = new GameObject();
        var rankManager = rankManagerObject.AddComponent<RankManager>();
        var allRankList = new List<Transform>();
        var rank1List = new List<Transform>();
        var rank2List = new List<Transform>();
        var rank3List = new List<Transform>();
        var rank4List = new List<Transform>();
        var allRankObject = new GameObject("AllRank");
        allRankObject.transform.parent = rankManagerObject.transform;
        allRankList.Add(allRankObject.transform);
        var rank1Object = new GameObject("Rank1");
        rank1Object.transform.parent = allRankObject.transform;
        rank1List.Add(rank1Object.transform);
        var rank2Object = new GameObject("Rank2");
        rank2Object.transform.parent = allRankObject.transform;
        rank2List.Add(rank2Object.transform);
        var rank3Object = new GameObject("Rank3");
        rank3Object.transform.parent = allRankObject.transform;
        rank3List.Add(rank3Object.transform);
        var rank4Object = new GameObject("Rank4");
        rank4Object.transform.parent = allRankObject.transform;
        rank4List.Add(rank4Object.transform);
        rankManager.AllRankList = allRankList;
        rankManager.Rank1List = rank1List;
        rankManager.Rank2List = rank2List;
        rankManager.Rank3List = rank3List;
        rankManager.Rank4List = rank4List;
        var thesisNumber = 42;
        MainSceneGameData.Instance.thesisNumber = thesisNumber;

        var photoObject = new GameObject("Photo");
        photoObject.transform.parent = rankManagerObject.transform;
        var photoImage = photoObject.AddComponent<Image>();
        rankManager.Photo = photoObject;

        var nameObject = new GameObject("Name");
        nameObject.transform.parent = rankManagerObject.transform;
        var nameText = nameObject.AddComponent<Text>();
        rankManager.name = nameObject;

        yield return null; // Wait for Start() to finish

        // Act
        rankManager.ShowRank();

        // Assert
        Assert.AreEqual(thesisNumber.ToString(), rankManager.Rank1List[2].gameObject.GetComponent<Text>().text);
    }
}
*/