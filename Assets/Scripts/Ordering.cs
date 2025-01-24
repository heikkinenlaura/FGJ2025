using UnityEngine;
using UnityEngine.UI;

public class Ordering : MonoBehaviour
{
    public GameObject iconPrefab;       // Prefab for the icon (RawImage)
    public Transform iconPosition;      // The position where the icon will appear (above the customer's head)
    public string[] iconNames = { "X", "Y", "Z" };  // List of icon names that correspond to item types
    private RawImage iconRawImage;      // Reference to the RawImage component of the icon

    void Start()
    {
        // Select a random icon name from the list
        string randomIconName = iconNames[Random.Range(0, iconNames.Length)];

        // Load the icon texture from the Resources folder (make sure icons are in "Resources/Icons" folder)
        Texture2D iconTexture = Resources.Load<Texture2D>("Icons/" + randomIconName);

        if (iconTexture != null)
        {
            // Instantiate the icon prefab
            GameObject iconObject = Instantiate(iconPrefab, iconPosition.position, Quaternion.identity);
            iconObject.transform.SetParent(iconPosition);  // Set the icon's parent to the customer

            // Set the icon's texture (RawImage uses textures instead of sprites)
            iconRawImage = iconObject.GetComponent<RawImage>();
            iconRawImage.texture = iconTexture;

            // Optional: Adjust the icon's size and position
            iconRawImage.rectTransform.localPosition = new Vector3(0, 2f, 0); // Adjust the position above the customer
        }
        else
        {
            Debug.LogError("Icon texture not found in Resources/Icons folder!");
        }
    }

    // Optionally, you can update the icon or remove it after some time, depending on how you want the icon to behave.
}
