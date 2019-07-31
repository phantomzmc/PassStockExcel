using System;
namespace PassStockExcel
{
    interface ISpacePartsList
    {
        void savedata(string id_item, string name_item, string group_item, float sell_price_unit, float sell_price_all, float cost_price_unit, float cost_price_all, string shelf_main, string shelf_try, DateTime date_count_stock, int round);
    }
}
