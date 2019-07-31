using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NoomLibrary;
using System.Data.SqlClient;
using System.Data;
using System.Globalization;
using System.Collections;

namespace PassStockExcel
{

    public class SpacePartsList : IList<SpacePartsList.SpaceParts>
    {
        private CStatement _statememet;
        private Dictionary<int, SpaceParts> _list = new Dictionary<int, SpaceParts>();


        SqlDataAdapter adapter = new SqlDataAdapter();

        public SpacePartsList()
        {
            this._statememet = new CStatement("uspSelectSpaceParts", "uspImportExcelStock", "UPDATE", "DELECT", System.Data.CommandType.StoredProcedure);
        }

        #region Imprement
        public SpaceParts this[int index]
        {
            get
            {
                SpaceParts result;
                if (this._list.TryGetValue(index, out result))
                {
                    return result;
                }
                else
                {
                    return null;
                }
            }
            set
            {
                SpaceParts result;
                if (this._list.TryGetValue(index, out result))
                {
                    this._list[index] = value;
                }
                else
                {
                    this._list.Add(index, value);
                }
            }
        }
        public int Count => this.Count;

        public bool IsReadOnly => this.IsReadOnly;

        public void Add(SpaceParts item)
        {
            this.Add(item);
        }

        public void Clear()
        {
            this.Clear();
        }

        public bool Contains(SpaceParts item)
        {
            return this.Contains(item);
        }

        public void CopyTo(SpaceParts[] array, int arrayIndex)
        {
            this.CopyTo(array, arrayIndex);
        }

        public IEnumerator<SpaceParts> GetEnumerator() => this.GetEnumerator();

        public int IndexOf(SpaceParts item)
        {
            return this.IndexOf(item);
        }

        public void Insert(int index, SpaceParts item)
        {
            this.Insert(index, item);
        }

        public bool Remove(SpaceParts item)
        {
            return this.Remove(item);
        }

