using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragNDrop : MonoBehaviour
{
    private bool _isDragActive = false;
    private Draggable _lastDragged;
    Vector3 _worldPosition;
    Vector2 _screenPosition;

    private void Awake()
    {
        DragNDrop[] controllers = FindObjectsOfType<DragNDrop>();
        if(controllers.Length > 1)
        {
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        if (_isDragActive)
        {
            if (Input.GetMouseButtonUp(0) || (Input.touchCount == 1 && Input.GetTouch(0).phase == TouchPhase.Ended))
            {
                Drop();
                return;
            }
        }

        if(Input.GetMouseButton(0))
        {
            Vector3 mousePos = Input.mousePosition;
            _screenPosition = new Vector2(mousePos.x, mousePos.y);
        }
        else if (Input.touchCount > 0)
        {
            _screenPosition = Input.GetTouch(0).position;
        }
        else
        {
            return;
        }

        _worldPosition = Camera.main.ScreenToWorldPoint(_screenPosition);

        if(_isDragActive)
        {
            Drag();
        }
        else
        {
            RaycastHit2D hit = Physics2D.Raycast(_worldPosition, Vector2.zero);
            if(hit.collider != null)
            {
                Draggable draggable = hit.transform.gameObject.GetComponent<Draggable>();
                if( draggable != null )
                {
                    _lastDragged = draggable;
                    InitDrag();
                }
                
            }
        }
    }

    private void Drag()
    {
        _isDragActive= true;
    }

    private void InitDrag()
    {
        _lastDragged.transform.position = new Vector2(_worldPosition.x, _worldPosition.y);
    }

    void Drop()
    {
        _isDragActive= false;
    }
}
