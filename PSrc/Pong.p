type tPongResponse = (source : Pong);
event ePong : tPongResponse;

machine Pong
{
  var counter : int;

  start state Init {
    entry  {
      counter = 0;
      goto Pong;
    }
  }

  state Pong {
    // wait for ePing event 
    // note that ping machine will call pong machine first
    on ePing do (pingResponse: tPingResponse) {
      counter = counter + 1;
      print format ("Pong called, counter = {0}", counter);

      // send event ePong to ping machine
      send pingResponse.source, ePong, (source = this,); 
    }
  }
}