private var UDPHost : String = "127.0.0.1"; // com host
private var listenerPort : int = 12000; // input port
private var broadcastPort : int = 57131; // output port 
private var oscHandler : Osc;

static var valor : int = 0;

var speed_PD: int = 4;
var speed_Gumball: int = 4;
var speed_Jake: int = 4;
var jump_PD: boolean = false;
var jump_Gumball: boolean = false;
var jump_Jake: boolean = false;

var gameTime: int = -1;
var itemFreq: int = -1;


public function Start ()
{	
	var udp : UDPPacketIO = GetComponent("UDPPacketIO");
	udp.init(UDPHost, broadcastPort, listenerPort);
	oscHandler = GetComponent("Osc");
	oscHandler.init(udp);
	oscHandler.SetAddressHandler("/jump", processingData);
	oscHandler.SetAddressHandler("/gameTimeLabel", setGameTime);
	oscHandler.SetAddressHandler("/itemFreqLabel", setItemFreq);

}

function Update () {
  if(jump_PD){
  	gameObject.Find("PD").GetComponent("salta").SendMessage ("jump", speed_PD);
  	jump_PD = false;
  }
  if(jump_Gumball){
  	gameObject.Find("Gumball").GetComponent("salta").SendMessage ("jump", speed_Gumball);
  	jump_Gumball = false;
  }
  if(jump_Jake){
  	gameObject.Find("Jake").GetComponent("salta").SendMessage ("jump", speed_Jake);
  	jump_Jake = false;
  }  
  
  if(Input.GetKeyDown("1")){
  	gameObject.Find("PD").GetComponent("salta").SendMessage ("jump", 3);
 }
  if(Input.GetKeyDown("2")){
  	gameObject.Find("Gumball").GetComponent("salta").SendMessage ("jump", 3);
  }
  if(Input.GetKeyDown("3")){
  	gameObject.Find("Jake").GetComponent("salta").SendMessage ("jump", 3);
  }  

 if(gameTime > 0){
 	for (var items in GameObject.FindGameObjectsWithTag ("items"))
		items.GetComponent("logic").SendMessage ("setGameTime", gameTime);
 	gameTime = -1;
 }
 
 if(itemFreq > 0){
 	for (var items in GameObject.FindGameObjectsWithTag ("items"))
		items.GetComponent("logic").SendMessage ("setItemFreq", itemFreq);
 	itemFreq = -1;
 }
}	

public function setGameTime(oscMessage : OscMessage) : void{
  gameTime = parseInt(oscMessage.Values[0]);
}
public function setItemFreq(oscMessage : OscMessage) : void{
  itemFreq = parseInt(oscMessage.Values[0]);
	
}


public function processingData(oscMessage : OscMessage) : void
{
		
  Osc.OscMessageToString(oscMessage);
  valor = parseInt(oscMessage.Values[0]);
  
  if(valor == 1) {
  	speed_PD = parseInt(oscMessage.Values[1]);
  	jump_PD = true;
  }
  if(valor == 2) {
  	speed_Gumball = parseInt(oscMessage.Values[1]);
  	jump_Gumball = true;
  }
  if(valor == 3) {
  	speed_Jake = parseInt(oscMessage.Values[1]);
  	jump_Jake = true;
  }

 } 

function OnApplicationQuit() {
	oscHandler.Cancel();
}