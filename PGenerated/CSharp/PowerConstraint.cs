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
    internal partial class Pong : PMachine
    {
        private PrtInt counter = ((PrtInt)0);
        public class ConstructorEvent : PEvent{public ConstructorEvent(IPrtValue val) : base(val) { }}
        
        protected override Event GetConstructorEvent(IPrtValue value) { return new ConstructorEvent((IPrtValue)value); }
        public Pong() {
            this.sends.Add(nameof(ePing));
            this.sends.Add(nameof(ePong));
            this.sends.Add(nameof(PHalt));
            this.receives.Add(nameof(ePing));
            this.receives.Add(nameof(ePong));
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
    internal partial class Ping : PMachine
    {
        private PrtInt counter_1 = ((PrtInt)0);
        private PMachineValue pong = null;
        public class ConstructorEvent : PEvent{public ConstructorEvent(PMachineValue val) : base(val) { }}
        
        protected override Event GetConstructorEvent(IPrtValue value) { return new ConstructorEvent((PMachineValue)value); }
        public Ping() {
            this.sends.Add(nameof(ePing));
            this.sends.Add(nameof(ePong));
            this.sends.Add(nameof(PHalt));
            this.receives.Add(nameof(ePing));
            this.receives.Add(nameof(ePong));
            this.receives.Add(nameof(PHalt));
        }
        
        public void Anon_2(Event currentMachine_dequeuedEvent)
        {
            Ping currentMachine = this;
            PMachineValue pong_local = (PMachineValue)(gotoPayload ?? ((PEvent)currentMachine_dequeuedEvent).Payload);
            this.gotoPayload = null;
            counter_1 = (PrtInt)(((PrtInt)0));
            pong = (PMachineValue)(((PMachineValue)((IPrtValue)pong_local)?.Clone()));
            currentMachine.TryGotoState<Ping_1>();
            return;
        }
        public void Anon_3(Event currentMachine_dequeuedEvent)
        {
            Ping currentMachine = this;
            PrtInt TMP_tmp0_1 = ((PrtInt)0);
            PrtInt TMP_tmp1_1 = ((PrtInt)0);
            PrtString TMP_tmp2_1 = ((PrtString)"");
            PMachineValue TMP_tmp3_1 = null;
            PEvent TMP_tmp4_1 = null;
            PMachineValue TMP_tmp5_1 = null;
            PrtNamedTuple TMP_tmp6_1 = (new PrtNamedTuple(new string[]{"source"},null));
            TMP_tmp0_1 = (PrtInt)((counter_1) + (((PrtInt)1)));
            counter_1 = TMP_tmp0_1;
            TMP_tmp1_1 = (PrtInt)(((PrtInt)((IPrtValue)counter_1)?.Clone()));
            TMP_tmp2_1 = (PrtString)(((PrtString) String.Format("Ping called, counter = {0}",TMP_tmp1_1)));
            PModule.runtime.Logger.WriteLine("<PrintLog> " + TMP_tmp2_1);
            TMP_tmp3_1 = (PMachineValue)(((PMachineValue)((IPrtValue)pong)?.Clone()));
            TMP_tmp4_1 = (PEvent)(new ePing((new PrtNamedTuple(new string[]{"source"},null))));
            TMP_tmp5_1 = (PMachineValue)(currentMachine.self);
            TMP_tmp6_1 = (PrtNamedTuple)((new PrtNamedTuple(new string[]{"source"}, TMP_tmp5_1)));
            currentMachine.TrySendEvent(TMP_tmp3_1, (Event)TMP_tmp4_1, TMP_tmp6_1);
        }
        public void Anon_4(Event currentMachine_dequeuedEvent)
        {
            Ping currentMachine = this;
            PrtNamedTuple pongResp = (PrtNamedTuple)(gotoPayload ?? ((PEvent)currentMachine_dequeuedEvent).Payload);
            this.gotoPayload = null;
            PrtInt TMP_tmp0_2 = ((PrtInt)0);
            PMachineValue TMP_tmp1_2 = null;
            PMachineValue TMP_tmp2_2 = null;
            PEvent TMP_tmp3_2 = null;
            PMachineValue TMP_tmp4_2 = null;
            PrtNamedTuple TMP_tmp5_2 = (new PrtNamedTuple(new string[]{"source"},null));
            TMP_tmp0_2 = (PrtInt)((counter_1) + (((PrtInt)1)));
            counter_1 = TMP_tmp0_2;
            TMP_tmp1_2 = (PMachineValue)(((PrtNamedTuple)pongResp)["source"]);
            TMP_tmp2_2 = (PMachineValue)(((PMachineValue)((IPrtValue)TMP_tmp1_2)?.Clone()));
            TMP_tmp3_2 = (PEvent)(new ePing((new PrtNamedTuple(new string[]{"source"},null))));
            TMP_tmp4_2 = (PMachineValue)(currentMachine.self);
            TMP_tmp5_2 = (PrtNamedTuple)((new PrtNamedTuple(new string[]{"source"}, TMP_tmp4_2)));
            currentMachine.TrySendEvent(TMP_tmp2_2, (Event)TMP_tmp3_2, TMP_tmp5_2);
        }
        [Start]
        [OnEntry(nameof(InitializeParametersFunction))]
        [OnEventGotoState(typeof(ConstructorEvent), typeof(Init_1))]
        class __InitState__ : State { }
        
        [OnEntry(nameof(Anon_2))]
        class Init_1 : State
        {
        }
        [OnEntry(nameof(Anon_3))]
        [OnEventDoAction(typeof(ePong), nameof(Anon_4))]
        class Ping_1 : State
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
        
        public void Anon_5(Event currentMachine_dequeuedEvent)
        {
            AlwaysCorrect currentMachine = this;
            global_counter = (PrtInt)(((PrtInt)0));
            currentMachine.TryGotoState<WaitForPingPongEvents>();
            return;
        }
        public void Anon_6(Event currentMachine_dequeuedEvent)
        {
            AlwaysCorrect currentMachine = this;
            PrtInt TMP_tmp0_3 = ((PrtInt)0);
            PrtInt TMP_tmp1_3 = ((PrtInt)0);
            PrtString TMP_tmp2_3 = ((PrtString)"");
            TMP_tmp0_3 = (PrtInt)((global_counter) + (((PrtInt)1)));
            global_counter = TMP_tmp0_3;
            TMP_tmp1_3 = (PrtInt)(((PrtInt)((IPrtValue)global_counter)?.Clone()));
            TMP_tmp2_3 = (PrtString)(((PrtString) String.Format("Ping intialized, global_counter = {0}",TMP_tmp1_3)));
            PModule.runtime.Logger.WriteLine("<PrintLog> " + TMP_tmp2_3);
        }
        public void Anon_7(Event currentMachine_dequeuedEvent)
        {
            AlwaysCorrect currentMachine = this;
            PrtInt TMP_tmp0_4 = ((PrtInt)0);
            PrtInt TMP_tmp1_4 = ((PrtInt)0);
            PrtString TMP_tmp2_4 = ((PrtString)"");
            TMP_tmp0_4 = (PrtInt)((global_counter) + (((PrtInt)1)));
            global_counter = TMP_tmp0_4;
            TMP_tmp1_4 = (PrtInt)(((PrtInt)((IPrtValue)global_counter)?.Clone()));
            TMP_tmp2_4 = (PrtString)(((PrtString) String.Format("Ping intialized, global_counter = {0}",TMP_tmp1_4)));
            PModule.runtime.Logger.WriteLine("<PrintLog> " + TMP_tmp2_4);
        }
        [Start]
        [OnEntry(nameof(Anon_5))]
        class Init_2 : State
        {
        }
        [Hot]
        [OnEventDoAction(typeof(ePing), nameof(Anon_6))]
        [OnEventDoAction(typeof(ePong), nameof(Anon_7))]
        class WaitForPingPongEvents : State
        {
        }
    }
}
namespace PImplementation
{
    internal partial class Test : PMachine
    {
        public class ConstructorEvent : PEvent{public ConstructorEvent(IPrtValue val) : base(val) { }}
        
        protected override Event GetConstructorEvent(IPrtValue value) { return new ConstructorEvent((IPrtValue)value); }
        public Test() {
            this.sends.Add(nameof(ePing));
            this.sends.Add(nameof(ePong));
            this.sends.Add(nameof(PHalt));
            this.receives.Add(nameof(ePing));
            this.receives.Add(nameof(ePong));
            this.receives.Add(nameof(PHalt));
            this.creates.Add(nameof(I_Ping));
            this.creates.Add(nameof(I_Pong));
        }
        
        public void Anon_8(Event currentMachine_dequeuedEvent)
        {
            Test currentMachine = this;
            PMachineValue TMP_tmp0_5 = null;
            TMP_tmp0_5 = (PMachineValue)(currentMachine.CreateInterface<I_Pong>( currentMachine));
            currentMachine.CreateInterface<I_Ping>(currentMachine, TMP_tmp0_5);
        }
        [Start]
        [OnEntry(nameof(InitializeParametersFunction))]
        [OnEventGotoState(typeof(ConstructorEvent), typeof(Init_3))]
        class __InitState__ : State { }
        
        [OnEntry(nameof(Anon_8))]
        class Init_3 : State
        {
        }
    }
}
namespace PImplementation
{
    public class tc {
        public static void InitializeLinkMap() {
            PModule.linkMap.Clear();
            PModule.linkMap[nameof(I_Ping)] = new Dictionary<string, string>();
            PModule.linkMap[nameof(I_Pong)] = new Dictionary<string, string>();
            PModule.linkMap[nameof(I_Test)] = new Dictionary<string, string>();
            PModule.linkMap[nameof(I_Test)].Add(nameof(I_Ping), nameof(I_Ping));
            PModule.linkMap[nameof(I_Test)].Add(nameof(I_Pong), nameof(I_Pong));
        }
        
        public static void InitializeInterfaceDefMap() {
            PModule.interfaceDefinitionMap.Clear();
            PModule.interfaceDefinitionMap.Add(nameof(I_Ping), typeof(Ping));
            PModule.interfaceDefinitionMap.Add(nameof(I_Pong), typeof(Pong));
            PModule.interfaceDefinitionMap.Add(nameof(I_Test), typeof(Test));
        }
        
        public static void InitializeMonitorObserves() {
            PModule.monitorObserves.Clear();
            PModule.monitorObserves[nameof(AlwaysCorrect)] = new List<string>();
            PModule.monitorObserves[nameof(AlwaysCorrect)].Add(nameof(ePing));
            PModule.monitorObserves[nameof(AlwaysCorrect)].Add(nameof(ePong));
        }
        
        public static void InitializeMonitorMap(IActorRuntime runtime) {
            PModule.monitorMap.Clear();
            PModule.monitorMap[nameof(I_Ping)] = new List<Type>();
            PModule.monitorMap[nameof(I_Ping)].Add(typeof(AlwaysCorrect));
            PModule.monitorMap[nameof(I_Pong)] = new List<Type>();
            PModule.monitorMap[nameof(I_Pong)].Add(typeof(AlwaysCorrect));
            PModule.monitorMap[nameof(I_Test)] = new List<Type>();
            PModule.monitorMap[nameof(I_Test)].Add(typeof(AlwaysCorrect));
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
            runtime.CreateActor(typeof(_GodMachine), new _GodMachine.Config(typeof(Test)));
        }
    }
}
// TODO: NamedModule Ping_2
// TODO: NamedModule Pong_2
namespace PImplementation
{
    public class I_Pong : PMachineValue {
        public I_Pong (ActorId machine, List<string> permissions) : base(machine, permissions) { }
    }
    
    public class I_Ping : PMachineValue {
        public I_Ping (ActorId machine, List<string> permissions) : base(machine, permissions) { }
    }
    
    public class I_Test : PMachineValue {
        public I_Test (ActorId machine, List<string> permissions) : base(machine, permissions) { }
    }
    
    public partial class PHelper {
        public static void InitializeInterfaces() {
            PInterfaces.Clear();
            PInterfaces.AddInterface(nameof(I_Pong), nameof(ePing), nameof(ePong), nameof(PHalt));
            PInterfaces.AddInterface(nameof(I_Ping), nameof(ePing), nameof(ePong), nameof(PHalt));
            PInterfaces.AddInterface(nameof(I_Test), nameof(ePing), nameof(ePong), nameof(PHalt));
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
