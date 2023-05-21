// [safety property] the drone should not exceed the geofence
// TODO:
// (1) GeoFence.p spec
// fix error for event handling
//
// (2) spec machine
// have a way of keeping track of the drone's position based on the movement event
// can copy whatever we had for the GeoFence.p
// check throughout the movement, whether the drone will exceed designated bound (radius)

spec GeoFenceSpec observes eStartGeoFence, eRequestDroneMovement, eDroneMovementResponse, eFenceReached, eFenceDistanced {
  start state Init {
    
  }
}