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
    internal partial class ePong : PEvent
    {
        public ePong() : base() {}
        public ePong (PrtNamedTuple payload): base(payload){ }
        public override IPrtValue Clone() { return new ePong();}
    }
}
namespace PImplementation
{
    internal partial class ePing : PEvent
    {
        public ePing() : base() {}
        public ePing (PrtNamedTuple payload): base(payload){ }
        public override IPrtValue Clone() { return new ePing();}
    }
}
namespace PImplementation
{
    internal partial class eStartBatteryFailSafe : PEvent
    {
        public eStartBatteryFailSafe() : base() {}
        public eStartBatteryFailSafe (IPrtValue payload): base(payload){ }
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
    internal partial class eUpdateDroneMovementAndPosition : PEvent
    {
        public eUpdateDroneMovementAndPosition() : base() {}
        public eUpdateDroneMovementAndPosition (PrtNamedTuple payload): base(payload){ }
        public override IPrtValue Clone() { return new eUpdateDroneMovementAndPosition();}
    }
}
namespace PImplementation
{
    internal partial class Pong : PMachine
    {
        private PrtInt counter = ((PrtInt)0);
        public class ConstructorEvent : PEvent{public ConstructorEvent(IPrtValue val) : base(val) { }}
        
        protected override Event GetConstructorEvent(IPrtValue value) { return new ConstructorEvent((IPrtValue)value); }
        public Pong() {
            this.sends.Add(nameof(eBatteryThresholdRequest));
            this.sends.Add(nameof(eBatteryThresholdResponse));
            this.sends.Add(nameof(eDroneMovementResponse));
            this.sends.Add(nameof(eFenceDistanced));
            this.sends.Add(nameof(eFenceRadiusRequest));
            this.sends.Add(nameof(eFenceRadiusResponse));
            this.sends.Add(nameof(eFenceReached));
            this.sends.Add(nameof(eLanded));
            this.sends.Add(nameof(eLanding));
            this.sends.Add(nameof(ePing));
            this.sends.Add(nameof(ePong));
            this.sends.Add(nameof(eRequestDroneMovement));
            this.sends.Add(nameof(eStartBatteryFailSafe));
            this.sends.Add(nameof(eStartGeoFence));
            this.sends.Add(nameof(eUpdateBatteryPercentage));
            this.sends.Add(nameof(eUpdateDroneBatteryRequest));
            this.sends.Add(nameof(eUpdateDroneMovementAndPosition));
            this.sends.Add(nameof(PHalt));
            this.receives.Add(nameof(eBatteryThresholdRequest));
            this.receives.Add(nameof(eBatteryThresholdResponse));
            this.receives.Add(nameof(eDroneMovementResponse));
            this.receives.Add(nameof(eFenceDistanced));
            this.receives.Add(nameof(eFenceRadiusRequest));
            this.receives.Add(nameof(eFenceRadiusResponse));
            this.receives.Add(nameof(eFenceReached));
            this.receives.Add(nameof(eLanded));
            this.receives.Add(nameof(eLanding));
            this.receives.Add(nameof(ePing));
            this.receives.Add(nameof(ePong));
            this.receives.Add(nameof(eRequestDroneMovement));
            this.receives.Add(nameof(eStartBatteryFailSafe));
            this.receives.Add(nameof(eStartGeoFence));
            this.receives.Add(nameof(eUpdateBatteryPercentage));
            this.receives.Add(nameof(eUpdateDroneBatteryRequest));
            this.receives.Add(nameof(eUpdateDroneMovementAndPosition));
            this.receives.Add(nameof(PHalt));
        }
        
        public void Anon(Event currentMachine_dequeuedEvent)
        {
            Pong currentMachine = this;
            counter = (PrtInt)(((PrtInt)0));
            currentMachine.TryGotoState<Pong_1>();
            return;
        }
        public void Anon_1(Event currentMachine_dequeuedEvent)
        {
            Pong currentMachine = this;
            PrtNamedTuple pingResponse = (PrtNamedTuple)(gotoPayload ?? ((PEvent)currentMachine_dequeuedEvent).Payload);
            this.gotoPayload = null;
            PrtInt TMP_tmp0 = ((PrtInt)0);
            PrtInt TMP_tmp1 = ((PrtInt)0);
            PrtString TMP_tmp2 = ((PrtString)"");
            PMachineValue TMP_tmp3 = null;
            PMachineValue TMP_tmp4 = null;
            PEvent TMP_tmp5 = null;
            PMachineValue TMP_tmp6 = null;
            PrtNamedTuple TMP_tmp7 = (new PrtNamedTuple(new string[]{"source"},null));
            TMP_tmp0 = (PrtInt)((counter) + (((PrtInt)1)));
            counter = TMP_tmp0;
            TMP_tmp1 = (PrtInt)(((PrtInt)((IPrtValue)counter)?.Clone()));
            TMP_tmp2 = (PrtString)(((PrtString) String.Format("Pong called, counter = {0}",TMP_tmp1)));
            PModule.runtime.Logger.WriteLine("<PrintLog> " + TMP_tmp2);
            TMP_tmp3 = (PMachineValue)(((PrtNamedTuple)pingResponse)["source"]);
            TMP_tmp4 = (PMachineValue)(((PMachineValue)((IPrtValue)TMP_tmp3)?.Clone()));
            TMP_tmp5 = (PEvent)(new ePong((new PrtNamedTuple(new string[]{"source"},null))));
            TMP_tmp6 = (PMachineValue)(currentMachine.self);
            TMP_tmp7 = (PrtNamedTuple)((new PrtNamedTuple(new string[]{"source"}, TMP_tmp6)));
            currentMachine.TrySendEvent(TMP_tmp4, (Event)TMP_tmp5, TMP_tmp7);
        }
        [Start]
        [OnEntry(nameof(InitializeParametersFunction))]
        [OnEventGotoState(typeof(ConstructorEvent), typeof(Init))]
        class __InitState__ : State { }
        
        [OnEntry(nameof(Anon))]
        class Init : State
        {
        }
        [OnEventDoAction(typeof(ePing), nameof(Anon_1))]
        class Pong_1 : State
        {
        }
    }
}
namespace PImplementation
{
    internal partial class BatteryFailSafeModified : PMachine
    {
        private PrtFloat battery_percentage = ((PrtFloat)0.0);
        private PrtFloat landing_threshold = ((PrtFloat)0.0);
        private PMachineValue powerManager = null;
        public class ConstructorEvent : PEvent{public ConstructorEvent(PMachineValue val) : base(val) { }}
        
        protected override Event GetConstructorEvent(IPrtValue value) { return new ConstructorEvent((PMachineValue)value); }
        public BatteryFailSafeModified() {
            this.sends.Add(nameof(eBatteryThresholdRequest));
            this.sends.Add(nameof(eBatteryThresholdResponse));
            this.sends.Add(nameof(eDroneMovementResponse));
            this.sends.Add(nameof(eFenceDistanced));
            this.sends.Add(nameof(eFenceRadiusRequest));
            this.sends.Add(nameof(eFenceRadiusResponse));
            this.sends.Add(nameof(eFenceReached));
            this.sends.Add(nameof(eLanded));
            this.sends.Add(nameof(eLanding));
            this.sends.Add(nameof(ePing));
            this.sends.Add(nameof(ePong));
            this.sends.Add(nameof(eRequestDroneMovement));
            this.sends.Add(nameof(eStartBatteryFailSafe));
            this.sends.Add(nameof(eStartGeoFence));
            this.sends.Add(nameof(eUpdateBatteryPercentage));
            this.sends.Add(nameof(eUpdateDroneBatteryRequest));
            this.sends.Add(nameof(eUpdateDroneMovementAndPosition));
            this.sends.Add(nameof(PHalt));
            this.receives.Add(nameof(eBatteryThresholdRequest));
            this.receives.Add(nameof(eBatteryThresholdResponse));
            this.receives.Add(nameof(eDroneMovementResponse));
            this.receives.Add(nameof(eFenceDistanced));
            this.receives.Add(nameof(eFenceRadiusRequest));
            this.receives.Add(nameof(eFenceRadiusResponse));
            this.receives.Add(nameof(eFenceReached));
            this.receives.Add(nameof(eLanded));
            this.receives.Add(nameof(eLanding));
            this.receives.Add(nameof(ePing));
            this.receives.Add(nameof(ePong));
            this.receives.Add(nameof(eRequestDroneMovement));
            this.receives.Add(nameof(eStartBatteryFailSafe));
            this.receives.Add(nameof(eStartGeoFence));
            this.receives.Add(nameof(eUpdateBatteryPercentage));
            this.receives.Add(nameof(eUpdateDroneBatteryRequest));
            this.receives.Add(nameof(eUpdateDroneMovementAndPosition));
            this.receives.Add(nameof(PHalt));
        }
        
