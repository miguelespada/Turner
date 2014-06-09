private var UDPHost : String = "127.0.0.1"; // com host
private var listenerPort : int = 12000; // input port
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
  		gameObject.Find("Ben10").GetComponent("animar").SendMessage ("anima", valor);
  		gameObject.Find("Darwin").GetComponent("animar").SendMessage ("anima", valor);
  		gameObject.Find("Finn").GetComponent("animar").SendMessage ("anima", valor);
  		gameObject.Find("Mordecai").GetComponent("animar").SendMessage ("anima", valor);
  		gameObject.Find("PChicle").GetComponent("animar").SendMessage ("anima", valor);
  		gameObject.Find("TitoYayo").GetComponent("animar").SendMessage ("anima", valor);
  		gameObject.Find("Camera").GetComponent("fx").SendMessage ("anima", valor);
		  prevValor = valor;
	}
  if (Input.anyKeyDown && Input.inputString.length == 1){
    var keyPressed : int = parseInt(Input.inputString) ;
    if(keyPressed >= 1 && keyPressed <= 5){
      valor = keyPressed - 1;
    }
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