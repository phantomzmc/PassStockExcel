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

        TreePetchList treePetchList = new TreePetchList();
        DealerList dealerList = new DealerList();

        double te_difCoast_Dis_Bath;
        double te_difCoast_Dis_EA;
        double te_difCoast_Dis_List;
        double te_difCoast_Plus_Bath;
        double te_difCoast_Plus_EA;
        double te_difCoast_Plus_List;
        double te_sum_amound;
        double te_total_count;
        double te_count_item;

        double de_difCoast_Dis_Bath;
        double de_difCoast_Dis_EA;
        double de_difCoast_Dis_List;
        double de_difCoast_Plus_Bath;
        double de_difCoast_Plus_EA;
        double de_difCoast_Plus_List;
        double de_sum_amound;
        double de_total_count;
        double de_count_item;

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
            te_difCoast_Dis_Bath = treePetchList.getDifCoast_Dis_Bath(Convert.ToDateTime("2019-08-22"), 3, 1, "T");
            te_difCoast_Dis_EA = treePetchList.getDifCoast_Dis_EA(Convert.ToDateTime("2019-08-22"), 3, 1, "T");
            te_difCoast_Dis_List = treePetchList.getDifCoast_Dis_List(Convert.ToDateTime("2019-08-22"), 3, 1, "T");
            te_difCoast_Plus_Bath = treePetchList.getDifCoast_Plus_Bath(Convert.ToDateTime("2019-08-22"), 3, 1, "T");
            te_difCoast_Plus_EA = treePetchList.getDifCoast_Plus_EA(Convert.ToDateTime("2019-08-22"), 3, 1, "T");
            te_difCoast_Plus_List = treePetchList.getDifCoast_Plus_List(Convert.ToDateTime("2019-08-22"), 3, 1, "T");
            te_sum_amound = treePetchList.getSum_Amound(Convert.ToDateTime("2019-08-22"), 3, 1, "T");
            te_total_count = treePetchList.getTotal_Count(Convert.ToDateTime("2019-08-22"), 3, 1, "T");
            te_count_item = treePetchList.getCount_Item(Convert.ToDateTime("2019-08-22"), 3, 1, "T");

            de_difCoast_Dis_Bath = dealerList.getDifCoast_Dis_Bath(Convert.ToDateTime("2019-08-22"), 3, 1, "D");
            de_difCoast_Dis_EA = dealerList.getDifCoast_Dis_EA(Convert.ToDateTime("2019-08-22"), 3, 1, "D");
            de_difCoast_Dis_List = dealerList.getDifCoast_Dis_List(Convert.ToDateTime("2019-08-22"), 3, 1, "D");
            de_difCoast_Plus_Bath = dealerList.getDifCoast_Plus_Bath(Convert.ToDateTime("2019-08-22"), 3, 1, "D");
            de_difCoast_Plus_EA = dealerList.getDifCoast_Plus_EA(Convert.ToDateTime("2019-08-22"), 3, 1, "D");
            de_difCoast_Plus_List = dealerList.getDifCoast_Plus_List(Convert.ToDateTime("2019-08-22"), 3, 1, "D");
            de_sum_amound = dealerList.getSum_Amound(Convert.ToDateTime("2019-08-22"), 3, 1, "D");
            de_total_count = dealerList.getTotal_Count(Convert.ToDateTime("2019-08-22"), 3, 1, "D");
            de_count_item = dealerList.getCount_Item(Convert.ToDateTime("2019-08-22"), 3, 1, "D");

            Panel_Report_View.Visible = true;
            this.setTextReport_T();
            this.setTextReport_D();
        }
        public void setTextReport_T()
        {
            
            t_difCoast_Plus_List.Text = string.Format("{0:#,###.##}", decimal.Parse(te_difCoast_Plus_List.ToString()));
            t_difCoast_Plus_EA.Text = string.Format("{0:#,###.##}", decimal.Parse(te_difCoast_Plus_EA.ToString()));
            t_difCoast_Plus_Bath.Text = string.Format("{0:#,###.##}", decimal.Parse(te_difCoast_Plus_Bath.ToString()));


            t_difCoast_Dis_List.Text = string.Format("{0:#,###.##}", decimal.Parse(te_difCoast_Dis_List.ToString()));
            t_difCoast_Dis_EA.Text = string.Format("{0:#,###.##}", decimal.Parse(te_difCoast_Dis_EA.ToString()));
            t_difCoast_Dis_Bath.Text = string.Format("{0:#,###.##}", decimal.Parse(te_difCoast_Dis_Bath.ToString()));

            t_count_item.Text = string.Format("{0:#,###.##}", decimal.Parse(te_count_item.ToString()));
            t_total_count.Text = string.Format("{0:#,###.##}", decimal.Parse(te_sum_amound.ToString()));
            t_sum_amound.Text = string.Format("{0:#,###.##}", decimal.Parse(te_total_count.ToString()));

            t_total_bal_bath.Text = string.Format("{0:#,###.##}", decimal.Parse((te_difCoast_Plus_Bath - te_difCoast_Dis_Bath).ToString()));
            t_total_dif_bath.Text = string.Format("{0:#,###.##}", decimal.Parse((te_difCoast_Plus_Bath + te_difCoast_Dis_Bath).ToString()));

            this.setTextReportPercent_T();
        }
        public void setTextReportPercent_T()
        {
            double per_difCoast_Plus_List = (te_difCoast_Plus_List / te_count_item) * 100;
            double per_difCoast_Plus_EA = (te_difCoast_Plus_EA / te_sum_amound) * 100;
            double per_difCoast_Plus_Bath = (te_difCoast_Plus_Bath / te_total_count) *100;
            double per_difCoast_Dis_List = (te_difCoast_Dis_List / te_count_item) * 100;
            double per_difCoast_Dis_EA = (te_difCoast_Dis_EA / te_sum_amound) * 100;
            double per_difCoast_Dis_Bath = (te_difCoast_Dis_Bath / te_total_count) * 100;

            t_difCoast_Plus_List_Percent.Text = string.Format("{0:##.##}", decimal.Parse(per_difCoast_Plus_List.ToString()));
            t_difCoast_Plus_EA_Percent.Text = string.Format("{0:##.##}", decimal.Parse(per_difCoast_Plus_EA.ToString())); 
            t_difCoast_Plus_Bath_Percent.Text = string.Format("{0:##.##}", decimal.Parse(per_difCoast_Plus_Bath.ToString()));

            t_difCoast_Dis_List_Percent.Text = string.Format("{0:##.##}", decimal.Parse(per_difCoast_Dis_List.ToString()));
            t_difCoast_Dis_EA_Percent.Text = string.Format("{0:##.##}", decimal.Parse(per_difCoast_Dis_EA.ToString()));
            t_difCoast_Dis_Bath_Percent.Text = string.Format("{0:##.##}", decimal.Parse(per_difCoast_Dis_Bath.ToString()));

            t_total_bal_percent.Text = string.Format("{0:##.##}", decimal.Parse((((te_difCoast_Plus_Bath - te_difCoast_Dis_Bath) / te_total_count) * 100).ToString()));
            t_total_dif_percent.Text = string.Format("{0:##.##}", decimal.Parse((((te_difCoast_Plus_Bath + te_difCoast_Dis_Bath) / te_total_count) * 100).ToString()));
        }
        public void setTextReport_D()
        {

            d_difCoast_Plus_List.Text = string.Format("{0:#,###.##}", decimal.Parse(de_difCoast_Plus_List.ToString()));
            d_difCoast_Plus_EA.Text = string.Format("{0:#,###.##}", decimal.Parse(de_difCoast_Plus_EA.ToString()));
            d_difCoast_Plus_Bath.Text = string.Format("{0:#,###.##}", decimal.Parse(de_difCoast_Plus_Bath.ToString()));


            d_difCoast_Dis_List.Text = string.Format("{0:#,###.##}", decimal.Parse(de_difCoast_Dis_List.ToString()));
            d_difCoast_Dis_EA.Text = string.Format("{0:#,###.##}", decimal.Parse(de_difCoast_Dis_EA.ToString()));
            d_difCoast_Dis_Bath.Text = string.Format("{0:#,###.##}", decimal.Parse(de_difCoast_Dis_Bath.ToString()));

            d_count_item.Text = string.Format("{0:#,###.##}", decimal.Parse(de_count_item.ToString()));
            d_total_count.Text = string.Format("{0:#,###.##}", decimal.Parse(de_total_count.ToString()));
            d_sum_amound.Text = string.Format("{0:#,###.##}", decimal.Parse(de_sum_amound.ToString()));

            d_total_bal_bath.Text = string.Format("{0:#,###.##}", decimal.Parse((de_difCoast_Plus_Bath - de_difCoast_Dis_Bath).ToString()));
            d_total_dif_bath.Text = string.Format("{0:#,###.##}", decimal.Parse((de_difCoast_Plus_Bath + de_difCoast_Dis_Bath).ToString()));

            this.setTextReportPercent_D();
        }
        public void setTextReportPercent_D()
        {
            double per_difCoast_Plus_List = (de_difCoast_Plus_List / de_count_item) * 100;
            double per_difCoast_Plus_EA = (de_difCoast_Plus_EA / de_sum_amound) * 100;
            double per_difCoast_Plus_Bath = (de_difCoast_Plus_Bath / de_total_count) * 100;
            double per_difCoast_Dis_List = (de_difCoast_Dis_List / de_count_item) * 100;
            double per_difCoast_Dis_EA = (de_difCoast_Dis_EA / de_sum_amound) * 100;
            double per_difCoast_Dis_Bath = (de_difCoast_Dis_Bath / de_total_count) * 100;

            d_difCoast_Plus_List_Percent.Text = per_difCoast_Plus_List == 0 ? per_difCoast_Plus_List.ToString() : string.Format("{0:#.##}", decimal.Parse(per_difCoast_Plus_List.ToString()));
            d_difCoast_Plus_EA_Percent.Text = per_difCoast_Plus_EA == 0 ? per_difCoast_Plus_EA.ToString() : string.Format("{0:#.##}", decimal.Parse(per_difCoast_Plus_EA.ToString()));
            d_difCoast_Plus_Bath_Percent.Text = per_difCoast_Plus_Bath == 0 ? per_difCoast_Plus_Bath.ToString() : string.Format("{0:#.##}", decimal.Parse(per_difCoast_Plus_Bath.ToString()));

            d_difCoast_Dis_List_Percent.Text = per_difCoast_Dis_List == 0 ? per_difCoast_Dis_List.ToString() : string.Format("{0:#.##}", decimal.Parse(per_difCoast_Dis_List.ToString()));
            d_difCoast_Dis_EA_Percent.Text = per_difCoast_Dis_EA == 0 ? per_difCoast_Dis_EA.ToString() : string.Format("{0:#.##}", decimal.Parse(per_difCoast_Dis_EA.ToString()));
            d_difCoast_Dis_Bath_Percent.Text = per_difCoast_Dis_Bath ==0 ? per_difCoast_Dis_Bath.ToString() : string.Format("{0:#.##}", decimal.Parse(per_difCoast_Dis_Bath.ToString()));

            d_total_bal_bath_percent.Text = string.Format("{0:#.##}", decimal.Parse(((de_difCoast_Plus_Bath - de_difCoast_Dis_Bath) / de_total_count * 100).ToString()));
            d_total_dif_bath_percent.Text = string.Format("{0:#.##}", decimal.Parse(((de_difCoast_Plus_Bath + de_difCoast_Dis_Bath) / de_total_count * 100).ToString()));
        }
    }
}