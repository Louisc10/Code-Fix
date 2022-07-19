using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragController : MonoBehaviour
{
    public AnswerController ans;
    public Draggable LastDragged => lastDragged;

    // Check if user is dragging
    private bool isDragActive = false;

    // Check position of input
    private Vector2 screenPosition;
    private Vector3 worldPosition;

    // Get last dragged item
    private Draggable lastDragged;

    void Awake()
    {
        DragController[] controllers = FindObjectsOfType<DragController>();

        if(controllers.Length > 1)
        {
            Destroy(gameObject); 
        }
    }

    private void Start()
    {
        ans = FindObjectOfType<AnswerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if(isDragActive && (Input.GetMouseButtonUp(0) || (Input.touchCount == 1 && Input.GetTouch(0).phase == TouchPhase.Ended)))
        {
            Drop();
            return;
        }

        if(Input.GetMouseButton(0))
        {
            Vector3 mousePos = Input.mousePosition;
            screenPosition = new Vector2(mousePos.x, mousePos.y);
        }
        else if (Input.touchCount > 0)
        {
            screenPosition = Input.GetTouch(0).position;
        }
        else
        {
            return;
        }

        worldPosition = Camera.main.ScreenToWorldPoint(screenPosition);

        if (isDragActive)
        {
            Drag();
        }
        else
        {
            RaycastHit2D hit = Physics2D.Raycast(worldPosition, Vector2.zero);
            if(hit.collider != null)
            {
                Draggable draggable = hit.transform.gameObject.GetComponent<Draggable>();
                if(draggable != null)
                {
                    lastDragged = draggable;
                    InitDrag();
                }
            }
        }
    }

    void InitDrag()
    {
        lastDragged.LastPosition = lastDragged.transform.position;
        UpdateDragStatus(true);
    }

    void Drag()
    {
        lastDragged.transform.position = new Vector2(worldPosition.x, worldPosition.y);
    }

    void Drop()
    {
        UpdateDragStatus(false);
    }

    void UpdateDragStatus (bool isDragging)
    {
        isDragActive = lastDragged.IsDragging = isDragging;
        lastDragged.gameObject.layer = isDragging ? Layers.Dragging : Layers.Default;
    }
}
