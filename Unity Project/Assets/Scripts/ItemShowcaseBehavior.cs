using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemShowcaseBehavior : MonoBehaviour
{

    public Sprite[] upgradeSprites;

    public int itemType;

    public int itemAmount;

    public SpriteRenderer itemSprite;

    public Text amountText;

    // Start is called before the first frame update
    void Start()
    {
        reload();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void setType(int set) {
        itemType = set;
        reload();
    }

    public void setAmount(int set) {
        itemAmount = set;
        reload();
    }

    private void reload() {
        itemSprite.sprite = upgradeSprites[itemType];
        amountText.text = ("x" + itemAmount);
    }
}
