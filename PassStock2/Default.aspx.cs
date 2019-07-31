using PassStockExcel;
using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.IO;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PassStock2
{
    public partial class _Default : Page
    {
        OleDbDataReader dr;

        public DateTime Date_Count_Stock;
        public int ID_Brach;
        protected void Page_Load(object sender, EventArgs e)
        {
            SpacePartsList spacePartList = new SpacePartsList();
            //spacePartList.getData();

            Panel2.Visible = true;

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            #region process
            this.process_data();

            SpacePartsList spacePartList = new SpacePartsList();

            String id_item;
            String name_item;
            String group_item;
            double sell_price_unit;
            double sell_price_all;
            double cost_price_unit;
            double cost_price_all;
            String shelf_main;
            String shelf_try;
            String date_count_stock;
            int round;
            double total_stock;
            double amound_sold;
            double number_part_booking;
            double invertory_last_month;
            int id_brach;

            try
            {
                string path = Path.GetFileName(FileUpload1.FileName);
                path = path.Replace(" ", "");
                FileUpload1.SaveAs(Server.MapPath("~/ExcelFile/") + path);
                String ExcelPath = Server.MapPath("~/ExcelFile/") + path;
                OleDbConnection mycon = new OleDbConnection("Provider = Microsoft.ACE.OLEDB.12.0; Data Source = " + ExcelPath + "; Extended Properties=Excel 8.0; Persist Security Info = False");
                mycon.Open();
                OleDbCommand cmd = new OleDbCommand("select * from [PartsInventoryReport_th$]", mycon);
                dr = cmd.ExecuteReader();

                try
                {
                    if (DateTime.Now.ToString() == null)
                    {

                    }
                    //else if (Convert.ToInt32(CountRound.Value.ToString()) == 0)
                    //{

                    //}
                    else
                    {
                        while (dr.Read())
                        {
                            // Response.Write("<br/>"+dr[0].ToString());
                            id_item = dr[5].ToString();
                            name_item = dr[6].ToString();
                            group_item = dr[7].ToString();
                            sell_price_unit = Convert.ToDouble(dr[22].ToString());
                            sell_price_all = Convert.ToDouble(dr[23].ToString());
                            cost_price_unit = Convert.ToDouble(dr[24].ToString());
                            cost_price_all = Convert.ToDouble(dr[25].ToString());
                            shelf_main = dr[3].ToString();
                            shelf_try = dr[4].ToString();
                            //date_count_stock = DateStock.Value.ToString();
                            date_count_stock = DateTime.Now.ToString();
                            //round = Convert.ToInt32(CountRound.Value.ToString());
                            round = 1;
                            total_stock = Convert.ToDouble(dr[12].ToString());
                            amound_sold = Convert.ToDouble(dr[13].ToString());
                            number_part_booking = Convert.ToDouble(dr[19].ToString());
                            invertory_last_month = Convert.ToDouble(dr[11].ToString());
                            id_brach = Convert.ToInt32(Select_Brach.Value.ToString());

                            spacePartList.savedata(id_item, name_item, group_item, sell_price_unit, sell_price_all, cost_price_unit, cost_price_all, shelf_main, shelf_try, date_count_stock, round, total_stock, amound_sold, number_part_booking, invertory_last_month, id_brach);
                        }
                    }

                }
                catch
                {
                    title_upload.Text = "Upload Error ";
                    title_upload.ForeColor = System.Drawing.Color.Orange;
                }
                finally
                {
                    title_upload.Text = "Data Has Been Saved Successfully";
                    title_upload.ForeColor = System.Drawing.Color.Green;
                    this.bindDataStock();
                    mycon.Close();

                }

                //lblText1.Text = "Data Has Been Saved Successfully";
            }
            catch(Exception ex)
            {
                title_upload.Text = ex.Message.ToString();
                title_upload.ForeColor = System.Drawing.Color.Red;
            }
            finally
            {
            }
            //catch
            //{
            //    title_upload.Text = "Save Data Error";
            //    title_upload.ForeColor = System.Drawing.Color.Red;
            //}
            #endregion
        }
        public void process_data()
        {
            title_upload.Text = "Save Date To Database...... ";
        }
        public void bindDataStock()
        {
            Date_Count_Stock = Convert.ToDateTime(DateStock.Text.ToString());
            ID_Brach = Convert.ToInt32(Select_Brach.Value.ToString());

            SpacePartsList space_part_list = new SpacePartsList();
            dataStock.DataSource = space_part_list.getData(Date_Count_Stock, ID_Brach);
            dataStock.DataBind();

        }
        public void bindDataStock2()
        {
            Date_Count_Stock = Convert.ToDateTime(DateStock2.Text.ToString());
            ID_Brach = Convert.ToInt32(Select_Brach.Value.ToString());

            SpacePartsList space_part_list = new SpacePartsList();
            dataStock.DataSource = space_part_list.getData(Date_Count_Stock, ID_Brach);
            dataStock.DataBind();

        }
        protected void dataStock_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            dataStock.PageIndex = e.NewPageIndex;
            bindDataStock();
        }
        protected void btnSelect_Click(object sender, EventArgs e)
        {
            bindDataStock2();
        }
    }
}