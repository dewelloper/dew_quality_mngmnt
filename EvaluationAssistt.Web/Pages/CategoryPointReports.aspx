<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CategoryPointReports.aspx.cs" Inherits="EvaluationAssistt.Web.Pages.CategoryPointReports" %>
<%@ Register Assembly="DevExpress.Web.v14.2, Version=14.2.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>




<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table>
                <tr>
                    <td colspan="9">
                        <dx:ASPxLabel ID="alblMessage" runat="server" Text="">
                        </dx:ASPxLabel>
                        <asp:CheckBox ID="chkQualityAdminAgent" runat="server" Text="Kalite Uzmanı ve Admin Grubunda Filitrele" />
                    </td>
                </tr>
                <tr>
                    <td colspan="9">
                        <table>
                            <tr>
                                <td>Başlangıç Tarihi</td>
                                <td>
                                    <dx:ASPxDateEdit ID="axdpStartDate" runat="server" AllowNull="False" EditFormat="DateTime" DateOnError="Today">
                                    </dx:ASPxDateEdit>
                                </td>
                                <td>Bitiş Tarihi</td>
                                <td>
                                    <dx:ASPxDateEdit ID="axdPEndDate" runat="server" AllowNull="False" EditFormat="DateTime" DateOnError="Today">
                                    </dx:ASPxDateEdit>
                                </td>
                                <td>Formlar</td>
                                <td>
                                    <dx:ASPxComboBox ID="acmbPForms" runat="server" ValueType="System.String" OnSelectedIndexChanged="acmbPForms_SelectedIndexChanged" AutoPostBack ="true">
                                    </dx:ASPxComboBox>
                                </td>
                                <td>
                                    <asp:Button ID="btnPCatQuery" runat="server" Text="Sorgula" OnClick="btnPCatQuery_Click" Style="cursor: pointer;" />
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td colspan="9">
                        <dx:ASPxGridView ID="grdPCategoryPointView" runat="server" CssFilePath="~/App_Themes/BlackGlass/{0}/styles.css"
                            CssPostfix="BlackGlass" ClientInstanceName="gridView2" AutoGenerateColumns="true"
                            Width="100%" DataSourceID="odsPoint">
                            <SettingsPager AlwaysShowPager="true" />
                            <Settings ShowFilterRow="True" />
                            <Images ImageFolder="~/App_Themes/BlackGlass/{0}/" />
                            <Styles CssPostfix="BlackGlass" CssFilePath="~/App_Themes/BlackGlass/{0}/styles.css">
                                <Header SortingImageSpacing="5px" ImageSpacing="5px" />
                                <AlternatingRow BackColor="#EFF3FB" />
                            </Styles>
                        </dx:ASPxGridView>

                        <asp:ObjectDataSource ID="odsPoint" runat="server" SortParameterName="sortColumns" EnablePaging="True" 
                            StartRowIndexParameterName="startRecord" MaximumRowsParameterName="maxRecords"
                            SelectCountMethod="GetCategoryPoints" SelectMethod="GetCategoryPointsByFilters" 
                            TypeName="EvaluationAssistt.Service.Services.EvaluationReportingService" 
                            UpdateMethod="GetCategoryPointsByFilters">
                            <SelectParameters>
                                <asp:Parameter DefaultValue="" Name="startDate" Type="DateTime" />
                                <asp:Parameter DefaultValue="" Name="endDate" Type="DateTime" />
                                <asp:Parameter Name="startRecord" Type="Int32" />
                                <asp:Parameter Name="maxRecords" Type="Int32" />
                                <asp:Parameter Name="sortColumns" Type="String" />
                                <asp:Parameter Name="reporterId" Type="String" />
                                <asp:Parameter Name="formId" Type="String" />
                                <asp:Parameter Name="isAdmQ" Type="Boolean" />
                            </SelectParameters>
                            <UpdateParameters>
                                <asp:Parameter Name="startDate" Type="DateTime" />
                                <asp:Parameter Name="endDate" Type="DateTime" />
                                <asp:Parameter Name="startRecord" Type="Int32" />
                                <asp:Parameter Name="maxRecords" Type="Int32" />
                                <asp:Parameter Name="sortColumns" Type="String" />
                                <asp:Parameter Name="reporterId" Type="String" />
                                <asp:Parameter Name="formId" Type="String" />
                                <asp:Parameter Name="isAdmQ" Type="Boolean" />
                            </UpdateParameters>
                        </asp:ObjectDataSource>

                        <asp:HiddenField ID="HiddenField3" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td colspan="8" style="text-align: right;">Export:</td>
                    <td>
                        <asp:Button ID="btnExportP3" runat="server" Text="Xlsx" OnClick="btnExportP3_Click" />
                        <asp:Button ID="btnExportPdfP3" runat="server" Text="Pdf" OnClick="btnExportPdfP3_Click" />
                        <asp:Button ID="btnExportRtfP3" runat="server" Text="Rtf" OnClick="btnExportRtfP3_Click" />
                        <asp:Button ID="btnExportCsvP3" runat="server" Text="Csv" OnClick="btnExportCsvP3_Click" />
                    </td>
                </tr>
            </table>


        </div>
        <dx:ASPxGridViewExporter ID="ASPxGridViewExporter1" runat="server">
        </dx:ASPxGridViewExporter>
        &nbsp;
    </form>
</body>
</html>
