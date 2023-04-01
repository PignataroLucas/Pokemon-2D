using ScriptableObjectsScripts;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

namespace Battle.Battle__Pokemon
{
    public class BattlePokemon : MonoBehaviour
    {
        [SerializeField] private PokemonAttributes attributes;
        [SerializeField] private int level;
        public bool isPlayerUnit;

        private Image _image;

        private Vector3 _originalPosition;
        private Color _originalColor;
        
        private void Awake() 
        {
            _image = GetComponent<Image>();
            _originalPosition = _image.transform.localPosition;
            _originalColor = _image.color;
        }

        public Pokemon.Pokemon Pokemon { get; set; }

        public void SetUp()
        {
            Pokemon = new Pokemon.Pokemon(attributes, level);
            _image.sprite = isPlayerUnit ? Pokemon.Attributes.BackSprite : Pokemon.Attributes.FrontSprite;
            PlayEnterAnimation();         
        }

        private void PlayEnterAnimation()
        {
            _image.transform.localPosition = isPlayerUnit ? new Vector3(-1463f, _originalPosition.y) 
                : new Vector3(1463f, _originalPosition.y);

            _image.transform.DOLocalMoveX(_originalPosition.x, 1.5f);
        }

        public void PlayAttackAnimation()
        {
            var sequence = DOTween.Sequence();
            sequence.Append(isPlayerUnit
                ? _image.transform.DOLocalMoveX(_originalPosition.x + 150f, .7f)
                : _image.transform.DOLocalMoveX(_originalPosition.x - 150f, .7f));

            sequence.Append(_image.transform.DOLocalMoveX(_originalPosition.x, .7f));
        }

        public void PlayHitAnimation()
        {
            var sequence = DOTween.Sequence();
            sequence.Append(_image.DOColor(Color.grey, .1f));
            sequence.Append(_image.DOColor(_originalColor, .1f));
        }

        public void PlayFaintAnimation()
        {
            var sequence = DOTween.Sequence();
            sequence.Append(_image.transform.DOLocalMoveY(_originalPosition.y - 200f, .5f));
            sequence.Join(_image.DOFade(0f, .5f));
        }
        
    }
}
