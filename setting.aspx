<%@ Page Title="Setting" Language="C#" MasterPageFile="~/main-admin.master" AutoEventWireup="true" CodeFile="setting.aspx.cs" Inherits="admin_settings" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="content">
        <div class="card mb-3">
            <div class="card-header position-relative min-vh-25 mb-7">
                <div class="bg-holder rounded-3 rounded-bottom-0" style="background-image: url(../../assets/img/generic/4.jpg);"></div>
                <div class="avatar avatar-5xl avatar-profile">
                    <a href="change-profile-photo.aspx"><asp:Image ID="profileimg" Width="200" ImageUrl="~/dp/user.png" class="rounded-circle img-thumbnail shadow-sm" runat="server" /></a>
                </div>
            </div>
            <div class="card-body">
                <div class="row">
                    <div class="col-lg-8">
                        <h4 class="mb-1">
                            <asp:Label ID="full_name_lbl" runat="server" Text="Welcome"></asp:Label><span data-bs-toggle="tooltip" data-bs-placement="right" title="" data-bs-original-title="Verified" aria-label="Verified"><svg class="svg-inline--fa fa-check-circle fa-w-16 text-primary" data-fa-transform="shrink-4 down-2" aria-hidden="true" focusable="false" data-prefix="fa" data-icon="check-circle" role="img" xmlns="http://www.w3.org/2000/svg" viewBox="0 0 512 512" data-fa-i2svg="" style="transform-origin: 0.5em 0.625em;"><g transform="translate(256 256)"><g transform="translate(0, 64)  scale(0.75, 0.75)  rotate(0 0 0)"><path fill="currentColor" d="M504 256c0 136.967-111.033 248-248 248S8 392.967 8 256 119.033 8 256 8s248 111.033 248 248zM227.314 387.314l184-184c6.248-6.248 6.248-16.379 0-22.627l-22.627-22.627c-6.248-6.249-16.379-6.249-22.628 0L216 308.118l-70.059-70.059c-6.248-6.248-16.379-6.248-22.628 0l-22.627 22.627c-6.248 6.248-6.248 16.379 0 22.627l104 104c6.249 6.249 16.379 6.249 22.628.001z" transform="translate(-256 -256)"></path>
                            </g>
                            </g></svg><!-- <small class="fa fa-check-circle text-primary" data-fa-transform="shrink-4 down-2"></small> Font Awesome fontawesome.com --></span>
                        </h4>
                    </div>
                </div>
            </div>
        </div>
        <div class="row">
            <div class="col-lg-12">

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
                            <button type="button" class="btn-close" style="float: right" data-bs-dismiss="alert" aria-label="Close"></button>
                        </div>
                    </div>
                </div>

            </div>


            <div class="col-lg-6">
                <div class="card mb-3">
                    <div class="card-header bg-light d-flex justify-content-between">
                        <h5 class="mb-0">Change Password</h5>
                    </div>
                    <div class="card-body fs--1 p-3">
                        <div class="input-group mb-3">
                            <span class="input-group-text"><i class="fa fa-star"></i></span>
                            <asp:TextBox ID="currentpassword" TextMode="Password" class="form-control" placeholder="Current Password *" runat="server"></asp:TextBox>
                        </div>
                        <div class="input-group mb-3">
                            <span class="input-group-text"><i class="fa fa-star"></i></span>
                            <asp:TextBox ID="password" TextMode="Password" class="form-control" placeholder="New Password *" runat="server"></asp:TextBox>
                        </div>
                        <div class="input-group mb-3">
                            <span class="input-group-text"><i class="fa fa-star"></i></span>
                            <asp:TextBox ID="confirm_password" TextMode="Password" class="form-control" placeholder="Confirm Password *" runat="server"></asp:TextBox>
                        </div>
                        <div class="text-center">
                            <asp:Button ID="changepasswordbtn" OnClick="changepasswordbtn_Click" CssClass="btn btn-md btn-success" runat="server" Text="Update Password" />
                        </div>
                    </div>
                </div>
            </div>


        </div>

    </div>
</asp:Content>