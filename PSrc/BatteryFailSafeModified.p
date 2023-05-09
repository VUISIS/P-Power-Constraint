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
  var powerConsumptionRate : float;
  start state Init {
    entry (powerManagerLocal: PowerManagement) {
      powerManager = powerManagerLocal;

      // set initial battery percentage
      battery_percentage = 100.0; // suppose battery starts at 100%
      landing_threshold = 20.0; // have a default landing threshold of 20% 

      powerConsumptionRate = 1.0; // make sure this aligns with powerManager

      print "Battery Fail Safe Enabled!";

      // [required] sync drone battery with power manager
      // pass it from the batteryFailSafeModified state machine to the power manager
      // [muted request] note that this event does not return anything in return
      send powerManager, eUpdateDroneBatteryRequest, (batteryPercentage = battery_percentage,);

      // [required] request initial threshold from power manager
      send powerManager, eBatteryThresholdRequest, (source = this,);
      goto MonitorAndUpdate;
    }
  }

  // monitor and update battery percentage based on distance moved
  // determines if the drone needs to land
  // note that the eDroneMovementResponse and eBatteryThresholdResponse
  // and eDroneMovementUpdate will be sent intermittently to ensure updates
  // and monitors are done
  // without blocking any particular event
  state MonitorAndUpdate {

    // to model the battery depletion
    on eDroneMovementDistanceResponse do (response: tDroneMovementDistanceResponse) {

      // update battery percentage
      // new_battery = old_battery - distanceMoved * powerConsumptionRate
      battery_percentage = battery_percentage - response.droneMovementDistance * powerConsumptionRate;

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
        goto MonitorAndUpdate;
      }

      // note that the drone battery percentage must be updated
      // before the battery threshold is requested.
      // update drone battery percentage
      send powerManager, eUpdateDroneBatteryRequest, (batteryPercentage = battery_percentage,);
      send powerManager, eBatteryThresholdRequest, (source = this,);
    }

    // to update the landing threshold
    on eBatteryThresholdResponse do (response: tBatteryThresholdResponse){
      landing_threshold = response.batteryThreshold;
      print format ("battery threshold updated, threshold = {0}", landing_threshold);

      // request drone
      send powerManager, eDroneMovementDistanceRequest, (source = this,);
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