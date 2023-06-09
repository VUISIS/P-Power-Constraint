using PChecker;
using PChecker.Actors;
using PChecker.Actors.Events;
using PChecker.Runtime;
using PChecker.Specifications;
using System;
using System.Runtime;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using Plang.CSharpRuntime;
using Plang.CSharpRuntime.Values;
using Plang.CSharpRuntime.Exceptions;
using System.Threading;
using System.Threading.Tasks;

#pragma warning disable 162, 219, 414, 1998
namespace PImplementation
{
}
namespace PImplementation
{
    internal partial class eStartBatteryFailSafe : PEvent
    {
        public eStartBatteryFailSafe() : base() {}
        public eStartBatteryFailSafe (PrtNamedTuple payload): base(payload){ }
        public override IPrtValue Clone() { return new eStartBatteryFailSafe();}
    }
}
namespace PImplementation
{
    internal partial class eUpdateBatteryPercentage : PEvent
    {
        public eUpdateBatteryPercentage() : base() {}
        public eUpdateBatteryPercentage (IPrtValue payload): base(payload){ }
        public override IPrtValue Clone() { return new eUpdateBatteryPercentage();}
    }
}
namespace PImplementation
{
    internal partial class eLanding : PEvent
    {
        public eLanding() : base() {}
        public eLanding (IPrtValue payload): base(payload){ }
        public override IPrtValue Clone() { return new eLanding();}
    }
}
namespace PImplementation
{
    internal partial class eLanded : PEvent
    {
        public eLanded() : base() {}
        public eLanded (IPrtValue payload): base(payload){ }
        public override IPrtValue Clone() { return new eLanded();}
    }
}
namespace PImplementation
{
    internal partial class eStartGeoFence : PEvent
    {
        public eStartGeoFence() : base() {}
        public eStartGeoFence (IPrtValue payload): base(payload){ }
        public override IPrtValue Clone() { return new eStartGeoFence();}
    }
}
namespace PImplementation
{
    internal partial class eRequestDroneMovement : PEvent
    {
        public eRequestDroneMovement() : base() {}
        public eRequestDroneMovement (IPrtValue payload): base(payload){ }
        public override IPrtValue Clone() { return new eRequestDroneMovement();}
    }
}
namespace PImplementation
{
    internal partial class eDroneMovementResponse : PEvent
    {
        public eDroneMovementResponse() : base() {}
        public eDroneMovementResponse (PrtNamedTuple payload): base(payload){ }
        public override IPrtValue Clone() { return new eDroneMovementResponse();}
    }
}
namespace PImplementation
{
    internal partial class eFenceReached : PEvent
    {
        public eFenceReached() : base() {}
        public eFenceReached (IPrtValue payload): base(payload){ }
        public override IPrtValue Clone() { return new eFenceReached();}
    }
}
namespace PImplementation
{
    internal partial class eFenceDistanced : PEvent
    {
        public eFenceDistanced() : base() {}
        public eFenceDistanced (IPrtValue payload): base(payload){ }
        public override IPrtValue Clone() { return new eFenceDistanced();}
    }
}
namespace PImplementation
{
    internal partial class eBatteryThresholdResponse : PEvent
    {
        public eBatteryThresholdResponse() : base() {}
        public eBatteryThresholdResponse (PrtNamedTuple payload): base(payload){ }
        public override IPrtValue Clone() { return new eBatteryThresholdResponse();}
    }
}
namespace PImplementation
{
    internal partial class eBatteryThresholdRequest : PEvent
    {
        public eBatteryThresholdRequest() : base() {}
        public eBatteryThresholdRequest (PrtNamedTuple payload): base(payload){ }
        public override IPrtValue Clone() { return new eBatteryThresholdRequest();}
    }
}
namespace PImplementation
{
    internal partial class eUpdateDroneBatteryRequest : PEvent
    {
        public eUpdateDroneBatteryRequest() : base() {}
        public eUpdateDroneBatteryRequest (PrtNamedTuple payload): base(payload){ }
        public override IPrtValue Clone() { return new eUpdateDroneBatteryRequest();}
    }
}
namespace PImplementation
{
    internal partial class eDroneMovementDistanceResponse : PEvent
    {
        public eDroneMovementDistanceResponse() : base() {}
        public eDroneMovementDistanceResponse (PrtNamedTuple payload): base(payload){ }
        public override IPrtValue Clone() { return new eDroneMovementDistanceResponse();}
    }
}
namespace PImplementation
{
    internal partial class eDroneMovementDistanceRequest : PEvent
    {
        public eDroneMovementDistanceRequest() : base() {}
        public eDroneMovementDistanceRequest (PrtNamedTuple payload): base(payload){ }
        public override IPrtValue Clone() { return new eDroneMovementDistanceRequest();}
    }
}
namespace PImplementation
{
    internal partial class eFenceRadiusRequest : PEvent
    {
        public eFenceRadiusRequest() : base() {}
        public eFenceRadiusRequest (PrtNamedTuple payload): base(payload){ }
        public override IPrtValue Clone() { return new eFenceRadiusRequest();}
    }
}
namespace PImplementation
{
    internal partial class eFenceRadiusResponse : PEvent
    {
        public eFenceRadiusResponse() : base() {}
        public eFenceRadiusResponse (PrtNamedTuple payload): base(payload){ }
        public override IPrtValue Clone() { return new eFenceRadiusResponse();}
    }
}
namespace PImplementation
{
    internal partial class eUpdateDroneMovementDistanceAndPosition : PEvent
    {
        public eUpdateDroneMovementDistanceAndPosition() : base() {}
        public eUpdateDroneMovementDistanceAndPosition (PrtNamedTuple payload): base(payload){ }
        public override IPrtValue Clone() { return new eUpdateDroneMovementDistanceAndPosition();}
    }
}
namespace PImplementation
{
    internal partial class eDroneMovementResponseFloat : PEvent
    {
        public eDroneMovementResponseFloat() : base() {}
        public eDroneMovementResponseFloat (PrtNamedTuple payload): base(payload){ }
        public override IPrtValue Clone() { return new eDroneMovementResponseFloat();}
    }
}
namespace PImplementation
{
    internal partial class BatteryFailSafeModified : PMachine
    {
        private PrtFloat battery_percentage = ((PrtFloat)0.0);
        private PrtFloat landing_threshold = ((PrtFloat)0.0);
        private PMachineValue powerManager = null;
        private PrtFloat powerConsumptionRate = ((PrtFloat)0.0);
        public class ConstructorEvent : PEvent{public ConstructorEvent(PMachineValue val) : base(val) { }}
        
        protected override Event GetConstructorEvent(IPrtValue value) { return new ConstructorEvent((PMachineValue)value); }
        public BatteryFailSafeModified() {
            this.sends.Add(nameof(eBatteryThresholdRequest));
            this.sends.Add(nameof(eBatteryThresholdResponse));
            this.sends.Add(nameof(eDroneMovementDistanceRequest));
            this.sends.Add(nameof(eDroneMovementDistanceResponse));
            this.sends.Add(nameof(eDroneMovementResponse));
            this.sends.Add(nameof(eDroneMovementResponseFloat));
            this.sends.Add(nameof(eFenceDistanced));
            this.sends.Add(nameof(eFenceRadiusRequest));
            this.sends.Add(nameof(eFenceRadiusResponse));
            this.sends.Add(nameof(eFenceReached));
            this.sends.Add(nameof(eLanded));
            this.sends.Add(nameof(eLanding));
            this.sends.Add(nameof(eRequestDroneMovement));
            this.sends.Add(nameof(eStartBatteryFailSafe));
            this.sends.Add(nameof(eStartGeoFence));
            this.sends.Add(nameof(eUpdateBatteryPercentage));
            this.sends.Add(nameof(eUpdateDroneBatteryRequest));
            this.sends.Add(nameof(eUpdateDroneMovementDistanceAndPosition));
            this.sends.Add(nameof(PHalt));
            this.receives.Add(nameof(eBatteryThresholdRequest));
            this.receives.Add(nameof(eBatteryThresholdResponse));
            this.receives.Add(nameof(eDroneMovementDistanceRequest));
            this.receives.Add(nameof(eDroneMovementDistanceResponse));
            this.receives.Add(nameof(eDroneMovementResponse));
            this.receives.Add(nameof(eDroneMovementResponseFloat));
            this.receives.Add(nameof(eFenceDistanced));
            this.receives.Add(nameof(eFenceRadiusRequest));
            this.receives.Add(nameof(eFenceRadiusResponse));
            this.receives.Add(nameof(eFenceReached));
            this.receives.Add(nameof(eLanded));
            this.receives.Add(nameof(eLanding));
            this.receives.Add(nameof(eRequestDroneMovement));
            this.receives.Add(nameof(eStartBatteryFailSafe));
            this.receives.Add(nameof(eStartGeoFence));
            this.receives.Add(nameof(eUpdateBatteryPercentage));
            this.receives.Add(nameof(eUpdateDroneBatteryRequest));
            this.receives.Add(nameof(eUpdateDroneMovementDistanceAndPosition));
            this.receives.Add(nameof(PHalt));
        }
        
