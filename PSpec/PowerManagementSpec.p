// note that the power management spec machine is largely similar to that of the power management p model
// purpose of PowerManagement spec machine: get the important parameters that are being passed around
// like the battery threshold and the fence radius. 
// monitor the entire execution process, and check if the drone
// (1) flies out of the fence
// (2) always able to make it to the launch point with remaining battery (based on consumption rate)

// objective 1: drone is always able to RTL (throughout operation)
// battery threshold should always be able to make it to the launch point (RTL) throughout the drone operation
//
// objective 2: fence radius should always be able to RTL with remaining battery
//
//
// feature specific objectives
// objective 3: drone should not exceed fence ever during operation
//
// objective 4: if battery threshold is triggered, the drone should RTL (eventually arrive at (0,0))

spec PowerManagementSpec observes 
  eBatteryThresholdResponse, 
  eBatteryThresholdRequest, 
  eUpdateDroneBatteryRequest, 
  eDroneMovementDistanceResponse, 
  eDroneMovementDistanceRequest,
  eFenceRadiusRequest,
  eFenceRadiusResponse,
  eUpdateDroneMovementDistanceAndPosition,
  eFenceRadiusResponse {

    // parameters that the spec machine cares about
    // battery percentage and drone position

    // static parameter
    var powerConsumptionRate: float; // percentage per meter

    // cached parameters, these parameter might be delayed
    var batteryPercentage: float;
    var droneHorizontalPosition: float;  // relative to the origin
    var droneVerticalPosition: float;    // relative to the origin

    // cached drone battery threshold
    var batteryThreshold: float;
    var fenceRadius: float;

    start state Init {
      entry {
        powerConsumptionRate = 1.0; // percentage per meter
        droneHorizontalPosition = 0.0;
        droneVerticalPosition = 0.0;

        goto WaitingForRequests;
      }
    }

    // TODO: sync on response 
    state WaitingForRequests {

    // this is where the check happens for fence
    entry {
      // fence radius should always be more than the horizontal position
      assert fenceRadius >= droneHorizontalPosition, format ("[spec machine] drone exceeded fence radius, fence radius = {0}, horizonal distance to origin = {1}", fenceRadius, droneHorizontalPosition);

      // battery should always make it to the launch point with the remaining battery
      assert powerConsumptionRate * (droneHorizontalPosition + droneVerticalPosition) >= batteryPercentage, format ("[spec machine] remaining drone battery cannot make it back to the launch point, Available Range = {0}, Distance to Origin = {1}", batteryPercentage / powerConsumptionRate, droneHorizontalPosition + droneVerticalPosition);

      // battery should always be above the threshold
      assert batteryPercentage >= batteryThreshold, format ("[spec machine] battery level fall below designated threshold, current battery level = {0},  = {1}", fenceRadius, droneHorizontalPosition);
    }

    // requests for calculating certain parameters
    // How to calculate battery threshold?
    // battery_threshold = distance_to_origin * battery_consumption_rate
    on eBatteryThresholdRequest do (request: tBatteryThresholdRequest) {
      // do nothing
    }

    // calculate the battery percentage based on the cache
    on eUpdateDroneBatteryRequest do (request: tUpdateDroneBattery) {
      batteryPercentage = request.batteryPercentage;
    }

    // requests for calculating the drone movement
    on eDroneMovementDistanceRequest do (request: tDroneMovementDistanceRequest) {
      // do nothing
    }

    //////////////////////////////////////////////////////
    // REQUEST FROM FenceFailSafeModified STATE MACHINE //
    //////////////////////////////////////////////////////
    
    // request for calculating the fence radius
    // How to calculate the fence radius?
    // R_fence = ((current_battery / power_consumption_rate) + distance_to_origin) / 2
    on eFenceRadiusRequest do (request: tFenceRadiusRequest) {
      // do nothing
      // // TODO: change the calculation of fence radius
      // var distance_to_origin: float;
      // distance_to_origin = droneHorizontalPosition + droneVerticalPosition;
      // send request.source, eFenceRadiusResponse, (fenceRadius = ((batteryPercentage / powerConsumptionRate) + distance_to_origin) / 2.0,);
    }


    on eUpdateDroneMovementDistanceAndPosition do (request: tUpdateDroneMovementDistanceAndPosition) {
      droneHorizontalPosition = request.droneHorizontalPosition;
      droneVerticalPosition = request.droneVerticalPosition;
      // cumulativeDroneMovementDistance = cumulativeDroneMovementDistance + request.droneMovementDistance;


    }

    // obtain battery threshold
    on eBatteryThresholdResponse do (response: tBatteryThresholdResponse) {
      batteryThreshold = response.batteryThreshold;
    }

    on eDroneMovementDistanceResponse do (response: tDroneMovementDistanceResponse) {
      // do nothing
    }

    on eFenceRadiusResponse do (response: tFenceRadiusResponse) {
      fenceRadius = response.fenceRadius;
    }
  }
}

