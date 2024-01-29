<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8" />
    <meta content="width=device-width, initial-scale=1.0" name="viewport" />
    <title>Mixed Note Value Counter, Fake Note Detector, Dealer in Sangli Kolhapur | TechSell</title>
    <meta content="" name="description" />
    <meta content="" name="keywords" />

    <!-- Font Roboto -->
    <link rel="preconnect" href="https://fonts.googleapis.com" />
    <link rel="preconnect" href="https://fonts.gstatic.com" crossorigin />
    <link href="https://fonts.googleapis.com/css2?family=Roboto:wght@100;300;400;500;700&family=Varela+Round&display=swap" rel="stylesheet" />

    <!-- Bootstrap -->
    <link href="Vendor/bootstrap/css/bootstrap.min.css" rel="stylesheet" />
    <script src="Vendor/bootstrap/js/bootstrap.min.js"></script>

    <!-- aos -->
    <script src="js/jquery-2.2.4.min.js"></script>
    <link href="https://unpkg.com/aos@2.3.1/dist/aos.css" rel="stylesheet" />
    <script src="https://unpkg.com/aos@2.3.1/dist/aos.js"></script>

    <!-- Swiper slider -->
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/swiper@9/swiper-bundle.min.css" />
    <script src="https://cdn.jsdelivr.net/npm/swiper@9/swiper-bundle.min.js"></script>

    <!--Animate Css  -->
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/animate.css/4.1.1/animate.min.css" />

    <!-- Ytp Player -->
    <script src="js/jquery.mb.YTPlayer.js"></script>

    <!-- Main Css -->
    <link href="css/techsell.css" rel="stylesheet" />
