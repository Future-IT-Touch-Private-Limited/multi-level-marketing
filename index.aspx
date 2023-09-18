<%@ Page Language="C#" AutoEventWireup="true" CodeFile="index.aspx.cs" Inherits="sunil_index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Admin Login</title>
    <meta name="robots" content="noindex,nofollow" />
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <meta name="theme-color" content="#ffffff">
    <script src="~/assets/js/config.js"></script>
    <script src="~/vendors/overlayscrollbars/OverlayScrollbars.min.js"></script>
    <link rel="preconnect" href="https://fonts.gstatic.com">
    <link href="https://fonts.googleapis.com/css?family=Open+Sans:300,400,500,600,700%7cPoppins:300,400,500,600,700,800,900&amp;display=swap" rel="stylesheet">
    <link href="~/vendors/overlayscrollbars/OverlayScrollbars.min.css" rel="stylesheet">
    <link href="~/assets/css/theme-rtl.min.css" rel="stylesheet">
    <link href="~/assets/css/theme.min.css" rel="stylesheet">
    <link href="~/assets/css/user-rtl.min.css" rel="stylesheet">
    <link href="~/assets/css/user.min.css" rel="stylesheet">
    <script>
        var isRTL = JSON.parse(localStorage.getItem('isRTL'));
        if (isRTL) {
            var linkDefault = document.getElementById('style-default');
            var userLinkDefault = document.getElementById('user-style-default');
            linkDefault.setAttribute('disabled', true);
            userLinkDefault.setAttribute('disabled', true);
            document.querySelector('html').setAttribute('dir', 'rtl');
        } else {
            var linkRTL = document.getElementById('style-rtl');
            var userLinkRTL = document.getElementById('user-style-rtl');
            linkRTL.setAttribute('disabled', true);
            userLinkRTL.setAttribute('disabled', true);
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
        
        <!-- ===============================================-->
        <!--    Main Content-->
        <!-- ===============================================-->
        <main class="main" id="top">
            <div class="container" data-layout="container">
                <script>
                    var isFluid = JSON.parse(localStorage.getItem('isFluid'));
                    if (isFluid) {
                        var container = document.querySelector('[data-layout]');
                        container.classList.remove('container');
                        container.classList.add('container-fluid');
                    }
        </script>
                <div class="row flex-center min-vh-100 py-6">
                    <div class="col-sm-10 col-md-8 col-lg-6 col-xl-5 col-xxl-4">
                        <a class="d-flex flex-center mb-4" href="#">
                            <img class="me-2" src="../metaverse-logo.png" alt="" /></a>
                        <div class="card">
                            <div class="card-body p-4 p-sm-5">
                                <div class="row flex-between-center mb-2">
                                    <div class="col-auto">
                                        <h5>Log in</h5>
                                    </div>
                                </div>

                                <div class="mb-3">
                                    <asp:TextBox ID="username" class="form-control" runat="server" placeholder="Username"></asp:TextBox>
                                </div>
                                <div class="mb-3">
                                    <asp:TextBox ID="password" TextMode="Password" runat="server" placeholder="Password" class="form-control"></asp:TextBox>
                                </div>

                                <div runat="server" visible="false" id="errordiv" class="alert alert-danger alert-dismissible fade show" role="alert">
                                    <div class="row">
                                        <div class="col-2">
                                            <button type="button" class="btn-close" style="float: right" data-bs-dismiss="alert" aria-label="Close"></button>
                                        </div>
                                        <div class="col-10">
                                            <asp:Label ID="errorlbl" runat="server" Text=""></asp:Label>
                                        </div>
                                    </div>
                                </div>
                                <div runat="server" visible="false" id="successdiv" class="alert alert-success alert-dismissible fade show" role="alert">
                                    <div class="row">
                                        <div class="col-10">
                                            <asp:Label ID="successlbl" runat="server" Text=""></asp:Label>
                                        </div>
                                        <div class="col-2">
                                            
                                        </div>
                                    </div>
                                </div>

                                <div class="row flex-between-center">
                                    <div class="col-auto">
                                        <div class="form-check mb-0">
                                            <input class="form-check-input" type="checkbox" id="basic-checkbox" checked="checked" />
                                            <label class="form-check-label mb-0" for="basic-checkbox">Remember me</label>
                                        </div>
                                    </div>
                                    <div class="col-auto"><a class="fs--1" href="#">Forgot Password?</a></div>
                                </div>
                                <div class="mb-3">
                                    <asp:Button ID="loginbtn" OnClick="loginbtn_Click" class="btn btn-primary d-block w-100 mt-3" runat="server" Text="Login" />
                                </div>

                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </main>
        <!-- ===============================================-->
        <!--    End of Main Content-->
        <!-- ===============================================-->

        <!-- ===============================================-->
        <!--    JavaScripts-->
        <!-- ===============================================-->
        <script src="../vendors/popper/popper.min.js"></script>
        <script src="../vendors/bootstrap/bootstrap.min.js"></script>
        <script src="../vendors/anchorjs/anchor.min.js"></script>
        <script src="../vendors/is/is.min.js"></script>
        <script src="../vendors/fontawesome/all.min.js"></script>
        <script src="../vendors/lodash/lodash.min.js"></script>
        <script src="https://polyfill.io/v3/polyfill.min.js?features=window.scroll"></script>
        <script src="../vendors/list.js/list.min.js"></script>
        <script src="../assets/js/theme.js"></script>

    </form>
</body>
</html>
