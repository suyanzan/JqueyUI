<%@ Page Language="C#" AutoEventWireup="true" CodeFile="JQUERY_UI_TESR.aspx.cs" Inherits="JQUERY_UI_TESR" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
        <script src="Scripts/jquery.min.js"></script>
    <script  src="Scripts/jquery-ui.js"></script>
    <link href="Scripts/jquery-ui.css" rel="stylesheet" />
    <title></title>
</head>
<script>
    function ShowPopupConfirm(message) {
        $(function () {
            $("#dialog-confirm").dialog({
                resizable: false,
                height: "auto",
                width: 400,
                modal: true,
                buttons: {
                    "Confirm": function () {
                        $(this).dialog("close");
                        $("#Button2").hide();
                        Button2.click();
                        //$("#Button2").hide();
                        //__doPostBack('<%=Button1.ClientID %>', "OnClick");
                    },
                    Cancel: function () {
                        $(this).dialog("close");
                        $("#Button2").hide();
                    }
                }
            });
        });
    };
    function ShowPopup(message) {
        $(function () {
        $("#dialog-message").html(message);
        $( "#dialog-message" ).dialog({
          modal: true,
          title: "Error",
          buttons: {
            Ok: function() {
              $( this ).dialog( "close" );
            }
          }
        });
      } );
    };
</script>
<body>
    <div id="dialog-confirm" title="Empty the recycle bin?" style="display: none">
    <p><span class="ui-icon ui-icon-alert" style="float:left; margin:12px 12px 20px 0;"></span>Do you sure layer choosed to create?</p>
    </div>
    <form id="form1" runat="server">
    <div>
        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox><asp:Button ID="Button1" runat="server" Text="Button" OnClick="Button1_Click"  />
    </div>
    <div style="position: absolute;  bottom: 0;" ><asp:Button ID="Button2" runat="server" Text="Button"  OnClick="Button2_Click" Visible="False" /></div>
    <div id="dialog-message" style="display: none">
    </div>
    </form>
</body>

</html>
