<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AgentMonthlyPointsReports.aspx.cs" Inherits="EvaluationAssistt.Web.Pages.AgentMonthlyPointsReports" %>

<%@ Register Assembly="DevExpress.Web.v14.2, Version=14.2.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>

<%@ Register Assembly="DevExpress.XtraReports.v14.2.Web, Version=14.2.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.XtraReports.Web" TagPrefix="dx" %>

<%@ Register Assembly="DevExpress.Web.v14.2, Version=14.2.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web" TagPrefix="dxe" %>
<%@ Register Assembly="DevExpress.XtraReports.v14.2.Web, Version=14.2.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.XtraReports.Web" TagPrefix="dxxr" %>
<%@ Register Assembly="DevExpress.Web.v14.2, Version=14.2.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web" TagPrefix="dxpc" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table>
                <tr>
                    <td colspan="9">
                        <asp:CheckBox ID="chkQualityAdmin" runat="server" Text="Kalite Uzmanı ve Admin Grubunda Filitrele" />
                    </td>
                </tr>
                <tr>
                    <td colspan="9">
                        <table>
                            <tr>
                                <td>Başlangıç Tarihi</td>
                                <td>
                                    <dx:ASPxDateEdit ID="aspxtDateStart3" runat="server" AllowNull="False" EditFormat="DateTime" DateOnError="Today">
                                    </dx:ASPxDateEdit>
                                </td>
                                <td>Bitiş Tarihi</td>
                                <td>
                                    <dx:ASPxDateEdit ID="aspxtDateEnd3" runat="server" AllowNull="False" EditFormat="DateTime" DateOnError="Today">
                                    </dx:ASPxDateEdit>
                                </td>
                                <td>Agentlar</td>
                                <td>
                                    <dx:ASPxComboBox ID="cmbtAgents" runat="server">
                                    </dx:ASPxComboBox>
                                </td>
                                <td>Formlar</td>
                                <td>
                                    <dx:ASPxComboBox ID="cmbtForms" runat="server" ValueType="System.String">
                                    </dx:ASPxComboBox>
                                </td>
                                <td>
                                    <asp:Button ID="btntAKQuery" runat="server" Text="Sorgula" OnClick="btntAKQuery_Click" style="cursor:pointer;" />
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
                        <dx:ASPxGridView ID="grdtAKView" runat="server" CssFilePath="~/App_Themes/BlackGlass/{0}/styles.css"
                            CssPostfix="BlackGlass" ClientInstanceName="gridView2"
                            Width="100%" DataSourceID="ods3" AutoGenerateColumns="true">
                            <ClientSideEvents CustomButtonClick="function(s, e) {
		                                gridView2.GetSelectedFieldValues('Id', OnGridSelectionComplete);
                                }" />               
                            <SettingsPager AlwaysShowPager="true" />
                            <Images ImageFolder="~/App_Themes/BlackGlass/{0}/" />
                            <Styles CssPostfix="BlackGlass" CssFilePath="~/App_Themes/BlackGlass/{0}/styles.css">
                                <Header SortingImageSpacing="5px" ImageSpacing="5px" />
                                <AlternatingRow BackColor="#EFF3FB" />
                            </Styles>
                        </dx:ASPxGridView>

                        <asp:ObjectDataSource ID="ods3" runat="server" SortParameterName="sortColumns" EnablePaging="True"
                            StartRowIndexParameterName="startRecord" MaximumRowsParameterName="maxRecords"
                            SelectCountMethod="GetPeopleCount" SelectMethod="GetAgentsPointsByMonthly" TypeName="EvaluationAssistt.Service.Services.EvaluationReportingService" UpdateMethod="GetAgentsPointsByMonthly">
                            <SelectParameters>
                                <asp:Parameter DefaultValue="" Name="startDate" Type="DateTime" />
                                <asp:Parameter DefaultValue="" Name="endDate" Type="DateTime" />
                                <asp:Parameter Name="startRecord" Type="Int32" />
                                <asp:Parameter Name="maxRecords" Type="Int32" />
                                <asp:Parameter Name="sortColumns" Type="String" />
                                <asp:Parameter Name="reporterId" Type="String" />
                                <asp:Parameter Name="selectedAgentId" Type="String" />
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
                                <asp:Parameter Name="selectedAgentId" Type="String" />
                                <asp:Parameter Name="formId" Type="String" />
                                <asp:Parameter Name="isAdmQ" Type="Boolean" />
                            </UpdateParameters>
                        </asp:ObjectDataSource>

                        <asp:HiddenField ID="HiddenField3" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td colspan="8" style="text-align:right;">
                        Export:</td>
                    <td>
                        <asp:Button ID="btntExport3" runat="server" Text="Xlsx" OnClick="btntExport3_Click" />
                        <asp:Button ID="btntExportPdf3" runat="server" Text="Pdf" OnClick="btntExportPdf3_Click" />
                        <asp:Button ID="btntExportRtf3" runat="server" Text="Rtf" OnClick="btntExportRtf3_Click" />
                        <asp:Button ID="btntExportCsv3" runat="server" Text="Csv" OnClick="btntExportCsv3_Click" />
                    </td>
                </tr>
            </table>


        </div>
        <br />
        <dx:ASPxGridViewExporter ID="ASPxGridViewExporter3" runat="server">
        </dx:ASPxGridViewExporter>
    </form>
</body>
</html>
