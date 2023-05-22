## BatteryFailSafe_ErrorLog1.txt
- checking BatteryFailSafe.p against 
- safety property violated: drone battery should never go below the safety threshold
- simulates the scenario where the drone exceed the battery threshold set by the feature when landed. The purpose of setting the threshold is so that the drone can have battery remaining. 

## GeoFenceSpec_ErrorLog2.txt
- this can be replicated by disabling all the checks in Monitor state in the GeoFence.p model
- The error log returned indicates that the drone requested a movement that dips below a certain altitude and violates the fence altitude parameter