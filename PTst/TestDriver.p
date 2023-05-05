machine Test {
  start state Init {
    entry {
      // initialize the Pong machine within the ping machine and pass it in
      new Ping(new Pong());
      // new Pong(pong_local = new Pong());
    }
  }
}
