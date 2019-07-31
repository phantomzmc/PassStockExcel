<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="PassStock2._Default" %>
    
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    
    <div class="jumbotron">
        <h1>Pass Stock</h1>
        <p class="lead">Upload Excel File To Database using Process</p>
        <ul class="nav nav-tabs" role="tablist">
            <li class="nav-item">
              <a class="nav-link active" data-toggle="tab" href="#insert_data">Insert Data</a>
            </li>
            <li class="nav-item">
              <a class="nav-link" data-toggle="tab" href="#select_data">Select Data</a>
            </li>
            <li class="nav-item">
              <a class="nav-link" data-toggle="tab" href="#menu2">Menu 2</a>
            </li>
        </ul>
    </div>
    <div class="tab-content">
        <div id="insert_data" class="container tab-pane active"><br>
            <div class="row">
             <div class="col-sm-12 col-xs-12">
                <div class="card" style="margin : 50px;">
                  <div class="card-body"> 
                    <div class="form-group">
                        <div class="date-stock">
                            <label for="date_stock" class="control-label col-sm-12">สาขา :  </label>
                            <div class="col-sm-12">
                                <div class="date-stock">
                                    <select ID="Select_Brach" class="form-control" runat="server">
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
                            <label for="date_stock" class="control-label col-sm-12">วันนับสต็อค :  </label>
                            <div class="col-sm-12">
                                <div class="date-stock">
<%--                                    <input type="date" class="form-control" runat="server" ID="DateStock" data-date-format="dd-mm-yyyy">--%>
<%--                                    <form id="form2" runat="server">
                                        <div>
                                            <asp:Calendar ID="Calendar1" runat="server" OnSelectionChanged="Calendar1_SelectionChanged"></asp:Calendar>
                                            <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                                        </div>
                                    </form>--%>
                                </div>
                            </div>
                        </div>
                    </div>
<%--                    <div class="form-group">
                        <div class="count-round">
                            <label for="count_round" class="control-label col-sm-12">นับรอบที่ :  </label>
                            <div class="col-sm-12">
                                <div class="count-round">
                                    <input type="number" class="form-control" runat="server" ID="CountRound">
                                </div>
                            </div>
                        </div>
                    </div>--%>
                  </div>
              </div>
            </div>
        </div>
            <div class="row">
                <div class="col-md-12 col-sm-12 col-xs-12">
                   <div class="card">
                      <div class="card-body"> 
                           <div class="upload">
                               <asp:Label ID="title_upload" runat="server" Text="เลือกไฟล์ Excel ในการอัพโหลด"  style="margin : 30px; font-size: 20px;"></asp:Label>
                               <div class="file-upload">
                                   <asp:FileUpload ID="FileUpload1" runat="server" CssClass="form-control-file border" Width="500px"/>
                               </div>
                               <div style="margin : 30px;">
                                   <asp:Button ID="Button2" runat="server" Text="Upload" OnClick="Button1_Click" CssClass="btn btn-success btn-lg"/>
                               </div>
                                <asp:UpdatePanel ID="UpdatePanel" runat="server" >
                                    <ContentTemplate>
                                       <asp:Panel ID="Panel1" runat="server">
                                            <div class="progress">
                                                <div class="progress-bar progress-bar-striped progress-bar-animated" style="width:90%">Uploading ........</div>
                                            </div>
                                       </asp:Panel>
                                       <asp:Panel ID="Panel2" runat="server">
                                            <div style="margin : 30px;">
                                                    <div class="row">
                                                        <div class="col-sm-12 col-md-12" style="padding-top: 20px">
                                                            <asp:GridView ID="dataStock" BorderWidth="0" GridLines="None" runat="server"
                                                                AutoGenerateColumns="false" CssClass="table table-hover" AllowPaging="True" onpageindexchanging="dataStock_PageIndexChanging">
                                                                <Columns>
                                                                    <asp:BoundField DataField="ID_Item" HeaderText="รหัสอะไหล่" />
                                                                    <asp:BoundField DataField="Name_Item" HeaderText="ชื่ออะไหล่" />
                                            <%--                        <asp:TemplateField HeaderText="รูป">
                                                                        <ItemTemplate>
                                                                            <asp:Image Height="80px" ImageUrl='<%# Eval("coverImg") %>' runat="server" />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>--%>
                                                                    <asp:BoundField DataField="Group_Item" HeaderText="หมวดอะไหล่" />
                                                                    <asp:BoundField DataField="Sell_Price_Unit" HeaderText="ราคาขายต่อหน่วย" />
                                                                    <asp:BoundField DataField="Sell_Price_All" HeaderText="ราคาขายทั้งหมด" />
                                                                    <asp:BoundField DataField="Cost_Price_Unit" HeaderText="ต้นทุนขายต่อหน่วย" />
                                                                    <asp:BoundField DataField="Cost_Price_All" HeaderText="ต้นทุนขายทั้งหมด" />
                                                                    <asp:BoundField DataField="Shelf_Main" HeaderText="ชั้นวางหลัก" />
                                            <%--                        <asp:BoundField DataField="Shelf_Try" HeaderText="ชั้นวางลอง" />--%>
                                            <%--                        <asp:BoundField DataField="Count_Round" HeaderText="รอบที่" />--%>
                                                                    <asp:BoundField DataField="Total_Stock" HeaderText="จำนวนสต๊อกรวม" />
                                                                    <asp:BoundField DataField="Amound_Sold" HeaderText="จำนวนที่ขายได้" />
                                                                    <asp:BoundField DataField="Number_Parts_Booking" HeaderText="จำนวนการจองสำหรับออกใบจัดอะไหล่" />
                                                                    <asp:BoundField DataField="Inventory_Last_Month" HeaderText="สต๊อกคงคลังณเดือนที่ผ่านมา" />
                                                                </Columns>
                                                            </asp:GridView>
                                                        </div>
                                                    </div>
                                            </div>
                                       </asp:Panel>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                        </div>
                    </div>
                </div>
            </div>

        </div>
        <div id="select_data" class="container tab-pane"><br>
            <div class="row">
             <div class="col-sm-12 col-xs-12">
                <div class="card" style="margin : 50px;">
                  <div class="card-body"> 
                    <div class="form-group">
                        <div class="date-stock">
                            <label for="date_stock" class="control-label col-sm-12">สาขา :  </label>
                            <div class="col-sm-12">
                                <div class="date-stock">
                                    <select ID="Select1" class="form-control" runat="server">
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
                            <label for="date_stock" class="control-label col-sm-12">วันนับสต็อค :  </label>
                            <div class="col-sm-12">
                                <div class="date-stock">
<%--                                    <input type="date" class="form-control" runat="server" ID="Date1" data-date-format="dd-mm-yyyy">--%>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="count-round">
                            <label for="count_round" class="control-label col-sm-12">นับรอบที่ :  </label>
                            <div class="col-sm-12">
                                <div class="count-round">
<%--                                    <input type="number" class="form-control" runat="server" ID="Number1">--%>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="upload">
                        <div style="margin : 30px;">
                           <asp:LinkButton ID="LinkButton1" runat="server" OnClick="Button1_Click" CssClass="btn btn-success btn-lg"><i class="glyphicon glyphicon-upload"></i>&nbsp;Upload</asp:LinkButton>   
                        </div>
                    </div>
                  </div>
              </div>
            </div>
            </div>

        </div>
    </div>

</asp:Content>
