<%@ Page Title="News" Language="C#" MasterPageFile="~/MasterParent.master" AutoEventWireup="true" CodeFile="news.aspx.cs" Inherits="news" %>
<%@ MasterType VirtualPath="~/MasterParent.master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="pgHeader1" id="pagehead">
        <div class="headerOverlay d-flex align-items-center justify-content-center">
            <div class="container">
                <div class="p-4">
                    <h1 class="text-white text-center text-uppercase">News</h1>
                    <div class="float_clear"></div>
                </div>
            </div>
        </div>
    </div>
    <%--  --%>
    <span class="space30"></span>
    <div class="container">
    <div class="row gy-2">
        <div class="col-md-4">
            <img src="images/value-products-bg.jpg" class="img-fluid w-100" />
        </div>
        <div class="col-md-8">
            <h3 class="semiBold semiMedium colorPrime eventtitle">Lorem Ipsum is simply dummy text of the printing and typesetting industry</h3>
            <span class="space5"></span>
            <span class="clrGrey small fst-italic">14/02/2023</span>
            <p class="fontRegular light  line-ht-7 mt-3 mb-4">Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book.</p>
            <a href="#" class="btnexplore">Explore</a>
        </div>
        <span class="greyLine"></span>

        <div class="col-md-4">
            <img src="images/value-products-bg.jpg" class="img-fluid w-100" />
        </div>
        <div class="col-md-8">
            <h3 class="semiBold semiMedium colorPrime eventtitle">Lorem Ipsum is simply dummy text of the printing and typesetting industry</h3>
            <span class="space5"></span>
            <span class="clrGrey small fst-italic">14/02/2023</span>
            <p class="fontRegular light  line-ht-7 mt-3 mb-4">Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book.</p>
            <a href="#" class="btnexplore">Explore</a>
        </div>
        <span class="greyLine"></span>

        <div class="col-md-4">
            <img src="images/value-products-bg.jpg" class="img-fluid w-100" />
        </div>
        <div class="col-md-8">
            <h3 class="semiBold semiMedium colorPrime eventtitle">Lorem Ipsum is simply dummy text of the printing and typesetting industry</h3>
            <span class="space5"></span>
            <span class="clrGrey small fst-italic">14/02/2023</span>
            <p class="fontRegular light  line-ht-7 mt-3 mb-4">Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book.</p>
            <a href="#" class="btnexplore">Explore</a>
        </div>
    </div>
        </div>
</asp:Content>

