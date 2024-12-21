<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DashBoard.aspx.cs" Inherits="E_WeddingDressShop.Views.DashBoard" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Wedding Dress Shop</title>
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/6.7.2/css/all.min.css" integrity="sha512-Evv84Mr4kqVGRNSgIGL/F/aIDqQb7xQ2vcrdIwxfjThSH8CSR7PBEakCr51Ck+w+/U6swU2Im1vVX0SVk9ABhg==" crossorigin="anonymous" referrerpolicy="no-referrer" />
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/slick-carousel/1.9.0/slick.min.css" integrity="sha512-yHknP1/AwR+yx26cB1y0cjvQUMvEa2PFzt1c9LlS4pRQ5NOTZFWbhBig+X9G9eYW/8m0/4OXNx8pxJ6z57x0dw==" crossorigin="anonymous" referrerpolicy="no-referrer" />
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/bootstrap/5.0.1/css/bootstrap.min.css" integrity="sha512-Ez0cGzNzHR1tYAv56860NLspgUGuQw16GiOOp/I2LuTmpSK9xDXlgJz3XN4cnpXWDmkNBKXR/VDMTCnAaEooxA==" crossorigin="anonymous" referrerpolicy="no-referrer" />
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/fancybox/3.5.7/jquery.fancybox.css" integrity="sha512-nNlU0WK2QfKsuEmdcTwkeh+lhGs6uyOxuUs+n+0oXSYDok5qy0EI0lt01ZynHq6+p/tbgpZ7P+yUb+r71wqdXg==" crossorigin="anonymous" referrerpolicy="no-referrer" />
    <link rel="stylesheet" href="https://unpkg.com/swiper/swiper-bundle.min.css"/>

    <style>
    @import url('https://fonts.googleapis.com/css2?family=Quicksand:wght@300..700&display=swap');
    @import url('https://fonts.googleapis.com/css2?family=Montserrat:ital,wght@0,100..900;1,100..900&display=swap');
    @font-face {
        font-family: "Housttely";
        src: url("../../Template/fonts/SVN-HousttelySignature-Regular.eot");
        src: url("../../Template/fonts/SVN-HousttelySignature-Regular.eot?#iefix") format("embedded-opentype"), 
            url("../../Template/fonts/SVN-HousttelySignature-Regular.woff2") format("woff2"), 
            url("../../Template/fonts/SVN-HousttelySignature-Regular.woff") format("woff"), 
            url("../../Template/fonts/SVN-HousttelySignature-Regular.ttf") format("truetype"), 
            url("../../Template/fonts/SVN-HousttelySignature-Regular.svg#SVN-HousttelySignature-Regular") format("svg");
        font-weight: normal;
        font-style: normal;
        font-display: swap;
    }

    * {
        margin: 0;
        padding: 0;
        box-sizing: border-box;
    }

    body {
        width: 100%;
        font-family: 'Montserrat', sans-serif;
    }

    header {
        position: fixed;
        top: 0;
        left: 0;
        width: 100%;
        height: 80px;
        box-shadow: 0 0 10px #00000059;
        display: flex;
        align-items: center;
        justify-content: space-between;
        padding: 0 40px;
        font-size: 14px;
        z-index: 10;
        background: #fff;
    }

    header img {
        width: 150px;
        object-fit: cover;
        margin: 0 70px;
    }

    .menu-header {
        flex: 1;
        display: flex;
        align-items: center;
        justify-content: space-between;
    }

    .menu-header a {
        padding: 10px 0;
        text-decoration: none;
        color: #222;
        transition: all 0.2s ease-in;
    }

    .menu-header a:hover {
        color: #ffb648;
    }

    /* ========== banner ========== */
    .banner {
        width: 100%;
        margin: 0 auto;
        overflow: hidden;
        padding-top: 80px;
    }

    .banner .swiper-slide img {
        width: 100%;
        object-fit: cover;
        display: block;
    }

    .banner .swiper-container {
        position: relative;
        width: 100%;
        height: 600px;
    }

    .banner .swiper-button-next,
    .banner .swiper-button-prev {
        color: white;
        opacity: 0.8;
        transition: color 0.3s ease, opacity 0.3s ease;
    }

    .banner .swiper-button-next:hover,
    .banner .swiper-button-prev:hover {
        opacity: 1;
    }

    .banner .swiper-pagination-bullet {
        background-color: white;
        opacity: 0.6;
        transition: opacity 0.3s ease;
    }

    .banner .swiper-pagination-bullet-active {
        opacity: 1;
    }
    </style>
