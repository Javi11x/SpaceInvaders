using SpaceInvaders.Models;
using UniRx;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace SpaceInvaders.Presenters
{
    public class MenuPresenter : MonoBehaviour
    {
        [SerializeField] Button _buttonStart;
        [SerializeField] Button _buttonScores;

        [Inject] readonly GameStateModel _gameState;

        private void Start()
        {
            // Proceed to gameplay
            _buttonStart.OnClickAsObservable()
                .Subscribe(_ => _gameState.State.Value = GameState.Gameplay)
                .AddTo(this);

            // Proceed to high scores
            _buttonScores.OnClickAsObservable()
                .Subscribe(_ => _gameState.State.Value = GameState.Scores)
                .AddTo(this);
        }
    }
}
