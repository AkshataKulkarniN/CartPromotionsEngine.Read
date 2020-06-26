using CartPromotionEngine.Service.Read.Interface;
using System;
using System.Globalization;
using System.Linq;

namespace CartPromotionEngine.Service.Read
{
    public class CartPromotionEngineService : ICartPromotionEngineService
    {
        public double TotalValueOfCart(string cartItems, string promotionCode)
        {
            double sum = 0;
            if(promotionCode.Contains("3AFor130"))
            {
                sum = TotalSumOfPromtionNItems(cartItems, 'A');
                sum += GetTotalValueOfCart(cartItems.Replace('A', ' ').Trim(' '));
            }
            else if(promotionCode.Contains("3BFor130"))
            {
                sum = TotalSumOfPromtionNItems(cartItems, 'B');
                sum += GetTotalValueOfCart(cartItems.Replace('B', ' ').Trim(' '));
            }
            else if(promotionCode.Contains("CDFor30"))
            {
                sum = TotalSumForCombinations(cartItems, "CD");
                cartItems = cartItems.Replace('C', ' ');
                cartItems = cartItems.Replace('D', ' ');
                sum += GetTotalValueOfCart(cartItems.Trim(' '));
            }
            if(string.IsNullOrEmpty(promotionCode))
            {
                sum += GetTotalValueOfCart(cartItems);
            }

            return sum;
        }


        public double TotalSumOfPromtionNItems(string cartItems, char item)
        {
            var sum = 0;
            var countOfAInCart = cartItems.Where(x => x == item).Count();


            if (countOfAInCart >= 1)
            {
                if (item == 'A')
                {
                    var combinations = countOfAInCart / 3;
                    var remainingUnits = countOfAInCart % 3;
                    if (combinations != 0)
                    {
                        sum = combinations * 130;
                    }
                    if (remainingUnits != 0)
                    {
                        sum += remainingUnits * 50;
                    }
                }
                else if(item == 'B')
                {
                    var combinations = countOfAInCart / 2;
                    var remainingUnits = countOfAInCart % 2;
                    if (combinations != 0)
                    {
                        sum = combinations * 130;
                    }
                    if (remainingUnits != 0)
                    {
                        sum += remainingUnits * 30;
                    }

                }
            }
            return sum;
        }

        public double TotalSumForCombinations(string cartItems, string itemCombination)
        {
            var sum = 0;
            if(itemCombination == "CD")
            {

                var countOfCInCart = cartItems.Where(x => x == itemCombination[0]).Count();
                var countOfDInCart = cartItems.Where(x => x == itemCombination[1]).Count();
                if(countOfCInCart > countOfDInCart)
                {
                    sum += countOfDInCart * 30;
                    sum += 20 * (countOfCInCart - countOfDInCart);
                }
                else if(countOfCInCart < countOfDInCart)
                {
                    sum += countOfCInCart * 30;
                    sum += 15 * (countOfDInCart - countOfCInCart);
                }
                else if(countOfCInCart == countOfDInCart)
                {
                    sum += countOfCInCart * 30;
                }
               
            }
            return sum;
        }


        #region Private methods
        private double GetTotalValueOfCart(string cartItems)
        {
            double sum = 0;
            foreach(var cartItem in cartItems)
            {
                var countOfItemInCart = cartItems.Where(x => x == cartItem).Count();
                switch(cartItem)
                {
                    case 'A': sum += countOfItemInCart * 50;
                            break;
                    case 'B': sum += countOfItemInCart * 30;
                            break;
                    case 'C': sum += countOfItemInCart * 20;
                        break;
                    case 'D': sum += countOfItemInCart * 15;
                        break;
                    default: sum += 0;
                        break;
                }
                cartItems = cartItems.Replace(cartItem, ' ').Trim(' ');
                if(string.IsNullOrEmpty(cartItems))
                {
                    break;
                }

            }
            return sum;
        }

        #endregion

    }
}
