private var UDPHost : String = "127.0.0.1"; // com host
private var listenerPort : int = 12000; // input port
private var broadcastPort : int = 57131; // output port 
private var oscHandler : Osc;

static var valor : int = 0;


public function Start ()
{	
	var udp : UDPPacketIO = GetComponent("UDPPacketIO");
	udp.init(UDPHost, broadcastPort, listenerPort);
	oscHandler = GetComponent("Osc");
	oscHandler.init(udp);
	oscHandler.SetAddressHandler("/jump", processingData);

}

function Update () {
  if(valor == 1)
  	gameObject.Find("PD").GetComponent("salta").SendMessage ("jump", 0);
  if(valor == 2)
  	gameObject.Find("Gumball").GetComponent("salta").SendMessage ("jump", 0);
  if(valor == 3)
  	gameObject.Find("Jake").GetComponent("salta").SendMessage ("jump", 0);
  
  if(valor > 0) valor = -1;

}	

public function processingData(oscMessage : OscMessage) : void
{	
  Osc.OscMessageToString(oscMessage);
  valor = parseInt(oscMessage.Values[0]);

} 

function OnApplicationQuit() {
	oscHandler.Cancel();
}