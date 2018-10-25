<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="QuestionManagement.aspx.cs" Inherits="EvaluationAssistt.Web.Pages.QuestionManagement" %>

<%@ Register Assembly="DevExpress.Web.v14.2, Version=14.2.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>

<%@ Import Namespace="EvaluationAssistt.Infrastructure.Helpers" %>





<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="/Scripts/Custom/EntryOperations.js" type="text/javascript"></script>
    <script type="text/javascript" language="javascript">
        function ClearInputs() {
            $("#txtAnswerText").val("");
            $("#txtScore").val("");
            $("#cbDefaultAnswer").removeAttr("checked");
            $("#txtAnswerText").focus();
            $("#btnRemoveAnswer").css("display", "none");
            $("#btnCancelAnswer").css("display", "none");
        }
        function AddNewAnswer() {
            var index = lstboxAnswers.GetSelectedIndex();
            var btn = $("#btnAddNewAnswer").val();
            var answerText = $("#txtAnswerText").val();
            var score = $("#txtScore").val();
            var isDefault = $("#cbDefaultAnswer").attr("checked") == "checked";
            if (answerText.trim() == "" || score.trim() == "")
                return false;
            var count = parseInt(lstboxAnswers.GetItemCount());
            var result = answerText + " - " + score + " puan";

            if (isDefault) {
                for (var i = 0; i < count; i++) {
                    var li = lstboxAnswers.GetItem(i);
                    var text = li.text.replace(" (Varsayılan)", "");
                    var value = li.value;
                    lstboxAnswers.RemoveItem(i);
                    lstboxAnswers.InsertItem(i, text, value, '/Contents/Images/Icons/16/i_16_edit.png');
                }
                result += " (Varsayılan)";
            }

            if (btn == "Yeni Cevap Ekle") {
                lstboxAnswers.AddItem(result, score, '/Contents/Images/Icons/16/i_16_edit.png');
                ClearInputs();
            }
            else {
                lstboxAnswers.RemoveItem(index);
                lstboxAnswers.InsertItem(index, result, score, '/Contents/Images/Icons/16/i_16_edit.png');
                lstboxAnswers.SetSelectedIndex(-1);
                $("#btnAddNewAnswer").val("Yeni Cevap Ekle");
                ClearInputs();
            }
        }
        function RemoveAnswer() {
            var selectedIndex = lstboxAnswers.GetSelectedIndex();
            lstboxAnswers.RemoveItem(selectedIndex);
        }
        function EditAnswer(s, e) {
            var answerText = s.GetSelectedItem().text.split("-")[0].trim();
            var answerOptions = s.GetSelectedItem().text.split("-")[1].trim();
            var score = s.GetSelectedItem().value;

            if (answerOptions.indexOf("Varsayılan") !== -1)
                $("#cbDefaultAnswer").attr("checked", "checked");
            else
                $("#cbDefaultAnswer").removeAttr("checked");

            $("#txtAnswerText").val(answerText);
            $("#txtScore").val(score);
            $("#btnAddNewAnswer").val("Cevabı Düzenle");
            $("#btnRemoveAnswer").css("display", "inline");
            $("#btnCancelAnswer").css("display", "inline");
        }
        function CancelAnswer() {
            lstboxAnswers.SetSelectedIndex(-1);
            $("#btnAddNewAnswer").val("Yeni Cevap Ekle");
            ClearInputs();
        }
        function AddNewAnswerKey(event) {
            if (event.keyCode == 13) {
                $("#btnAddNewAnswer").click();
                return false;
            }
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="server">
    <div class="g_6 contents_header">
        <h3 class="i_16_forms tab_label">Soru Yönetimi</h3>
    </div>
    <div class="g_6 contents_options">
        <div class="simple_buttons">
            <div class="bwIcon i_16_help">
                <a href="Help.aspx#3_6" target="_blank"><span class="label">Yardım</span></a>
            </div>
        </div>
        <div class="simple_buttons">
            <div class="bwIcon i_16_settings">
                Araçlar
            </div>
            <div class="buttons_arrow">
                <!-- Drop Menu -->
                <ul class="drop_menu menu_with_icons right_direction">
                    <li><a class="i_16_up" href="javascript:void(0)" onclick="HideAll();" title="Tüm Sekmeleri Kapat">
                        <span class="label">Tümünü Gizle</span> </a></li>
                    <li><a class="i_16_down" href="javascript:void(0)" onclick="ShowAll();" title="Tüm Sekmeleri Aç">
                        <span class="label">Tümünü Göster</span> </a></li>
                    <li><a class="i_16_pages" href="javascript:void(0)" onclick="BookmarkPage();" title="Sayfayı Sık Kullanılanlara Ekle">
                        <span class="label">Favorilere Ekle</span> </a></li>
                    <li><a class="i_16_add" href="CategoryManagement.aspx" title="Yeni Kategori Ekle">
                        <span class="label">Yeni Kategori</span> </a></li>
                    <li><a class="i_16_settings_small" href="CategoryQuestionsManagement.aspx" title="Kategori - Soru Eşleştirme" style="width: 150px;">
                        <span class="label">Kategori - Soru Eşleştirme</span></a></li>
                </ul>
            </div>
        </div>
    </div>
    <asp:Panel ID="pnlRegister" runat="server" Visible="false" DefaultButton="">
        <div class="g_12 separator">
            
        </div>
        <div class="g_12">
            <div class="widget_header">
                <h4 class="widget_header_title wwIcon i_16_forms">Yeni Soru</h4>
            </div>
            <div class="widget_contents noPadding">
                <div class="line_grid">
                    <div class="g_3" style="width: 100%">
                        <table class="simple_table" cellpadding="5" cellspacing="5" style="width: 100%">
                            <tr>
                                <td class="lbl"><span class="label">Soru Metni</span></td>
                                <td><span class="label" style="width: 100%">:</span></td>
                                <td>
                                    <asp:TextBox ID="txtQuestionText" runat="server" EnableTheming="false" CssClass="simple_field" Width="100%" />
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="required_txtQuestionText" ControlToValidate="txtQuestionText"
                                        runat="server" ValidationGroup="Register"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                        </table>
                    </div>
                    <div style="clear: both" />
                    <div class="g_3">
                        <table class="simple_table" cellpadding="5" cellspacing="5">
                            <tr>
                                <td class="lbl"><span class="label">Çoklu Cevap</span></td>
                                <td><span class="label">:</span></td>
                                <td>
                                    <input type="checkbox" id="cbHasMultipleAnswers" runat="server" />
                                    <span class="label">Evet</span>
                                </td>
                                <td></td>
                            </tr>
                            <tr>
                                <td class="lbl"><span class="label">Puanı Görünür</span></td>
                                <td><span class="label">:</span></td>
                                <td>
                                    <input type="checkbox" id="cbHasVisibleScore" runat="server" />
                                    <span class="label">Evet</span>
                                </td>
                                <td></td>
                            </tr>
                        </table>
                    </div>
                    <div class="g_3">
                        <table class="simple_table" cellpadding="5" cellspacing="5">
                            <tr>
                                <td class="lbl"><span class="label">Açıklama Alanı</span></td>
                                <td><span class="label">:</span></td>
                                <td>
                                    <input type="checkbox" id="cbHasComment" runat="server" />
                                    <span class="label">Evet</span>
                                </td>
                                <td></td>
                            </tr>
                            <tr>
                                <td class="lbl" style="width: 120px;">
                                    <span class="label">Açıklama Zorunlu</span>
                                </td>
                                <td class="label">:</td>
                                <td>
                                    <input type="checkbox" id="cbRequiresComment" runat="server" />
                                    <span class="label">Evet</span>
                                </td>
                                <td></td>
                            </tr>
                        </table>
                    </div>
                    <div style="clear: both" />
                    <div style="width: 100%">
                        <div style="float: left; width: 80%">
                            <span class="label">Cevap Metni :</span>
                            <br />
                            <input type="text" id="txtAnswerText" style="width: 95%" class="simple_field" onkeydown="return AddNewAnswerKey(event);" />
                        </div>
                        <div style="float: left; width: 10%">
                            <span class="label">Puanı :</span>
                            <br />
                            <input type="text" id="txtScore" style="width: 50px" class="simple_field" onkeydown="return AddNewAnswerKey(event);" />
                        </div>
                        <div style="float: left; width: 10%">
                            <span class="label">Varsayılan :</span>
                            <br />
                            <input type="checkbox" id="cbDefaultAnswer" style="height: 28px; width: 28px;" />
                        </div>
                        <div style="clear: both;"></div>
                        <div style="margin-top: 20px;">
                            <input id="btnAddNewAnswer" type="button" value="Yeni Cevap Ekle" onclick="AddNewAnswer();" />
                            <input id="btnRemoveAnswer" type="button" value="Seçili Cevabı Sil" onclick="RemoveAnswer();" style="display: none;" />
                            <input id="btnCancelAnswer" type="button" value="İptal" onclick="CancelAnswer();" style="display: none;" />
                        </div>
                        <br />
                        <br />
                        <dx:ASPxListBox ID="lstboxAnswers" ClientInstanceName="lstboxAnswers" runat="server" Width="100%" Border-BorderStyle="None" ValueType="System.Int32">
                            <ClientSideEvents SelectedIndexChanged="function(s,e){EditAnswer(s,e);}" />
                            <ItemStyle Cursor="pointer" />
                            <Border BorderStyle="None" />
                        </dx:ASPxListBox>
                        <br />
                        <br />
                        <asp:Button ID="btnSave" Text="Kaydet" ValidationGroup="Register" runat="server" OnClick="btnSave_Click" PostBackUrl="~/Pages/QuestionManagement.aspx" />
                        <asp:Button ID="btnCancel" Text="İptal" runat="server" OnClick="btnClear_Click" PostBackUrl="~/Pages/QuestionManagement.aspx" />
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
                <h4 class="widget_header_title wwIcon i_16_forms">Soru Listesi</h4>
            </div>
            <div class="widget_contents noPadding">
                <div class="line_grid">
                    <div class="g_3">
                        <dx:ASPxGridView ID="gridviewQuestions" runat="server" ClientInstanceName="gridviewQuestions" KeyFieldName="Id">
                            <Columns>
                                <dx:GridViewDataColumn Caption="" FixedStyle="Left" Width="60px">
                                    <DataItemTemplate>
                                        <asp:ImageButton ID="imgEdit" style="width:16px; height:16px;" PostBackUrl='<%#Eval("Id", "/Pages/QuestionManagement.aspx?Id={0}") %>'
                                            ImageUrl="~/Contents/Images/Icons/16/i_16_edit.png" runat="server" />
                                        <img class="imgButton" alt="" onclick="javascript:EntryDelete('<%#Eval("Id") %>', '<%# HtmlHelper.TruncateString(Eval("QuestionText")) %>', 'soru', this, '/Pages/QuestionManagement.aspx/DeleteQuestion');"
                                            src="/Contents/Images/Icons/16/i_16_delete.png" />
                                    </DataItemTemplate>
                                </dx:GridViewDataColumn>
                                <dx:GridViewDataTextColumn Caption="Soru Metni" FieldName="QuestionText">
                                    <DataItemTemplate>
                                        <span title='<%#Eval("QuestionText") %>'><%# HtmlHelper.TruncateString(Eval("QuestionText")) %></span>
                                    </DataItemTemplate>
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn Caption="Açıklama Alanı" FieldName="HasComment" Width="100px">
                                    <DataItemTemplate>
                                        <%# HtmlHelper.TrueFalseIcon(Convert.ToBoolean(Eval("HasComment"))) %>
                                    </DataItemTemplate>
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn Caption="Açıklama Zorunlu" FieldName="RequiresComment" Width="100px">
                                    <DataItemTemplate>
                                        <%# HtmlHelper.TrueFalseIcon(Convert.ToBoolean(Eval("RequiresComment"))) %>
                                    </DataItemTemplate>
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn Caption="Puanı Görünür" FieldName="HasVisibleScore" Width="100px">
                                    <DataItemTemplate>
                                        <%# HtmlHelper.TrueFalseIcon(Convert.ToBoolean(Eval("HasVisibleScore"))) %>
                                    </DataItemTemplate>
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn Caption="Çoklu Cevap" FieldName="HasMultipleAnswers" Width="100px">
                                    <DataItemTemplate>
                                        <%# HtmlHelper.TrueFalseIcon(Convert.ToBoolean(Eval("HasMultipleAnswers"))) %>
                                    </DataItemTemplate>
                                </dx:GridViewDataTextColumn>
                            </Columns>
                        </dx:ASPxGridView>
                    </div>
                </div>
            </div>
        </div>
    </asp:Panel>
</asp:Content>
