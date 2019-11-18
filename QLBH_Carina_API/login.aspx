<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="QLBH_Carina_API.login21" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no" />
    <meta name="description" content="" />
    <meta name="author" content="" />
    <title>Quản Lý Bán Hàng Carina</title>
    <!--favicon-->
    <link rel="icon" href="assets/images/logo_carina_white.png" type="image/x-icon" />
    <!-- Bootstrap core CSS-->
    <link href="assets/css/bootstrap.min.css" rel="stylesheet" />
    <!-- animate CSS-->
    <link href="assets/css/animate.css" rel="stylesheet" type="text/css" />
    <!-- Icons CSS-->
    <link href="assets/css/icons.css" rel="stylesheet" type="text/css" />
    <!-- Custom Style-->
    <link href="assets/css/app-style.css" rel="stylesheet" />
    <link href="https://fonts.googleapis.com/css?family=Pacifico&display=swap&subset=vietnamese" rel="stylesheet" />
    <!-- Xử lý khối -->
    <script type="text/javascript" charset="utf-8"> function hasClassName(a, s) { return new RegExp("(?:^|\\s+)" + s + "(?:\\s+|$)").test(a.className) } function addClassName(a, s) { hasClassName(a, s) || (a.className = [a.className, s].join(" ")) } function removeClassName(a, s) { if (hasClassName(a, s)) { var e = new RegExp("(?:^|\\s+)" + s + "(?:\\s+|$)", "g"), m = a.className; a.className = m.replace(e, " ") } } function toggleClassName(a, s) { hasClassName(a, s) ? removeClassName(a, s) : addClassName(a, s) } function toggleShape() { var a = document.getElementById("shape"); hasClassName(a, "ring") ? (removeClassName(a, "ring"), addClassName(a, "cube")) : (removeClassName(a, "cube"), addClassName(a, "ring")); var s = document.getElementById("stage"); hasClassName(a, "ring") ? s.style.webkitTransform = "translateZ(-200px)" : s.style.webkitTransform = "" }</script>
    <style>
      body{margin:0;padding:0}#stage{width:100%;height:100%;padding-top:3.5em;-webkit-transition:-webkit-transform 2s;-webkit-transform-style:preserve-3d}#shape{position:relative;top:200px;margin:0 auto;height:250px;width:250px;-webkit-transform-style:preserve-3d}.plane{position:absolute;height:200px;width:200px;border:1px solid #fff;-webkit-border-radius:12px;-webkit-box-sizing:border-box;text-align:center;font-family:Times,serif;font-size:124pt;color:#000;background-color:rgba(255,255,255,.6);-webkit-transition:-webkit-transform 2s,opacity 2s;-webkit-backface-visibility:hidden}#shape.backfaces .plane{-webkit-backface-visibility:visible}#shape{-webkit-animation:spin 8s infinite linear}@-webkit-keyframes spin{from{-webkit-transform:rotateY(0)}to{-webkit-transform:rotateY(360deg)}}.one{background-image:url(assets/images/img/1.jpg);background-size:100% 100%;background-repeat:no-repeat}.two{background-image:url(assets/images/img/2.jpg);background-size:100% 100%;background-repeat:no-repeat}.three{background-image:url(assets/images/img/3.jpg);background-size:100% 100%;background-repeat:no-repeat}.four{background-image:url(assets/images/img/4.jpg);background-size:100% 100%;background-repeat:no-repeat}.five{background-image:url(assets/images/img/5.jpg);background-size:100% 100%;background-repeat:no-repeat}.six{background-image:url(assets/images/img/6.jpg);background-size:100% 100%;background-repeat:no-repeat}.seven{background-image:url(assets/images/img/7.jpg);background-size:100% 100%;background-repeat:no-repeat}.eight{background-image:url(assets/images/img/8.jpg);background-size:100% 100%;background-repeat:no-repeat}.nine{background-image:url(assets/images/img/9.jpg);background-size:100% 100%;background-repeat:no-repeat}.ten{background-image:url(assets/images/img/10.jpg);background-size:100% 100%;background-repeat:no-repeat}.eleven{background-image:url(assets/images/img/11.jpg);background-size:100% 100%;background-repeat:no-repeat}.twelve{background-image:url(assets/images/img/12.jpg);background-size:100% 100%;background-repeat:no-repeat}#shape.cube>.one{opacity:.2;-webkit-transform:scale3d(1.2,1.2,1.2) rotateX(90deg) translateZ(100px)}#shape.cube>.two{opacity:.2;-webkit-transform:scale3d(1.2,1.2,1.2) translateZ(100px)}#shape.cube>.three{opacity:.2;-webkit-transform:scale3d(1.2,1.2,1.2) rotateY(90deg) translateZ(100px)}#shape.cube>.four{opacity:.2;-webkit-transform:scale3d(1.2,1.2,1.2) rotateY(180deg) translateZ(100px)}#shape.cube>.five{opacity:.2;-webkit-transform:scale3d(1.2,1.2,1.2) rotateY(-90deg) translateZ(100px)}#shape.cube>.six{opacity:.2;-webkit-transform:scale3d(1.2,1.2,1.2) rotateX(-90deg) translateZ(100px) rotate(180deg)}#shape:hover.cube>.one{opacity:.9;-webkit-transform:scale3d(1.5,1.5,1.5) rotateX(90deg) translateZ(130px)}#shape:hover.cube>.two{opacity:.9;-webkit-transform:scale3d(1.5,1.5,1.5) translateZ(150px)}#shape:hover.cube>.three{opacity:.9;-webkit-transform:scale3d(1.5,1.5,1.5) rotateY(90deg) translateZ(150px)}#shape:hover.cube>.four{opacity:.9;-webkit-transform:scale3d(1.5,1.5,1.5) rotateY(180deg) translateZ(150px)}#shape:hover.cube>.five{opacity:.9;-webkit-transform:scale3d(1.5,1.5,1.5) rotateY(-90deg) translateZ(150px)}#shape:hover.cube>.six{opacity:.9;-webkit-transform:scale3d(1.5,1.5,1.5) rotateX(-90deg) translateZ(130px) rotate(180deg)}#shape.cube>.seven{-webkit-transform:scale3d(.8,.8,.8) rotateX(90deg) translateZ(100px) rotate(180deg)}#shape.cube>.eight{-webkit-transform:scale3d(.8,.8,.8) translateZ(100px)}#shape.cube>.nine{-webkit-transform:scale3d(.8,.8,.8) rotateY(90deg) translateZ(100px)}#shape.cube>.ten{-webkit-transform:scale3d(.8,.8,.8) rotateY(180deg) translateZ(100px)}#shape.cube>.eleven{-webkit-transform:scale3d(.8,.8,.8) rotateY(-90deg) translateZ(100px)}#shape.cube>.twelve{-webkit-transform:scale3d(.8,.8,.8) rotateX(-90deg) translateZ(100px)}.ring>.one{-webkit-transform:translateZ(380px)}.ring>.two{-webkit-transform:rotateY(30deg) translateZ(380px)}.ring>.three{-webkit-transform:rotateY(60deg) translateZ(380px)}.ring>.four{-webkit-transform:rotateY(90deg) translateZ(380px)}.ring>.five{-webkit-transform:rotateY(120deg) translateZ(380px)}.ring>.six{-webkit-transform:rotateY(150deg) translateZ(380px)}.ring>.seven{-webkit-transform:rotateY(180deg) translateZ(380px)}.ring>.eight{-webkit-transform:rotateY(210deg) translateZ(380px)}.ring>.nine{-webkit-transform:rotateY(-120deg) translateZ(380px)}.ring>.ten{-webkit-transform:rotateY(-90deg) translateZ(380px)}.ring>.eleven{-webkit-transform:rotateY(300deg) translateZ(380px)}.ring>.twelve{-webkit-transform:rotateY(330deg) translateZ(380px)}.controls{padding:5px}.controls>div{margin:10px}.audio{position:absolute;top:15px;left:15px;height:30px;width:300px}.classname{-moz-box-shadow:inset 0 1px 0 0 #fff;-webkit-box-shadow:inset 0 1px 0 0 #fff;box-shadow:inset 0 1px 0 0 #fff;background:-webkit-gradient(linear,left top,left bottom,color-stop(.05,#ededed),color-stop(1,#dfdfdf));background:-moz-linear-gradient(center top,#ededed 5%,#dfdfdf 100%);background-color:#ededed;-webkit-border-top-left-radius:6px;-moz-border-radius-topleft:6px;border-top-left-radius:6px;-webkit-border-top-right-radius:6px;-moz-border-radius-topright:6px;border-top-right-radius:6px;-webkit-border-bottom-right-radius:6px;-moz-border-radius-bottomright:6px;border-bottom-right-radius:6px;-webkit-border-bottom-left-radius:6px;-moz-border-radius-bottomleft:6px;border-bottom-left-radius:6px;text-indent:0;border:1px solid #dcdcdc;display:inline-block;color:#777;font-family:arial;font-size:15px;font-weight:700;font-style:normal;height:50px;line-height:50px;width:100px;text-decoration:none;text-align:center;text-shadow:1px 1px 0 #fff}.classname:hover{background:-webkit-gradient(linear,left top,left bottom,color-stop(.05,#dfdfdf),color-stop(1,#ededed));background:-moz-linear-gradient(center top,#dfdfdf 5%,#ededed 100%);background-color:#dfdfdf}.classname:active{position:relative;top:1px}.edit_icon{position:absolute;top:50%;left:4%;transform:translateY(-50%)}
    </style>
