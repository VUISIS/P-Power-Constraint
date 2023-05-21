test battery [main=Test_BatteryFailSafe]:
  assert BatteryFailSafeSpec in
    (union BatteryFailSafe, { Test_BatteryFailSafe });

test geofence [main=Test_GeoFence]:
  assert GeoFenceSpec in
  (union GeoFence, { Test_GeoFence });

// test waypoint [main=Test_Waypoint]:
//   assert WaypointCorrect in
//   (union Waypoint, Avoid, { Test_Waypoint });

// test avoid [main=Test_Avoid]:
//   assert AvoidCorrect in
//   (union Waypoint, Avoid, { Test_Avoid });

// test global [main=Test_Global]:
//   assert GlobalCorrect in
//   (union Waypoint, Avoid, { Test_Global });