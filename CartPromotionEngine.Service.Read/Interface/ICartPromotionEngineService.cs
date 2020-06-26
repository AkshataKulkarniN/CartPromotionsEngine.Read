using System;
using System.Collections.Generic;
using System.Text;

namespace CartPromotionEngine.Service.Read.Interface
{
    public interface ICartPromotionEngineService
    {

        double TotalValueOfCart(string cartItems, string promotionCode);
        double TotalSumOfPromtionNItems(string cartItems, char  itemName);

        double TotalSumForCombinations(string cartItems, string itemCombination);
    }
}
