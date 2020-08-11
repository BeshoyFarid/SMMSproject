<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="profilepage.aspx.cs" Inherits="SMMSproject.profilepage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
 <div class="container">
     <div class="row">
         <div class="col-md-7 mx-auto">
             <div class="spec ">
                 <center>
                     <h1>Orders</h1>
                 </center>
			</div>
         </div>
     </div>
 </div>
   <div class="container">
       <div class="row">
           <div class="col-md-7">
               
               <asp:DataList ID="DataList1" runat="server" RepeatColumns="5" CellPadding="4" ForeColor="#333333">
                   
                        <AlternatingItemStyle BackColor="White" />
                        <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                        <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                        <ItemStyle BackColor="#FFFBD6" ForeColor="#333333" />
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
                          
                        </ItemTemplate>
                        <SelectedItemStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
            </asp:DataList>
           </div>
       </div>
   </div>
</asp:Content>
