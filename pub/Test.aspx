<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="Test.aspx.cs" Inherits="EvaluationAssistt.Web.Test" EnableTheming="false" %>

<%@ Register Assembly="DevExpress.Web.v14.2, Version=14.2.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>





<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        td {
            border-color: red;
        }
        tr {
            border-color: red;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="server">
    <table border="1">
        <tr>
            <td>Tayfun</td>
            <td>Esmer</td>
        </tr>
        <tr>
            <td>Sevda</td>
            <td>Seçer</td>
        </tr>
        <tr>
            <td>Fatih</td>
            <td>Erdoğan</td>
        </tr>
    </table>
    <dx:ASPxRoundPanel ID="ASPxRoundPanel1" runat="server" Width="200px" Theme="Aqua"></dx:ASPxRoundPanel>
</asp:Content>
