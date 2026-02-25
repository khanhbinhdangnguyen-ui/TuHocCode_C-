using TuHocCode.Services;
using UnityEngine;
using UnityEngine.UIElements;

namespace TuHocCode.Features.Score
{
    public class ScoreController : MonoBehaviour
    {
        [SerializeField] private UIDocument document;

        private readonly ScoreService _scoreService = new ScoreService();

        private void Start()
        {
            if (document == null)
            {
                document = GetComponent<UIDocument>();
            }

            if (document == null)
            {
                Debug.LogWarning("ScoreController: UIDocument missing.");
                return;
            }

            var root = document.rootVisualElement;
            var scoreLabel = root.Q<Label>("score-value");
            if (scoreLabel == null)
            {
                return;
            }

            var score = _scoreService.Load();
            scoreLabel.text = $"{score.total_score}/100";
        }
    }
}
