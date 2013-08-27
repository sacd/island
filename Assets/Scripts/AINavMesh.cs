using UnityEngine; 
using System.Collections; 

public class AINavMesh : MonoBehaviour { 
public Transform _target; // Указываем переменную, к которой будет двигаться наш агент 
NavMeshAgent _agent; // Указываем переменную агента 

void Start () { 
_agent = (NavMeshAgent)this.GetComponent("NavMeshAgent"); // Указываем, что переменная _agent - это наш агент. 
} 

void Update () { 
_agent.SetDestination(_target.position); // Заставляем агента двигаться в сторону _target'а 
} 
} 