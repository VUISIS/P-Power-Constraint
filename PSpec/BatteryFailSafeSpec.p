// [liveness property] check if battery eventually drains (hot states)
// check when the drone lands, the battery is above or equal to the safe landing threshold
// passed

// [safety property] when the drone lands, the battery level must be above or equal to the
// safe landing threshold

// spec machine has 3 states, Init, InAir and Landing
// Init -> InAir -> Landing

spec BatteryFailSafeSpec observes eStartBatteryFailSafe, eUpdateBatteryPercentage, eLanding, eLanded {
  var landing_threshold : int;
  var current_battery: int;

  start state Init {
    on eStartBatteryFailSafe do (startBatteryFailSafeResponse: tStartBatteryFailSafe) {
      current_battery = 100; // initialize battery amount to 100%
      landing_threshold = startBatteryFailSafeResponse.landing_threshold_amount;
      goto InAir;
    }
  }

  hot state InAir {
    // decrement the battery amount by
    on eUpdateBatteryPercentage do {
      current_battery = current_battery - 1;
      print format ("[spec machine] battery updated, battery = {0}", current_battery);
      goto InAir;
    }

    on eLanding goto InAir;
    on eLanded goto Landed;
  }

  cold state Landed {
    entry {
      print "spec machine entered landed state";

      // the ending battery level must be above or equal to the safe landing threshold
      assert current_battery >= landing_threshold, "[spec machine] battery level is below safe landing threshold";
      
      // TODO: Fix this assertion that triggers bugs
      // assert current_battery < landing_threshold, "[spec machine] battery level is below safe landing threshold";
    }
  }
}