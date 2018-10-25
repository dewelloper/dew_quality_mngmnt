<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="AgentManagement.aspx.cs" Inherits="EvaluationAssistt.Web.Pages.AgentManagement" %>

<%@ Register Assembly="DevExpress.Web.v14.2, Version=14.2.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>



<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="/Scripts/Custom/EntryOperations.js"></script>
    <script type="text/javascript">

        var admin = new Array(1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19);
        var quality_expert = new Array(2, 3, 4, 5, 6, 7, 9, 11, 12, 13, 14, 15, 16, 17, 18);
        var group_leader = new Array(2, 9, 11, 12, 13, 15, 16, 19);
        var team_leader = new Array(2, 9, 11, 12, 13, 15, 16);
        var agent = new Array(9, 11, 12, 13, 16);

        var arr = new Array(null, admin, quality_expert, group_leader, team_leader, agent);

        function SetPages(s, e) {
            var agentTypeId = s.GetValue();

            var list = arr[agentTypeId];

            lstboxPagesAgents.UnselectAll();
            lstboxPagesAgents.SelectValues(list);
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="server">
    <div class="g_6 contents_header">
        <h3 class="i_16_forms tab_label">K.Y.</h3>
    </div>
    <%--<div class="g_6 contents_options">
        <div class="simple_buttons">
            <div class="bwIcon i_16_help">
                <a href="Help.aspx#3_14" target="_blank"><span class="label">Yardim</span></a>
            </div>
        </div>
        <div class="simple_buttons">
            <div class="bwIcon i_16_settings">
                Araclar
            </div>
            <div class="buttons_arrow">
                <!-- Drop Menu -->
                <ul class="drop_menu menu_with_icons right_direction">
                    <li><a class="i_16_up" href="javascript:void(0)" onclick="HideAll();" title="Tum Sekmeleri Kapat">
                        <span class="label">Tumunu Gizle</span> </a></li>
                    <li><a class="i_16_down" href="javascript:void(0)" onclick="ShowAll();" title="Tum Sekmeleri Ac">
                        <span class="label">Tumunu Goster</span> </a></li>
                    <li><a class="i_16_pages" href="javascript:void(0)" onclick="BookmarkPage();" title="Sayfayi Sik Kullanilanlara Ekle">
                        <span class="label">Favorilere Ekle</span> </a></li>
                    <li><a class="i_16_add" href="TeamManagement.aspx" title="Yeni Takim Ekle">
                        <span class="label">Yeni Takim</span> </a></li>
                </ul>
            </div>
        </div>
    </div>--%>
    <asp:Panel ID="pnlRegister" CssClass="pnlRegister" runat="server" Visible="false">
        <div class="g_12 separator">
            
        </div>
        <div class="g_12">
            <div class="widget_header">
                <h4 class="widget_header_title wwIcon i_16_forms">Yeni Kullanici</h4>
            </div>
            <div class="widget_contents noPadding">
                <div class="line_grid">
                    <div class="g_3">
                        <table cellpadding="5" cellspacing="5" width="100%">
                            <tr>
                                <td class="lbl"><span class="label">Ad</span></td>
                                <td><span class="label">:</span></td>
                                <td>
                                    <asp:TextBox ID="txtFirstName" runat="server" />
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="required_txtFirstName" ControlToValidate="txtFirstName"
                                        runat="server" ValidationGroup="Register"></asp:RequiredFieldValidator>
                                </td>

                                <td class="lbl"><span class="label">Soyad</span></td>
                                <td><span class="label">:</span></td>
                                <td>
                                    <asp:TextBox ID="txtLastName" runat="server" /></td>
                                <td>
                                    <asp:RequiredFieldValidator ID="required_txtLastName" ControlToValidate="txtLastName"
                                        runat="server" ValidationGroup="Register"></asp:RequiredFieldValidator></td>
                                <td>
                                    <span class="label">Rol</span>
                                </td>
                                <td>
                                    <span class="label">:</span>
                                </td>
                                <td>
                                    <dx:ASPxComboBox ID="cmbAgentTypes" runat="server" ValueType="System.Int32">
                                        <ClientSideEvents SelectedIndexChanged="function(s,e){ SetPages(s,e); }" />
                                    </dx:ASPxComboBox>
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="required_cmbAgentTypes" ControlToValidate="cmbAgentTypes"
                                        runat="server" InitialValue="" ValidationGroup="Register">
                                    </asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td class="lbl"><span class="label">Login ID</span></td>
                                <td><span class="label">:</span></td>
                                <td>
                                    <asp:TextBox ID="txtLoginId" runat="server" />
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="required_txtLoginId" ControlToValidate="txtLoginId"
                                        runat="server" ValidationGroup="Register"></asp:RequiredFieldValidator></td>
                                <td class="lbl"><span class="label">IPPhone </span></td>
                                <td><span class="label">:</span></td>
                                <td>
                                    <asp:TextBox ID="txtRegisterNumber" runat="server" /></td>
                                <td>
                                    <asp:RequiredFieldValidator ID="required_txtRegisterNumber" ControlToValidate="txtRegisterNumber"
                                        runat="server" ValidationGroup="Register"></asp:RequiredFieldValidator></td>
                                <td rowspan="3" colspan="3" valign="top">
                                    <dx:ASPxListBox ID="lstboxPagesAgents" ClientInstanceName="lstboxPagesAgents" runat="server" ValueType="System.Int32" SelectionMode="CheckColumn" Width="100%" Height="145px"></dx:ASPxListBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="lbl"><span class="label">Takim</span></td>
                                <td><span class="label">:</span></td>
                                <td colspan="5">
                                    <dx:ASPxComboBox ID="cmbTeam" runat="server" ValueType="System.Int32" IncrementalFilteringMode="Contains" Width="100%">
                                    </dx:ASPxComboBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="label">
                                    <span class="label">Tüm Çağrılara Yetkili</span>
                                </td>
                                <td><span class="label">:</span></td>
                                <td colspan="5">
                                    <input type="checkbox" id="cbAllGroupsAccess" runat="server" />
                                    <span class="label">Evet</span>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="8">
                                    <br />
                                    <br />
                                    <asp:Button ID="btnSave" Text="Kaydet" ValidationGroup="Register" runat="server" OnClick="btnSave_Click"
                                        PostBackUrl="/Pages/AgentManagement.aspx" />
                                    &nbsp;<input type="button" value="Temizle" onclick="javascript: ClearControls('pnlRegister');" />
                                    <asp:Button ID="btnCancel" Text="İptal" runat="server" PostBackUrl="~/Pages/AgentManagement.aspx" OnClick="btnClear_Click" />
                                    &nbsp;<asp:Button ID="btnTransfer" runat="server" ToolTip="Seçili olan kullanıcıyı seçili olan takıma transfer eder..." OnClick="btnTransfer_Click" PostBackUrl="~/Pages/AgentManagement.aspx" Text="Transfer et" />
                                </td>
                            </tr>
                        </table>
                    </div>
                </div>
            </div>
        </div>
    </asp:Panel>
    <div class="g_12">
        <asp:Button ID="btnNew" Text="Yeni" runat="server" OnClick="btnNew_Click" />
    </div>
    <div class="g_12 separator">
        
    </div>
    <asp:Panel ID="pnlList" runat="server">
        <div class="g_12">
            <div class="widget_header">
                <h4 class="widget_header_title wwIcon i_16_forms">Kullanici Listesi</h4>
            </div>
            <div class="widget_contents noPadding">
                <div class="line_grid">
                    <div class="g_3">
                        <dx:ASPxGridView ID="gridviewAgents" runat="server" ClientInstanceName="gridviewAgents" KeyFieldName="Id">
                            <Columns>
                                <dx:GridViewDataColumn Caption="" FixedStyle="Left" Width="90px">
                                    <DataItemTemplate>
                                        <asp:ImageButton ID="imgEdit" style="width:16px; height:16px;"  PostBackUrl='<%#Eval("Id", "/Pages/AgentManagement.aspx?Id={0}") %>'
                                            ImageUrl="~/Contents/Images/Icons/16/i_16_edit.png" runat="server" />
                                        <img class="imgButton" alt="" onclick="javascript:EntryDelete('<%#Eval("Id") %>', '<%#Eval("FullName") %>', 'agent', this, '/Pages/AgentManagement.aspx/DeleteAgent');"
                                            src="/Contents/Images/Icons/16/i_16_delete.png" />
                                        <img class="imgButton" alt="Personel İstifa ve Geri alım" onclick="javascript:EntryResignation('<%#Eval("Id") %>', '<%#Eval("FullName") %>', 'agent', this, '/Pages/AgentManagement.aspx/ResignationAgent');"
                                            src="/Contents/Images/Icons/16/i_16_settings.png" />
                                    </DataItemTemplate>
                                </dx:GridViewDataColumn>
                                <dx:GridViewDataTextColumn Caption="Ad" FieldName="FirstName">
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn Caption="Soyad" FieldName="LastName">
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn Caption="unvan" FieldName="AgentTypeName">
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn Caption="Sicil No" FieldName="RegisterNumber" Width="100px" Visible="false">
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn Caption="Takim" FieldName="TeamName">
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn Caption="Grup" FieldName="GroupName">
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn Caption="Lokasyon" FieldName="LocationName">
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn Caption="Pasifmi" FieldName="Resignation">
                                </dx:GridViewDataTextColumn>
                            </Columns>
                        </dx:ASPxGridView>
                    </div>
                </div>
            </div>
        </div>
    </asp:Panel>
</asp:Content>