        public void Anon(Event currentMachine_dequeuedEvent)
        {
            BatteryFailSafeModified currentMachine = this;
            PMachineValue powerManagerLocal = (PMachineValue)(gotoPayload ?? ((PEvent)currentMachine_dequeuedEvent).Payload);
            this.gotoPayload = null;
            PrtString TMP_tmp0 = ((PrtString)"");
            PMachineValue TMP_tmp1 = null;
            PEvent TMP_tmp2 = null;
            PrtFloat TMP_tmp3 = ((PrtFloat)0.0);
            PrtNamedTuple TMP_tmp4 = (new PrtNamedTuple(new string[]{"batteryPercentage"},((PrtFloat)0.0)));
            PMachineValue TMP_tmp5 = null;
            PEvent TMP_tmp6 = null;
            PMachineValue TMP_tmp7 = null;
            PrtNamedTuple TMP_tmp8 = (new PrtNamedTuple(new string[]{"source"},null));
            powerManager = (PMachineValue)(((PMachineValue)((IPrtValue)powerManagerLocal)?.Clone()));
            battery_percentage = (PrtFloat)(((PrtFloat)100));
            landing_threshold = (PrtFloat)(((PrtFloat)20));
            powerConsumptionRate = (PrtFloat)(((PrtFloat)1));
            TMP_tmp0 = (PrtString)(((PrtString) String.Format("Battery Fail Safe Enabled!")));
            PModule.runtime.Logger.WriteLine("<PrintLog> " + TMP_tmp0);
            TMP_tmp1 = (PMachineValue)(((PMachineValue)((IPrtValue)powerManager)?.Clone()));
            TMP_tmp2 = (PEvent)(new eUpdateDroneBatteryRequest((new PrtNamedTuple(new string[]{"batteryPercentage"},((PrtFloat)0.0)))));
            TMP_tmp3 = (PrtFloat)(((PrtFloat)((IPrtValue)battery_percentage)?.Clone()));
            TMP_tmp4 = (PrtNamedTuple)((new PrtNamedTuple(new string[]{"batteryPercentage"}, TMP_tmp3)));
            currentMachine.TrySendEvent(TMP_tmp1, (Event)TMP_tmp2, TMP_tmp4);
            TMP_tmp5 = (PMachineValue)(((PMachineValue)((IPrtValue)powerManager)?.Clone()));
            TMP_tmp6 = (PEvent)(new eBatteryThresholdRequest((new PrtNamedTuple(new string[]{"source"},null))));
            TMP_tmp7 = (PMachineValue)(currentMachine.self);
            TMP_tmp8 = (PrtNamedTuple)((new PrtNamedTuple(new string[]{"source"}, TMP_tmp7)));
            currentMachine.TrySendEvent(TMP_tmp5, (Event)TMP_tmp6, TMP_tmp8);
            currentMachine.TryGotoState<MonitorAndUpdate>();
            return;
        }
        public void Anon_1(Event currentMachine_dequeuedEvent)
        {
            BatteryFailSafeModified currentMachine = this;
            PrtNamedTuple response = (PrtNamedTuple)(gotoPayload ?? ((PEvent)currentMachine_dequeuedEvent).Payload);
            this.gotoPayload = null;
            PrtFloat TMP_tmp0_1 = ((PrtFloat)0.0);
            PrtFloat TMP_tmp1_1 = ((PrtFloat)0.0);
            PrtFloat TMP_tmp2_1 = ((PrtFloat)0.0);
            PrtFloat TMP_tmp3_1 = ((PrtFloat)0.0);
            PrtString TMP_tmp4_1 = ((PrtString)"");
            PrtBool TMP_tmp5_1 = ((PrtBool)false);
            PrtString TMP_tmp6_1 = ((PrtString)"");
            PMachineValue TMP_tmp7_1 = null;
            PEvent TMP_tmp8_1 = null;
            PrtString TMP_tmp9 = ((PrtString)"");
            PMachineValue TMP_tmp10 = null;
            PEvent TMP_tmp11 = null;
            PrtFloat TMP_tmp12 = ((PrtFloat)0.0);
            PrtNamedTuple TMP_tmp13 = (new PrtNamedTuple(new string[]{"batteryPercentage"},((PrtFloat)0.0)));
            PMachineValue TMP_tmp14 = null;
            PEvent TMP_tmp15 = null;
            PMachineValue TMP_tmp16 = null;
            PrtNamedTuple TMP_tmp17 = (new PrtNamedTuple(new string[]{"source"},null));
            TMP_tmp0_1 = (PrtFloat)(((PrtNamedTuple)response)["droneMovementDistance"]);
            TMP_tmp1_1 = (PrtFloat)((TMP_tmp0_1) * (powerConsumptionRate));
            TMP_tmp2_1 = (PrtFloat)((battery_percentage) - (TMP_tmp1_1));
            battery_percentage = TMP_tmp2_1;
            TMP_tmp3_1 = (PrtFloat)(((PrtFloat)((IPrtValue)battery_percentage)?.Clone()));
            TMP_tmp4_1 = (PrtString)(((PrtString) String.Format("battery updated, battery = {0}",TMP_tmp3_1)));
            PModule.runtime.Logger.WriteLine("<PrintLog> " + TMP_tmp4_1);
            TMP_tmp5_1 = (PrtBool)((battery_percentage) < (landing_threshold));
            if (TMP_tmp5_1)
            {
                TMP_tmp6_1 = (PrtString)(((PrtString) String.Format("battery below threshold, landing initiated!")));
                PModule.runtime.Logger.WriteLine("<PrintLog> " + TMP_tmp6_1);
                TMP_tmp7_1 = (PMachineValue)(currentMachine.self);
                TMP_tmp8_1 = (PEvent)(new eLanding(null));
                currentMachine.TrySendEvent(TMP_tmp7_1, (Event)TMP_tmp8_1);
                currentMachine.TryGotoState<Landing>();
                return;
            }
            else
            {
                TMP_tmp9 = (PrtString)(((PrtString) String.Format("battery above threshold, continue monitoring!")));
                PModule.runtime.Logger.WriteLine("<PrintLog> " + TMP_tmp9);
            }
            TMP_tmp10 = (PMachineValue)(((PMachineValue)((IPrtValue)powerManager)?.Clone()));
            TMP_tmp11 = (PEvent)(new eUpdateDroneBatteryRequest((new PrtNamedTuple(new string[]{"batteryPercentage"},((PrtFloat)0.0)))));
            TMP_tmp12 = (PrtFloat)(((PrtFloat)((IPrtValue)battery_percentage)?.Clone()));
            TMP_tmp13 = (PrtNamedTuple)((new PrtNamedTuple(new string[]{"batteryPercentage"}, TMP_tmp12)));
            currentMachine.TrySendEvent(TMP_tmp10, (Event)TMP_tmp11, TMP_tmp13);
            TMP_tmp14 = (PMachineValue)(((PMachineValue)((IPrtValue)powerManager)?.Clone()));
            TMP_tmp15 = (PEvent)(new eBatteryThresholdRequest((new PrtNamedTuple(new string[]{"source"},null))));
            TMP_tmp16 = (PMachineValue)(currentMachine.self);
            TMP_tmp17 = (PrtNamedTuple)((new PrtNamedTuple(new string[]{"source"}, TMP_tmp16)));
            currentMachine.TrySendEvent(TMP_tmp14, (Event)TMP_tmp15, TMP_tmp17);
        }
        public void Anon_2(Event currentMachine_dequeuedEvent)
        {
            BatteryFailSafeModified currentMachine = this;
            PrtNamedTuple response_1 = (PrtNamedTuple)(gotoPayload ?? ((PEvent)currentMachine_dequeuedEvent).Payload);
            this.gotoPayload = null;
            PrtFloat TMP_tmp0_2 = ((PrtFloat)0.0);
            PrtFloat TMP_tmp1_2 = ((PrtFloat)0.0);
            PrtFloat TMP_tmp2_2 = ((PrtFloat)0.0);
            PrtString TMP_tmp3_2 = ((PrtString)"");
            PMachineValue TMP_tmp4_2 = null;
            PEvent TMP_tmp5_2 = null;
            PMachineValue TMP_tmp6_2 = null;
            PrtNamedTuple TMP_tmp7_2 = (new PrtNamedTuple(new string[]{"source"},null));
            TMP_tmp0_2 = (PrtFloat)(((PrtNamedTuple)response_1)["batteryThreshold"]);
            TMP_tmp1_2 = (PrtFloat)(((PrtFloat)((IPrtValue)TMP_tmp0_2)?.Clone()));
            landing_threshold = TMP_tmp1_2;
            TMP_tmp2_2 = (PrtFloat)(((PrtFloat)((IPrtValue)landing_threshold)?.Clone()));
            TMP_tmp3_2 = (PrtString)(((PrtString) String.Format("battery threshold updated, threshold = {0}",TMP_tmp2_2)));
            PModule.runtime.Logger.WriteLine("<PrintLog> " + TMP_tmp3_2);
            TMP_tmp4_2 = (PMachineValue)(((PMachineValue)((IPrtValue)powerManager)?.Clone()));
            TMP_tmp5_2 = (PEvent)(new eDroneMovementDistanceRequest((new PrtNamedTuple(new string[]{"source"},null))));
            TMP_tmp6_2 = (PMachineValue)(currentMachine.self);
            TMP_tmp7_2 = (PrtNamedTuple)((new PrtNamedTuple(new string[]{"source"}, TMP_tmp6_2)));
            currentMachine.TrySendEvent(TMP_tmp4_2, (Event)TMP_tmp5_2, TMP_tmp7_2);
        }
        public void Anon_3(Event currentMachine_dequeuedEvent)
        {
            BatteryFailSafeModified currentMachine = this;
            PrtString TMP_tmp0_3 = ((PrtString)"");
            PMachineValue TMP_tmp1_3 = null;
            PEvent TMP_tmp2_3 = null;
            TMP_tmp0_3 = (PrtString)(((PrtString) String.Format("Landing initiated!")));
            PModule.runtime.Logger.WriteLine("<PrintLog> " + TMP_tmp0_3);
            TMP_tmp1_3 = (PMachineValue)(currentMachine.self);
            TMP_tmp2_3 = (PEvent)(new eLanded(null));
            currentMachine.TrySendEvent(TMP_tmp1_3, (Event)TMP_tmp2_3);
            currentMachine.TryGotoState<Landed>();
            return;
        }
        public void Anon_4(Event currentMachine_dequeuedEvent)
        {
            BatteryFailSafeModified currentMachine = this;
            PrtString TMP_tmp0_4 = ((PrtString)"");
            TMP_tmp0_4 = (PrtString)(((PrtString) String.Format("Landed!")));
            PModule.runtime.Logger.WriteLine("<PrintLog> " + TMP_tmp0_4);
        }
        [Start]
        [OnEntry(nameof(InitializeParametersFunction))]
        [OnEventGotoState(typeof(ConstructorEvent), typeof(Init))]
        class __InitState__ : State { }
        
        [OnEntry(nameof(Anon))]
        class Init : State
        {
        }
        [OnEventDoAction(typeof(eDroneMovementDistanceResponse), nameof(Anon_1))]
        [OnEventDoAction(typeof(eBatteryThresholdResponse), nameof(Anon_2))]
        class MonitorAndUpdate : State
        {
        }
        [OnEventDoAction(typeof(eLanding), nameof(Anon_3))]
        class Landing : State
        {
        }
        [OnEventDoAction(typeof(eLanded), nameof(Anon_4))]
        class Landed : State
        {
        }
    }
}
namespace PImplementation
{
    internal partial class BatteryFailSafe : PMachine
    {
        private PrtInt battery_percentage_1 = ((PrtInt)0);
        private PrtInt landing_threshold_1 = ((PrtInt)0);
        public class ConstructorEvent : PEvent{public ConstructorEvent(PrtInt val) : base(val) { }}
        