        public void Anon_2(Event currentMachine_dequeuedEvent)
        {
            BatteryFailSafeModified currentMachine = this;
            PMachineValue powerManagerLocal = (PMachineValue)(gotoPayload ?? ((PEvent)currentMachine_dequeuedEvent).Payload);
            this.gotoPayload = null;
            PrtString TMP_tmp0_1 = ((PrtString)"");
            powerManager = (PMachineValue)(((PMachineValue)((IPrtValue)powerManagerLocal)?.Clone()));
            battery_percentage = (PrtFloat)(((PrtFloat)100));
            landing_threshold = (PrtFloat)(((PrtFloat)20));
            TMP_tmp0_1 = (PrtString)(((PrtString) String.Format("Battery Fail Safe Enabled!")));
            PModule.runtime.Logger.WriteLine("<PrintLog> " + TMP_tmp0_1);
            currentMachine.TryGotoState<Monitoring>();
            return;
        }
        public void Anon_3(Event currentMachine_dequeuedEvent)
        {
            BatteryFailSafeModified currentMachine = this;
            PrtFloat TMP_tmp0_2 = ((PrtFloat)0.0);
            PrtFloat TMP_tmp1_1 = ((PrtFloat)0.0);
            PrtString TMP_tmp2_1 = ((PrtString)"");
            PrtBool TMP_tmp3_1 = ((PrtBool)false);
            PrtString TMP_tmp4_1 = ((PrtString)"");
            PMachineValue TMP_tmp5_1 = null;
            PEvent TMP_tmp6_1 = null;
            PrtString TMP_tmp7_1 = ((PrtString)"");
            PMachineValue TMP_tmp8 = null;
            PEvent TMP_tmp9 = null;
            TMP_tmp0_2 = (PrtFloat)((battery_percentage) - (((PrtFloat)1)));
            battery_percentage = TMP_tmp0_2;
            TMP_tmp1_1 = (PrtFloat)(((PrtFloat)((IPrtValue)battery_percentage)?.Clone()));
            TMP_tmp2_1 = (PrtString)(((PrtString) String.Format("battery updated, battery = {0}",TMP_tmp1_1)));
            PModule.runtime.Logger.WriteLine("<PrintLog> " + TMP_tmp2_1);
            TMP_tmp3_1 = (PrtBool)((battery_percentage) < (landing_threshold));
            if (TMP_tmp3_1)
            {
                TMP_tmp4_1 = (PrtString)(((PrtString) String.Format("battery below threshold, landing initiated!")));
                PModule.runtime.Logger.WriteLine("<PrintLog> " + TMP_tmp4_1);
                TMP_tmp5_1 = (PMachineValue)(currentMachine.self);
                TMP_tmp6_1 = (PEvent)(new eLanding(null));
                currentMachine.TrySendEvent(TMP_tmp5_1, (Event)TMP_tmp6_1);
                currentMachine.TryGotoState<Landing>();
                return;
            }
            else
            {
                TMP_tmp7_1 = (PrtString)(((PrtString) String.Format("battery above threshold, continue monitoring!")));
                PModule.runtime.Logger.WriteLine("<PrintLog> " + TMP_tmp7_1);
                TMP_tmp8 = (PMachineValue)(currentMachine.self);
                TMP_tmp9 = (PEvent)(new eUpdateBatteryPercentage(null));
                currentMachine.TrySendEvent(TMP_tmp8, (Event)TMP_tmp9);
                currentMachine.TryGotoState<Monitoring>();
                return;
            }
        }
        public void Anon_4(Event currentMachine_dequeuedEvent)
        {
            BatteryFailSafeModified currentMachine = this;
            PrtString TMP_tmp0_3 = ((PrtString)"");
            PMachineValue TMP_tmp1_2 = null;
            PEvent TMP_tmp2_2 = null;
            TMP_tmp0_3 = (PrtString)(((PrtString) String.Format("Landing initiated!")));
            PModule.runtime.Logger.WriteLine("<PrintLog> " + TMP_tmp0_3);
            TMP_tmp1_2 = (PMachineValue)(currentMachine.self);
            TMP_tmp2_2 = (PEvent)(new eLanded(null));
            currentMachine.TrySendEvent(TMP_tmp1_2, (Event)TMP_tmp2_2);
            currentMachine.TryGotoState<Landed>();
            return;
        }
        public void Anon_5(Event currentMachine_dequeuedEvent)
        {
            BatteryFailSafeModified currentMachine = this;
            PrtString TMP_tmp0_4 = ((PrtString)"");
            TMP_tmp0_4 = (PrtString)(((PrtString) String.Format("Landed!")));
            PModule.runtime.Logger.WriteLine("<PrintLog> " + TMP_tmp0_4);
        }
        [Start]
        [OnEntry(nameof(InitializeParametersFunction))]
        [OnEventGotoState(typeof(ConstructorEvent), typeof(Init_1))]
        class __InitState__ : State { }
        
        [OnEntry(nameof(Anon_2))]
        class Init_1 : State
        {
        }
        [OnEventDoAction(typeof(eStartBatteryFailSafe), nameof(Anon_3))]
        [OnEventDoAction(typeof(eUpdateBatteryPercentage), nameof(Anon_3))]
        class Monitoring : State
        {
        }
        [OnEntry(nameof(Anon_4))]
        class Landing : State
        {
        }
        [OnEntry(nameof(Anon_5))]
        class Landed : State
        {
        }
    }
}
namespace PImplementation
{
    internal partial class Ping : PMachine
    {
        private PrtInt counter_1 = ((PrtInt)0);
        private PMachineValue pong = null;
        public class ConstructorEvent : PEvent{public ConstructorEvent(PMachineValue val) : base(val) { }}
        
        protected override Event GetConstructorEvent(IPrtValue value) { return new ConstructorEvent((PMachineValue)value); }
        public Ping() {
            this.sends.Add(nameof(eBatteryThresholdRequest));
            this.sends.Add(nameof(eBatteryThresholdResponse));
            this.sends.Add(nameof(eDroneMovementResponse));
            this.sends.Add(nameof(eFenceDistanced));
            this.sends.Add(nameof(eFenceRadiusRequest));
            this.sends.Add(nameof(eFenceRadiusResponse));
            this.sends.Add(nameof(eFenceReached));
            this.sends.Add(nameof(eLanded));
            this.sends.Add(nameof(eLanding));
            this.sends.Add(nameof(ePing));
            this.sends.Add(nameof(ePong));
            this.sends.Add(nameof(eRequestDroneMovement));
            this.sends.Add(nameof(eStartBatteryFailSafe));
            this.sends.Add(nameof(eStartGeoFence));
            this.sends.Add(nameof(eUpdateBatteryPercentage));
            this.sends.Add(nameof(eUpdateDroneBatteryRequest));
            this.sends.Add(nameof(eUpdateDroneMovementAndPosition));
            this.sends.Add(nameof(PHalt));
            this.receives.Add(nameof(eBatteryThresholdRequest));
            this.receives.Add(nameof(eBatteryThresholdResponse));
            this.receives.Add(nameof(eDroneMovementResponse));
            this.receives.Add(nameof(eFenceDistanced));
            this.receives.Add(nameof(eFenceRadiusRequest));
            this.receives.Add(nameof(eFenceRadiusResponse));
            this.receives.Add(nameof(eFenceReached));
            this.receives.Add(nameof(eLanded));
            this.receives.Add(nameof(eLanding));
            this.receives.Add(nameof(ePing));
            this.receives.Add(nameof(ePong));
            this.receives.Add(nameof(eRequestDroneMovement));
            this.receives.Add(nameof(eStartBatteryFailSafe));
            this.receives.Add(nameof(eStartGeoFence));
            this.receives.Add(nameof(eUpdateBatteryPercentage));
            this.receives.Add(nameof(eUpdateDroneBatteryRequest));
            this.receives.Add(nameof(eUpdateDroneMovementAndPosition));
            this.receives.Add(nameof(PHalt));
        }
        
        public void Anon_6(Event currentMachine_dequeuedEvent)
        {
            Ping currentMachine = this;
            PMachineValue pong_local = (PMachineValue)(gotoPayload ?? ((PEvent)currentMachine_dequeuedEvent).Payload);
            this.gotoPayload = null;
            counter_1 = (PrtInt)(((PrtInt)0));
            pong = (PMachineValue)(((PMachineValue)((IPrtValue)pong_local)?.Clone()));
            currentMachine.TryGotoState<Ping_1>();
            return;
        }
        public void Anon_7(Event currentMachine_dequeuedEvent)
        {
            Ping currentMachine = this;
            PrtInt TMP_tmp0_5 = ((PrtInt)0);
            PrtInt TMP_tmp1_3 = ((PrtInt)0);
            PrtString TMP_tmp2_3 = ((PrtString)"");
            PMachineValue TMP_tmp3_2 = null;
            PEvent TMP_tmp4_2 = null;
            PMachineValue TMP_tmp5_2 = null;
            PrtNamedTuple TMP_tmp6_2 = (new PrtNamedTuple(new string[]{"source"},null));
            TMP_tmp0_5 = (PrtInt)((counter_1) + (((PrtInt)1)));
            counter_1 = TMP_tmp0_5;
            TMP_tmp1_3 = (PrtInt)(((PrtInt)((IPrtValue)counter_1)?.Clone()));
            TMP_tmp2_3 = (PrtString)(((PrtString) String.Format("Ping called, counter = {0}",TMP_tmp1_3)));
            PModule.runtime.Logger.WriteLine("<PrintLog> " + TMP_tmp2_3);
            TMP_tmp3_2 = (PMachineValue)(((PMachineValue)((IPrtValue)pong)?.Clone()));
            TMP_tmp4_2 = (PEvent)(new ePing((new PrtNamedTuple(new string[]{"source"},null))));
            TMP_tmp5_2 = (PMachineValue)(currentMachine.self);
            TMP_tmp6_2 = (PrtNamedTuple)((new PrtNamedTuple(new string[]{"source"}, TMP_tmp5_2)));
            currentMachine.TrySendEvent(TMP_tmp3_2, (Event)TMP_tmp4_2, TMP_tmp6_2);
        }
        public void Anon_8(Event currentMachine_dequeuedEvent)
        {
            Ping currentMachine = this;
            PrtNamedTuple pongResp = (PrtNamedTuple)(gotoPayload ?? ((PEvent)currentMachine_dequeuedEvent).Payload);
            this.gotoPayload = null;
            PrtInt TMP_tmp0_6 = ((PrtInt)0);
            PMachineValue TMP_tmp1_4 = null;
            PMachineValue TMP_tmp2_4 = null;
            PEvent TMP_tmp3_3 = null;
            PMachineValue TMP_tmp4_3 = null;
            PrtNamedTuple TMP_tmp5_3 = (new PrtNamedTuple(new string[]{"source"},null));
            TMP_tmp0_6 = (PrtInt)((counter_1) + (((PrtInt)1)));
            counter_1 = TMP_tmp0_6;
            TMP_tmp1_4 = (PMachineValue)(((PrtNamedTuple)pongResp)["source"]);
            TMP_tmp2_4 = (PMachineValue)(((PMachineValue)((IPrtValue)TMP_tmp1_4)?.Clone()));
            TMP_tmp3_3 = (PEvent)(new ePing((new PrtNamedTuple(new string[]{"source"},null))));
            TMP_tmp4_3 = (PMachineValue)(currentMachine.self);
            TMP_tmp5_3 = (PrtNamedTuple)((new PrtNamedTuple(new string[]{"source"}, TMP_tmp4_3)));
            currentMachine.TrySendEvent(TMP_tmp2_4, (Event)TMP_tmp3_3, TMP_tmp5_3);
        }
        [Start]
        [OnEntry(nameof(InitializeParametersFunction))]
        [OnEventGotoState(typeof(ConstructorEvent), typeof(Init_2))]
        class __InitState__ : State { }
        
