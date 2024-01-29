<%@ Page Title="" Language="C#" MasterPageFile="~/adminpanel/MasterAdmin.master" AutoEventWireup="true" CodeFile="products-data.aspx.cs" Inherits="adminpanel_products_data" %>
<%@ MasterType VirtualPath="~/adminpanel/MasterAdmin.master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <script>
		$(document).ready(function () {
            $('[id$=gvProducts]').DataTable({
                columnDefs: [
                    { orderable: false, targets: [0, 1, 2, 3, 4, 5]}
				],
				order: [[0, 'desc']]
			});
		});
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <h2 class="pgTitle">Products Msater</h2>
    <span class="space10"></span>
	<div id="editinfo" runat="server">
        <div class="card card-primary">
            <div class="card-header">
                <h3 class="card-title"><%=pgTitle %></h3>
            </div>
            <%-- Card Body --%>
            <div class="card-body">
                <div class="colorLightBlue">
                    <%--<span>Id</span>--%>
                    <asp:Label ID="lblId" runat="server" Text="[New]"></asp:Label>
                </div>
                <span class="space15"></span>
                <%-- From Row Start --%>
                <div class="form-row">
                    
                    <div class="form-group col-md-6">
                        <label>Select Category:*</label>
                        <asp:DropDownList ID="ddrProdCat" CssClass="form-control" runat="server">
                            <asp:ListItem Value="0">-- Select Product Category --</asp:ListItem>
                        </asp:DropDownList>
                    </div>

                     <div class="form-group col-md-6">
                        <label>Select Brand:*</label>
                        <asp:DropDownList ID="ddrbrand" CssClass="form-control" runat="server">
                            <asp:ListItem Value="0">-- Select Brand  --</asp:ListItem>
                        </asp:DropDownList>
                    </div>

                    <div class="form-group col-md-6">
                        <label>Product Name:*</label>
                        <asp:TextBox ID="txtProdName" runat="server" CssClass="form-control" MaxLength="80" Width="100%"></asp:TextBox>
                    </div>

                    <div class="form-group col-md-6">
                        <label>Product Description:*</label>
                        <asp:TextBox ID="txtProdDesc" runat="server" CssClass="form-control" MaxLength="300" Width="100%" TextMode="MultiLine" Height="200"></asp:TextBox>
                    </div>

                    <div class="form-group col-md-6">
                        <label>Product Features:*</label>
                        <asp:TextBox ID="txtProdFeature" runat="server" CssClass="form-control" MaxLength="300" Width="100%" TextMode="MultiLine" Height="200"></asp:TextBox>
                    </div>

                    <div class="form-group col-md-6">
                        <label>Product Specification:</label> <span class="text-info"> (Please add each specification in new line) </span>
                        <asp:TextBox ID="txtProdSpec" runat="server" CssClass="form-control" MaxLength="300" Width="100%" TextMode="MultiLine" Height="200"></asp:TextBox>
                    </div>

                   <div class="form-group col-md-6">
                        <div id="linkvid" runat="server">
                            <label>Product Video Link:</label>
                            <asp:TextBox ID="txtVidLink" runat="server" CssClass="form-control" Width="100%"
                                MaxLength="200"></asp:TextBox>
                        </div>
                        <span class="space10"></span>
                        <%=videoPreview %>
                    </div>

                  
                     <div class="form-group col-md-6">
                        <label>Product Image:*</label>
                         <asp:FileUpload ID="fuImage" runat="server" CssClass="form-control-file" />
						<span class="space10"></span>
						<%= prodPhoto %><span class="space5"></span>
						
                    </div>

                    <div class="form-group col-md-6">
                        <label>Product Brochure:</label>
                         <asp:FileUpload ID="fuBrocure" runat="server" CssClass="form-control-file" />
						<span class="space10"></span>
						<%= brochure %><span class="space5"></span>
						
                    </div>
                   

                </div>
            </div>
        </div>
        <!-- Button controls starts -->
        <span class="space10"></span>
        <span class="space10"></span>
        <asp:Button ID="btnSave" runat="server" CssClass="btn btn-primary" Text="Save" OnClick="btnSave_Click" />
        <asp:Button ID="btnDelete" runat="server" CssClass="btn btn-outline-info" Text="Delete" OnClientClick="return confirm('Are you sure to delete?');" OnClick="btnDelete_Click" />
        <asp:Button ID="btnCancel" runat="server" CssClass="btn btn-outline-dark" Text="Cancel" OnClick="btnCancel_Click" />
        <div class="float_clear"></div>
        <!-- Button controls ends -->
        <%--</ContentTemplate>
		</asp:UpdatePanel>--%>
    </div>
     <div id="viewinfo" runat="server">
        <a href="products-data.aspx?action=new" runat="server" class="btn btn-primary btn-md">Add New</a>
		<%--<a href="contactdata.aspx?action=new" runat="server" class="btn btn-primary btn-md">Add New</a>--%>
        <span class="space20"></span>
        <div class="formPanel table-responsive-md">
            <asp:GridView ID="gvProducts" runat="server" CssClass="table table-striped table-bordered table-hover" GridLines="None" 
				AutoGenerateColumns="false" OnRowDataBound="gvProducts_RowDataBound" >
				 <HeaderStyle CssClass="thead-dark" />
				<RowStyle CssClass="" />
				<AlternatingRowStyle CssClass="alt" />
				<Columns>
					 <asp:BoundField DataField="proId">
						<HeaderStyle CssClass="HideCol" />
						<ItemStyle  CssClass="HideCol"/>
					</asp:BoundField>
					
					 <asp:BoundField DataField="proName" HeaderText="Product Name">
						<ItemStyle Width="10%" />
					</asp:BoundField>

					 <asp:BoundField DataField="catName" HeaderText="Product Category">
						<ItemStyle Width="10%" />
					</asp:BoundField>

                     <asp:BoundField DataField="brandName" HeaderText="Brand">
						<ItemStyle Width="5%" />
					</asp:BoundField>

                    <asp:TemplateField HeaderText="Product Video">
                        <ItemStyle Width="2%" />
                        <ItemTemplate>
                            <asp:Literal ID="litVideoLink" runat="server"></asp:Literal>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField>
						<ItemStyle Width="3%" />
						<ItemTemplate>
							<asp:Literal ID="litAnch" runat="server"></asp:Literal>
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

