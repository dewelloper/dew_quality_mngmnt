<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Help.aspx.cs" Inherits="EvaluationAssistt.Web.Pages.Help" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <%-- <asp:ContentPlaceHolder ID="head" runat="server">
    </asp:ContentPlaceHolder>--%>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Değerlendirme Formu Uygulaması</title>
    <!--[if lt IE 9]>
		<script src="http://css3-mediaqueries-js.googlecode.com/svn/trunk/css3-mediaqueries.js"></script>
		<script src="http://html5shiv.googlecode.com/svn/trunk/html5.js"></script>
		<script src="/Scripts/Flot/excanvas.js"></script>
	<![endif]-->
    <!-- The Fonts -->
    <link href="http://fonts.googleapis.com/css?family=Arial|Droid+Sans:400,700" rel="stylesheet">
    <!-- The Main CSS File -->
    <link rel="stylesheet" href="/Contents/Css/style.css">
    <link href="/Contents/Css/jquery.msgbox.css" rel="stylesheet" type="text/css" />
    <!-- jQuery -->
    <script src="/Scripts/jQuery/jquery-1.7.2.min.js"></script>
    <%--<script src="/Scripts/jQuery/jquery-1.9.1.min.js"></script>--%>
    <script src="/Scripts/Mbox/jquery.msgbox.js" type="text/javascript"></script>
    <!-- Flot -->
    <script src="/Scripts/Flot/jquery.flot.js"></script>
    <script src="/Scripts/Flot/jquery.flot.resize.js"></script>
    <script src="/Scripts/Flot/jquery.flot.pie.js"></script>
    <!-- DataTables -->
    <script src="/Scripts/DataTables/jquery.dataTables.min.js"></script>
    <!-- ColResizable -->
    <script src="/Scripts/ColResizable/colResizable-1.3.js"></script>
    <!-- jQuryUI -->
    <script src="/Scripts/jQueryUI/jquery-ui-1.8.21.min.js"></script>
    <!-- Uniform -->
    <script src="/Scripts/Uniform/jquery.uniform.js"></script>
    <!-- Tipsy -->
    <script src="/Scripts/Tipsy/jquery.tipsy.js"></script>
    <!-- Elastic -->
    <script src="/Scripts/Elastic/jquery.elastic.js"></script>
    <!-- ColorPicker -->
    <script src="/Scripts/ColorPicker/colorpicker.js"></script>
    <!-- SuperTextarea -->
    <script src="/Scripts/SuperTextarea/jquery.supertextarea.min.js"></script>
    <!-- UISpinner -->
    <script src="/Scripts/UISpinner/ui.spinner.js"></script>
    <!-- MaskedInput -->
    <script src="/Scripts/MaskedInput/jquery.maskedinput-1.3.js"></script>
    <!-- ClEditor -->
    <script src="/Scripts/ClEditor/jquery.cleditor.js"></script>
    <!-- Full Calendar -->
    <script src="/Scripts/FullCalendar/fullcalendar.js"></script>
    <!-- Color Box -->
    <script src="/Scripts/ColorBox/jquery.colorbox.js"></script>
    <!-- Kanrisha Script -->
    <script src="/Scripts/kanrisha.js"></script>
    <!-- Menu Script -->
    <script src="/Scripts/Menu/Menu.js" type="text/javascript"></script>
    <script src="/Scripts/CollapsibleFieldset.js" type="text/javascript"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            $(".widget_header").click(function (event) {
                $(this).next().slideToggle(function () {
                    if ($(this).is(":visible")) {
                        $(this).prev().css("border", "1px solid #C9C9C9");
                        $(this).prev().children().first().css("color", "#9d9d9d");
                        //$(this).prev().children().first().css("text-decoration", "none");
                    } else {
                        $(this).prev().css("border", "2px solid #F18103");
                        $(this).prev().children().first().css("color", "#F18103");
                        //$(this).prev().children().first().css("font-weight", "bold");
                    }
                })
            });
        });
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <header class="main_header">
			<div class="wrapper">
				<div style="display:table; margin:0 auto">
					<a href="/Modules/OutsourceYonetimi/AnaSayfa.aspx" title="Değerlendirme Formu">
						<img src="../Contents/Images/assistt_logo_big.png" alt="ttnet_logo">
					</a>
				</div>
			</div>
		</header>
        <div class="wrapper contents_wrapper">
            <div class="contents" style="width: 100%;">
                <div class="grid_wrapper">
                    <div class="g_12 separator">
                        
                    </div>
                    <div>
                        <div class="g_12">
                            <div class="widget_header">
                                <h4 class="widget_header_title wwIcon i_16_forms">İçindekiler</h4>
                            </div>
                            <div class="widget_contents noPadding">
                                <div class="line_grid">
                                    <div class="g_3">
                                        <ul style="list-style-type: none">
                                            <li><a href="#1"><span class="label">1. AssisTT Değerlendirme Formu Uygulaması Hakkında</span></a></li>
                                            <li><a href="#2"><span class="label">2. Yetkilendirme ve Kullanıcı Tipleri</span></a></li>
                                            <li><a href="#3"><span class="label">3. Ekranlar</span></a>
                                                <ul style="list-style-type: none; margin: 0px; padding: 0px; padding-left: 15px;">
                                                    <li><a href="#3_1"><span class="label">3.1 Anasayfa</span></a></li>
                                                    <li><a href="#3_2"><span class="label">3.2 Çağrı Yönetimi</span></a></li>
                                                    <li><a href="#3_3"><span class="label">3.3 Form Yönetimi</span></a></li>
                                                    <li><a href="#3_4"><span class="label">3.4 Bölüm Yönetimi</span></a></li>
                                                    <li><a href="#3_5"><span class="label">3.5 Kategori Yönetimi</span></a></li>
                                                    <li><a href="#3_6"><span class="label">3.6 Soru Yönetimi</span></a></li>
                                                    <li><a href="#3_7"><span class="label">3.7 Form - Bölüm Eşleştirme</span></a></li>
                                                    <li><a href="#3_8"><span class="label">3.8 Bölüm - Kategori Eşleştirme</span></a></li>
                                                    <li><a href="#3_9"><span class="label">3.9 Kategori - Soru Eşleştirme</span></a></li>
                                                    <li><a href="#3_10"><span class="label">3.10 Form Ayarları</span></a></li>
                                                    <li><a href="#3_11"><span class="label">3.11 Lokasyon Yönetimi</span></a></li>
                                                    <li><a href="#3_12"><span class="label">3.12 Grup Yönetimi</span></a></li>
                                                    <li><a href="#3_13"><span class="label">3.13 Takım Yönetimi</span></a></li>
                                                    <li><a href="#3_14"><span class="label">3.14 Kullanıcı Yönetimi</span></a></li>
                                                </ul>
                                            </li>
                                        </ul>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div>
                        <div class="g_12">
                            <a name="#1"></a>
                            <div class="widget_header">
                                <h4 class="widget_header_title wwIcon i_16_forms">AssisTT Değerlendirme Formu Uygulaması Hakkında</h4>
                            </div>
                            <div class="widget_contents noPadding">
                                <div class="line_grid">
                                    <div class="g_3">
                                        <span class="label">Değerlendirme Formu uygulaması, Türk Telekom’un bir alt kuruluşu olan AssisTT tarafından kullanılan olan bir programdır. Çağrı merkezi biriminde görev yapan müşteri temsilcilerine ait çağrı kayıtlarının takip edilebildiği, bu çağrı kayıtlarının üst birimler tarafından değerlendirilebildiği, bu değerlendirmelerin yapılabilmesi için gerekli anketlerin oluşturulup, tüm içeriğinin hazırlanabildiği bir uygulamadır.</span>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div>
                        <div class="g_12">
                            <a name="#2"></a>
                            <div class="widget_header">
                                <h4 class="widget_header_title wwIcon i_16_forms">Yetkilendirme ve Kullanıcı Tipleri</h4>
                            </div>
                            <div class="widget_contents noPadding">
                                <div class="line_grid">
                                    <div class="g_3">
                                        <span class="label">Kullanıcı yönetimi ve yetkilendirme işlemleri, Kullanıcı Yönetimi sayfası üzerinden yapılmaktadır. Bu sayfada gerçekleştirilebilen işlemler aşağıdaki gibidir :</span><br />
                                        <ul>
                                            <li><span class="label">Yeni Kullanıcı Ekleme</span></li>
                                            <li><span class="label">Kullanıcı düzenleme</span>
                                                <ul style="margin: 0px; padding: 0px; padding-left: 15px;">
                                                    <li><span class="label">Kullanıcı bilgilerini değiştirme</span></li>
                                                    <li><span class="label">Kullanıcıya rol atama</span></li>
                                                    <li><span class="label">Kullanıcıya ait sayfa yetkilerini düzenleme</span></li>
                                                    <li><span class="label">Kullanıcıyı bir takıma atama</span></li>
                                                    <li><span class="label">Tüm kullanıcıları listeleme</span></li>
                                                </ul>
                                            </li>
                                            <li><span class="label">Kullanıcıyı silme</span></li>
                                        </ul>
                                        <br />
                                        <span class="label">Uygulamada yer alan roller ve yetkili oldukları sayfalar aşağıdaki gibidir :</span>
                                        <ul>
                                            <li><span class="label">Asistan : Anasayfa, Mesajlar, Profil, Değerlendirilmiş Anket* (*: Kendisine ait çağrılar)</span></li>
                                            <li><span class="label">Takım Lideri : Anasayfa, Mesajlar, Profil, Değerlendirilmiş Anket*, Değerlendirilmiş Anket Listesi*, 
Çağrı Yönetimi (*: Kendi takımındaki asistanlara ait)
                                            </span></li>
                                            <li><span class="label">Grup Lideri : Anasayfa, Mesajlar, Profil, Değerlendirilmiş Anket*, Değerlendirilmiş Anket Listesi*, 
Çağrı Yönetimi, Takım Yönetimi (*: Kendi gruplarındaki asistanlara ait)
                                            </span></li>
                                            <li><span class="label">Kalite Uzmanı : Anasayfa, Mesajlar, Profil, Değerlendirilmiş Anket*, Değerlendirilmiş Anket Listesi*, 