        [OnEntry(nameof(Anon_6))]
        class Init_2 : State
        {
        }
        [OnEntry(nameof(Anon_7))]
        [OnEventDoAction(typeof(ePong), nameof(Anon_8))]
        class Ping_1 : State
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
            this.sends.Add(nameof(eDroneMovementResponse));
            this.sends.Add(nameof(eFenceDistanced));
            this.sends.Add(nameof(eFenceRadiusRequest));
            this.sends.Add(nameof(eFenceRadiusResponse));
            this.sends.Add(nameof(eFenceReached));
            this.sends.Add(nameof(eLanded));
            this.sends.Add(nameof(eLanding));
            this.sends.Add(nameof(ePing));
            this.sends.Add(nameof(ePong));
            this.sends.Add(nameof(eRequestDroneMovement));
            this.sends.Add(nameof(eStartBatteryFailSafe));
            this.sends.Add(nameof(eStartGeoFence));
            this.sends.Add(nameof(eUpdateBatteryPercentage));
            this.sends.Add(nameof(eUpdateDroneBatteryRequest));
            this.sends.Add(nameof(eUpdateDroneMovementAndPosition));
            this.sends.Add(nameof(PHalt));
            this.receives.Add(nameof(eBatteryThresholdRequest));
            this.receives.Add(nameof(eBatteryThresholdResponse));
            this.receives.Add(nameof(eDroneMovementResponse));
            this.receives.Add(nameof(eFenceDistanced));
            this.receives.Add(nameof(eFenceRadiusRequest));
            this.receives.Add(nameof(eFenceRadiusResponse));
            this.receives.Add(nameof(eFenceReached));
            this.receives.Add(nameof(eLanded));
            this.receives.Add(nameof(eLanding));
            this.receives.Add(nameof(ePing));
            this.receives.Add(nameof(ePong));
            this.receives.Add(nameof(eRequestDroneMovement));
            this.receives.Add(nameof(eStartBatteryFailSafe));
            this.receives.Add(nameof(eStartGeoFence));
            this.receives.Add(nameof(eUpdateBatteryPercentage));
            this.receives.Add(nameof(eUpdateDroneBatteryRequest));
            this.receives.Add(nameof(eUpdateDroneMovementAndPosition));
            this.receives.Add(nameof(PHalt));
        }
        
        public void Anon_9(Event currentMachine_dequeuedEvent)
        {
            BatteryFailSafe currentMachine = this;
            PrtInt landing_threshold_local = (PrtInt)(gotoPayload ?? ((PEvent)currentMachine_dequeuedEvent).Payload);
            this.gotoPayload = null;
            PrtString TMP_tmp0_7 = ((PrtString)"");
            PMachineValue TMP_tmp1_5 = null;
            PEvent TMP_tmp2_5 = null;
            battery_percentage_1 = (PrtInt)(((PrtInt)100));
            landing_threshold_1 = (PrtInt)(((PrtInt)((IPrtValue)landing_threshold_local)?.Clone()));
            TMP_tmp0_7 = (PrtString)(((PrtString) String.Format("Battery Fail Safe Enabled!")));
            PModule.runtime.Logger.WriteLine("<PrintLog> " + TMP_tmp0_7);
            TMP_tmp1_5 = (PMachineValue)(currentMachine.self);
            TMP_tmp2_5 = (PEvent)(new eStartBatteryFailSafe(null));
            currentMachine.TrySendEvent(TMP_tmp1_5, (Event)TMP_tmp2_5);
            currentMachine.TryGotoState<Monitoring_1>();
            return;
        }
        public void Anon_10(Event currentMachine_dequeuedEvent)
        {
            BatteryFailSafe currentMachine = this;
            PrtInt TMP_tmp0_8 = ((PrtInt)0);
            PrtInt TMP_tmp1_6 = ((PrtInt)0);
            PrtString TMP_tmp2_6 = ((PrtString)"");
            PrtBool TMP_tmp3_4 = ((PrtBool)false);
            PrtString TMP_tmp4_4 = ((PrtString)"");
            PMachineValue TMP_tmp5_4 = null;
            PEvent TMP_tmp6_3 = null;
            PrtString TMP_tmp7_2 = ((PrtString)"");
            PMachineValue TMP_tmp8_1 = null;
            PEvent TMP_tmp9_1 = null;
            TMP_tmp0_8 = (PrtInt)((battery_percentage_1) - (((PrtInt)1)));
            battery_percentage_1 = TMP_tmp0_8;
            TMP_tmp1_6 = (PrtInt)(((PrtInt)((IPrtValue)battery_percentage_1)?.Clone()));
            TMP_tmp2_6 = (PrtString)(((PrtString) String.Format("battery updated, battery = {0}",TMP_tmp1_6)));
            PModule.runtime.Logger.WriteLine("<PrintLog> " + TMP_tmp2_6);
            TMP_tmp3_4 = (PrtBool)((battery_percentage_1) < (landing_threshold_1));
            if (TMP_tmp3_4)
            {
                TMP_tmp4_4 = (PrtString)(((PrtString) String.Format("battery below threshold, landing initiated!")));
                PModule.runtime.Logger.WriteLine("<PrintLog> " + TMP_tmp4_4);
                TMP_tmp5_4 = (PMachineValue)(currentMachine.self);
                TMP_tmp6_3 = (PEvent)(new eLanding(null));
                currentMachine.TrySendEvent(TMP_tmp5_4, (Event)TMP_tmp6_3);
                currentMachine.TryGotoState<Landing_1>();
                return;
            }
            else
            {
                TMP_tmp7_2 = (PrtString)(((PrtString) String.Format("battery above threshold, continue monitoring!")));
                PModule.runtime.Logger.WriteLine("<PrintLog> " + TMP_tmp7_2);
                TMP_tmp8_1 = (PMachineValue)(currentMachine.self);
                TMP_tmp9_1 = (PEvent)(new eUpdateBatteryPercentage(null));
                currentMachine.TrySendEvent(TMP_tmp8_1, (Event)TMP_tmp9_1);
                currentMachine.TryGotoState<Monitoring_1>();
                return;
            }
        }
        public void Anon_11(Event currentMachine_dequeuedEvent)
        {
            BatteryFailSafe currentMachine = this;
            PrtString TMP_tmp0_9 = ((PrtString)"");
            PMachineValue TMP_tmp1_7 = null;
            PEvent TMP_tmp2_7 = null;
            TMP_tmp0_9 = (PrtString)(((PrtString) String.Format("Landing initiated!")));
            PModule.runtime.Logger.WriteLine("<PrintLog> " + TMP_tmp0_9);
            TMP_tmp1_7 = (PMachineValue)(currentMachine.self);
            TMP_tmp2_7 = (PEvent)(new eLanded(null));
            currentMachine.TrySendEvent(TMP_tmp1_7, (Event)TMP_tmp2_7);
            currentMachine.TryGotoState<Landed_1>();
            return;
        }
        public void Anon_12(Event currentMachine_dequeuedEvent)
        {
            BatteryFailSafe currentMachine = this;
            PrtString TMP_tmp0_10 = ((PrtString)"");
            TMP_tmp0_10 = (PrtString)(((PrtString) String.Format("Landed!")));
            PModule.runtime.Logger.WriteLine("<PrintLog> " + TMP_tmp0_10);
        }
        [Start]
        [OnEntry(nameof(InitializeParametersFunction))]
        [OnEventGotoState(typeof(ConstructorEvent), typeof(Init_3))]
        class __InitState__ : State { }
        
        [OnEntry(nameof(Anon_9))]
        class Init_3 : State
        {
        }
        [OnEventDoAction(typeof(eStartBatteryFailSafe), nameof(Anon_10))]
        [OnEventDoAction(typeof(eUpdateBatteryPercentage), nameof(Anon_10))]
        class Monitoring_1 : State
        {
        }
        [OnEntry(nameof(Anon_11))]
        class Landing_1 : State
        {
        }
        [OnEntry(nameof(Anon_12))]
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
            this.sends.Add(nameof(eDroneMovementResponse));
            this.sends.Add(nameof(eFenceDistanced));
            this.sends.Add(nameof(eFenceRadiusRequest));
            this.sends.Add(nameof(eFenceRadiusResponse));
            this.sends.Add(nameof(eFenceReached));
            this.sends.Add(nameof(eLanded));
            this.sends.Add(nameof(eLanding));
            this.sends.Add(nameof(ePing));
            this.sends.Add(nameof(ePong));
            this.sends.Add(nameof(eRequestDroneMovement));
            this.sends.Add(nameof(eStartBatteryFailSafe));
            this.sends.Add(nameof(eStartGeoFence));
            this.sends.Add(nameof(eUpdateBatteryPercentage));
            this.sends.Add(nameof(eUpdateDroneBatteryRequest));
            this.sends.Add(nameof(eUpdateDroneMovementAndPosition));
            this.sends.Add(nameof(PHalt));
            this.receives.Add(nameof(eBatteryThresholdRequest));
            this.receives.Add(nameof(eBatteryThresholdResponse));
            this.receives.Add(nameof(eDroneMovementResponse));
            this.receives.Add(nameof(eFenceDistanced));
            this.receives.Add(nameof(eFenceRadiusRequest));
            this.receives.Add(nameof(eFenceRadiusResponse));
            this.receives.Add(nameof(eFenceReached));
            this.receives.Add(nameof(eLanded));
            this.receives.Add(nameof(eLanding));
            this.receives.Add(nameof(ePing));
            this.receives.Add(nameof(ePong));
            this.receives.Add(nameof(eRequestDroneMovement));
            this.receives.Add(nameof(eStartBatteryFailSafe));
            this.receives.Add(nameof(eStartGeoFence));
            this.receives.Add(nameof(eUpdateBatteryPercentage));
            this.receives.Add(nameof(eUpdateDroneBatteryRequest));
            this.receives.Add(nameof(eUpdateDroneMovementAndPosition));
            this.receives.Add(nameof(PHalt));
        }
        
