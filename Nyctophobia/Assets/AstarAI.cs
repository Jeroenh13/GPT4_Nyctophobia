using UnityEngine;
using System.Collections;
//Note this line, if it is left out, the script won't know that the class 'Path' exists and it will throw compiler errors
//This line should always be present at the top of scripts which use pathfinding
using Pathfinding;
public class AstarAI : MonoBehaviour
{
    //The point to move to
    public Transform targetPosition;

    private Seeker seeker;
    private CharacterController controller;

    //The calculated path
    public Path path;

    //The AI's speed per second
    public float speed = 100;

    //The max distance from the AI to a waypoint for it to continue to the next waypoint
    public float nextWaypointDistance = 3;

    //The waypoint we are currently moving towards
    private int currentWaypoint = 0;

    private Animator anim;
    public float range = 4f;
    private float range2 = 4f;
    private float stop = 2.2f;
    private Transform myTransform;
    public bool scared = false;
    public int scaredmeter = 0;
    public int maxscared;
    public Transform savespot;
    private Transform follow;

    public bool standingstill = false;

    public void Awake()
    {
        myTransform = transform;
    }

    public void Start()
    {
        seeker = GetComponent<Seeker>();
        controller = GetComponent<CharacterController>();
        anim = GetComponent<Animator>();
    }

    public void OnPathComplete(Path p)
    {
        if (!p.error)
        {
            path = p;
            //Reset the waypoint counter
            currentWaypoint = 0;
        }
    }

    public void FixedUpdate()
    {
        if (scaredmeter == maxscared)
            scared = true;

        if (scared == false && follow != targetPosition)
        {
            follow = targetPosition;
            Debug.Log("target = targetposition");
        }
        else if (scared == true && follow != savespot)
        {
            follow = savespot;
            range = 100f;
            Debug.Log("target = savespot");
        }

        if (standingstill == false)
        {
            //Start a new path to the targetPosition, return the result to the OnPathComplete function
            seeker.StartPath(transform.position, follow.position, OnPathComplete);
        }
        if (standingstill == true)
            anim.SetBool("Run", false);

        if (path == null)
        {
            //We have no path to move after yet
            return;
        }

        if (currentWaypoint >= path.vectorPath.Count)
        {
            return;
        }

        float distance = Vector3.Distance(myTransform.position, follow.position);
        if (distance <= range && distance > stop)
        {
            anim.SetBool("Run", true);
            //Direction to the next waypoint
            Vector3 dir = (path.vectorPath[currentWaypoint] - transform.position).normalized;
            dir *= speed * Time.fixedDeltaTime;
            controller.SimpleMove(dir);
            transform.rotation = Quaternion.LookRotation(dir);

            //Check if we are close enough to the next waypoint
            //If we are, proceed to follow the next waypoint
            if (Vector3.Distance(transform.position, path.vectorPath[currentWaypoint]) < nextWaypointDistance)
            {
                currentWaypoint++;
                return;
            }
        }
        else if (distance <= stop)
        {
            anim.SetBool("Run", false);
        }
        else if (distance >= range)
        {
            anim.SetBool("Run", false);
        }
    }
}