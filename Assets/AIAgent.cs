using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIAgent : MonoBehaviour
{
    [SerializeField] private GameObject _player;    //serialized fields are private variables which Unity has special access to despite being private 
    [SerializeField] private float _speed;          //serialized fields cannot be called from separate classes
    [SerializeField] private Transform[] _waypoints; //arrays store multiple values as a single variable
    [SerializeField] private int _waypointIndex = 0;

    void Update()
    {
        Vector2 waypointPosition = _waypoints[_waypointIndex].position;
        MovetoPoint(waypointPosition);
        if (Vector2.Distance(transform.position, waypointPosition) < 0.1f)
        {
            _waypointIndex++;
            if (_waypointIndex == _waypoints.Length)
            {
                _waypointIndex = 0;
            }
        }
        //MovetoPoint(_player.transform.position);                                                                                                                           
    }
    void MovetoPoint(Vector2 point)
    {
        Vector2 directionToPlayer = point - (Vector2)transform.position;

        directionToPlayer.Normalize();
        directionToPlayer *= _speed * Time.deltaTime;
        transform.position += (Vector3)directionToPlayer;
    }
}
