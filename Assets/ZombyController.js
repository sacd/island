#pragma strict
//public var go : GameObject;
public var target : Transform;
 private var agent: NavMeshAgent;
public var dist_to_player : float;
public var dtpValue : int = 70;

function Start () 
{
var a : float = Random.Range(0.1,1.0);
agent = GetComponent.<NavMeshAgent>();

yield WaitForSeconds (a);
animation["walk35"].layer = 1;
animation["walk35"].speed = 1.5;
animation.CrossFade("walk35");
animation.wrapMode = WrapMode.Loop;
//set target for NavMesh
yield WaitForSeconds (1);
if (networkView.isMine)
{
   var go : GameObject = GameObject.Find("Main Camera");
   target = go.transform.root;
}
   
}

function FixedUpdate () 
{


if (target)
{
   agent.SetDestination(target.position); 
 
  dist_to_player=Vector3.Distance(target.transform.position, transform.position); 
}

 //destroy zomby if distance to the player is big             
if (dist_to_player > dtpValue)
{
    if (networkView.isMine)  
    {   
       if (Network.isServer)
       {
          Network.RemoveRPCs(networkView.viewID); 
          Network.Destroy(gameObject); 
       }
		 
        else if (Network.isClient){ 
           var viewID : NetworkViewID= Network.AllocateViewID();
           networkView.RPC("ZombyDelete", RPCMode.AllBuffered,viewID);
       }
     }
}  


}



@RPC 
function ZombyDelete(viewID : NetworkViewID) { 
var nView : NetworkView;
nView = GetComponent(NetworkView);
nView.viewID = viewID;
Network.RemoveRPCs(nView.viewID); 
Network.Destroy(gameObject); 

}
