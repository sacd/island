#pragma strict
var hp: int;
public var timme : int = 0;
public var enter : boolean;
public var otherClip: AudioClip;
public var go : GameObject;

//function Start () {
//Zattack();
// Destroy (this);
//}

function Update () {
if(enter)
{
   if (timme == 3)
   {
      Zattack();
      timme = 0;
   }
}

}




function OnTriggerEnter (other : Collider) {
   if (other.gameObject.tag == "toChange" && other.gameObject.networkView.isMine  ){
     
     go = other.gameObject;
     enter = true;
     Zattack();
     animation.Stop("walk35");
     networkView.RPC("Zenter", RPCMode.All);    
 
   }
  
}

function OnTriggerExit (other : Collider) {
if (other.gameObject.tag == "toChange" && other.gameObject.networkView.isMine){
  enter = false; 
  networkView.RPC("Zexit", RPCMode.All);     

}
   
}

@RPC
function Zenter () {
audio.clip = otherClip;
audio.Play();
      animation.CrossFade("fight35");
      animation.wrapMode = WrapMode.Loop;
       animation["fight35"].speed = 2;
}

@RPC
function Zexit () {

audio.Stop();
   yield WaitForSeconds (1);
    animation.CrossFade("walk35");
    animation.wrapMode = WrapMode.Loop;
}


function Zattack () {
hp++;
go.SendMessage ("DamKick", SendMessageOptions.DontRequireReceiver);
//send
yield WaitForSeconds (1);
timme = 3;

}


function AttackDestroy()
{
 Destroy (this);
} 

