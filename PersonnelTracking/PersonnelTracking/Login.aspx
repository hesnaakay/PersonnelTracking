<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="PersonnelTracking.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form class="form-horizontal" runat="server" id="form1" method="post">
  <div class="form-group">
    <label for="inputName" class="col-sm-2 control-label">Ad</label>
    <div class="col-sm-4">
      <asp:TextBox runat="server" type="text" CssClass="form-control" id="firstname" placeholder="Adınız"> </asp:TextBox>
    </div>
    <label for="inputName" class="col-sm-2 control-label">Soyad</label>
    <div class="col-sm-4">
      <asp:TextBox runat="server" type="text" class="form-control" id="lastname" placeholder="Soyadınız"> </asp:TextBox>
    </div>
  </div>
  <div class="form-group">
    <label for="inputPhone" class="col-sm-2 control-label">GSM</label>
    <div class="col-sm-4">
      <asp:TextBox runat="server" type="text" class="form-control" id="phonenumber" placeholder="GSM"> </asp:TextBox>
    </div>
    <label for="inputName" class="col-sm-2 control-label">Adres</label>
    <div class="col-sm-4">
      <asp:TextBox runat="server" type="text" class="form-control" id="address" placeholder="Adresiniz"> </asp:TextBox>
    </div>
  </div>
  <div class="form-group">
    <label for="inputPermit" class="col-sm-2 control-label">İzin Gün Sayısı</label>
    <div class="col-sm-4">
      <asp:TextBox runat="server" type="text" class="form-control" id="totalpermit" placeholder="İzinli Gün Sayısı"> </asp:TextBox>
    </div>
    <div class="col-sm-4">
    </div>
  </div>  
  <div class="form-group">
    <div class="col-sm-offset-2 col-sm-10">
    </div>
  </div>
  <div class="form-group">
    <div class="col-sm-offset-2 col-sm-10">
      <asp:Button runat="server" type="submit" class="btn btn-success" text = "Kayıt Yap" OnClick="login"> </asp:Button>
    </div>
  </div>
</form>
</asp:Content>
