<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="product.aspx.cs" Inherits="SMMSproject.product" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
   
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
 <div class="container">
     <div class="row">
         <div class="col-md-7 mx-auto">
             <div class="spec ">
                 <center>
                     <h1>Products</h1>
                 </center>
			</div>
         </div>
     </div>
 </div>
   <div class="container">
       <div class="row">
           <div class="col-md-7">
               
               <asp:DataList ID="DataList1" runat="server" RepeatColumns="5" CellPadding="10"  CellSpacing="10" ForeColor="#333333">
                   
                        <AlternatingItemStyle BackColor="White" ForeColor="#284775" />
                        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                        <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                        <ItemStyle BackColor="#F7F6F3" ForeColor="#333333" />
                   <SeparatorTemplate>
                       <br />
                   </SeparatorTemplate>
                        <ItemTemplate>       
                            <center>
                                <asp:Image ID="Image1" runat="server" ImageURL='<%# Eval("pro_image_link") %>' Height="120" Width="120"/>
                                <h6><%# Eval("proName") %></h6>
                                <h6><%# Eval("discrption") %></h6>
                                <h6>price: <%# Eval("price") %> LE</h6>
                            </center>
                            <center> 
                                <asp:LinkButton ID="Button1" runat="server" Text='<%# Eval("id") %>' OnClick="Button1_Click">Add To Cart</asp:LinkButton>
                            </center>
                        </ItemTemplate>
                        <SelectedItemStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
            </asp:DataList>
           </div>
       </div>
   </div>
   
</asp:Content>