</head>
<body>
    <header>
        <div class="menu-header">
            <a href="#">ABOUT US</a>
            <a href="#">ALBUMS WEDDING</a>
            <a href="#">COLLECTIONS</a>
            <a href="#">NEW CONCEPT</a>
        </div>
        <img src="../../Template/image/logo-header.png" />
        <div class="menu-header">
            <a href="#">DRESS WEDDING</a>
            <a href="#">MIMOSA ACADEMI</a>
            <a href="#">BLOGS</a>
            <a href="#">LOGIN</a>
        </div>
    </header>
    
    <div class="banner">
        <div class="swiper-container">
            <div class="swiper-wrapper slides-banner">
                <div class="swiper-slide">
                    <img src="../../Template/image/banner.png" />
                </div>
                <div class="swiper-slide">
                    <img src="../../Template/image/banner.png" />
                </div>
                <div class="swiper-slide">
                    <img src="../../Template/image/banner.png" />
                </div>
            </div>
            <!-- Thêm nút điều hướng -->
            <div class="swiper-button-next"></div>
            <div class="swiper-button-prev"></div>
            <!-- Thêm Pagination -->
            <div class="swiper-pagination"></div>
        </div>
    </div>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/jquery/3.7.1/jquery.min.js" integrity="sha512-v2CJ7UaYy4JwqLDIrZUI/4hqeoQieOmAZNXBeQyjo21dadnwR+8ZaIJVT8EE2iyI61OV8e6M8PP2/4hpQINQ/g==" crossorigin="anonymous" referrerpolicy="no-referrer"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/bootstrap/5.0.1/js/bootstrap.min.js" integrity="sha512-EKWWs1ZcA2ZY9lbLISPz8aGR2+L7JVYqBAYTq5AXgBkSjRSuQEGqWx8R1zAX16KdXPaCjOCaKE8MCpU0wcHlHA==" crossorigin="anonymous" referrerpolicy="no-referrer"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/fancybox/3.5.7/jquery.fancybox.min.js" integrity="sha512-uURl+ZXMBrF4AwGaWmEetzrd+J5/8NRkWAvJx5sbPSSuOb0bZLqf+tOzniObO00BjHa/dD7gub9oCGMLPQHtQA==" crossorigin="anonymous" referrerpolicy="no-referrer"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/slick-carousel/1.9.0/slick.min.js" integrity="sha512-HGOnQO9+SP1V92SrtZfjqxxtLmVzqZpjFFekvzZVWoiASSQgSr4cw9Kqd2+l8Llp4Gm0G8GIFJ4ddwZilcdb8A==" crossorigin="anonymous" referrerpolicy="no-referrer"></script>
    <script src="https://unpkg.com/swiper/swiper-bundle.min.js"></script>
    <script>
        document.addEventListener("DOMContentLoaded", () => {
            const swiper = new Swiper('.banner .swiper-container', {
                loop: true,
                autoplay: {
                    delay: 3000,
                    disableOnInteraction: false,
                },
                speed: 800,
                effect: 'slide',
                fadeEffect: {
                    crossFade: true,
                },
                navigation: {
                    nextEl: '.swiper-button-next',
                    prevEl: '.swiper-button-prev',
                },
                pagination: {
                    el: '.swiper-pagination',
                    clickable: true,
                },
                lazy: true,
            });
        });
    </script>
</body>
</html>
