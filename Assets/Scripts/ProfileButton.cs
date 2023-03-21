using UnityEngine;
using UnityEngine.UI;

public class ProfileButton : MonoBehaviour
{
    private Button button1; // Stores a reference to the button component of the game object
    private Button button2;
    private Sprite[] avatars; // An array to hold the avatars
    private int currentIndex = 0; // An integer to keep track of the current avatar index
    public GameObject GroupProfileButton1;
    public GameObject GroupProfileButton2;

    private void Start()
    {
        // Find and store a reference to the button component of the game object
        button1 = GroupProfileButton1.GetComponent<Button>();
        button2 = GroupProfileButton2.GetComponent<Button>();

        // Load the avatars into the sprite array
        avatars = new Sprite[11];
        for (int i = 0; i < 11; i++)
        {
            avatars[i] = Resources.Load<Sprite>("AvatarJPG/pic" + (i + 1));
        }

        // Set the button image to the first avatar in the array
        button1.image.sprite = avatars[currentIndex];
        button2.image.sprite = avatars[currentIndex];
    }

    // This method is called when the button is clicked
    public void OnButtonClick()
    {
        // Update the current index to the next avatar in the array
        currentIndex = (currentIndex + 1) % 11;

        // Update the button image to the next avatar in the array
        button1.image.sprite = avatars[currentIndex];
        button2.image.sprite = avatars[currentIndex];
    }

    // This method is used to save the current avatar index
    public void SaveData()
    {
        // Get the current avatar index and save it to player preferences
        int avatarIndex = currentIndex;
        PlayerPrefs.SetInt("AvatarIndex", avatarIndex);
    }
}