        protected override Event GetConstructorEvent(IPrtValue value) { return new ConstructorEvent((PrtInt)value); }
        public BatteryFailSafe() {
            this.sends.Add(nameof(eBatteryThresholdRequest));
            this.sends.Add(nameof(eBatteryThresholdResponse));
            this.sends.Add(nameof(eDroneMovementDistanceRequest));
            this.sends.Add(nameof(eDroneMovementDistanceResponse));
            this.sends.Add(nameof(eDroneMovementResponse));
            this.sends.Add(nameof(eDroneMovementResponseFloat));
            this.sends.Add(nameof(eFenceDistanced));
            this.sends.Add(nameof(eFenceRadiusRequest));
            this.sends.Add(nameof(eFenceRadiusResponse));
            this.sends.Add(nameof(eFenceReached));
            this.sends.Add(nameof(eLanded));
            this.sends.Add(nameof(eLanding));
            this.sends.Add(nameof(eRequestDroneMovement));
            this.sends.Add(nameof(eStartBatteryFailSafe));
            this.sends.Add(nameof(eStartGeoFence));
            this.sends.Add(nameof(eUpdateBatteryPercentage));
            this.sends.Add(nameof(eUpdateDroneBatteryRequest));
            this.sends.Add(nameof(eUpdateDroneMovementDistanceAndPosition));
            this.sends.Add(nameof(PHalt));
            this.receives.Add(nameof(eBatteryThresholdRequest));
            this.receives.Add(nameof(eBatteryThresholdResponse));
            this.receives.Add(nameof(eDroneMovementDistanceRequest));
            this.receives.Add(nameof(eDroneMovementDistanceResponse));
            this.receives.Add(nameof(eDroneMovementResponse));
            this.receives.Add(nameof(eDroneMovementResponseFloat));
            this.receives.Add(nameof(eFenceDistanced));
            this.receives.Add(nameof(eFenceRadiusRequest));
            this.receives.Add(nameof(eFenceRadiusResponse));
            this.receives.Add(nameof(eFenceReached));
            this.receives.Add(nameof(eLanded));
            this.receives.Add(nameof(eLanding));
            this.receives.Add(nameof(eRequestDroneMovement));
            this.receives.Add(nameof(eStartBatteryFailSafe));
            this.receives.Add(nameof(eStartGeoFence));
            this.receives.Add(nameof(eUpdateBatteryPercentage));
            this.receives.Add(nameof(eUpdateDroneBatteryRequest));
            this.receives.Add(nameof(eUpdateDroneMovementDistanceAndPosition));
            this.receives.Add(nameof(PHalt));
        }
        
        public void Anon_5(Event currentMachine_dequeuedEvent)
        {
            BatteryFailSafe currentMachine = this;
            PrtInt landing_threshold_local = (PrtInt)(gotoPayload ?? ((PEvent)currentMachine_dequeuedEvent).Payload);
            this.gotoPayload = null;
            PrtString TMP_tmp0_5 = ((PrtString)"");
            PMachineValue TMP_tmp1_4 = null;
            PEvent TMP_tmp2_4 = null;
            PrtInt TMP_tmp3_3 = ((PrtInt)0);
            PrtNamedTuple TMP_tmp4_3 = (new PrtNamedTuple(new string[]{"landing_threshold_amount"},((PrtInt)0)));
            battery_percentage_1 = (PrtInt)(((PrtInt)100));
            landing_threshold_1 = (PrtInt)(((PrtInt)((IPrtValue)landing_threshold_local)?.Clone()));
            TMP_tmp0_5 = (PrtString)(((PrtString) String.Format("Battery Fail Safe Enabled!")));
            PModule.runtime.Logger.WriteLine("<PrintLog> " + TMP_tmp0_5);
            TMP_tmp1_4 = (PMachineValue)(currentMachine.self);
            TMP_tmp2_4 = (PEvent)(new eStartBatteryFailSafe((new PrtNamedTuple(new string[]{"landing_threshold_amount"},((PrtInt)0)))));
            TMP_tmp3_3 = (PrtInt)(((PrtInt)((IPrtValue)landing_threshold_local)?.Clone()));
            TMP_tmp4_3 = (PrtNamedTuple)((new PrtNamedTuple(new string[]{"landing_threshold_amount"}, TMP_tmp3_3)));
            currentMachine.TrySendEvent(TMP_tmp1_4, (Event)TMP_tmp2_4, TMP_tmp4_3);
            currentMachine.TryGotoState<Monitoring>();
            return;
        }
        public void Anon_6(Event currentMachine_dequeuedEvent)
        {
            BatteryFailSafe currentMachine = this;
            PrtInt TMP_tmp0_6 = ((PrtInt)0);
            PrtInt TMP_tmp1_5 = ((PrtInt)0);
            PrtString TMP_tmp2_5 = ((PrtString)"");
            PrtBool TMP_tmp3_4 = ((PrtBool)false);
            PrtString TMP_tmp4_4 = ((PrtString)"");
            PMachineValue TMP_tmp5_3 = null;
            PEvent TMP_tmp6_3 = null;
            PrtString TMP_tmp7_3 = ((PrtString)"");
            PMachineValue TMP_tmp8_2 = null;
            PEvent TMP_tmp9_1 = null;
            TMP_tmp0_6 = (PrtInt)((battery_percentage_1) - (((PrtInt)1)));
            battery_percentage_1 = TMP_tmp0_6;
            TMP_tmp1_5 = (PrtInt)(((PrtInt)((IPrtValue)battery_percentage_1)?.Clone()));
            TMP_tmp2_5 = (PrtString)(((PrtString) String.Format("battery updated, battery = {0}",TMP_tmp1_5)));
            PModule.runtime.Logger.WriteLine("<PrintLog> " + TMP_tmp2_5);
            TMP_tmp3_4 = (PrtBool)((battery_percentage_1) < (landing_threshold_1));
            if (TMP_tmp3_4)
            {
                TMP_tmp4_4 = (PrtString)(((PrtString) String.Format("battery below threshold, landing initiated!")));
                PModule.runtime.Logger.WriteLine("<PrintLog> " + TMP_tmp4_4);
                TMP_tmp5_3 = (PMachineValue)(currentMachine.self);
                TMP_tmp6_3 = (PEvent)(new eLanding(null));
                currentMachine.TrySendEvent(TMP_tmp5_3, (Event)TMP_tmp6_3);
                currentMachine.TryGotoState<Landing_1>();
                return;
            }
            else
            {
                TMP_tmp7_3 = (PrtString)(((PrtString) String.Format("battery above threshold, continue monitoring!")));
                PModule.runtime.Logger.WriteLine("<PrintLog> " + TMP_tmp7_3);
                TMP_tmp8_2 = (PMachineValue)(currentMachine.self);
                TMP_tmp9_1 = (PEvent)(new eUpdateBatteryPercentage(null));
                currentMachine.TrySendEvent(TMP_tmp8_2, (Event)TMP_tmp9_1);
                currentMachine.TryGotoState<Monitoring>();
                return;
            }
        }
        public void Anon_7(Event currentMachine_dequeuedEvent)
        {
            BatteryFailSafe currentMachine = this;
            PrtString TMP_tmp0_7 = ((PrtString)"");
            PMachineValue TMP_tmp1_6 = null;
            PEvent TMP_tmp2_6 = null;
            TMP_tmp0_7 = (PrtString)(((PrtString) String.Format("Landing initiated!")));
            PModule.runtime.Logger.WriteLine("<PrintLog> " + TMP_tmp0_7);
            TMP_tmp1_6 = (PMachineValue)(currentMachine.self);
            TMP_tmp2_6 = (PEvent)(new eLanded(null));
            currentMachine.TrySendEvent(TMP_tmp1_6, (Event)TMP_tmp2_6);
            currentMachine.TryGotoState<Landed_1>();
            return;
        }
        public void Anon_8(Event currentMachine_dequeuedEvent)
        {
            BatteryFailSafe currentMachine = this;
            PrtString TMP_tmp0_8 = ((PrtString)"");
            TMP_tmp0_8 = (PrtString)(((PrtString) String.Format("Landed!")));
            PModule.runtime.Logger.WriteLine("<PrintLog> " + TMP_tmp0_8);
        }
        [Start]
        [OnEntry(nameof(InitializeParametersFunction))]
        [OnEventGotoState(typeof(ConstructorEvent), typeof(Init_1))]
        class __InitState__ : State { }
        
        [OnEntry(nameof(Anon_5))]
        class Init_1 : State
        {
        }
        [OnEventDoAction(typeof(eStartBatteryFailSafe), nameof(Anon_6))]
        [OnEventDoAction(typeof(eUpdateBatteryPercentage), nameof(Anon_6))]
        class Monitoring : State
        {
        }
        [OnEventDoAction(typeof(eLanding), nameof(Anon_7))]
        class Landing_1 : State
        {
        }
        [OnEventDoAction(typeof(eLanded), nameof(Anon_8))]
        class Landed_1 : State
        {
        }
    }
}
namespace PImplementation
{
    internal partial class GeoFence : PMachine
    {
        private PrtInt fence_alt_min = ((PrtInt)0);
        private PrtInt fence_alt_max = ((PrtInt)0);
        private PrtInt fence_radius = ((PrtInt)0);
        private PrtInt drone_horizontal_distance_to_origin = ((PrtInt)0);
        private PrtInt drone_altitude = ((PrtInt)0);
        public class ConstructorEvent : PEvent{public ConstructorEvent(IPrtValue val) : base(val) { }}
        
        protected override Event GetConstructorEvent(IPrtValue value) { return new ConstructorEvent((IPrtValue)value); }
        public GeoFence() {
            this.sends.Add(nameof(eBatteryThresholdRequest));
            this.sends.Add(nameof(eBatteryThresholdResponse));
            this.sends.Add(nameof(eDroneMovementDistanceRequest));
            this.sends.Add(nameof(eDroneMovementDistanceResponse));
            this.sends.Add(nameof(eDroneMovementResponse));
            this.sends.Add(nameof(eDroneMovementResponseFloat));
            this.sends.Add(nameof(eFenceDistanced));
            this.sends.Add(nameof(eFenceRadiusRequest));
            this.sends.Add(nameof(eFenceRadiusResponse));
            this.sends.Add(nameof(eFenceReached));
            this.sends.Add(nameof(eLanded));
            this.sends.Add(nameof(eLanding));
            this.sends.Add(nameof(eRequestDroneMovement));
            this.sends.Add(nameof(eStartBatteryFailSafe));
            this.sends.Add(nameof(eStartGeoFence));
            this.sends.Add(nameof(eUpdateBatteryPercentage));
            this.sends.Add(nameof(eUpdateDroneBatteryRequest));
            this.sends.Add(nameof(eUpdateDroneMovementDistanceAndPosition));
            this.sends.Add(nameof(PHalt));
            this.receives.Add(nameof(eBatteryThresholdRequest));
            this.receives.Add(nameof(eBatteryThresholdResponse));
            this.receives.Add(nameof(eDroneMovementDistanceRequest));
            this.receives.Add(nameof(eDroneMovementDistanceResponse));
            this.receives.Add(nameof(eDroneMovementResponse));
            this.receives.Add(nameof(eDroneMovementResponseFloat));
            this.receives.Add(nameof(eFenceDistanced));
            this.receives.Add(nameof(eFenceRadiusRequest));
            this.receives.Add(nameof(eFenceRadiusResponse));
            this.receives.Add(nameof(eFenceReached));
            this.receives.Add(nameof(eLanded));
            this.receives.Add(nameof(eLanding));
            this.receives.Add(nameof(eRequestDroneMovement));
            this.receives.Add(nameof(eStartBatteryFailSafe));
            this.receives.Add(nameof(eStartGeoFence));
            this.receives.Add(nameof(eUpdateBatteryPercentage));
            this.receives.Add(nameof(eUpdateDroneBatteryRequest));
            this.receives.Add(nameof(eUpdateDroneMovementDistanceAndPosition));
            this.receives.Add(nameof(PHalt));
        }
        
