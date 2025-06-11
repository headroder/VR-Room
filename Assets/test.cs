using UnityEngine;
using UnityEngine.InputSystem; // InputSystem 네임스페이스 꼭!

public class ControllerInputDebugger : MonoBehaviour
{
    public InputActionProperty triggerAction; // XRI RightHand/Trigger 입력 연결용

    void OnEnable()
    {
        triggerAction.action.Enable();
    }

    void OnDisable()
    {
        triggerAction.action.Disable();
    }

    void Update()
    {
        if (triggerAction != null && triggerAction.action != null)
        {
            float triggerValue = triggerAction.action.ReadValue<float>();
            if (triggerValue > 0.1f) // 0.1f 이상이면 실제로 누르고 있는 것
            {
                Debug.Log($"Trigger pressed! Value: {triggerValue}");
            }
        }
    }
}
