using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class ClickToMove : MonoBehaviour
{
    public LayerMask groundLayer;   // layer ground
    public NavMeshAgent agent;      // NavMesh agent
    public Transform player; //player position

    public GameObject SC;
    // stop ?
    public bool stop = false;
   
}
