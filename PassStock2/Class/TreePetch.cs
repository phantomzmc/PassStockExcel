using NoomLibrary;
using PassStockExcel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace PassStock2
{
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

        private CStatement _statememet_Count, _statememet_Total_Coast, _statememet_Sum_Amound,_statememet_Dis_Bath, _statememet_Dis_EA, _statememet_Dis_List, _statememet_Plus_Bath, _statememet_Plus_EA, _statememet_Plus_List;

        SqlDataAdapter adapter = new SqlDataAdapter();

        public void getCount_Item(DateTime date_count_stock, int id_brach, int count, string type_item)
        {
            int countitem;
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
        }

        public void getTotal_Count(DateTime date_count_stock, int id_brach, int count, string type_item)
        {
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
            return;
        }

        public void getSum_Amound(DateTime date_count_stock, int id_brach, int count, string type_item)
        {
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
            return;
        }

        public void getDifCoast_Dis_Bath(DateTime date_count_stock, int id_brach, int count,string type_item)
        {
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
                    treePetch.T_Coast_Dis_Bath = Convert.ToDouble(item["DIF_Total_Coast"]);
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
            return ;
        }

        public void getDifCoast_Dis_EA(DateTime date_count_stock, int id_brach, int count, string type_item)
        {
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
                CSQLStatementValue csv = new CSQLStatementValue(this._statememet_Dis_EA, plist, NoomLibrary.StatementType.Select);
                adlist.Add(csv);
                cstate.Open();
                cstate.Execute(adlist);

                _dt = (DataTable)cstate.Execute(adlist);

                foreach (DataRow item in _dt.Rows)
                {
                    TreePetch treePetch = new TreePetch();
                    treePetch.T_Coast_Dis_EA = Convert.ToDouble(item["DIF_Total_Coast"]);
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
            return;
        }

        public void getDifCoast_Dis_List(DateTime date_count_stock, int id_brach, int count, string type_item)
        {
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
                CSQLStatementValue csv = new CSQLStatementValue(this._statememet_Dis_List, plist, NoomLibrary.StatementType.Select);
                adlist.Add(csv);
                cstate.Open();
                cstate.Execute(adlist);

                _dt = (DataTable)cstate.Execute(adlist);

                foreach (DataRow item in _dt.Rows)
                {
                    TreePetch treePetch = new TreePetch();
                    treePetch.T_Coast_Dis_List = Convert.ToDouble(item["Count_List"]);
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
            return;
        }

        public void getDifCoast_Plus_Bath(DateTime date_count_stock, int id_brach, int count, string type_item)
        {
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
                    treePetch.T_Coast_Plus_Bath = Convert.ToDouble(item["DIF_Total_Coast"]);
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
            return;
        }

        public void getDifCoast_Plus_EA(DateTime date_count_stock, int id_brach, int count, string type_item)
        {
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
                CSQLStatementValue csv = new CSQLStatementValue(this._statememet_Plus_EA, plist, NoomLibrary.StatementType.Select);
                adlist.Add(csv);
                cstate.Open();
                cstate.Execute(adlist);

                _dt = (DataTable)cstate.Execute(adlist);

                foreach (DataRow item in _dt.Rows)
                {
                    TreePetch treePetch = new TreePetch();
                    treePetch.T_Coast_Plus_EA = Convert.ToDouble(item["DIF_Total_Coast"]);
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
            return;
        }

        public void getDifCoast_Plus_List(DateTime date_count_stock, int id_brach, int count, string type_item)
        {
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
                CSQLStatementValue csv = new CSQLStatementValue(this._statememet_Dis_List, plist, NoomLibrary.StatementType.Select);
                adlist.Add(csv);
                cstate.Open();
                cstate.Execute(adlist);

                _dt = (DataTable)cstate.Execute(adlist);

                foreach (DataRow item in _dt.Rows)
                {
                    TreePetch treePetch = new TreePetch();
                    treePetch.T_Coast_Plus_List = Convert.ToDouble(item["Count_List"]);
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
            return;
        }
    }
}