// made from https://github.com/p-org/P/blob/master/Tutorial/1_ClientServer/PSpec/BankBalanceCorrect.p
// BankBalanceCorrect.p
// event eSpec_AlwaysCorrect;

spec AlwaysCorrect observes ePing, ePong {
  var global_counter : int;

  start state Init {
    entry {
      global_counter = 0;
      goto WaitForPingPongEvents;
    }
  }

  // trigger liveness bug when hitting the execution limit, the system cannot terminate on a hot state
  // the system does however allow termination on a cold state
  // only spec machine are allowed to have hot/cold states
  hot state WaitForPingPongEvents {
    on ePing do {
      global_counter = global_counter + 1;

      // print out the value of global_counter
      print format ("Ping intialized, global_counter = {0}", global_counter);

      // statement that causes the bug
      // assert global_counter <= 10, "global_counter must be <= 10";
    }

    on ePong do {
      global_counter = global_counter + 1;

      // print out the value of global_counter
      print format ("Ping intialized, global_counter = {0}", global_counter);
    }
  }
}