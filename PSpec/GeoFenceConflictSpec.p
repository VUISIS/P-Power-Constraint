// put new specs on the old models, show conflicting traces
// TODO: create the new composed specs
// check battery spec against the fence
// everytime it moves decrement the battery level
// combining GeoFenceSpecs (p specs) with BatteryFailSafe Model (p model) 
spec GeoFenceConflictSpec observes eStartGeoFence, eRequestDroneMovement, eDroneMovementResponse, eFenceReached, eFenceDistanced {
  var battery_percentage : float;
  var power_consumption_rate : float;
  var landing_threshold : float;

  // drone states
  var drone_horizontal_distance_to_origin : int; // in meters
  var drone_altitude : int; // in meters

  start state Init {
    on eStartGeoFence do {
      // start battery level at 100
      battery_percentage = 100.0; // suppose battery starts at 100%
      power_consumption_rate = 1.0; // percentage per meter
      landing_threshold = 20.0;

      // start the drone at home
      drone_horizontal_distance_to_origin = 0;
      drone_altitude = 0;

      print "[conflict spec machine] Geo Fence Enabled!";
      goto GeoFenceEnabled;
    }
  }

  state GeoFenceEnabled {
    on eDroneMovementResponse do (response : tDroneMovementResponse) {
      var cumulative_movement: float;
      cumulative_movement = (response.vertical_movement + response.horizontal_movement) to float;

      // update the drone location
      drone_altitude = drone_altitude + response.vertical_movement;
      drone_horizontal_distance_to_origin = drone_horizontal_distance_to_origin + response.horizontal_movement;

      // decrement the battery based on cumulative movement
      battery_percentage = battery_percentage - cumulative_movement * power_consumption_rate;

      if (battery_percentage <= landing_threshold) {
        goto GeoFenceDisabled;
      }
    }

    on eRequestDroneMovement, eFenceReached, eFenceDistanced do {
      // do nothing in other events where the drone is not moving
    }
  }

  state GeoFenceDisabled {
    entry {
      // ensure that the drone returns to origin
      assert drone_horizontal_distance_to_origin == 0, "[conflict spec machine] drone did not return to origin (horizontal)";
      assert drone_altitude == 0, "[conflict spec machine] drone did not return to origin (horizontal)";
    }
  }
}