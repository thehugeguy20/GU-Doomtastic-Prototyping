using UnityEngine;
using UnityEngine.AI;

public class RatNavAI : MonoBehaviour
{

    public NavMeshAgent agent;
    private bool hunting = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (hunting == true)
        {
            GameObject playerObj = GameObject.Find("Player");
            agent.SetDestination(playerObj.transform.position);

            if (Input.GetKeyDown(KeyCode.H))
            {
                hunting = false;
                agent.SetDestination(this.transform.position);
            }
        }
        else if (Input.GetKeyDown(KeyCode.H))
        {
            hunting = true;
        }
    }
}
