private var UDPHost : String = "127.0.0.1"; // com host
private var listenerPort : int = 8000; // input port
private var broadcastPort : int = 57131; // output port 
private var oscHandler : Osc;

static var valor : int = 0;
static var prevValor : int = 0;


public function Start ()
{	
	var udp : UDPPacketIO = GetComponent("UDPPacketIO");
	udp.init(UDPHost, broadcastPort, listenerPort);
	oscHandler = GetComponent("Osc");
	oscHandler.init(udp);
	oscHandler.SetAddressHandler("/anima", processingData);

}

function Update () {	
	if(prevValor != valor){
  		gameObject.Find("Ben10").GetComponent("animacion").SendMessage ("anima", valor);
  		gameObject.Find("Darwin").GetComponent("animacion").SendMessage ("anima", valor);
  		gameObject.Find("Finn").GetComponent("animacion").SendMessage ("anima", valor);
  		gameObject.Find("Mordecai").GetComponent("animacion").SendMessage ("anima", valor);
  		gameObject.Find("PChicle").GetComponent("animacion").SendMessage ("anima", valor);
  		gameObject.Find("TitoYayo").GetComponent("animacion").SendMessage ("anima", valor);

		prevValor = valor;
	}
  
}	

public function processingData(oscMessage : OscMessage) : void
{	
  Osc.OscMessageToString(oscMessage);
  valor = parseInt(oscMessage.Values[0])	;

} 

function OnApplicationQuit() {
	oscHandler.Cancel();
}