<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="EnciclopediaJuridica.Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Enciclopédia jurídica</title>
    <link href="~/Styles/Site.css" rel="stylesheet" type="text/css" />
</head>
<body style="height: 785px">
    <form id="form1" runat="server">
    <div>
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        
        <br />
        <div style="text-align: center;">
        <table style="text-align: left; width: 94%;" border="0" cellpadding="0" cellspacing="0">
          <tbody>
            <tr>
              <td style="text-align: center;">
              <div style="margin-left: 80px;"><font size="+1"><b>Enciclop&eacute;dia Jur&iacute;dica Soibeman</b></font><br>
              <b><font size="-1">Autor: Leib Soibelman</font></b><br>
              </div>
              </td>
              <td style="width: 100px;"><a href="sobre.htm" target="_blank">Sobre a obra</a><br>
              <a href="ajuda.htm" target="_blank">Ajuda</a></td>
            </tr>
          </tbody>
        </table>
        </div>

        <div style="text-align: center;">
        <table style="text-align: left; width: 94%;" border="0" cellpadding="0" cellspacing="0">
            <tbody>
                <tr>
                    <td style="text-align: center;">
                        <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                            <ContentTemplate>
                                <br />Pesquisa geral<br />
                                <asp:TextBox runat="server" ID="txtCampoPesquisa" Width="300px" MaxLength="200" />&nbsp;
                                <asp:Button runat="server" ID="btnBusca" Text="Busca" onclick="btnBusca_Click" />
                                <br />
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </td>
                </tr>
                <tr>
                    <td style="text-align: center;">
                        <center>
                            <asp:UpdatePanel ID="UpdatePanel_ListaTipoPesquisa" runat="server">
                                <ContentTemplate>
                                    <asp:RadioButtonList ID="ListaTipoPesquisa" runat="server" Height="51px" RepeatColumns="2" Width="350px" >
                                        <asp:ListItem Text="Todas as palavras" Value="E" />
                                        <asp:ListItem Text="Qualquer palavra" Value="OU" />
                                        <asp:ListItem Text="Expressão exata" Value="EE" />
                                        <asp:ListItem Text="No título dos verbetes" Value="TIT" />                        
                                    </asp:RadioButtonList>
                                    <br />
                                    <asp:Label runat="server" ID="lblMensagem" Text="&nbsp;" CssClass="MensagemAlerta" />
                                    <br />
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </center>
                    </td>
                </tr>

          </tbody>
        </table>
        </div>

        <asp:UpdatePanel ID="UpdatePanel_Lista" runat="server">
            <ContentTemplate>

                <asp:Panel runat="server" ID="PainelLista" CssClass="EstiloPainelHTML" ScrollBars="Vertical" Width="100%" Height="100%" Visible="false" >
                <table border="0" >
                    <tr>
                        <td valign="top">
                            <asp:UpdatePanel ID="UpdatePanel_Verbetes" runat="server">
                                <ContentTemplate>
                                    <asp:Label runat="server" ID="lblQuantidadeVerbetes" Text="    " />
                                    <br />
                                    <asp:ListBox ID="LstVerbetes" runat="server" Height="637px" Width="221px" AutoPostBack="True" onselectedindexchanged="LstVerbetes_SelectedIndexChanged"  CssClass="EstiloListaVerbetes" />
                                </ContentTemplate>
                            </asp:UpdatePanel>                            
                        </td>
                        <td valign="top" style="width:100%">
                            <asp:UpdatePanel ID="UpdatePanel_Literal" runat="server">
                                <ContentTemplate>
                                    <asp:Panel ID="Painel_HTML" runat="server" Height="637px" Width="100%" ScrollBars="Vertical">
                                        <asp:Literal runat="server" ID="Literal_HTML"/>
                                        <asp:Panel runat="server" ID="Painel_Referencias" Height="637px" Width="100%" />
                                    </asp:Panel> 
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </td>
                    </tr>
                </table>
                </asp:Panel>
              </ContentTemplate>
           </asp:UpdatePanel>
        
        <div style="text-align: center;">
        <table style="text-align: left; width: 94%;" border="0" cellpadding="0" cellspacing="0">
            <tbody>
                <tr>
                    <td style="text-align: center;">
                        <asp:UpdatePanel ID="UpdatePanel_Temas" runat="server">
                            <ContentTemplate>
                                
                                <asp:Panel runat="server" ID="PainelTemas" Visible="true">
                                    Pesquisa de tema específico:<br>
                                    <asp:LinkButton ID="BtnCasosFamosos" a runat="server" Text="Casos Famosos" onclick="BtnCasosFamosos_Click" /> <span style="color: rgb(255, 0, 0);"> | </span>
                                    <asp:LinkButton ID="BtnTemasInteresse" runat="server" Text="Temas de Interesse" onclick="BtnTemasInteresse_Click" /><span style="color: rgb(255, 0, 0);"> | </span>
                                    <asp:LinkButton ID="BtnTemasEstudo" runat="server" Text="Temas de Estudo" onclick="BtnTemasEstudo_Click" /><span style="color: rgb(255, 0, 0);"> | </span>
                                    <asp:LinkButton ID="BtnFrasesMaximas" runat="server" Text="Frases e Máximas" onclick="BtnFrasesMaximas_Click" /><span style="color: rgb(255, 0, 0);"> | </span>
                                    <asp:LinkButton ID="BtnLatim" runat="server" Text="Latim" onclick="BtnLatim_Click" /><br>

                                    <asp:LinkButton ID="BtnVerbetesBibliograficos" runat="server" Text="Verbetes bibliogr&aacute;ficos" onclick="BtnVerbetesBibliograficos_Click" /><span style="color: rgb(255, 0, 0);"> | </span>
                                    <asp:LinkButton ID="BtnHistoricoDireitoEstrangeiro" runat="server" Text="Temas Hist&oacute;ricos e Direito Estrangeiro" onclick="BtnHistoricoDireitoEstrangeiro_Click" /><span style="color: rgb(255, 0, 0);"> | </span>
                                    <asp:LinkButton ID="BtnDesempenhoPratico" runat="server" Text="Desempenho Prático" onclick="BtnDesempenhoPratico_Click" />


                                </asp:Panel>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </td>
                </tr>
            </tbody>
        </table>
        </div>

    </div>
    </form>
</body>
</html>
