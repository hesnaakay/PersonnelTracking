<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Usage.aspx.cs" Inherits="PersonnelTracking.Usage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Personel Bilgileri</h2>
    <div class="bs-example" data-example-id="bordered-table">
        <table class="table table-bordered" id="tblPersonnel">
            <thead>
                <tr>
                    <th>#</th>
                    <th>Ad</th>
                    <th>Soyad</th>
                    <th>Telefon Numarası</th>
                    <th>Adres</th>
                    <th>Toplam İzin</th>
                    <th>Kullanılan İzin</th>
                </tr>
            </thead>
            <tbody>
                
            </tbody>
        </table>
    </div>
    
    <div class="infoPersonnel" style="display: none;">
        <h3>Seçilen Personel Bilgisi</h3>
        <button class="btn btn-success" id ="permitAdd" style="margin-bottom: 5px;" data-id="">İzin Ekle</button> <br />
        <div class="alert alert-info" id="infoMsg" style="display:none;" role="alert"> İşlem başarıyla gerçekleşti...</div>
        <div class="alert alert-danger" id="dangerMsg" style="display:none;" role="alert"> İşleminiz gerçekleştirilemedi...</div>
        <table class="table table-hover">
            <thead>
                <tr>
                    <th>#</th>
                    <th>Ad</th>
                    <th>Soyad</th>
                    <th>Başlangıç Tarihi</th>
                    <th>Bitiş Tarihi</th>
                </tr>
            </thead>
            <tbody>             
            </tbody>
        </table>
    </div>
    <!-- Modal -->
    <div class="modal fade" id="myModal" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
      <div class="modal-dialog" role="document">
        <div class="modal-content">
          <div class="modal-header">
            <h5 class="modal-title" id="exampleModalLabel">Personel İzin Girişi Sayfası</h5>
            <button type="button" class="close" data-dismiss="modal" aria-label="Close">
              <span aria-hidden="true">&times;</span>
            </button>
          </div>
          <div class="modal-body" >
            <div class="row">
                <div class="col-md-12">
				<div class="card">
					<div class="content">
						<form id="dataForm1" action="Usage.aspx"  method="post">
							<div class="row">
								<div  class="form-group col-md-6">
									<label>Başlangıç Tarihi</label>
                                    
									<input class="form-control datepicker" id = "startdate" type="text" name="startdate" placeholder="Başlangıç Tarihi" autocomplete="off" />
								</div>
                                <div  class="form-group col-md-6">
									<label>Bitiş Tarihi</label>
                                    <input class="form-control datepicker" id="enddate" type="text" name="duedate" placeholder="Bitiş Tarihi" />
								</div>
							</div>
							<div class="row">
								<div  class="form-group col-md-12">
									<input class="form-control" type="hidden" name="id" value=""/>
                                    <div class="modal-footer">
                                        <button type="button" id="permitSave" class="btn btn-primary">İzni Kaydet</button>
                                    </div>
								</div>
							</div>
						</form> 
					</div>
				</div>
				</div>
            </div>
          </div>
          
        </div>
      </div>
    </div>
</asp:Content>
