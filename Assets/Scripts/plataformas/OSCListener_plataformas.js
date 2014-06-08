private var UDPHost : String = "127.0.0.1"; // com host
private var listenerPort : int = 12000; // input port
private var broadcastPort : int = 57131; // output port 
private var oscHandler : Osc;

static var valor : int = 0;

var speed_PD: int = 0;
var speed_Gumball: int = 0;
var speed_Jake: int = 0;
var jump_PD: boolean = false;
var jump_Gumball: boolean = false;
var jump_Jake: boolean = false;


public function Start ()
{	
	var udp : UDPPacketIO = GetComponent("UDPPacketIO");
	udp.init(UDPHost, broadcastPort, listenerPort);
	oscHandler = GetComponent("Osc");
	oscHandler.init(udp);
	oscHandler.SetAddressHandler("/jump", processingData);

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
  if(jump_Jake || Input.GetKeyDown("1")){
  	gameObject.Find("Jake").GetComponent("salta").SendMessage ("jump", 4);
  	jump_Jake = false;
  }  

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