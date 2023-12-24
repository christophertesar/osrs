// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// using UnityEngine.AI;

// public class EnemyAI : MonoBehaviour
// {
//     // Start is called before the first frame update
//     private Vector3 spawnPoint;
//     public float walkPointRange;
//     public float speed;

//     CharacterController controller;

//     private Vector3 walkPoint;

//     Vector2 rotation = Vector2.zero;

//     private void Awake(){
//         spawnPos = transform.position;
//     }

//     private getWalkPoint(){
//         float randomZ = randomZ.Range(-walkPointRange, walkPointRange);
//         float randomX = randomZ.Range(-walkPointRange, walkPointRange);
//         walkPoint = new Vector3(spawnPoint.x + randomX, spawnPoint.y, spawnPoint.z + randomZ);
//     }

//     void Start()
//     {
//         controller = GetComponent<CharacterController>();
//         rotation.y = transform.eulerAngles.y;
//         while(true){
            
//         }
//     }

//     // Update is called once per frame
//     void Update()
//     {
//         controller.SimpleMove(speed);
//     }
// }
