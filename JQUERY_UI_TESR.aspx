<%@ Page Language="C#" AutoEventWireup="true" CodeFile="JQUERY_UI_TESR.aspx.cs" Inherits="JQUERY_UI_TESR" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
        <script src="Scripts/jquery.min.js"></script>
    <script  src="Scripts/jquery-ui.js"></script>
    <link href="Scripts/jquery-ui.css" rel="stylesheet" />
    <title></title>
    <style>
        .hidden
        {
        display:none;
        }   
    </style>
</head>
<script>
    //var fso = new ActiveXObject("Scripting.FileSystemObject");
    //var f1 = fso.OpenTextFile("I:\RD73.CTOC", true);
    //alert("File last modified: " + f1.DateLastModified);
    function showBlockUI() {
        $.blockUI({
            message: '<table><tr><td valign="middle" style="height:50px" class="main"><img src="Img/ajax-loader.gif" /> 處理中,請稍候...</td></tr></table>',
            css: {
                width: '265px',
                height: '55px'
            }
        });
    }
    function checkfile() {
        var myObject;
        myObject = new ActiveXObject("Scripting.FileSystemObject");
        if (myObject.FileExists("I:\\RD73.CTOC")) {
            alert("File Exists");
        } else {
            alert("File doesn't exist");
        }
    }
    function readAll() {
        var fso = new ActiveXObject("Scripting.FileSystemObject");
        var txtFile = fso.OpenTextFile("kategorije.txt", 1, false, 0);

        var fText = txtFile.ReadAll();
        txtFile.Close();
        fso = null
        var array = fText.split("\r\n");
        var sel = document.getElementById("dropdown2");
        for (var i = 0; i < array.length; i++) {
            var opt = document.createElement("option");
            opt.innerHTML = array[i];
            opt.value = array[i];
            sel.appendChild(opt);
        }
    }
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
    function ShowPopupConfirm2(message) {
        $(function () {
            $("#dialog-confirm2").html(message)
            $("#dialog-confirm2").dialog({
                resizable: false,
                height: "auto",
                width: 400,
                modal: true,
                title: "Check Again",
                buttons: {
                    "Confirm": function () {
                        $(this).dialog("close");
                        //__doPostBack('<%= Button3.UniqueID %>', 'OnClick');
                        $("[id*=btnhidden]").click();
                        //return true;
                    },
                    Cancel: function () {
                        $(this).dialog("close");
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
    function rgb2hex(rgb) {
        rgb = rgb.match(/^rgba?[\s+]?\([\s+]?(\d+)[\s+]?,[\s+]?(\d+)[\s+]?,[\s+]?(\d+)[\s+]?/i);
        return (rgb && rgb.length === 4) ? "#" +
         ("0" + parseInt(rgb[1], 10).toString(16)).slice(-2) +
         ("0" + parseInt(rgb[2], 10).toString(16)).slice(-2) +
         ("0" + parseInt(rgb[3], 10).toString(16)).slice(-2) : '';
    }
    $(function () {
        //Assign Click event to Button.
        $("#btnGet").click(function () {
            var message = "Id Name                  Country\n";

            //Loop through all checked CheckBoxes in GridView.
            $("#Table1 input[type=checkbox]:checked").each(function () {
                var row = $(this).closest("tr")[0];
                var color = $(this).closest("tr").css("background-color");// get this in whatever way.
                var hex = rgb2hex(color).toUpperCase();
                //alert(hex);
                if (hex === "#00FFB9") {
                    message += row.cells[1].innerHTML;
                    message += "   " + row.cells[2].innerHTML;
                    message += "   " + row.cells[3].innerHTML;
                    //alert(row.bgColor);
                    message += "\n";
                }
            });
            //Display selected Row data in Alert Box.
            alert(message);
            //alert(color);
            return false;
        });
    });
    function btnGetClick() {
        $("#Table1 input[type=checkbox]:checked").each(function () {
            var message = null;
            var row = $(this).closest("tr")[0];
            var color = $(this).closest("tr").css("background-color");// get this in whatever way.
            var hex = rgb2hex(color).toUpperCase();
            //alert(hex);
            if (hex === "#00FFB9") {
                message += row.cells[1].innerHTML;
                message += "   " + row.cells[2].innerHTML;
                message += "   " + row.cells[3].innerHTML;
                //alert(row.bgColor);
                message += "\n";
            }
            if(message !=null)
            {
                ShowPopupConfirm2(message);
            }
            else
            {
                $("[id*=btnhidden]").click();
            }
        });
        // this will prevent the postback, equivalent to: event.preventDefault();
        return false;
    }

</script>
<body>
    <p><span class="ui-icon ui-icon-alert" style="float:left; margin:12px 12px 20px 0;"></span>Do you sure layer choosed to create?</p>
    </div>
    <form id="form1" runat="server">
    <table cellspacing="0" rules="all" border="1" id="Table1" style="border-collapse: collapse;">
        <tr>
            <th>&nbsp;</th>
            <th style="width:80px">Customer Id</th>
            <th style="width:120px">Name</th>
            <th style="width:120px">Country</th>
        </tr>
        <tr>
            <td><input type="checkbox"/></td>
            <td>1</td>
            <td>John Hammond</td>
            <td>United States</td>
        </tr>
        <tr style="background-color:#00FFB9;padding:40px 40px">
            <td><input type="checkbox"/></td>
            <td>2</td>
            <td>Mudassar Khan</td>
            <td>India</td>
        </tr>
        <tr>
            <td><input type="checkbox"/></td>
            <td>3</td>
            <td>Suzanne Mathews</td>
            <td>France</td>
        </tr>
        <tr style="background-color:#CC3333;padding:40px 40px">
            <td><input type="checkbox"/></td>
            <td>4</td>
            <td>Robert Schidner</td>
            <td>Russia</td>
        </tr>
    </table>
    <div>
        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox><asp:Button ID="Button1" runat="server" Text="Button" OnClick="Button1_Click"  />
    </div>
    <div style="position: absolute;  bottom: 0;" ><asp:Button ID="Button2" runat="server" Text="Button"  OnClick="Button2_Click" Visible="False" /></div>
    <div id="dialog-message" style="display: none"></div>
    <div id="dialog-confirm" title="Empty the recycle bin?" style="display: none">
    </div>
    <div id="dialog-confirm2" title="Empty the recycle bin?" style="display: none">
    </div>
        <asp:Button ID="Button3" runat="server" Text="Button" OnClientClick="return btnGetClick()" />
        <asp:Button id="btnhidden" runat="server" cssClass=hidden OnClick="btnhidden_Click"/>
        <asp:FileUpload ID="FileUpload1" runat="server" /><asp:Button ID="Button4" runat="server" Text="LockExcel" OnClick="Button4_Click" /><asp:Button ID="Button5" runat="server" Text="UnLockExcel" OnClick="Button5_Click" />
    </form>
    <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
     <input type="button" value="Check file" onClick="checkfile()"/>
</body>

</html>