        public void Anon_13(Event currentMachine_dequeuedEvent)
        {
            GeoFence currentMachine = this;
            PrtString TMP_tmp0_11 = ((PrtString)"");
            PMachineValue TMP_tmp1_8 = null;
            PEvent TMP_tmp2_8 = null;
            fence_alt_min = (PrtInt)(((PrtInt)0));
            fence_alt_max = (PrtInt)(((PrtInt)100));
            fence_radius = (PrtInt)(((PrtInt)100));
            drone_horizontal_distance_to_origin = (PrtInt)(((PrtInt)0));
            drone_altitude = (PrtInt)(((PrtInt)0));
            TMP_tmp0_11 = (PrtString)(((PrtString) String.Format("Geo Fence Enabled!")));
            PModule.runtime.Logger.WriteLine("<PrintLog> " + TMP_tmp0_11);
            TMP_tmp1_8 = (PMachineValue)(currentMachine.self);
            TMP_tmp2_8 = (PEvent)(new eStartGeoFence(null));
            currentMachine.TrySendEvent(TMP_tmp1_8, (Event)TMP_tmp2_8);
            currentMachine.TryGotoState<Monitoring_2>();
            return;
        }
        public void Anon_14(Event currentMachine_dequeuedEvent)
        {
            GeoFence currentMachine = this;
            PMachineValue TMP_tmp0_12 = null;
            PEvent TMP_tmp1_9 = null;
            TMP_tmp0_12 = (PMachineValue)(currentMachine.self);
            TMP_tmp1_9 = (PEvent)(new eRequestDroneMovement(null));
            currentMachine.TrySendEvent(TMP_tmp0_12, (Event)TMP_tmp1_9);
            currentMachine.TryGotoState<GenerateMovement>();
            return;
        }
        public void Anon_15(Event currentMachine_dequeuedEvent)
        {
            GeoFence currentMachine = this;
            PrtNamedTuple response = (PrtNamedTuple)(gotoPayload ?? ((PEvent)currentMachine_dequeuedEvent).Payload);
            this.gotoPayload = null;
            PrtInt TMP_tmp0_13 = ((PrtInt)0);
            PrtInt TMP_tmp1_10 = ((PrtInt)0);
            PrtBool TMP_tmp2_9 = ((PrtBool)false);
            PMachineValue TMP_tmp3_5 = null;
            PEvent TMP_tmp4_5 = null;
            PrtInt TMP_tmp5_5 = ((PrtInt)0);
            PrtInt TMP_tmp6_4 = ((PrtInt)0);
            PrtBool TMP_tmp7_3 = ((PrtBool)false);
            PrtInt TMP_tmp8_2 = ((PrtInt)0);
            PrtInt TMP_tmp9_2 = ((PrtInt)0);
            PrtBool TMP_tmp10 = ((PrtBool)false);
            PrtBool TMP_tmp11 = ((PrtBool)false);
            PMachineValue TMP_tmp12 = null;
            PEvent TMP_tmp13 = null;
            PrtInt TMP_tmp14 = ((PrtInt)0);
            PrtInt TMP_tmp15 = ((PrtInt)0);
            PrtInt TMP_tmp16 = ((PrtInt)0);
            PrtInt TMP_tmp17 = ((PrtInt)0);
            TMP_tmp0_13 = (PrtInt)(((PrtNamedTuple)response)["horizontal_movement"]);
            TMP_tmp1_10 = (PrtInt)((drone_horizontal_distance_to_origin) + (TMP_tmp0_13));
            TMP_tmp2_9 = (PrtBool)((TMP_tmp1_10) > (fence_radius));
            if (TMP_tmp2_9)
            {
                TMP_tmp3_5 = (PMachineValue)(currentMachine.self);
                TMP_tmp4_5 = (PEvent)(new eFenceReached(null));
                currentMachine.TrySendEvent(TMP_tmp3_5, (Event)TMP_tmp4_5);
                currentMachine.TryGotoState<Holding>();
                return;
            }
            else
            {
                TMP_tmp5_5 = (PrtInt)(((PrtNamedTuple)response)["vertical_movement"]);
                TMP_tmp6_4 = (PrtInt)((drone_altitude) + (TMP_tmp5_5));
                TMP_tmp7_3 = (PrtBool)((TMP_tmp6_4) < (fence_alt_min));
                TMP_tmp11 = (PrtBool)(((PrtBool)((IPrtValue)TMP_tmp7_3)?.Clone()));
                if (TMP_tmp11)
                {
                }
                else
                {
                    TMP_tmp8_2 = (PrtInt)(((PrtNamedTuple)response)["vertical_movement"]);
                    TMP_tmp9_2 = (PrtInt)((drone_altitude) + (TMP_tmp8_2));
                    TMP_tmp10 = (PrtBool)((TMP_tmp9_2) > (fence_alt_max));
                    TMP_tmp11 = (PrtBool)(((PrtBool)((IPrtValue)TMP_tmp10)?.Clone()));
                }
                if (TMP_tmp11)
                {
                    TMP_tmp12 = (PMachineValue)(currentMachine.self);
                    TMP_tmp13 = (PEvent)(new eFenceReached(null));
                    currentMachine.TrySendEvent(TMP_tmp12, (Event)TMP_tmp13);
                    currentMachine.TryGotoState<Holding>();
                    return;
                }
                else
                {
                    TMP_tmp14 = (PrtInt)(((PrtNamedTuple)response)["vertical_movement"]);
                    TMP_tmp15 = (PrtInt)((drone_altitude) + (TMP_tmp14));
                    drone_altitude = TMP_tmp15;
                    TMP_tmp16 = (PrtInt)(((PrtNamedTuple)response)["horizontal_movement"]);
                    TMP_tmp17 = (PrtInt)((drone_horizontal_distance_to_origin) + (TMP_tmp16));
                    drone_horizontal_distance_to_origin = TMP_tmp17;
                }
            }
        }
        public void Anon_16(Event currentMachine_dequeuedEvent)
        {
            GeoFence currentMachine = this;
            PrtString TMP_tmp0_14 = ((PrtString)"");
            PMachineValue TMP_tmp1_11 = null;
            PEvent TMP_tmp2_10 = null;
            TMP_tmp0_14 = (PrtString)(((PrtString) String.Format("Fence Reached! Starting Holding Pattern")));
            PModule.runtime.Logger.WriteLine("<PrintLog> " + TMP_tmp0_14);
            TMP_tmp1_11 = (PMachineValue)(currentMachine.self);
            TMP_tmp2_10 = (PEvent)(new eFenceDistanced(null));
            currentMachine.TrySendEvent(TMP_tmp1_11, (Event)TMP_tmp2_10);
            currentMachine.TryGotoState<Monitoring_2>();
            return;
        }
        public void Anon_17(Event currentMachine_dequeuedEvent)
        {
            GeoFence currentMachine = this;
            PrtNamedTuple response_1 = (new PrtNamedTuple(new string[]{"horizontal_movement","vertical_movement"},((PrtInt)0), ((PrtInt)0)));
            PrtInt TMP_tmp0_15 = ((PrtInt)0);
            PrtInt TMP_tmp1_12 = ((PrtInt)0);
            PrtInt TMP_tmp2_11 = ((PrtInt)0);
            PrtInt TMP_tmp3_6 = ((PrtInt)0);
            PMachineValue TMP_tmp4_6 = null;
            PEvent TMP_tmp5_6 = null;
            PrtNamedTuple TMP_tmp6_5 = (new PrtNamedTuple(new string[]{"horizontal_movement","vertical_movement"},((PrtInt)0), ((PrtInt)0)));
            TMP_tmp0_15 = (PrtInt)(((PrtInt)currentMachine.TryRandom(((PrtInt)20))));
            TMP_tmp1_12 = (PrtInt)((TMP_tmp0_15) - (((PrtInt)10)));
            ((PrtNamedTuple)response_1)["horizontal_movement"] = TMP_tmp1_12;
            TMP_tmp2_11 = (PrtInt)(((PrtInt)currentMachine.TryRandom(((PrtInt)20))));
            TMP_tmp3_6 = (PrtInt)((TMP_tmp2_11) - (((PrtInt)10)));
            ((PrtNamedTuple)response_1)["vertical_movement"] = TMP_tmp3_6;
            TMP_tmp4_6 = (PMachineValue)(currentMachine.self);
            TMP_tmp5_6 = (PEvent)(new eDroneMovementResponse((new PrtNamedTuple(new string[]{"horizontal_movement","vertical_movement"},((PrtInt)0), ((PrtInt)0)))));
            TMP_tmp6_5 = (PrtNamedTuple)(((PrtNamedTuple)((IPrtValue)response_1)?.Clone()));
            currentMachine.TrySendEvent(TMP_tmp4_6, (Event)TMP_tmp5_6, TMP_tmp6_5);
            currentMachine.TryGotoState<Monitoring_2>();
            return;
        }
        [Start]
        [OnEntry(nameof(InitializeParametersFunction))]
        [OnEventGotoState(typeof(ConstructorEvent), typeof(Init_4))]
        class __InitState__ : State { }
        
        [OnEntry(nameof(Anon_13))]
        class Init_4 : State
        {
        }
        [OnEventDoAction(typeof(eStartGeoFence), nameof(Anon_14))]
        [OnEventDoAction(typeof(eFenceDistanced), nameof(Anon_14))]
        [OnEventDoAction(typeof(eDroneMovementResponse), nameof(Anon_15))]
        class Monitoring_2 : State
        {
        }
        [OnEventDoAction(typeof(eFenceReached), nameof(Anon_16))]
        class Holding : State
        {
        }
        [OnEventDoAction(typeof(eRequestDroneMovement), nameof(Anon_17))]
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
        private PrtFloat powerConsumptionRate = ((PrtFloat)0.0);
        private PrtFloat batteryPercentage = ((PrtFloat)0.0);
        private PrtFloat droneHorizontalPosition = ((PrtFloat)0.0);
        private PrtFloat droneVerticalPosition = ((PrtFloat)0.0);
        private PrtFloat cumulativeDroneMovement = ((PrtFloat)0.0);
        public class ConstructorEvent : PEvent{public ConstructorEvent(IPrtValue val) : base(val) { }}
        
        protected override Event GetConstructorEvent(IPrtValue value) { return new ConstructorEvent((IPrtValue)value); }
        public PowerManagement() {
            this.sends.Add(nameof(eBatteryThresholdRequest));
            this.sends.Add(nameof(eBatteryThresholdResponse));
            this.sends.Add(nameof(eDroneMovementResponse));
            this.sends.Add(nameof(eFenceDistanced));
            this.sends.Add(nameof(eFenceRadiusRequest));
            this.sends.Add(nameof(eFenceRadiusResponse));
            this.sends.Add(nameof(eFenceReached));
            this.sends.Add(nameof(eLanded));
            this.sends.Add(nameof(eLanding));
            this.sends.Add(nameof(ePing));
            this.sends.Add(nameof(ePong));
            this.sends.Add(nameof(eRequestDroneMovement));
            this.sends.Add(nameof(eStartBatteryFailSafe));
            this.sends.Add(nameof(eStartGeoFence));
            this.sends.Add(nameof(eUpdateBatteryPercentage));
            this.sends.Add(nameof(eUpdateDroneBatteryRequest));
            this.sends.Add(nameof(eUpdateDroneMovementAndPosition));
            this.sends.Add(nameof(PHalt));
            this.receives.Add(nameof(eBatteryThresholdRequest));
            this.receives.Add(nameof(eBatteryThresholdResponse));
            this.receives.Add(nameof(eDroneMovementResponse));
            this.receives.Add(nameof(eFenceDistanced));
            this.receives.Add(nameof(eFenceRadiusRequest));
            this.receives.Add(nameof(eFenceRadiusResponse));
            this.receives.Add(nameof(eFenceReached));
            this.receives.Add(nameof(eLanded));
            this.receives.Add(nameof(eLanding));
            this.receives.Add(nameof(ePing));
            this.receives.Add(nameof(ePong));
            this.receives.Add(nameof(eRequestDroneMovement));
            this.receives.Add(nameof(eStartBatteryFailSafe));
            this.receives.Add(nameof(eStartGeoFence));
            this.receives.Add(nameof(eUpdateBatteryPercentage));
            this.receives.Add(nameof(eUpdateDroneBatteryRequest));
            this.receives.Add(nameof(eUpdateDroneMovementAndPosition));
            this.receives.Add(nameof(PHalt));
        }
        
