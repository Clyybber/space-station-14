using Robust.Shared.GameObjects;
using Robust.Shared.GameStates;
using Robust.Shared.Log;
using Robust.Shared.Maths;

namespace Content.Shared.Gravity
{
    public class SharedMagicGravitySystem : EntitySystem
    {
        public override void Initialize()
        {
            base.Initialize();
            SubscribeLocalEvent<MagicGravityComponent, ComponentHandleState>(HandleComponentState);
        }

        private void HandleComponentState(EntityUid uid, MagicGravityComponent component, ComponentHandleState args)
        {
            if (args.Current is not MagicGravityComponent.MagicGravityComponentState state) return;
            component.Enabled = state.Enabled;
        }

        public override void Update(float frameTime)
        {
            foreach (var (magicGravityComponent, physicsComponent) in ComponentManager.EntityQuery<MagicGravityComponent, PhysicsComponent>())
            {
                if (magicGravityComponent.Enabled)
                {
                    Logger.Debug("hey");
                    physicsComponent.ApplyLinearImpulse(Vector2.One * 1000000);
                }
            }
        }

    }
}