        public void Anon_9(Event currentMachine_dequeuedEvent)
        {
            GeoFence currentMachine = this;
            PrtString TMP_tmp0_9 = ((PrtString)"");
            PMachineValue TMP_tmp1_7 = null;
            PEvent TMP_tmp2_7 = null;
            fence_alt_min = (PrtInt)(((PrtInt)0));
            fence_alt_max = (PrtInt)(((PrtInt)100));
            fence_radius = (PrtInt)(((PrtInt)100));
            drone_horizontal_distance_to_origin = (PrtInt)(((PrtInt)0));
            drone_altitude = (PrtInt)(((PrtInt)0));
            TMP_tmp0_9 = (PrtString)(((PrtString) String.Format("Geo Fence Enabled!")));
            PModule.runtime.Logger.WriteLine("<PrintLog> " + TMP_tmp0_9);
            TMP_tmp1_7 = (PMachineValue)(currentMachine.self);
            TMP_tmp2_7 = (PEvent)(new eStartGeoFence(null));
            currentMachine.TrySendEvent(TMP_tmp1_7, (Event)TMP_tmp2_7);
            currentMachine.TryGotoState<Monitoring_1>();
            return;
        }
        public void Anon_10(Event currentMachine_dequeuedEvent)
        {
            GeoFence currentMachine = this;
            PMachineValue TMP_tmp0_10 = null;
            PEvent TMP_tmp1_8 = null;
            TMP_tmp0_10 = (PMachineValue)(currentMachine.self);
            TMP_tmp1_8 = (PEvent)(new eRequestDroneMovement(null));
            currentMachine.TrySendEvent(TMP_tmp0_10, (Event)TMP_tmp1_8);
            currentMachine.TryGotoState<GenerateMovement>();
            return;
        }
        public void Anon_11(Event currentMachine_dequeuedEvent)
        {
            GeoFence currentMachine = this;
            PrtNamedTuple response_2 = (PrtNamedTuple)(gotoPayload ?? ((PEvent)currentMachine_dequeuedEvent).Payload);
            this.gotoPayload = null;
            PrtInt TMP_tmp0_11 = ((PrtInt)0);
            PrtInt TMP_tmp1_9 = ((PrtInt)0);
            PrtBool TMP_tmp2_8 = ((PrtBool)false);
            PMachineValue TMP_tmp3_5 = null;
            PEvent TMP_tmp4_5 = null;
            PrtInt TMP_tmp5_4 = ((PrtInt)0);
            PrtInt TMP_tmp6_4 = ((PrtInt)0);
            PrtBool TMP_tmp7_4 = ((PrtBool)false);
            PrtInt TMP_tmp8_3 = ((PrtInt)0);
            PrtInt TMP_tmp9_2 = ((PrtInt)0);
            PrtBool TMP_tmp10_1 = ((PrtBool)false);
            PrtInt TMP_tmp11_1 = ((PrtInt)0);
            PrtInt TMP_tmp12_1 = ((PrtInt)0);
            PrtBool TMP_tmp13_1 = ((PrtBool)false);
            PrtBool TMP_tmp14_1 = ((PrtBool)false);
            PMachineValue TMP_tmp15_1 = null;
            PEvent TMP_tmp16_1 = null;
            PrtInt TMP_tmp17_1 = ((PrtInt)0);
            PrtInt TMP_tmp18 = ((PrtInt)0);
            PrtInt TMP_tmp19 = ((PrtInt)0);
            PrtInt TMP_tmp20 = ((PrtInt)0);
            PMachineValue TMP_tmp21 = null;
            PEvent TMP_tmp22 = null;
            TMP_tmp0_11 = (PrtInt)(((PrtNamedTuple)response_2)["horizontal_movement"]);
            TMP_tmp1_9 = (PrtInt)((drone_horizontal_distance_to_origin) + (TMP_tmp0_11));
            TMP_tmp2_8 = (PrtBool)((TMP_tmp1_9) > (fence_radius));
            if (TMP_tmp2_8)
            {
                TMP_tmp3_5 = (PMachineValue)(currentMachine.self);
                TMP_tmp4_5 = (PEvent)(new eFenceReached(null));
                currentMachine.TrySendEvent(TMP_tmp3_5, (Event)TMP_tmp4_5);
                currentMachine.TryGotoState<Holding>();
                return;
            }
            else
            {
                TMP_tmp5_4 = (PrtInt)(((PrtNamedTuple)response_2)["horizontal_movement"]);
                TMP_tmp6_4 = (PrtInt)((drone_horizontal_distance_to_origin) + (TMP_tmp5_4));
                TMP_tmp7_4 = (PrtBool)((TMP_tmp6_4) < (((PrtInt)0)));
                if (TMP_tmp7_4)
                {
                }
                else
                {
                    TMP_tmp8_3 = (PrtInt)(((PrtNamedTuple)response_2)["vertical_movement"]);
                    TMP_tmp9_2 = (PrtInt)((drone_altitude) + (TMP_tmp8_3));
                    TMP_tmp10_1 = (PrtBool)((TMP_tmp9_2) < (fence_alt_min));
                    TMP_tmp14_1 = (PrtBool)(((PrtBool)((IPrtValue)TMP_tmp10_1)?.Clone()));
                    if (TMP_tmp14_1)
                    {
                    }
                    else
                    {
                        TMP_tmp11_1 = (PrtInt)(((PrtNamedTuple)response_2)["vertical_movement"]);
                        TMP_tmp12_1 = (PrtInt)((drone_altitude) + (TMP_tmp11_1));
                        TMP_tmp13_1 = (PrtBool)((TMP_tmp12_1) > (fence_alt_max));
                        TMP_tmp14_1 = (PrtBool)(((PrtBool)((IPrtValue)TMP_tmp13_1)?.Clone()));
                    }
                    if (TMP_tmp14_1)
                    {
                        TMP_tmp15_1 = (PMachineValue)(currentMachine.self);
                        TMP_tmp16_1 = (PEvent)(new eFenceReached(null));
                        currentMachine.TrySendEvent(TMP_tmp15_1, (Event)TMP_tmp16_1);
                        currentMachine.TryGotoState<Holding>();
                        return;
                    }
                    else
                    {
                        TMP_tmp17_1 = (PrtInt)(((PrtNamedTuple)response_2)["vertical_movement"]);
                        TMP_tmp18 = (PrtInt)((drone_altitude) + (TMP_tmp17_1));
                        drone_altitude = TMP_tmp18;
                        TMP_tmp19 = (PrtInt)(((PrtNamedTuple)response_2)["horizontal_movement"]);
                        TMP_tmp20 = (PrtInt)((drone_horizontal_distance_to_origin) + (TMP_tmp19));
                        drone_horizontal_distance_to_origin = TMP_tmp20;
                        TMP_tmp21 = (PMachineValue)(currentMachine.self);
                        TMP_tmp22 = (PEvent)(new eRequestDroneMovement(null));
                        currentMachine.TrySendEvent(TMP_tmp21, (Event)TMP_tmp22);
                        currentMachine.TryGotoState<GenerateMovement>();
                        return;
                    }
                }
            }
        }
        public void Anon_12(Event currentMachine_dequeuedEvent)
        {
            GeoFence currentMachine = this;
            PrtString TMP_tmp0_12 = ((PrtString)"");
            PMachineValue TMP_tmp1_10 = null;
            PEvent TMP_tmp2_9 = null;
            TMP_tmp0_12 = (PrtString)(((PrtString) String.Format("Fence Reached! Starting Holding Pattern")));
            PModule.runtime.Logger.WriteLine("<PrintLog> " + TMP_tmp0_12);
            TMP_tmp1_10 = (PMachineValue)(currentMachine.self);
            TMP_tmp2_9 = (PEvent)(new eFenceDistanced(null));
            currentMachine.TrySendEvent(TMP_tmp1_10, (Event)TMP_tmp2_9);
            currentMachine.TryGotoState<Monitoring_1>();
            return;
        }
        public void Anon_13(Event currentMachine_dequeuedEvent)
        {
            GeoFence currentMachine = this;
            PrtNamedTuple response_3 = (new PrtNamedTuple(new string[]{"horizontal_movement","vertical_movement"},((PrtInt)0), ((PrtInt)0)));
            PrtInt TMP_tmp0_13 = ((PrtInt)0);
            PrtInt TMP_tmp1_11 = ((PrtInt)0);
            PrtInt TMP_tmp2_10 = ((PrtInt)0);
            PrtInt TMP_tmp3_6 = ((PrtInt)0);
            PrtInt TMP_tmp4_6 = ((PrtInt)0);
            PrtInt TMP_tmp5_5 = ((PrtInt)0);
            PrtString TMP_tmp6_5 = ((PrtString)"");
            PMachineValue TMP_tmp7_5 = null;
            PEvent TMP_tmp8_4 = null;
            PrtNamedTuple TMP_tmp9_3 = (new PrtNamedTuple(new string[]{"horizontal_movement","vertical_movement"},((PrtInt)0), ((PrtInt)0)));
            TMP_tmp0_13 = (PrtInt)(((PrtInt)currentMachine.TryRandom(((PrtInt)20))));
            TMP_tmp1_11 = (PrtInt)((TMP_tmp0_13) - (((PrtInt)10)));
            ((PrtNamedTuple)response_3)["horizontal_movement"] = TMP_tmp1_11;
            TMP_tmp2_10 = (PrtInt)(((PrtInt)currentMachine.TryRandom(((PrtInt)20))));
            TMP_tmp3_6 = (PrtInt)((TMP_tmp2_10) - (((PrtInt)10)));
            ((PrtNamedTuple)response_3)["vertical_movement"] = TMP_tmp3_6;
            TMP_tmp4_6 = (PrtInt)(((PrtNamedTuple)response_3)["horizontal_movement"]);
            TMP_tmp5_5 = (PrtInt)(((PrtNamedTuple)response_3)["vertical_movement"]);
            TMP_tmp6_5 = (PrtString)(((PrtString) String.Format("Movement Generated, horizontal movement = {0}, vertical movement = {1}",TMP_tmp4_6,TMP_tmp5_5)));
            PModule.runtime.Logger.WriteLine("<PrintLog> " + TMP_tmp6_5);
            TMP_tmp7_5 = (PMachineValue)(currentMachine.self);
            TMP_tmp8_4 = (PEvent)(new eDroneMovementResponse((new PrtNamedTuple(new string[]{"horizontal_movement","vertical_movement"},((PrtInt)0), ((PrtInt)0)))));
            TMP_tmp9_3 = (PrtNamedTuple)(((PrtNamedTuple)((IPrtValue)response_3)?.Clone()));
            currentMachine.TrySendEvent(TMP_tmp7_5, (Event)TMP_tmp8_4, TMP_tmp9_3);
            currentMachine.TryGotoState<Monitoring_1>();
            return;
        }
        [Start]
        [OnEntry(nameof(InitializeParametersFunction))]
        [OnEventGotoState(typeof(ConstructorEvent), typeof(Init_2))]
        class __InitState__ : State { }
        
