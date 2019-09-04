<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="PassStock2._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <div class="row">
            <img alt="" src="http://192.168.1.186/Portals/0/Images/logo/logosala_resize.png" />
        </div>
        <p class="lead">เพิ่มไฟล์ Excel สต็อคสินค้าลงในฐานข้อมูล</p>
        <ul class="nav nav-tabs" role="tablist">
            <li class="nav-item">
                <asp:Button ID="insert_data_btn" runat="server" CssClass="btn btn-link btn-block" Text="เพิ่มข้อมูล"
                    onClick="insertdata_view_click" />
                <%--                        <a class="nav-link active" data-toggle="tab" href="#insert_data" runat="server"
                            onclick="insert_data_click">เพิ่มข้อมูล</a>--%>
            </li>
            <li class="nav-item">
                <asp:Button ID="select_count1_btn" runat="server" CssClass="btn btn-link btn-block" Text="แสดงข้อมูล"
                    onClick="select_count1_click" />
                <%--                            <a class="nav-link" data-toggle="tab" href="#tb_count1"  runat="server" onclick="select_count1_click">นับครั้งที่ 1</a>--%>
            </li>
            <li class="nav-item">
                <asp:Button ID="select_report_btn" runat="server" CssClass="btn btn-link btn-block"
                    Text="สรุปการตรวจนับอะไหล่" onClick="select_report_click" />
                <%--                            <a class="nav-link" data-toggle="tab" href="#tb_count1"  runat="server" onclick="select_count1_click">นับครั้งที่ 1</a>--%>
            </li>
        </ul>
    </div>

    <div class="tab-content">
        <asp:Panel ID="Panel2" runat="server">
            <div ID="insert_data" class="container tab-pane active"><br />
                <h1>Isuzu Sala Import ExcelFile (PassStock)</h1>
                <div class="row">
                    <div class="col-sm-12 col-xs-12">
                        <div class="card" style="margin : 50px;">
                            <div class="card-body">
                                <div class="form-group">
                                    <div class="date-stock">
                                        <label for="date_stock" class="control-label col-sm-12">สาขา : </label>
                                        <div class="col-sm-12">
                                            <div class="date-stock">
                                                <select ID="Select_Brach" class="form-control" runat="server">
                                                    <option value="0">-- เลือกสาขา --</option>
                                                    <option value="1">ดอนจั่น</option>
                                                    <option value="2">หน้าปริ้น</option>
                                                    <option value="3">สันทราย</option>
                                                    <option value="4">สันป่าตอง</option>
                                                    <option value="5">จอมทอง</option>
                                                </select>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <div class="date-stock">
                                        <label for="date_stock" class="control-label col-sm-12">วันนับสต็อค :
                                        </label>
                                        <div class="col-sm-12">
                                            <div class="date-stock">
                                                <asp:TextBox ID="DateStock" runat="server" TextMode="Date"
                                                    CssClass="form-control" Width="100%" onfocus="formInUse = true;"
                                                    onblur="formInUse = false;" Format="dd MMM yy"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="card">
                            <div class="card-body">
                                <div class="date-stock">
                                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                        <ContentTemplate>
                                            <%--                                        <i class="far fa-check-circle" id="icon_title_upload" runat="server"></i>--%>
                                            <asp:Label ID="title_upload" runat="server"
                                                Text="เลือกไฟล์ Excel ในการอัพโหลด"
                                                style="margin : 30px; font-size: 20px;"></asp:Label>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                    <div class="file-upload">
                                        <asp:FileUpload ID="FileUpload1" runat="server"
                                            CssClass="form-control-file border" Width="500px" />
                                    </div>
                                    <div style="margin : 30px;">
                                        <asp:LinkButton ID="Button1" runat="server" OnClick="Button1_Click"
                                            CssClass="btn btn-success btn-lg">
                                            <i class="fas fa-upload"></i> Upload
                                        </asp:LinkButton>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </asp:Panel>
        <asp:Panel ID="Panel1" runat="server">
            <div ID="tb_count1" class="container tab-pane"><br />
                <div class="row">
                    <div class="col-sm-12 col-xs-12">
                        <div class="card" style="margin : 30px;">
                            <div class="card-body">
                                <div class="form-group">
                                    <div class="date-stock">
                                        <label for="date_stock" class="control-label col-sm-12">สาขา : </label>
                                        <div class="col-sm-12">
                                            <div class="date-stock">
                                                <select ID="Select_Brach1" class="form-control" runat="server">
                                                    <option value="0">-- เลือกสาขา --</option>
                                                    <option value="1">ดอนจั่น</option>
                                                    <option value="2">หน้าปริ้น</option>
                                                    <option value="3">สันทราย</option>
                                                    <option value="4">สันป่าตอง</option>
                                                    <option value="5">จอมทอง</option>
                                                </select>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <div class="date-stock">
                                        <label for="date_stock" class="control-label col-sm-12">วันนับสต็อค :
                                        </label>
                                        <div class="col-sm-12">
                                            <div class="date-stock">
                                                <asp:TextBox ID="date_TextBox" runat="server" TextMode="Date"
                                                    CssClass="form-control" Width="100%" onfocus="formInUse = true;"
                                                    onblur="formInUse = false;" Format="dd MMM yy"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <div class="date-stock">
                                        <label for="date_stock" class="control-label col-sm-12">รอบการนับ :
                                        </label>
                                        <div class="col-sm-12">
                                            <div class="date-stock">
                                                <select ID="Select_Round" class="form-control" runat="server">
                                                    <option value="">-- เลือกรอบ --</option>
                                                    <option value="0">ก่อนนับ</option>
                                                    <option value="1">รอบที่ 1 </option>
                                                    <option value="2">รอบที่ 2 </option>
                                                    <option value="3">รอบที่ 3</option>
                                                    <option value="4">หลังนับ</option>
                                                </select>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="date-stock">
                                        <div style="margin : 30px;">
                                            <asp:LinkButton ID="LinkButton1" runat="server"
                                                OnClick="selectData1_Button_Click" CssClass="btn btn-success btn-lg">
                                                <i class="fas fa-list"></i> แสดงข้อมูล
                                            </asp:LinkButton>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                    <ContentTemplate>
                        <asp:Panel ID="Panel3" runat="server">
                            <div class="row">
                                <div class="col-sm-12 col-md-12" style="padding-top: 20px">
                                    <asp:GridView ID="dataStock" BorderWidth="0" GridLines="None" runat="server"
                                        AutoGenerateColumns="false" CssClass="table table-hover" AllowPaging="True"
                                        onpageindexchanging="dataStock_PageIndexChanging">
                                        <Columns>
                                            <asp:TemplateField HeaderText="รหัสอะไหล่"
                                                HeaderStyle-CssClass="txt_GridView">
                                                <ItemTemplate>
                                                    <asp:Label ID="Label1" runat="server" Text='<%# Bind("ID_Item") %>'
                                                        CssClass="txt_GridView"></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="ชื่ออะไหล่"
                                                HeaderStyle-CssClass="txt_GridView">
                                                <ItemTemplate>
                                                    <asp:Label ID="Label1" runat="server"
                                                        Text='<%# Bind("Name_Item") %>' CssClass="txt_GridView">
                                                    </asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <%--                                            <asp:TemplateField HeaderText="หมวดอะไหล่" HeaderStyle-CssClass="txt_GridView">
                                                <ItemTemplate>
                                                    <asp:Label ID="Label1" runat="server"
                                                        Text='<%# Bind("Group_Item") %>' CssClass="txt_GridView">
                                            </asp:Label>
                                            </ItemTemplate>
                                            </asp:TemplateField>--%>
                                            <asp:TemplateField HeaderText="ชั้นวางหลัก"
                                                HeaderStyle-CssClass="txt_GridView">
                                                <ItemTemplate>
                                                    <asp:Label ID="Label1" runat="server"
                                                        Text='<%# Bind("Self_Main") %>' CssClass="txt_GridView">
                                                    </asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <%-- <asp:TemplateField HeaderText="ราคาขายต่อหน่วย" HeaderStyle-CssClass="txt_GridView">
                                                <ItemTemplate>
                                                    <asp:Label ID="Label1" runat="server"
                                                        Text='<%# Bind("Sell_Price_Unit") %>' CssClass="txt_GridView">
                                            </asp:Label>
                                            </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="ราคาขายทั้งหมด"
                                                HeaderStyle-CssClass="txt_GridView">
                                                <ItemTemplate>
                                                    <asp:Label ID="Label1" runat="server"
                                                        Text='<%# Bind("Sell_Price_All") %>' CssClass="txt_GridView">
                                                    </asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>--%>
                                            <asp:TemplateField HeaderText="ต้นทุนขายต่อหน่วย"
                                                HeaderStyle-CssClass="txt_GridView">
                                                <ItemTemplate>
                                                    <asp:Label ID="Label1" runat="server"
                                                        Text='<%# Bind("Cost_Price_Unit") %>' CssClass="txt_GridView">
                                                    </asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="ต้นทุนขายทั้งหมด"
                                                HeaderStyle-CssClass="txt_GridView">
                                                <ItemTemplate>
                                                    <asp:Label ID="Label1" runat="server"
                                                        Text='<%# Bind("Cost_Price_All") %>' CssClass="txt_GridView">
                                                    </asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="สต๊อกรวม"
                                                HeaderStyle-CssClass="txt_GridView">
                                                <ItemTemplate>
                                                    <asp:Label ID="Label1" runat="server"
                                                        Text='<%# Bind("Total_Stock") %>' CssClass="txt_GridView">
                                                    </asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="ขายได้" HeaderStyle-CssClass="txt_GridView">
                                                <ItemTemplate>
                                                    <asp:Label ID="Label1" runat="server"
                                                        Text='<%# Bind("Amound_Sold") %>' CssClass="txt_GridView">
                                                    </asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <%--                                            <asp:TemplateField HeaderText="จำนวนการจอง" HeaderStyle-CssClass="txt_GridView">
                                                <ItemTemplate>
                                                    <asp:Label ID="Label1" runat="server"
                                                        Text='<%# Bind("Number_Parts_Booking") %>'
                                            CssClass="txt_GridView">
                                            </asp:Label>
                                            </ItemTemplate>
                                            </asp:TemplateField>--%>
                                            <asp:TemplateField HeaderText="สต๊อกเดือนที่ผ่านมา"
                                                HeaderStyle-CssClass="txt_GridView">
                                                <ItemTemplate>
                                                    <asp:Label ID="Label1" runat="server"
                                                        Text='<%# Bind("Inventory_Last_Month") %>'
                                                        CssClass="txt_GridView">
                                                    </asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="นับได้" HeaderStyle-CssClass="txt_GridView">
                                                <ItemTemplate>
                                                    <asp:Label ID="Label1" runat="server"
                                                        Text='<%# Bind("Get_Count") %>' CssClass="txt_GridView">
                                                    </asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="แตกต่าง" HeaderStyle-CssClass="txt_GridView">
                                                <ItemTemplate>
                                                    <asp:Label ID="Label1" runat="server"
                                                        Text='<%# Bind("Count_Value") %>' CssClass="txt_GridView">
                                                    </asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="ต้นทุนที่แตกต่าง"
                                                HeaderStyle-CssClass="txt_GridView">
                                                <ItemTemplate>
                                                    <asp:Label ID="Label1" runat="server"
                                                        Text='<%# Bind("Cost_Count_Value") %>' CssClass="txt_GridView">
                                                    </asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <%--<asp:TemplateField HeaderText="นับรอบที่ 2" HeaderStyle-CssClass="txt_GridView" ControlStyle-BackColor="#eee">
                                                <ItemTemplate>
                                                    <asp:Label ID="Label1" runat="server"
                                                        Text='<%# Bind("Count2") %>'
                                            CssClass="txt_GridView">
                                            </asp:Label>
                                            </ItemTemplate>
                                            </asp:TemplateField>--%>
                                            <%--                                        <asp:BoundField DataField="Shelf_Main" HeaderText="ชั้นวางหลัก" />--%>

                                        </Columns>
                                    </asp:GridView>
                                </div>
                            </div>

                        </asp:Panel>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
        </asp:Panel>
        <asp:Panel ID="Panel_Report" runat="server">
            <div ID="tb_report" class="container tab-pane"><br />
                <div class="row">
                    <div class="col-sm-12 col-xs-12">
                        <div class="card" style="margin : 30px;">
                            <div class="card-body">
                                <div class="form-group">
                                    <div class="date-stock">
                                        <label for="date_stock" class="control-label col-sm-12">สาขา : </label>
                                        <div class="col-sm-12">
                                            <div class="date-stock">
                                                <select ID="Select1" class="form-control" runat="server">
                                                    <option value="0">-- เลือกสาขา --</option>
                                                    <option value="1">ดอนจั่น</option>
                                                    <option value="2">หน้าปริ้น</option>
                                                    <option value="3">สันทราย</option>
                                                    <option value="4">สันป่าตอง</option>
                                                    <option value="5">จอมทอง</option>
                                                </select>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <div class="date-stock">
                                        <label for="date_stock" class="control-label col-sm-12">วันนับสต็อค :
                                        </label>
                                        <div class="col-sm-12">
                                            <div class="date-stock">
                                                <asp:TextBox ID="TextBox1" runat="server" TextMode="Date"
                                                    CssClass="form-control" Width="100%" onfocus="formInUse = true;"
                                                    onblur="formInUse = false;" Format="dd MMM yy"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <div class="date-stock">
                                        <label for="date_stock" class="control-label col-sm-12">รอบการนับ :
                                        </label>
                                        <div class="col-sm-12">
                                            <div class="date-stock">
                                                <select ID="Select2" class="form-control" runat="server">
                                                    <option value="">-- เลือกรอบ --</option>
                                                    <option value="1">รอบที่ 1 </option>
                                                    <option value="2">รอบที่ 2 </option>
                                                    <option value="3">รอบที่ 3</option>
                                                </select>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="date-stock">
                                        <div style="margin : 30px;">
                                            <asp:LinkButton ID="LinkButton2" runat="server"
                                                OnClick="selectReport_Button_Click" CssClass="btn btn-success btn-lg">
                                                <i class="fas fa-list"></i> แสดงข้อมูล
                                            </asp:LinkButton>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                    <ContentTemplate>
                        <asp:Panel ID="Panel_Report_View" runat="server">
                            <div class="row">
                                <div class="col-sm-12 col-md-12" style="padding-top: 20px">
                                    <table class="table table-hover" border="0">
                                        <tr>
                                            <center>
                                                <th colspan="8">สรุปการตรวจนับอะไหล่</th>
                                            </center>
                                        </tr>
                                        <tr>
                                            <td colspan="1">วันที่ตรวจนับ</td>
                                            <td colspan="2">นับครั้งต่อไป (25611223_1130)</td>
                                            <td colspan="2">ผลการตรวจนับ</td>
                                            <td colspan="3"></td>
                                        </tr>
                                        <tr>
                                            <td colspan="1">บริษัท-สาขา</td>
                                            <td colspan="2">นับครั้งต่อไป (25611223_1130)</td>
                                            <td colspan="2">สาขา</td>
                                            <td colspan="3"></td>
                                        </tr>
                                        <tr>
                                            <td colspan="1">ผู้ตรวจนับ</td>
                                            <td colspan="2"></td>
                                            <td colspan="2">ผู้ยืนยันการตรวจนับ</td>
                                            <td colspan="3"></td>
                                        </tr>
                                        <tr>
                                            <td colspan="8"></td>
                                        </tr>
                                        <tr>
                                            <td>ผลการตรวจนับ</td>
                                        </tr>
                                        <tr>
                                            <td> อะไหล่ตรีเพชรฯ (1)</td>
                                            <td>
                                                <asp:Label ID="countItem" runat="server" Text="00000"></asp:Label>
                                            </td>
                                            <td>รายการ</td>
                                            <td>(+)</td>
                                            <td>00</td>
                                            <td>รายการ</td>
                                            <td>0.00</td>
                                            <td>%</td>
                                        </tr>
                                        <tr>
                                            <td> จำนวน</td>
                                            <td>000000</td>
                                            <td>ชิ้น</td>
                                            <td>จำนวน</td>
                                            <td>00</td>
                                            <td>ชิ้น</td>
                                            <td>0.00</td>
                                            <td>%</td>
                                        </tr>
                                        <tr>
                                            <td> มูลค่า</td>
                                            <td>000000</td>
                                            <td>บาท</td>
                                            <td>มูลค่า</td>
                                            <td>00</td>
                                            <td>บาท</td>
                                            <td>0.00</td>
                                            <td>%</td>
                                        </tr>
                                        <tr>
                                            <td colspan="3"></td>
                                            <td>(-)</td>
                                            <td>100</td>
                                            <td>รายการ</td>
                                            <td>0.00</td>
                                            <td>%</td>
                                        </tr>
                                        <tr>
                                            <td colspan="3"></td>
                                            <td>จำนวน</td>
                                            <td>00</td>
                                            <td>ชิ้น</td>
                                            <td>0.00</td>
                                            <td>%</td>
                                        </tr>
                                        <tr>
                                            <td colspan="3"></td>
                                            <td>มูลค่า</td>
                                            <td>00</td>
                                            <td>บาท</td>
                                            <td>0.00</td>
                                            <td>%</td>
                                        </tr>
                                        <tr>
                                            <td colspan="3"></td>
                                            <td>TOTAL BAL.</td>
                                            <td>00</td>
                                            <td>บาท</td>
                                            <td>0.00</td>
                                            <td>%</td>
                                        </tr>
                                        <tr>
                                            <td colspan="3"></td>
                                            <td>TOTAL DIF.</td>
                                            <td>00</td>
                                            <td>บาท</td>
                                            <td>0.00</td>
                                            <td>%</td>
                                        </tr>
                                        <tr>
                                            <td> อะไหล่ตรีเพชรฯ (1)</td>
                                            <td>000000</td>
                                            <td>รายการ</td>
                                            <td>(+)</td>
                                            <td>00</td>
                                            <td>รายการ</td>
                                            <td>0.00</td>
                                            <td>%</td>
                                        </tr>
                                        <tr>
                                            <td> จำนวน</td>
                                            <td>000000</td>
                                            <td>ชิ้น</td>
                                            <td>จำนวน</td>
                                            <td>00</td>
                                            <td>ชิ้น</td>
                                            <td>0.00</td>
                                            <td>%</td>
                                        </tr>
                                        <tr>
                                            <td> มูลค่า</td>
                                            <td>000000</td>
                                            <td>บาท</td>
                                            <td>มูลค่า</td>
                                            <td>00</td>
                                            <td>บาท</td>
                                            <td>0.00</td>
                                            <td>%</td>
                                        </tr>
                                        <tr>
                                            <td colspan="3"></td>
                                            <td>(-)</td>
                                            <td>100</td>
                                            <td>รายการ</td>
                                            <td>0.00</td>
                                            <td>%</td>
                                        </tr>
                                        <tr>
                                            <td colspan="3"></td>
                                            <td>จำนวน</td>
                                            <td>00</td>
                                            <td>ชิ้น</td>
                                            <td>0.00</td>
                                            <td>%</td>
                                        </tr>
                                        <tr>
                                            <td colspan="3"></td>
                                            <td>มูลค่า</td>
                                            <td>00</td>
                                            <td>บาท</td>
                                            <td>0.00</td>
                                            <td>%</td>
                                        </tr>
                                        <tr>
                                            <td colspan="3"></td>
                                            <td>TOTAL BAL.</td>
                                            <td>00</td>
                                            <td>บาท</td>
                                            <td>0.00</td>
                                            <td>%</td>
                                        </tr>
                                        <tr>
                                            <td colspan="3"></td>
                                            <td>TOTAL DIF.</td>
                                            <td>00</td>
                                            <td>บาท</td>
                                            <td>0.00</td>
                                            <td>%</td>
                                        </tr>
                                        <tr>
                                            <td> อะไหล่ตรีเพชรฯ (1)</td>
                                            <td>000000</td>
                                            <td>รายการ</td>
                                            <td>(+)</td>
                                            <td>00</td>
                                            <td>รายการ</td>
                                            <td>0.00</td>
                                            <td>%</td>
                                        </tr>
                                        <tr>
                                            <td> จำนวน</td>
                                            <td>000000</td>
                                            <td>ชิ้น</td>
                                            <td>จำนวน</td>
                                            <td>00</td>
                                            <td>ชิ้น</td>
                                            <td>0.00</td>
                                            <td>%</td>
                                        </tr>
                                        <tr>
                                            <td> มูลค่า</td>
                                            <td>000000</td>
                                            <td>บาท</td>
                                            <td>มูลค่า</td>
                                            <td>00</td>
                                            <td>บาท</td>
                                            <td>0.00</td>
                                            <td>%</td>
                                        </tr>
                                        <tr>
                                            <td colspan="3"></td>
                                            <td>(-)</td>
                                            <td>100</td>
                                            <td>รายการ</td>
                                            <td>0.00</td>
                                            <td>%</td>
                                        </tr>
                                        <tr>
                                            <td colspan="3"></td>
                                            <td>จำนวน</td>
                                            <td>00</td>
                                            <td>ชิ้น</td>
                                            <td>0.00</td>
                                            <td>%</td>
                                        </tr>
                                        <tr>
                                            <td colspan="3"></td>
                                            <td>มูลค่า</td>
                                            <td>00</td>
                                            <td>บาท</td>
                                            <td>0.00</td>
                                            <td>%</td>
                                        </tr>
                                        <tr>
                                            <td colspan="3"></td>
                                            <td>TOTAL BAL.</td>
                                            <td>00</td>
                                            <td>บาท</td>
                                            <td>0.00</td>
                                            <td>%</td>
                                        </tr>
                                        <tr>
                                            <td colspan="3"></td>
                                            <td>TOTAL DIF.</td>
                                            <td>00</td>
                                            <td>บาท</td>
                                            <td>0.00</td>
                                            <td>%</td>
                                        </tr>
                                    </table>
                                </div>
                            </div>
                        </asp:Panel>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
        </asp:Panel>
</asp:Content>