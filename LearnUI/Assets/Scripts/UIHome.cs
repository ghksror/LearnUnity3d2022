using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIHome : MonoBehaviour
{
    [Range(0, 1.0f)]
    public float hpFillAmount;
    [Range(0, 1.0f)]
    public float expFillAmount;

    public Slider hpSlider;
    public Slider expSlider;

    public Button btnSquare;
    public Button btnFacebook;
    public Button btnItems;
    public Button btnShop;
    public Button btnMessages;
    public Button btnMission;
    public Button btnRanking;
    public Button btnSettings;
    public Button btnHeart;
    public Button btnGold;
    public Button btnDiamond;
    public Button btnFriends;

    //public Button[] arrMenuBtns;

    void Start()
    {
        this.btnFacebook.onClick.AddListener(() =>
        {
            Debug.Log("Facebook");
        });
        this.btnItems.onClick.AddListener(() =>
        {
            Debug.Log("Items");
        });
        this.btnShop.onClick.AddListener(() =>
        {
            Debug.Log("Shop");
        });
        this.btnMessages.onClick.AddListener(() =>
        {
            Debug.Log("Message");
        });
        this.btnMission.onClick.AddListener(() =>
        {
            Debug.Log("Mission");
        });
        this.btnRanking.onClick.AddListener(() =>
        {
            Debug.Log("Ranking");
        });
        this.btnSettings.onClick.AddListener(() =>
        {
            Debug.Log("Settings");
        });
        this.btnHeart.onClick.AddListener(() =>
        {
            Debug.Log("Heart");
        });
        this.btnGold.onClick.AddListener(() =>
        {
            Debug.Log("Gold");
        });
        this.btnDiamond.onClick.AddListener(() =>
        {
            Debug.Log("Diamond");
        });
        this.btnFriends.onClick.AddListener(() =>
        {
            Debug.Log("Friends");
        });
    }
    void Update()
    {
        this.hpSlider.value = this.hpFillAmount;
        this.expSlider.value = this.expFillAmount;
    }
}
