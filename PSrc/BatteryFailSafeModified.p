// Author:
// Simon Chu, Sumon Biswas

// Purpose: 
// in additional to basic functionality listed previously, this supports dynamic
// update of the battery threshold and based on the battery threshold (that's always enough
// to return to launch), it will return to launch instead of landing immediately

// event declaration used
// event eStartBatteryFailSafe;
// event eUpdateBatteryPercentage;
// event eLanding;
// event eLanded;

machine BatteryFailSafeModified
{
  // indicate the battery percentage limit where landing is required.
  var battery_percentage : float;
  var landing_threshold : float;
  var powerManager : PowerManagement;

  start state Init {
    entry (powerManagerLocal: PowerManagement) {
      powerManager = powerManagerLocal;

      // set initial battery percentage
      battery_percentage = 100.0; // suppose battery starts at 100%
      landing_threshold = 20.0; // have a default landing threshold of 20% 

      print "Battery Fail Safe Enabled!";

      // [required] sync drone battery with power manager
      send powerManager, eUpdateDroneBatteryRequest;

      // [required] request initial threshold from power manager
      send powerManager, eBatteryThresholdRequest, (source = this,);
      goto Monitoring;
    }
  }

  // monitor and update battery percentage
  // determines if the drone needs to land
  state Monitoring {
    on eBatteryThresholdResponse (response: tBatteryThresholdResponse) do {

      // update battery percentage
      battery_percentage = battery_percentage - 1.0;

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