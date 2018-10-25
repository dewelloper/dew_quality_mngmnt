<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdminQualityReports.aspx.cs" Inherits="EvaluationAssistt.Web.Pages.AdminQualityReports" %>

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
                                    <dx:ASPxDateEdit ID="aspxDateStart3" runat="server" AllowNull="False" EditFormat="DateTime" DateOnError="Today">
                                    </dx:ASPxDateEdit>
                                </td>
                                <td>Bitiş Tarihi</td>
                                <td>
                                    <dx:ASPxDateEdit ID="aspxDateEnd3" runat="server" AllowNull="False" EditFormat="DateTime" DateOnError="Today">
                                    </dx:ASPxDateEdit>
                                </td>
                                <td>Agentlar</td>
                                <td>
                                    <dx:ASPxComboBox ID="cmbAgents" runat="server">
                                    </dx:ASPxComboBox>
                                </td>
                                <td>Formlar</td>
                                <td>
                                    <dx:ASPxComboBox ID="cmbForms" runat="server" ValueType="System.String">
                                    </dx:ASPxComboBox>
                                </td>
                                <td>
                                    <asp:Button ID="btnAKQuery" runat="server" Text="Sorgula" OnClick="btnAKQuery_Click" style="cursor:pointer;" />
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
                        <dx:ASPxGridView ID="grdAKView" runat="server" CssFilePath="~/App_Themes/BlackGlass/{0}/styles.css"
                            CssPostfix="BlackGlass" ClientInstanceName="gridView2"
                            Width="100%" DataSourceID="ods3" AutoGenerateColumns="False">
                            <ClientSideEvents CustomButtonClick="function(s, e) {
		                                gridView2.GetSelectedFieldValues('Id', OnGridSelectionComplete);
                                }" />               
                            <Columns>
<%--                                <dx:GridViewDataTextColumn FieldName="AgentId" VisibleIndex="0">
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn FieldName="AgentName" VisibleIndex="1">
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn FieldName="FormId" VisibleIndex="2">
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn FieldName="FormNAme" VisibleIndex="3">
                                </dx:GridViewDataTextColumn>--%>
                                <dx:GridViewDataTextColumn FieldName="Question" Caption="Soru" VisibleIndex="4" CellStyle-Wrap="True" CellStyle-HorizontalAlign="Left">
                                    <HeaderStyle Border-BorderColor="Black" Border-BorderWidth="1px" BackColor="#0A0A2A" Paddings-PaddingTop="10px" />
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn FieldName="Quantity" Caption="Adet" VisibleIndex="5" CellStyle-Wrap="True">
                                    <HeaderStyle Border-BorderColor="Black" Border-BorderWidth="1px" BackColor="#0A0A2A" Paddings-PaddingTop="10px" />
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn FieldName="Point" Caption="Puan" VisibleIndex="6" CellStyle-Wrap="True">
                                    <HeaderStyle Border-BorderColor="Black" Border-BorderWidth="1px" BackColor="#0A0A2A" Paddings-PaddingTop="10px" />
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn FieldName="Percent" Caption="Yüzde" VisibleIndex="7" CellStyle-Wrap="True">
                                    <HeaderStyle Border-BorderColor="Black" Border-BorderWidth="1px" BackColor="#0A0A2A" Paddings-PaddingTop="10px" />
                                </dx:GridViewDataTextColumn>
<%--                                <dx:GridViewDataTextColumn FieldName="QId" VisibleIndex="8">
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn FieldName="AId" VisibleIndex="9">
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn FieldName="FormScore" VisibleIndex="10">
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn FieldName="AnswerScore" VisibleIndex="11">
                                </dx:GridViewDataTextColumn>--%>
                            </Columns>
                            <SettingsPager AlwaysShowPager="true" />
                            <Images ImageFolder="~/App_Themes/BlackGlass/{0}/" />
                            <Styles CssPostfix="BlackGlass" CssFilePath="~/App_Themes/BlackGlass/{0}/styles.css">
                                <Header SortingImageSpacing="5px" ImageSpacing="5px" />
                                <AlternatingRow BackColor="#EFF3FB" />
                            </Styles>
                        </dx:ASPxGridView>

                        <asp:ObjectDataSource ID="ods3" runat="server" SortParameterName="sortColumns" EnablePaging="True"
                            StartRowIndexParameterName="startRecord" MaximumRowsParameterName="maxRecords"
                            SelectCountMethod="GetPeopleCount" SelectMethod="GetAnswerPerPercentsByFilter" TypeName="EvaluationAssistt.Service.Services.EvaluationReportingService" UpdateMethod="GetAnswerPerPercentsByFilter">
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
                        <asp:Button ID="btnExport3" runat="server" Text="Xlsx" OnClick="btnExport3_Click" />
                        <asp:Button ID="btnExportPdf3" runat="server" Text="Pdf" OnClick="btnExportPdf3_Click" />
                        <asp:Button ID="btnExportRtf3" runat="server" Text="Rtf" OnClick="btnExportRtf3_Click" />
                        <asp:Button ID="btnExportCsv3" runat="server" Text="Csv" OnClick="btnExportCsv3_Click" />
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
