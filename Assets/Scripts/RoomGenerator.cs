using UnityEngine;
using UnityEngine.UI;

public class RoomGenerator : MonoBehaviour
{
    public Text roomNameText; // A reference to the Text component that will display the room name

    private const string Characters = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ"; // A string containing all the possible characters for the room name

    public Image image; // A reference to the Image component that will display the user's avatar
    public Text usernameText; // A reference to the Text component that will display the user's username
    private Sprite[] avatars; // An array to hold the avatars
    private int Index = 0; // An integer to keep track of the current index

    // A property that gets and sets the room name using player preferences
    public static string RoomName
    {
        get => PlayerPrefs.GetString("RoomName", string.Empty);
        set => PlayerPrefs.SetString("RoomName", value);
    }

    private void Awake()
    {
        // Find and store a reference to the Text component that will display the room name
        roomNameText = GameObject.Find("RoomNumber").GetComponent<Text>();

        // Find and store a reference to the Text component that will display the user's username
        usernameText = GameObject.Find("Group" + Index).GetComponent<Text>();

        // Find and store a reference to the Image component that will display the user's avatar
        image = GameObject.Find("picGroup" + Index).GetComponent<Image>();

        // Increment the index
        Index++;

        // Generate a random room name if none is saved in player preferences
        if (string.IsNullOrEmpty(RoomName))
        {
            RoomName = GenerateRandomRoomName();
        }

        // Display the room name in the Text component
        roomNameText.text = RoomName;

        // Load the avatars into the sprite array
        avatars = new Sprite[12];
        for (int i = 0; i < 12; i++)
        {
            avatars[i] = Resources.Load<Sprite>("AvatarJPG/pic" + (i + 1));
        }

        // Get the saved avatar index and display the corresponding avatar
        int avatarIndex = PlayerPrefs.GetInt("AvatarIndex", 0);
        image.sprite = avatars[avatarIndex];

        // Get the saved username and display it in the Text component
        string username = PlayerPrefs.GetString("Username", "");
        usernameText.text = username;
    }

    // Method to generate a new random room name
    public void GenerateNewRoomName()
    {
        RoomName = GenerateRandomRoomName();
        roomNameText.text = RoomName;
    }

    // Method to generate a random room name using the Characters string
    private string GenerateRandomRoomName()
    {
        int length = 6; // The length of the room name
        string randomString = "";
        for (int i = 0; i < length; i++)
        {
            int index = UnityEngine.Random.Range(0, Characters.Length);
            randomString += Characters[index];
        }
        return randomString;
    }
}