        public void Anon_18(Event currentMachine_dequeuedEvent)
        {
            PowerManagement currentMachine = this;
            powerConsumptionRate = (PrtFloat)(((PrtFloat)1));
            droneHorizontalPosition = (PrtFloat)(((PrtFloat)0));
            droneVerticalPosition = (PrtFloat)(((PrtFloat)0));
        }
        public void Anon_19(Event currentMachine_dequeuedEvent)
        {
            PowerManagement currentMachine = this;
            PrtNamedTuple request = (PrtNamedTuple)(gotoPayload ?? ((PEvent)currentMachine_dequeuedEvent).Payload);
            this.gotoPayload = null;
            PMachineValue TMP_tmp0_16 = null;
            PMachineValue TMP_tmp1_13 = null;
            PEvent TMP_tmp2_12 = null;
            PrtFloat TMP_tmp3_7 = ((PrtFloat)0.0);
            PrtNamedTuple TMP_tmp4_7 = (new PrtNamedTuple(new string[]{"batteryThreshold"},((PrtFloat)0.0)));
            TMP_tmp0_16 = (PMachineValue)(((PrtNamedTuple)request)["source"]);
            TMP_tmp1_13 = (PMachineValue)(((PMachineValue)((IPrtValue)TMP_tmp0_16)?.Clone()));
            TMP_tmp2_12 = (PEvent)(new eBatteryThresholdResponse((new PrtNamedTuple(new string[]{"batteryThreshold"},((PrtFloat)0.0)))));
            TMP_tmp3_7 = (PrtFloat)(((PrtFloat)0));
            TMP_tmp4_7 = (PrtNamedTuple)((new PrtNamedTuple(new string[]{"batteryThreshold"}, TMP_tmp3_7)));
            currentMachine.TrySendEvent(TMP_tmp1_13, (Event)TMP_tmp2_12, TMP_tmp4_7);
        }
        public void Anon_20(Event currentMachine_dequeuedEvent)
        {
            PowerManagement currentMachine = this;
            PrtNamedTuple request_1 = (PrtNamedTuple)(gotoPayload ?? ((PEvent)currentMachine_dequeuedEvent).Payload);
            this.gotoPayload = null;
            PrtFloat TMP_tmp0_17 = ((PrtFloat)0.0);
            PrtFloat TMP_tmp1_14 = ((PrtFloat)0.0);
            TMP_tmp0_17 = (PrtFloat)(((PrtNamedTuple)request_1)["batteryPercentage"]);
            TMP_tmp1_14 = (PrtFloat)(((PrtFloat)((IPrtValue)TMP_tmp0_17)?.Clone()));
            batteryPercentage = TMP_tmp1_14;
        }
        public void Anon_21(Event currentMachine_dequeuedEvent)
        {
            PowerManagement currentMachine = this;
            PrtNamedTuple request_2 = (PrtNamedTuple)(gotoPayload ?? ((PEvent)currentMachine_dequeuedEvent).Payload);
            this.gotoPayload = null;
            PMachineValue TMP_tmp0_18 = null;
            PMachineValue TMP_tmp1_15 = null;
            PEvent TMP_tmp2_13 = null;
            PrtFloat TMP_tmp3_8 = ((PrtFloat)0.0);
            PrtNamedTuple TMP_tmp4_8 = (new PrtNamedTuple(new string[]{"fenceRadius"},((PrtFloat)0.0)));
            TMP_tmp0_18 = (PMachineValue)(((PrtNamedTuple)request_2)["source"]);
            TMP_tmp1_15 = (PMachineValue)(((PMachineValue)((IPrtValue)TMP_tmp0_18)?.Clone()));
            TMP_tmp2_13 = (PEvent)(new eFenceRadiusResponse((new PrtNamedTuple(new string[]{"fenceRadius"},((PrtFloat)0.0)))));
            TMP_tmp3_8 = (PrtFloat)(((PrtFloat)0));
            TMP_tmp4_8 = (PrtNamedTuple)((new PrtNamedTuple(new string[]{"fenceRadius"}, TMP_tmp3_8)));
            currentMachine.TrySendEvent(TMP_tmp1_15, (Event)TMP_tmp2_13, TMP_tmp4_8);
        }
        public void Anon_22(Event currentMachine_dequeuedEvent)
        {
            PowerManagement currentMachine = this;
            PrtNamedTuple request_3 = (PrtNamedTuple)(gotoPayload ?? ((PEvent)currentMachine_dequeuedEvent).Payload);
            this.gotoPayload = null;
            PrtFloat TMP_tmp0_19 = ((PrtFloat)0.0);
            PrtFloat TMP_tmp1_16 = ((PrtFloat)0.0);
            PrtFloat TMP_tmp2_14 = ((PrtFloat)0.0);
            PrtFloat TMP_tmp3_9 = ((PrtFloat)0.0);
            PrtFloat TMP_tmp4_9 = ((PrtFloat)0.0);
            PrtFloat TMP_tmp5_7 = ((PrtFloat)0.0);
            TMP_tmp0_19 = (PrtFloat)(((PrtNamedTuple)request_3)["droneHorizontalPosition"]);
            TMP_tmp1_16 = (PrtFloat)(((PrtFloat)((IPrtValue)TMP_tmp0_19)?.Clone()));
            droneHorizontalPosition = TMP_tmp1_16;
            TMP_tmp2_14 = (PrtFloat)(((PrtNamedTuple)request_3)["droneVerticalPosition"]);
            TMP_tmp3_9 = (PrtFloat)(((PrtFloat)((IPrtValue)TMP_tmp2_14)?.Clone()));
            droneVerticalPosition = TMP_tmp3_9;
            TMP_tmp4_9 = (PrtFloat)(((PrtNamedTuple)request_3)["droneMovement"]);
            TMP_tmp5_7 = (PrtFloat)((cumulativeDroneMovement) + (TMP_tmp4_9));
            cumulativeDroneMovement = TMP_tmp5_7;
        }
        [Start]
        [OnEntry(nameof(InitializeParametersFunction))]
        [OnEventGotoState(typeof(ConstructorEvent), typeof(Init_5))]
        class __InitState__ : State { }
        
        [OnEntry(nameof(Anon_18))]
        class Init_5 : State
        {
        }
        [OnEventDoAction(typeof(eBatteryThresholdRequest), nameof(Anon_19))]
        [OnEventDoAction(typeof(eUpdateDroneBatteryRequest), nameof(Anon_20))]
        [OnEventDoAction(typeof(eFenceRadiusRequest), nameof(Anon_21))]
        [OnEventDoAction(typeof(eUpdateDroneMovementAndPosition), nameof(Anon_22))]
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
        private PrtInt fence_alt_min_1 = ((PrtInt)0);
        private PrtInt fence_alt_max_1 = ((PrtInt)0);
        private PrtInt fence_radius_1 = ((PrtInt)0);
        private PrtInt drone_horizontal_distance_to_origin_1 = ((PrtInt)0);
        private PrtInt drone_altitude_1 = ((PrtInt)0);
        public class ConstructorEvent : PEvent{public ConstructorEvent(PMachineValue val) : base(val) { }}
        
        protected override Event GetConstructorEvent(IPrtValue value) { return new ConstructorEvent((PMachineValue)value); }
        public GeoFenceModified() {
            this.sends.Add(nameof(eBatteryThresholdRequest));
            this.sends.Add(nameof(eBatteryThresholdResponse));
            this.sends.Add(nameof(eDroneMovementResponse));
            this.sends.Add(nameof(eFenceDistanced));
            this.sends.Add(nameof(eFenceRadiusRequest));
            this.sends.Add(nameof(eFenceRadiusResponse));
            this.sends.Add(nameof(eFenceReached));
            this.sends.Add(nameof(eLanded));
            this.sends.Add(nameof(eLanding));
            this.sends.Add(nameof(ePing));
            this.sends.Add(nameof(ePong));
            this.sends.Add(nameof(eRequestDroneMovement));
            this.sends.Add(nameof(eStartBatteryFailSafe));
            this.sends.Add(nameof(eStartGeoFence));
            this.sends.Add(nameof(eUpdateBatteryPercentage));
            this.sends.Add(nameof(eUpdateDroneBatteryRequest));
            this.sends.Add(nameof(eUpdateDroneMovementAndPosition));
            this.sends.Add(nameof(PHalt));
            this.receives.Add(nameof(eBatteryThresholdRequest));
            this.receives.Add(nameof(eBatteryThresholdResponse));
            this.receives.Add(nameof(eDroneMovementResponse));
            this.receives.Add(nameof(eFenceDistanced));
            this.receives.Add(nameof(eFenceRadiusRequest));
            this.receives.Add(nameof(eFenceRadiusResponse));
            this.receives.Add(nameof(eFenceReached));
            this.receives.Add(nameof(eLanded));
            this.receives.Add(nameof(eLanding));
            this.receives.Add(nameof(ePing));
            this.receives.Add(nameof(ePong));
            this.receives.Add(nameof(eRequestDroneMovement));
            this.receives.Add(nameof(eStartBatteryFailSafe));
            this.receives.Add(nameof(eStartGeoFence));
            this.receives.Add(nameof(eUpdateBatteryPercentage));
            this.receives.Add(nameof(eUpdateDroneBatteryRequest));
            this.receives.Add(nameof(eUpdateDroneMovementAndPosition));
            this.receives.Add(nameof(PHalt));
        }
        
