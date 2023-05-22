// machine Test {
//   start state Init {
//     entry {
//       // initialize the Pong machine within the ping machine and pass it in
//       new Ping(new Pong());
//       // new Pong(pong_local = new Pong());
//     }
//   }
// }

machine Test_BatteryFailSafe {
  start state Init {
    entry {
      new BatteryFailSafe(20); // land when the drone is at 20% battery capacity
    }
  }
}

machine Test_GeoFence {
  start state Init {
    entry {
      new GeoFence();
    }
  }
}

machine Test_PowerManagement {
  var powerManager: PowerManagement;  
  start state Init {
    entry {
      // have one instance of power management and have
      // the battery fail safe state machine and geo fence state machine
      // refer to it.
      powerManager = new PowerManagement();
      new BatteryFailSafeModified(powerManager);
      new GeoFenceModified(powerManager);

      // new PowerManagement((batteryFailSafe = new BatteryFailSafeModified(), geoFence = new GeoFenceModified()));
    }
  }
}