// Date: 2023-05-05 10:01:48
// 
// Purpose: BatteryFailSafe machine ensures if a drone's battery dips below certain threshold
// it will land safely.
//
// Implementation: This machine has a built-in battery model, and it is standalone,
// given the initial battery percentage and landing_threshold.

// type tPingResponse = (source : Ping);

// event ePing: tPingResponse;
event eStartBatteryFailSafe;
event eUpdateBatteryPercentage;
event eLanding;
event eLanded;

machine BatteryFailSafe
{
  // indicate the battery percentage limit where landing is required.
  var battery_percentage : int;
  var landing_threshold : int;

  start state Init {
    entry (landing_threshold_local : int) {
      // set initial battery percentage
      battery_percentage = 100; // suppose battery starts at 100%
      landing_threshold = landing_threshold_local;

      print "Battery Fail Safe Enabled!";

      send this, eStartBatteryFailSafe;
      goto Monitoring;
    }
  }

  // monitor and update battery percentage
  // determines if the drone needs to land
  state Monitoring {
    on eStartBatteryFailSafe, eUpdateBatteryPercentage do {

      // update battery percentage
      battery_percentage = battery_percentage - 1;

      print format ("battery updated, battery = {0}", battery_percentage);

      // if battery percentage is below landing threshold, land
      if (battery_percentage < landing_threshold) {
        print "battery below threshold, landing initiated!";
        send this, eLanding;
        goto Landing;
      }

      // otherwise, continue monitoring
      else {
        print "battery above threshold, continue monitoring!";
        send this, eUpdateBatteryPercentage;
        goto Monitoring;
      }
    }
  }

  state Landing {
    entry {
      print "Landing initiated!";
      send this, eLanded;
      goto Landed;
    }
  }

  state Landed {
    entry {
      // terminating state
      print "Landed!";
    }
  }
}