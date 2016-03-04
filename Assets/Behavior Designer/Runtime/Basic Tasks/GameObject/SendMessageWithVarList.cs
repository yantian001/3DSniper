using UnityEngine;

namespace BehaviorDesigner.Runtime.Tasks.Basic.UnityGameObject
{
    [TaskCategory("Basic/GameObject")]
    [TaskDescription("Sends a message to the target GameObject. Returns Success.")]
    public class SendMessageWithVarList : Action
    {
        [Tooltip("The GameObject that the task operates on. If null the task GameObject is used.")]
        public SharedGameObject targetGameObject;
        [Tooltip("The message to send")]
        public SharedString message;
        [Tooltip("The value to send")]
        public SharedGenericVariable[] value;


        public override TaskStatus OnUpdate()
        {
            if (value != null) {
                GetDefaultGameObject(targetGameObject.Value).SendMessage(message.Value, value,SendMessageOptions.DontRequireReceiver);
            } else {
                GetDefaultGameObject(targetGameObject.Value).SendMessage(message.Value, SendMessageOptions.DontRequireReceiver);
            }

            return TaskStatus.Success;
        }

        public override void OnReset()
        {
            targetGameObject = null;
            message = "";
        }
    }
}