Çağrı Yönetimi, Takım Yönetimi (*: Kendi gruplarındaki asistanlara ait)
                                            </span></li>
                                            <li><span class="label">Admin : Tüm sayfalar
                                            </span></li>
                                        </ul>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div>
                        <div class="g_12">
                            <a name="#3"></a>
                            <div class="widget_header">
                                <h4 class="widget_header_title wwIcon i_16_forms">Ekranlar</h4>
                            </div>
                            <div class="widget_contents noPadding">
                                <div class="line_grid">
                                    <div class="g_3">
                                        <div class="g_12">
                                            <a name="#3_1"></a>
                                            <div class="widget_header">
                                                <h4 class="widget_header_title wwIcon i_16_forms">Anasayfa</h4>
                                            </div>
                                            <div class="widget_contents noPadding">
                                                <div class="line_grid">
                                                    <div class="g_3">
                                                        <img src="../Contents/Manual/Images/anasayfa.png" alt="anasayfa" />
                                                        <br />
                                                        <br />
                                                        <ul style="list-style-type: none; margin: 0px; padding: 0px;">
                                                            <li>
                                                                <span class="label">1.	Bulunduğunuz sayfayı belirtir. Bu alan, tüm sayfalarda yer almakta ve sayfanın içeriği ile ilgili genel ve kısa bir açıklamaya sahiptir.</span>
                                                            </li>
                                                            <li>
                                                                <span class="label">2.	Bu buton yardımıyla, sayfa ile ilgili sık kullanılan işlemler yapılabilir, sayfa ile ilişkili diğer sayfalara geçiş için kullanılabilir.</span>
                                                            </li>
                                                            <li>
                                                                <span class="label">3.	Sayfa ile ilgili yardım dökümanını açar.</span>
                                                            </li>
                                                            <li>
                                                                <span class="label">4.	Kendinize ait çağrı kayıtları ile ilgili özet bilgilerin yer aldığı bölüm için filtreleme alanıdır. Varsayılan olarak o günün tarihleri gelmekte ve içerisinde bulunulan güne ait çağrıların özet bilgileri yer almaktadır. Tarih aralığı girildikten sonra Sorgula butonuna basarak, belirtilen tarih aralığındaki size ait çağrıların özel bilgileri görüntülenebilir.</span>
                                                            </li>
                                                            <li>
                                                                <span class="label">5.	Sol tarafta yer alan tarih alanlarına girilen aralık içerisindeki size ait çağrıların özet bilgilerini görüntülemek için kullanılır. Sayfanın yeniden yüklenmesine neden olmaz ancak özet bilgilerin güncellenmesi için biraz beklemeniz gerekebilir.</span>
                                                            </li>
                                                            <li>
                                                                <span class="label">6.	Yukarıdaki filtre alanı doldurulduktan sonra Sorgula butonuna basılarak hesaplanan özel çağrı bilgilerinin gösterildiği bölümdür. İlk açılışta, o gün içerisindeki size ait çağrıların özet bilgileri gösterilmektedir.</span>
                                                            </li>
                                                            <li>
                                                                <span class="label">7.	Son 30 gün içerisinde değerlendirilmiş olan çağrı kayıtlarınızın liste halinde gösterildiği bölümdür.</span>
                                                            </li>
                                                            <li>
                                                                <span class="label">8.	Size ait değerlendirilmiş olan çağrının kayıt tarihi bilgisini içerir.</span>
                                                            </li>
                                                            <li>
                                                                <span class="label">9.	Size ait değerlendirilmiş olan çağrının hangi form (anket) üzerinden değerlendirildiği bilgisini içerir.</span>
                                                            </li>
                                                            <li>
                                                                <span class="label">10.	Size ait değerlendirilmiş olan çağrının kimin tarafından değerlendirildiği bilgisini içerir.</span>
                                                            </li>
                                                            <li>
                                                                <span class="label">11.	Size ait değerlendirilmiş olan çağrının değerlendirilme tarihi bilgisini içerir.</span>
                                                            </li>
                                                            <li>
                                                                <span class="label">12.	Size ait değerlendirilmiş olan çağrıdan kaç puan aldığınız bilgisini içerir.</span>
                                                            </li>
                                                            <li>
                                                                <span class="label">13.	Size ait değerlendirilmiş olan çağrıyı görüntülemek için kullanabileceğiniz bağlantıdır. Bu bağlantı ile değerlendirilmiş olan anketi, cevapları ile birlikte görüntüleyebilir, bu anket üzerinden değerlendiren kişiye itiraz, bilgilendirme vb. notlarınızı iletebilirsiniz.</span>
                                                            </li>
                                                            <li>
                                                                <span class="label">14.	Listede yer alan toplam kayıt ve toplam sayfa ile mevcut sayfa bilgilerinin gösterildiği bölümdür.</span>
                                                            </li>
                                                            <li>
                                                                <span class="label">15.	Sayfa içerisinde yer alan tüm menülerin kapanmasını sağlar. Kapalı menüler turuncu ile renklendirilir.</span>
                                                            </li>
                                                            <li>
                                                                <span class="label">16.	Sayfa içerisinde yer alan tüm menülerin açılmasını sağlar.</span>
                                                            </li>
                                                            <li>
                                                                <span class="label">17.	İlgili sayfayı favorilerinize ekler. Favori sayfalarınızı Profil sayfanızdan düzenleyebilirsiniz.</span>
                                                            </li>
                                                        </ul>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="g_12">
                                            <a name="#3_2"></a>
                                            <div class="widget_header">
                                                <h4 class="widget_header_title wwIcon i_16_forms">Çağrı Yönetimi</h4>
                                            </div>
                                            <div class="widget_contents noPadding">
                                                <div class="line_grid">
                                                    <div class="g_3">
                                                        <img src="../Contents/Manual/Images/cagri_yonetimi.png" alt="anasayfa" />
                                                        <br />
                                                        <br />
                                                        <ul style="list-style-type: none; margin: 0px; padding: 0px;">
                                                            <li>
                                                                <span class="label">1.	Bulunduğunuz sayfayı belirtir. Bu alan, tüm sayfalarda yer almakta ve sayfanın içeriği ile ilgili genel ve kısa bir açıklamaya sahiptir.</span>
                                                            </li>
                                                            <li>
                                                                <span class="label">2.	Bu buton yardımıyla, sayfa ile ilgili sık kullanılan işlemler yapılabilir, sayfa ile ilişkili diğer sayfalara geçiş için kullanılabilir.</span>
                                                            </li>
                                                            <li>
                                                                <span class="label">3.	Sayfa ile ilgili yardım dökümanını açar.</span>
                                                            </li>
                                                            <li>
                                                                <span class="label">4.	Listelenecek olan çağrı kayıtlarını; Lokasyon-Asistan veya Lokasyon-Grup-Takım-Asistan şeklinde filtrelemeye yarar.</span>
                                                            </li>
                                                            <li>
                                                                <span class="label">5.	Asistan, Konuşma Süresi Aralığı, Tarih Aralığı, Telefon No ve Remark filtreleme alanlarında yer alan bilgilere göre uygun çağrı kayıtlarını listeler.</span>
                                                            </li>
                                                            <li>
                                                                <span class="label">6.	Listelenecek olan çağrı kayıtlarını, konuşma sürelerine göre filtrelemeye yarar. İlgili değerler saniye cinsindedir ve varsayılan olarak 20sn ile 120sn arasıdır.</span>
                                                            </li>
                                                            <li>
                                                                <span class="label">7.	Listelenecek olan çağrı kayıtlarını, çağrıların kaydedildiği tarihe göre filtrelemeye yarar. Varsayılan olarak o gün içerisindeki çağrı kayıtlarını listeleyecek şekilde gelir.</span>
                                                            </li>
                                                            <li>
                                                                <span class="label">8.	Sorgula butonuna basıldıktan sonra, filtreleme alanında yer alan kriterlere uygun çağrı kayıtlarının listelendiği bölümdür.</span>
                                                            </li>
                                                            <li>
                                                                <span class="label">9.	Çağrının ait olduğu müşteri temsilcisi bilgisini içerir.</span>
                                                            </li>
                                                            <li>
                                                                <span class="label">10.	Çağrının kayıt tarihi bilgisini içerir.</span>
                                                            </li>
                                                            <li>
                                                                <span class="label">11.	Çağrıyı başlatan telefon numarası bilgisini içerir.</span>
                                                            </li>
                                                            <li>
                                                                <span class="label">12.	Çağrının kaydının süre bilgisini içerir.</span>
                                                            </li>
                                                            <li>
                                                                <span class="label">13.	Çağrı kaydına ait VDN bilgisini içerir.</span>
                                                            </li>
                                                            <li>
                                                                <span class="label">14.	Çağrı kaydına ait VND No bilgisini içerir.</span>
                                                            </li>
                                                            <li>
                                                                <span class="label">15.	Çağrı kaydına ait ilgili ses dosyasını bilgisayarınıza indirmek için kullanabileceğiniz bağlantıdır.</span>
                                                            </li>
                                                            <li>
                                                                <span class="label">16.	Çağrı kaydına ait ilgili ses dosyasını indirmeden, aynı sayfa üzerinde dinleyebileceğiniz bağlantıdır.</span>
                                                            </li>
                                                            <li>
                                                                <span class="label">17.	Çağrı kaydını değerlendirmek için kullanabileceğiniz bağlantıdır. Açılan sayfada, listeden bir anket seçimi yapılır. Eğer seçilen anket ile daha önce değerlendirme yapıldıysa, ilgili anket, cevapları ile birlikte sistemden yüklenir. Eğer anket uygulanmamışsa, yeni değerlendirme yapabileceğiniz sayfa açılır.</span>
                                                            </li>
                                                            <li>
                                                                <span class="label">18.	Sayfa içerisinde yer alan tüm menülerin kapanmasını sağlar. Kapalı menüler turuncu ile renklendirilir.</span>
                                                            </li>
                                                            <li>
                                                                <span class="label">19.	Sayfa içerisinde yer alan tüm menülerin açılmasını sağlar.</span>
                                                            </li>
                                                            <li>
                                                                <span class="label">20.	İlgili sayfayı favorilerinize ekler. Favori sayfalarınızı Profil sayfanızdan düzenleyebilirsiniz.</span>
                                                            </li>
                                                            <li>
                                                                <span class="label">21.	Sadece değerlendirilmiş çağrı kayıtlarının listelendiği sayfaya gitmeye yarayan bağlantıdır.</span>
                                                            </li>
                                                        </ul>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="g_12">
                                            <a name="#3_3"></a>
                                            <div class="widget_header">
                                                <h4 class="widget_header_title wwIcon i_16_forms">Form Yönetimi</h4>
                                            </div>
                                            <div class="widget_contents noPadding">
                                                <div class="line_grid">
                                                    <div class="g_3">
                                                        <img src="../Contents/Manual/Images/form_yonetimi_1.png" alt="anasayfa" />
                                                        <br />
                                                        <br />
                                                        <ul style="list-style-type: none; margin: 0px; padding: 0px;">
                                                            <li>
                                                                <span class="label">1.	Bulunduğunuz sayfayı belirtir. Bu alan, tüm sayfalarda yer almakta ve sayfanın içeriği ile ilgili genel ve kısa bir açıklamaya sahiptir.</span>
                                                            </li>
                                                            <li>
                                                                <span class="label">2.	Bu buton yardımıyla, sayfa ile ilgili sık kullanılan işlemler yapılabilir, sayfa ile ilişkili diğer sayfalara geçiş için kullanılabilir.</span>
                                                            </li>
                                                            <li>
                                                                <span class="label">3.	Sayfa ile ilgili yardım dökümanını açar.</span>
                                                            </li>
                                                            <li>
                                                                <span class="label">4.	Sistemde tanımlı formların liste halinde gösterildiği bölümdür.</span>
                                                            </li>
                                                            <li>
                                                                <span class="label">5.	İlgili satırda yer alan formu düzenlemek için kullanılan bağlantıdır.</span>
                                                            </li>
                                                            <li>
                                                                <span class="label">6.	İlgili satırda yer alan formu silmek için kullanılan bağlantıdır.</span>
                                                            </li>
                                                            <li>
                                                                <span class="label">7.	İlgili satırda yer alan formun isim bilgisini içerir.</span>
                                                            </li>
                                                            <li>
                                                                <span class="label">8.	İlgili satırda yer alan formda, açıklama girilmesinin zorunlu olup olmadığı bilgisini içerir.</span>
                                                            </li>
                                                            <li>
                                                                <span class="label">9.	Listede yer alan toplam kayıt ve toplam sayfa ile mevcut sayfa bilgilerinin gösterildiği bölümdür.</span>
                                                            </li>
                                                            <li>
                                                                <span class="label">10.	Sayfa içerisinde yer alan tüm menülerin kapanmasını sağlar. Kapalı menüler turuncu ile renklendirilir.</span>
                                                            </li>
                                                            <li>
                                                                <span class="label">11.	Sayfa içerisinde yer alan tüm menülerin açılmasını sağlar.</span>
                                                            </li>
                                                            <li>
                                                                <span class="label">12.	İlgili sayfayı favorilerinize ekler. Favori sayfalarınızı Profil sayfanızdan düzenleyebilirsiniz.</span>
                                                            </li>
                                                            <li>
                                                                <span class="label">13.	Formun bir alt öğesi olmak üzere, yeni bir Bölüm eklemek için kullanılan bağlantıdır.</span>
                                                            </li>
                                                            <li>
                                                                <span class="label">14.	Sistemde tanımlı form ve bölümler arasında eşleştirme yaparak, birbirine bağlamak için kullanılan sayfaya giden bağlantıdır.</span>
                                                            </li>
                                                            <li>
                                                                <span class="label">15.	Yeni bir form eklemek için kullanılan butondur. Bu butona basılması ile sayfanın üst kısmında yeni bir form girişi yapmak için gerekli alanların yer aldığı bir bölüm açılacaktır. *</span>
                                                            </li>
                                                        </ul>
                                                        <br />
                                                        <br />
                                                        <img src="../Contents/Manual/Images/form_yonetimi_2.png" alt="anasayfa" />
                                                        <br />
                                                        <span class="label">* : Yeni butonuna basılması ile birlikte, sayfanın üst kısmında yukarıdaki bölüm açılmaktadır.</span>
                                                        <br />
                                                        <br />
                                                        <ul style="list-style-type: none; margin: 0px; padding: 0px;">
                                                            <li>
                                                                <span class="label">1.	Oluşturulacak olan yeni form için gerekli isim bilgisinin girileceği alan.</span>
                                                            </li>
                                                            <li>
                                                                <span class="label">2.	Oluşturulacak olan form değerlendirilirken, açıklama alanının zorunlu olup olmayacağı bilgisinin seçileceği alan.</span>
                                                            </li>
                                                            <li>
                                                                <span class="label">3.	Girilen bilgilerle yeni form oluşturmak için kullanılacak olan buton.</span>
                                                            </li>
                                                            <li>
                                                                <span class="label">4.	Girilen bilgilerin tümünü silmek için kullanılacak olan buton.</span>
                                                            </li>
                                                            <li>
                                                                <span class="label">5.	Form oluşturma işlemini iptal edip, liste görüntüsüne geçmek için kullanılacak olan buton.</span>
                                                            </li>
                                                        </ul>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="g_12">
                                            <a name="#3_4"></a>
                                            <div class="widget_header">
                                                <h4 class="widget_header_title wwIcon i_16_forms">Bölüm Yönetimi</h4>
                                            </div>
                                            <div class="widget_contents noPadding">
                                                <div class="line_grid">
                                                    <div class="g_3">
                                                        <img src="../Contents/Manual/Images/bolum_yonetimi_1.png" alt="anasayfa" />
                                                        <br />
                                                        <br />
                                                        <ul style="list-style-type: none; margin: 0px; padding: 0px;">
                                                            <li>
                                                                <span class="label">1.	Bulunduğunuz sayfayı belirtir. Bu alan, tüm sayfalarda yer almakta ve sayfanın içeriği ile ilgili genel ve kısa bir açıklamaya sahiptir.</span>
                                                            </li>
                                                            <li>
                                                                <span class="label">2.	Bu buton yardımıyla, sayfa ile ilgili sık kullanılan işlemler yapılabilir, sayfa ile ilişkili diğer sayfalara geçiş için kullanılabilir.</span>
                                                            </li>
                                                            <li>
                                                                <span class="label">3.	Sayfa ile ilgili yardım dökümanını açar.</span>
                                                            </li>
                                                            <li>
                                                                <span class="label">4.	Sistemde tanımlı bölümlerin liste halinde gösterildiği bölümdür.</span>
                                                            </li>
                                                            <li>
                                                                <span class="label">5.	İlgili satırda yer alan bölümü düzenlemek için kullanılan bağlantıdır.</span>
                                                            </li>
                                                            <li>
                                                                <span class="label">6.	İlgili satırda yer alan bölümü silmek için kullanılan bağlantıdır.</span>
                                                            </li>
                                                            <li>
                                                                <span class="label">7.	İlgili satırda yer alan bölümün isim bilgisini içerir.</span>
                                                            </li>
                                                            <li>
                                                                <span class="label">8.	İlgili satırda yer alan bölümün, başlangıçta kapalı gelip gelmeyeceği bilgisini içerir.</span>
                                                            </li>
                                                            <li>
                                                                <span class="label">9.	İlgili satırda yer alan bölümden alınabilecek minimum puan bilgisini içerir.</span>
                                                            </li>
                                                            <li>
                                                                <span class="label">10.	İlgili satırda yer alan bölümden alınabilecek maksimum puan bilgisini içerir.</span>
                                                            </li>
                                                            <li>
                                                                <span class="label">11.	İlgili satırda yer alan bölüme ait puanların hesaplanma yöntemi bilgisini içerir.</span>
                                                            </li>
                                                            <li>
                                                                <span class="label">12.	Listede yer alan toplam kayıt ve toplam sayfa ile mevcut sayfa bilgilerinin gösterildiği bölümdür.</span>
                                                            </li>
                                                            <li>
                                                                <span class="label">13.	Sayfa içerisinde yer alan tüm menülerin kapanmasını sağlar. Kapalı menüler turuncu ile renklendirilir.</span>
                                                            </li>
                                                            <li>
                                                                <span class="label">14.	Sayfa içerisinde yer alan tüm menülerin açılmasını sağlar.</span>
                                                            </li>
                                                            <li>
                                                                <span class="label">15.	İlgili sayfayı favorilerinize ekler. Favori sayfalarınızı Profil sayfanızdan düzenleyebilirsiniz.</span>
                                                            </li>
                                                            <li>
                                                                <span class="label">16.	Bölümün bir üst öğesi olmak üzere, yeni bir Form eklemek için kullanılan bağlantıdır.</span>
                                                            </li>
                                                            <li>
                                                                <span class="label">17.	Bölümün bir alt öğesi olmak üzere, yeni bir Kategori eklemek için kullanılan bağlantıdır.</span>
                                                            </li>
                                                            <li>
                                                                <span class="label">18.	Sistemde tanımlı bölüm ve kategoriler arasında eşleştirme yaparak, birbirine bağlamak için kullanılan sayfaya giden bağlantıdır.</span>
                                                            </li>
                                                            <li>
                                                                <span class="label">19.	Yeni bir bölüm eklemek için kullanılan butondur. Bu butona basılması ile sayfanın üst kısmında yeni bir bölüm girişi yapmak için gerekli alanların yer aldığı bir bölüm açılacaktır. *</span>
                                                            </li>
                                                        </ul>
                                                        <br />
                                                        <br />
                                                        <img src="../Contents/Manual/Images/bolum_yonetimi_2.png" alt="anasayfa" />
                                                        <br />
                                                        <span class="label">* : Yeni butonuna basılması ile birlikte, sayfanın üst kısmında yukarıdaki bölüm açılmaktadır.</span>
                                                        <br />
                                                        <br />
                                                        <ul style="list-style-type: none; margin: 0px; padding: 0px;">
                                                            <li>
                                                                <span class="label">1.	Oluşturulacak olan yeni bölüm için gerekli isim bilgisinin girileceği alan.</span>
                                                            </li>
                                                            <li>
                                                                <span class="label">2.	Oluşturulacak olan yeni bölüme ait puanların hesaplanma yöntemi bilgisinin girileceği alan.</span>
                                                            </li>
                                                            <li>
                                                                <span class="label">3.	Oluşturulacak olan yeni bölümden alınabilecek minimum puan bilgisinin girileceği alan.</span>
                                                            </li>
                                                            <li>
                                                                <span class="label">4.	Oluşturulacak olan yeni bölümden alınabilecek maksimum puan bilgisinin girileceği alan.</span>
                                                            </li>
                                                            <li>
                                                                <span class="label">5.	Oluşturulacak olan yeni bölümün, başlangıçta kapalı olup olmayacağı bilgisinin seçileceği alan.</span>
                                                            </li>
                                                            <li>
                                                                <span class="label">6.	Girilen bilgilerle yeni bölüm oluşturmak için kullanılacak olan buton.</span>
                                                            </li>
                                                            <li>
                                                                <span class="label">7.	Girilen bilgilerin tümünü silmek için kullanılacak olan buton.</span>
                                                            </li>
                                                            <li>
                                                                <span class="label">8.	Bölüm oluşturma işlemini iptal edip, liste görüntüsüne geçmek için kullanılacak olan buton.</span>
                                                            </li>
                                                        </ul>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="g_12">
                                            <a name="#3_5"></a>
                                            <div class="widget_header">
                                                <h4 class="widget_header_title wwIcon i_16_forms">Kategori Yönetimi</h4>
                                            </div>
                                            <div class="widget_contents noPadding">
                                                <div class="line_grid">
                                                    <div class="g_3">
                                                        <img src="../Contents/Manual/Images/kategori_yonetimi_1.png" alt="anasayfa" />
                                                        <br />
                                                        <br />
                                                        <ul style="list-style-type: none; margin: 0px; padding: 0px;">
                                                            <li>
                                                                <span class="label">1.	Bulunduğunuz sayfayı belirtir. Bu alan, tüm sayfalarda yer almakta ve sayfanın içeriği ile ilgili genel ve kısa bir açıklamaya sahiptir.</span>
                                                            </li>
                                                            <li>
                                                                <span class="label">2.	Bu buton yardımıyla, sayfa ile ilgili sık kullanılan işlemler yapılabilir, sayfa ile ilişkili diğer sayfalara geçiş için kullanılabilir.</span>
                                                            </li>
                                                            <li>
                                                                <span class="label">3.	Sayfa ile ilgili yardım dökümanını açar.</span>
                                                            </li>
                                                            <li>
                                                                <span class="label">4.	Sistemde tanımlı kategorilerin liste halinde gösterildiği bölümdür.</span>
                                                            </li>
                                                            <li>
                                                                <span class="label">5.	İlgili satırda yer alan kategoriyi düzenlemek için kullanılan bağlantıdır.</span>
                                                            </li>
                                                            <li>
                                                                <span class="label">6.	İlgili satırda yer alan kategoriyi silmek için kullanılan bağlantıdır.</span>
                                                            </li>
                                                            <li>
                                                                <span class="label">7.	İlgili satırda yer alan kategorinin isim bilgisini içerir.</span>
                                                            </li>
                                                            <li>
                                                                <span class="label">8.	İlgili satırda yer alan kategorinin, başlangıçta kapalı gelip gelmeyeceği bilgisini içerir.</span>
                                                            </li>
                                                            <li>
                                                                <span class="label">9.	İlgili satırda yer alan kategoriden alınabilecek minimum puan bilgisini içerir.</span>
                                                            </li>
                                                            <li>
                                                                <span class="label">10.	İlgili satırda yer alan kategoriden alınabilecek maksimum puan bilgisini içerir.</span>
                                                            </li>
                                                            <li>
                                                                <span class="label">11.	İlgili satırda yer alan kategoriye ait puanların hesaplanma yöntemi bilgisini içerir.</span>
                                                            </li>
                                                            <li>
                                                                <span class="label">12.	Listede yer alan toplam kayıt ve toplam sayfa ile mevcut sayfa bilgilerinin gösterildiği bölümdür.</span>
                                                            </li>
                                                            <li>
                                                                <span class="label">13.	Sayfa içerisinde yer alan tüm menülerin kapanmasını sağlar. Kapalı menüler turuncu ile renklendirilir.</span>
                                                            </li>
                                                            <li>
                                                                <span class="label">14.	Sayfa içerisinde yer alan tüm menülerin açılmasını sağlar.</span>
                                                            </li>
                                                            <li>
                                                                <span class="label">15.	İlgili sayfayı favorilerinize ekler. Favori sayfalarınızı Profil sayfanızdan düzenleyebilirsiniz.</span>
                                                            </li>
                                                            <li>
                                                                <span class="label">16.	Kategorinin bir üst öğesi olmak üzere, yeni bir Bölüm eklemek için kullanılan bağlantıdır.</span>
                                                            </li>
                                                            <li>
                                                                <span class="label">17.	Kategorinin bir alt öğesi olmak üzere, yeni bir Soru eklemek için kullanılan bağlantıdır.</span>
                                                            </li>
                                                            <li>
                                                                <span class="label">18.	Sistemde tanımlı kategori ve sorular arasında eşleştirme yaparak, birbirine bağlamak için kullanılan sayfaya giden bağlantıdır.</span>
                                                            </li>
                                                            <li>
                                                                <span class="label">19.	Yeni bir kategori eklemek için kullanılan butondur. Bu butona basılması ile sayfanın üst kısmında yeni bir kategori girişi yapmak için gerekli alanların yer aldığı bir bölüm açılacaktır. *</span>
                                                            </li>
                                                        </ul>
                                                        <br />
                                                        <br />
                                                        <img src="../Contents/Manual/Images/kategori_yonetimi_2.png" alt="anasayfa" />
                                                        <br />
                                                        <span class="label">* : Yeni butonuna basılması ile birlikte, sayfanın üst kısmında yukarıdaki bölüm açılmaktadır.</span>
                                                        <br />
                                                        <br />
                                                        <ul style="list-style-type: none; margin: 0px; padding: 0px;">
                                                            <li>
                                                                <span class="label">1.	Oluşturulacak olan yeni kategori için gerekli isim bilgisinin girileceği alan.</span>
                                                            </li>
                                                            <li>
                                                                <span class="label">2.	Oluşturulacak olan yeni kategoriye ait puanların hesaplanma yöntemi bilgisinin girileceği alan.</span>
                                                            </li>
                                                            <li>
                                                                <span class="label">3.	Oluşturulacak olan yeni kategoriden alınabilecek minimum puan bilgisinin girileceği alan.</span>
                                                            </li>
                                                            <li>
                                                                <span class="label">4.	Oluşturulacak olan yeni kategoriden alınabilecek maksimum puan bilgisinin girileceği alan.</span>
                                                            </li>
                                                            <li>
                                                                <span class="label">5.	Oluşturulacak olan yeni kategorinin, başlangıçta kapalı olup olmayacağı bilgisinin seçileceği alan.</span>
                                                            </li>
                                                            <li>
                                                                <span class="label">6.	Girilen bilgilerle yeni kategori oluşturmak için kullanılacak olan buton.</span>
                                                            </li>
                                                            <li>
                                                                <span class="label">7.	Girilen bilgilerin tümünü silmek için kullanılacak olan buton.</span>
                                                            </li>
                                                            <li>
                                                                <span class="label">8.	Kategori oluşturma işlemini iptal edip, liste görüntüsüne geçmek için kullanılacak olan buton.</span>
                                                            </li>
                                                        </ul>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="g_12">
                                            <a name="#3_6"></a>
                                            <div class="widget_header">
                                                <h4 class="widget_header_title wwIcon i_16_forms">Soru Yönetimi</h4>
                                            </div>
                                            <div class="widget_contents noPadding">
                                                <div class="line_grid">
                                                    <div class="g_3">
                                                        <img src="../Contents/Manual/Images/soru_yonetimi_1.png" alt="anasayfa" />
                                                        <br />
                                                        <br />
                                                        <ul style="list-style-type: none; margin: 0px; padding: 0px;">
                                                            <li>
                                                                <span class="label">1.	Bulunduğunuz sayfayı belirtir. Bu alan, tüm sayfalarda yer almakta ve sayfanın içeriği ile ilgili genel ve kısa bir açıklamaya sahiptir.</span>
                                                            </li>
                                                            <li>
                                                                <span class="label">2.	Bu buton yardımıyla, sayfa ile ilgili sık kullanılan işlemler yapılabilir, sayfa ile ilişkili diğer sayfalara geçiş için kullanılabilir.</span>
                                                            </li>
                                                            <li>
                                                                <span class="label">3.	Sayfa ile ilgili yardım dökümanını açar.</span>
                                                            </li>
                                                            <li>
                                                                <span class="label">4.	Sistemde tanımlı soruların liste halinde gösterildiği bölümdür.</span>
                                                            </li>
                                                            <li>
                                                                <span class="label">5.	İlgili satırda yer alan soruyu düzenlemek için kullanılan bağlantıdır.</span>
                                                            </li>
                                                            <li>
                                                                <span class="label">6.	İlgili satırda yer alan soruyu silmek için kullanılan bağlantıdır.</span>
                                                            </li>
                                                            <li>
                                                                <span class="label">7.	İlgili satırda yer alan sorunun metnini içerir.</span>
                                                            </li>
                                                            <li>
                                                                <span class="label">8.	İlgili satırda yer alan soruya ait bir açıklama alanı olup olmadığı bilgisini içerir.</span>
                                                            </li>
                                                            <li>
                                                                <span class="label">9.	İlgili satırda yer alan soruya ait açıklamanın zorunlu alan olup olmadığı bilgisini içerir.</span>
                                                            </li>
                                                            <li>
                                                                <span class="label">10.	İlgili satırda yer alan sorunun puanının görünür olup olmadığı bilgisini içerir.</span>
                                                            </li>
                                                            <li>
                                                                <span class="label">11.	İlgili satırda yer alan sorunun çoklu cevap olup olmayacağı bilgisini içerir.</span>
                                                            </li>
                                                            <li>
                                                                <span class="label">12.	Listede yer alan toplam kayıt ve toplam sayfa ile mevcut sayfa bilgilerinin gösterildiği bölümdür.</span>
                                                            </li>
                                                            <li>
                                                                <span class="label">13.	Sayfa içerisinde yer alan tüm menülerin kapanmasını sağlar. Kapalı menüler turuncu ile renklendirilir.</span>
                                                            </li>
                                                            <li>
                                                                <span class="label">14.	Sayfa içerisinde yer alan tüm menülerin açılmasını sağlar.</span>
                                                            </li>
                                                            <li>
                                                                <span class="label">15.	İlgili sayfayı favorilerinize ekler. Favori sayfalarınızı Profil sayfanızdan düzenleyebilirsiniz.</span>
                                                            </li>
                                                            <li>
                                                                <span class="label">16.	Sorunun bir üst öğesi olmak üzere, yeni bir Kategori eklemek için kullanılan bağlantıdır.</span>
                                                            </li>
                                                            <li>
                                                                <span class="label">17.	Sistemde tanımlı soru ve kategıriler arasında eşleştirme yaparak, birbirine bağlamak için kullanılan sayfaya giden bağlantıdır.</span>
                                                            </li>
                                                            <li>
                                                                <span class="label">18.	Yeni bir soru eklemek için kullanılan butondur. Bu butona basılması ile sayfanın üst kısmında yeni bir soru girişi yapmak için gerekli alanların yer aldığı bir bölüm açılacaktır. *</span>
                                                            </li>
                                                        </ul>
                                                        <br />
                                                        <br />
                                                        <img src="../Contents/Manual/Images/soru_yonetimi_2.png" alt="anasayfa" />
                                                        <br />
                                                        <span class="label">* : Yeni butonuna basılması ile birlikte, sayfanın üst kısmında yukarıdaki bölüm açılmaktadır.</span>
                                                        <br />
                                                        <br />
                                                        <ul style="list-style-type: none; margin: 0px; padding: 0px;">
                                                            <li>
                                                                <span class="label">1.	Oluşturulacak olan yeni soru için gerekli soru metninin girileceği alan.</span>
                                                            </li>
                                                            <li>
                                                                <span class="label">2.	Oluşturulacak olan yeni sorunun çoklu cevap olup olmayacağı bilgisinin seçileceği alan.</span>
                                                            </li>
                                                            <li>
                                                                <span class="label">3.	Oluşturulacak olan yeni sorunun puanının görünüp görünmeyeceği bilgisinin seçileceği alan.</span>
                                                            </li>
                                                            <li>
                                                                <span class="label">4.	Oluşturulacak olan yeni soruya ait bir açıklama alanı olup olmayacağı bilgisinin seçileceği alan.</span>
                                                            </li>
                                                            <li>
                                                                <span class="label">5.	Oluşturulacak olan yeni soruya ait açıklamanın zorunlu alan olup olmayacağı bilgisinin seçileceği alan.</span>
                                                            </li>
                                                            <li>
                                                                <span class="label">6.	Oluşturulacak olan yeni soruya eklenecek olan cevap için gerekli cevap metninin girileceği alan.</span>
                                                            </li>
                                                            <li>
                                                                <span class="label">7.	Oluşturulacak olan yeni soruya eklenecek olan cevabın puan bilgisinin girileceği alan.</span>
                                                            </li>
                                                            <li>
                                                                <span class="label">8.	Oluşturulacak olan yeni soruya eklenecek olan cevabın varsayılan olup olmayacağı bilgisinin seçileceği alan.</span>
                                                            </li>
                                                            <li>
                                                                <span class="label">9.	Oluşturulacak olan yeni soruya, gerekli bilgileri girdikten sonra (cevap metni, puanı) yeni cevap seçeneği eklemek için kullanılacak olan buton.</span>
                                                            </li>
                                                            <li>
                                                                <span class="label">10.	Girilen bilgilerle yeni soru oluşturmak için kullanılacak olan buton.</span>
                                                            </li>
                                                            <li>
                                                                <span class="label">11.	Soru oluşturma işlemini iptal edip, liste görüntüsüne geçmek için kullanılacak olan buton.</span>
                                                            </li>
                                                            <li>
                                                                <span class="label">12.	Oluşturulacak olan soruya eklenmiş olan cevapların liste halinde gösterildiği alan. *</span>
                                                            </li>
                                                        </ul>
                                                        <br />
                                                        <br />
                                                        <img src="../Contents/Manual/Images/soru_yonetimi_3.png" alt="anasayfa" />
                                                        <br />
                                                        <span class="label">* : Oluşturulacak olan soruya ait cevap listesinden herhangi bir cevap seçildiği zaman, cevaba ait bilgiler yukarıdaki alanlara şekilde gibi dolacaktır ve butonların açıklamaları ile fonksiyonaliteleri değişecektir.</span>
                                                        <br />
                                                        <br />
                                                        <ul style="list-style-type: none; margin: 0px; padding: 0px;">
                                                            <li>
                                                                <span class="label">1.	Seçili cevap üzerinde yaptığınız değişiklikleri uygulayıp, düzenleme modundan çıkmak için kullanılacak olan butondur.</span>
                                                            </li>
                                                            <li>
                                                                <span class="label">2.	Seçili cevabı silmek için kullanılacak olan butondur.</span>
                                                            </li>
                                                            <li>
                                                                <span class="label">3.	Seçili cevap üzerinde yaptığınız değişikliklerden vazgeçip, düzenleme modundan çıkmak için kullanılacan olan butondur.</span>
                                                            </li>
                                                            <li>
                                                                <span class="label">4.	Soruya eklenmiş olan cevaplardan her birisidir.</span>
                                                            </li>
                                                            <li>
                                                                <span class="label">5.	Soruya eklenmiş olan cevaplardan biri olup, seçilerek, bilgilerinin üst tarafa dolması sağlanmıştır. Aynı zamanda varsayılan cevap olarak işaretlenmiştir.</span>
                                                            </li>
                                                        </ul>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="g_12">
                                            <a name="#3_7"></a>
                                            <div class="widget_header">
                                                <h4 class="widget_header_title wwIcon i_16_forms">Form - Bölüm Eşleştirme</h4>
                                            </div>
                                            <div class="widget_contents noPadding">
                                                <div class="line_grid">
                                                    <div class="g_3">
                                                        <img src="../Contents/Manual/Images/form_bolum_eslestirme.png" alt="anasayfa" />
                                                        <br />
                                                        <br />
                                                        <ul style="list-style-type: none; margin: 0px; padding: 0px;">
                                                            <li>
                                                                <span class="label">1.	Eşleştirilerek bölümlerle bağlanacak olan form seçimi için kullanılan alandır.</span>
                                                            </li>
                                                            <li>
                                                                <span class="label">2.	Sistemde yer alan ve seçili form ile eşleştirilmemiş tüm bölümlerin listelendiği alandır.</span>
                                                            </li>
                                                            <li>
                                                                <span class="label">3.	Seçili olan forma eklenebilecek olan bölümlerin her birisidir. Eşleştirmek için sol tarafındaki kutucuklar işaretlenmelidir.</span>
                                                            </li>
                                                            <li>
                                                                <span class="label">4.	Seçili olan form ile, işaretlenmiş bölümlerin eşleştirilmesi için kullanılacak olan butondur. Üst listede herhangi bir bölümün seçilmemesi durumunda, bu buton deaktif olacaktır.</span>
                                                            </li>
                                                            <li>
                                                                <span class="label">5.	Seçili olan form ile önceden eşleştirilmiş olan alt listeden seçili bölümün çıkarılması için kullanılacak olan butondur. Alt listede herhangi bir bölümün seçilmemesi durumunda, bu buton deaktif olacaktır.</span>
                                                            </li>
                                                            <li>
                                                                <span class="label">6.	Seçili olan form ile önceden eşleştirilmiş olan tüm bölümlerin listelendiği alandır.</span>
                                                            </li>
                                                            <li>
                                                                <span class="label">7.	Seçili olan form ile önceden eşleştirilmiş bölümlerin her birisidir. Eşleştirmeyi iptal edip, seçili formdan çıkarmak için, sol tarafındaki kutucuklar işaretlenmelidir.</span>
                                                            </li>
                                                            <li>
                                                                <span class="label">8.	Seçili olan forma yönelik ilgili eşleştirmelerin kalıcı olarak kaydedilmesi için kullanılacak olan butondur.</span>
                                                            </li>
                                                        </ul>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="g_12">
                                            <a name="#3_8"></a>
                                            <div class="widget_header">
                                                <h4 class="widget_header_title wwIcon i_16_forms">Bölüm - Kategori Eşleştirme</h4>
                                            </div>
                                            <div class="widget_contents noPadding">
                                                <div class="line_grid">
                                                    <div class="g_3">
                                                        <img src="../Contents/Manual/Images/bolum_kategori_eslestirme.png" alt="anasayfa" />
                                                        <br />
                                                        <br />
                                                        <ul style="list-style-type: none; margin: 0px; padding: 0px;">
                                                            <li>
                                                                <span class="label">1.	Eşleştirilerek kategorilerle bağlanacak olan bölüm seçimi için kullanılan alandır.</span>
                                                            </li>
                                                            <li>
                                                                <span class="label">2.	Sistemde yer alan ve seçili bölüm ile eşleştirilmemiş tüm kategorilerin listelendiği alandır.</span>
                                                            </li>
                                                            <li>
                                                                <span class="label">3.	Seçili olan bölüme eklenebilecek olan kategorilerin her birisidir. Eşleştirmek için sol tarafındaki kutucuklar işaretlenmelidir.</span>
                                                            </li>
                                                            <li>
                                                                <span class="label">4.	Seçili olan bölüm ile, işaretlenmiş kategorilerin eşleştirilmesi için kullanılacak olan butondur. Üst listede herhangi bir kategorinin seçilmemesi durumunda, bu buton deaktif olacaktır.</span>
                                                            </li>
                                                            <li>
                                                                <span class="label">5.	Seçili olan bölüm ile önceden eşleştirilmiş olan alt listeden seçili kategorinin çıkarılması için kullanılacak olan butondur. Alt listede herhangi bir kategorinin seçilmemesi durumunda, bu buton deaktif olacaktır.</span>
                                                            </li>
                                                            <li>
                                                                <span class="label">6.	Seçili olan bölüm ile önceden eşleştirilmiş olan tüm kategorilerin listelendiği alandır.</span>
                                                            </li>
                                                            <li>
                                                                <span class="label">7.	Seçili olan bölüm ile önceden eşleştirilmiş kategorilerin her birisidir. Eşleştirmeyi iptal edip, seçili bölümden çıkarmak için, sol tarafındaki kutucuklar işaretlenmelidir.</span>
                                                            </li>
                                                            <li>
                                                                <span class="label">8.	Seçili olan bölüme yönelik ilgili eşleştirmelerin kalıcı olarak kaydedilmesi için kullanılacak olan butondur.</span>
                                                            </li>
                                                        </ul>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="g_12">
                                            <a name="#3_9"></a>
                                            <div class="widget_header">
                                                <h4 class="widget_header_title wwIcon i_16_forms">Kategori - Soru Eşleştirme</h4>
                                            </div>
                                            <div class="widget_contents noPadding">
                                                <div class="line_grid">
                                                    <div class="g_3">
                                                        <img src="../Contents/Manual/Images/kategori_soru_eslestirme.png" alt="anasayfa" />
                                                        <br />
                                                        <br />
                                                        <ul style="list-style-type: none; margin: 0px; padding: 0px;">
                                                            <li>
                                                                <span class="label">1.	Eşleştirilerek sorularla bağlanacak olan kategori seçimi için kullanılan alandır.</span>
                                                            </li>
                                                            <li>
                                                                <span class="label">2.	Sistemde yer alan ve seçili kategori ile eşleştirilmemiş tüm soruların listelendiği alandır.</span>
                                                            </li>
                                                            <li>
                                                                <span class="label">3.	Seçili olan kategoriye eklenebilecek olan soruların her birisidir. Eşleştirmek için sol tarafındaki kutucuklar işaretlenmelidir.</span>
                                                            </li>
                                                            <li>
                                                                <span class="label">4.	Seçili olan kategoriile, işaretlenmiş soruların eşleştirilmesi için kullanılacak olan butondur. Üst listede herhangi bir sorunun seçilmemesi durumunda, bu buton deaktif olacaktır.</span>
                                                            </li>
                                                            <li>
                                                                <span class="label">5.	Seçili olan kategori ile önceden eşleştirilmiş olan alt listeden seçili soruların çıkarılması için kullanılacak olan butondur. Alt listede herhangi bir sorunun seçilmemesi durumunda, bu buton deaktif olacaktır.</span>
                                                            </li>
                                                            <li>
                                                                <span class="label">6.	Seçili olan kategori ile önceden eşleştirilmiş olan tüm soruların listelendiği alandır.</span>
                                                            </li>
                                                            <li>
                                                                <span class="label">7.	Seçili olan kategori ile önceden eşleştirilmiş soruların her birisidir. Eşleştirmeyi iptal edip, seçili bölümden çıkarmak için, sol tarafındaki kutucuklar işaretlenmelidir.</span>
                                                            </li>
                                                            <li>
                                                                <span class="label">8.	Seçili olan kategoriye yönelik ilgili eşleştirmelerin kalıcı olarak kaydedilmesi için kullanılacak olan butondur.</span>
                                                            </li>
                                                        </ul>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="g_12">
                                            <a name="#3_10"></a>
                                            <div class="widget_header">
                                                <h4 class="widget_header_title wwIcon i_16_forms">Form Ayarları</h4>
                                            </div>
                                            <div class="widget_contents noPadding">
                                                <div class="line_grid">
                                                    <div class="g_3">
                                                        <img src="../Contents/Manual/Images/form_ayarlari_1.png" alt="anasayfa" />
                                                        <br />
                                                        <br />
                                                        <ul style="list-style-type: none; margin: 0px; padding: 0px;">
                                                            <li>
                                                                <span class="label">1.	Bulunduğunuz sayfayı belirtir. Bu alan, tüm sayfalarda yer almakta ve sayfanın içeriği ile ilgili genel ve kısa bir açıklamaya sahiptir.</span>
                                                            </li>
                                                            <li>
                                                                <span class="label">2.	Bu buton yardımıyla, sayfa ile ilgili sık kullanılan işlemler yapılabilir, sayfa ile ilişkili diğer sayfalara geçiş için kullanılabilir.</span>
                                                            </li>
                                                            <li>
                                                                <span class="label">3.	Sayfa ile ilgili yardım dökümanını açar.</span>
                                                            </li>
                                                            <li>
                                                                <span class="label">4.	İlgili ayarın uygulanacağı form seçimi için kullanılacak alandır.</span>
                                                            </li>
                                                            <li>
                                                                <span class="label">5.	Seçilmiş olan form ile ilgili ayarların yapılacağı soruları listelemek için gerekli bölüm seçim alanıdır.</span>
                                                            </li>
                                                            <li>
                                                                <span class="label">6.	Seçilmiş olan bölüme ait bilgilerin gösterildiği alandır. Buradan değişiklik yapılması mümkün değildir.</span>
                                                            </li>
                                                            <li>
                                                                <span class="label">7.	Seçilmiş olan form ile ilgili ayarların yapılacağı soruları listelemek için gerekli kategori seçim alanıdır.</span>
                                                            </li>
                                                            <li>
                                                                <span class="label">8.	Seçilmiş olan kategoriye ait bilgilerin gösterildiği alandır. Buradan değişiklik yapılması mümkün değildir.</span>
                                                            </li>
                                                            <li>
                                                                <span class="label">9.	Sayfa içerisinde yer alan tüm menülerin kapanmasını sağlar. Kapalı menüler turuncu ile renklendirilir.</span>
                                                            </li>
                                                            <li>
                                                                <span class="label">10.	Sayfa içerisinde yer alan tüm menülerin açılmasını sağlar.</span>
                                                            </li>
                                                            <li>
                                                                <span class="label">11.	İlgili sayfayı favorilerinize ekler. Favori sayfalarınızı Profil sayfanızdan düzenleyebilirsiniz.</span>
                                                            </li>
                                                        </ul>
                                                        <br />
                                                        <br />
                                                        <img src="../Contents/Manual/Images/form_ayarlari_2.png" alt="anasayfa" />
                                                        <br />
                                                        <br />
                                                        <ul style="list-style-type: none; margin: 0px; padding: 0px;">
                                                            <li>
                                                                <span class="label">1.	Seçili olan forma yönelik yapılacak ayar için gerekli sorunun seçim alanı.</span>
                                                            </li>
                                                            <li>
                                                                <span class="label">2.	Soruya ait cevapların listelendiği alan. Yapılacak olan ayarın hangi cevaba istinaden uygulanacağını belirlemek için bir cevap seçilmesi gerekmektedir.</span>
                                                            </li>
                                                            <li>
                                                                <span class="label">3.	Seçilen soru ve cevaba göre, bölümlere yönelik yapılacak ayar için gerekli bölümlerin listesi.</span>
                                                            </li>
                                                            <li>
                                                                <span class="label">4.	Yapılacak olan ayarın uygulanacağı bölüme ait isim bilgisini içeren alan.</span>
                                                            </li>
                                                            <li>
                                                                <span class="label">5.	Seçilen soru ve cevaba göre, ilgili bölümün, başlangıç durumuna göre (açık/kapalı) aksi yönde bir işlem yapılıp yapılmayacağı bilgisini içeren alan.</span>
                                                            </li>
                                                            <li>
                                                                <span class="label">6.	Seçilen soru ve cevaba göre, ilgili bölüme ait puanların sıfırlanıp sıfırlanmayacağı bilgisini içeren alan.</span>
                                                            </li>
                                                            <li>
                                                                <span class="label">7.	Seçilen soru ve cevaba göre, kategorilere yönelik yapılacak ayar için gerekli kategorilerin listesi.</span>
                                                            </li>
                                                            <li>
                                                                <span class="label">8.	Yapılacak olan ayarın uygulanacağı kategoriye ait isim bilgisini içeren alan.</span>
                                                            </li>
                                                            <li>
                                                                <span class="label">9.	Seçilen soru ve cevaba göre, ilgili kategorinin, başlangıç durumuna göre (açık/kapalı) aksi yönde bir işlem yapılıp yapılmayacağı bilgisini içeren alan.</span>
                                                            </li>
                                                            <li>
                                                                <span class="label">10.	Seçilen soru ve cevaba göre, ilgili kategoriye ait puanların sıfırlanıp sıfırlanmayacağı bilgisini içeren alan.</span>
                                                            </li>
                                                            <li>
                                                                <span class="label">11.	Yapılacak olan ayarın uygulanayacağı soruya ait soru metni bilgisini içeren alan.</span>
                                                            </li>
                                                            <li>
                                                                <span class="label">12.	Seçilen soru ve cevaba göre, ilgili sorunun, başlangıç durumuna göre (açık/kapalı) aksi yönde bir işlem yapılıp yapılmayacağı bilgisini içeren alan.</span>
                                                            </li>
                                                            <li>
                                                                <span class="label">13.	Seçilen soru ve cevaba göre, ilgili soruya ait puanın sıfırlanıp sıfırlanmayacağı bilgisini içeren alan.</span>
                                                            </li>
                                                            <li>
                                                                <span class="label">14.	Yapılan seçimlerin, kaydedilerek kalıcı hale gelmesi için kullanılan buton.</span>
                                                            </li>
                                                        </ul>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="g_12">
                                            <a name="#3_11"></a>
                                            <div class="widget_header">
                                                <h4 class="widget_header_title wwIcon i_16_forms">Lokasyon Yönetimi</h4>
                                            </div>
                                            <div class="widget_contents noPadding">
                                                <div class="line_grid">
                                                    <div class="g_3">
                                                        <img src="../Contents/Manual/Images/lokasyon_yonetimi_1.png" alt="anasayfa" />
                                                        <br />
                                                        <br />
                                                        <ul style="list-style-type: none; margin: 0px; padding: 0px;">
                                                            <li>
                                                                <span class="label">1.	Bulunduğunuz sayfayı belirtir. Bu alan, tüm sayfalarda yer almakta ve sayfanın içeriği ile ilgili genel ve kısa bir açıklamaya sahiptir.</span>
                                                            </li>
                                                            <li>
                                                                <span class="label">2.	Bu buton yardımıyla, sayfa ile ilgili sık kullanılan işlemler yapılabilir, sayfa ile ilişkili diğer sayfalara geçiş için kullanılabilir.</span>
                                                            </li>
                                                            <li>
                                                                <span class="label">3.	Sayfa ile ilgili yardım dökümanını açar.</span>
                                                            </li>
                                                            <li>
                                                                <span class="label">4.	Sistemde tanımlı lokasyonların liste halinde gösterildiği bölümdür.</span>
                                                            </li>
                                                            <li>
                                                                <span class="label">5.	İlgili satırda yer alan lokasyonu düzenlemek için kullanılan bağlantıdır.</span>
                                                            </li>
                                                            <li>
                                                                <span class="label">6.	İlgili satırda yer alan lokasyonu silmek için kullanılan bağlantıdır.</span>
                                                            </li>
                                                            <li>
                                                                <span class="label">7.	İlgili satırda yer alan lokasyonun isim bilgisini içerir.</span>
                                                            </li>
                                                            <li>
                                                                <span class="label">8.	Listede yer alan toplam kayıt ve toplam sayfa ile mevcut sayfa bilgilerinin gösterildiği bölümdür.</span>
                                                            </li>
                                                            <li>
                                                                <span class="label">9.	Sayfa içerisinde yer alan tüm menülerin kapanmasını sağlar. Kapalı menüler turuncu ile renklendirilir.</span>
                                                            </li>
                                                            <li>
                                                                <span class="label">10.	Sayfa içerisinde yer alan tüm menülerin açılmasını sağlar.</span>
                                                            </li>
                                                            <li>
                                                                <span class="label">11.	İlgili sayfayı favorilerinize ekler. Favori sayfalarınızı Profil sayfanızdan düzenleyebilirsiniz.</span>
                                                            </li>
                                                            <li>
                                                                <span class="label">12.	Lokasyonun bir alt öğesi olmak üzere, yeni bir Grup eklemek için kullanılan bağlantıdır.</span>
                                                            </li>
                                                            <li>
                                                                <span class="label">13.	Grubun bir alt öğesi olmak üzere, yeni bir Takım eklemek için kullanılan bağlantıdır.</span>
                                                            </li>
                                                            <li>
                                                                <span class="label">14.	Takımın bir alt öğesi olmak üzere, yeni bir Kullanıcı eklemek için kullanılan bağlantıdır.</span>
                                                            </li>
                                                            <li>
                                                                <span class="label">15.	Yeni bir lokasyon eklemek için kullanılan butondur. Bu butona basılması ile sayfanın üst kısmında yeni bir lokasyon girişi yapmak için gerekli alanların yer aldığı bir bölüm açılacaktır. *</span>
                                                            </li>
                                                        </ul>
                                                        <br />
                                                        <br />
                                                        <img src="../Contents/Manual/Images/lokasyon_yonetimi_2.png" alt="anasayfa" />
                                                        <br />
                                                        <span class="label">* : Yeni butonuna basılması ile birlikte, sayfanın üst kısmında yukarıdaki bölüm açılmaktadır.</span>
                                                        <br />
                                                        <br />
                                                        <ul style="list-style-type: none; margin: 0px; padding: 0px;">
                                                            <li>
                                                                <span class="label">1.	Oluşturulacak olan yeni kategori için gerekli isim bilgisinin girileceği alan.</span>
                                                            </li>
                                                            <li>
                                                                <span class="label">2.	Girilen bilgilerle yeni lokasyon oluşturmak için kullanılacak olan buton.</span>
                                                            </li>
                                                            <li>
                                                                <span class="label">3.	Girilen bilgilerin tümünü silmek için kullanılacak olan buton.</span>
                                                            </li>
                                                            <li>
                                                                <span class="label">4.	Lokasyon oluşturma işlemini iptal edip, liste görüntüsüne geçmek için kullanılacak olan buton.</span>
                                                            </li>
                                                        </ul>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="g_12">
                                            <a name="#3_12"></a>
                                            <div class="widget_header">
                                                <h4 class="widget_header_title wwIcon i_16_forms">Grup Yönetimi</h4>
                                            </div>
                                            <div class="widget_contents noPadding">
                                                <div class="line_grid">
                                                    <div class="g_3">
                                                        <img src="../Contents/Manual/Images/grup_yonetimi_1.png" alt="anasayfa" />
                                                        <br />
                                                        <br />
                                                        <ul style="list-style-type: none; margin: 0px; padding: 0px;">
                                                            <li>
                                                                <span class="label">1.	Bulunduğunuz sayfayı belirtir. Bu alan, tüm sayfalarda yer almakta ve sayfanın içeriği ile ilgili genel ve kısa bir açıklamaya sahiptir.</span>
                                                            </li>
                                                            <li>
                                                                <span class="label">2.	Bu buton yardımıyla, sayfa ile ilgili sık kullanılan işlemler yapılabilir, sayfa ile ilişkili diğer sayfalara geçiş için kullanılabilir.</span>
                                                            </li>
                                                            <li>
                                                                <span class="label">3.	Sayfa ile ilgili yardım dökümanını açar.</span>
                                                            </li>
                                                            <li>
                                                                <span class="label">4.	Sistemde tanımlı grupların liste halinde gösterildiği bölümdür.</span>
                                                            </li>
                                                            <li>
                                                                <span class="label">5.	İlgili satırda yer alan grubu düzenlemek için kullanılan bağlantıdır.</span>
                                                            </li>
                                                            <li>
                                                                <span class="label">6.	İlgili satırda yer alan grubu silmek için kullanılan bağlantıdır.</span>
                                                            </li>
                                                            <li>
                                                                <span class="label">7.	İlgili satırda yer alan grubun isim bilgisini içerir.</span>
                                                            </li>
                                                            <li>
                                                                <span class="label">8.	İlgili satırda yer alan grubun bağlı olduğu lokasyon bilgisini içerir.</span>
                                                            </li>
                                                            <li>
                                                                <span class="label">9.	İlgili satırda yer alan grubun, grup lideri bilgisini içerir.</span>
                                                            </li>
                                                            <li>
                                                                <span class="label">10.	Listede yer alan toplam kayıt ve toplam sayfa ile mevcut sayfa bilgilerinin gösterildiği bölümdür.</span>
                                                            </li>
                                                            <li>
                                                                <span class="label">11.	Sayfa içerisinde yer alan tüm menülerin kapanmasını sağlar. Kapalı menüler turuncu ile renklendirilir.</span>
                                                            </li>
                                                            <li>
                                                                <span class="label">12.	Sayfa içerisinde yer alan tüm menülerin açılmasını sağlar.</span>
                                                            </li>
                                                            <li>
                                                                <span class="label">13.	İlgili sayfayı favorilerinize ekler. Favori sayfalarınızı Profil sayfanızdan düzenleyebilirsiniz.</span>
                                                            </li>
                                                            <li>
                                                                <span class="label">14.	Grubun bir üst öğesi olmak üzere, yeni bir Lokasyon eklemek için kullanılan bağlantıdır.</span>
                                                            </li>
                                                            <li>
                                                                <span class="label">15.	Grubun bir alt öğesi olmak üzere, yeni bir Takım eklemek için kullanılan bağlantıdır.</span>
                                                            </li>
                                                            <li>
                                                                <span class="label">16.	Yeni bir grup eklemek için kullanılan butondur. Bu butona basılması ile sayfanın üst kısmında yeni bir grup girişi yapmak için gerekli alanların yer aldığı bir bölüm açılacaktır. *</span>
                                                            </li>
                                                        </ul>
                                                        <br />
                                                        <br />
                                                        <img src="../Contents/Manual/Images/grup_yonetimi_2.png" alt="anasayfa" />
                                                        <br />
                                                        <span class="label">* : Yeni butonuna basılması ile birlikte, sayfanın üst kısmında yukarıdaki bölüm açılmaktadır.</span>
                                                        <br />
                                                        <br />
                                                        <ul style="list-style-type: none; margin: 0px; padding: 0px;">
                                                            <li>
                                                                <span class="label">1.	Oluşturulacak olan yeni grup için gerekli isim bilgisinin girileceği alan.</span>
                                                            </li>
                                                            <li>
                                                                <span class="label">2.	Oluşturulacak olan yeni grubun bağlı olacağı lokasyon bilgisinin seçileceği alan.</span>
                                                            </li>
                                                            <li>
                                                                <span class="label">3.	Oluşturulacak olan yeni grubun, grup lideri bilgisinin seçileceği alan.</span>
                                                            </li>
                                                            <li>
                                                                <span class="label">4.	Girilen bilgilerle yeni grup oluşturmak için kullanılacak olan buton.</span>
                                                            </li>
                                                            <li>
                                                                <span class="label">5.	Girilen bilgilerin tümünü silmek için kullanılacak olan buton.</span>
                                                            </li>
                                                            <li>
                                                                <span class="label">6.	Grup oluşturma işlemini iptal edip, liste görüntüsüne geçmek için kullanılacak olan buton.</span>
                                                            </li>
                                                        </ul>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="g_12">
                                            <a name="#3_13"></a>
                                            <div class="widget_header">
                                                <h4 class="widget_header_title wwIcon i_16_forms">Takım Yönetimi</h4>
                                            </div>
                                            <div class="widget_contents noPadding">
                                                <div class="line_grid">
                                                    <div class="g_3">
                                                        <img src="../Contents/Manual/Images/takim_yonetimi_1.png" alt="anasayfa" />
                                                        <br />
                                                        <br />
                                                        <ul style="list-style-type: none; margin: 0px; padding: 0px;">
                                                            <li>
                                                                <span class="label">1.	Bulunduğunuz sayfayı belirtir. Bu alan, tüm sayfalarda yer almakta ve sayfanın içeriği ile ilgili genel ve kısa bir açıklamaya sahiptir.</span>
                                                            </li>
                                                            <li>
                                                                <span class="label">2.	Bu buton yardımıyla, sayfa ile ilgili sık kullanılan işlemler yapılabilir, sayfa ile ilişkili diğer sayfalara geçiş için kullanılabilir.</span>
                                                            </li>
                                                            <li>
                                                                <span class="label">3.	Sayfa ile ilgili yardım dökümanını açar.</span>
                                                            </li>
                                                            <li>
                                                                <span class="label">4.	Sistemde tanımlı takımların liste halinde gösterildiği bölümdür.</span>
                                                            </li>
                                                            <li>
                                                                <span class="label">5.	İlgili satırda yer alan takımı düzenlemek için kullanılan bağlantıdır.</span>
                                                            </li>
                                                            <li>
                                                                <span class="label">6.	İlgili satırda yer alan takımı silmek için kullanılan bağlantıdır.</span>
                                                            </li>
                                                            <li>
                                                                <span class="label">7.	İlgili satırda yer alan takımın isim bilgisini içerir.</span>
                                                            </li>
                                                            <li>
                                                                <span class="label">8.	İlgili satırda yer alan takımın bağlı olduğu grup bilgisini içerir.</span>
                                                            </li>
                                                            <li>
                                                                <span class="label">9.	İlgili satırda yer alan takımın, takım lideri bilgisini içerir.</span>
                                                            </li>
                                                            <li>
                                                                <span class="label">10.	Listede yer alan toplam kayıt ve toplam sayfa ile mevcut sayfa bilgilerinin gösterildiği bölümdür.</span>
                                                            </li>
                                                            <li>
                                                                <span class="label">11.	Sayfa içerisinde yer alan tüm menülerin kapanmasını sağlar. Kapalı menüler turuncu ile renklendirilir.</span>
                                                            </li>
                                                            <li>
                                                                <span class="label">12.	Sayfa içerisinde yer alan tüm menülerin açılmasını sağlar.</span>
                                                            </li>
                                                            <li>
                                                                <span class="label">13.	İlgili sayfayı favorilerinize ekler. Favori sayfalarınızı Profil sayfanızdan düzenleyebilirsiniz.</span>
                                                            </li>
                                                            <li>
                                                                <span class="label">14.	Takımın bir üst öğesi olmak üzere, yeni Grup eklemek için kullanılan bağlantıdır.</span>
                                                            </li>
                                                            <li>
                                                                <span class="label">15.	Takımın bir alt öğesi olmak üzere, yeni Kullanıcı eklemek için kullanılan bağlantıdır.</span>
                                                            </li>
                                                            <li>
                                                                <span class="label">16.	Yeni bir bölüm eklemek için kullanılan butondur. Bu butona basılması ile sayfanın üst kısmında yeni bir bölüm girişi yapmak için gerekli alanların yer aldığı bir bölüm açılacaktır. *</span>
                                                            </li>
                                                        </ul>
                                                        <br />
                                                        <br />
                                                        <img src="../Contents/Manual/Images/takim_yonetimi_2.png" alt="anasayfa" />
                                                        <br />
                                                        <span class="label">* : Yeni butonuna basılması ile birlikte, sayfanın üst kısmında yukarıdaki bölüm açılmaktadır.</span>
                                                        <br />
                                                        <br />
                                                        <ul style="list-style-type: none; margin: 0px; padding: 0px;">
                                                            <li>
                                                                <span class="label">1.	Oluşturulacak olan yeni takım için gerekli isim bilgisinin girileceği alan.</span>
                                                            </li>
                                                            <li>
                                                                <span class="label">2.	Oluşturulacak olan yeni takımın, takım lideri bilgisinin seçileceği alan.</span>
                                                            </li>
                                                            <li>
                                                                <span class="label">3.	Oluşturulacak olan yeni takımın, bağlı olacağı grup bilgisinin seçileceği alan.</span>
                                                            </li>
                                                            <li>
                                                                <span class="label">4.	Girilen bilgilerle yeni takım oluşturmak için kullanılacak olan buton.</span>
                                                            </li>
                                                            <li>
                                                                <span class="label">5.	Girilen bilgilerin tümünü silmek için kullanılacak olan buton.</span>
                                                            </li>
                                                            <li>
                                                                <span class="label">6.	Takım oluşturma işlemini iptal edip, liste görüntüsüne geçmek için kullanılacak olan buton.</span>
                                                            </li>
                                                        </ul>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="g_12">
                                            <a name="#3_14"></a>
                                            <div class="widget_header">
                                                <h4 class="widget_header_title wwIcon i_16_forms">Kullanıcı Yönetimi</h4>
                                            </div>
                                            <div class="widget_contents noPadding">
                                                <div class="line_grid">
                                                    <div class="g_3">
                                                        <img src="../Contents/Manual/Images/kullanici_yonetimi_1.png" alt="anasayfa" />
                                                        <br />
                                                        <br />
                                                        <ul style="list-style-type: none; margin: 0px; padding: 0px;">
                                                            <li>
                                                                <span class="label">1.	Bulunduğunuz sayfayı belirtir. Bu alan, tüm sayfalarda yer almakta ve sayfanın içeriği ile ilgili genel ve kısa bir açıklamaya sahiptir.</span>
                                                            </li>
                                                            <li>
                                                                <span class="label">2.	Bu buton yardımıyla, sayfa ile ilgili sık kullanılan işlemler yapılabilir, sayfa ile ilişkili diğer sayfalara geçiş için kullanılabilir.</span>
                                                            </li>
                                                            <li>
                                                                <span class="label">3.	Sayfa ile ilgili yardım dökümanını açar.</span>
                                                            </li>
                                                            <li>
                                                                <span class="label">4.	Sistemde tanımlı kullanıcıların liste halinde gösterildiği bölümdür.</span>
                                                            </li>
                                                            <li>
                                                                <span class="label">5.	İlgili satırda yer alan kullanıcıyı düzenlemek için kullanılan bağlantıdır.</span>
                                                            </li>
                                                            <li>
                                                                <span class="label">6.	İlgili satırda yer alan kullanıcıyı silmek için kullanılan bağlantıdır.</span>
                                                            </li>
                                                            <li>
                                                                <span class="label">7.	İlgili satırda yer alan kullanıcının ad bilgisini içerir.</span>
                                                            </li>
                                                            <li>
                                                                <span class="label">8.	İlgili satırda yer alan kullanıcının soyad bilgisini içerir.</span>
                                                            </li>
                                                            <li>
                                                                <span class="label">9.	İlgili satırda yer alan kullanıcının sicil numarası bilgisini içerir.</span>
                                                            </li>
                                                            <li>
                                                                <span class="label">10.	İlgili satırda yer alan kullanıcının bağlı olduğu takım bilgisini içerir.</span>
                                                            </li>
                                                            <li>
                                                                <span class="label">11.	Listede yer alan toplam kayıt ve toplam sayfa ile mevcut sayfa bilgilerinin gösterildiği bölümdür.</span>
                                                            </li>
                                                            <li>
                                                                <span class="label">11.	Listede yer alan toplam kayıt ve toplam sayfa ile mevcut sayfa bilgilerinin gösterildiği bölümdür.</span>
                                                            </li>
                                                            <li>
                                                                <span class="label">13.	Sayfa içerisinde yer alan tüm menülerin açılmasını sağlar.</span>
                                                            </li>
                                                            <li>
                                                                <span class="label">14.	İlgili sayfayı favorilerinize ekler. Favori sayfalarınızı Profil sayfanızdan düzenleyebilirsiniz.</span>
                                                            </li>
                                                            <li>
                                                                <span class="label">15.	Yeni bir kullanıcı eklemek için kullanılan butondur. Bu butona basılması ile sayfanın üst kısmında yeni bir kullanıcı girişi yapmak için gerekli alanların yer aldığı bir bölüm açılacaktır. *</span>
                                                            </li>
                                                        </ul>
                                                        <br />
                                                        <br />
                                                        <img src="../Contents/Manual/Images/kullanici_yonetimi_2.png" alt="anasayfa" />
                                                        <br />
                                                        <span class="label">* : Yeni butonuna basılması ile birlikte, sayfanın üst kısmında yukarıdaki bölüm açılmaktadır.</span>
                                                        <br />
                                                        <br />
                                                        <ul style="list-style-type: none; margin: 0px; padding: 0px;">
                                                            <li>
                                                                <span class="label">1.	Oluşturulacak olan yeni kullanıcı için gerekli ad bilgisinin girileceği alan.</span>
                                                            </li>
                                                            <li>
                                                                <span class="label">2.	Oluşturulacak olan yeni kullanıcı için gerekli soyad bilgisinin girileceği alan.</span>
                                                            </li>
                                                            <li>
                                                                <span class="label">3.	Oluşturulacak olan yeni kullanıcı için gerekli rol bilgisinin seçileceği alan. Seçilen role göre, hemen altında yer alan sayfalara yetkiler tanımlanacaktır.</span>
                                                            </li>
                                                            <li>
                                                                <span class="label">4.	Oluşturulacak olan yeni kullanıcı için gerekli login id bilgisinin girileceği alan. </span>
                                                            </li>
                                                            <li>
                                                                <span class="label">5.	Oluşturulacak olan yeni kullanıcı için gerekli sicil numarası bilgisinin girileceği alan. </span>
                                                            </li>
                                                            <li>
                                                                <span class="label">6.	Oluşturulacak olan yeni kullanıcının bağlı olacağı takım bilgisinin seçileceği alan.</span>
                                                            </li>
                                                            <li>
                                                                <span class="label">7.	Oluşturulacak olan yeni kullanıcının sayfa yetkilerinin listelendiği alan. Üst tarafta yer alan rol seçimine göre farklı sayfalar varsayılan olarak işaretlenecektir.</span>
                                                            </li>
                                                            <li>
                                                                <span class="label">8.	Girilen bilgilerle yeni kullanıcı oluşturmak için kullanılacak olan buton.</span>
                                                            </li>
                                                            <li>
                                                                <span class="label">9.	Girilen bilgilerin tümünü silmek için kullanılacak olan buton.</span>
                                                            </li>
                                                            <li>
                                                                <span class="label">10.	Kullanıcı oluşturma işlemini iptal edip, liste görüntüsüne geçmek için kullanılacak olan buton.</span>
                                                            </li>
                                                        </ul>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <footer>
			<div class="wrapper">
				<a href="http://www.empatel.com.tr/" target="_blank">
                <img src="/Contents/Images/empatel.png" alt="Empatel" /></a>
			</div>
		</footer>
    </form>
</body>
</html>
