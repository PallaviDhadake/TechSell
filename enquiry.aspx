<%@ Page Title="Enquiry" Language="C#" MasterPageFile="~/MasterParent.master" AutoEventWireup="true" CodeFile="enquiry.aspx.cs" Inherits="enquiry" %>
<%@ MasterType VirtualPath="~/MasterParent.master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="pgHeader1" id="pagehead">
        <div class="headerOverlay d-flex align-items-center justify-content-center">
            <div class="container">
                <div class="p-4">
                    <h1 class="text-white text-center text-uppercase">Enquiry</h1>
                    <div class="float_clear"></div>
                </div>
            </div>
        </div>
    </div>
        <div class="container">
        <%--<h2 class="semiBold mb-1">Enquiry</h2>--%>
        <%--<span class="fontRegular clrGrey line-ht-5">Tempor erat elitr rebum at clita. Diam dolor diam ipsum sit. Aliqu diam amet diam et eos erat ipsum et lorem et sit,</span>--%>



        <span class="space30"></span>
        <div class="row">
            <div class="col-md-8">
                <div class="p-4">

                    <%=prMarkup %>
                    <span class="space10"></span>

                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                        <ContentTemplate>
                            <div class="form-row">
                                <div class="form-group col-md-12">
                                    <asp:TextBox ID="txtName" class="conTextBox" placeholder="Name *" runat="server"></asp:TextBox>
                                </div>
                            </div>
                            <div class="form-row">
                                <div class="row">
                                     <div class="form-group col-md-6">
                                    <asp:TextBox ID="txtEmail" class="conTextBox" placeholder="Email *" runat="server"></asp:TextBox>
                                </div>
                                <div class="form-group col-md-6">
                                    <asp:TextBox ID="txtMobile" class="conTextBox" placeholder="Mobile No *" runat="server"></asp:TextBox>
                                </div>
                                </div>
                               
                            </div>
                            <div class="form-row">
                                <div class="form-group col-md-12">
                                    <asp:TextBox ID="txtCompany" class="conTextBox" placeholder="Comapny Name *" runat="server"></asp:TextBox>
                                </div>
                            </div>
                             <div class="form-row">
                                <div class="row">
                                    <div class="form-group col-md-12">
                                        <asp:TextBox ID="txtCity" class="conTextBox" placeholder="City *" runat="server"></asp:TextBox>
                                    </div>
                                   <%-- <div class="form-group col-md-6">
                                        <asp:TextBox ID="txtCountry" class="conTextBox" placeholder="Country *" runat="server"></asp:TextBox>
                                    </div>--%>
                                </div>
                            <div class="form-row">
                                <div class="form-group col-md-12">
                                    <asp:TextBox ID="txtAddress" TextMode="MultiLine" Height="150" class="conTextBox" placeholder="Address *" runat="server"></asp:TextBox>
                                </div>
                            </div>
                           
                            </div>
                           
                           <%-- <div class="form-group">
                                <div class="">
                                    <asp:DropDownList ID="ddrServices" CssClass="conTextBox" runat="server">
                                        <asp:ListItem Value="0" class="clrdarkgrey">--Select Services *--</asp:ListItem>
                                        <asp:ListItem Value="1">Architectural design of villas and houses</asp:ListItem>
                                        <asp:ListItem Value="2">Interior design of villas and houses</asp:ListItem>
                                        <asp:ListItem Value="3">Apartment interior design</asp:ListItem>
                                        <asp:ListItem Value="4">Interior design of bedroom</asp:ListItem>
                                    </asp:DropDownList>

                                </div>
                            </div>--%>
                            <div class="form-group">
                                <asp:TextBox ID="txtMessage" class="conTextBox" TextMode="MultiLine" Height="150" placeholder="Message *" runat="server"></asp:TextBox>
                            </div>
                            <span class="space20"></span>
                            <asp:Button ID="btnSubmit" CssClass="buttonForm text-uppercase" runat="server" Text="Submit" OnClick="btnSubmit_Click" />
                        </ContentTemplate>
                    </asp:UpdatePanel>
                    <%--</form>--%>
                </div>
            </div>
            <div class="col-md-4">
                <div class="p-4">
                    <img src="<%=Master.rootPath + "images/icon.svg" %>" class="img-fluid w-100" />
                </div>
            </div>
        </div>
    </div>
</asp:Content>

