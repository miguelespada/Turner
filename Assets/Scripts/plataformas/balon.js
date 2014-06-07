#pragma strict

var speed: float = 1.0;
function Start () {

}

function Update () {
	transform.Rotate(0, Time.deltaTime * speed, 0);
}