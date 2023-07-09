using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using TMPro;

public class Shop : MonoBehaviour
{
    public Dictionary<string, int> bodyPartOptions = new Dictionary<string, int>();
    public GameObject player;
    public List<Sprite> faceOptions = new List<Sprite>();
    public List<Sprite> bodyOptions = new List<Sprite>();
    public List<Sprite> hoodOptions = new List<Sprite>();

    public SpriteRenderer faceRenderer;
    public SpriteRenderer bodyRenderer;
    public SpriteRenderer hoodRenderer;
    public TextMeshProUGUI messageText;

    public AudioClip sound;

    private AudioSource source;

  

    public GameObject PanelShop;

    public Player playersCoins;

    public TextMeshProUGUI costText;

    public Dictionary<string, List<int>> bodyPartPrices = new Dictionary<string, List<int>>()
    {
        {"Face", new List<int>{5, 10, 15, 20}},
        {"Body", new List<int>{10, 20, 30, 40}},
        {"Hood", new List<int>{8, 16, 24, 32}}
    };

    private int totalCost = 0;

    private bool bodyPartChanged = false;

    private void Start()
    {
        source = GetComponent<AudioSource>();
        playersCoins = GameObject.FindObjectOfType<Player>();

        // Initialize the bodyPartOptions dictionary
        bodyPartOptions["Face"] = 0;
        bodyPartOptions["Body"] = 0;
        bodyPartOptions["Hood"] = 0;

        // Set the initial sprite for each body part
        faceRenderer.sprite = faceOptions[0];
        bodyRenderer.sprite = bodyOptions[0];
        hoodRenderer.sprite = hoodOptions[0];

        // Calculate the initial total cost
        PurchasePrice();
    }

    public void Update()
    { 
        if (bodyPartChanged)
        {
            PurchasePrice();
            bodyPartChanged = false;
        }
    }

    private void PurchasePrice()
    {
        totalCost = 0;
        foreach (KeyValuePair<string, int> kvp in bodyPartOptions)
        {
            if (kvp.Value >= 1)
            {
                totalCost += bodyPartPrices[kvp.Key][kvp.Value - 1];
            }
        }
        costText.text = "Coins: " + totalCost.ToString();
    }

    public void DefaultOption()
    {
        source.PlayOneShot(sound);
        bodyPartOptions["Face"] = 0;
        bodyPartOptions["Body"] = 0;
        bodyPartOptions["Hood"] = 0;

        faceRenderer.sprite = faceOptions[0];
        bodyRenderer.sprite = bodyOptions[0];
        hoodRenderer.sprite = hoodOptions[0];

        bodyPartChanged = true;
    }

    public void NextFaceOption()
    {
        source.PlayOneShot(sound);
        bodyPartOptions["Face"]++;
        if (bodyPartOptions["Face"] >= faceOptions.Count)
            bodyPartOptions["Face"] = 0;
        faceRenderer.sprite = faceOptions[bodyPartOptions["Face"]];
        bodyPartChanged = true;
    }

    public void PreviousFaceOption()
    {
        source.PlayOneShot(sound);
        bodyPartOptions["Face"]--;
        if (bodyPartOptions["Face"] < 0)
            bodyPartOptions["Face"] = faceOptions.Count - 1;
        faceRenderer.sprite = faceOptions[bodyPartOptions["Face"]];
        bodyPartChanged = true;
    }

    public void NextBodyOption()
    {
        source.PlayOneShot(sound);
        bodyPartOptions["Body"]++;
        if (bodyPartOptions["Body"] >= bodyOptions.Count)
            bodyPartOptions["Body"] = 0;
        bodyRenderer.sprite = bodyOptions[bodyPartOptions["Body"]];
        bodyPartChanged = true;
    }

    public void PreviousBodyOption()
    {
        source.PlayOneShot(sound);
        bodyPartOptions["Body"]--;
        if (bodyPartOptions["Body"] < 0)
            bodyPartOptions["Body"] = bodyOptions.Count - 1;
        bodyRenderer.sprite = bodyOptions[bodyPartOptions["Body"]];
        bodyPartChanged = true;
    }

    public void NextHoodOption()
    {
        source.PlayOneShot(sound);
        bodyPartOptions["Hood"]++;
        if (bodyPartOptions["Hood"] >= hoodOptions.Count)
            bodyPartOptions["Hood"] = 0;
        hoodRenderer.sprite = hoodOptions[bodyPartOptions["Hood"]];
        bodyPartChanged = true;
    }

    public void PreviousHoodOption()
    {
        source.PlayOneShot(sound);
        bodyPartOptions["Hood"]--;
        if (bodyPartOptions["Hood"] < 0)
            bodyPartOptions["Hood"] = hoodOptions.Count - 1;
        hoodRenderer.sprite = hoodOptions[bodyPartOptions["Hood"]];
        bodyPartChanged = true;
    }

    public void Save()
    {
        source.PlayOneShot(sound);
        int currentCoins = playersCoins.CoinsNumber;

        Debug.Log(currentCoins + "CrrentCoints");
        if (currentCoins >= totalCost) { 
        // PrefabUtility.SaveAsPrefabAsset(player, "Assets/Prefab/Rogue_06 Variant.prefab");
        PanelShop.SetActive(false);
        playersCoins.CoinsNumber -= totalCost;
        }
		else
		{
            messageText.text = "Not enough coins!";
            StartCoroutine(ClearMessage(2.0f));
        }
    }

    private IEnumerator ClearMessage(float delay)
    {
        yield return new WaitForSeconds(delay); // wait for the specified delay
        messageText.text = ""; // clear the message
    }
}