        public void Anon_23(Event currentMachine_dequeuedEvent)
        {
            GeoFenceModified currentMachine = this;
            PMachineValue powerManagerLocal_1 = (PMachineValue)(gotoPayload ?? ((PEvent)currentMachine_dequeuedEvent).Payload);
            this.gotoPayload = null;
            PrtString TMP_tmp0_20 = ((PrtString)"");
            PMachineValue TMP_tmp1_17 = null;
            PEvent TMP_tmp2_15 = null;
            powerManager_1 = (PMachineValue)(((PMachineValue)((IPrtValue)powerManagerLocal_1)?.Clone()));
            fence_alt_min_1 = (PrtInt)(((PrtInt)0));
            fence_alt_max_1 = (PrtInt)(((PrtInt)100));
            fence_radius_1 = (PrtInt)(((PrtInt)100));
            drone_horizontal_distance_to_origin_1 = (PrtInt)(((PrtInt)0));
            drone_altitude_1 = (PrtInt)(((PrtInt)0));
            TMP_tmp0_20 = (PrtString)(((PrtString) String.Format("Geo Fence Enabled!")));
            PModule.runtime.Logger.WriteLine("<PrintLog> " + TMP_tmp0_20);
            TMP_tmp1_17 = (PMachineValue)(currentMachine.self);
            TMP_tmp2_15 = (PEvent)(new eStartGeoFence(null));
            currentMachine.TrySendEvent(TMP_tmp1_17, (Event)TMP_tmp2_15);
            currentMachine.TryGotoState<Monitoring_3>();
            return;
        }
        public void Anon_24(Event currentMachine_dequeuedEvent)
        {
            GeoFenceModified currentMachine = this;
            PMachineValue TMP_tmp0_21 = null;
            PEvent TMP_tmp1_18 = null;
            TMP_tmp0_21 = (PMachineValue)(currentMachine.self);
            TMP_tmp1_18 = (PEvent)(new eRequestDroneMovement(null));
            currentMachine.TrySendEvent(TMP_tmp0_21, (Event)TMP_tmp1_18);
            currentMachine.TryGotoState<GenerateMovement_1>();
            return;
        }
        public void Anon_25(Event currentMachine_dequeuedEvent)
        {
            GeoFenceModified currentMachine = this;
            PrtNamedTuple response_2 = (PrtNamedTuple)(gotoPayload ?? ((PEvent)currentMachine_dequeuedEvent).Payload);
            this.gotoPayload = null;
            PrtInt TMP_tmp0_22 = ((PrtInt)0);
            PrtInt TMP_tmp1_19 = ((PrtInt)0);
            PrtBool TMP_tmp2_16 = ((PrtBool)false);
            PMachineValue TMP_tmp3_10 = null;
            PEvent TMP_tmp4_10 = null;
            PrtInt TMP_tmp5_8 = ((PrtInt)0);
            PrtInt TMP_tmp6_6 = ((PrtInt)0);
            PrtBool TMP_tmp7_4 = ((PrtBool)false);
            PrtInt TMP_tmp8_3 = ((PrtInt)0);
            PrtInt TMP_tmp9_3 = ((PrtInt)0);
            PrtBool TMP_tmp10_1 = ((PrtBool)false);
            PrtBool TMP_tmp11_1 = ((PrtBool)false);
            PMachineValue TMP_tmp12_1 = null;
            PEvent TMP_tmp13_1 = null;
            PrtInt TMP_tmp14_1 = ((PrtInt)0);
            PrtInt TMP_tmp15_1 = ((PrtInt)0);
            PrtInt TMP_tmp16_1 = ((PrtInt)0);
            PrtInt TMP_tmp17_1 = ((PrtInt)0);
            TMP_tmp0_22 = (PrtInt)(((PrtNamedTuple)response_2)["horizontal_movement"]);
            TMP_tmp1_19 = (PrtInt)((drone_horizontal_distance_to_origin_1) + (TMP_tmp0_22));
            TMP_tmp2_16 = (PrtBool)((TMP_tmp1_19) > (fence_radius_1));
            if (TMP_tmp2_16)
            {
                TMP_tmp3_10 = (PMachineValue)(currentMachine.self);
                TMP_tmp4_10 = (PEvent)(new eFenceReached(null));
                currentMachine.TrySendEvent(TMP_tmp3_10, (Event)TMP_tmp4_10);
                currentMachine.TryGotoState<Holding_1>();
                return;
            }
            else
            {
                TMP_tmp5_8 = (PrtInt)(((PrtNamedTuple)response_2)["vertical_movement"]);
                TMP_tmp6_6 = (PrtInt)((drone_altitude_1) + (TMP_tmp5_8));
                TMP_tmp7_4 = (PrtBool)((TMP_tmp6_6) < (fence_alt_min_1));
                TMP_tmp11_1 = (PrtBool)(((PrtBool)((IPrtValue)TMP_tmp7_4)?.Clone()));
                if (TMP_tmp11_1)
                {
                }
                else
                {
                    TMP_tmp8_3 = (PrtInt)(((PrtNamedTuple)response_2)["vertical_movement"]);
                    TMP_tmp9_3 = (PrtInt)((drone_altitude_1) + (TMP_tmp8_3));
                    TMP_tmp10_1 = (PrtBool)((TMP_tmp9_3) > (fence_alt_max_1));
                    TMP_tmp11_1 = (PrtBool)(((PrtBool)((IPrtValue)TMP_tmp10_1)?.Clone()));
                }
                if (TMP_tmp11_1)
                {
                    TMP_tmp12_1 = (PMachineValue)(currentMachine.self);
                    TMP_tmp13_1 = (PEvent)(new eFenceReached(null));
                    currentMachine.TrySendEvent(TMP_tmp12_1, (Event)TMP_tmp13_1);
                    currentMachine.TryGotoState<Holding_1>();
                    return;
                }
                else
                {
                    TMP_tmp14_1 = (PrtInt)(((PrtNamedTuple)response_2)["vertical_movement"]);
                    TMP_tmp15_1 = (PrtInt)((drone_altitude_1) + (TMP_tmp14_1));
                    drone_altitude_1 = TMP_tmp15_1;
                    TMP_tmp16_1 = (PrtInt)(((PrtNamedTuple)response_2)["horizontal_movement"]);
                    TMP_tmp17_1 = (PrtInt)((drone_horizontal_distance_to_origin_1) + (TMP_tmp16_1));
                    drone_horizontal_distance_to_origin_1 = TMP_tmp17_1;
                }
            }
        }
        public void Anon_26(Event currentMachine_dequeuedEvent)
        {
            GeoFenceModified currentMachine = this;
            PrtString TMP_tmp0_23 = ((PrtString)"");
            PMachineValue TMP_tmp1_20 = null;
            PEvent TMP_tmp2_17 = null;
            TMP_tmp0_23 = (PrtString)(((PrtString) String.Format("Fence Reached! Starting Holding Pattern")));
            PModule.runtime.Logger.WriteLine("<PrintLog> " + TMP_tmp0_23);
            TMP_tmp1_20 = (PMachineValue)(currentMachine.self);
            TMP_tmp2_17 = (PEvent)(new eFenceDistanced(null));
            currentMachine.TrySendEvent(TMP_tmp1_20, (Event)TMP_tmp2_17);
            currentMachine.TryGotoState<Monitoring_3>();
            return;
        }
        public void Anon_27(Event currentMachine_dequeuedEvent)
        {
            GeoFenceModified currentMachine = this;
            PrtNamedTuple response_3 = (new PrtNamedTuple(new string[]{"horizontal_movement","vertical_movement"},((PrtInt)0), ((PrtInt)0)));
            PrtInt TMP_tmp0_24 = ((PrtInt)0);
            PrtInt TMP_tmp1_21 = ((PrtInt)0);
            PrtInt TMP_tmp2_18 = ((PrtInt)0);
            PrtInt TMP_tmp3_11 = ((PrtInt)0);
            PMachineValue TMP_tmp4_11 = null;
            PEvent TMP_tmp5_9 = null;
            PrtNamedTuple TMP_tmp6_7 = (new PrtNamedTuple(new string[]{"horizontal_movement","vertical_movement"},((PrtInt)0), ((PrtInt)0)));
            TMP_tmp0_24 = (PrtInt)(((PrtInt)currentMachine.TryRandom(((PrtInt)20))));
            TMP_tmp1_21 = (PrtInt)((TMP_tmp0_24) - (((PrtInt)10)));
            ((PrtNamedTuple)response_3)["horizontal_movement"] = TMP_tmp1_21;
            TMP_tmp2_18 = (PrtInt)(((PrtInt)currentMachine.TryRandom(((PrtInt)20))));
            TMP_tmp3_11 = (PrtInt)((TMP_tmp2_18) - (((PrtInt)10)));
            ((PrtNamedTuple)response_3)["vertical_movement"] = TMP_tmp3_11;
            TMP_tmp4_11 = (PMachineValue)(currentMachine.self);
            TMP_tmp5_9 = (PEvent)(new eDroneMovementResponse((new PrtNamedTuple(new string[]{"horizontal_movement","vertical_movement"},((PrtInt)0), ((PrtInt)0)))));
            TMP_tmp6_7 = (PrtNamedTuple)(((PrtNamedTuple)((IPrtValue)response_3)?.Clone()));
            currentMachine.TrySendEvent(TMP_tmp4_11, (Event)TMP_tmp5_9, TMP_tmp6_7);
            currentMachine.TryGotoState<Monitoring_3>();
            return;
        }
        [Start]
        [OnEntry(nameof(InitializeParametersFunction))]
        [OnEventGotoState(typeof(ConstructorEvent), typeof(Init_6))]
        class __InitState__ : State { }
        
        [OnEntry(nameof(Anon_23))]
        class Init_6 : State
        {
        }
        [OnEventDoAction(typeof(eStartGeoFence), nameof(Anon_24))]
        [OnEventDoAction(typeof(eFenceDistanced), nameof(Anon_24))]
        [OnEventDoAction(typeof(eDroneMovementResponse), nameof(Anon_25))]
        class Monitoring_3 : State
        {
        }
        [OnEventDoAction(typeof(eFenceReached), nameof(Anon_26))]
        class Holding_1 : State
        {
        }
        [OnEventDoAction(typeof(eRequestDroneMovement), nameof(Anon_27))]
        class GenerateMovement_1 : State
        {
        }
    }
}
namespace PImplementation
{
    internal partial class AlwaysCorrect : PMonitor
    {
        private PrtInt global_counter = ((PrtInt)0);
        static AlwaysCorrect() {
            observes.Add(nameof(ePing));
            observes.Add(nameof(ePong));
        }
        
        public void Anon_28(Event currentMachine_dequeuedEvent)
        {
            AlwaysCorrect currentMachine = this;
            global_counter = (PrtInt)(((PrtInt)0));
            currentMachine.TryGotoState<WaitForPingPongEvents>();
            return;
        }
        public void Anon_29(Event currentMachine_dequeuedEvent)
        {
            AlwaysCorrect currentMachine = this;
            PrtInt TMP_tmp0_25 = ((PrtInt)0);
            PrtInt TMP_tmp1_22 = ((PrtInt)0);
            PrtString TMP_tmp2_19 = ((PrtString)"");
            TMP_tmp0_25 = (PrtInt)((global_counter) + (((PrtInt)1)));
            global_counter = TMP_tmp0_25;
            TMP_tmp1_22 = (PrtInt)(((PrtInt)((IPrtValue)global_counter)?.Clone()));
            TMP_tmp2_19 = (PrtString)(((PrtString) String.Format("Ping intialized, global_counter = {0}",TMP_tmp1_22)));
            PModule.runtime.Logger.WriteLine("<PrintLog> " + TMP_tmp2_19);
        }
        public void Anon_30(Event currentMachine_dequeuedEvent)
        {
            AlwaysCorrect currentMachine = this;
            PrtInt TMP_tmp0_26 = ((PrtInt)0);
            PrtInt TMP_tmp1_23 = ((PrtInt)0);
            PrtString TMP_tmp2_20 = ((PrtString)"");
            TMP_tmp0_26 = (PrtInt)((global_counter) + (((PrtInt)1)));
            global_counter = TMP_tmp0_26;
            TMP_tmp1_23 = (PrtInt)(((PrtInt)((IPrtValue)global_counter)?.Clone()));
            TMP_tmp2_20 = (PrtString)(((PrtString) String.Format("Ping intialized, global_counter = {0}",TMP_tmp1_23)));
            PModule.runtime.Logger.WriteLine("<PrintLog> " + TMP_tmp2_20);
        }
        [Start]
        [OnEntry(nameof(Anon_28))]
        class Init_7 : State
        {
        }
        [Hot]
        [OnEventDoAction(typeof(ePing), nameof(Anon_29))]
        [OnEventDoAction(typeof(ePong), nameof(Anon_30))]
        class WaitForPingPongEvents : State
        {
        }
    }
}
namespace PImplementation
{
    internal partial class Test_BatteryFailSafe : PMachine
    {
        public class ConstructorEvent : PEvent{public ConstructorEvent(IPrtValue val) : base(val) { }}
        
