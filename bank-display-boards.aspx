<%@ Page Title="" Language="C#" MasterPageFile="~/MasterParent.master" AutoEventWireup="true" CodeFile="bank-display-boards.aspx.cs" Inherits="bank_display_boards" %>
<%@ MasterType VirtualPath="~/MasterParent.master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="pgHeader1" id="pagehead">
        <div class="headerOverlay d-flex align-items-center justify-content-center">
            <div class="container">
                <div class="p-4">
                    <h1 class="text-white text-center text-uppercase">Bank display boards</h1>
                    <div class="float_clear"></div>
                </div>
            </div>
        </div>
    </div>
    <span class="space30"></span>
    <div class="container">
        <div class="row">
    <div class="col-md-8">
        <div class="pad10">
            <h2 class="h2Contact">Fixed Deposit Interest Display Boards</h2>
            <span class="space20"></span>
            <h3 class="h3contact">Specifications</h3>
            <span class="space20"></span>
            <ul class="specList" >
                <li>Unique display design</li>
                <li>Dimensions - Optional</li>
                <li>Number of countries - Optional</li>
                <li>RS232 Communication</li>
                <li>Ethernet Connectivity</li>
                <li>Running Moving Display</li>
                <li>Real Time & Date Display</li>
            </ul>
            <span class="space20"></span>
            <h3 class="h3contact">Key Features of Interest Display Boards</h3>
            <span class="space20"></span>
            <ul class="specList">
                <li>1” , 2” Digit Sizes</li>
                <li>Four & Six Digit Display</li>
                <li>Data Updating through Key Board or PC</li>
                <li>Indoor Type display boards</li>
                <li>Available in Numeric Displays or in Matrix Mode</li>
                <li>Reliable LED Display</li>
                <li>High Readability</li>
                <li>DATE/ TIME Display is available (OPTIONAL)</li>
                <li>High Quality MS Powder Coated Casing</li>
                <li>Require Power Input 220 V +/- 10 %, 50 Hz.</li>
                <li>Control Technology: 8 Bit Micro - Controller</li>
            </ul>

            <span class="space20"></span>
            <div class="row">
                <div class="col-md-4">
                    <div class="p-2">
                        <div class="border">
                            <div class="p-3">
                                <a href="upload/bank-boards/bank-of-india.jpg" data-fancybox="group1" class="swipebox" title="Bank of India">
                                    <img src="upload/bank-boards/thumbs/bank-of-india.jpg" alt="image" class="w100">
                                </a>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="col-md-4">
                    <div class="p-2">
                        <div class="border">
                            <div class="p-3">
                                <a href="upload/bank-boards/buldhana-urban-bank-H.jpg" data-fancybox="group1" class="swipebox" title="Buldhana Urban Bank - Horizontal">
                                    <img src="upload/bank-boards/thumbs/buldhana-urban-bank-H.jpg" alt="image" class="w100">
                                </a>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="col-md-4">
                    <div class="p-2">
                        <div class="border">
                            <div class="p-3">
                                    <a href="upload/bank-boards/buldhana-urban-bank-V.jpg" data-fancybox="group1" class="swipebox" title="Buldhana Urban Bank - Vertical">
                                        <img src="upload/bank-boards/thumbs/buldhana-urban-bank-V.jpg" alt="image" class="w100">
                                    </a>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="col-md-4">
                    <div class="p-2">
                        <div class="border">
                            <div class="p-3">
                                    <a href="upload/bank-boards/pandharpur-bank.jpg" data-fancybox="group1" class="swipebox" title="Pandharpur Bank">
                                        <img src="upload/bank-boards/thumbs/pandharpur-bank.jpg" alt="image" class="w100">
                                    </a>
                                </div>
                        </div>
                    </div>
                </div>
                <div class="col-md-4">
                    <div class="p-2">
                        <div class="border">
                            <div class="p-3">
                                <a href="upload/bank-boards/shri-adinath-bank.jpg" class="swipebox" data-fancybox="group1" title="Shri Adinath Bank">
                                    <img src="upload/bank-boards/thumbs/shri-adinath-bank.jpg" alt="image" class="w100">
                                </a>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="col-md-4">
                    <div class="p-2">
                        <div class="border">
                            <div class="p-3">
                                <a href="upload/bank-boards/tmb-bank.jpg" class="swipebox" data-fancybox="group1" title="TMB Bank">
                                    <img src="upload/bank-boards/thumbs/tmb-bank.jpg" alt="image" class="w100">
                                </a>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div class="float_clear"></div>
        </div>
    </div>
    <div class="col-md-4">
        <div  class="p-3">
            <a href="<%=Master.rootPath + "product/currency-counting-with-fake-note-detector" %>">
                <img src="<%=Master.rootPath + "images/cash-currency-counter.jpg" %>"   class="sb100" />
            </a>
        </div>
        
    </div>
        </div>
    <div class="float_clear"></div>
    

</div>
</asp:Content>

