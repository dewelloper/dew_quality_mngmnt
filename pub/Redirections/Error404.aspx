﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="Error404.aspx.cs" Inherits="EvaluationAssistt.Web.Redirections.Error404" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="server">
    <div class="g_6 contents_header">
        <h3 class="i_16_forms tab_label">&nbsp;</h3>
    </div>
    <div class="g_12 separator">
        
    </div>
    <div class="g_12">
        <div class="widget_header">
            <h4 class="widget_header_title wwIcon i_16_forms">Sayfa ya da öğe bulunamadı</h4>
        </div>
        <div class="widget_contents noPadding">
            <div class="line_grid">
                <div class="g_3">
                    <span class="label">Yapabilecekleriniz :</span>
                    <ul>
                        <li><a href="/Pages/Home.aspx"><span class="label">Anasayfaya geri dön</span></a></li>
                        <li><a href="/Pages/ProfileManagement.aspx"><span class="label">Profilime git</span></a></li>
                    </ul>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
