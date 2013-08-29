var spotlight : GameObject;
function Update () {
if (Input.GetKeyDown(KeyCode.F)) {
spotlight.active=!spotlight.active;
}
}