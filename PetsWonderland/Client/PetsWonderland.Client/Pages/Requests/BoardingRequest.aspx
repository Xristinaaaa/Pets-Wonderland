﻿<%@ Page Language="C#" 
		AutoEventWireup="true" 
		MasterPageFile="../../Site.Master"
		CodeBehind="BoardingRequest.aspx.cs" Inherits="PetsWonderland.Client.Pages.Requests.BoardingRequest" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxtoolkit" %>

<asp:Content ContentPlaceHolderID="CustomStylesheets" runat="server">
    <link href="<%= ResolveUrl("~/Content/Pages/boardingRequest.css") %>" rel="stylesheet" type="text/css" />       
</asp:Content>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="col-md-4 form-horizontal boarding-request parallax">
		<div class="form-group">
			<h3>Register your pet to our hotel </h3>
		</div>
		<div class="form-content">
			<div class="form-group">
				<asp:Label runat="server" AssociatedControlID="PetName" CssClass="col-md-2 control-label">Pet name *</asp:Label>
				<div>
					<asp:TextBox runat="server" ID="PetName" CssClass="form-control"/>
					<asp:RequiredFieldValidator runat="server" ControlToValidate= "PetName"
						CssClass="col-md-offset-2 col-md-10 text-danger" ErrorMessage="The PetName field is required." />
				</div>
			</div>
			<div class="form-group">
				<asp:Label runat="server" AssociatedControlID="Breed" CssClass="col-md-2 control-label">Breed *</asp:Label>
				<div>
					<asp:TextBox runat="server" ID="Breed" CssClass="form-control"/>
					<asp:RequiredFieldValidator runat="server" ControlToValidate="Breed"
						CssClass="col-md-offset-2 col-md-10 text-danger" ErrorMessage="The Breed field is required." />
				</div>
			</div>
			<div class="form-group">
				<asp:Label runat="server" AssociatedControlID="Age" CssClass="col-md-2 control-label">Age *</asp:Label>
				<div>
					<asp:TextBox runat="server" ID="Age" CssClass="form-control"/>
					<asp:RequiredFieldValidator runat="server" ControlToValidate="Age"
						CssClass="col-md-offset-2 col-md-10 text-danger" ErrorMessage="The Age field is required." />
				</div>
			</div>
			<div class="form-group">
				<asp:Label runat="server" AssociatedControlID="Gender" CssClass="col-md-2 control-label">Gender</asp:Label>
				<asp:CheckBox runat="server" ID="Gender" CssClass="col-md-1 control-label" Text="Male"/>
				<asp:CheckBox runat="server" ID="Gender1" CssClass="col-md-1 control-label" Text="Female"/>
			</div>
			<div class="form-group">
				<asp:Label runat="server" AssociatedControlID="ImageUrl" CssClass="col-md-2 control-label">Insert animal image link</asp:Label>
				<asp:TextBox runat="server" ID="ImageUrl" CssClass="form-control"/>
			</div>
			<div class="form-group">
				<asp:Label runat="server" AssociatedControlID="Image"  CssClass="col-md-2 control-label">Or choose one </asp:Label>
				<div class="col-md-2">
					<asp:FileUpload runat="server" ID="Image"></asp:FileUpload>
				</div>
				<asp:Label ID="FileUploadedLabel" runat="server" CssClass="col-md-2 control-label"/>
			</div>
			<div class="dates-wrapper">
				<div class="form-group">
					<asp:Label runat="server" AssociatedControlID="txtFrom"  CssClass="col-md-2 control-label">From </asp:Label>
					<asp:TextBox ID="txtFrom" runat="server" CssClass="form-control" Width="110px"></asp:TextBox>
					<ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtFrom"></ajaxToolkit:CalendarExtender>	
				</div>
				<br />
				<div class="form-group">
					<asp:Label runat="server" AssociatedControlID="txtTo" CssClass="col-md-2 control-label">To </asp:Label>
					<asp:TextBox ID="txtTo" runat="server" CssClass="form-control" Width="110px"></asp:TextBox>
					<ajaxToolkit:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txtTo"></ajaxToolkit:CalendarExtender>	
				</div>
			</div>			
			<div class="form-group">
				<div class="col-md-offset-2 col-md-22">
					<br />
					<asp:Button runat="server" OnClick="CreateUserRequest_Click" Text="Send your request" CssClass="btn btn-default" />
				</div>
			</div>
		</div>
    </div>
</asp:Content>