        [OnEntry(nameof(Anon_9))]
        class Init_2 : State
        {
        }
        [OnEventDoAction(typeof(eStartGeoFence), nameof(Anon_10))]
        [OnEventDoAction(typeof(eFenceDistanced), nameof(Anon_10))]
        [OnEventDoAction(typeof(eDroneMovementResponse), nameof(Anon_11))]
        class Monitoring_1 : State
        {
        }
        [OnEventDoAction(typeof(eFenceReached), nameof(Anon_12))]
        class Holding : State
        {
        }
        [OnEventDoAction(typeof(eRequestDroneMovement), nameof(Anon_13))]
        class GenerateMovement : State
        {
        }
    }
}
namespace PImplementation
{
    internal partial class PowerManagement : PMachine
    {
        private PMachineValue batteryFailSafeMachine = null;
        private PMachineValue genFenceMachine = null;
        private PrtFloat powerConsumptionRate_1 = ((PrtFloat)0.0);
        private PrtFloat batteryPercentage = ((PrtFloat)0.0);
        private PrtFloat droneHorizontalPosition = ((PrtFloat)0.0);
        private PrtFloat droneVerticalPosition = ((PrtFloat)0.0);
        private PrtFloat cumulativeDroneMovementDistance = ((PrtFloat)0.0);
        public class ConstructorEvent : PEvent{public ConstructorEvent(IPrtValue val) : base(val) { }}
        
        protected override Event GetConstructorEvent(IPrtValue value) { return new ConstructorEvent((IPrtValue)value); }
        public PowerManagement() {
            this.sends.Add(nameof(eBatteryThresholdRequest));
            this.sends.Add(nameof(eBatteryThresholdResponse));
            this.sends.Add(nameof(eDroneMovementDistanceRequest));
            this.sends.Add(nameof(eDroneMovementDistanceResponse));
            this.sends.Add(nameof(eDroneMovementResponse));
            this.sends.Add(nameof(eDroneMovementResponseFloat));
            this.sends.Add(nameof(eFenceDistanced));
            this.sends.Add(nameof(eFenceRadiusRequest));
            this.sends.Add(nameof(eFenceRadiusResponse));
            this.sends.Add(nameof(eFenceReached));
            this.sends.Add(nameof(eLanded));
            this.sends.Add(nameof(eLanding));
            this.sends.Add(nameof(eRequestDroneMovement));
            this.sends.Add(nameof(eStartBatteryFailSafe));
            this.sends.Add(nameof(eStartGeoFence));
            this.sends.Add(nameof(eUpdateBatteryPercentage));
            this.sends.Add(nameof(eUpdateDroneBatteryRequest));
            this.sends.Add(nameof(eUpdateDroneMovementDistanceAndPosition));
            this.sends.Add(nameof(PHalt));
            this.receives.Add(nameof(eBatteryThresholdRequest));
            this.receives.Add(nameof(eBatteryThresholdResponse));
            this.receives.Add(nameof(eDroneMovementDistanceRequest));
            this.receives.Add(nameof(eDroneMovementDistanceResponse));
            this.receives.Add(nameof(eDroneMovementResponse));
            this.receives.Add(nameof(eDroneMovementResponseFloat));
            this.receives.Add(nameof(eFenceDistanced));
            this.receives.Add(nameof(eFenceRadiusRequest));
            this.receives.Add(nameof(eFenceRadiusResponse));
            this.receives.Add(nameof(eFenceReached));
            this.receives.Add(nameof(eLanded));
            this.receives.Add(nameof(eLanding));
            this.receives.Add(nameof(eRequestDroneMovement));
            this.receives.Add(nameof(eStartBatteryFailSafe));
            this.receives.Add(nameof(eStartGeoFence));
            this.receives.Add(nameof(eUpdateBatteryPercentage));
            this.receives.Add(nameof(eUpdateDroneBatteryRequest));
            this.receives.Add(nameof(eUpdateDroneMovementDistanceAndPosition));
            this.receives.Add(nameof(PHalt));
        }
        
        public void Anon_14(Event currentMachine_dequeuedEvent)
        {
            PowerManagement currentMachine = this;
            powerConsumptionRate_1 = (PrtFloat)(((PrtFloat)1));
            droneHorizontalPosition = (PrtFloat)(((PrtFloat)0));
            droneVerticalPosition = (PrtFloat)(((PrtFloat)0));
            currentMachine.TryGotoState<WaitingForRequests>();
            return;
        }
        public void Anon_15(Event currentMachine_dequeuedEvent)
        {
            PowerManagement currentMachine = this;
            PrtNamedTuple request = (PrtNamedTuple)(gotoPayload ?? ((PEvent)currentMachine_dequeuedEvent).Payload);
            this.gotoPayload = null;
            PMachineValue TMP_tmp0_14 = null;
            PMachineValue TMP_tmp1_12 = null;
            PEvent TMP_tmp2_11 = null;
            PrtFloat TMP_tmp3_7 = ((PrtFloat)0.0);
            PrtFloat TMP_tmp4_7 = ((PrtFloat)0.0);
            PrtNamedTuple TMP_tmp5_6 = (new PrtNamedTuple(new string[]{"batteryThreshold"},((PrtFloat)0.0)));
            TMP_tmp0_14 = (PMachineValue)(((PrtNamedTuple)request)["source"]);
            TMP_tmp1_12 = (PMachineValue)(((PMachineValue)((IPrtValue)TMP_tmp0_14)?.Clone()));
            TMP_tmp2_11 = (PEvent)(new eBatteryThresholdResponse((new PrtNamedTuple(new string[]{"batteryThreshold"},((PrtFloat)0.0)))));
            TMP_tmp3_7 = (PrtFloat)((droneHorizontalPosition) + (droneVerticalPosition));
            TMP_tmp4_7 = (PrtFloat)((TMP_tmp3_7) * (powerConsumptionRate_1));
            TMP_tmp5_6 = (PrtNamedTuple)((new PrtNamedTuple(new string[]{"batteryThreshold"}, TMP_tmp4_7)));
            currentMachine.TrySendEvent(TMP_tmp1_12, (Event)TMP_tmp2_11, TMP_tmp5_6);
        }
        public void Anon_16(Event currentMachine_dequeuedEvent)
        {
            PowerManagement currentMachine = this;
            PrtNamedTuple request_1 = (PrtNamedTuple)(gotoPayload ?? ((PEvent)currentMachine_dequeuedEvent).Payload);
            this.gotoPayload = null;
            PrtFloat TMP_tmp0_15 = ((PrtFloat)0.0);
            PrtFloat TMP_tmp1_13 = ((PrtFloat)0.0);
            TMP_tmp0_15 = (PrtFloat)(((PrtNamedTuple)request_1)["batteryPercentage"]);
            TMP_tmp1_13 = (PrtFloat)(((PrtFloat)((IPrtValue)TMP_tmp0_15)?.Clone()));
            batteryPercentage = TMP_tmp1_13;
        }
        public void Anon_17(Event currentMachine_dequeuedEvent)
        {
            PowerManagement currentMachine = this;
            PrtNamedTuple request_2 = (PrtNamedTuple)(gotoPayload ?? ((PEvent)currentMachine_dequeuedEvent).Payload);
            this.gotoPayload = null;
            PMachineValue TMP_tmp0_16 = null;
            PMachineValue TMP_tmp1_14 = null;
            PEvent TMP_tmp2_12 = null;
            PrtFloat TMP_tmp3_8 = ((PrtFloat)0.0);
            PrtNamedTuple TMP_tmp4_8 = (new PrtNamedTuple(new string[]{"droneMovementDistance"},((PrtFloat)0.0)));
            TMP_tmp0_16 = (PMachineValue)(((PrtNamedTuple)request_2)["source"]);
            TMP_tmp1_14 = (PMachineValue)(((PMachineValue)((IPrtValue)TMP_tmp0_16)?.Clone()));
            TMP_tmp2_12 = (PEvent)(new eDroneMovementDistanceResponse((new PrtNamedTuple(new string[]{"droneMovementDistance"},((PrtFloat)0.0)))));
            TMP_tmp3_8 = (PrtFloat)(((PrtFloat)((IPrtValue)cumulativeDroneMovementDistance)?.Clone()));
            TMP_tmp4_8 = (PrtNamedTuple)((new PrtNamedTuple(new string[]{"droneMovementDistance"}, TMP_tmp3_8)));
            currentMachine.TrySendEvent(TMP_tmp1_14, (Event)TMP_tmp2_12, TMP_tmp4_8);
            cumulativeDroneMovementDistance = (PrtFloat)(((PrtFloat)0));
        }
        public void Anon_18(Event currentMachine_dequeuedEvent)
        {
            PowerManagement currentMachine = this;
            PrtNamedTuple request_3 = (PrtNamedTuple)(gotoPayload ?? ((PEvent)currentMachine_dequeuedEvent).Payload);
            this.gotoPayload = null;
            PrtFloat distance_to_origin = ((PrtFloat)0.0);
            PrtFloat TMP_tmp0_17 = ((PrtFloat)0.0);
            PMachineValue TMP_tmp1_15 = null;
            PMachineValue TMP_tmp2_13 = null;
            PEvent TMP_tmp3_9 = null;
            PrtFloat TMP_tmp4_9 = ((PrtFloat)0.0);
            PrtFloat TMP_tmp5_7 = ((PrtFloat)0.0);
            PrtFloat TMP_tmp6_6 = ((PrtFloat)0.0);
            PrtNamedTuple TMP_tmp7_6 = (new PrtNamedTuple(new string[]{"fenceRadius"},((PrtFloat)0.0)));
            TMP_tmp0_17 = (PrtFloat)((droneHorizontalPosition) + (droneVerticalPosition));
            distance_to_origin = TMP_tmp0_17;
            TMP_tmp1_15 = (PMachineValue)(((PrtNamedTuple)request_3)["source"]);
            TMP_tmp2_13 = (PMachineValue)(((PMachineValue)((IPrtValue)TMP_tmp1_15)?.Clone()));
            TMP_tmp3_9 = (PEvent)(new eFenceRadiusResponse((new PrtNamedTuple(new string[]{"fenceRadius"},((PrtFloat)0.0)))));
            TMP_tmp4_9 = (PrtFloat)((batteryPercentage) / (powerConsumptionRate_1));
            TMP_tmp5_7 = (PrtFloat)((TMP_tmp4_9) + (distance_to_origin));
            TMP_tmp6_6 = (PrtFloat)((TMP_tmp5_7) / (((PrtFloat)2)));
            TMP_tmp7_6 = (PrtNamedTuple)((new PrtNamedTuple(new string[]{"fenceRadius"}, TMP_tmp6_6)));
            currentMachine.TrySendEvent(TMP_tmp2_13, (Event)TMP_tmp3_9, TMP_tmp7_6);
        }
        public void Anon_19(Event currentMachine_dequeuedEvent)
        {
            PowerManagement currentMachine = this;
            PrtNamedTuple request_4 = (PrtNamedTuple)(gotoPayload ?? ((PEvent)currentMachine_dequeuedEvent).Payload);
            this.gotoPayload = null;
            PrtFloat TMP_tmp0_18 = ((PrtFloat)0.0);
            PrtFloat TMP_tmp1_16 = ((PrtFloat)0.0);
            PrtFloat TMP_tmp2_14 = ((PrtFloat)0.0);
            PrtFloat TMP_tmp3_10 = ((PrtFloat)0.0);
            PrtFloat TMP_tmp4_10 = ((PrtFloat)0.0);
            PrtFloat TMP_tmp5_8 = ((PrtFloat)0.0);
            TMP_tmp0_18 = (PrtFloat)(((PrtNamedTuple)request_4)["droneHorizontalPosition"]);
            TMP_tmp1_16 = (PrtFloat)(((PrtFloat)((IPrtValue)TMP_tmp0_18)?.Clone()));
            droneHorizontalPosition = TMP_tmp1_16;
            TMP_tmp2_14 = (PrtFloat)(((PrtNamedTuple)request_4)["droneVerticalPosition"]);
            TMP_tmp3_10 = (PrtFloat)(((PrtFloat)((IPrtValue)TMP_tmp2_14)?.Clone()));
            droneVerticalPosition = TMP_tmp3_10;
            TMP_tmp4_10 = (PrtFloat)(((PrtNamedTuple)request_4)["droneMovementDistance"]);
            TMP_tmp5_8 = (PrtFloat)((cumulativeDroneMovementDistance) + (TMP_tmp4_10));
            cumulativeDroneMovementDistance = TMP_tmp5_8;
        }
        [Start]
        [OnEntry(nameof(InitializeParametersFunction))]
        [OnEventGotoState(typeof(ConstructorEvent), typeof(Init_3))]
        class __InitState__ : State { }
        