</head>
<body class="bg-theme bg-theme1">
    <!-- start loader -->
    <div id="pageloader-overlay" class="visible incoming">
        <div class="loader-wrapper-outer">
            <div class="loader-wrapper-inner">
                <div class="loader"></div>
            </div>
        </div>
    </div>
    <!-- end loader -->

    <!-- Start wrapper-->
    <div class="container-fluid">
        <div class="row">
            <div class="col-3 p-0 float-left " style="z-index: 99999999999999999999;">
                <div class="col-12 p-0">
                    <div class="card m-0" style="height: 100%; position: fixed; width: 25%;">
                        <div class="card-content p-3">
                            <div class="text-center">
                                <img src="assets/images/logo_login_carina-white.png" alt="logo icon" />
                            </div>
                            <div class="card-title text-uppercase text-center py-3"></div>

                            <form id="form1" runat="server">
                                <div>
                                    <div class="form-group">
                                        <div class="position-relative has-icon-left">
                                            <label for="exampleInputName" class="sr-only">Name</label>
                                            <i class="icon-user edit_icon"></i>
                                            <asp:TextBox ID="txtusername" autocomplete="off" CssClass="form-control" runat="server" placeholder="Tên Đăng Nhập" OnTextChanged="txtusername_TextChanged"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <div class="position-relative has-icon-left">
                                            <label for="exampleInputPassword" class="sr-only">Password</label>
                                            <i class="icon-lock edit_icon"></i>
                                            <asp:TextBox ID="txtpassword" autocomplete="off" CssClass="form-control" runat="server" placeholder="Mật Khẩu" OnTextChanged="txtpassword_TextChanged"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <div class="icheck-material-white">
                                            <input type="checkbox" id="user-checkbox" checked="" />
                                            <label for="user-checkbox">Ghi Nhớ Mật Khẩu</label>
                                        </div>
                                    </div>
                                    <asp:Button ID="gui" CssClass="btn btn-light btn-block waves-effect waves-light" runat="server" Text="Đăng Nhập Carina" OnClick="gui_Click" />
                                </div>
                            </form>
                        </div>
                    </div>
                </div>
            </div>
            <div class="col-9 float-right">
                <div style="text-align: right; padding: 15px;"><a href="#" class="classname" onclick="toggleShape()">Đổi kiểu</a></div>
                <div id="container">
                    <div id="stage">
                        <h3 style="font-family: 'Pacifico', cursive; font-size: 2.26rem;">Quản lí bán hàng Carina</h3>
                        <div id="shape" class="cube backfaces">
                            <div class="plane one"></div>
                            <div class="plane two"></div>
                            <div class="plane three"></div>
                            <div class="plane four"></div>
                            <div class="plane five"></div>
                            <div class="plane six"></div>
                            <div class="plane seven"></div>
                            <div class="plane eight"></div>
                            <div class="plane nine"></div>
                            <div class="plane ten"></div>
                            <div class="plane eleven"></div>
                            <div class="plane twelve"></div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <!-- Bootstrap core JavaScript-->
    <script src="assets/js/jquery.min.js"></script>
    <script src="assets/js/popper.min.js"></script>
    <script src="assets/js/bootstrap.min.js"></script>

    <!-- sidebar-menu js -->
    <script src="assets/js/sidebar-menu.js"></script>

    <!-- Custom scripts -->
    <script src="assets/js/app-script.js"></script>
</body>
</html>
