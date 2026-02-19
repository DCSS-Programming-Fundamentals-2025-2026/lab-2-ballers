using lab1_ballers.Domain.Cards;
using lab1_ballers.Domain.CardsRepos;
using System.Collections;
namespace lab1_ballers.Upgrade
{
    class CardEnumerator : IEnumerator
    {
        private CardBase[] _cards;
        private int _position = -1;

        public CardEnumerator(CardBase[] cards)
        {
            _cards = cards;
        }

        public bool MoveNext()
        {
            _position++;
            return _position < _cards.Length;
        }

        public object Current
        {
            get
            {
                return _cards[_position];
            }
        }

        public void Reset()
        {
            _position = -1;
        }
    }
}