        public void RemoveAt(int index)
        {
            this.RemoveAt(index);
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
#endregion
        public DataTable getData(DateTime date_count_stock,int id_brach)
        {
            String count_stock = date_count_stock.ToString("yyyy-MM-dd");
            DataTable _dt = new DataTable();
            CStatementList cstate = new CStatementList(Connection.CSQLConnection);
            try
            {
                CSQLParameterList plist = new CSQLParameterList();
                plist.Add("@Date_Count_Stock", DbType.String, count_stock, ParameterDirection.Input);
                plist.Add("@ID_Brach", DbType.Int32, id_brach, ParameterDirection.Input);

                CSQLDataAdepterList adlist = new CSQLDataAdepterList();
                CSQLStatementValue csv = new CSQLStatementValue(this._statememet, plist, NoomLibrary.StatementType.Select);
                adlist.Add(csv);
                cstate.Open();
                cstate.Execute(adlist);
                _dt = (DataTable)cstate.Execute(adlist);
                foreach (DataRow item in _dt.Rows)
                {
                    SpaceParts spaceParts = new SpaceParts();
                    spaceParts.ID_Item = item["ID_Item"].ToString();
                    spaceParts.Name_Item = item["Name_Item"].ToString();
                    spaceParts.Group_Item = item["Group_Item"].ToString();
                    spaceParts.Sell_Price_Unit = Convert.ToInt32(item["Sell_Price_Unit"]);
                    spaceParts.Sell_Price_All = Convert.ToInt32(item["Sell_Price_Unit"]);
                    spaceParts.Cost_Price_Unit = Convert.ToInt32(item["Sell_Price_Unit"]);
                    spaceParts.Cost_Price_All = Convert.ToInt32(item["Sell_Price_Unit"]);
                    spaceParts.Shelf_Main = item["Shelf_Main"].ToString();
                    spaceParts.Shelf_Try = item["Shelf_Try"].ToString();
                    spaceParts.Date_Count_Stock = Convert.ToDateTime(item["Date_Count_Stock"]);
                    spaceParts.Round = Convert.ToInt32(item["Count_Round"]);
                    spaceParts.Total_Stock = Convert.ToInt32(item["Total_Stock"]);
                    spaceParts.Amound_Sold = Convert.ToInt32(item["Amound_Sold"]);
                    spaceParts.Number_Parts_Booking = Convert.ToInt32(item["Number_Parts_Booking"]);
                    spaceParts.Inventory_Last_Month = Convert.ToInt32(item["Inventory_Last_Month"]);
                }

                cstate.Commit();

            }
            catch (Exception ex)
            {
                string error = ex.Message;
                cstate.Rollback();
            }
            finally
            {
                cstate.Close();
            }
            return _dt;
        }

        public void savedata(string id_item, string name_item, string group_item, double sell_price_unit, double sell_price_all, double cost_price_unit, double cost_price_all, string shelf_main, string shelf_try, string date_count_stock, int round, double total_stock, double amound_sold, double number_part_booking, double invertory_last_month,int id_brach)
        {
            IFormatProvider culture = new CultureInfo("en-US", true);
            DateTime date_count = Convert.ToDateTime(date_count_stock);
            date_count.ToString("dd-MM-yyyy");
            DateTime date_count2 = Convert.ToDateTime(date_count.Date);
            CStatementList cstate = new CStatementList(Connection.CSQLConnection);
            try
            {
                CSQLParameterList plist = new CSQLParameterList();
                plist.Add("@ID_Item", DbType.String, id_item, ParameterDirection.Input);
                plist.Add("@Name_Item", DbType.String, name_item, ParameterDirection.Input);
                plist.Add("@Group_Item", DbType.String, group_item, ParameterDirection.Input);
                plist.Add("@Sell_Price_Unit", DbType.Int32, sell_price_unit, ParameterDirection.Input);
                plist.Add("@Sell_Price_All", DbType.Int32, sell_price_all, ParameterDirection.Input);
                plist.Add("@Cost_Price_Unit", DbType.Int32, cost_price_unit, ParameterDirection.Input);
                plist.Add("@Cost_Price_All", DbType.Int32, cost_price_all, ParameterDirection.Input);
                plist.Add("@Shelf_Main", DbType.String, shelf_main, ParameterDirection.Input);
                plist.Add("@Shelf_Try", DbType.String, shelf_try, ParameterDirection.Input);
                plist.Add("@Date_Count_Stock", DbType.Date, DateTime.Now, ParameterDirection.Input);
                plist.Add("@Round", DbType.Int32, round, ParameterDirection.Input);
                plist.Add("@Total_Stock", DbType.Int32, total_stock, ParameterDirection.Input);
                plist.Add("@Amound_Sold", DbType.Int32, amound_sold, ParameterDirection.Input);
                plist.Add("@Number_Parts_Booking", DbType.Int32, number_part_booking, ParameterDirection.Input);
                plist.Add("@Inventory_Last_Month", DbType.Int32, invertory_last_month, ParameterDirection.Input);
                plist.Add("@ID_Brach", DbType.Int32, id_brach, ParameterDirection.Input);

                CSQLDataAdepterList adlist = new CSQLDataAdepterList();
                CSQLStatementValue csv = new CSQLStatementValue(this._statememet, plist, NoomLibrary.StatementType.Insert);
                adlist.Add(csv);
                cstate.Open();

                cstate.Execute(adlist);

                cstate.Commit();

            }
            catch (Exception ex)
            {
                string error = ex.Message;
                cstate.Rollback();
            }
            finally
            {
                cstate.Close();
            }
        }
        public class SpaceParts
        {
            public String ID_Item { get; set; }
            public String Name_Item { get; set; }
            public String Group_Item { get; set; }
            public float Sell_Price_Unit { get; set; }
            public float Sell_Price_All { get; set; }
            public float Cost_Price_Unit { get; set; }
            public float Cost_Price_All { get; set; }
            public String Shelf_Main { get; set; }
            public String Shelf_Try { get; set; }
            public DateTime Date_Count_Stock { get; set; }
            public int Round { get; set; }
            public float Total_Stock { get; set; }
            public float Amound_Sold { get; set; }
            public float Number_Parts_Booking { get; set; }
            public float Inventory_Last_Month { get; set; }

            public SpaceParts()
            {
                this.ID_Item = ID_Item == null ? "" : ID_Item;
                this.Name_Item = null;
                this.Group_Item = null;
                this.Sell_Price_Unit = 0;
                this.Sell_Price_All = 0;
                this.Cost_Price_Unit = 0;
                this.Cost_Price_All = 0;
                this.Shelf_Main = null;
                this.Shelf_Try = null;
                this.Date_Count_Stock = DateTime.MinValue;
                this.Round = 0;
                this.Total_Stock = 0;
                this.Amound_Sold = 0;
                this.Number_Parts_Booking = 0;
                this.Inventory_Last_Month = 0;
            }
        }
    }
}