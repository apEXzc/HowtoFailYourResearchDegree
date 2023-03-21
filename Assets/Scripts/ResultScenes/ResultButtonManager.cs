using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ResultButtonManager : MonoBehaviour
{
    public GameObject imageReview;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClickReviewButton()
    {
        // Sprite result = Resources.Load<Sprite>("Screenshot_result");
        // imageReview.gameObject.GetComponent<Image>().sprite = result;
        imageReview.gameObject.SetActive(true);
        // get image from system desktop
        string filePath = Path.Combine(Application.dataPath,"Screenshot_result.png");
        byte[] imageData = File.ReadAllBytes(filePath);
        Texture2D texture = new Texture2D(2, 2); // create a new texture
        texture.LoadImage(imageData); // load the image data into the texture
        Sprite sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), new Vector2(0.5f, 0.5f));
        imageReview.gameObject.GetComponent<Image>().sprite = sprite;
    }

    public void OnClickNewGameButton()
    {
        SceneManager.LoadScene("MainScenes");
        DeleteScreenshot();
    }

    public void OnClickQuitButton()
    {
        SceneManager.LoadScene("StartScenes");
        DeleteScreenshot();
    }
    
    public void DeleteScreenshot()
    {
        string filePath = Path.Combine(Application.dataPath, "Assets/Resources", "Screenshot_result.png");
        if (File.Exists(filePath))
        {
            File.Delete(filePath);
        }
    }

}
