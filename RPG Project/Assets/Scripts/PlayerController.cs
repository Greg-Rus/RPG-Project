using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerController : MonoBehaviour
{
    private Camera _camera;
    private PlayerMotor _playerMotor;
    //Layers
    public LayerMask WalkableLayerMask;

    public Interactable Focus;

    // Start is called before the first frame update
    void Start()
    {
        _camera = Camera.main;
        _playerMotor = GetComponent<PlayerMotor>();
    }

    // Update is called once per frame
    private void Update()
    {
        if (EventSystem.current.IsPointerOverGameObject()) return;

        if (Input.GetMouseButtonDown(0))
        {
            //Camera matrix conversions
            Ray ray = _camera.ScreenPointToRay(Input.mousePosition);
            //Ray ray2 = new Ray(_camera.transform.position, _camera.transform.forward);

            //out variable declaration
            RaycastHit hit;

            //out variables
            if (Physics.Raycast(ray, out hit, 100, WalkableLayerMask))
            {
                var sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                sphere.transform.position = hit.point;
                Destroy(sphere,2);

                _playerMotor.MoveToPoint(hit.point);

                RemoveFocus();
                _playerMotor.StopFollowingTarget();
            }
        }

        if (Input.GetMouseButtonDown(1))
        {
            Ray ray = _camera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 100f))
            {
                Interactable interactable = hit.collider.gameObject.GetComponent<Interactable>();
                if (interactable != null)
                {
                    SetFocus(interactable);
                }
            }
        }   
    }

    private void SetFocus(Interactable newFocus)
    {
        if (Focus != newFocus)
        {
            if (Focus != null)
            {
                Focus.OnDeFocused();
            }
            Focus = newFocus;
            _playerMotor.TrackTarget(Focus);
        }

        Focus.OnFocused(transform);
    }

    private void RemoveFocus()
    {
        if (Focus != null)
        {
            Focus.OnDeFocused();
        }
        
        Focus = null;
        _playerMotor.StopFollowingTarget();
    }
}
