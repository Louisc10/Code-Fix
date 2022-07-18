using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Draggable : MonoBehaviour
{
    public bool IsDragging;

    public Vector3 LastPosition;

    private Collider2D _collider;

    private DragController dragController;

    private float movementTime = 15f;
    private System.Nullable<Vector3> movementDst;

    private Draggable collideDraggable;

    void Start()
    {
        _collider = GetComponent<Collider2D>();
        dragController = FindObjectOfType<DragController>();
    }

    void FixedUpdate()
    {
        if(movementDst.HasValue)
        {
            if (IsDragging)
            {
                movementDst = null;
                return;
            }

            if(transform.position == movementDst)
            {
                gameObject.layer = Layers.Default;
                movementDst = null;
            }
            else
            {
                transform.position = Vector3.Lerp(transform.position, movementDst.Value, movementTime * Time.fixedDeltaTime);
            }
        }

        if (dragController.LastDragged?.gameObject == gameObject)
        {
            movementDst = LastPosition;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        collideDraggable = other.GetComponent<Draggable>();

        if(collideDraggable != null && dragController.LastDragged.gameObject == gameObject)
        {
            ColliderDistance2D colliderDistance2D = other.Distance(_collider);
            Vector3 diff = new Vector3(colliderDistance2D.normal.x, colliderDistance2D.normal.y);

            // Distance not applied for some reason
            Debug.Log(diff);

            transform.position -= diff;

            collideDraggable = null;
        }

        if (other.CompareTag("DropValid"))
        {
            movementDst = other.transform.position;
        }
        else
        {
            movementDst = LastPosition;
        }
    }
}
