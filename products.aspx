<%@ Page Title="Mixed Note Value Counter, Fake Note Detector Products | TechSell" Language="C#" MasterPageFile="~/MasterParent.master" AutoEventWireup="true" CodeFile="products.aspx.cs" Inherits="products" MaintainScrollPositionOnPostback="true" %>

<%@ MasterType VirtualPath="~/MasterParent.master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style>
       
    </style>
    <script type="text/javascript">
        $(function () {
            toggleBox('proDesc', 'sDesc');
        });

        $(window).load(function () {
            setSocialUrl();
        });

        function toggleBox(divId, switchId) {
            document.getElementById("proDesc").style.display = "none";
            document.getElementById("proFeat").style.display = "none";
            document.getElementById("proSpec").style.display = "none";
            document.getElementById("sDesc").className = "";
            document.getElementById("sFeat").className = "";
            document.getElementById("sSpec").className = "";

            $("#" + divId).fadeIn("5000");


            document.getElementById(switchId).className = "act";
        }
    </script>

    <script type="text/javascript">
        ; (function ($) {
            $('.swipebox-video').swipebox();
        })(jQuery);
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="pgHeader1" id="pagehead">
        <div class="headerOverlay d-flex align-items-center justify-content-center">
            <div class="container">
                <div class="p-4">
                    <h1 class="text-white text-center text-uppercase">Our Products</h1>
                    <div class="float_clear"></div>
                </div>
            </div>
        </div>
    </div>

    <span class="space30"></span>

      <asp:UpdatePanel ID="UpdatePanel2" runat="server" EnableViewState="true">
        <ContentTemplate>
    <div class="container">
        <div class="">
            <div class="margin_auto">
                <div class="pad_TB_15">
                    <h1 class="pageH1">Products</h1>
                    <span class="space10"></span>

                    <ul class="breadcrum">
                        <%=bCrumb %>
                    </ul>
                    <span class="space20"></span>
                </div>
            </div>
        </div>
    </div>
    <div class="clearfix"></div>

    <div class="container">
        <span class="space15"></span>
        <div class="row" id="divProducts" runat="server">
            <div class="col-md-4">
                <div class="pad_10">
                    <div class="navHeadBox">
                        <h2>Products</h2>
                        <a class="sideNavAnch" onclick="showNav('sideMenu');"></a>
                        <div class="float_clear"></div>
                    </div>
                    <ul id="sideMenu">
                        <%=sideNavDisplay %>
                    </ul>
                </div>
            </div>
            <div class="col-md-8">
                <div class="pad_10 ">
                    <%=productList %>
                </div>
            </div>
        </div>
    </div>

    <div class="clearfix"></div>

    <div class="container">
        <div id="divDetails" runat="server">
            <div class="row">
                <div class="col-md-6">
                    <div class="p-3 border">
                        <div class="borderBox">
                            <div class="pad_10">
                                <img alt="<%=arrDetails[1] %>" src="<%=arrDetails[0] %>" class="w100" />
                            </div>
                        </div>
                    </div>
                </div>
                <div class="col-md-6">
                    <div class="p-3">
                        <h2 class="subH2"><%=arrDetails[1] %></h2>
                        <div class="lineSpace"></div>
                        <ul class="featureList">
                            <%=arrDetails[2] %>
                        </ul>
                        <span class="space30"></span>

                        <div class="col-md-6">
                            <%=arrDetails[3] %>
                        </div>
                        <div class="col-md-6">
                            <%=arrDetails[4]%>
                        </div>
                    </div>
                    <div class="float_clear"></div>
                    <span class="space40"></span>
                    <a class="prDetAnch" href="<%=arrDetails[8] %>">Send Enquiry</a>
                    <span class="space20"></span>
                    <a id="fbAnch" class="social fb" onclick="basicPopup(this.href);return false"></a>
                    <a id="twAnch" class="social twt" onclick="basicPopup(this.href);return false"></a>
                </div>
            </div>
        

         <div class="specsPanel">
                <ul class="specNav">
                    <li><a id="sDesc" href="javascript:toggleBox('proDesc', 'sDesc');">Description</a></li>
                    <li><a id="sFeat" href="javascript:toggleBox('proFeat', 'sFeat');">Features</a></li>
                    <li><a id="sSpec" href="javascript:toggleBox('proSpec', 'sSpec');">Specification</a></li>
                </ul>
            </div>
            <span class="space30"></span>
            <div class="w100">
                <div id="proDesc">
                    <div class="pad_10">
                        <p><%=arrDetails[5] %></p>
                    </div>
                </div>
                <div id="proFeat">
                    <div class="pad_10">
                        <ul class="featureList">
                            <%=arrDetails[6] %>
                        </ul>
                    </div>
                </div>
                <div id="proSpec">
                    <div class="pad_10">
                        <%=arrDetails[7] %>
                    </div>
                </div>
            </div>
            </div>
    </div>
       </ContentTemplate>
    </asp:UpdatePanel>     
</asp:Content>

