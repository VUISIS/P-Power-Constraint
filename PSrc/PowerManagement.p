// Simon Chu
// purpose: 
// The PowerManagement state machine 

// reference:
// waiting for request state referred to Client-Server example in the P tutorial
// https://github.com/p-org/P/blob/master/Tutorial/1_ClientServer/PSrc/Client.p
// https://github.com/p-org/P/blob/master/Tutorial/1_ClientServer/PSrc/Server.p

// for communicating with the BatteryFailSafe state machine
type tBatteryThresholdResponse = (batteryThreshold: float);
event eBatteryThresholdResponse: tBatteryThresholdResponse;

type tBatteryThresholdRequest = (source: BatteryFailSafeModified);
event eBatteryThresholdRequest: tBatteryThresholdRequest;

type tUpdateDroneBattery = (batteryPercentage: float);
event eUpdateDroneBatteryRequest: tUpdateDroneBattery;

type tDroneMovementDistanceResponse = (droneMovementDistance: float);
event eDroneMovementDistanceResponse: tDroneMovementDistanceResponse;

type tDroneMovementDistanceRequest = (source: BatteryFailSafeModified);
event eDroneMovementDistanceRequest: tDroneMovementDistanceRequest;

// for communicating with the GeoFence state machine
type tFenceRadiusRequest = (source: GeoFenceModified);
event eFenceRadiusRequest: tFenceRadiusRequest;

type tFenceRadiusResponse = (fenceRadius: float);
event eFenceRadiusResponse: tFenceRadiusResponse;

type tUpdateDroneMovementDistanceAndPosition = (droneMovementDistance: float, droneHorizontalPosition: float, droneVerticalPosition: float);
event eUpdateDroneMovementDistanceAndPosition: tUpdateDroneMovementDistanceAndPosition;

machine PowerManagement {
  // state machines
  var batteryFailSafeMachine: BatteryFailSafeModified;
  var genFenceMachine: GeoFenceModified;

  // static parameters
  var powerConsumptionRate: float; // percentage per meter

  // cached parameters, these parameter might be delayed
  var batteryPercentage: float;
  var droneHorizontalPosition: float;  // relative to the origin
  var droneVerticalPosition: float;    // relative to the origin
  var cumulativeDroneMovementDistance: float;  // cumulative movement of the drone

  start state Init {
    entry {
      powerConsumptionRate = 1.0; // percentage per meter
      droneHorizontalPosition = 0.0;
      droneVerticalPosition = 0.0;

      goto WaitingForRequests;
    }
  }

  state WaitingForRequests {
    ////////////////////////////////////////////////
    // REQUEST FROM BatteryFailSafe STATE MACHINE //
    ////////////////////////////////////////////////

    // requests for calculating certain parameters
    // How to calculate battery threshold?
    // battery_threshold = distance_to_origin * battery_consumption_rate
    on eBatteryThresholdRequest do (request: tBatteryThresholdRequest) {
      // Problem: no square root function build in in P
      // distance_to_origin = sqrt(droneHorizontalPosition * droneHorizontalPosition + droneVerticalPosition * droneVerticalPosition);

      send request.source, eBatteryThresholdResponse, (batteryThreshold = (droneHorizontalPosition + droneVerticalPosition) * powerConsumptionRate,);
    }

    // calculate the battery percentage based on the cache
    on eUpdateDroneBatteryRequest do (request: tUpdateDroneBattery) {
      batteryPercentage = request.batteryPercentage;
    }

    // requests for calculating the drone movement
    on eDroneMovementDistanceRequest do (request: tDroneMovementDistanceRequest) {
      send request.source, eDroneMovementDistanceResponse, (droneMovementDistance = cumulativeDroneMovementDistance,);
      // reset the variable that stores drone movement distance
      cumulativeDroneMovementDistance = 0.0;
    }

    //////////////////////////////////////////////////////
    // REQUEST FROM FenceFailSafeModified STATE MACHINE //
    //////////////////////////////////////////////////////
    
    // request for calculating the fence radius
    // How to calculate the fence radius?
    // R_fence = ((current_battery / power_consumption_rate) + distance_to_origin) / 2
    on eFenceRadiusRequest do (request: tFenceRadiusRequest) {
      // TODO: change the calculation of fence radius
      var distance_to_origin: float;
      distance_to_origin = droneHorizontalPosition + droneVerticalPosition;
      send request.source, eFenceRadiusResponse, (fenceRadius = ((batteryPercentage / powerConsumptionRate) + distance_to_origin) / 2.0,);
    }

    on eUpdateDroneMovementDistanceAndPosition do (request: tUpdateDroneMovementDistanceAndPosition) {
      droneHorizontalPosition = request.droneHorizontalPosition;
      droneVerticalPosition = request.droneVerticalPosition;
      cumulativeDroneMovementDistance = cumulativeDroneMovementDistance + request.droneMovementDistance;
    }
  }


}