<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="QuestionnairesEvaluated.aspx.cs" Inherits="EvaluationAssistt.Web.Pages.QuestionnairesEvaluated" %>

<%@ Register Assembly="DevExpress.Web.v14.2, Version=14.2.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>

<%@ Import Namespace="EvaluationAssistt.Infrastructure.Helpers" %>
<%@ Import Namespace="EvaluationAssistt.Infrastructure.Enums" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <%--    <script src="//code.jquery.com/jquery-1.10.2.js"></script>--%>
    <script src="../Scripts/jQuery/jquery-1.9.1.min.js"></script>

    <script type="text/javascript" src="http://<%=ConfigurationManager.AppSettings["SoundFileIp"].ToString() %>/Scripts/audio-player.js"></script>
    <script type="text/javascript">
        AudioPlayer.setup("http://<%=ConfigurationManager.AppSettings["SoundFileIp"].ToString() %>/Scripts/player.swf", {
        });
    </script>
    <script type="text/javascript">
        function ToggleCategoriesRadio(sender) {
            var radios = $(sender).parent().children('input[name^="radio"]');

            var isChecked = false;

            for (var i = 0; i < radios.length; i++) {
                if (radios[i] == sender) {
                    $(radios[i]).attr("markedcategory", "1");
                    continue;
                }

                if ($(radios[i]).attr("markedcategory") == "1") {
                    isChecked = true;
                    $(radios[i]).attr("markedcategory", "0");
                }
            }

            if (isChecked) {
                for (var i = 0; i < radios.length; i++) {

                    if (radios[i] == sender)
                        continue;

                    var disable = $(radios[i]).attr("categories").split(",");

                    for (var j = 0; j < disable.length; j++) {
                        var t = disable[j];
                        $("#category_" + t).toggle();

                        var y = $("#category_" + t).find('input[name^="radio"], input[name^="check"]');
                        for (var p = 0; p < y.length; p++) {
                            y[p].checked = false;
                        }
                    }
                }
            }

            var categories = $(sender).attr("categories").split(",");
            for (var i = 0; i < categories.length; i++) {
                var id = categories[i];
                $("#category_" + id).toggle();

                var y = $("#category_" + t).find('input[name^="radio"], input[name^="check"]');
                for (var j = 0; j < y.length; j++) {
                    y[j].checked = false;
                }
            }
        }

        function ToggleSectionsRadio(sender) {
            var radios = $(sender).parent().children('input[name^="radio"]');

            var isChecked = false;

            for (var i = 0; i < radios.length; i++) {
                if (radios[i] == sender) {
                    $(radios[i]).attr("markedsection", "1");
                    continue;
                }

                if ($(radios[i]).attr("markedsection") == "1") {
                    isChecked = true;
                    $(radios[i]).attr("markedsection", "0");
                }
            }

            if (isChecked) {
                for (var i = 0; i < radios.length; i++) {

                    if (radios[i] == sender)
                        continue;

                    var disable = $(radios[i]).attr("sections").split(",");

                    for (var j = 0; j < disable.length; j++) {
                        var t = disable[j];
                        $("#section_" + t).toggle();

                        var y = $("#section_" + t).find('input[name^="radio"]');
                        for (var p = 0; p < y.length; p++) {
                            y[p].checked = false;
                        }
                    }
                }
            }

            var sections = $(sender).attr("sections").split(",");
            for (var i = 0; i < sections.length; i++) {
                var id = sections[i];
                $("#section_" + id).toggle();

                var y = $("#section_" + t).find('input[name^="radio"]');
                for (var j = 0; j < y.length; j++) {
                    y[j].checked = false;
                }
            }
        }

        function ToggleQuestionsRadio(sender) {
            var radios = $(sender).parent().children('input[name^="radio"]');

            var isChecked = false;

            for (var i = 0; i < radios.length; i++) {
                if (radios[i] == sender) {
                    $(radios[i]).attr("markedquestion", "1");
                    continue;
                }

                if ($(radios[i]).attr("markedquestion") == "1") {
                    isChecked = true;
                    $(radios[i]).attr("markedquestion", "0");
                }
            }

            if (isChecked) {
                for (var i = 0; i < radios.length; i++) {

                    if (radios[i] == sender)
                        continue;

                    var disable = $(radios[i]).attr("questions").split(",");

                    for (var j = 0; j < disable.length; j++) {
                        var t = disable[j];
                        $("#question_" + t).toggle();

                        var y = $("#question_" + t).find('input[name^="radio"]');
                        for (var p = 0; p < y.length; p++) {
                            y[p].checked = false;
                        }
                    }
                }
            }

            var questions = $(sender).attr("questions").split(",");
            for (var i = 0; i < questions.length; i++) {
                var id = questions[i];
                $("#question_" + id).toggle();

                var y = $("#question_" + t).find('input[name^="radio"]');
                for (var j = 0; j < y.length; j++) {
                    y[j].checked = false;
                }
            }
        }

        function ToggleCategoriesCheck(sender) {
            var categories = $(sender).attr("categories").split(",");
            for (var i = 0; i < categories.length; i++) {
                var id = categories[i];
                $("#category_" + id).toggle();

                var y = $("#category_" + id).find('input[name^="check"], input[name^="radio"]');
                for (var i = 0; i < y.length; i++) {
                    y[i].checked = false;
                }
            }
        }

        function ToggleSectionsCheck(sender) {
            var sections = $(sender).attr("sections").split(",");
            for (var i = 0; i < sections.length; i++) {
                var id = sections[i];
                $("#section_" + id).toggle();

                var y = $("#section_" + id).find('input[name^="check"], input[name^="radio"]');
                for (var i = 0; i < y.length; i++) {
                    y[i].checked = false;
                }
            }
        }

        function ToggleQuestionsCheck(sender) {
            var questions = $(sender).attr("questions").split(",");
            for (var i = 0; i < questions.length; i++) {
                var id = questions[i];
                $("#question_" + id).toggle();

                var y = $("#question_" + id).find('input[name^="check"], input[name^="radio"]');
                for (var i = 0; i < y.length; i++) {
                    y[i].checked = false;
                }
            }
        }

        $(document).ready(function () {
            document.getElementById('content_btnSave').disabled = true;
        });

        function CalculateScore() {
            var formId = $("#hiddenFormId").val();

            var answers_radio = $('input[name^="radio"]').filter(":checked");
            var answers_radio_string = "";

            for (var i = 0; i < answers_radio.length; i++) {
                answers_radio_string += $(answers_radio[i]).attr("answer") + "-";
            }

            var answers_check = $('input[name^="check"]').filter(":checked");
            var answers_check_string = "";

            for (var i = 0; i < answers_check.length; i++) {
                answers_check_string += $(answers_check[i]).attr("answer") + "-";
            }

            $.ajax({
                type: 'POST',
                url: "/Pages/QuestionnairesEvaluated.aspx/CalculateScoreOnCs",
                dataType: 'json',
                contentType: 'application/json;charset=utf-8',
                data: '{"radioScores":"' + answers_radio_string + '", "checkScores":"' + answers_check_string + '", "formId":"' + formId + '"}',
                success: function (e) {
                    document.getElementById('content_btnSave').disabled = false;
                    var _totalScore = $("#hiddenTotalScore").val();

                    var totalScore = parseInt(_totalScore);
                    var calculated = parseInt(e.d);

                    var result = calculated;
                    //if (calculated > 0)
                    //    result = calculated;
                    //else result = totalScore - calculated;

                    //if (result < 0)
                    //    result = 0;

                    $("#lblTotalScore").html(result);
                }
            })
        }

        function SubmitForm() {
            var requestRunning = false;
            if (requestRunning) { // don't do anything if an AJAX request is pending
                return;
            }

            var all_answers = $('input[name^="radio"], input[name^="check"]').filter(":checked");

            var ids = "";

            for (var i = 0; i < all_answers.length; i++) {
                ids += $(all_answers[i]).attr("answer") + "-";
            }

            var _comments = $('input[id^="txtComment"]');
            var comments = "";

            for (var i = 0; i < _comments.length; i++) {
                var questionId = $(_comments[i]).attr("id").split("_")[3];
                comments += questionId + "_" + $(_comments[i]).val() + "-";
            }

            var formId = $("#hiddenFormId").val();
            var callId = getParameterByName("CallId");

            var score = parseInt($("#lblTotalScore").html());

            requestRunning = true;
            $.ajax({
                type: 'POST',
                url: "/Pages/QuestionnairesEvaluated.aspx/SubmitForm",
                dataType: 'json',
                contentType: 'application/json;charset=utf-8',
                data: '{"ids":"' + ids + '", "formId":"' + formId + '", "callId":"' + callId + '", "comments":"' + comments + '", "score":"' + score + '"}',
                success: function (e) {
                    $.msgbox("Form başarıyla kaydedilmiştir", {
                        type: "info",
                        buttons:
                            [
                                { type: "submit", value: "Tamam" }
                            ]
                    })

                    window.location = 'Home.Aspx';

                    $("#btnSave").css("display", "none");
                }
            })
        }

        function DeleteById() {
            var callId = getParameterByName("CallId");

            $.ajax({
                type: 'POST',
                url: "/Pages/QuestionnairesEvaluated.aspx/DeleteEvaluationById",
                dataType: 'json',
                contentType: 'application/json;charset=utf-8',
                data: '{"callId":"' + callId + '"}',
                success: function (e) {
                    $.msgbox("Değerlendirme başarıyla silinmiştir", {
                        type: "info",
                        buttons:
                            [
                                { type: "submit", value: "Tamam" }
                            ]
                    })

                    window.location = 'Home.Aspx';

                    $("#btnDelete").css("display", "none");
                }
            })
        }

        function SaveNote(sender) {
            var note = document.getElementById('txtAgentNote').value;

            var callId = parseInt(getParameterByName("CallId"));
            var formId = parseInt(getParameterByName("FormId"));

            $.ajax({
                type: 'POST',
                url: "/Pages/QuestionnairesEvaluated.aspx/SaveNote",
                dataType: 'json',
                contentType: 'application/json;charset=utf-8',
                data: '{"callId":"' + callId + '", "formId":"' + formId + '", "note":"' + note + '"}',
                success: function (e) {
                    $.msgbox("<b>Kayıt Başarılı!</b><br /><br />Ankete ilişkin notunuz başarıyla kaydedilmiştir.", {
                        type: "info",
                        buttons:
                            [
                                { type: "submit", value: "Tamam" }
                            ]
                    });
                    $(sender).hide();
                    window.location.href = "Home.Aspx";
                }
            })
        }

        function SaveInstantancy(sender) {
            var all_answers = $('input[name^="radio"], input[name^="check"]').filter(":checked");
            var ids = "";
            for (var i = 0; i < all_answers.length; i++) {
                ids += $(all_answers[i]).attr("answer") + "-";
            }
            var _comments = $('input[id^="txtComment"]');
            var comments = "";
            for (var i = 0; i < _comments.length; i++) {
                var questionId = $(_comments[i]).attr("id").split("_")[3];
                comments += questionId + "_" + $(_comments[i]).val() + "-";
            }
            var formId = $("#hiddenFormId").val();
            var callId = getParameterByName("CallId");
            var score = parseInt($("#lblTotalScore").html());

            var deliveryService;
            var selection = $("input[@name=rbListNoYes]:checked").val();
            var callId = parseInt(getParameterByName("CallId"));
            var formId = parseInt(getParameterByName("FormId"));
            var editedScore = document.getElementById('lblTotalScore').outerText;
            var ISMNote = "";
            var TLNote = "";
            if (document.getElementById('content_txtISMNote') != null)
                ISMNote = document.getElementById('content_txtISMNote').value;
            if (document.getElementById('content_txtTLNote') != null)
                TLNote = document.getElementById('content_txtTLNote').value;

            $.ajax({
                type: 'POST',
                url: "/Pages/QuestionnairesEvaluated.aspx/SaveInstantancy",
                dataType: 'json',
                contentType: 'application/json;charset=utf-8',
                data: '{"callId":"' + callId + '", "formId":"' + formId + '", "selection":"' + selection + '", "editedScore":"' + editedScore + '", "TLNote":"' + TLNote + '", "ISMNote":"' + ISMNote + '","ids":"' + ids + '"}',
                success: function (e) {
                    $.msgbox("<b>Kayıt Başarılı!</b><br /><br />Değerlendirme puanınız ve durumunuz başarıyla kaydedilmiştir.", {
                        type: "info",
                        buttons:
                            [
                                { type: "submit", value: "Tamam" }
                            ]
                    });
                    $(sender).hide();
                    window.location.href = "Home.Aspx";
                }
            })
        }

        function getParameterByName(name) {
            name = name.replace(/[\[]/, "\\\[").replace(/[\]]/, "\\\]");
            var regexS = "[\\?&]" + name + "=([^&#]*)";
            var regex = new RegExp(regexS);
            var results = regex.exec(window.location.search);
            if (results == null)
                return "";
            else
                return decodeURIComponent(results[1].replace(/\+/g, " "));
        }

        function UpdateScoreTexts() {
            $(".widget_header[type^='category']").each(function () {

                var totalScore = 0;

                var inputs = $(this).next().find('input[name^="radio"]').filter(":checked");

                for (var i = 0; i < inputs.length; i++) {
                    var score = $(inputs[i]).attr("score");
                    totalScore += parseInt(score);
                }

                var text = $(this).children("h4:first-child").text().split(" | ")[0];

                $(this).children("h4:first-child").text(text + " | " + totalScore + " puan");

            });

            $(".widget_header[type='section']").each(function () {

                var categories = $(this).next().find(".widget_header");

                var sectionScore = 0;

                for (var i = 0; i < categories.length; i++) {
                    var text = $(categories[i]).children("h4:first-child").text().split(" | ")[1];

                    var index = text.indexOf("-");
                    index += 1;

                    var index2 = text.indexOf(" puan");

                    var score = text.substring(index, index2);
                    score = parseInt(score);
                    sectionScore += score;
                }

                var text = $(this).children("h4:first-child").text().split(" | ")[0];

                $(this).children("h4:first-child").text(text + " | " + sectionScore + " puan");

            });
        }

        var canceledCatIds = new Array();
        function IsThisChecked(e) {
            var cat = e.parentElement.parentElement.parentElement.id.split("_")[1];
            if ($.inArray(cat, canceledCatIds) == -1 && e.checked)
                canceledCatIds.push(cat);
            else canceledCatIds.splice(cat);
        }

    </script>
    <link href="/Contents/Css/sticky.css" rel="stylesheet" />
    <style type="text/css">
        .auto-style1 {
            width: 173px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="server">
    <div class="g_6 contents_header">
        <h3 class="i_16_forms tab_label">Değerlendirme Formu</h3>
    </div>
    <div class="g_12 separator">
    </div>
    <div class="g_12">
        <div class="g_3">
            <table>
                <tr>
                    <td><span class="label">Müşteri Temsilcisi</span></td>
                    <td><span class="label">:</span> </td>
                    <td>
                        <asp:Label ID="lblAgentName" CssClass="label" Text="" runat="server" /></td>
                </tr>
                <tr>
                    <td><span class="label">Çağrı Tarihi</span></td>
                    <td><span class="label">:</span></td>
                    <td>
                        <asp:Label ID="lblDateStarted" CssClass="label" Text="" runat="server" /></td>
                </tr>
                <tr>
                    <td><span class="label">Telefon
                    </span></td>
                    <td><span class="label">:</span></td>
                    <td>
                        <asp:Label ID="lblPhone" runat="server" CssClass="label"></asp:Label></td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td><span class="label">Çağrı Kaydı
                    </span></td>
                    <td><span class="label">:</span></td>
                    <td>
                        <asp:Literal ID="litPlayer" runat="server"></asp:Literal></td>
                </tr>
                <tr>
                    <td><span class="label">Form</span></td>
                    <td><span class="label">:</span></td>
                    <td>
                        <span class="label" id="lblFormName" runat="server"></span>
                    </td>
                </tr>
                <%if (UserHelper.Type != UserType.Agent)
                  {%>
                <tr>
                    <td><span class="label">Değerlendiren</span></td>
                    <td><span class="label">:</span></td>
                    <td>
                        <span class="label" id="lblEvaluatorName" runat="server"></span>
                    </td>
                </tr>
                <%} %>
                <tr>
                    <td><span class="label">Değerlendirme Tarihi</span></td>
                    <td><span class="label">:</span></td>
                    <td>
                        <span class="label" id="lblEvaluationDate" runat="server"></span>
                    </td>
                </tr>
                <tr>
                    <td><span class="label">Toplam Puan</span></td>
                    <td><span class="label">:</span></td>
                    <td><span class="label" id="lblTotalScore" runat="server" clientidmode="Static"></span></td>
                </tr>
                <% string note = presenter.GetFormNote();

                   if ((UserHelper.Type != UserType.Agent) && !String.IsNullOrEmpty(note) || UserHelper.Type == UserType.Agent)
                   { %>
                <tr>
                    <td><span class="label">Takım Liderine Not</span></td>
                    <td><span class="label">:</span></td>
                    <td></td>
                </tr>
                <%if (UserHelper.Type == UserType.TeamLeader)
                  {
                      presenter.SetNoteSeen(this.CallId, this.FormId);
                  } %>
                <tr>
                    <td colspan="3" id="applyProcess" runat="server">
                        <table class="label">
                            <tr>
                                <td>&nbsp;</td>
                                <td>Takım Lideri Notu:</td>
                                <td style="vertical-align: bottom">
                                    <a runat="server" id="lblQualityExpertNote">Kalite Uzmanı Notu:</a></td>
                                <td style="vertical-align: bottom; align-self: center" class="auto-style1">&nbsp;</td>
                            </tr>
                            <tr>
                                <td>İtiraza ve nota ilişkin kararınız<br />
                                    <asp:RadioButtonList ID="rbListNoYes" TextAlign="Right" runat="server" Width="126px">
                                        <asp:ListItem Value="1">  Onaylıyorum</asp:ListItem>
                                        <asp:ListItem Value="2">  Onaylamıyorum</asp:ListItem>
                                    </asp:RadioButtonList>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtTLNote" TextMode="MultiLine" runat="server" Width="183px" Height="42px" Visible="false"></asp:TextBox>
                                </td>
                                <td style="vertical-align: bottom">
                                    <asp:TextBox ID="txtISMNote" TextMode="MultiLine" runat="server" Width="183px" Height="42px" Visible="false"></asp:TextBox>
                                </td>
                                <td style="vertical-align: bottom; align-self: center" class="auto-style1">&nbsp;&nbsp;&nbsp;&nbsp;
                                    <input type="button" id="btnUpdate" runat="server" onclick="SaveInstantancy(this);" value="Onay Güncelle" /></td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td colspan="3">
                        <span class="label">Asistan Notu:</span></td>
                </tr>
                <tr>
                    <td colspan="3">
                        <textarea id="txtAgentNote" cols="1" rows="5" style="width: 500px; height: 100px;" class="simple_field"
                            <%:!String.IsNullOrEmpty(note) ? "readonly=\"readonly\"" : "" %>><%:note %></textarea>&nbsp;
                    </td>
                </tr>
                <%if (EvaluationAssistt.Infrastructure.Helpers.UserHelper.Type == EvaluationAssistt.Infrastructure.Enums.UserType.Agent && String.IsNullOrEmpty(note))
                  {%>
                <tr>
                    <td colspan="3">&nbsp;</td>
                </tr>
                <tr>
                    <td colspan="3" style="vertical-align: bottom; align-content: flex-start;">&nbsp;</td>
                </tr>
                <%}
                   } %>
                <tr>
                    <td colspan="2">
                        <input type="button" id="btnSend" runat="server" onclick="SaveNote(this);" value="Gönder" /></td>
                    <td></td>
                </tr>
            </table>
        </div>
    </div>
    <div>
        <div class="g_12 separator">
            <a style="font-family: Tahoma; font-size: smaller;">Değerlendirme Notu:</a><br />
            <textarea id="txtEvaluationNote" runat="server" cols="100" name="S1" rows="4" style="font-family: Tahoma; font-size: 10px;"></textarea>
            <table>
                <tr>
                    <td>
                        <input id="btnCalculateScore" runat="server" type="button" value="Puan Hesapla" onclick="CalculateScore();" /></td>
                    <td>
                        <input id="btnSave" runat="server" type="button" value="Kaydet" onclick="SubmitForm();" /></td>
                    <td>
                        <input id="btnDelete" runat="server" type="button" value="Sil" onclick="DeleteById();" /></td>
                </tr>
            </table>
        </div>

    </div>

    <%
        int formCallId = presenter.GetFormCallId(this.CallId, this.FormId);

        List<EvaluationAssistt.Domain.Dto.SectionsDto> sections = this.Sections.ToList();

        foreach (EvaluationAssistt.Domain.Dto.SectionsDto section in sections)
        {
            if (section.IsDisabled)
                continue;
            
    %>
    <div class="g_12" id='<%:"section_" + section.Id %>'>
        <div class="widget_header" type="section">
            <h4 class="widget_header_title wwIcon i_16_forms"><%:section.Name %> </h4>
        </div>
        <div class="widget_contents noPadding">
            <div class="line_grid">
                <%
            
            section.Categories = presenter.GetCategoriesBySectionId(section.Id).ToList();

            foreach (EvaluationAssistt.Domain.Dto.CategoriesDto category in section.Categories)
            {
                if (category.IsDisabled)
                    continue;
                
                %>
                <div class="g_12" id='<%:"category_" + category.Id %>'>
                    <div class="widget_header" type="category">
                        <h4 class="widget_header_title wwIcon i_16_forms"><%:category.Name %> </h4>
                        <%--                        <div>
                            <input type="checkbox" class="passEvaluation" id="chkIsCanceled"
                                onchange="IsThisChecked(this);" value="Bu kategoriyi değerlendirmeden geç" />
                        </div>--%>
                    </div>
                    <div class="widget_contents noPadding">
                        <div class="line_grid">
                            <%
                category.Questions = presenter.GetQuestionsByCategoryId(category.Id).ToList();

                foreach (EvaluationAssistt.Domain.Dto.QuestionsDto question in category.Questions)
                {
                    Tuple<bool, string> result = new Tuple<bool, string>(false, null);
                    string comment = String.Empty;

                    question.Answers = presenter.GetAnswersByQuestionId(question.Id);
                    
                            %>
                            <span class="label" style="color: red; font-weight: bold;">
                                <%:String.Format("Soru {0}: {1}", category.Questions.IndexOf(question) + 1, question.QuestionText) %>
                            </span>
                            <br />
                            <div>
                                <%foreach (EvaluationAssistt.Domain.Dto.AnswersDto answer in question.Answers)
                                  {
                                      result = presenter.GetIfAnswerExists(formCallId, answer.QuestionId, answer.Id);
                                      if (String.IsNullOrEmpty(comment))
                                          comment = result.Item2;

                                      answer.CategoriesToToggle = presenter.GetCategoriesToToggleByAnswerId(answer.Id);
                                      string JsParametersCategoriesToggle = String.Join(",", answer.CategoriesToToggle);
                                      answer.SectionsToToggle = presenter.GetSectionsToToggleByAnswerId(answer.Id);
                                      string JsParametersSectionsToggle = String.Join(",", answer.SectionsToToggle);
                                      answer.QuestionsToToggle = presenter.GetQuestionsToToggleByAnswerId(answer.Id);
                                      string JsParametersQuestionsToggle = String.Join(",", answer.QuestionsToToggle);
                                %>


                                <%
                                      
                                      if (UserHelper.Type == UserType.Agent || (UserHelper.Type == UserType.TeamLeader && (Session["CallState"] != null && !Convert.ToBoolean(Session["CallState"]))))
                                      {
                                          if (question.HasMultipleAnswers)
                                          {%>
                                <input type="checkbox" disabled="disabled" name='<%:String.Format("check_{0}_{1}_{2}", section.Id, category.Id, question.Id) %>' <%:result.Item1 ? "checked='checked'" : "" %>
                                    answer='<%:String.Format("check_{0}_{1}_{2}_{3}", section.Id, category.Id, question.Id, answer.Id) %>'
                                    onchange='ToggleCategoriesCheck(this); ToggleSectionsCheck(this); ToggleQuestionsCheck(this); UpdateScoreTexts();'
                                    categories='<%:JsParametersCategoriesToggle %>'
                                    sections='<%:JsParametersSectionsToggle %>'
                                    questions='<%:JsParametersQuestionsToggle %>'
                                    score='<%:answer.Score.ToString() %>' />
                                <span class="label"><%: answer.AnswerText%></span>
                                <br />
                                <%}
                                          else
                                          {%>
                                <input type="radio" disabled="disabled" name='<%:String.Format("radio_{0}_{1}_{2}", section.Id, category.Id, question.Id) %>' <%:result.Item1 ? "checked='checked'" : "" %>
                                    answer='<%:String.Format("radio_{0}_{1}_{2}_{3}", section.Id, category.Id, question.Id, answer.Id) %>'
                                    onchange="ToggleCategoriesRadio(this); ToggleSectionsRadio(this); ToggleQuestionsRadio(this); UpdateScoreTexts();"
                                    markedcategory="0" markedsection="0" markedquestion="0"
                                    categories='<%:JsParametersCategoriesToggle %>'
                                    sections='<%:JsParametersSectionsToggle %>'
                                    questions='<%:JsParametersQuestionsToggle %>'
                                    score='<%:answer.Score.ToString() %>' />
                                <span class="label"><%: answer.AnswerText %></span>
                                <br />
                                <%}
                                      }
                                      else
                                      {
                                          if (question.HasMultipleAnswers)
                                          {%>
                                <input type="checkbox" name='<%:String.Format("check_{0}_{1}_{2}", section.Id, category.Id, question.Id) %>' <%:result.Item1 ? "checked='checked'" : "" %>
                                    answer='<%:String.Format("check_{0}_{1}_{2}_{3}", section.Id, category.Id, question.Id, answer.Id) %>'
                                    onchange='ToggleCategoriesCheck(this); ToggleSectionsCheck(this); ToggleQuestionsCheck(this); UpdateScoreTexts();'
                                    categories='<%:JsParametersCategoriesToggle %>'
                                    sections='<%:JsParametersSectionsToggle %>'
                                    questions='<%:JsParametersQuestionsToggle %>'
                                    score='<%:answer.Score.ToString() %>' />
                                <span class="label"><%: answer.AnswerText%></span>
                                <br />
                                <%}
                                          else
                                          {%>
                                <input type="radio" name='<%:String.Format("radio_{0}_{1}_{2}", section.Id, category.Id, question.Id) %>' <%:result.Item1 ? "checked='checked'" : "" %>
                                    answer='<%:String.Format("radio_{0}_{1}_{2}_{3}", section.Id, category.Id, question.Id, answer.Id) %>'
                                    onchange="ToggleCategoriesRadio(this); ToggleSectionsRadio(this); ToggleQuestionsRadio(this); UpdateScoreTexts();"
                                    markedcategory="0" markedsection="0" markedquestion="0"
                                    categories='<%:JsParametersCategoriesToggle %>'
                                    sections='<%:JsParametersSectionsToggle %>'
                                    questions='<%:JsParametersQuestionsToggle %>'
                                    score='<%:answer.Score.ToString() %>' />
                                <span class="label"><%: answer.AnswerText %></span>
                                <br />
                                <%}
                                      }
                                  } %>
                            </div>
                            <%
                    if (question.HasComment)
                    {%>
                            <br />
                            <span class="label">Açıklama:</span>
                            <br />
                            <input type="text" class="simple_field" id='<%:String.Format("txtComment_{0}_{1}_{2}", section.Id, category.Id, question.Id) %>' value='<%:comment %>' style="width: 100%" />
                            <br />
                            <%}%>
                            <br />
                            <%
                }%>
                        </div>
                    </div>
                </div>
                <%  } %>
            </div>
        </div>
    </div>
    <%
        }%>
    <div class="g_12">
        <asp:HiddenField ID="hiddenIsCalculated" runat="server" ClientIDMode="Static" Value="" />
        <asp:HiddenField ID="hiddenFormId" runat="server" ClientIDMode="Static" Value="" />
        <asp:HiddenField ID="hiddenTotalScore" runat="server" ClientIDMode="Static" Value="" />
        <asp:HiddenField ID="hiddenMarked" runat="server" ClientIDMode="Static" Value="False" />
    </div>
    <script type="text/javascript">
        $(document).ready(function () {
            $(".widget_header").click();
            UpdateScoreTexts();

            var totalScore = $("#hiddenTotalScore").val();

            //$("#lblTotalScore").html(totalScore);

            if (!totalScore) {
                $("#btnSave").hide();
                $("#btnCalculateScore").hide();
            }
            else {
                $("#btnSave").show();
                $("#btnCalculateScore").show();
            }
        });
    </script>
</asp:Content>
