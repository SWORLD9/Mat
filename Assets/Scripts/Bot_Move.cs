using Unity.AI.Navigation;
using UnityEngine;
using UnityEngine.AI;

public class Bot_Move : MonoBehaviour
{
    [SerializeField] private GameObject Respawn;
    [SerializeField] private GameObject PLayer_1;
    private NavMeshAgent agent;
    
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
      // agent.SetDestination(PLayer_1.transform.position);
    }

    
    void FixedUpdate()
    { 
        
        if (this.transform.position.y < -0.91)  // Если падает - возвращаем в начало
        {

            this.transform.position = Respawn.transform.position;
        }
    }
}
