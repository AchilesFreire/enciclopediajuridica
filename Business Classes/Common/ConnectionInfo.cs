	/*******************************************************
	 **                                                   * 
	 ** Piton Consultoria Ltda                            * 
	 *  Business Class Layer                              * 
	 ** Projeto:Piton                                     **
	 *  Chamada: rul_                                     * 
	 *                                                    * 
	 *  Objeto gerado automaticamente pelo TierGenerator  * 
	 *                                                    * 
	 *  Versão do programa:1.0.2788.18592                 *  
	 *                                                    * 
	 *  Data da criação: 20/08/2007                       * 
	 *  Hora de criação: 09:20:18                         * 
	 *                                                    *  
	 *                                                    *  
	*******************************************************/

using System;
using Business_DataBase;
using System.Resources;
using System.Configuration;

namespace BusinessClass
{
	/// <summary>
	/// Summary description for Global.
	/// </summary>
    public sealed class ConnectionInfo
    {
        #region "Enumerados"
        public enum EnumBarraFerramentas
        {
            BtnNovo = 0,
            BtnEditar = 1,
            BtnSalvar = 2,
            BtnExcluir = 3,
            BtnImprimir = 5,
            BtnVisualizar = 6,
            BtnControles = 8,
            BtnGrid = 9,
            BtnSair = 11

        }
        #endregion

        #region "Variaveis"
        static cls_conexao _Conexao = new cls_conexao();
        static string _LoginUsuario = "";
        static string _NomeUsuario = "";
        static string _TipoUsuario = "";

        static String _mensagem = String.Empty;


        #endregion

        #region "Construtores"
        public ConnectionInfo()
        {
            //
            // TODO: Add constructor logic here
            //
            CarregaStringConexao();
        }
        #endregion

        #region "Propriedades"
        static public cls_conexao Conexao
        {
            get { return _Conexao; }
            set { _Conexao = value; }
        }
        static public string LoginUsuario
        {
            get { return _LoginUsuario; }
            set { _LoginUsuario = value; }
        }
        public string NomeUsuario
        {
            get { return _NomeUsuario; }
            set { _NomeUsuario = value; }
        }
        static public string TipoUsuario
        {
            get { return _TipoUsuario; }
            set { _TipoUsuario = value; }
        }
        static public String mensagem
        {
            get { return _mensagem; }
            set { _mensagem = value; }
        }


        #endregion

        #region "Metodos publicos"

        static public Boolean IsNumeric(Object valor)
        {
            int res = -1;

            return System.Int32.TryParse(valor.ToString(), out res);
        }
        static public Boolean IsDate(Object valor)
        {
            System.DateTime res = new DateTime();

            return System.DateTime.TryParse(valor.ToString(), out  res);
        }
        static public Boolean IsDecimal(Object valor)
        {
            System.Decimal res = new Decimal(-1);

            return System.Decimal.TryParse(valor.ToString(), out  res);
        }

        static public String FormataBoolean(Boolean valor)
        {
            return (valor? "1" : "0");
        }

        static public String FormataData(DateTime valor)
        {
            return valor.ToString();
        }
        static public String FormataDataHora(DateTime valor)
        {
            return valor.ToString();
        }


        static public String FormataDouble(Double valor)
        {
            return valor.ToString().Replace(".","").Replace(",", ".");
        }
        static public String FormataDecimal(Decimal valor)
        {
            return valor.ToString().Replace(".", "").Replace(",", ".");
        }

        static public String FormataString(String valor)
        {
            return valor.ToString().Replace("'", "");
        }

        #endregion

        #region "Metodos privados"

        private void CarregaStringConexao()
        {
            try
            {
                string strconexao = "";

                strconexao = ConfigurationManager.AppSettings.GetValues("conexao")[0];

                Conexao.StringConexao = strconexao;

            }
            catch (Exception ex)
            {
                _mensagem = "CarregaStringConexao():\n\n" + ex.Message;
            }

            
        }
        #endregion
    }

}
