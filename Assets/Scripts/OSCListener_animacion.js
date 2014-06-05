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
  		gameObject.Find("Ben10").GetComponent("animacionBen10").SendMessage ("anima", valor);
  		gameObject.Find("Darwin").GetComponent("animacionDarwin").SendMessage ("anima", valor);
  		gameObject.Find("Finn").GetComponent("animacionFinn").SendMessage ("anima", valor);
  		gameObject.Find("Mordecai").GetComponent("animacionMordecai").SendMessage ("anima", valor);
  		gameObject.Find("PChicle").GetComponent("animacionPChicle").SendMessage ("anima", valor);
  		gameObject.Find("TitoYayo").GetComponent("animacionTitoYayo").SendMessage ("anima", valor);
  		gameObject.Find("Confetti").GetComponent("animacionConfetti").SendMessage ("anima", valor);
  		gameObject.Find("Confetti_2").GetComponent("animacionConfetti1").SendMessage ("anima", valor);
  		gameObject.Find("Confetti_3").GetComponent("animacionConfetti2").SendMessage ("anima", valor);

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