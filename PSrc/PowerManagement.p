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

// for communicating with the GeoFence state machine
type tFenceRadiusRequest = (source: GeoFenceModified);
event eFenceRadiusRequest: tFenceRadiusRequest;

type tFenceRadiusResponse = (fenceRadius: float);
event eFenceRadiusResponse: tFenceRadiusResponse;

type tUpdateDroneMovementAndPosition = (droneMovement: float, droneHorizontalPosition: float, droneVerticalPosition: float);
event eUpdateDroneMovementAndPosition: tUpdateDroneMovementAndPosition;

machine PowerManagement {
  // state machines
  var batteryFailSafeMachine: BatteryFailSafeModified;
  var genFenceMachine: GeoFenceModified;
  var powerConsumptionRate: float;

  // cached parameters, these parameter might be delayed
  var batteryPercentage: float;
  var droneHorizontalPosition: float;  // relative to the origin
  var droneVerticalPosition: float;    // relative to the origin
  var cumulativeDroneMovement: float;  // cumulative movement of the drone

  start state Init {
    entry {
      powerConsumptionRate = 1.0; // percentage per meter
      droneHorizontalPosition = 0.0;
      droneVerticalPosition = 0.0;
    }
  }

  state WaitingForRequests {
    ////////////////////////////////////////////////
    // REQUEST FROM BatteryFailSafe STATE MACHINE //
    ////////////////////////////////////////////////

    // requests for calculating certain parameters
    on eBatteryThresholdRequest do (request: tBatteryThresholdRequest) {
      // TODO: change the calculation of battery threshold
      send request.source, eBatteryThresholdResponse, (batteryThreshold = 0.0,);
    }

    // calculate the battery percentage based on the cache
    on eUpdateDroneBatteryRequest do (request: tUpdateDroneBattery) {
      batteryPercentage = request.batteryPercentage;
    }

    //////////////////////////////////////////////////////
    // REQUEST FROM FenceFailSafeModified STATE MACHINE //
    //////////////////////////////////////////////////////
    
    // request for calculating the fence radius
    on eFenceRadiusRequest do (request: tFenceRadiusRequest) {
      // TODO: change the calculation of fence radius
      send request.source, eFenceRadiusResponse, (fenceRadius = 0.0,);
    }

    on eUpdateDroneMovementAndPosition do (request: tUpdateDroneMovementAndPosition) {
      droneHorizontalPosition = request.droneHorizontalPosition;
      droneVerticalPosition = request.droneVerticalPosition;
      cumulativeDroneMovement = cumulativeDroneMovement + request.droneMovement;
    }
  }


}