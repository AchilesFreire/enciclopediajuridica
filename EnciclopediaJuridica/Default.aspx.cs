using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using EnciclopediaJuridica.BusinessRule;
using EnciclopediaJuridica.BusinessCollection;

using System.Data;
using System.Text;


namespace EnciclopediaJuridica
{
    public partial class Default : System.Web.UI.Page
    {
        #region "Variaveis"
        static List<String> PalavrasMarcar;
        static DataSet DataSet_Lista;

        static List<LinkButton> ListaReferencia;

        //static Enum_Tema TemaAtual;

        #endregion

        #region "Eventos"

        protected void Page_Load(object sender, EventArgs e)
        {
            AtualizaListaReferencia();

        }

        protected void btnBusca_Click(object sender, EventArgs e)
        {
            if (txtCampoPesquisa.Text.Trim() == "")
            {
                lblMensagem.Text = "Informe o texto para pesquisa";
                return;
            }
            if ( ListaTipoPesquisa.SelectedValue == "")
            {
                lblMensagem.Text = "Informe o tipo de pesquisa";
                return;
            }

            BuscaDadosPesquisa(ListaTipoPesquisa.SelectedValue);
                       
        }

        protected void LstVerbetes_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (LstVerbetes.SelectedIndex == -1)
                {
                    Literal_HTML.Text = "";
                }
                else
                {

                    VisualizaVerbete(Convert.ToInt32(LstVerbetes.SelectedValue));
                }


            }
            catch (Exception ex)
            {
                lblMensagem.Text = ex.Message;
            }
        }

        protected void BtnCasosFamosos_Click(object sender, EventArgs e)
        {
            CarregaTemas(1);
        }

        protected void BtnTemasInteresse_Click(object sender, EventArgs e)
        {
            CarregaTemas(6);
        }

        protected void BtnTemasEstudo_Click(object sender, EventArgs e)
        {
            CarregaTemas(5);
        }

        protected void BtnFrasesMaximas_Click(object sender, EventArgs e)
        {
            CarregaTemas(2);
        }

        protected void BtnLatim_Click(object sender, EventArgs e)
        {
            CarregaTemas(4);
        }

        protected void BtnVerbetesBibliograficos_Click(object sender, EventArgs e)
        {
            CarregaTemas(8);
        }

        protected void BtnHistoricoDireitoEstrangeiro_Click(object sender, EventArgs e)
        {
            CarregaTemas(3);
        }

        protected void BtnDesempenhoPratico_Click(object sender, EventArgs e)
        {
            CarregaTemas(7);
        }

        protected void BtnReferencia_Click(object sender, EventArgs e)
        {
            String Nome = ((LinkButton)sender).ID;
            Nome = Nome.Substring(Nome.IndexOf("_"));


            int CodigoVerbete;
        }

        #endregion

        #region "Metodos para as pesquisas"

        /// <summary>
        /// Realiza a pesquisa nos verbetes, listando os que tem TODAS as palavras
        /// 
        /// </summary>
        /// <param name="ListaCodigos"></param>
        private void BuscaDadosPesquisa(String TipoPesquisa)
        {
            try
            {
                rul_VERBETE verbete = new rul_VERBETE();
                lblMensagem.Text = "";

                List<String> ListaCodigos = new List<String>();
                List<String> ListaPalavasNaoEncontradas = new List<String>();
                String Mensagem = "";

                Boolean FraseExata = (ListaTipoPesquisa.SelectedValue == "EE");

                #region "Verificando as palavras"
                if (!VerificaPalavras(out ListaCodigos, out ListaPalavasNaoEncontradas, FraseExata))
                {
                    foreach (String erro in ListaPalavasNaoEncontradas)
                    {
                        Mensagem += " " + erro + ";";
                    }
                    lblMensagem.Text = "Palavras não foram encontradas:" + Mensagem;
                    return;
                }
                #endregion

                PainelLista.Visible = true;
                PainelTemas.Visible = false;

                #region "Buscando os dados de acordo com a pesquisa solicitada"
                switch (TipoPesquisa)
                {
                    case "E":
                        {
                            DataSet_Lista = verbete.Pesquisa_E(ListaCodigos);
                            break;
                        }
                    case "OU":
                        {
                            DataSet_Lista = verbete.Pesquisa_OU(ListaCodigos);
                            break;
                        }
                    case "EE":
                        {
                            DataSet_Lista = verbete.Pesquisa_EE(ListaCodigos);
                            break;
                        }
                    case "TIT":
                        {
                            DataSet_Lista = verbete.Pesquisa_TIT(ListaCodigos);
                            break;
                        }
                    default:
                        {
                            DataSet_Lista = verbete.Pesquisa_E(ListaCodigos);
                            break;
                        }
                }
                #endregion

                if (DataSet_Lista == null)
                {
                    lblMensagem.Text = verbete.mensagem;
                }
                else
                {
                    #region "Carregando os dados da pesquisa na lista"

                    int total = DataSet_Lista.Tables[0].Rows.Count;

                    LstVerbetes.DataTextField = "NOME";
                    LstVerbetes.DataValueField = "VERBETE";
                    LstVerbetes.DataSource = DataSet_Lista;
                    LstVerbetes.DataBind();

                    if (total == 0)
                        lblQuantidadeVerbetes.Text = "Nenhum verbete foi encontrado";
                    else
                        if (total == 1)
                            lblQuantidadeVerbetes.Text = "1 verbete encontrado";
                        else
                            lblQuantidadeVerbetes.Text = "" + total + " verbetes encontrados";

                    #endregion
                }

            }
            catch (Exception ex)
            {
                lblMensagem.Text = ex.Message;
            }
        }

        private Boolean VerificaPalavras(out List<String> ListaCodigos, out List<String> ListaPalavasNaoEncontradas, Boolean FraseExata)
        {
            ListaCodigos = new List<String>();
            ListaPalavasNaoEncontradas = new List<String>();

            try
            {
                Boolean retorno = false;
                String TextoPesquisa = txtCampoPesquisa.Text.Trim().ToLower();

                TextoPesquisa = TextoPesquisa.Replace(" de ", " ");
                TextoPesquisa = TextoPesquisa.Replace(" das ", " ");
                TextoPesquisa = TextoPesquisa.Replace(" dos ", " ");
                TextoPesquisa = TextoPesquisa.Replace(" da ", " ");
                TextoPesquisa = TextoPesquisa.Replace(" do ", " ");
                TextoPesquisa = TextoPesquisa.Replace(" por ", " ");
                TextoPesquisa = TextoPesquisa.Replace(" para ", " ");
                TextoPesquisa = TextoPesquisa.Replace(" as ", " ");
                TextoPesquisa = TextoPesquisa.Replace(" os ", " ");
                TextoPesquisa = TextoPesquisa.Replace(" a ", " ");
                TextoPesquisa = TextoPesquisa.Replace(" e ", " ");
                TextoPesquisa = TextoPesquisa.Replace(" i ", " ");
                TextoPesquisa = TextoPesquisa.Replace(" o ", " ");
                TextoPesquisa = TextoPesquisa.Replace(" u ", " ");
                TextoPesquisa = TextoPesquisa.Replace(" ou ", " ");
                TextoPesquisa = TextoPesquisa.Replace("  ", " ");

                String[] Palavras = TextoPesquisa.Split(' ');
                rul_PALAVRAENCICLOPEDIA p = new rul_PALAVRAENCICLOPEDIA() ;
                col_PALAVRAENCICLOPEDIA col;
                String CodigoHexa;

                PalavrasMarcar = new List<string>();
                if (FraseExata)
                    PalavrasMarcar.Add(txtCampoPesquisa.Text);

                foreach (String Palavra in Palavras)
                {


                    if ((FraseExata) || ((!FraseExata) && (Palavra.Length > 2)))
                    {

                        if (!FraseExata)
                            PalavrasMarcar.Add(Palavra);

                        p.NOME = Palavra;
                        col = p.GetAll();

                        if (col.Count > 0)
                        {

                            CodigoHexa = Convert.ToString( col.Item(0).PALAVRAENCICLOPEDIA  ,16);

                            ListaCodigos.Add(CodigoHexa);
                            retorno = true;
                        }
                        else
                        {
                            ListaCodigos.Add("");
                            ListaPalavasNaoEncontradas.Add(Palavra);
                            retorno = false;
                            break;
                        }
                    }
                }

                return retorno;
            }
            catch (Exception ex)
            {
                lblMensagem.Text = ex.Message;
                return false;
            }
        }

        #endregion

        #region "Visualizacao do Verbete"

        private void VisualizaVerbete(int CodigoVerbete)
        {
            try
            {
                rul_ACEPCAO acepcao = new rul_ACEPCAO();
                acepcao.VERBETE = CodigoVerbete;
                col_ACEPCAO Acepcoes = acepcao.GetAll();
                StringBuilder textohtml = new StringBuilder();

                foreach (rul_ACEPCAO a in Acepcoes)
                {

                    textohtml.Append("<br>");
                    textohtml.Append("<div align='left' width='90%'>");
                    textohtml.Append("<b><font class='Titulo'>" + a.NOME + "</font></b>");
                    textohtml.Append("<hr align='center' width='99%' color='black'>");
                    textohtml.Append("</div>");
                    textohtml.Append("<div align='justify'><font class='Texto'>");
                    textohtml.Append(a.DEFINICAO);
                    textohtml.Append("</div>");
                    textohtml.Append("<br>");
                }
                textohtml.Append("<hr>");

                String TextoHTMLMarcado = textohtml.ToString();
                MarcaTexto(ref TextoHTMLMarcado);

                #region "Incluindo as reerencias"
                
                rul_REFERENCIA referencia = new rul_REFERENCIA();
                referencia.VERBETEORIGEM = CodigoVerbete;
                DataSet DS_referencias = referencia.RetornaReferencias();
                StringBuilder TextoReferencias = new StringBuilder();
                int codref=1;
                LinkButton Botao;
                int q = DS_referencias.Tables[0].Rows.Count;

                if (q > 0)
                    ListaReferencia = new List<LinkButton>();
                else
                    ListaReferencia = null;

                for ( int i=0; i < q ; i++)
                {
                    //TextoReferencias.Append("<asp:LinkButton ID=\"BtnRef" + codref + "\" a runat=\"server\" Text=\"" + DS_referencias.Tables[0].Rows[i]["NOME"].ToString().Trim() +  "\" onclick=\"BtnReferencia_Click\" />");
                    Botao = new LinkButton();
                    Botao.Text = DS_referencias.Tables[0].Rows[i]["NOME"].ToString().Trim();
                    Botao.ID = "Botao_" + DS_referencias.Tables[0].Rows[i]["VERBETEDESTINO"].ToString().Trim();
                    
                    Botao.Click += new System.EventHandler(BtnReferencia_Click);


                    ListaReferencia.Add(Botao);
                    
                }

                AtualizaListaReferencia();

                TextoHTMLMarcado += "<br>Veja tambem<br><br>" + TextoReferencias.ToString();
                #endregion

                Literal_HTML.Text = TextoHTMLMarcado;

            }
             catch (Exception ex)
            {
                lblMensagem.Text = ex.Message;
            }
        }

        private void MarcaTexto(ref String TextoHTML)
        {

            try
            {

                if (PalavrasMarcar == null)
                    return;

                if (PalavrasMarcar.Count == 0)
                    return;

                //String LetrasPalavras = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZáéíóúàèìòùâêîôûäëïüöÁÉÍÓÚÀÈÌÒÙÂÊÎÔÛÄËÏÖÜãõÃÕçÇ1234567890";
                String Delimitadores = " .,;:\"()<>" + '\n' +  '\r';
                String HTMLSubstituicao = "<b><font style='background-color:#800080;color:#ffffff;'><%Palavra%></font></b>";
                String Palavra ="";
                String Retorno = "";
                String TextoMarcado = "";

                int q = TextoHTML.Length;
                int i = 0;
                char Letra;

                while (i < q)
                {
                    Letra = TextoHTML[i];

                    if (Delimitadores.Contains(Letra))
                    {
                        if (Palavra != "")
                        {
                            if (PalavrasMarcar.Contains(Palavra))
                            {
                                TextoMarcado = HTMLSubstituicao;
                                TextoMarcado = TextoMarcado.Replace("<%Palavra%>", Palavra);

                                Retorno += TextoMarcado;
                            }
                            else
                            {
                                Retorno += Palavra;

                            }
                            Palavra = "";
                        }
                        

                        Retorno += Letra;
                    }
                    else
                        Palavra += Letra;

                    i++;

                }
                TextoHTML = Retorno;


                

            }
             catch (Exception ex)
            {
                lblMensagem.Text = ex.Message;

               
            }
        }


        private void AtualizaListaReferencia()
        {
            if (ListaReferencia == null)
                return;

            foreach (LinkButton l in ListaReferencia)
            {
                Painel_Referencias.Controls.Add(l);
            }
        }
        #endregion

        #region "Temas"

        private void CarregaTemas(int CodigoTema)
        {
            try
            {
  
                PainelLista.Visible = true;
                PainelTemas.Visible = false; 
                
                rul_TEMA tema = new rul_TEMA();
                tema.TEMA = CodigoTema;
                DataSet DataSet_Tema = tema.RetornaVerbetesTema();

                int total = DataSet_Tema.Tables[0].Rows.Count;

                LstVerbetes.DataTextField = "NOME";
                LstVerbetes.DataValueField = "VERBETE";
                LstVerbetes.DataSource = DataSet_Tema;
                LstVerbetes.DataBind();

                if (total == 0)
                    lblQuantidadeVerbetes.Text = "Nenhum verbete foi encontrado";
                else
                    if (total == 1)
                        lblQuantidadeVerbetes.Text = "1 verbete encontrado";
                    else
                        lblQuantidadeVerbetes.Text = "" + total + " verbetes encontrados";


            }
            catch (Exception ex)
            {
                lblMensagem.Text = ex.Message;
            }
        }
        
        #endregion


    }
}