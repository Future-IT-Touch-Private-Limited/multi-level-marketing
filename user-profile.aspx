<%@ Page Title="User Profile" Language="C#" MasterPageFile="~/main-admin.master" AutoEventWireup="true" CodeFile="user-profile.aspx.cs" Inherits="admin_user_profile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="content">
        <div class="card mb-3">
            <div class="card-header position-relative min-vh-25 mb-7">

                <div class="bg-holder rounded-3 rounded-bottom-0" style="background-image: url(../../assets/img/generic/4.jpg);"></div>
                <div class="avatar avatar-5xl avatar-profile">
                    <asp:Image ID="profileimg" Width="200" ImageUrl="~/user.png" class="rounded-circle img-thumbnail shadow-sm" runat="server" />
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
        <div class="row g-0">
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
            <div class="col-lg-6 pe-lg-2">
                <div class="card mb-3">
                    <div class="card-header">
                        <div class="row flex-between-end">
                            <div class="col-auto align-self-center">
                                <h5 class="mb-0" data-anchor="data-anchor" id="basic-example">User Details<a class="anchorjs-link " aria-label="Anchor" data-anchorjs-icon="#" href="#basic-example" style="padding-left: 0.375em;"></a></h5>
                            </div>
                        </div>
                    </div>
                    <div class="card-body bg-light">
                        <div class="tab-content">
                            <div class="tab-pane preview-tab-pane active" role="tabpanel">

                                <div class="input-group mb-3">
                                    <span class="input-group-text"><i class="fa fa-edit"></i></span>
                                    <asp:DropDownList ID="gender" CssClass="form-control" runat="server">
                                        <asp:ListItem>Male</asp:ListItem>
                                        <asp:ListItem>Female</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                                <div class="input-group mb-3">
                                    <span class="input-group-text"><i class="fa fa-edit"></i></span>
                                    <asp:TextBox ID="full_name" class="form-control" placeholder="Full Name" runat="server"></asp:TextBox>
                                </div>
                                <div class="input-group mb-3">
                                    <span class="input-group-text"><i class="fa fa-edit"></i></span>
                                    <asp:TextBox ID="mobile_no" class="form-control" placeholder="Mobile No." runat="server"></asp:TextBox>
                                </div>
                                <div class="input-group mb-3">
                                    <span class="input-group-text"><i class="fa fa-edit"></i></span>
                                    <asp:TextBox ID="email_address" ReadOnly="true" class="form-control" placeholder="Email Address" runat="server"></asp:TextBox>
                                </div>
                                <div class="input-group mb-3">
                                    <span class="input-group-text"><i class="fa fa-edit"></i></span>
                                    <asp:DropDownList ID="country" CssClass="form-control" runat="server">
                                        <asp:ListItem>India</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                                <div class="input-group mb-3">
                                    <span class="input-group-text"><i class="fa fa-edit"></i></span>
                                    <asp:DropDownList ID="state" CssClass="form-control" runat="server">
                                        <asp:ListItem>Andaman and Nicobar Islands</asp:ListItem>
                                        <asp:ListItem>Andhra Pradesh</asp:ListItem>
                                        <asp:ListItem>Arunachal Pradesh</asp:ListItem>
                                        <asp:ListItem>Assam</asp:ListItem>
                                        <asp:ListItem>Bihar</asp:ListItem>
                                        <asp:ListItem>Chandigarh</asp:ListItem>
                                        <asp:ListItem>Chhattisgarh</asp:ListItem>
                                        <asp:ListItem>Dadra and Nagar Haveli and Daman and Diu</asp:ListItem>
                                        <asp:ListItem>Delhi</asp:ListItem>
                                        <asp:ListItem>Goa</asp:ListItem>
                                        <asp:ListItem>Gujarat</asp:ListItem>
                                        <asp:ListItem>Haryana</asp:ListItem>
                                        <asp:ListItem>Himachal Pradesh</asp:ListItem>
                                        <asp:ListItem>Jammu and Kashmir</asp:ListItem>
                                        <asp:ListItem>Jharkhand</asp:ListItem>
                                        <asp:ListItem>Karnataka</asp:ListItem>
                                        <asp:ListItem>Kerala</asp:ListItem>
                                        <asp:ListItem>Ladakh</asp:ListItem>
                                        <asp:ListItem>Lakshadweep</asp:ListItem>
                                        <asp:ListItem>Madhya Pradesh</asp:ListItem>
                                        <asp:ListItem>Maharashtra</asp:ListItem>
                                        <asp:ListItem>Manipur</asp:ListItem>
                                        <asp:ListItem>Meghalaya</asp:ListItem>
                                        <asp:ListItem>Mizoram</asp:ListItem>
                                        <asp:ListItem>Nagaland</asp:ListItem>
                                        <asp:ListItem>Odisha</asp:ListItem>
                                        <asp:ListItem>Puducherry</asp:ListItem>
                                        <asp:ListItem>Punjab</asp:ListItem>
                                        <asp:ListItem>Rajasthan</asp:ListItem>
                                        <asp:ListItem>Sikkim</asp:ListItem>
                                        <asp:ListItem>Tamil Nadu</asp:ListItem>
                                        <asp:ListItem>Telangana</asp:ListItem>
                                        <asp:ListItem>Tripura</asp:ListItem>
                                        <asp:ListItem>Uttar Pradesh</asp:ListItem>
                                        <asp:ListItem>Uttarakhand</asp:ListItem>
                                        <asp:ListItem>West Bengal</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                                <div class="input-group mb-3">
                                    <span class="input-group-text"><i class="fa fa-edit"></i></span>
                                    <asp:TextBox ID="city" class="form-control" placeholder="City" runat="server"></asp:TextBox>
                                </div>
                                <div class="input-group mb-3">
                                    <span class="input-group-text"><i class="fa fa-edit"></i></span>
                                    <asp:TextBox ID="address" class="form-control" placeholder="Address" runat="server"></asp:TextBox>
                                </div>
                                <div class="input-group mb-3">
                                    <span class="input-group-text"><i class="fa fa-edit"></i></span>
                                    <asp:TextBox ID="pin_code" TextMode="Number" class="form-control" placeholder="Pin Code" runat="server"></asp:TextBox>
                                </div>
                                <div class="text-center">
                                    <asp:Button ID="saveuserdetails_btn" OnClick="saveuserdetails_btn_Click" CssClass="btn btn-md btn-success" runat="server" Text="Save User Details" />
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>

            <div class="col-lg-6">
                <div class="card mb-3">
                    <div class="card-header bg-light d-flex justify-content-between">
                        <h5 class="mb-0">Bank Details</h5>
                    </div>
                    <div class="card-body fs--1 p-3">
                        <div class="input-group mb-3">
                            <span class="input-group-text"><i class="fa fa-edit"></i></span>
                            <asp:TextBox ID="account_holder_name" class="form-control" placeholder="Account Holder Name" runat="server"></asp:TextBox>
                        </div>
                        <div class="input-group mb-3">
                            <span class="input-group-text"><i class="fa fa-edit"></i></span>
                            <asp:TextBox ID="bank_name" class="form-control" placeholder="Bank Name" runat="server"></asp:TextBox>
                        </div>
                        <div class="input-group mb-3">
                            <span class="input-group-text"><i class="fa fa-edit"></i></span>
                            <asp:TextBox ID="account_number" class="form-control" placeholder="Account Number" runat="server"></asp:TextBox>
                        </div>
                        <div class="input-group mb-3">
                            <span class="input-group-text"><i class="fa fa-edit"></i></span>
                            <asp:TextBox ID="ifsc_code" class="form-control" placeholder="IFSC Code" runat="server"></asp:TextBox>
                        </div>
                        <div class="text-center">
                            <asp:Button ID="savebankdetails_btn" OnClick="savebankdetails_btn_Click" CssClass="btn btn-md btn-success" runat="server" Text="Save Bank Details" />
                        </div>
                    </div>
                </div>


                <div class="card mb-3">
                    <div class="card-header bg-light d-flex justify-content-between">
                        <h5 class="mb-0">Account Status</h5>
                    </div>
                    <div class="card-body fs--1 p-3">
                        <div class="input-group mb-3">
                            <span class="input-group-text"><i class="fa fa-edit"></i></span>
                            <asp:DropDownList ID="account_status" class="form-control" runat="server">
                                <asp:ListItem>Running</asp:ListItem>
                                <asp:ListItem>Blocked</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                        <div class="text-center">
                            <asp:Button ID="change_status_btn" OnClick="change_status_btn_Click" CssClass="btn btn-md btn-success" runat="server" Text="Change Status" />
                        </div>
                    </div>
                </div>


                <div class="card mb-3">
                    <div class="card-header bg-light d-flex justify-content-between">
                        <h5 class="mb-0 text-center">Auto Login</h5>
                    </div>
                    <div class="card-body fs--1 p-3">
                        <asp:HyperLink ID="login_hl" Target="_blank" CssClass="btn btn-primary btn-md" runat="server">Login Account</asp:HyperLink>
                    </div>
                </div>

            </div>


        </div>

    </div>
</asp:Content>