        [OnEntry(nameof(Anon_14))]
        class Init_3 : State
        {
        }
        [OnEventDoAction(typeof(eBatteryThresholdRequest), nameof(Anon_15))]
        [OnEventDoAction(typeof(eUpdateDroneBatteryRequest), nameof(Anon_16))]
        [OnEventDoAction(typeof(eDroneMovementDistanceRequest), nameof(Anon_17))]
        [OnEventDoAction(typeof(eFenceRadiusRequest), nameof(Anon_18))]
        [OnEventDoAction(typeof(eUpdateDroneMovementDistanceAndPosition), nameof(Anon_19))]
        class WaitingForRequests : State
        {
        }
    }
}
namespace PImplementation
{
    internal partial class GeoFenceModified : PMachine
    {
        private PMachineValue powerManager_1 = null;
        private PrtFloat fence_alt_min_1 = ((PrtFloat)0.0);
        private PrtFloat fence_alt_max_1 = ((PrtFloat)0.0);
        private PrtFloat fence_radius_1 = ((PrtFloat)0.0);
        private PrtFloat drone_horizontal_distance_to_origin_1 = ((PrtFloat)0.0);
        private PrtFloat drone_altitude_1 = ((PrtFloat)0.0);
        private PrtFloat drone_movement = ((PrtFloat)0.0);
        public class ConstructorEvent : PEvent{public ConstructorEvent(PMachineValue val) : base(val) { }}
        
        protected override Event GetConstructorEvent(IPrtValue value) { return new ConstructorEvent((PMachineValue)value); }
        public GeoFenceModified() {
            this.sends.Add(nameof(eBatteryThresholdRequest));
            this.sends.Add(nameof(eBatteryThresholdResponse));
            this.sends.Add(nameof(eDroneMovementDistanceRequest));
            this.sends.Add(nameof(eDroneMovementDistanceResponse));
            this.sends.Add(nameof(eDroneMovementResponse));
            this.sends.Add(nameof(eDroneMovementResponseFloat));
            this.sends.Add(nameof(eFenceDistanced));
            this.sends.Add(nameof(eFenceRadiusRequest));
            this.sends.Add(nameof(eFenceRadiusResponse));
            this.sends.Add(nameof(eFenceReached));
            this.sends.Add(nameof(eLanded));
            this.sends.Add(nameof(eLanding));
            this.sends.Add(nameof(eRequestDroneMovement));
            this.sends.Add(nameof(eStartBatteryFailSafe));
            this.sends.Add(nameof(eStartGeoFence));
            this.sends.Add(nameof(eUpdateBatteryPercentage));
            this.sends.Add(nameof(eUpdateDroneBatteryRequest));
            this.sends.Add(nameof(eUpdateDroneMovementDistanceAndPosition));
            this.sends.Add(nameof(PHalt));
            this.receives.Add(nameof(eBatteryThresholdRequest));
            this.receives.Add(nameof(eBatteryThresholdResponse));
            this.receives.Add(nameof(eDroneMovementDistanceRequest));
            this.receives.Add(nameof(eDroneMovementDistanceResponse));
            this.receives.Add(nameof(eDroneMovementResponse));
            this.receives.Add(nameof(eDroneMovementResponseFloat));
            this.receives.Add(nameof(eFenceDistanced));
            this.receives.Add(nameof(eFenceRadiusRequest));
            this.receives.Add(nameof(eFenceRadiusResponse));
            this.receives.Add(nameof(eFenceReached));
            this.receives.Add(nameof(eLanded));
            this.receives.Add(nameof(eLanding));
            this.receives.Add(nameof(eRequestDroneMovement));
            this.receives.Add(nameof(eStartBatteryFailSafe));
            this.receives.Add(nameof(eStartGeoFence));
            this.receives.Add(nameof(eUpdateBatteryPercentage));
            this.receives.Add(nameof(eUpdateDroneBatteryRequest));
            this.receives.Add(nameof(eUpdateDroneMovementDistanceAndPosition));
            this.receives.Add(nameof(PHalt));
        }
        
