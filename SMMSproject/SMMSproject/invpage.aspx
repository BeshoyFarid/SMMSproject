<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="invpage.aspx.cs" Inherits="SMMSproject.invpage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        function readURL(input) {
            if (input.files && input.files[0]) {
                var reader = new FileReader();
                reader.onload = function (e) {
                    $('#imageview').attr('src', e.target.result);
                };
                reader.readAsDataURL(input.files[0]);
            }
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
      <div class="container-fluid">
      <div class="row">
         <div class="col-md-5">
            <div class="card">
               <div class="card-body">
                  <div class="row">
                     <div class="col">
                        <center>
                           <h4>Item Details</h4>
                        </center>
                     </div>
                  </div>
                  <div class="row">
                     <div class="col">
                        <center>
                           <img id="imageview" hight="150px" width="150px" src="Image/18.jpg" />
                        </center>
                     </div>
                  </div>
                  <div class="row">
                     <div class="col">
                        <hr>
                     </div>
                  </div>
                  <div class="row">
                     <div class="col">
                        <asp:FileUpload onchange="readURL(this);" class="form-control" ID="FileUpload1" runat="server" />
                     </div>
                  </div>

                  <div class="row">
                     <div class="col-md-4">
                        <label>Item ID</label>
                        <div class="form-group">
                           <div class="input-group">
                              <asp:TextBox CssClass="form-control" ID="TextBox1" runat="server" placeholder="Item ID"></asp:TextBox>
                              <asp:LinkButton class="btn btn-primary" ID="LinkButton4" runat="server" OnClick="LinkButton4_Click" Width="16px"><i class="fas fa-check-circle"></i></asp:LinkButton>
                           </div>
                        </div>
                     </div>
                     <div class="col-md-8">
                        <label>Item Name</label>
                        <div class="form-group">
                           <asp:TextBox CssClass="form-control" ID="TextBox2" runat="server" placeholder="Item Name"></asp:TextBox>
                        </div>
                     </div>
                  </div>
                  <div class="row">
                     <div class="col-md-4">
                        <label>Actual Stock</label>
                        <div class="form-group">
                           <asp:TextBox CssClass="form-control" ID="TextBox4" runat="server" placeholder="Stock" TextMode="Number"></asp:TextBox>
                        </div>
                        <label>Supplier Name</label>
                        <div class="form-group">
                           <asp:DropDownList class="form-control" ID="DropDownList2" runat="server">
                              <asp:ListItem Text="Supplier 1" Value="Supplier 1" />
                              <asp:ListItem Text="Supplier 2" Value="Supplier 2" />
                           </asp:DropDownList>
                        </div>
                     </div>
                     <div class="col-md-4">
                     
                        <label>Expire Date</label>
                        <div class="form-group">
                           <asp:TextBox CssClass="form-control" ID="TextBox3" runat="server" placeholder="Date" TextMode="Date"></asp:TextBox>
                        </div>
                       
                     </div>
                     <div class="col-md-4">
                       <label>item Cost(per unit)</label>
                        <div class="form-group">
                           <asp:TextBox CssClass="form-control" ID="TextBox10" runat="server" placeholder="Item Cost(per unit)" TextMode="Number"></asp:TextBox>
                        </div>
                     </div>
                  </div>
                 
                 
                  <div class="row">
                     <div class="col-12">
                        <label>Item Description</label>
                        <div class="form-group">
                           <asp:TextBox CssClass="form-control" ID="TextBox6" runat="server" placeholder="Item Description" TextMode="MultiLine" Rows="2"></asp:TextBox>
                        </div>
                     </div>
                  </div>
                  <div class="row">
                     <div class="col-4">
                        <asp:Button ID="Button1" class="btn btn-lg btn-block btn-success" runat="server" Text="Add" OnClick="Button1_Click" />
                     </div>
                     <div class="col-4">
                        <asp:Button ID="Button3" class="btn btn-lg btn-block btn-warning" runat="server" Text="Update" OnClick="Button3_Click" />
                     </div>
                     <div class="col-4">
                        <asp:Button ID="Button2" class="btn btn-lg btn-block btn-danger" runat="server" Text="Delete" OnClick="Button2_Click" />
                     </div>
                  </div>
               </div>
            </div>
            <a href="homepage.aspx"><< Back to Home</a><br>
            <br>
         </div>
         <div class="col-md-7">
            <div class="card">
               <div class="card-body">
                  <div class="row">
                     <div class="col">
                        <center>
                           <h4>Item Inventory List</h4>
                        </center>
                     </div>
                  </div>
                  <div class="row">
                     <div class="col">
                        <hr>
                     </div>
                  </div>
                  <div class="row">
                     <div class="col">
                        <asp:GridView class="table table-striped table-bordered" ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="id" DataSourceID="SqlDataSource1">
                            <Columns>
                                <asp:BoundField DataField="id" HeaderText="id" ReadOnly="True" SortExpression="id" />
                                <asp:BoundField DataField="proName" HeaderText="proName" SortExpression="proName" />
                                <asp:BoundField DataField="price" HeaderText="price" SortExpression="price" />
                                <asp:BoundField DataField="quantity" HeaderText="quantity" SortExpression="quantity" />
                                <asp:BoundField DataField="discrption" HeaderText="discrption" SortExpression="discrption" />
                                <asp:BoundField DataField="exDate" HeaderText="exDate" SortExpression="exDate" />
                                <asp:BoundField DataField="pro_image_link" HeaderText="pro_image_link" SortExpression="pro_image_link" />
                                <asp:BoundField DataField="supplierName" HeaderText="supplierName" SortExpression="supplierName" />
                            </Columns>
                         </asp:GridView>
                     </div>
                  </div>
               </div>
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:smdbConnectionString %>" SelectCommand="SELECT * FROM [product]"></asp:SqlDataSource>
            </div>
         </div>
      </div>
   </div>
</asp:Content>
