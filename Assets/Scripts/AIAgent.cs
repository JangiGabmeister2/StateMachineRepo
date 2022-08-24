using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIAgent : MonoBehaviour
{
    [SerializeField] private GameObject _player;        //serialized fields are private variables which Unity has special access to despite being private 
    [SerializeField] private float _speed;              //serialized fields cannot be called from separate classes
    [SerializeField] private Transform[] _waypoints;    //arrays store multiple values as a single variable
    [SerializeField] private int _waypointIndex = 0;

    #region Patrol + Chase
    public void Patrol()
    {
        Vector2 waypointPosition = _waypoints[_waypointIndex].position;
        MovetoPoint(waypointPosition);
        if (Vector2.Distance(transform.position, waypointPosition) < 0.1f)
        {            
            _waypointIndex++;
        }

        if (_waypointIndex == _waypoints.Length)
        {
            _waypointIndex = 0;
        }
    }
    
    public bool IsPlayerInRange()
    {
        if (Vector2.Distance(transform.position, _player.transform.position) < 5f)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    void MovetoPoint(Vector2 point)
    {
        Vector2 directionToPlayer = point - (Vector2)transform.position;

        directionToPlayer.Normalize();
        directionToPlayer *= _speed * Time.deltaTime;
        transform.position += (Vector3)directionToPlayer;
    }

    public void ChasePlayer()
    {
        if (IsPlayerInRange())
        {
            MovetoPoint(_player.transform.position);
        }
    }
    #endregion

    #region Search
    public void Search()
    {
        int closestIndex = -1;
        float closestDistance = float.MaxValue;

        for (int index = 0; index < _waypoints.Length; index++)
        {
            float currentDistance = Vector2.Distance(_waypoints[index].position, transform.position);
            if (currentDistance < closestDistance)
            {
                closestDistance = currentDistance;
                closestIndex = index;
            }
        }

        _waypointIndex = closestIndex;
    }
    #endregion

    #region Random Patrol
    public void RandomPatrol()
    {        
        Vector2 waypointPosition = _waypoints[_waypointIndex].position;
        MovetoPoint(waypointPosition);
        if (Vector2.Distance(transform.position, waypointPosition) < 0.1f)
        {
            _waypointIndex = Random.Range(0, _waypoints.Length);
        }
    }
    #endregion

    #region Orbit
    public void OrbitPlayer()
    {
        Orbit(_player.transform.position);
    }

    void Orbit(Vector2 point)
    {
        transform.RotateAround(point, Vector3.forward, _speed * 10 * Time.deltaTime);
    }
    #endregion
}
