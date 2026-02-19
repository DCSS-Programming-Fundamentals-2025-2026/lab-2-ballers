using lab1_ballers.Domain.Cards;
using System.Collections;

namespace lab1_ballers.Upgrade
{
    class CardComparer : IComparer
    {
        public int Compare(object x, object y)
        {
            if (x != null && y != null)
            {
                CardBase c1 = x as CardBase;
                CardBase c2 = y as CardBase;

                return string.Compare(c1.Type.ToString(), c2.Type.ToString(), StringComparison.OrdinalIgnoreCase);
            }

            return -1;
        }
    }
}
