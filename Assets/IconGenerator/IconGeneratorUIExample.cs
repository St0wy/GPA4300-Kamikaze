using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// This script is only a visual demostration of the asset!
// If you want to, you can use this with your own scripts.

public class IconGeneratorUIExample : MonoBehaviour
{
	private Sprite iconSprite; // Used in example for viewing image on screen.
	public GameObject itemPrefab; // Used in example for viewing image on screen.

	private void Start()
	{
		// Enable Text component.
		transform.GetChild(1).gameObject.SetActive(true);
	}

	// Add image to the 
	public void AddImage(Texture2D icon, string itemName)
	{
		iconSprite = Sprite.Create(icon, new Rect(0, 0, icon.width, icon.height), new Vector2(0.5f, 0.5f));

		GameObject item = Instantiate(itemPrefab, this.gameObject.transform.GetChild(0), true);
		item.GetComponent<Image>().sprite = iconSprite;
		item.GetComponentInChildren<Text>().text = itemName + ".png";
	}
}