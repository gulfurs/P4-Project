using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class DanceManager : MonoBehaviour
{
    public Sprite danceSprite; // The sprite you want to search for
    public List<Image> danceSpritesList; // List to store references to sprites
    public GameObject robotIdle;
    public GameObject robotDance;
    public GameObject robotBreak;
    public GameObject nodes1;
    public GameObject nodes2;

    void Start()
    {
        // Initialize the list
        danceSpritesList = new List<Image>();

        // Call a method to find and add all sprites with the specified sprite initially
        FindAndAddDanceSprites();
    }

    void Update()
    {
        // Update the list of dance sprites continuously
        UpdateDanceSpritesList();
        if (danceSpritesList.Count == 1) {
            robotIdle.SetActive(false);
            robotDance.SetActive(true);
            robotBreak.SetActive(false);
            nodes1.SetActive(true);
            nodes2.SetActive(true);
        } else if (danceSpritesList.Count >= 2) {
            robotIdle.SetActive(false);
            robotDance.SetActive(false);
            robotBreak.SetActive(true);
            nodes1.SetActive(true);
            nodes2.SetActive(true);
        } else {
            robotIdle.SetActive(true);
            robotDance.SetActive(false);
            robotBreak.SetActive(false);
            nodes1.SetActive(false);
            nodes2.SetActive(false);
        }
    }

    void FindAndAddDanceSprites()
    {
        // Find all GameObjects with SpriteRenderer component
        Image[] allSprites = FindObjectsOfType<Image>(true);

        // Iterate through each SpriteRenderer
        foreach (Image spriteRenderer in allSprites)
        {
            // Check if the sprite of this SpriteRenderer matches the specified danceSprite
            if (spriteRenderer.sprite == danceSprite)
            {
                // Add this SpriteRenderer to the list
                danceSpritesList.Add(spriteRenderer);
            }
        }
    }

    void UpdateDanceSpritesList()
    {
        // Clear the existing list
        danceSpritesList.Clear();

        // Call the method to find and add all sprites with the specified sprite again
        FindAndAddDanceSprites();
    }
}
