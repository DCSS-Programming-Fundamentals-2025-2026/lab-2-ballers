using lab1_ballers.Domain.Cards;
using System.Collections;

namespace lab1_ballers.Upgrade
{
    class CardEnumerator : IEnumerator
    {
        private CardBase[] _cards;
        private int _position = -1;
        private int _count; 

        public CardEnumerator(CardBase[] cards, int count) 
        {
            _cards = cards;
            _count = count;
        }

        public bool MoveNext()
        {
            _position++;
            return _position < _count; 
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