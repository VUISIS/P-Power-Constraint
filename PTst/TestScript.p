// ************************************
// ***** TEST FOR ORIGINAL MODELS *****
// ************************************

// original battery fail safe model
test battery [main=Test_BatteryFailSafe]:
  assert BatteryFailSafeSpec in
    (union BatteryFailSafe, { Test_BatteryFailSafe });

// original geo-fence model
test geofence [main=Test_GeoFence]:
  assert GeoFenceSpec in
  (union GeoFence, { Test_GeoFence });

// **************************************************
// ***** TEST NEW SPECS ON COMBINED OLD MODELS ******
// **************************************************

// ************************************
// ***** TEST FOR UPDATED MODELS ******
// ************************************

// test the updated models
test powermanager [main=Test_PowerManagement]:
  assert PowerManagementSpec in
  (union PowerManagement, BatteryFailSafeModified, GeoFenceModified, { Test_PowerManagement });

// test waypoint [main=Test_Waypoint]:
//   assert WaypointCorrect in
//   (union Waypoint, Avoid, { Test_Waypoint });

// test avoid [main=Test_Avoid]:
//   assert AvoidCorrect in
//   (union Waypoint, Avoid, { Test_Avoid });

// test global [main=Test_Global]:
//   assert GlobalCorrect in
//   (union Waypoint, Avoid, { Test_Global });