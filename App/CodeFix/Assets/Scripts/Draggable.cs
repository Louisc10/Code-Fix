using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Draggable : MonoBehaviour
{
    public bool IsDragging;

    public Vector3 LastPosition;
    public Vector3 _initPosition;

    private Collider2D _collider;
    private Collider2D _lastCollidedWith;

    private DragController dragController;

    private float movementTime = 15f;
    private System.Nullable<Vector3> movementDst;

    private bool isInit = false;

    void Start()
    {
        _collider = GetComponent<Collider2D>();

        dragController = FindObjectOfType<DragController>();
        LastPosition = transform.position;
        _initPosition = transform.position;
    }

    private void Update()
    {
        // Still ineffecient
        Vector2 size = ((RectTransform)transform).sizeDelta;
        ((BoxCollider2D)_collider).size = new Vector2(size.x, size.y);
        ((BoxCollider2D)_collider).offset = new Vector2(0, size.y / 3);
    }

    void FixedUpdate()
    {

        if (movementDst.HasValue)
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

        if(!IsDragging && _lastCollidedWith == null)
        {
            movementDst = _initPosition;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Draggable collideDraggable = other.GetComponent<Draggable>();

        //if(collideDraggable != null && dragController.LastDragged.gameObject == gameObject)
        //{
        //    ColliderDistance2D colliderDistance2D = other.Distance(_collider);
        //    Vector3 diff = new Vector3(colliderDistance2D.normal.x, colliderDistance2D.normal.y);

        //    transform.position -= diff;
        //}

        if (other.CompareTag("DropValid"))
        {
            _lastCollidedWith = other;
            movementDst = other.transform.position;
        }
        else
        {
            movementDst = LastPosition;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("DropValid"))
        {
            _lastCollidedWith = null;
            movementDst = _initPosition;
        }
    }
}
