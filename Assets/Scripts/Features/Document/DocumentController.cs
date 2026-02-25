using System.Linq;
using TuHocCode.Services;
using UnityEngine;
using UnityEngine.UIElements;

namespace TuHocCode.Features.Document
{
    public class DocumentController : MonoBehaviour
    {
        [SerializeField] private UIDocument document;

        private readonly DocumentService _service = new DocumentService();

        private void Start()
        {
            if (document == null)
            {
                document = GetComponent<UIDocument>();
            }

            if (document == null)
            {
                Debug.LogWarning("DocumentController: UIDocument missing.");
                return;
            }

            var root = document.rootVisualElement;
            var searchField = root.Q<TextField>("document-search");
            var resultLabel = root.Q<Label>("document-result");

            if (searchField == null || resultLabel == null)
            {
                return;
            }

            searchField.RegisterValueChangedCallback(evt =>
            {
                var first = _service.Search(evt.newValue).FirstOrDefault();
                resultLabel.text = first == null ? "Không có kết quả" : $"{first.command}: {first.title}";
            });
        }
    }
}