        public void Anon_20(Event currentMachine_dequeuedEvent)
        {
            GeoFenceModified currentMachine = this;
            PMachineValue powerManagerLocal_1 = (PMachineValue)(gotoPayload ?? ((PEvent)currentMachine_dequeuedEvent).Payload);
            this.gotoPayload = null;
            PrtString TMP_tmp0_19 = ((PrtString)"");
            PMachineValue TMP_tmp1_17 = null;
            PEvent TMP_tmp2_15 = null;
            PrtFloat TMP_tmp3_11 = ((PrtFloat)0.0);
            PrtFloat TMP_tmp4_11 = ((PrtFloat)0.0);
            PrtFloat TMP_tmp5_9 = ((PrtFloat)0.0);
            PrtNamedTuple TMP_tmp6_7 = (new PrtNamedTuple(new string[]{"droneMovementDistance","droneHorizontalPosition","droneVerticalPosition"},((PrtFloat)0.0), ((PrtFloat)0.0), ((PrtFloat)0.0)));
            PMachineValue TMP_tmp7_7 = null;
            PEvent TMP_tmp8_5 = null;
            PMachineValue TMP_tmp9_4 = null;
            PrtNamedTuple TMP_tmp10_2 = (new PrtNamedTuple(new string[]{"source"},null));
            powerManager_1 = (PMachineValue)(((PMachineValue)((IPrtValue)powerManagerLocal_1)?.Clone()));
            fence_alt_min_1 = (PrtFloat)(((PrtFloat)0));
            fence_alt_max_1 = (PrtFloat)(((PrtFloat)100));
            fence_radius_1 = (PrtFloat)(((PrtFloat)100));
            drone_movement = (PrtFloat)(((PrtFloat)0));
            drone_horizontal_distance_to_origin_1 = (PrtFloat)(((PrtFloat)0));
            drone_altitude_1 = (PrtFloat)(((PrtFloat)0));
            TMP_tmp0_19 = (PrtString)(((PrtString) String.Format("GeoFence Enabled!")));
            PModule.runtime.Logger.WriteLine("<PrintLog> " + TMP_tmp0_19);
            TMP_tmp1_17 = (PMachineValue)(((PMachineValue)((IPrtValue)powerManager_1)?.Clone()));
            TMP_tmp2_15 = (PEvent)(new eUpdateDroneMovementDistanceAndPosition((new PrtNamedTuple(new string[]{"droneMovementDistance","droneHorizontalPosition","droneVerticalPosition"},((PrtFloat)0.0), ((PrtFloat)0.0), ((PrtFloat)0.0)))));
            TMP_tmp3_11 = (PrtFloat)(((PrtFloat)((IPrtValue)drone_movement)?.Clone()));
            TMP_tmp4_11 = (PrtFloat)(((PrtFloat)((IPrtValue)drone_horizontal_distance_to_origin_1)?.Clone()));
            TMP_tmp5_9 = (PrtFloat)(((PrtFloat)((IPrtValue)drone_altitude_1)?.Clone()));
            TMP_tmp6_7 = (PrtNamedTuple)((new PrtNamedTuple(new string[]{"droneMovementDistance","droneHorizontalPosition","droneVerticalPosition"}, TMP_tmp3_11, TMP_tmp4_11, TMP_tmp5_9)));
            currentMachine.TrySendEvent(TMP_tmp1_17, (Event)TMP_tmp2_15, TMP_tmp6_7);
            TMP_tmp7_7 = (PMachineValue)(((PMachineValue)((IPrtValue)powerManager_1)?.Clone()));
            TMP_tmp8_5 = (PEvent)(new eFenceRadiusRequest((new PrtNamedTuple(new string[]{"source"},null))));
            TMP_tmp9_4 = (PMachineValue)(currentMachine.self);
            TMP_tmp10_2 = (PrtNamedTuple)((new PrtNamedTuple(new string[]{"source"}, TMP_tmp9_4)));
            currentMachine.TrySendEvent(TMP_tmp7_7, (Event)TMP_tmp8_5, TMP_tmp10_2);
            currentMachine.TryGotoState<MonitorAndUpdate_1>();
            return;
        }
        public void Anon_21(Event currentMachine_dequeuedEvent)
        {
            GeoFenceModified currentMachine = this;
            PrtNamedTuple response_4 = (PrtNamedTuple)(gotoPayload ?? ((PEvent)currentMachine_dequeuedEvent).Payload);
            this.gotoPayload = null;
            PrtFloat TMP_tmp0_20 = ((PrtFloat)0.0);
            PrtFloat TMP_tmp1_18 = ((PrtFloat)0.0);
            PMachineValue TMP_tmp2_16 = null;
            PEvent TMP_tmp3_12 = null;
            TMP_tmp0_20 = (PrtFloat)(((PrtNamedTuple)response_4)["fenceRadius"]);
            TMP_tmp1_18 = (PrtFloat)(((PrtFloat)((IPrtValue)TMP_tmp0_20)?.Clone()));
            fence_radius_1 = TMP_tmp1_18;
            TMP_tmp2_16 = (PMachineValue)(currentMachine.self);
            TMP_tmp3_12 = (PEvent)(new eRequestDroneMovement(null));
            currentMachine.TrySendEvent(TMP_tmp2_16, (Event)TMP_tmp3_12);
            currentMachine.TryGotoState<GenerateMovement_1>();
            return;
        }
        public void Anon_22(Event currentMachine_dequeuedEvent)
        {
            GeoFenceModified currentMachine = this;
            PMachineValue TMP_tmp0_21 = null;
            PEvent TMP_tmp1_19 = null;
            TMP_tmp0_21 = (PMachineValue)(currentMachine.self);
            TMP_tmp1_19 = (PEvent)(new eRequestDroneMovement(null));
            currentMachine.TrySendEvent(TMP_tmp0_21, (Event)TMP_tmp1_19);
            currentMachine.TryGotoState<GenerateMovement_1>();
            return;
        }
        public void Anon_23(Event currentMachine_dequeuedEvent)
        {
            GeoFenceModified currentMachine = this;
            PrtNamedTuple response_5 = (PrtNamedTuple)(gotoPayload ?? ((PEvent)currentMachine_dequeuedEvent).Payload);
            this.gotoPayload = null;
            PrtFloat TMP_tmp0_22 = ((PrtFloat)0.0);
            PrtFloat TMP_tmp1_20 = ((PrtFloat)0.0);
            PrtBool TMP_tmp2_17 = ((PrtBool)false);
            PMachineValue TMP_tmp3_13 = null;
            PEvent TMP_tmp4_12 = null;
            PrtFloat TMP_tmp5_10 = ((PrtFloat)0.0);
            PrtFloat TMP_tmp6_8 = ((PrtFloat)0.0);
            PrtBool TMP_tmp7_8 = ((PrtBool)false);
            PrtFloat TMP_tmp8_6 = ((PrtFloat)0.0);
            PrtFloat TMP_tmp9_5 = ((PrtFloat)0.0);
            PrtBool TMP_tmp10_3 = ((PrtBool)false);
            PrtBool TMP_tmp11_2 = ((PrtBool)false);
            PMachineValue TMP_tmp12_2 = null;
            PEvent TMP_tmp13_2 = null;
            PrtFloat TMP_tmp14_2 = ((PrtFloat)0.0);
            PrtFloat TMP_tmp15_2 = ((PrtFloat)0.0);
            PrtFloat TMP_tmp16_2 = ((PrtFloat)0.0);
            PrtFloat TMP_tmp17_2 = ((PrtFloat)0.0);
            PMachineValue TMP_tmp18_1 = null;
            PEvent TMP_tmp19_1 = null;
            PrtFloat TMP_tmp20_1 = ((PrtFloat)0.0);
            PrtFloat TMP_tmp21_1 = ((PrtFloat)0.0);
            PrtFloat TMP_tmp22_1 = ((PrtFloat)0.0);
            PrtFloat TMP_tmp23 = ((PrtFloat)0.0);
            PrtFloat TMP_tmp24 = ((PrtFloat)0.0);
            PrtNamedTuple TMP_tmp25 = (new PrtNamedTuple(new string[]{"droneMovementDistance","droneHorizontalPosition","droneVerticalPosition"},((PrtFloat)0.0), ((PrtFloat)0.0), ((PrtFloat)0.0)));
            PMachineValue TMP_tmp26 = null;
            PEvent TMP_tmp27 = null;
            PMachineValue TMP_tmp28 = null;
            PrtNamedTuple TMP_tmp29 = (new PrtNamedTuple(new string[]{"source"},null));
            TMP_tmp0_22 = (PrtFloat)(((PrtNamedTuple)response_5)["horizontal_movement"]);
            TMP_tmp1_20 = (PrtFloat)((drone_horizontal_distance_to_origin_1) + (TMP_tmp0_22));
            TMP_tmp2_17 = (PrtBool)((TMP_tmp1_20) > (fence_radius_1));
            if (TMP_tmp2_17)
            {
                TMP_tmp3_13 = (PMachineValue)(currentMachine.self);
                TMP_tmp4_12 = (PEvent)(new eFenceReached(null));
                currentMachine.TrySendEvent(TMP_tmp3_13, (Event)TMP_tmp4_12);
                currentMachine.TryGotoState<Holding_1>();
                return;
            }
            else
            {
                TMP_tmp5_10 = (PrtFloat)(((PrtNamedTuple)response_5)["vertical_movement"]);
                TMP_tmp6_8 = (PrtFloat)((drone_altitude_1) + (TMP_tmp5_10));
                TMP_tmp7_8 = (PrtBool)((TMP_tmp6_8) < (fence_alt_min_1));
                TMP_tmp11_2 = (PrtBool)(((PrtBool)((IPrtValue)TMP_tmp7_8)?.Clone()));
                if (TMP_tmp11_2)
                {
                }
                else
                {
                    TMP_tmp8_6 = (PrtFloat)(((PrtNamedTuple)response_5)["vertical_movement"]);
                    TMP_tmp9_5 = (PrtFloat)((drone_altitude_1) + (TMP_tmp8_6));
                    TMP_tmp10_3 = (PrtBool)((TMP_tmp9_5) > (fence_alt_max_1));
                    TMP_tmp11_2 = (PrtBool)(((PrtBool)((IPrtValue)TMP_tmp10_3)?.Clone()));
                }
                if (TMP_tmp11_2)
                {
                    TMP_tmp12_2 = (PMachineValue)(currentMachine.self);
                    TMP_tmp13_2 = (PEvent)(new eFenceReached(null));
                    currentMachine.TrySendEvent(TMP_tmp12_2, (Event)TMP_tmp13_2);
                    currentMachine.TryGotoState<Holding_1>();
                    return;
                }
                else
                {
                    TMP_tmp14_2 = (PrtFloat)(((PrtNamedTuple)response_5)["vertical_movement"]);
                    TMP_tmp15_2 = (PrtFloat)((drone_altitude_1) + (TMP_tmp14_2));
                    drone_altitude_1 = TMP_tmp15_2;
                    TMP_tmp16_2 = (PrtFloat)(((PrtNamedTuple)response_5)["horizontal_movement"]);
                    TMP_tmp17_2 = (PrtFloat)((drone_horizontal_distance_to_origin_1) + (TMP_tmp16_2));
                    drone_horizontal_distance_to_origin_1 = TMP_tmp17_2;
                }
            }
            TMP_tmp18_1 = (PMachineValue)(((PMachineValue)((IPrtValue)powerManager_1)?.Clone()));
            TMP_tmp19_1 = (PEvent)(new eUpdateDroneMovementDistanceAndPosition((new PrtNamedTuple(new string[]{"droneMovementDistance","droneHorizontalPosition","droneVerticalPosition"},((PrtFloat)0.0), ((PrtFloat)0.0), ((PrtFloat)0.0)))));
            TMP_tmp20_1 = (PrtFloat)(((PrtNamedTuple)response_5)["vertical_movement"]);
            TMP_tmp21_1 = (PrtFloat)(((PrtNamedTuple)response_5)["horizontal_movement"]);
            TMP_tmp22_1 = (PrtFloat)((TMP_tmp20_1) + (TMP_tmp21_1));
            TMP_tmp23 = (PrtFloat)(((PrtFloat)((IPrtValue)drone_horizontal_distance_to_origin_1)?.Clone()));
            TMP_tmp24 = (PrtFloat)(((PrtFloat)((IPrtValue)drone_altitude_1)?.Clone()));
            TMP_tmp25 = (PrtNamedTuple)((new PrtNamedTuple(new string[]{"droneMovementDistance","droneHorizontalPosition","droneVerticalPosition"}, TMP_tmp22_1, TMP_tmp23, TMP_tmp24)));
            currentMachine.TrySendEvent(TMP_tmp18_1, (Event)TMP_tmp19_1, TMP_tmp25);
            TMP_tmp26 = (PMachineValue)(((PMachineValue)((IPrtValue)powerManager_1)?.Clone()));
            TMP_tmp27 = (PEvent)(new eFenceRadiusRequest((new PrtNamedTuple(new string[]{"source"},null))));
            TMP_tmp28 = (PMachineValue)(currentMachine.self);
            TMP_tmp29 = (PrtNamedTuple)((new PrtNamedTuple(new string[]{"source"}, TMP_tmp28)));
            currentMachine.TrySendEvent(TMP_tmp26, (Event)TMP_tmp27, TMP_tmp29);
        }
        public void Anon_24(Event currentMachine_dequeuedEvent)
        {
            GeoFenceModified currentMachine = this;
            PrtString TMP_tmp0_23 = ((PrtString)"");
            PMachineValue TMP_tmp1_21 = null;
            PEvent TMP_tmp2_18 = null;
            TMP_tmp0_23 = (PrtString)(((PrtString) String.Format("Fence Reached! Starting Holding Pattern")));
            PModule.runtime.Logger.WriteLine("<PrintLog> " + TMP_tmp0_23);
            TMP_tmp1_21 = (PMachineValue)(currentMachine.self);
            TMP_tmp2_18 = (PEvent)(new eFenceDistanced(null));
            currentMachine.TrySendEvent(TMP_tmp1_21, (Event)TMP_tmp2_18);
            currentMachine.TryGotoState<MonitorAndUpdate_1>();
            return;
        }
        public void Anon_25(Event currentMachine_dequeuedEvent)
        {
            GeoFenceModified currentMachine = this;
            PrtNamedTuple response_6 = (new PrtNamedTuple(new string[]{"horizontal_movement","vertical_movement"},((PrtFloat)0.0), ((PrtFloat)0.0)));
            PrtInt TMP_tmp0_24 = ((PrtInt)0);
            PrtInt TMP_tmp1_22 = ((PrtInt)0);
            PrtFloat TMP_tmp2_19 = ((PrtFloat)0.0);
            PrtInt TMP_tmp3_14 = ((PrtInt)0);
            PrtInt TMP_tmp4_13 = ((PrtInt)0);
            PrtFloat TMP_tmp5_11 = ((PrtFloat)0.0);
            PMachineValue TMP_tmp6_9 = null;
            PEvent TMP_tmp7_9 = null;
            PrtNamedTuple TMP_tmp8_7 = (new PrtNamedTuple(new string[]{"horizontal_movement","vertical_movement"},((PrtFloat)0.0), ((PrtFloat)0.0)));
            TMP_tmp0_24 = (PrtInt)(((PrtInt)currentMachine.TryRandom(((PrtInt)20))));
            TMP_tmp1_22 = (PrtInt)((TMP_tmp0_24) - (((PrtInt)10)));
            TMP_tmp2_19 = (PrtFloat)((TMP_tmp1_22));
            ((PrtNamedTuple)response_6)["horizontal_movement"] = TMP_tmp2_19;
            TMP_tmp3_14 = (PrtInt)(((PrtInt)currentMachine.TryRandom(((PrtInt)20))));
            TMP_tmp4_13 = (PrtInt)((TMP_tmp3_14) - (((PrtInt)10)));
            TMP_tmp5_11 = (PrtFloat)((TMP_tmp4_13));
            ((PrtNamedTuple)response_6)["vertical_movement"] = TMP_tmp5_11;
            TMP_tmp6_9 = (PMachineValue)(currentMachine.self);
            TMP_tmp7_9 = (PEvent)(new eDroneMovementResponseFloat((new PrtNamedTuple(new string[]{"horizontal_movement","vertical_movement"},((PrtFloat)0.0), ((PrtFloat)0.0)))));
            TMP_tmp8_7 = (PrtNamedTuple)(((PrtNamedTuple)((IPrtValue)response_6)?.Clone()));
            currentMachine.TrySendEvent(TMP_tmp6_9, (Event)TMP_tmp7_9, TMP_tmp8_7);
            currentMachine.TryGotoState<MonitorAndUpdate_1>();
            return;
        }
        [Start]
        [OnEntry(nameof(InitializeParametersFunction))]
        [OnEventGotoState(typeof(ConstructorEvent), typeof(Init_4))]
        class __InitState__ : State { }
        
