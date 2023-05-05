type tPingResponse = (source : Ping);

event ePing: tPingResponse;

machine Ping
{
  var counter : int;
  var pong : Pong;

  start state Init {
    // serve the constructor of the Pong class
    // instantiate a new Ping project using new Ping(<pong_machine_instance>)
    entry (pong_local : Pong){
      // set the global counter variable to 0
      counter = 0;

      // set the state machine instance of the pong machine (secondary machine)
      pong = pong_local; 
      goto Ping;
    }
  }

  // ping is started first, and send the first event to pong
  state Ping {
    entry {
      counter = counter + 1;
      print format ("Ping called, counter = {0}", counter);

      // send event ePing to pong machine
      send pong, ePing, (source = this,); 
    }

    on ePong do (pongResp: tPongResponse) {
      counter = counter + 1;
      send pongResp.source, ePing, (source = this,); // send event ePing to pong machine
    }
  }
}