</head>
<body>
    <section id="navrbar">
        <!-- Header Starts -->
        <div class="header">
            <div class="p-1">
                <div class="container-fluid">
                    <div class="socialBox">
                        <a href="#" target="_blank" class="topFb" title="Follow Us on facebook"></a>
                        <a href="#" target="_blank" class="topInsta" title="Follow Us on Instagram"></a>
                        <a href="#" target="_blank" class="topyouTube" title="Follow Us on twitter"></a>
                    </div>
                    <a href="tel:+91-233 2620659" class="colorWhite text-decoration-none me-3">+91-233 2620659</a>
                    <a href="tel:+91-9422406963" class="colorWhite text-decoration-none me-3 ph1">+91-9422406963</a>
                    <a href="tel:+91-9326406969" class="colorWhite text-decoration-none ph2">+91-9326406969</a>
                </div>
            </div>
        </div>
        <!-- Header End  -->
        <!-- Navigations start -->
        <div id="navigationBar">
            <div class="container-fluid">
                <div class="p-2">
                    <nav class="navbar navbar-expand-xl m-0 p-0">
                        <div class="container-fluid m-0 p-0">
                            <a class="navbar-brand" href="<%=rootPath %>">
                                <img src="images/techsell-logo.png" class="img-fluid logo" />
                            </a>
                            <button class="navbar-toggler" type="button" data-bs-toggle="collapse" data-bs-target="#navbarNavDropdown" aria-controls="navbarNavDropdown" aria-expanded="false" aria-label="Toggle navigation">
                                <img src="images/icons/social/nav-btn-color.png" />
                            </button>
                            <div class="collapse navbar-collapse" id="navbarNavDropdown">
                                <!-- Navigation starts -->
                                <ul class="navbar-nav ms-auto">
                                    <li class="nav-item">
                                        <a class="nav-link" aria-current="page" href="<%=rootPath%>">Home</a>
                                    </li>
                                    <li class="nav-item">
                                        <a class="nav-link" aria-current="page" href="about-us">About Us</a>
                                    </li>
                                    <li class="nav-item">
                                        <a class="nav-link" href="product">Products</a>
                                    </li>
                                    <%--<li class="nav-item">
                                        <a class="nav-link" href="#">Clients</a>
                                    </li>--%>
                                    <li class="nav-item">
                                        <a class="nav-link" href="awards">Awards</a>
                                    </li>
                                    <li class="nav-item">
                                        <a class="nav-link" href="news">News</a>
                                    </li>
                                    <li class="nav-item">
                                        <a class="nav-link" href="enquiry">Enquiry</a>
                                    </li>
                                    <li class="nav-item">
                                        <a class="nav-link" href="contact-us">Contact Us</a>
                                    </li>
                                </ul>
                            </div>
                        </div>
                </div>
                </nav>
            </div>
        </div>
        <!-- Navigations End -->
    </section>

    <!-- Banner Starts -->
    <section>
        <div id="bannerBg">
            <div class="container">
                <span class="space40"></span>
                <div id="carouselExampleControls" class="carousel slide" data-bs-ride="carousel">
                    <div class="">
                        <div class="carousel-inner">
                            <div class="carousel-item active">
                                <img src="images/banner/banner-0-1.jpg" class="img-fluid w-100" />
                            </div>
                            <div class="carousel-item">
                                <img src="images/banner/banner-0.jpg" class="img-sfluid w-100" />
                            </div>
                            <div class="carousel-item">
                                <img src="images/banner/banner-1.jpg" class="img-sfluid w-100" />
                            </div>
                            <div class="carousel-item">
                                <img src="images/banner/banner-2.jpg" class="img-sfluid w-100" />
                            </div>
                            <div class="carousel-item">
                                <img src="images/banner/banner-3.jpg" class="img-sfluid w-100" />
                            </div>
                            <div class="carousel-item">
                                <img src="images/banner/banner-4.jpg" class="img-sfluid w-100" />
                            </div>
                            <div class="carousel-item">
                                <img src="images/banner/banner-5.jpg" class="img-sfluid w-100" />
                            </div>
                        </div>
                    </div>
                </div>
                <span class="space40"></span>
            </div>
        </div>
    </section>
    <!-- Banner End -->
    <!-- Brief Info start-->
    <section class="mt-5">
        <div class="container">
            <div class="section-title">
                <h2 class="pageH1 txt_center">TechSell - Tushar Enterprises</h2>
            </div>
            <p class="fontRegular text-center ">
                TechSell aka Tushar Enterprises has been providing Banking, Industrial and also customized equipments for more than two decades. Tushar Enterprises focus has always been on innovation and quality. TechSell is formed with vision of “Providing world class intellectual equipments at affordable prices so that the masses can get quality of performance and accuracy for their industry or business.
            </p>
        </div>
    </section>
    <!-- Brief Info end -->

    <!-- Stats Count -->
    <!-- Fadein-out animation div starts -->
    <span class="space30"></span>
    <div class="bgQBox text-center">
        <span class="space40"></span>
        <div class="container overFlowHidden">
            <div class="row gy-3" id="counter">
                <div class="col-lg">
                    <div class="pad_15">
                        <h4 class="extra-large text-white semiBold letter-sp-2 mrg_B_5 count-num" data-count="50000">50,000 +</h4>
                        <span class="text-white semiBold semiMedium">Installations</span>
                    </div>
                </div>
                <div class="col-lg">
                    <div class="pad_15">
                        <h4 class="extra-large text-white semiBold letter-sp-2 mrg_B_5 count-num" data-count="10">20+</h4>
                        <span class="text-white semiBold semiMedium">Years of Excellence</span>
                    </div>
                </div>
                <div class="col-lg">
                    <div class="pad_15">
                        <h4 class="extra-large text-white semiBold letter-sp-2 mrg_B_5 count-num" data-count="40">50+</h4>
                        <span class="text-white semiBold semiMedium">Trained Engineers</span>
                    </div>
                </div>
                <div class="col-lg">
                    <div class="pad_15"> 
                        <h4 class="extra-large text-white semiBold letter-sp-2 mrg_B_5 count-num" data-count="5">10+</h4>
                        <span class="text-white semiBold semiMedium">R&amp;D Engineers</span>
                    </div>
                </div>
                <div class="col-lg">
                    <div class="pad_15">
                        <span class="space20"></span>
                        <img src="images/icons/certification.png" class=""/>
                        <span class="space20"></span>
                        <span class="text-white semiBold semiMedium">ISO 9001:2015</span>
                    </div>
                </div>

                <div class="float_clear"></div>
            </div>
            <span class="space40"></span>
        </div>
    </div>


        <section id="projects" class="mt-5">
            <span class="space10"></span>
            <div class="container-fluid">
                <div class="p-3">
                    <div class="section-title">
                        <h2 class="pageH1 txt_center">TechSell EXCLUSIVE PRODUCTS</h2>
                    </div>
                    <span class="space30"></span>
                    <div class="row">
                        <div class="swiper mySwiper">
                            <div class="swiper-wrapper">
                                <%=GetProjectsData() %>
                                <%--<div class="swiper-slide">
                                    <a href="#" class="text-decoration-none">
                                        <img src="images/maxvell-mx-100-ipro.jpg" class="d-block w-100 img-fluid" alt="...">
                                        <div class="px-4" style="width:200px;">
                                            <div class="projectbox">
                                                <div class="">
                                                    <div class="p-3">
                                                        <p class="semiBold semiMedium mb-2 colorSec">MX-100i PRO +</p>
                                                        <p class="fontRegular clrdarkgrey mb-2">
                                                            Automatic start, stop and clear with UV, MG, MT, IR, 3D Color detection while counting.
                                                            <span class="space15"></span>
                                                            <span href="" class="btnEvent">Brochure</span>
                                                        </p>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </a>
                                </div>
                                <div class="swiper-slide">
                                    <a href="#" class="text-decoration-none">
                                        <img src="images/maxvell-mx-100-ipro.jpg" class="d-block w-100 img-fluid" alt="...">
                                        <div class="px-4" style="width:200px;">
                                            <div class="projectbox">
                                                <div class="">
                                                    <div class="p-3">
                                                        <p class="semiBold semiMedium mb-2 colorSec">MX-100i PRO +</p>
                                                        <p class="fontRegular clrdarkgrey mb-2">
                                                            Automatic start, stop and clear with UV, MG, MT, IR, 3D Color detection while counting.
                                                            <span class="space15"></span>
                                                            <span href="" class="btnEvent">Brochure</span>
                                                        </p>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </a>
                                </div>
                                <div class="swiper-slide">
                                    <a href="#" class="text-decoration-none">
                                        <img src="images/maxvell-mx-100-ipro.jpg" class="d-block w-100 img-fluid" alt="...">
                                        <div class="px-4" style="width:200px;">
                                            <div class="projectbox">
                                                <div class="">
                                                    <div class="p-3">
                                                        <p class="semiBold semiMedium mb-2 colorSec">MX-100i PRO +</p>
                                                        <p class="fontRegular clrdarkgrey mb-2">
                                                            Automatic start, stop and clear with UV, MG, MT, IR, 3D Color detection while counting.
                                                            <span class="space15"></span>
                                                            <span href="" class="btnEvent">Brochure</span>
                                                        </p>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </a>
                                </div>
                                <div class="swiper-slide">
                                    <a href="#" class="text-decoration-none">
                                        <img src="images/maxvell-mx-100-ipro.jpg" class="d-block w-100 img-fluid" alt="...">
                                        <div class="px-4" style="width:200px;">
                                            <div class="projectbox">
                                                <div class="">
                                                    <div class="p-3">
                                                        <p class="semiBold semiMedium mb-2 colorSec">MX-100i PRO +</p>
                                                        <p class="fontRegular clrdarkgrey mb-2">
                                                            Automatic start, stop and clear with UV, MG, MT, IR, 3D Color detection while counting.
                                                            <span class="space15"></span>
                                                            <span href="" class="btnEvent">Brochure</span>
                                                        </p>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </a>
                                </div>--%>
                            </div>
                            <span class="space80"></span>
                            <%--<span class="space80"></span>--%>
                            <span class="space60"></span>
                            <div class="swiper-pagination"></div>
                        </div>
                         <span class="space30"></span>
                        <div class="text-center">
                            <a href="#" class="btnViewMore">View More</a>
                        </div>
                    </div>
                </div>
            </div>
            <!-- <span class="space80"></span>-->
        </section>
        <!-- Products End -->
        <!-- Value Added starts -->
        <section id="valuesprod" class="mt-5">
            <div class="bgvalueadded">
                <div class="overlyBannr">
                    <span class="space50"></span>
                    <div class="container">
                        <div id="carouselExampleFade" class="carousel slide carousel-fade" data-bs-ride="carousel">
                            <div class="carousel-inner">
                                <div class="carousel-item active">
                                    <div class="row g-0">
                                        <div class="col-lg-7">
                                            <div class="h-100">
                                                <img src="images/maxvell-mx-100-ipro.jpg" class="img-fluid w-100" />
                                            </div>
                                        </div>
                                        <div class="col-lg-5">
                                            <div class="bg-white h-100">
                                                <div class="p-4">
                                                    <span class="semiBold  semiMedium colorPrime text-uppercase">Value Added</span>
                                                    <span class="greyLine"></span>
                                                    <p class="fontRegular small line-ht-5">TechSell has been providing Banking, Industrial and also customized equipments for more than two decades.</p>
                                                    <ul class="">
                                                        <li>Hopper Capacity: 300 bills</li>
                                                        <li>Stacker Capacity: 200 bills</li>
                                                        <li>Counting Speed: 1000 pcs/min</li>
                                                        <li>Dimension: 310x285x175 mm</li>
                                                        <li>Power Supply: AC 220V +- 10% 50 Hz</li>
                                                    </ul>

                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <%--<div class="carousel-item">
                                    <div class="row g-0">
                                        <div class="col-lg-7">
                                            <img src="images/slide/maxsell-mx12a2-sangli.jpg" class="img-fluid w-100" />
                                        </div>
                                        <div class="col-lg-5">
                                            <div class="bg-white h-100">
                                                <div class="p-4">
                                                    <span class="semiBold  semiMedium colorPrime text-uppercase">Value Added</span>
                                                    <span class="greyLine"></span>
                                                    <p class="fontRegular small line-ht-5">TechSell has been providing Banking, Industrial and also customized equipments for more than two decades.</p>
                                                    <ul class="">
                                                        <li>Hopper Capacity: 300 bills</li>
                                                        <li>Stacker Capacity: 200 bills</li>
                                                        <li>Counting Speed: 1000 pcs/min</li>
                                                        <li>Dimension: 310x285x175 mm</li>
                                                        <li>Power Supply: AC 220V +- 10% 50 Hz</li>
                                                    </ul>

                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="carousel-item">
                                    <div class="row g-0">
                                        <div class="col-lg-7">
                                            <img src="images/slide/maxvell-MX-100i-PRO.jpg" class="img-fluid w-100" />
                                        </div>
                                        <div class="col-lg-5">
                                            <div class="bg-white h-100">
                                                <div class="p-4">
                                                    <span class="semiBold  semiMedium colorPrime text-uppercase">Value Added</span>
                                                    <span class="greyLine"></span>
                                                    <p class="fontRegular small line-ht-5">TechSell has been providing Banking, Industrial and also customized equipments for more than two decades.</p>
                                                    <ul class="">
                                                        <li>Hopper Capacity: 300 bills</li>
                                                        <li>Stacker Capacity: 200 bills</li>
                                                        <li>Counting Speed: 1000 pcs/min</li>
                                                        <li>Dimension: 310x285x175 mm</li>
                                                        <li>Power Supply: AC 220V +- 10% 50 Hz</li>
                                                    </ul>

                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>--%>
                            </div>
                           <%-- <button class="carousel-control-prev" type="button" data-bs-target="#carouselExampleFade" data-bs-slide="prev">
                                <span class="carousel-control-prev-icon" aria-hidden="true"></span>
                                <span class="visually-hidden">Previous</span>
                            </button>
                            <button class="carousel-control-next" type="button" data-bs-target="#carouselExampleFade" data-bs-slide="next">
                                <span class="carousel-control-next-icon" aria-hidden="true"></span>
                                <span class="visually-hidden">Next</span>
                            </button>--%>
                        </div>
                    </div>
                    <span class="space50"></span>
                </div>
            </div>
        </section>
        <!-- Value Added end -->
        <!-- News start -->
        <section id="news" class="mt-5">
            <div class="container">
                <div class="section-title">
                    <h2 class="pageH1 txt_center">News</h2>
                </div>
                <div class="row gy-3">
                    <%=GetNewsData() %>
                    <%--<div class="col-lg-4">
                        <div class="newsImg">
                            <img src="images/products/project-8.jpeg" class="img-fluid rounded mb-3 newsImg" />
                        </div>
                        <span class="fontRegular small colorPrime"> 6 Aug 2023 / <span class="small colorBlack">Tushar Enterprises Techsell</span> </span>
                        <span class="space10"></span>
                        <h3 class="nwstitle semiBold semiMedium mb-2">Lorem Ipsum is simply dummy text of the printing and typesetting industry.</h3>
                        <p class="fontRegular small line-ht-5">Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book.</p>
                        <a href="#" class="colorPrime text-decoration-none">Read More</a>
                    </div>
                    <div class="col-lg-4">
                        <div class="newsImg">
                            <img src="images/products/project-8.jpeg" class="img-fluid rounded mb-3 newsImg" />
                        </div>
                        <span class="fontRegular small colorPrime"> 6 Aug 2023 / <span class="small colorBlack">Tushar Enterprises Techsell</span> </span>
                        <span class="space10"></span>
                        <h3 class="nwstitle semiBold semiMedium mb-2">Lorem Ipsum is simply dummy text of the printing and typesetting industry.</h3>
                        <p class="fontRegular small line-ht-5">Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book.</p>
                        <a href="#" class="colorPrime text-decoration-none">Read More</a>
                    </div>
                    <div class="col-lg-4">
                        <div class="newsImg">
                            <img src="images/products/project-8.jpeg" class="img-fluid rounded mb-3 newsImg" />
                        </div>
                        <span class="fontRegular small colorPrime"> 6 Aug 2023 / <span class="small colorBlack">Tushar Enterprises Techsell</span> </span>
                        <span class="space10"></span>
                        <h3 class="nwstitle semiBold semiMedium mb-2">Lorem Ipsum is simply dummy text of the printing and typesetting industry.</h3>
                        <p class="fontRegular small line-ht-5">Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book.</p>
                        <a href="#" class="colorPrime text-decoration-none">Read More</a>
                    </div>--%>
                </div>
                <span class="space30"></span>
                <div class="text-center">
                    <a href="#" class="btnViewMore">View More</a>
                </div>
            </div>
        </section>
        <!-- News end -->
        <!-- Feature Products -->
        <span class="space30"></span>
        <section id="featureVideos" class="mt-5">
            <div class="">
                <div class="container-fluid">
                    <div class="section-title">
                        <h2 class="pageH1 txt_center">Transforming with technology</h2>
                    </div>
                    <p class="fontRegular  line-ht-5 text-center mt-0">TechSell Currency Sorters Machine an Outcome of an Intelligent Experience & Refined Research.</p>
                    <span class="space40"></span>
                    <div class="swiper mySwiper1">
                        <div class="swiper-wrapper">
                            <div class="swiper-slide">
                                <div class="video-container videobg">
                                    <div class="video-box">
                                        <div class="inner-video" id="v-pl">
                                            <div id="player" class="player dis-block" data-property="{videoURL:'https://www.youtube.com/watch?v=wzPUYk2maj8',containment:'#v-pl', autoplay: true, showControls: false, mute:true, loop:true, opacity:1}"></div>
                                        </div>

                                    </div>
                                </div>
                                <span class="space60"></span>
                            </div>
                            <div class="swiper-slide">
                                <div class="video-container videobg">
                                    <div class="video-box">
                                        
                                            <div class="inner-video" id="v-pl1">
                                                <div id="player1" class="player1 dis-block" data-property="{videoURL:'https://www.youtube.com/watch?v=_pwpNS-GGp0',containment:'#v-pl1', autoplay: true, showControls: false, mute:true, loop:true, opacity:1}"></div>
                                            </div>
                                        </div>
                                </div>
                            </div>
                            <div class="swiper-slide">
                                <div class="video-container videobg">
                                    <div class="video-box">
                                        <div class="inner-video" id="v-pl2">
                                            <div id="player2" class="player1 dis-block" data-property="{videoURL:'https://www.youtube.com/watch?v=_pwpNS-GGp0',containment:'#v-pl2', autoplay: true, showControls: false, mute:true, loop:true, opacity:1}"></div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="swiper-slide">

                            </div>
                        </div>
                        <div class="swiper-pagination"></div>
                    </div>
                    <span class="space40"></span>
                </div>
            </div>
        </section>
        <!-- Feature products end -->
        <!-- Our clients -->
        <section id="clients" class="mt-5">
            <div class="container">
                <div class="section-title">
                    <h2 class="pageH1 txt_center">TechSell - Precise Clients</h2>
                </div>
                <div class="swiper mySwiper2">
                    <div class="swiper-wrapper">
                        <div class="swiper-slide">
                            <img src="images/logo/axis-bank.png" />
                        </div>
                        <div class="swiper-slide">
                            <img src="images/logo/bank-of-india.png" />
                        </div>
                        <div class="swiper-slide">
                            <img src="images/logo/bank-of-maharashtra.png" />
                        </div>
                        <div class="swiper-slide">
                            <img src="images/logo/corporation-bank.png" />
                        </div>
                        <div class="swiper-slide">
                            <img src="images/logo/ichalkaranji-janta-sahakari-bank.png" />
                        </div>
                        <div class="swiper-slide">
                            <img src="images/logo/ratnakar-bank.png" />
                        </div>
                        <div class="swiper-slide">
                            <img src="images/logo/state-bank-india.png" />
                        </div>
                        <div class="swiper-slide">
                            <img src="images/logo/union-bank-india.png" />
                        </div>
                    </div>
                </div>
            </div>
            <span class="space20"></span>
        </section>
        <!-- our clients -->
        <!-- Footer start -->
        <section id="footer" class="shadow">
            <span class="greyLine"></span>
            <div class="bg-white">
                <div class="container-fluid">
                    <div class="p-3">
                        <div class="row">
                            <div class="col-lg-4">
                                <span class="semiBold semiMedium clrmediumgrey">TechSell - Tushar Enterprises</span>
                                <img src="images/techsell-logo.png" class="img-fluid logo mt-2" />
                            </div>
                            <div class="col-lg-4">
                                <h4 class="footerCaption  mb-2 semiBold upperCase letter-sp-2">Navigation</h4>
                                <ul class="footerNav">
                                    <li><a href="<%=rootPath %>">Home</a></li>
                                    <li><a href="about-us">About Us</a></li>
                                    <li><a href="product">Products</a></li>
                                    <%--<li><a href="c">Clients</a></li>--%>
                                    <li><a href="awards">Awards</a></li>
                                    <li><a href="news">News</a></li>
                                    <li><a href="enquiry">Enquiry</a></li>
                                    <li><a href="contact-us">Contact us</a></li>
                                </ul>
                            </div>
                            <div class="col-lg-4">
                                <h4 class="footerCaption clrWhite mb-2 semiBold upperCase letter-sp-2">Contact Info</h4>
                                <span class="addr line-ht-5 small">
                                    Gala No.3,37 Digambar Jain Boarding,
                                    Mahavirnagar, Sangli - 416416.
                                </span>
                                <span class="space15"></span>
                                <a href="#" class="email breakWord line-ht-5 small txtDecNone">san_tusharent@yahoo.com</a>
                                <span class="space15"></span>
                                <a href="+919326406969" class="foo_call line-ht-5 small txtDecNone">+91 9326406969</a>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div class="bgfooter">
                <div class="container-fluid">
                    <div class="p-3">
                        <span class="mrg_B_5 small fontRegular">&copy; <%=Currentyear %> | Techsell , All Rights Reserved</span>
                        <span class="small fontRegular">Website By <a href="http://www.intellect-systems.com" target="_blank" class="intellect" title="Website Design and Development Service By Intellect Systems">Intellect Systems</a></span>
                    </div>
                </div>
            </div>
        </section>
        <!-- Footer end -->
        <!-- Products slider start -->
        <script>
            var swiper = new Swiper(".mySwiper", {
                slidesPerView: 3,
                spaceBetween: 30,
                autoplay: true,
                pagination: {
                    el: ".swiper-pagination",
                    clickable: true,
                },
                breakpoints: {
                    320: {
                        slidesPerView: 1,
                        spaceBetween: 30
                    },
                    1200: {
                        slidesPerView: 3,
                        spaceBetween: 20
                    },
                    1140: {
                        slidesPerView: 3,
                        spaceBetween: 20
                    },
                    920: {
                        slidesPerView: 2,
                        spaceBetween: 20
                    },
                    800: {
                        slidesPerView: 2,
                        spaceBetween: 20
                    },
                    768: {
                        slidesPerView: 2,
                        spaceBetween: 20
                    },
                    640: {
                        slidesPerView: 2,
                        spaceBetween: 20
                    },
                    540: {
                        slidesPerView: 2,
                        spaceBetween: 20
                    }
                }
            });
        </script>
        <!-- Products slider end -->
        <!-- Feature videos slider -->
        <script>
            var swiper = new Swiper(".mySwiper1", {
                slidesPerView: 3,
                spaceBetween: 30,
               // freeMode: true,
                pagination: {
                    el: ".swiper-pagination",
                    clickable: true,
                },
                breakpoints: {
                    320: {
                        slidesPerView: 1,
                        spaceBetween: 30
                    },
                    1200: {
                        slidesPerView: 3,
                        spaceBetween: 20
                    },
                    1140: {
                        slidesPerView: 3,
                        spaceBetween: 20
                    },
                    920: {
                        slidesPerView: 2,
                        spaceBetween: 20
                    },
                    800: {
                        slidesPerView: 2,
                        spaceBetween: 20
                    },
                    768: {
                        slidesPerView: 2,
                        spaceBetween: 20
                    },
                    640: {
                        slidesPerView: 2,
                        spaceBetween: 20
                    },
                    540: {
                        slidesPerView: 2,
                        spaceBetween: 20
                    }
                }
            });
        </script>
        <!-- Feature videos slidre end -->
        <!-- YTp palyer -->
        <script type="text/javascript">
            $('document').ready(function () {
                if ($(".player").length > 0) {
                    $(".player").mb_YTPlayer();
                }
            });
        </script>

        <script type="text/javascript">
            $('document').ready(function () {
                if ($(".player1").length > 0) {
                    $(".player1").mb_YTPlayer();
                }
            });
        </script>

        <script type="text/javascript">
            $('document').ready(function () {
                if ($(".player2").length > 0) {
                    $(".player2").mb_YTPlayer();
                }
            });
        </script>

        <!-- our clients slider -->
        <script>
            var swiper = new Swiper(".mySwiper2", {
                slidesPerView: 5,
                spaceBetween: 30,
                autoplay: true,
                pagination: {
                    el: ".swiper-pagination",
                    clickable: true,
                },
                breakpoints: {
                    320: {
                        slidesPerView: 3,
                        spaceBetween: 30
                    },
                    1200: {
                        slidesPerView: 5,
                        spaceBetween: 20
                    },
                    1140: {
                        slidesPerView: 5,
                        spaceBetween: 20
                    },
                    920: {
                        slidesPerView: 4,
                        spaceBetween: 20
                    },
                    800: {
                        slidesPerView: 4,
                        spaceBetween: 20
                    },
                    768: {
                        slidesPerView: 4,
                        spaceBetween: 20
                    },
                    640: {
                        slidesPerView: 3,
                        spaceBetween: 20
                    },
                    540: {
                        slidesPerView: 3,
                        spaceBetween: 20
                    }
                }
            });
        </script>

        <!-- running count -->
        <script>
            var a = 0;
            $(window).scroll(function () {

                var oTop = $('#counter').offset().top - window.innerHeight;
                if (a == 0 && $(window).scrollTop() > oTop) {
                    $('.count-num').each(function () {
                        var $this = $(this),
                            countTo = $this.attr('data-count');
                        $({
                            countNum: $this.text()
                        }).animate({
                            countNum: countTo
                        },

                            {

                                duration: 2000,
                                easing: 'swing',
                                step: function () {
                                    $this.text(Math.floor(this.countNum));
                                },
                                complete: function () {
                                    $this.text(this.countNum);
                                    //alert('finished');
                                }

                            });
                    });
                    a = 1;
                }

            });
        </script>
</body>
</html>
