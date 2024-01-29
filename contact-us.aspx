<%@ Page Title="Contact Us | TechSell" Language="C#" MasterPageFile="~/MasterParent.master" AutoEventWireup="true" CodeFile="contact-us.aspx.cs" Inherits="contact_us" %>

<%@ MasterType VirtualPath="~/MasterParent.master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script type="text/javascript"
        src="https://maps.googleapis.com/maps/api/js?key=AIzaSyCvO0AHfg1cuND1KXbw3t5xZr5p4PVrEk4">
    </script>
    <script type="text/javascript">
        function initialize() {
            var myLatlng = new google.maps.LatLng(16.862437, 74.572166);

            var mapOptions = {
                center: myLatlng,
                zoom: 17, scrollwheel: false, draggable: true,
            };

            var map = new google.maps.Map(document.getElementById("map-canvas"), mapOptions);
            var marker = new google.maps.Marker({
                position: myLatlng,
                map: map,
                title: "Tushar Enterprises"
            });

        }
        google.maps.event.addDomListener(window, 'load', initialize);
    </script>
    <style>
        #map-canvas{height:450px;}
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="pgHeader1" id="pagehead">
        <div class="headerOverlay d-flex align-items-center justify-content-center">
            <div class="container">
                <div class="p-4">
                    <h1 class="text-white text-center text-uppercase">Contact Us</h1>
                    <div class="float_clear"></div>
                </div>
            </div>
        </div>
    </div>
    <!-- Page Header Ends -->

    <%-- Map Canvas --%>
    <div id="map-canvas" class=""></div>
    <span class="space40"></span>
    <%-- Conatct us --%>
    <div class="container">
        <div class="row">
            <div class="col-md-8">
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <div class="form-row">
                            <div class="form-group col-md-12">
                                <asp:TextBox ID="txtName" class="conTextBox" placeholder="Name *" runat="server"></asp:TextBox>
                            </div>
                        </div>
                        <div class="form-row">
                            <div class="row">
                                <div class="form-group col-md-12">
                                    <asp:TextBox ID="txtEmail" class="conTextBox" placeholder="Email *" runat="server"></asp:TextBox>
                                </div>
                                <div class="form-group col-md-12">
                                    <asp:TextBox ID="txtPhone" class="conTextBox" placeholder="Mobile No *" runat="server"></asp:TextBox>
                                </div>
                            </div>

                        </div>
                        <div class="form-row">
                            <div class="form-group col-md-12">
                                <asp:TextBox ID="txtCompName" class="conTextBox" placeholder="Comapny Name *" runat="server"></asp:TextBox>
                            </div>
                        </div>
                        <div class="form-row">
                            <div class="form-group col-md-12">
                                <asp:TextBox ID="txtAdd" class="conTextBox" placeholder="Address " runat="server"></asp:TextBox>
                            </div>
                        </div>
                        <div class="form-row">
                            <div class="row">
                                <div class="form-group col-md-12">
                                    <asp:TextBox ID="txtCity" class="conTextBox" placeholder="City *" runat="server"></asp:TextBox>
                                </div>
                                <div class="form-group col-md-12">
                                    <asp:TextBox ID="txtCountry" class="conTextBox" placeholder="Country *" runat="server"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <span class="space20"></span>
                        <asp:Button ID="btnSubmit" CssClass="buttonForm text-uppercase" runat="server" Text="Submit" OnClick="btnSubmit_Click" />
                    </ContentTemplate>
                </asp:UpdatePanel>
                <span class="space30"></span>
                <div class="themeBGPrime">
                    <div class="p-3">
                        <span class="semiBold semiMedium text-white">Work Area</span>
                        <span class="space10"></span>
                        <p class="fontRegular regular line-ht-5 text-white">Satara, Ratnagiri, Mumbai, Pune, Nashik, Solapur, Goa, Sindhudurg, Belgaum</p>
                    </div>
                </div>
            </div>
            <div class="col-md-4">
                <div class="card mb-4">
                    <div class="card-body">
                        <h5 class="card-title colorPrime">Registered Office</h5>
                        <p class="card-text">
                            Gala No.3, 37 Digambar Jain Boarding
                            Mahavirnagar, Sangli - 416416
                            <span class="space10"></span>
                            <span class="foo_call"> +91 9326406969, +91 9326406963 </span> 
                            <span class="space5"></span>
                            <span class="foo_call"> +91-233-2620659, +91-233-2625620</span> 
                            <span class="space5"></span>
                            <span class="email">san_tusharent@yahoo.com</span>
                        </p>
                    </div>
                </div>
                <div class="card mb-4">
                     <div class="card-body">
                        <h5 class="card-title colorPrime">Branch Office Kolhapur</h5>
                        <p class="card-text">
                                612, E/B, Gala No. 3,
                                Anandi Chambers, Shahupuri 2nd Lane,
                                Kolhapur
                            <span class="space10"></span>
                            <span class="foo_call"> +91 9326406963, +91 9326406965 </span> 
                            <span class="space5"></span>
                            <span class="foo_call">+91-0231-2654963</span> 
                            <span class="space5"></span>
                            <span class="email">klp_tusharent@yahoo.com</span>
                        </p>
                    </div>
                </div>
                <div class="card mb-4">
                    <div class="card-body">
                        <h5 class="card-title colorPrime">Contact Persons</h5>
                        <p class="card-text">
                            Mr. Mahaveer D. Patil (Proprietor)<br />
                            +91 - 9422406963<br />
                            Shilpa Katkar (Sales Coordinator)<br />
                            +91 - 9326406969<br />
                            Mr. Jaykumar Patil (Sales Manager)<br />
                            +91 - 9405555955/56
                        </p>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

