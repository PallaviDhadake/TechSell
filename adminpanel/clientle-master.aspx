<%@ Page Title="Clients | TechSell - Tushar Enterprises" Language="C#" MasterPageFile="~/adminpanel/MasterAdmin.master" AutoEventWireup="true" CodeFile="clientle-master.aspx.cs" Inherits="adminpanel_testimonials_master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    
        <script type="text/javascript">
            $(function () {
            var prm = Sys.WebForms.PageRequestManager.getInstance();
            if (prm != null) {
                prm.add_endRequest(function (sender, e) {
                    if (sender._postBackSettings.panelsToUpdate != null) {
                        createDataTable();
                    }
                });
            };

            createDataTable();
            function createDataTable() {
                $('#<%= gvClients.ClientID %>').prepend($("<thead></thead>").append($('#<%= gvClients.ClientID %>').find("tr:first"))).DataTable({

                    columnDefs: [
                        { orderable: false, targets: [0, 1, 2, 3, 4] }
                    ],
                    order: [[0, 'desc']]
                });

            }
        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <h2 class="pgTitle">Client Master</h2>
    <span class="space10"></span>
	<div id="editinfo" runat="server">
        <div class="card card-primary">
            <div class="card-header">
                <h3 class="card-title"><%=pgTitle %></h3>
            </div>
           
            <div class="card-body">
                <div class="colorLightBlue">
                  
                    <asp:Label ID="lblId" runat="server" Text="[New]"></asp:Label>
                </div>
                <span class="space15"></span>
              
                <div class="form-row">
                    <div class="form-group col-md-6">
                        <label>Client Name: *</label>
                        <asp:TextBox ID="txtPerNm" runat="server" CssClass="form-control" Width="100%" MaxLength="80"></asp:TextBox>
                    </div>
                    
                    <div class="form-group col-md-6">
                        <label>City: *</label>
                        <asp:TextBox ID="txtPlce" runat="server" CssClass="form-control" Width="100%" 
                            MaxLength="30" ></asp:TextBox>
                    </div>
                </div>
            </div>
        </div>
        <!-- Button controls starts -->
        <span class="space10"></span>
        <span class="space10"></span>
        <asp:Button ID="btnSave" runat="server" CssClass="btn btn-primary" Text="Save" OnClick="btnSave_Click" />
      
        <asp:Button ID="btnCancel" runat="server" CssClass="btn btn-outline-dark" Text="Cancel" OnClick="btnCancel_Click" />
        <div class="float_clear"></div>
        <!-- Button controls ends -->
       
    </div>
     <div id="viewinfo" runat="server">
        <%--<a href="testimonials-master.aspx?action=new" runat="server" class="btn btn-primary btn-md">Add New</a>--%>
		<%--<a href="contactdata.aspx?action=new" runat="server" class="btn btn-primary btn-md">Add New</a>--%>
        <span class="space20"></span>
        <div class="formPanel table-responsive-md">
            <asp:GridView ID="gvClients" runat="server" CssClass="table table-striped table-bordered table-hover" GridLines="None" 
				AutoGenerateColumns="false" OnRowDataBound="gvClients_RowDataBound" OnRowCommand="gvClients_RowCommand">
				 <HeaderStyle CssClass="thead-dark" />
				<RowStyle CssClass="" />
				<AlternatingRowStyle CssClass="alt" />
				<Columns>
					 <asp:BoundField DataField="clId">
						<HeaderStyle CssClass="HideCol" />
						<ItemStyle  CssClass="HideCol"/>
					</asp:BoundField>
					
					 <asp:BoundField DataField="clName" HeaderText="Client Name">
						<ItemStyle Width="30%" />
					</asp:BoundField>

                     <asp:BoundField DataField="clCity" HeaderText="City">
						<ItemStyle Width="15%" />
					</asp:BoundField>

                    	<asp:TemplateField>
						<ItemStyle Width="5%" />
						<ItemTemplate>
							<asp:Literal ID="litAnch" runat="server"></asp:Literal>
						</ItemTemplate>
					</asp:TemplateField>  

                       <asp:TemplateField>
						<ItemStyle Width="5%" />
						<ItemTemplate>
							<asp:Button ID="btnDelete" runat="server" CssClass="gDel" CommandName="Update"/>
						</ItemTemplate>
					</asp:TemplateField> 

				</Columns>
				<EmptyDataTemplate>
					<span class="warning">Its Empty Here... :(</span>
				</EmptyDataTemplate>
				<PagerStyle CssClass="" />
			</asp:GridView>
        </div>
    </div>
</asp:Content>

