using NoomLibrary;
using PassStockExcel;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace PassStock2
{
    public class TreePetchList : IList<TreePetchList.TreePetch>
    {
        private CStatement _statememet_Count, _statememet_Total_Coast, _statememet_Sum_Amound, _statememet_Dis_Bath, _statememet_Dis_EA, _statememet_Dis_List, _statememet_Plus_Bath, _statememet_Plus_EA, _statememet_Plus_List;
        private Dictionary<int, TreePetch> _list = new Dictionary<int, TreePetch>();


        SqlDataAdapter adapter = new SqlDataAdapter();

        #region Imprement
        public TreePetch this[int index]
        {
            get
            {
                TreePetch result;
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
                TreePetch result;
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

        public void Add(TreePetch item)
        {
            this.Add(item);
        }

        public void Clear()
        {
            this.Clear();
        }

        public bool Contains(TreePetch item)
        {
            return this.Contains(item);
        }

        public void CopyTo(TreePetch[] array, int arrayIndex)
        {
            this.CopyTo(array, arrayIndex);
        }

        public IEnumerator<TreePetch> GetEnumerator() => this.GetEnumerator();

        public int IndexOf(TreePetch item)
        {
            return this.IndexOf(item);
        }

        public void Insert(int index, TreePetch item)
        {
            this.Insert(index, item);
        }

        public bool Remove(TreePetch item)
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

        public TreePetchList()
        {
            this._statememet_Count = new CStatement("uspSelectCount_Item", "uspImportExcelStock", "UPDATE", "DELECT", System.Data.CommandType.StoredProcedure);
            this._statememet_Total_Coast = new CStatement("uspSelectTotal_Coast", "uspImportExcelStock", "UPDATE", "DELECT", System.Data.CommandType.StoredProcedure);
            this._statememet_Sum_Amound = new CStatement("uspSelectSum_AmoundSold", "uspImportExcelStock", "UPDATE", "DELECT", System.Data.CommandType.StoredProcedure);

            this._statememet_Dis_Bath = new CStatement("uspSelectDif_Coast_Dis_Bath", "uspImportExcelStock", "UPDATE", "DELECT", System.Data.CommandType.StoredProcedure);
            this._statememet_Dis_EA = new CStatement("uspSelectDif_Coast_Dis_EA", "uspImportExcelStock", "UPDATE", "DELECT", System.Data.CommandType.StoredProcedure);
            this._statememet_Dis_List = new CStatement("uspSelectDif_Coast_Dis_List", "uspImportExcelStock", "UPDATE", "DELECT", System.Data.CommandType.StoredProcedure);
            this._statememet_Plus_Bath = new CStatement("uspSelectDif_Coast_Plus_Bath", "uspImportExcelStock", "UPDATE", "DELECT", System.Data.CommandType.StoredProcedure);
            this._statememet_Plus_EA = new CStatement("uspSelectDif_Coast_Plus_EA", "uspImportExcelStock", "UPDATE", "DELECT", System.Data.CommandType.StoredProcedure);
            this._statememet_Plus_List = new CStatement("uspSelectDif_Coast_Plus_List", "uspImportExcelStock", "UPDATE", "DELECT", System.Data.CommandType.StoredProcedure);
        }
        public int getCount_Item(DateTime date_count_stock, int id_brach, int count, string type_item)
        {
            int countitem = 0;
            DataTable _dt = new DataTable();
            TreePetch treePetch = new TreePetch();

            String count_stock = date_count_stock.ToString("yyyy-MM-dd");
            CStatementList cstate = new CStatementList(Connection.CSQLConnection);
            try
            {
                CSQLParameterList plist = new CSQLParameterList();
                plist.Add("@Date_Count_Stock", DbType.String, count_stock, ParameterDirection.Input);
                plist.Add("@ID_Brach", DbType.Int32, id_brach, ParameterDirection.Input);
                plist.Add("@Round", DbType.Int32, count, ParameterDirection.Input);
                plist.Add("@Type_Item", DbType.String, type_item, ParameterDirection.Input);


                CSQLDataAdepterList adlist = new CSQLDataAdepterList();
                CSQLStatementValue csv = new CSQLStatementValue(this._statememet_Count, plist, NoomLibrary.StatementType.Select);
                adlist.Add(csv);
                cstate.Open();
                cstate.Execute(adlist);

                _dt = (DataTable)cstate.Execute(adlist);

                foreach (DataRow item in _dt.Rows)
                {
                    treePetch.T_Count_Item = Convert.ToInt32(item["Count_Item"]);
                    countitem = Convert.ToInt32(item["Count_Item"]);
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
            return countitem;
        }

        public int getTotal_Count(DateTime date_count_stock, int id_brach, int count, string type_item)
        {
            int total_count = 0;
            DataTable _dt = new DataTable();
            String count_stock = date_count_stock.ToString("yyyy-MM-dd");
            CStatementList cstate = new CStatementList(Connection.CSQLConnection);
            try
            {
                CSQLParameterList plist = new CSQLParameterList();
                plist.Add("@Date_Count_Stock", DbType.String, count_stock, ParameterDirection.Input);
                plist.Add("@ID_Brach", DbType.Int32, id_brach, ParameterDirection.Input);
                plist.Add("@Round", DbType.Int32, count, ParameterDirection.Input);
                plist.Add("@Type_Item", DbType.String, type_item, ParameterDirection.Input);


                CSQLDataAdepterList adlist = new CSQLDataAdepterList();
                CSQLStatementValue csv = new CSQLStatementValue(this._statememet_Total_Coast, plist, NoomLibrary.StatementType.Select);
                adlist.Add(csv);
                cstate.Open();
                cstate.Execute(adlist);

                _dt = (DataTable)cstate.Execute(adlist);

                foreach (DataRow item in _dt.Rows)
                {
                    TreePetch treePetch = new TreePetch();
                    treePetch.T_Total_Coast = Convert.ToInt32(item["Total_Coast"]);
                    total_count = Convert.ToInt32(item["Total_Coast"]);
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
            return total_count;
        }

        public int getSum_Amound(DateTime date_count_stock, int id_brach, int count, string type_item)
        {
            int sum_amound = 0;
            DataTable _dt = new DataTable();
            String count_stock = date_count_stock.ToString("yyyy-MM-dd");
            CStatementList cstate = new CStatementList(Connection.CSQLConnection);
            try
            {
                CSQLParameterList plist = new CSQLParameterList();
                plist.Add("@Date_Count_Stock", DbType.String, count_stock, ParameterDirection.Input);
                plist.Add("@ID_Brach", DbType.Int32, id_brach, ParameterDirection.Input);
                plist.Add("@Round", DbType.Int32, count, ParameterDirection.Input);
                plist.Add("@Type_Item", DbType.String, type_item, ParameterDirection.Input);


                CSQLDataAdepterList adlist = new CSQLDataAdepterList();
                CSQLStatementValue csv = new CSQLStatementValue(this._statememet_Sum_Amound, plist, NoomLibrary.StatementType.Select);
                adlist.Add(csv);
                cstate.Open();
                cstate.Execute(adlist);

                _dt = (DataTable)cstate.Execute(adlist);

                foreach (DataRow item in _dt.Rows)
                {
                    TreePetch treePetch = new TreePetch();
                    treePetch.T_Sum_AmoundSold = Convert.ToInt32(item["Total"]);
                    sum_amound = Convert.ToInt32(item["Total"]);
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
            return sum_amound;
        }

        public int getDifCoast_Dis_Bath(DateTime date_count_stock, int id_brach, int count,string type_item)
        {
            int T_Coast_Dis_Bath = 0;
            DataTable _dt = new DataTable();
            String count_stock = date_count_stock.ToString("yyyy-MM-dd");
            CStatementList cstate = new CStatementList(Connection.CSQLConnection);
            try
            { 
                CSQLParameterList plist = new CSQLParameterList();
                plist.Add("@Date_Count_Stock", DbType.String, count_stock, ParameterDirection.Input);
                plist.Add("@ID_Brach", DbType.Int32, id_brach, ParameterDirection.Input);
                plist.Add("@Round", DbType.Int32, count, ParameterDirection.Input);
                plist.Add("@Type_Item", DbType.String, type_item, ParameterDirection.Input);


                CSQLDataAdepterList adlist = new CSQLDataAdepterList();
                CSQLStatementValue csv = new CSQLStatementValue(this._statememet_Dis_Bath, plist, NoomLibrary.StatementType.Select);
                adlist.Add(csv);
                cstate.Open();
                cstate.Execute(adlist);

                _dt = (DataTable)cstate.Execute(adlist);

                foreach (DataRow item in _dt.Rows)
                {
                    TreePetch treePetch = new TreePetch();
                    T_Coast_Dis_Bath = Convert.ToInt32(item["DIF_Total_Coast"]);
                    treePetch.T_Coast_Dis_Bath = T_Coast_Dis_Bath;
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
            return T_Coast_Dis_Bath;
        }

        public int getDifCoast_Dis_EA(DateTime date_count_stock, int id_brach, int count, string type_item)
        {
            DataTable _dt = new DataTable();
            int T_Coast_Dis_EA = 0;
            String count_stock = date_count_stock.ToString("yyyy-MM-dd");
            CStatementList cstate = new CStatementList(Connection.CSQLConnection);
            try
            {
                CSQLParameterList plist = new CSQLParameterList();
                plist.Add("@Date_Count_Stock", DbType.String, count_stock, ParameterDirection.Input);
                plist.Add("@ID_Brach", DbType.Int32, id_brach, ParameterDirection.Input);
                plist.Add("@Round", DbType.Int32, count, ParameterDirection.Input);
                plist.Add("@Type_Item", DbType.String, type_item, ParameterDirection.Input);


                CSQLDataAdepterList adlist = new CSQLDataAdepterList();
                CSQLStatementValue csv = new CSQLStatementValue(this._statememet_Dis_EA, plist, NoomLibrary.StatementType.Select);
                adlist.Add(csv);
                cstate.Open();
                cstate.Execute(adlist);

                _dt = (DataTable)cstate.Execute(adlist);

                foreach (DataRow item in _dt.Rows)
                {
                    TreePetch treePetch = new TreePetch();
                    treePetch.T_Coast_Dis_EA = Convert.ToDouble(item["DIF_Total_Coast"]);
                    T_Coast_Dis_EA = Convert.ToInt32(item["DIF_Total_Coast"]);
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
            return T_Coast_Dis_EA;
        }

        public int getDifCoast_Dis_List(DateTime date_count_stock, int id_brach, int count, string type_item)
        {
            DataTable _dt = new DataTable();
            int Count_List = 0;
            String count_stock = date_count_stock.ToString("yyyy-MM-dd");
            CStatementList cstate = new CStatementList(Connection.CSQLConnection);
            try
            {
                CSQLParameterList plist = new CSQLParameterList();
                plist.Add("@Date_Count_Stock", DbType.String, count_stock, ParameterDirection.Input);
                plist.Add("@ID_Brach", DbType.Int32, id_brach, ParameterDirection.Input);
                plist.Add("@Round", DbType.Int32, count, ParameterDirection.Input);
                plist.Add("@Type_Item", DbType.String, type_item, ParameterDirection.Input);


                CSQLDataAdepterList adlist = new CSQLDataAdepterList();
                CSQLStatementValue csv = new CSQLStatementValue(this._statememet_Dis_List, plist, NoomLibrary.StatementType.Select);
                adlist.Add(csv);
                cstate.Open();
                cstate.Execute(adlist);

                _dt = (DataTable)cstate.Execute(adlist);

                foreach (DataRow item in _dt.Rows)
                {
                    TreePetch treePetch = new TreePetch();
                    treePetch.T_Coast_Dis_List = Convert.ToDouble(item["Count_List"]);
                    Count_List = Convert.ToInt32(item["Count_List"]);
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
            return Count_List;
        }

        public double getDifCoast_Plus_Bath(DateTime date_count_stock, int id_brach, int count, string type_item)
        {
            double DIF_Total_Coast = 0;
            DataTable _dt = new DataTable();
            String count_stock = date_count_stock.ToString("yyyy-MM-dd");
            CStatementList cstate = new CStatementList(Connection.CSQLConnection);
            try
            {
                CSQLParameterList plist = new CSQLParameterList();
                plist.Add("@Date_Count_Stock", DbType.String, count_stock, ParameterDirection.Input);
                plist.Add("@ID_Brach", DbType.Int32, id_brach, ParameterDirection.Input);
                plist.Add("@Round", DbType.Int32, count, ParameterDirection.Input);
                plist.Add("@Type_Item", DbType.String, type_item, ParameterDirection.Input);


                CSQLDataAdepterList adlist = new CSQLDataAdepterList();
                CSQLStatementValue csv = new CSQLStatementValue(this._statememet_Plus_Bath, plist, NoomLibrary.StatementType.Select);
                adlist.Add(csv);
                cstate.Open();
                cstate.Execute(adlist);

                _dt = (DataTable)cstate.Execute(adlist);

                foreach (DataRow item in _dt.Rows)
                {
                    TreePetch treePetch = new TreePetch();
                    treePetch.T_Coast_Plus_Bath = Convert.ToInt64(item["DIF_Total_Coast"]);
                    DIF_Total_Coast = Convert.ToDouble(item["DIF_Total_Coast"]);
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
            return DIF_Total_Coast;
        }

        public double getDifCoast_Plus_EA(DateTime date_count_stock, int id_brach, int count, string type_item)
        {
            DataTable _dt = new DataTable();
            double DIF_Total_Coast = 0;
            String count_stock = date_count_stock.ToString("yyyy-MM-dd");
            CStatementList cstate = new CStatementList(Connection.CSQLConnection);
            try
            {
                CSQLParameterList plist = new CSQLParameterList();
                plist.Add("@Date_Count_Stock", DbType.String, count_stock, ParameterDirection.Input);
                plist.Add("@ID_Brach", DbType.Int32, id_brach, ParameterDirection.Input);
                plist.Add("@Round", DbType.Int32, count, ParameterDirection.Input);
                plist.Add("@Type_Item", DbType.String, type_item, ParameterDirection.Input);


                CSQLDataAdepterList adlist = new CSQLDataAdepterList();
                CSQLStatementValue csv = new CSQLStatementValue(this._statememet_Plus_EA, plist, NoomLibrary.StatementType.Select);
                adlist.Add(csv);
                cstate.Open();
                cstate.Execute(adlist);

                _dt = (DataTable)cstate.Execute(adlist);

                foreach (DataRow item in _dt.Rows)
                {
                    TreePetch treePetch = new TreePetch();
                    treePetch.T_Coast_Plus_EA = Convert.ToInt64(item["DIF_Total_Coast"]);
                    DIF_Total_Coast = Convert.ToDouble(item["DIF_Total_Coast"]);
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
            return DIF_Total_Coast;
        }

        public double getDifCoast_Plus_List(DateTime date_count_stock, int id_brach, int count, string type_item)
        {
            DataTable _dt = new DataTable();
            double Count_List = 0;
            String count_stock = date_count_stock.ToString("yyyy-MM-dd");
            CStatementList cstate = new CStatementList(Connection.CSQLConnection);
            try
            {
                CSQLParameterList plist = new CSQLParameterList();
                plist.Add("@Date_Count_Stock", DbType.String, count_stock, ParameterDirection.Input);
                plist.Add("@ID_Brach", DbType.Int32, id_brach, ParameterDirection.Input);
                plist.Add("@Round", DbType.Int32, count, ParameterDirection.Input);
                plist.Add("@Type_Item", DbType.String, type_item, ParameterDirection.Input);


                CSQLDataAdepterList adlist = new CSQLDataAdepterList();
                CSQLStatementValue csv = new CSQLStatementValue(this._statememet_Plus_List, plist, NoomLibrary.StatementType.Select);
                adlist.Add(csv);
                cstate.Open();
                cstate.Execute(adlist);

                _dt = (DataTable)cstate.Execute(adlist);

                foreach (DataRow item in _dt.Rows)
                {
                    TreePetch treePetch = new TreePetch();
                    treePetch.T_Coast_Plus_List = Convert.ToInt32(item["Coast_List"]);
                    Count_List = Convert.ToDouble(item["Coast_List"]);
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
            return Count_List;
        }

        public class TreePetch
        {
            public int T_Count_Item { get; set; }
            public Double T_Total_Coast { get; set; }
            public Double T_Sum_AmoundSold { get; set; }
            public Double T_Coast_Dis_EA { get; set; }
            public Double T_Coast_Dis_List { get; set; }
            public Double T_Coast_Dis_Bath { get; set; }
            public Double T_Coast_Plus_EA { get; set; }
            public Double T_Coast_Plus_List { get; set; }
            public Double T_Coast_Plus_Bath { get; set; }

            public TreePetch()
            {
                this.T_Count_Item = 0;
                this.T_Total_Coast = 0;
                this.T_Sum_AmoundSold = 0;
                this.T_Coast_Dis_EA = 0.0;
                this.T_Coast_Dis_List = 0;
                this.T_Coast_Dis_Bath = 0.0;
                this.T_Coast_Plus_EA = 0.0;
                this.T_Coast_Plus_List = 0;
                this.T_Coast_Plus_Bath = 0.0;
            }
        }

    }
}