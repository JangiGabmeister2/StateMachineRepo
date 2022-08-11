using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AIAgent))]

public class StateMachine : MonoBehaviour
{
    public enum state
    {
        Patrol,
        Chase,
        BerryPicking,
        RandomPatrol,
        Orbit
    }

    [SerializeField] private state _state;

    private AIAgent _aiAgent;

    void Start()
    {
        _aiAgent = GetComponent<AIAgent>();
        NextState();
    }

    private void NextState()
    {
        /*
        if (_state == state.Patrol)
        {
            StartCoroutine(PatrolState());
        }
        else
        {
            if (_state == state.BerryPicking)
            {
                yada yada
            }
        }
        */
        //instead of making a long list of if else statements, use switch statements

        switch (_state)
        {
            case state.Patrol:
                StartCoroutine(PatrolState());
                break;
            case state.Chase:
                StartCoroutine(ChaseState());
                break;
            case state.BerryPicking:
                StartCoroutine(BerryPickingState());
                break;
            case state.RandomPatrol:
                StartCoroutine(RandomPatrolState());
                break;
            case state.Orbit:
                StartCoroutine(OrbitState());
                break;
            default:
                Debug.LogWarning("State does not exist in NextState function, stopping StateMachine");
                break;
        }
    }

    #region States
    private IEnumerator PatrolState()
    {
        Debug.Log("Patrol: Enter");
        _aiAgent.Search();
        while (_state == state.Patrol)
        {
            _aiAgent.Patrol();
            if (_aiAgent.IsPlayerInRange())
            {
                _state = state.Chase;
            }
            yield return null; //wait a single frame
        }
        Debug.Log("Patrol: Exit");
        NextState();
    }
    private IEnumerator BerryPickingState()
    {
        Debug.Log("Berry Picking: Enter");
        while (_state == state.BerryPicking)
        {
            //Our code runs here.
            yield return null;
        }
        Debug.Log("Berry Picking: Exit");
        NextState();
    }
    private IEnumerator ChaseState()
    {
        Debug.Log("Chase: Enter");
        while (_state == state.Chase)
        {
            _aiAgent.ChasePlayer();
            if (!_aiAgent.IsPlayerInRange())
            {
                _state = state.Patrol;
            }
            yield return null;
        }
        Debug.Log("Chase: Exit");
        NextState();
    }
    private IEnumerator RandomPatrolState()
    {
        Debug.Log("AI is patrolling randomly");
        while (_state == state.RandomPatrol)
        {
            _aiAgent.RandomPatrol();
            if (_aiAgent.IsPlayerInRange())
            {
                _state = state.Chase;
            }
            yield return null;
        }
        Debug.Log("AI is no longer patrolling randomly");
        NextState();
    }
    private IEnumerator OrbitState()
    {
        Debug.Log("AI is orbiting you");
        while (_state == state.RandomPatrol)
        {
            _aiAgent.OrbitPlayer();
            yield return null;
        }
        Debug.Log("AI is no longer orbiting you");
        NextState();
        yield return null;
    }
    #endregion
}
