using UnityEngine;
using UnityEngine.UIElements;

namespace TuHocCode.App
{
    public class MainLayoutController : MonoBehaviour
    {
        [SerializeField] private UIDocument document;

        private void Start()
        {
            if (document == null)
            {
                document = GetComponent<UIDocument>();
            }

            if (document == null)
            {
                Debug.LogWarning("MainLayoutController: UIDocument missing.");
                return;
            }

            var root = document.rootVisualElement;
            BindNav(root, "nav-document", "tab-document");
            BindNav(root, "nav-practice", "tab-practice");
            BindNav(root, "nav-score", "tab-score");

            ShowTab(root, "tab-document");
        }

        private static void BindNav(VisualElement root, string buttonName, string tabName)
        {
            var button = root.Q<Button>(buttonName);
            if (button == null)
            {
                return;
            }

            button.clicked += () => ShowTab(root, tabName);
        }

        private static void ShowTab(VisualElement root, string tabName)
        {
            foreach (var tab in root.Query<VisualElement>(className: "app-tab").ToList())
            {
                tab.style.display = tab.name == tabName ? DisplayStyle.Flex : DisplayStyle.None;
            }
        }
    }
}
