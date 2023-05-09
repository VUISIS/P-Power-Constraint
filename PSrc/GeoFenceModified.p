// Author:
// Simon Chu, Sumon Biswas

// Purpose: 
// in additional to basic functionality listed previously, this supports dynamic
// resizing of the geo fence based on the battery level, distance to the origin, etc.

type tDroneMovementResponseFloat = (horizontal_movement : float, vertical_movement : float);
event eDroneMovementResponseFloat: tDroneMovementResponseFloat;

// event eStartGeoFence;
// event eRequestDroneMovement;
// event eFenceReached;
// event eFenceDistanced;


machine GeoFenceModified {
  var powerManager : PowerManagement;

  // fence settings
  var fence_alt_min : float;
  var fence_alt_max : float;
  var fence_radius : float; // in meters, cetnered around the home location

  // drone states
  var drone_horizontal_distance_to_origin : float; // in meters
  var drone_altitude : float; // in meters

  var drone_movement: float; // in meters

  start state Init {
  entry (powerManagerLocal: PowerManagement) {
      powerManager = powerManagerLocal;

      fence_alt_min = 0.0;
      fence_alt_max = 100.0;
      fence_radius = 100.0; // by default set the fence radius to 100

      // cache variable to record the previous movement
      drone_movement = 0.0;

      // start the drone at home
      drone_horizontal_distance_to_origin = 0.0;
      drone_altitude = 0.0;

      print "GeoFence Enabled!";

      // [muted request, no response] update drone movement and position
      send powerManager, eUpdateDroneMovementDistanceAndPosition, (droneMovementDistance = drone_movement, droneHorizontalPosition = drone_horizontal_distance_to_origin, droneVerticalPosition = drone_altitude);
      
      // request for fence radius and enter monitor and update state
      send powerManager, eFenceRadiusRequest, (source = this,);

      goto MonitorAndUpdate;
    }
  }

  // everytime fence is updated or drone just got out of a holding pattern
  // after hitting the fence, the drone will move.
  state MonitorAndUpdate {
    on eFenceRadiusResponse do (response : tFenceRadiusResponse) {
      // update the fence radius
      fence_radius = response.fenceRadius;

      // start the drone movement generator
      send this, eRequestDroneMovement;
      goto GenerateMovement;
    }

    on eFenceDistanced do {
      // start the drone movement generator
      send this, eRequestDroneMovement;
      goto GenerateMovement;
    }
    
    // the drone moves
    on eDroneMovementResponseFloat do (response : tDroneMovementResponseFloat) {
      
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

      // [muted request] everytime that the drone moves, update the movement and position
      send powerManager, eUpdateDroneMovementDistanceAndPosition, (droneMovementDistance = response.vertical_movement + response.horizontal_movement, droneHorizontalPosition = drone_horizontal_distance_to_origin, droneVerticalPosition = drone_altitude);

      // request a new Fence
      send powerManager, eFenceRadiusRequest, (source = this,);
    }
  }

  // temporarily holding the drone.
  state Holding {
    on eFenceReached do {
      // start holding pattern
      print "Fence Reached! Starting Holding Pattern";

      send this, eFenceDistanced;
      goto MonitorAndUpdate;
    }
  }

  state GenerateMovement {
    on eRequestDroneMovement do {
      var response : tDroneMovementResponseFloat;

      // generate random movement from -10 ~ 10
      response.horizontal_movement = (choose(20) - 10) to float;
      response.vertical_movement = (choose(20) - 10) to float;

      send this, eDroneMovementResponseFloat, response;
      goto MonitorAndUpdate;
    }
  }
}