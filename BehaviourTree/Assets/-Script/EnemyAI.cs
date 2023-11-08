using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    BehaviourTree tree;

    NavMeshAgent agent;

    public GameObject player;
    public GameObject location1;
    public GameObject location2;

    public enum ActionState { IDLE, WORKING };
    ActionState state = ActionState.IDLE;

    Node.Status treeStatus = Node.Status.RUNNING;

    void Start()
    {
        agent = this.GetComponent<NavMeshAgent>();

        tree = new BehaviourTree();
        Sequence enemyMovement = new Sequence("Enemy Movement");
        Selector isFrezen = new Selector("Is Frezen");
        Leaf leavePlayer = new Leaf("Leave Player", leavePath);
        Leaf chasePlayer = new Leaf("Chase Player", ChasePlayer);

        enemyMovement.AddChild(chasePlayer);
        enemyMovement.AddChild(leavePlayer);
        enemyMovement.AddChild(isFrezen);
        tree.AddChild(enemyMovement);
     
    }

    public Node.Status FrezenChecker(GameObject player)
    {
        if (player.GetComponent<Player>().enemyFrozen)
        {
            float d1 = Vector3.Distance(location1.transform.position, this.transform.position);
            float d2 = Vector3.Distance(location2.transform.position, this.transform.position);
            if (d1 > d2)//far from d1, go d1, far from player
            {
                Node.Status s = GoToLocation(location1.transform.position);
                return s;
            }
            else
            {
                Node.Status s = GoToLocation(location2.transform.position);
                return s;
            }
        }
        else
        {
            return GoToLocation(player.transform.position);
        }
    }

    public Node.Status ChasePlayer()
    {
        return FrezenChecker(player);
    }

    public Node.Status leavePath()
    {
        return FrezenChecker(player);
    }
    Node.Status GoToLocation(Vector3 destination)
    {
        float distanitionToTarget = Vector3.Distance(destination, this.transform.position);
        if (state == ActionState.IDLE)
        {
            agent.SetDestination(destination);
            state = ActionState.WORKING;
        }
        else if (Vector3.Distance(agent.pathEndPosition, destination) >= 2)
        {
            state = ActionState.IDLE;
            return Node.Status.FAILURE;
        }
        else if (distanitionToTarget < 2)
        {
            state = ActionState.IDLE;
            return Node.Status.SUCCESS;
        }
        return Node.Status.RUNNING;
    }

    void Update()
    {
        if(treeStatus != Node.Status.SUCCESS)
             treeStatus = tree.Process();
    }
}
