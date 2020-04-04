using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    public float Radius = 3;
    public Transform InteractionTransform;

    private bool _isFocused = false;
    private Transform _player;
    private bool _hasInteracted = false;

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(InteractionTransform.position, Radius);
    }

    void Update()
    {
        if (_isFocused && _hasInteracted)
        {
            var distance = Vector3.Distance(InteractionTransform.position, _player.position);
            if (distance <= Radius)
            {
                _hasInteracted = true;
                Interact();
            }
        }
    }

    public void OnFocused(Transform playerTransform)
    {
        _isFocused = true;
        _player = playerTransform;
        _hasInteracted = false;
    }

    public void OnDeFocused()
    {
        _isFocused = false;
        _player = null;
        _hasInteracted = false;
    }

    public virtual void Interact()
    {

    }
}
