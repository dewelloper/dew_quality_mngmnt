<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="OutCallReports.aspx.cs" Inherits="EvaluationAssistt.Web.Pages.OutCallReports" %>
<%@ Register Assembly="DevExpress.Web.v14.2, Version=14.2.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>




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
                        <asp:CheckBox ID="chkQualityAdminAgent" runat="server" Text="Kalite Uzmanı ve Admin Grubunda Filitrele" />
                    </td>
                </tr>
                <tr>
                    <td colspan="9">
                        <table>
                            <tr>
                                <td>Başlangıç Tarihi</td>
                                <td>
                                    <dx:ASPxDateEdit ID="axdcStartDate" runat="server" AllowNull="False" EditFormat="DateTime" DateOnError="Today">
                                    </dx:ASPxDateEdit>
                                </td>
                                <td>Bitiş Tarihi</td>
                                <td>
                                    <dx:ASPxDateEdit ID="axdcEndDate" runat="server" AllowNull="False" EditFormat="DateTime" DateOnError="Today">
                                    </dx:ASPxDateEdit>
                                </td>
                                <td>Formlar</td>
                                <td>
                                    <dx:ASPxComboBox ID="acmbcForms" runat="server" ValueType="System.String">
                                    </dx:ASPxComboBox>
                                </td>
                                <td>
                                    <asp:Button ID="btncCatQuery" runat="server" Text="Sorgula" OnClick="btnCatQuery_Click" Style="cursor: pointer;" />
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
                        <dx:ASPxGridView ID="grdcCategoryView" runat="server" CssFilePath="~/App_Themes/BlackGlass/{0}/styles.css"
                            CssPostfix="BlackGlass" ClientInstanceName="gridView2"
                            Width="100%" DataSourceID="odsc4" AutoGenerateColumns="False">
                            <ClientSideEvents CustomButtonClick="function(s, e) {
		                                gridView2.GetSelectedFieldValues('Id', OnGridSelectionComplete);
                                }" />
                            <Columns>
                                <dx:GridViewDataTextColumn FieldName="QuestionName" Caption="Soru Adı" VisibleIndex="1" CellStyle-Wrap="True" CellStyle-HorizontalAlign="Left">
                                    <HeaderStyle Border-BorderColor="Black" Border-BorderWidth="1px" BackColor="#0A0A2A" Paddings-PaddingTop="10px" />
                                    <CellStyle HorizontalAlign="Left" Wrap="True"></CellStyle>
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn FieldName="Quantity" Caption="Değerlendirme Sayısı" VisibleIndex="2" CellStyle-Wrap="True">
                                    <HeaderStyle Border-BorderColor="Black" Border-BorderWidth="1px" BackColor="#0A0A2A" Paddings-PaddingTop="10px" />
                                    <CellStyle Wrap="True"></CellStyle>
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn FieldName="MaxPoint" Caption="Maksimum Puan" VisibleIndex="3" CellStyle-Wrap="True">
                                    <HeaderStyle Border-BorderColor="Black" Border-BorderWidth="1px" BackColor="#0A0A2A" Paddings-PaddingTop="10px" />
                                    <CellStyle Wrap="True"></CellStyle>
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn FieldName="MiddlePoint" Caption="Ortalama Puan" VisibleIndex="4" CellStyle-Wrap="True">
                                    <HeaderStyle Border-BorderColor="Black" Border-BorderWidth="1px" BackColor="#0A0A2A" Paddings-PaddingTop="10px" />
                                    <CellStyle Wrap="True"></CellStyle>
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn FieldName="Percent" Caption="Yüzde" VisibleIndex="5" CellStyle-Wrap="True">
                                    <HeaderStyle Border-BorderColor="Black" Border-BorderWidth="1px" BackColor="#0A0A2A" Paddings-PaddingTop="10px" />
                                    <CellStyle Wrap="True"></CellStyle>
                                </dx:GridViewDataTextColumn>
                            </Columns>
                            <SettingsPager AlwaysShowPager="true" />
                            <Settings ShowFilterRow="True" />
                            <Images ImageFolder="~/App_Themes/BlackGlass/{0}/" />
                            <Styles CssPostfix="BlackGlass" CssFilePath="~/App_Themes/BlackGlass/{0}/styles.css">
                                <Header SortingImageSpacing="5px" ImageSpacing="5px" />
                                <AlternatingRow BackColor="#EFF3FB" />
                            </Styles>
                        </dx:ASPxGridView>

                        <asp:ObjectDataSource ID="odsc4" runat="server" SortParameterName="sortColumns" EnablePaging="True"
                            StartRowIndexParameterName="startRecord" MaximumRowsParameterName="maxRecords"
                            SelectCountMethod="GetPeopleCount" SelectMethod="GetCategoriesByFiltersOutCalls" TypeName="EvaluationAssistt.Service.Services.EvaluationReportingService" UpdateMethod="GetCategoriesByFiltersOutCalls">
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
                        <asp:Button ID="btncExport3" runat="server" Text="Xlsx" OnClick="btncExport3_Click" />
                        <asp:Button ID="btncExportPdf3" runat="server" Text="Pdf" OnClick="btncExportPdf3_Click" />
                        <asp:Button ID="btncExportRtf3" runat="server" Text="Rtf" OnClick="btncExportRtf3_Click" />
                        <asp:Button ID="btncExportCsv3" runat="server" Text="Csv" OnClick="btncExportCsv3_Click" />
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