        [OnEntry(nameof(Anon_20))]
        class Init_4 : State
        {
        }
        [OnEventDoAction(typeof(eFenceRadiusResponse), nameof(Anon_21))]
        [OnEventDoAction(typeof(eFenceDistanced), nameof(Anon_22))]
        [OnEventDoAction(typeof(eDroneMovementResponseFloat), nameof(Anon_23))]
        class MonitorAndUpdate_1 : State
        {
        }
        [OnEventDoAction(typeof(eFenceReached), nameof(Anon_24))]
        class Holding_1 : State
        {
        }
        [OnEventDoAction(typeof(eRequestDroneMovement), nameof(Anon_25))]
        class GenerateMovement_1 : State
        {
        }
    }
}
namespace PImplementation
{
    public class DefaultImpl {
        public static void InitializeLinkMap() {
            PModule.linkMap.Clear();
            PModule.linkMap[nameof(I_BatteryFailSafeModified)] = new Dictionary<string, string>();
            PModule.linkMap[nameof(I_BatteryFailSafe)] = new Dictionary<string, string>();
            PModule.linkMap[nameof(I_GeoFence)] = new Dictionary<string, string>();
            PModule.linkMap[nameof(I_PowerManagement)] = new Dictionary<string, string>();
            PModule.linkMap[nameof(I_GeoFenceModified)] = new Dictionary<string, string>();
        }
        
        public static void InitializeInterfaceDefMap() {
            PModule.interfaceDefinitionMap.Clear();
            PModule.interfaceDefinitionMap.Add(nameof(I_BatteryFailSafeModified), typeof(BatteryFailSafeModified));
            PModule.interfaceDefinitionMap.Add(nameof(I_BatteryFailSafe), typeof(BatteryFailSafe));
            PModule.interfaceDefinitionMap.Add(nameof(I_GeoFence), typeof(GeoFence));
            PModule.interfaceDefinitionMap.Add(nameof(I_PowerManagement), typeof(PowerManagement));
            PModule.interfaceDefinitionMap.Add(nameof(I_GeoFenceModified), typeof(GeoFenceModified));
        }
        
        public static void InitializeMonitorObserves() {
            PModule.monitorObserves.Clear();
        }
        
        public static void InitializeMonitorMap(IActorRuntime runtime) {
            PModule.monitorMap.Clear();
        }
        
        
        [PChecker.SystematicTesting.Test]
        public static void Execute(IActorRuntime runtime) {
            runtime.RegisterLog(new PLogFormatter());
            PModule.runtime = runtime;
            PHelper.InitializeInterfaces();
            PHelper.InitializeEnums();
            InitializeLinkMap();
            InitializeInterfaceDefMap();
            InitializeMonitorMap(runtime);
            InitializeMonitorObserves();
            runtime.CreateActor(typeof(_GodMachine), new _GodMachine.Config(typeof(Main)));
        }
    }
}
// TODO: NamedModule BatteryFailSafe_1
// TODO: NamedModule GeoFence_1
// TODO: NamedModule BatteryFailSafeModified_1
// TODO: NamedModule GeoFenceModified_1
// TODO: NamedModule PowerManagement_1
namespace PImplementation
{
    public class I_BatteryFailSafeModified : PMachineValue {
        public I_BatteryFailSafeModified (ActorId machine, List<string> permissions) : base(machine, permissions) { }
    }
    
    public class I_BatteryFailSafe : PMachineValue {
        public I_BatteryFailSafe (ActorId machine, List<string> permissions) : base(machine, permissions) { }
    }
    
    public class I_GeoFence : PMachineValue {
        public I_GeoFence (ActorId machine, List<string> permissions) : base(machine, permissions) { }
    }
    
    public class I_PowerManagement : PMachineValue {
        public I_PowerManagement (ActorId machine, List<string> permissions) : base(machine, permissions) { }
    }
    
    public class I_GeoFenceModified : PMachineValue {
        public I_GeoFenceModified (ActorId machine, List<string> permissions) : base(machine, permissions) { }
    }
    
    public partial class PHelper {
        public static void InitializeInterfaces() {
            PInterfaces.Clear();
            PInterfaces.AddInterface(nameof(I_BatteryFailSafeModified), nameof(eBatteryThresholdRequest), nameof(eBatteryThresholdResponse), nameof(eDroneMovementDistanceRequest), nameof(eDroneMovementDistanceResponse), nameof(eDroneMovementResponse), nameof(eDroneMovementResponseFloat), nameof(eFenceDistanced), nameof(eFenceRadiusRequest), nameof(eFenceRadiusResponse), nameof(eFenceReached), nameof(eLanded), nameof(eLanding), nameof(eRequestDroneMovement), nameof(eStartBatteryFailSafe), nameof(eStartGeoFence), nameof(eUpdateBatteryPercentage), nameof(eUpdateDroneBatteryRequest), nameof(eUpdateDroneMovementDistanceAndPosition), nameof(PHalt));
            PInterfaces.AddInterface(nameof(I_BatteryFailSafe), nameof(eBatteryThresholdRequest), nameof(eBatteryThresholdResponse), nameof(eDroneMovementDistanceRequest), nameof(eDroneMovementDistanceResponse), nameof(eDroneMovementResponse), nameof(eDroneMovementResponseFloat), nameof(eFenceDistanced), nameof(eFenceRadiusRequest), nameof(eFenceRadiusResponse), nameof(eFenceReached), nameof(eLanded), nameof(eLanding), nameof(eRequestDroneMovement), nameof(eStartBatteryFailSafe), nameof(eStartGeoFence), nameof(eUpdateBatteryPercentage), nameof(eUpdateDroneBatteryRequest), nameof(eUpdateDroneMovementDistanceAndPosition), nameof(PHalt));
            PInterfaces.AddInterface(nameof(I_GeoFence), nameof(eBatteryThresholdRequest), nameof(eBatteryThresholdResponse), nameof(eDroneMovementDistanceRequest), nameof(eDroneMovementDistanceResponse), nameof(eDroneMovementResponse), nameof(eDroneMovementResponseFloat), nameof(eFenceDistanced), nameof(eFenceRadiusRequest), nameof(eFenceRadiusResponse), nameof(eFenceReached), nameof(eLanded), nameof(eLanding), nameof(eRequestDroneMovement), nameof(eStartBatteryFailSafe), nameof(eStartGeoFence), nameof(eUpdateBatteryPercentage), nameof(eUpdateDroneBatteryRequest), nameof(eUpdateDroneMovementDistanceAndPosition), nameof(PHalt));
            PInterfaces.AddInterface(nameof(I_PowerManagement), nameof(eBatteryThresholdRequest), nameof(eBatteryThresholdResponse), nameof(eDroneMovementDistanceRequest), nameof(eDroneMovementDistanceResponse), nameof(eDroneMovementResponse), nameof(eDroneMovementResponseFloat), nameof(eFenceDistanced), nameof(eFenceRadiusRequest), nameof(eFenceRadiusResponse), nameof(eFenceReached), nameof(eLanded), nameof(eLanding), nameof(eRequestDroneMovement), nameof(eStartBatteryFailSafe), nameof(eStartGeoFence), nameof(eUpdateBatteryPercentage), nameof(eUpdateDroneBatteryRequest), nameof(eUpdateDroneMovementDistanceAndPosition), nameof(PHalt));
            PInterfaces.AddInterface(nameof(I_GeoFenceModified), nameof(eBatteryThresholdRequest), nameof(eBatteryThresholdResponse), nameof(eDroneMovementDistanceRequest), nameof(eDroneMovementDistanceResponse), nameof(eDroneMovementResponse), nameof(eDroneMovementResponseFloat), nameof(eFenceDistanced), nameof(eFenceRadiusRequest), nameof(eFenceRadiusResponse), nameof(eFenceReached), nameof(eLanded), nameof(eLanding), nameof(eRequestDroneMovement), nameof(eStartBatteryFailSafe), nameof(eStartGeoFence), nameof(eUpdateBatteryPercentage), nameof(eUpdateDroneBatteryRequest), nameof(eUpdateDroneMovementDistanceAndPosition), nameof(PHalt));
        }
    }
    
}
namespace PImplementation
{
    public partial class PHelper {
        public static void InitializeEnums() {
            PrtEnum.Clear();
        }
    }
    
}
#pragma warning restore 162, 219, 414
