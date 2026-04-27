using UnityEngine;
using UnityEngine.EventSystems;
public class dragUI : MonoBehaviour,
IBeginDragHandler, IDragHandler, IEndDragHandler
{
public Transform parentTransform;
private Canvas canvas;
void Awake()
{
//rectTransform = GetComponentInParent<RectTransform>();
canvas = GetComponentInParent<Canvas>();
}
public void OnBeginDrag(PointerEventData eventData)
{
// Called once when the drag starts
Debug.Log("Started dragging " + gameObject.name);
}
public void OnDrag(PointerEventData eventData)
{
// Called every frame while dragging
parentTransform.position = new Vector2(parentTransform.position.x,parentTransform.position.y) + eventData.delta;
}
public void OnEndDrag(PointerEventData eventData)
{
// Called once when the drag ends
Debug.Log("Finished dragging " + gameObject.name);
}
}