        protected override Event GetConstructorEvent(IPrtValue value) { return new ConstructorEvent((IPrtValue)value); }
        public Test_BatteryFailSafe() {
            this.sends.Add(nameof(eBatteryThresholdRequest));
            this.sends.Add(nameof(eBatteryThresholdResponse));
            this.sends.Add(nameof(eDroneMovementResponse));
            this.sends.Add(nameof(eFenceDistanced));
            this.sends.Add(nameof(eFenceRadiusRequest));
            this.sends.Add(nameof(eFenceRadiusResponse));
            this.sends.Add(nameof(eFenceReached));
            this.sends.Add(nameof(eLanded));
            this.sends.Add(nameof(eLanding));
            this.sends.Add(nameof(ePing));
            this.sends.Add(nameof(ePong));
            this.sends.Add(nameof(eRequestDroneMovement));
            this.sends.Add(nameof(eStartBatteryFailSafe));
            this.sends.Add(nameof(eStartGeoFence));
            this.sends.Add(nameof(eUpdateBatteryPercentage));
            this.sends.Add(nameof(eUpdateDroneBatteryRequest));
            this.sends.Add(nameof(eUpdateDroneMovementAndPosition));
            this.sends.Add(nameof(PHalt));
            this.receives.Add(nameof(eBatteryThresholdRequest));
            this.receives.Add(nameof(eBatteryThresholdResponse));
            this.receives.Add(nameof(eDroneMovementResponse));
            this.receives.Add(nameof(eFenceDistanced));
            this.receives.Add(nameof(eFenceRadiusRequest));
            this.receives.Add(nameof(eFenceRadiusResponse));
            this.receives.Add(nameof(eFenceReached));
            this.receives.Add(nameof(eLanded));
            this.receives.Add(nameof(eLanding));
            this.receives.Add(nameof(ePing));
            this.receives.Add(nameof(ePong));
            this.receives.Add(nameof(eRequestDroneMovement));
            this.receives.Add(nameof(eStartBatteryFailSafe));
            this.receives.Add(nameof(eStartGeoFence));
            this.receives.Add(nameof(eUpdateBatteryPercentage));
            this.receives.Add(nameof(eUpdateDroneBatteryRequest));
            this.receives.Add(nameof(eUpdateDroneMovementAndPosition));
            this.receives.Add(nameof(PHalt));
            this.creates.Add(nameof(I_BatteryFailSafe));
        }
        
        public void Anon_31(Event currentMachine_dequeuedEvent)
        {
            Test_BatteryFailSafe currentMachine = this;
            PrtInt TMP_tmp0_27 = ((PrtInt)0);
            TMP_tmp0_27 = (PrtInt)(((PrtInt)20));
            currentMachine.CreateInterface<I_BatteryFailSafe>(currentMachine, TMP_tmp0_27);
        }
        [Start]
        [OnEntry(nameof(InitializeParametersFunction))]
        [OnEventGotoState(typeof(ConstructorEvent), typeof(Init_8))]
        class __InitState__ : State { }
        
        [OnEntry(nameof(Anon_31))]
        class Init_8 : State
        {
        }
    }
}
namespace PImplementation
{
    internal partial class Test_GeoFence : PMachine
    {
        public class ConstructorEvent : PEvent{public ConstructorEvent(IPrtValue val) : base(val) { }}
        
        protected override Event GetConstructorEvent(IPrtValue value) { return new ConstructorEvent((IPrtValue)value); }
        public Test_GeoFence() {
            this.sends.Add(nameof(eBatteryThresholdRequest));
            this.sends.Add(nameof(eBatteryThresholdResponse));
            this.sends.Add(nameof(eDroneMovementResponse));
            this.sends.Add(nameof(eFenceDistanced));
            this.sends.Add(nameof(eFenceRadiusRequest));
            this.sends.Add(nameof(eFenceRadiusResponse));
            this.sends.Add(nameof(eFenceReached));
            this.sends.Add(nameof(eLanded));
            this.sends.Add(nameof(eLanding));
            this.sends.Add(nameof(ePing));
            this.sends.Add(nameof(ePong));
            this.sends.Add(nameof(eRequestDroneMovement));
            this.sends.Add(nameof(eStartBatteryFailSafe));
            this.sends.Add(nameof(eStartGeoFence));
            this.sends.Add(nameof(eUpdateBatteryPercentage));
            this.sends.Add(nameof(eUpdateDroneBatteryRequest));
            this.sends.Add(nameof(eUpdateDroneMovementAndPosition));
            this.sends.Add(nameof(PHalt));
            this.receives.Add(nameof(eBatteryThresholdRequest));
            this.receives.Add(nameof(eBatteryThresholdResponse));
            this.receives.Add(nameof(eDroneMovementResponse));
            this.receives.Add(nameof(eFenceDistanced));
            this.receives.Add(nameof(eFenceRadiusRequest));
            this.receives.Add(nameof(eFenceRadiusResponse));
            this.receives.Add(nameof(eFenceReached));
            this.receives.Add(nameof(eLanded));
            this.receives.Add(nameof(eLanding));
            this.receives.Add(nameof(ePing));
            this.receives.Add(nameof(ePong));
            this.receives.Add(nameof(eRequestDroneMovement));
            this.receives.Add(nameof(eStartBatteryFailSafe));
            this.receives.Add(nameof(eStartGeoFence));
            this.receives.Add(nameof(eUpdateBatteryPercentage));
            this.receives.Add(nameof(eUpdateDroneBatteryRequest));
            this.receives.Add(nameof(eUpdateDroneMovementAndPosition));
            this.receives.Add(nameof(PHalt));
            this.creates.Add(nameof(I_GeoFence));
        }
        
        public void Anon_32(Event currentMachine_dequeuedEvent)
        {
            Test_GeoFence currentMachine = this;
            currentMachine.CreateInterface<I_GeoFence>(currentMachine);
        }
        [Start]
        [OnEntry(nameof(InitializeParametersFunction))]
        [OnEventGotoState(typeof(ConstructorEvent), typeof(Init_9))]
        class __InitState__ : State { }
        
        [OnEntry(nameof(Anon_32))]
        class Init_9 : State
        {
        }
    }
}
namespace PImplementation
{
    internal partial class Test_PowerManagment : PMachine
    {
        private PMachineValue powerManager_2 = null;
        public class ConstructorEvent : PEvent{public ConstructorEvent(IPrtValue val) : base(val) { }}
        
        protected override Event GetConstructorEvent(IPrtValue value) { return new ConstructorEvent((IPrtValue)value); }
        public Test_PowerManagment() {
            this.sends.Add(nameof(eBatteryThresholdRequest));
            this.sends.Add(nameof(eBatteryThresholdResponse));
            this.sends.Add(nameof(eDroneMovementResponse));
            this.sends.Add(nameof(eFenceDistanced));
            this.sends.Add(nameof(eFenceRadiusRequest));
            this.sends.Add(nameof(eFenceRadiusResponse));
            this.sends.Add(nameof(eFenceReached));
            this.sends.Add(nameof(eLanded));
            this.sends.Add(nameof(eLanding));
            this.sends.Add(nameof(ePing));
            this.sends.Add(nameof(ePong));
            this.sends.Add(nameof(eRequestDroneMovement));
            this.sends.Add(nameof(eStartBatteryFailSafe));
            this.sends.Add(nameof(eStartGeoFence));
            this.sends.Add(nameof(eUpdateBatteryPercentage));
            this.sends.Add(nameof(eUpdateDroneBatteryRequest));
            this.sends.Add(nameof(eUpdateDroneMovementAndPosition));
            this.sends.Add(nameof(PHalt));
            this.receives.Add(nameof(eBatteryThresholdRequest));
            this.receives.Add(nameof(eBatteryThresholdResponse));
            this.receives.Add(nameof(eDroneMovementResponse));
            this.receives.Add(nameof(eFenceDistanced));
            this.receives.Add(nameof(eFenceRadiusRequest));
            this.receives.Add(nameof(eFenceRadiusResponse));
            this.receives.Add(nameof(eFenceReached));
            this.receives.Add(nameof(eLanded));
            this.receives.Add(nameof(eLanding));
            this.receives.Add(nameof(ePing));
            this.receives.Add(nameof(ePong));
            this.receives.Add(nameof(eRequestDroneMovement));
            this.receives.Add(nameof(eStartBatteryFailSafe));
            this.receives.Add(nameof(eStartGeoFence));
            this.receives.Add(nameof(eUpdateBatteryPercentage));
            this.receives.Add(nameof(eUpdateDroneBatteryRequest));
            this.receives.Add(nameof(eUpdateDroneMovementAndPosition));
            this.receives.Add(nameof(PHalt));
            this.creates.Add(nameof(I_BatteryFailSafeModified));
            this.creates.Add(nameof(I_GeoFenceModified));
            this.creates.Add(nameof(I_PowerManagement));
        }
        
        public void Anon_33(Event currentMachine_dequeuedEvent)
        {
            Test_PowerManagment currentMachine = this;
            PMachineValue TMP_tmp0_28 = null;
            PMachineValue TMP_tmp1_24 = null;
            PMachineValue TMP_tmp2_21 = null;
            TMP_tmp0_28 = (PMachineValue)(currentMachine.CreateInterface<I_PowerManagement>( currentMachine));
            powerManager_2 = TMP_tmp0_28;
            TMP_tmp1_24 = (PMachineValue)(((PMachineValue)((IPrtValue)powerManager_2)?.Clone()));
            currentMachine.CreateInterface<I_BatteryFailSafeModified>(currentMachine, TMP_tmp1_24);
            TMP_tmp2_21 = (PMachineValue)(((PMachineValue)((IPrtValue)powerManager_2)?.Clone()));
            currentMachine.CreateInterface<I_GeoFenceModified>(currentMachine, TMP_tmp2_21);
        }
        [Start]
        [OnEntry(nameof(InitializeParametersFunction))]
        [OnEventGotoState(typeof(ConstructorEvent), typeof(Init_10))]
        class __InitState__ : State { }
        
