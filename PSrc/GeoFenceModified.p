// Author:
// Simon Chu, Sumon Biswas

// Purpose: 
// in additional to basic functionality listed previously, this supports dynamic
// resizing of the geo fence based on the battery level, distance to the origin, etc.

// type tDroneMovementResponse = (horizontal_movement : int, vertical_movement : int);

// event eStartGeoFence;
// event eRequestDroneMovement;
// event eDroneMovementResponse: tDroneMovementResponse;
// event eFenceReached;
// event eFenceDistanced;


machine GeoFenceModified {
  var powerManager : PowerManagement;

  // fence settings
  var fence_alt_min : int;
  var fence_alt_max : int;
  var fence_radius : int; // in meters, cetnered around the home location

  // drone states
  var drone_horizontal_distance_to_origin : int; // in meters
  var drone_altitude : int; // in meters

  start state Init {
  entry (powerManagerLocal: PowerManagement) {
      powerManager = powerManagerLocal;

      fence_alt_min = 0;
      fence_alt_max = 100;
      fence_radius = 100;

      // start the drone at home
      drone_horizontal_distance_to_origin = 0;
      drone_altitude = 0;

      print "Geo Fence Enabled!";

      send this, eStartGeoFence;
      goto Monitoring;
    }
  }

  state Monitoring {
    on eStartGeoFence, eFenceDistanced do {
      // start the drone movement generator
      send this, eRequestDroneMovement;
      goto GenerateMovement;
    }
      
    on eDroneMovementResponse do (response : tDroneMovementResponse) {
      
      // check if the drone is within the fence
      // exceeded fence radius
      if (drone_horizontal_distance_to_origin + response.horizontal_movement > fence_radius) {
        // drone is outside the fence, start holding pattern
        send this, eFenceReached;
        goto Holding;
      } 
      
      // exceeded fence altitude
      else if (drone_altitude + response.vertical_movement < fence_alt_min || drone_altitude + response.vertical_movement > fence_alt_max) {
        // drone is within the fence, check if the altitude is within the fence
        send this, eFenceReached;
        goto Holding;
      }
      
      // update the drone's location normally
      else {
        // update the drone's position
        drone_altitude = drone_altitude + response.vertical_movement;
        drone_horizontal_distance_to_origin = drone_horizontal_distance_to_origin + response.horizontal_movement;
      }
    }
  }

  // temporarily holding the drone.
  state Holding {
    on eFenceReached do {
      // start holding pattern
      print "Fence Reached! Starting Holding Pattern";

      send this, eFenceDistanced;
      goto Monitoring;
    }
  }

  state GenerateMovement {
    on eRequestDroneMovement do {
      var response : tDroneMovementResponse;

      // generate random movement from -10 ~ 10
      response.horizontal_movement = choose(20) - 10;
      response.vertical_movement = choose(20) - 10;

      send this, eDroneMovementResponse, response;
      goto Monitoring;
    }
  }
}