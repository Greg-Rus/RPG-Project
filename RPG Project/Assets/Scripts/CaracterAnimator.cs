using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))] //This will add the component if it was not on the GameObject.
                                         //This ensures that GetComponent will not return a null.
public class CaracterAnimator : MonoBehaviour
{
    private NavMeshAgent _navMeshAgent;
    private Animator _animator;

    private const float K_locomotionSmoothTime = 0.1f;
    // Start is called before the first frame update
    void Start()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
        _animator = GetComponentInChildren<Animator>(); //This can be slow for complex game objects.
                                                        //Sometimes it is enough to make the field public and drag the component in.
    }

    // Update is called once per frame
    void Update()
    {
        var speed = _navMeshAgent.velocity.magnitude / _navMeshAgent.speed;
        _animator.SetFloat("SpeedPercent", speed, K_locomotionSmoothTime, Time.deltaTime);
    }
}