        [OnEntry(nameof(Anon_33))]
        class Init_10 : State
        {
        }
    }
}
namespace PImplementation
{
    public class tc {
        public static void InitializeLinkMap() {
            PModule.linkMap.Clear();
            PModule.linkMap[nameof(I_GeoFence)] = new Dictionary<string, string>();
            PModule.linkMap[nameof(I_BatteryFailSafe)] = new Dictionary<string, string>();
            PModule.linkMap[nameof(I_Test_GeoFence)] = new Dictionary<string, string>();
            PModule.linkMap[nameof(I_Test_GeoFence)].Add(nameof(I_GeoFence), nameof(I_GeoFence));
        }
        
        public static void InitializeInterfaceDefMap() {
            PModule.interfaceDefinitionMap.Clear();
            PModule.interfaceDefinitionMap.Add(nameof(I_GeoFence), typeof(GeoFence));
            PModule.interfaceDefinitionMap.Add(nameof(I_BatteryFailSafe), typeof(BatteryFailSafe));
            PModule.interfaceDefinitionMap.Add(nameof(I_Test_GeoFence), typeof(Test_GeoFence));
        }
        
        public static void InitializeMonitorObserves() {
            PModule.monitorObserves.Clear();
            PModule.monitorObserves[nameof(AlwaysCorrect)] = new List<string>();
            PModule.monitorObserves[nameof(AlwaysCorrect)].Add(nameof(ePing));
            PModule.monitorObserves[nameof(AlwaysCorrect)].Add(nameof(ePong));
        }
        
        public static void InitializeMonitorMap(IActorRuntime runtime) {
            PModule.monitorMap.Clear();
            PModule.monitorMap[nameof(I_GeoFence)] = new List<Type>();
            PModule.monitorMap[nameof(I_GeoFence)].Add(typeof(AlwaysCorrect));
            PModule.monitorMap[nameof(I_BatteryFailSafe)] = new List<Type>();
            PModule.monitorMap[nameof(I_BatteryFailSafe)].Add(typeof(AlwaysCorrect));
            PModule.monitorMap[nameof(I_Test_GeoFence)] = new List<Type>();
            PModule.monitorMap[nameof(I_Test_GeoFence)].Add(typeof(AlwaysCorrect));
            runtime.RegisterMonitor<AlwaysCorrect>();
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
            runtime.CreateActor(typeof(_GodMachine), new _GodMachine.Config(typeof(Test_GeoFence)));
        }
    }
}
// TODO: NamedModule BatteryFailSafe_1
// TODO: NamedModule GeoFence_1
namespace PImplementation
{
    public class I_Pong : PMachineValue {
        public I_Pong (ActorId machine, List<string> permissions) : base(machine, permissions) { }
    }
    
    public class I_BatteryFailSafeModified : PMachineValue {
        public I_BatteryFailSafeModified (ActorId machine, List<string> permissions) : base(machine, permissions) { }
    }
    
    public class I_Ping : PMachineValue {
        public I_Ping (ActorId machine, List<string> permissions) : base(machine, permissions) { }
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
    
    public class I_Test_BatteryFailSafe : PMachineValue {
        public I_Test_BatteryFailSafe (ActorId machine, List<string> permissions) : base(machine, permissions) { }
    }
    
    public class I_Test_GeoFence : PMachineValue {
        public I_Test_GeoFence (ActorId machine, List<string> permissions) : base(machine, permissions) { }
    }
    
    public class I_Test_PowerManagment : PMachineValue {
        public I_Test_PowerManagment (ActorId machine, List<string> permissions) : base(machine, permissions) { }
    }
    
    public partial class PHelper {
        public static void InitializeInterfaces() {
            PInterfaces.Clear();
            PInterfaces.AddInterface(nameof(I_Pong), nameof(eBatteryThresholdRequest), nameof(eBatteryThresholdResponse), nameof(eDroneMovementResponse), nameof(eFenceDistanced), nameof(eFenceRadiusRequest), nameof(eFenceRadiusResponse), nameof(eFenceReached), nameof(eLanded), nameof(eLanding), nameof(ePing), nameof(ePong), nameof(eRequestDroneMovement), nameof(eStartBatteryFailSafe), nameof(eStartGeoFence), nameof(eUpdateBatteryPercentage), nameof(eUpdateDroneBatteryRequest), nameof(eUpdateDroneMovementAndPosition), nameof(PHalt));
            PInterfaces.AddInterface(nameof(I_BatteryFailSafeModified), nameof(eBatteryThresholdRequest), nameof(eBatteryThresholdResponse), nameof(eDroneMovementResponse), nameof(eFenceDistanced), nameof(eFenceRadiusRequest), nameof(eFenceRadiusResponse), nameof(eFenceReached), nameof(eLanded), nameof(eLanding), nameof(ePing), nameof(ePong), nameof(eRequestDroneMovement), nameof(eStartBatteryFailSafe), nameof(eStartGeoFence), nameof(eUpdateBatteryPercentage), nameof(eUpdateDroneBatteryRequest), nameof(eUpdateDroneMovementAndPosition), nameof(PHalt));
            PInterfaces.AddInterface(nameof(I_Ping), nameof(eBatteryThresholdRequest), nameof(eBatteryThresholdResponse), nameof(eDroneMovementResponse), nameof(eFenceDistanced), nameof(eFenceRadiusRequest), nameof(eFenceRadiusResponse), nameof(eFenceReached), nameof(eLanded), nameof(eLanding), nameof(ePing), nameof(ePong), nameof(eRequestDroneMovement), nameof(eStartBatteryFailSafe), nameof(eStartGeoFence), nameof(eUpdateBatteryPercentage), nameof(eUpdateDroneBatteryRequest), nameof(eUpdateDroneMovementAndPosition), nameof(PHalt));
            PInterfaces.AddInterface(nameof(I_BatteryFailSafe), nameof(eBatteryThresholdRequest), nameof(eBatteryThresholdResponse), nameof(eDroneMovementResponse), nameof(eFenceDistanced), nameof(eFenceRadiusRequest), nameof(eFenceRadiusResponse), nameof(eFenceReached), nameof(eLanded), nameof(eLanding), nameof(ePing), nameof(ePong), nameof(eRequestDroneMovement), nameof(eStartBatteryFailSafe), nameof(eStartGeoFence), nameof(eUpdateBatteryPercentage), nameof(eUpdateDroneBatteryRequest), nameof(eUpdateDroneMovementAndPosition), nameof(PHalt));
            PInterfaces.AddInterface(nameof(I_GeoFence), nameof(eBatteryThresholdRequest), nameof(eBatteryThresholdResponse), nameof(eDroneMovementResponse), nameof(eFenceDistanced), nameof(eFenceRadiusRequest), nameof(eFenceRadiusResponse), nameof(eFenceReached), nameof(eLanded), nameof(eLanding), nameof(ePing), nameof(ePong), nameof(eRequestDroneMovement), nameof(eStartBatteryFailSafe), nameof(eStartGeoFence), nameof(eUpdateBatteryPercentage), nameof(eUpdateDroneBatteryRequest), nameof(eUpdateDroneMovementAndPosition), nameof(PHalt));
            PInterfaces.AddInterface(nameof(I_PowerManagement), nameof(eBatteryThresholdRequest), nameof(eBatteryThresholdResponse), nameof(eDroneMovementResponse), nameof(eFenceDistanced), nameof(eFenceRadiusRequest), nameof(eFenceRadiusResponse), nameof(eFenceReached), nameof(eLanded), nameof(eLanding), nameof(ePing), nameof(ePong), nameof(eRequestDroneMovement), nameof(eStartBatteryFailSafe), nameof(eStartGeoFence), nameof(eUpdateBatteryPercentage), nameof(eUpdateDroneBatteryRequest), nameof(eUpdateDroneMovementAndPosition), nameof(PHalt));
            PInterfaces.AddInterface(nameof(I_GeoFenceModified), nameof(eBatteryThresholdRequest), nameof(eBatteryThresholdResponse), nameof(eDroneMovementResponse), nameof(eFenceDistanced), nameof(eFenceRadiusRequest), nameof(eFenceRadiusResponse), nameof(eFenceReached), nameof(eLanded), nameof(eLanding), nameof(ePing), nameof(ePong), nameof(eRequestDroneMovement), nameof(eStartBatteryFailSafe), nameof(eStartGeoFence), nameof(eUpdateBatteryPercentage), nameof(eUpdateDroneBatteryRequest), nameof(eUpdateDroneMovementAndPosition), nameof(PHalt));
            PInterfaces.AddInterface(nameof(I_Test_BatteryFailSafe), nameof(eBatteryThresholdRequest), nameof(eBatteryThresholdResponse), nameof(eDroneMovementResponse), nameof(eFenceDistanced), nameof(eFenceRadiusRequest), nameof(eFenceRadiusResponse), nameof(eFenceReached), nameof(eLanded), nameof(eLanding), nameof(ePing), nameof(ePong), nameof(eRequestDroneMovement), nameof(eStartBatteryFailSafe), nameof(eStartGeoFence), nameof(eUpdateBatteryPercentage), nameof(eUpdateDroneBatteryRequest), nameof(eUpdateDroneMovementAndPosition), nameof(PHalt));
            PInterfaces.AddInterface(nameof(I_Test_GeoFence), nameof(eBatteryThresholdRequest), nameof(eBatteryThresholdResponse), nameof(eDroneMovementResponse), nameof(eFenceDistanced), nameof(eFenceRadiusRequest), nameof(eFenceRadiusResponse), nameof(eFenceReached), nameof(eLanded), nameof(eLanding), nameof(ePing), nameof(ePong), nameof(eRequestDroneMovement), nameof(eStartBatteryFailSafe), nameof(eStartGeoFence), nameof(eUpdateBatteryPercentage), nameof(eUpdateDroneBatteryRequest), nameof(eUpdateDroneMovementAndPosition), nameof(PHalt));
            PInterfaces.AddInterface(nameof(I_Test_PowerManagment), nameof(eBatteryThresholdRequest), nameof(eBatteryThresholdResponse), nameof(eDroneMovementResponse), nameof(eFenceDistanced), nameof(eFenceRadiusRequest), nameof(eFenceRadiusResponse), nameof(eFenceReached), nameof(eLanded), nameof(eLanding), nameof(ePing), nameof(ePong), nameof(eRequestDroneMovement), nameof(eStartBatteryFailSafe), nameof(eStartGeoFence), nameof(eUpdateBatteryPercentage), nameof(eUpdateDroneBatteryRequest), nameof(eUpdateDroneMovementAndPosition), nameof(PHalt));
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
