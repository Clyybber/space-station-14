using System;
using Content.Shared.NetIDs;
using Robust.Shared.GameObjects;
using Robust.Shared.Players;
using Robust.Shared.Serialization;
using Robust.Shared.ViewVariables;

namespace Content.Shared.Gravity
{
    [RegisterComponent]
    public sealed class MagicGravityComponent : Component
    {
        public override string Name => "MagicGravity";
        public override uint? NetID => ContentNetIDs.MAGIC_GRAVITY;

        [ViewVariables(VVAccess.ReadWrite)]
        public bool Enabled
        {
            get => _enabled;
            set
            {
                if (_enabled == value) return;
                _enabled = value;
                Dirty();
            }
        }

        private bool _enabled;

        public override ComponentState GetComponentState(ICommonSession player)
        {
            return new MagicGravityComponentState(_enabled);
        }

        [Serializable, NetSerializable]
        public sealed class MagicGravityComponentState : ComponentState
        {
            public bool Enabled { get; }

            public MagicGravityComponentState(bool enabled) : base(ContentNetIDs.MAGIC_GRAVITY)
            {
                Enabled = enabled;
            }
        }
    }
}
