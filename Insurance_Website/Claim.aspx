<%@ Page Title="Contact" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Claim.aspx.cs" Inherits="Insurance_Website.Contact" %>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="jumbotron">
        <h1>Claim Request</h1>
    </div>
    <div class="row">
        <div class="col-md-6">
            <form id="claimForm" method="POST" >
                <div class="form-group">
                    <label for="ClaimTitle">Description of Claim</label>
                    <input type="text" class="form-control" ID="title" name="title">
                </div>
                <div class="form-group">
                    <label for="policyNumber">Policy Number</label>
                    <input type="text" class="form-control" ID="policyNumber" name="policyNumber">
                </div>
                <div class="form-group">
                    <label for="Amount">Claim Amount</label>
                    <input type="text" class="form-control" ID="amount" name="amount">
                </div>
                
                <asp:button type="submit" id="submitButton" text="Submit" class="btn btn-primary" runat="server"></asp:button>
            </form>
        </div>
        <div class="col-md-6">
        </div>
    </div>
</asp:Content>



