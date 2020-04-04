using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class PlayerMotor : MonoBehaviour
{
    private NavMeshAgent _navMeshAgent;

    private Transform _target;
    // Start is called before the first frame update
    void Start()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        if (_target != null)
        {
            MoveToPoint(_target.transform.position);
            FaceTarget();
        }
    }

    // Update is called once per frame
    public void MoveToPoint(Vector3 destination)
    {
        _navMeshAgent.SetDestination(destination);
    }

    public void TrackTarget(Interactable target)
    {
        _navMeshAgent.stoppingDistance = target.Radius * 0.8f;
        _target = target.InteractionTransform;
    }

    public void StopFollowingTarget()
    {
        _target = null;
        _navMeshAgent.stoppingDistance = 0f;
    }

    private void FaceTarget()
    {
        var direction = _target.position - transform.position;
        var lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0f, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.smoothDeltaTime * 5f);
    }
}
