using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using Unity.VisualScripting;
using Unity.ProjectAuditor.Editor;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class Card : MonoBehaviour{
    public Card_data data;

    public string card_name;
    public string description;
    public int health;
    public int cost;
    public int damage;
    public Sprite sprite;
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI descriptionText;
    public TextMeshProUGUI healthText;
    public TextMeshProUGUI costText;
    public TextMeshProUGUI damageText;
    public Image spriteImage;
    public GameManager gameManager;
    public Transform parentTransform;
    public float touched = 0;
    
    
    private Canvas canvas;

    private Vector3 card;

    private Vector3 arrow;
    private Vector3 offset;
    private Camera mainCamera;
    private dragUI dragScript;

    // Start is called before the first frame update
    void Start()
    {
        card_name = data.card_name;
        description = data.description;
        health = data.health;
        cost = data.cost;
        damage = data.damage;
        sprite = data.sprite;
        nameText.text = card_name;
        descriptionText.text = description;
        healthText.text = health.ToString();
        costText.text = cost.ToString();
        damageText.text = damage.ToString();
        spriteImage.sprite = sprite;
        mainCamera = Camera.main;
        dragScript = Object.FindAnyObjectByType<dragUI>();
        if (dragScript == null)
        {
            Debug.Log("Unable to find dragging script");
        }
    }
    /*void Awake()
    {
    //rectTransform = GetComponentInParent<RectTransform>();
    canvas = GetComponentInParent<Canvas>();
    }*/
    


    // Update is called once per frame
    void Update()
        {
        float leftLimit = Screen.width * 0.1f;
        float rightLimit = Screen.width * 0.9f;
        float bottomLimit = Screen.height * 0.5f;
        float topLimit = Screen.height;
        Vector3 screenPos = Camera.main.WorldToScreenPoint(transform.position);
        if(screenPos.x > leftLimit && screenPos.x < rightLimit && screenPos.y > bottomLimit && screenPos.y < topLimit
        && !Input.GetMouseButton(0))
            {
                print("In bound and mouse released, card is ready to move back");
            }
        }

    }











        //float x = transform.localPosition.x;
        //float y = transform.localPosition.y;
        //if(y > 300 && x > 500 && x < 3600 && y < 1800)
        //{
          //  print("card in boundary");
        //}
    







 