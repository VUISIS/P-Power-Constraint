// [safety property] the drone should not exceed the geofence
// TODO:
// spec machine
// have a way of keeping track of the drone's position based on the movement event
// eDroneMovementResponse
// can copy whatever we had for the GeoFence.p
// check throughout the movement, whether the drone will exceed designated bound (radius)

spec GeoFenceSpec observes eStartGeoFence, eRequestDroneMovement, eDroneMovementResponse, eFenceReached, eFenceDistanced {
  // fence settings
  var fence_alt_min : int;
  var fence_alt_max : int;
  var fence_radius : int; // in meters, cetnered around the home location

  // drone states
  var drone_horizontal_distance_to_origin : int; // in meters
  var drone_altitude : int; // in meters

  start state Init {
    on eStartGeoFence do {
      // note that these parameter must be consistent with the GeoFence model
      // define the fence boundary
      fence_alt_min = 0;
      fence_alt_max = 100;
      fence_radius = 100;

      // start the drone at home
      drone_horizontal_distance_to_origin = 0;
      drone_altitude = 0;

      print "[spec machine] Geo Fence Enabled!";
      goto GeoFenceEnabled;
    }
  }

  state GeoFenceEnabled {
    on eDroneMovementResponse do (response : tDroneMovementResponse) {
      // update the drone location
      drone_altitude = drone_altitude + response.vertical_movement;
      drone_horizontal_distance_to_origin = drone_horizontal_distance_to_origin + response.horizontal_movement;

      // check if the drone is within the fence
      // exceeded fence radius
      // horizontal distance must be less than the fence radius
      assert drone_horizontal_distance_to_origin < fence_radius, format ("[spec machine] drone exceeded fence radius, fence radius = {0}, horizonal distance to origin = {1}", fence_radius, drone_horizontal_distance_to_origin);
      
      // exceeded fence altitude
      assert drone_altitude > fence_alt_min && drone_altitude < fence_alt_max, format ("[spec machine] drone exceeded fence altitude, fence altitude min = {0}, fence altitude max = {1}, current altitude = {2}", fence_alt_min, fence_alt_max, drone_altitude);
    }

    on eRequestDroneMovement, eFenceReached, eFenceDistanced do {
      // do nothing in other events where the drone is not moving
    }
  }
}