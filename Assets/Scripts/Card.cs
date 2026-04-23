using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using Unity.VisualScripting;
using Unity.ProjectAuditor.Editor;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class Card : MonoBehaviour
{
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

    private Vector3 card;

    private Vector3 arrow;
    private Vector3 offset;
    private Camera mainCamera;

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
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mouse;
        mouse = Input.mousePosition;

       if (Input.GetMouseButtonDown(0) && EventSystem.current.IsPointerOverGameObject())   
        {
            card = new Vector3(transform.position.x, transform.position.y, 0);
            arrow = Input.mousePosition;
        }
        if (Input.GetMouseButton(0) && EventSystem.current.IsPointerOverGameObject())
        {
            offset = arrow - Input.mousePosition;
            transform.position = card - offset;
        }
        if (Input.GetMouseButtonUp(0))
        {
            transform.position = card;
        }
        if(Mouse.current.leftButton.wasPressedThisFrame)
        {
            CheckForClick();
        }
    }
    void CheckForClick()
    {
        //get mouse position on screen (pixels)
        Vector2 mousePos = Mouse.current.position.ReadValue();

        //convert pixels into world position
        Vector3 worldPos = mainCamera.ScreenToWorldPoint(
            new Vector3(mousePos.x, mousePos.y, 0));
        //shoot raycast at that world position
        RaycastHit2D hit = Physics2D.Raycast(worldPos, Vector2.zero);
        //if raycast hits this specific sprite, run logic
        if(hit.collider != null && hit.collider.gameObject == gameObject)
        {
            Debug.Log("Sprite clicked");
        }

    }
}


 