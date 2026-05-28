using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using Unity.VisualScripting;
using Unity.ProjectAuditor.Editor;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using NUnit.Framework;
using Unity.Mathematics;
using UnityEngine.UIElements;

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
    public UnityEngine.UI.Image spriteImage;
    public GameManager gameManager;
    public Transform parentTransform;
    public float touched = 0;

    public float origin_x = 0;
    public float origin_y = 0;
    
    private int toggle = 0;
    
    private Canvas canvas;

    private Vector3 card;

    private Vector3 arrow;
    private Vector3 offset;
    private Camera mainCamera;
    private dragUI dragScript;

    private bool mouseDown;
    [SerializeField] private GameObject Orc;
    [SerializeField] private GameObject Fairy;
    [SerializeField] private GameObject Spirit;
    [SerializeField] private GameObject Wizard;

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
        //spriteImage.sprite = sprite;
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
        

        // Returns true every frame the button is held down

        if (Input.GetMouseButtonDown(0))
        {
            origin_x = transform.position.x;
            origin_y = transform.position.y;
            toggle = 0;
        }


        if (Input.GetMouseButtonUp(0))
        {
            if (toggle == 0)
            {
                transform.position = new Vector3(origin_x, origin_y ,0);
                Instantiate(Orc, new Vector3(transform.position.x,transform.position.y,0), Quaternion.identity);
                toggle = 1;
            }
                
        }


        if (Input.GetMouseButton(0)) 
        {
            mouseDown = true;
        } else
        {
            mouseDown = false;
        }

        
        }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "placebox")
        {
            print("do stuff");
        }
    }

}
    



