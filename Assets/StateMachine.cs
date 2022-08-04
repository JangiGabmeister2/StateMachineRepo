using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine : MonoBehaviour
{
    public enum state
    {
        Patrol,
        Search,
        Chase,
        BerryPicking
    }

    [SerializeField] private state _state;

    void Start()
    {
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
            case state.Search:
                StartCoroutine(SearchState());
                break;
            case state.Chase:
                StartCoroutine(ChaseState());
                break;
            case state.BerryPicking:
                StartCoroutine(BerryPickingState());
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
        while (_state == state.Patrol)
        {
            //Our code runs here.
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
            yield return null; //wait a single frame
        }
        Debug.Log("Berry Picking: Exit");
        NextState();
    }
    private IEnumerator ChaseState()
    {
        Debug.Log("Chase: Enter");
        while (_state == state.Chase)
        {
            //Our code runs here.
            yield return null; //wait a single frame
        }
        Debug.Log("Chase: Exit");
        NextState();
    }
    private IEnumerator SearchState()
    {
        Debug.Log("Search: Enter");
        while (_state == state.Search)
        {
            //Our code runs here.
            yield return null; //wait a single frame
        }
        Debug.Log("Search: Exit");
        NextState();
    }
    #endregion
}
