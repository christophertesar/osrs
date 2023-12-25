using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public interface IState
{
    public void Enter();
    public void Execute();
    public void Exit();
}
 
public class StateMachine
{
    IState currentState;
 
    public void ChangeState(IState newState)
    {
        if (currentState != null)
            currentState.Exit();
 
        currentState = newState;
        currentState.Enter();
    }
 
    public void Update()
    {
        if (currentState != null) currentState.Execute();
    }
}
 
public class NPC : MonoBehaviour
{
    StateMachine stateMachine = new StateMachine();
    public Vector3 spawnPoint;
    public float speed = 3.0f;
    public float walkRange = 10.0f;
    public CharacterController characterController;

    void Start()
    {
        spawnPoint = transform.position;
        characterController = GetComponent<CharacterController>();
        stateMachine.ChangeState(new Idle(this));
    }
 
    void Update()
    {
        stateMachine.Update();
    }

    public void ChangeState(IState state){
        stateMachine.ChangeState(state);
    }
}

public class Idle : MonoBehaviour, IState{
    NPC owner;
    public Idle(NPC owner) { this.owner = owner; }

    private float timeToIdle;

    private bool idleing = true;

    public void Enter(){
        Debug.Log(owner.transform.root.GetChild(1).gameObject);
        GameObject idleModel = owner.transform.root.GetChild(1).gameObject;
        idleModel.SetActive(true);
        timeToIdle = UnityEngine.Random.Range(2.0f, 8.0f);
        idleing = true;
        //StartCoroutine(ExecuteAfterTime(timeToIdle));
        idleing = false;
    }
    public void Execute(){
        if(!idleing){
            owner.ChangeState(new Walk(owner));
        }
    }
    public void Exit(){
        GameObject idleModel = owner.transform.root.GetChild(1).gameObject;
        idleModel.SetActive(false);
    }

    IEnumerator ExecuteAfterTime(float time)
    {
        yield return new WaitForSeconds(time);

        idleing = false;
    }
}

public class Walk : IState{
    NPC owner;
    public Walk(NPC owner) { this.owner = owner; }

    private Vector3 walkPoint;
    private Vector3 walkDirection;

    private float tol = 0.3f;

    public void Enter(){
        GameObject walkModel = owner.transform.root.GetChild(0).gameObject;
        walkModel.SetActive(true);
        walkPoint.x = owner.spawnPoint.x + UnityEngine.Random.Range(-owner.walkRange, owner.walkRange);
        walkPoint.y = owner.spawnPoint.y;
        walkPoint.z = owner.spawnPoint.z + UnityEngine.Random.Range(-owner.walkRange, owner.walkRange);
        owner.transform.LookAt(walkPoint);
    }
    public void Execute(){
        if(InRange(owner.transform.root.position.x, walkPoint.x, tol) & InRange(owner.transform.root.position.z, walkPoint.z, tol)){
            owner.ChangeState(new Idle(owner));
        }
        else{
            owner.characterController.SimpleMove((walkPoint - owner.transform.position).normalized * owner.speed);
        }
    }
    public void Exit(){
        GameObject walkModel = owner.transform.root.GetChild(1).gameObject;
        walkModel.SetActive(false);
    }

    bool InRange(float x, float y, float tol){
        if(Math.Abs(x-y) <= tol){
            return true;
        }
        else{
            return false;
        }
    }
}