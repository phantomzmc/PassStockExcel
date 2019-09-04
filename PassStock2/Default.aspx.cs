using PassStockExcel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PassStock2
{
    public partial class _Default : System.Web.UI.Page
    {
        OleDbDataReader dr;
        DataTable dt;

        public DateTime Date_Count_Stock;
        public int ID_Brach;
        public int round;

        TreePetch treePetch = new TreePetch();
        Dealer dealer = new Dealer();
        protected void Page_Load(object sender, EventArgs e)
        {
            SpacePartsList spacePartList = new SpacePartsList();
            if (!IsPostBack)
            {
                Panel1.Visible = false;
                Panel_Report_View.Visible = false;
                Panel_Report.Visible = false;
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if(FileUpload1.FileName == "")
            {
                this.uploadToDatabase();

                //title_upload.Text = "Can't Upload ! pleace select excel file to database";
                //title_upload.ForeColor = System.Drawing.Color.OrangeRed;

            }
            else if(FileUpload1.FileName != "")
            {
                this.uploadToDatabase();
            }
        }
        public void uploadToDatabase()
        {
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
            //int round;
            double total_stock;
            double amound_sold;
            double number_part_booking;
            double invertory_last_month;
            int id_brach;

            dt = new DataTable();
            try
            {
                string strFileName = FileUpload1.FileName;
                string path = Path.GetFileName(strFileName);
                path = path.Replace(" ", "");
                FileUpload1.SaveAs(Server.MapPath("~/ExcelFile/") + path);
                String ExcelPath = Server.MapPath("~/ExcelFile/") + path;
                OleDbConnection mycon = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + ExcelPath + ";Extended Properties='Excel 12.0 Xml;HDR=NO;'");
                mycon.Open();
                
                OleDbDataAdapter da = new OleDbDataAdapter("select * from [PartsInventoryReport_th$]", mycon);
                da.Fill(dt);
                //this.bindDataStock(dt);
                try
                    {
                        this.process_data();

                        foreach (DataRow item in dt.Rows)
                        {
                            // Response.Write("<br/>"+dr[0].ToString());
                            id_item = item[5].ToString();
                            name_item = item[6].ToString();
                            group_item = item[7].ToString();
                            sell_price_unit = double.MinValue;
                            double.TryParse(item[22].ToString(), out sell_price_unit);
                            sell_price_all = double.MinValue;
                            double.TryParse(item[23].ToString(), out sell_price_all);
                            cost_price_unit = double.MinValue;
                            double.TryParse(item[24].ToString(), out cost_price_unit);
                            cost_price_all = double.MinValue;
                            double.TryParse(item[25].ToString(), out cost_price_all);

                            shelf_main = item[3].ToString() == "" ? null : item[3].ToString();
                            shelf_try = item[4].ToString() == "" ? null : item[4].ToString();
                            date_count_stock = DateStock.Text.ToString();
                            //date_count_stock = DateTime.Now;
                            //round = Convert.ToInt32(CountRound.Value.ToString());
                            //round = 1;
                            total_stock = double.MinValue;
                            double.TryParse(item[12].ToString(), out total_stock);
                            amound_sold = double.MinValue;
                            double.TryParse(item[13].ToString(), out amound_sold);
                            number_part_booking = double.MinValue;
                            double.TryParse(item[19].ToString(), out number_part_booking);
                            invertory_last_month = double.MinValue;
                            double.TryParse(item[11].ToString(), out invertory_last_month);

                            id_brach = Convert.ToInt32(Select_Brach.Value.ToString());
                            spacePartList.savedata(id_item, name_item, group_item, sell_price_unit, sell_price_all, cost_price_unit, cost_price_all, shelf_main, shelf_try, date_count_stock, total_stock, amound_sold, number_part_booking, invertory_last_month, id_brach);
                        }
                    }
                    catch
                    {
                        title_upload.Text = "Upload Error ";
                        title_upload.ForeColor = System.Drawing.Color.Orange;

                    }
                    finally
                    {
                        title_upload.Text = "เพิ่มข้อมูล Excel เรียบร้อย";
                        title_upload.ForeColor = System.Drawing.Color.Green;

                    }
            }
            catch (Exception ex)
            {
                title_upload.Text = ex.Message;
                title_upload.ForeColor = System.Drawing.Color.Red;
            }
        }
        public void process_data()
        {
            title_upload.Text = "Uploading......";

        }
        public void bindDataStock(DataTable dt)
        {
            round = Convert.ToInt32(Session["Round"]);
            Date_Count_Stock = Convert.ToDateTime(Session["Date_Count_Stock"]);
            ID_Brach = Convert.ToInt32(Session["ID_Brach"]);

            SpacePartsList space_part_list = new SpacePartsList();
            dataStock.DataSource = space_part_list.getData(Date_Count_Stock.Date, ID_Brach, round);
            //dataStock.DataSource = dt;
            dataStock.DataBind();

        }
        protected void dataStock_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

            dataStock.PageIndex = e.NewPageIndex;
            bindDataStock(dt);

            Panel1.Visible = true;
            Panel2.Visible = false;
        }
        public void insertdata_view_click(object sebder ,EventArgs e)
        {
            Panel2.Visible = true;
            Panel1.Visible = false;
        }
        public void selectData1_Button_Click(object sender, EventArgs e)
        {
            ID_Brach = Convert.ToInt32(Select_Brach1.Value.ToString());
            Date_Count_Stock = Convert.ToDateTime(date_TextBox.Text);
            round = Convert.ToInt32(Select_Round.Value.ToString());

            Session["ID_Brach"] = Convert.ToInt32(Select_Brach1.Value.ToString());
            Session["Date_Count_Stock"] = Date_Count_Stock.Date;
            Session["Round"] = Convert.ToInt32(Select_Round.Value.ToString());

            this.bindDataStock(dt);

            Panel1.Visible = true;
            Panel2.Visible = false;

            TreePetch treePetch = new TreePetch();
            treePetch.getDifCoast_Dis_Bath(Convert.ToDateTime("2019-08-22"), 3, 1, "T");
        }
        public void select_count1_click(object sender, EventArgs e)
        {
            Session["Round"] = 1;

            Panel1.Visible = true;
            Panel2.Visible = false;

            //this.bindDataStock(dt);
        }
        public void select_count2_click(object sender, EventArgs e)
        {
            Session["Round"] = 2;
            round = 2;

            Panel1.Visible = true;
            Panel2.Visible = false;

            //this.bindDataStock(dt);
        }
        public void select_count3_click(object sender, EventArgs e)
        {
            Session["Round"] = 3;

            Panel1.Visible = true;
            Panel2.Visible = false;

            //this.bindDataStock(dt);
        }
        public void select_report_click(object sender , EventArgs e)
        {
            Panel1.Visible = false;
            Panel2.Visible = false;
            Panel_Report.Visible = true;
        }
        public void selectReport_Button_Click(object sender , EventArgs e)
        {
            treePetch.getDifCoast_Dis_Bath(Convert.ToDateTime("2019-08-22"), 3, 1, "T");
            treePetch.getDifCoast_Dis_EA(Convert.ToDateTime("2019-08-22"), 3, 1, "T");
            treePetch.getDifCoast_Dis_List(Convert.ToDateTime("2019-08-22"), 3, 1, "T");
            treePetch.getDifCoast_Plus_Bath(Convert.ToDateTime("2019-08-22"), 3, 1, "T");
            treePetch.getDifCoast_Plus_EA(Convert.ToDateTime("2019-08-22"), 3, 1, "T");
            treePetch.getDifCoast_Plus_List(Convert.ToDateTime("2019-08-22"), 3, 1, "T");
            treePetch.getSum_Amound(Convert.ToDateTime("2019-08-22"), 3, 1, "T");
            treePetch.getTotal_Count(Convert.ToDateTime("2019-08-22"), 3, 1, "T");
            treePetch.getCount_Item(Convert.ToDateTime("2019-08-22"), 3, 1, "T");

            Panel_Report_View.Visible = true;
            this.setTextReport();
        }
        public void setTextReport()
        {

            countItem.Text = treePetch.T_Count_Item.ToString();
        }
    }
}