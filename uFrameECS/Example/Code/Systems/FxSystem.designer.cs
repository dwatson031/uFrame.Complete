// ------------------------------------------------------------------------------
//  <autogenerated>
//      This code was generated by a tool.
//      Mono Runtime Version: 2.0.50727.1433
// 
//      Changes to this file may cause incorrect behavior and will be lost if 
//      the code is regenerated.
//  </autogenerated>
// ------------------------------------------------------------------------------

namespace uFrameECSExample {
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using uFrame.ECS.APIs;
    using uFrame.ECS.Components;
    using uFrame.ECS.Systems;
    using uFrame.Kernel;
    using uFrameECSExample;
    using UniRx;
    using UnityEngine;
    
    
    public partial class FxSystemBase : uFrame.ECS.Systems.EcsSystem {
        
        private IEcsComponentManagerOf<EffectOnDestroy> _EffectOnDestroyManager;
        
        public IEcsComponentManagerOf<EffectOnDestroy> EffectOnDestroyManager {
            get {
                return _EffectOnDestroyManager;
            }
            set {
                _EffectOnDestroyManager = value;
            }
        }
        
        public override void Setup() {
            base.Setup();
            EffectOnDestroyManager = ComponentSystem.RegisterComponent<EffectOnDestroy>(13);
            EffectOnDestroyManager.RemovedObservable.Subscribe(_=>EffectOnDestroyComponentDestroyed(_,_)).DisposeWith(this);
        }
        
        protected virtual void EffectOnDestroyComponentDestroyed(EffectOnDestroy data, EffectOnDestroy group) {
            var handler = new EffectOnDestroyComponentDestroyed();
            handler.System = this;
            handler.Event = data;
            handler.Group = group;
            StartCoroutine(handler.Execute());
        }
        
        protected void EffectOnDestroyComponentDestroyedFilter(EffectOnDestroy data) {
            var GroupEffectOnDestroy = EffectOnDestroyManager[data.EntityId];
            if (GroupEffectOnDestroy == null) {
                return;
            }
            if (!GroupEffectOnDestroy.Enabled) {
                return;
            }
            this.EffectOnDestroyComponentDestroyed(data, GroupEffectOnDestroy);
        }
    }
    
    [uFrame.Attributes.uFrameIdentifier("21d7c4d7-2056-4594-bb88-bdba63969e8a")]
    public partial class FxSystem : FxSystemBase {
        
        private static FxSystem _Instance;
        
        public FxSystem() {
            Instance = this;
        }
        
        public static FxSystem Instance {
            get {
                return _Instance;
            }
            set {
                _Instance = value;
            }
        }
    }
}
