using TuHocCode.Services;
using UnityEngine;
using UnityEngine.UIElements;

namespace TuHocCode.Features.Chat
{
    public class ChatController : MonoBehaviour
    {
        [SerializeField] private UIDocument document;

        private readonly ChatService _chatService = new ChatService();
        private Vector2 _dragOffset;

        private void Start()
        {
            if (document == null)
            {
                document = GetComponent<UIDocument>();
            }

            if (document == null)
            {
                Debug.LogWarning("ChatController: UIDocument missing.");
                return;
            }

            var root = document.rootVisualElement;
            var button = root.Q<VisualElement>("chat-fab");
            var panel = root.Q<VisualElement>("chat-panel");
            var input = root.Q<TextField>("chat-input");
            var output = root.Q<Label>("chat-output");

            if (button != null && panel != null)
            {
                panel.style.display = DisplayStyle.None;
                button.RegisterCallback<ClickEvent>(_ =>
                {
                    panel.style.display = panel.style.display == DisplayStyle.None ? DisplayStyle.Flex : DisplayStyle.None;
                });
                RegisterDrag(button);
            }

            if (input != null && output != null)
            {
                input.RegisterCallback<KeyDownEvent>(evt =>
                {
                    if (evt.keyCode != KeyCode.Return && evt.keyCode != KeyCode.KeypadEnter)
                    {
                        return;
                    }

                    var answer = _chatService.Ask(input.value);
                    output.text = $"{answer.title}\n{answer.summary}\n\n{answer.codeExample}";
                });
            }
        }

        private void RegisterDrag(VisualElement element)
        {
            element.RegisterCallback<PointerDownEvent>(evt =>
            {
                _dragOffset = evt.localPosition;
                element.CapturePointer(evt.pointerId);
            });

            element.RegisterCallback<PointerMoveEvent>(evt =>
            {
                if (!element.HasPointerCapture(evt.pointerId))
                {
                    return;
                }

                element.style.left = evt.position.x - _dragOffset.x;
                element.style.top = evt.position.y - _dragOffset.y;
            });

            element.RegisterCallback<PointerUpEvent>(evt =>
            {
                if (element.HasPointerCapture(evt.pointerId))
                {
                    element.ReleasePointer(evt.pointerId);
                }
            });
        }
    }
}
