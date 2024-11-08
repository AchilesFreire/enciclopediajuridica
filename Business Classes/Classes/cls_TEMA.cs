using System;
using System.Data;
using Business_DataBase;
using System.Drawing;
using BusinessClass;

namespace EnciclopediaJuridica.BusinessClass
{

    /// <summary>
    /// Definicao da Classe cls_TEMA
    /// Esta classe representa o objeto TEMA no banco de dados
    /// Todas as operacoes basicas (Inclusao, Alteracao, Exclusao, Consulta) sao feitas por esta classe
    /// Que utilizada internamente pela clase rul_TEMA
    /// 
    /// Nota: Esta classe nao deve ser instanciada dentro do projeto, pois a arquitetura de camadas
    /// Define a classe rul_TEMA para utilizacao na camada de apresentacao do projeto
    /// 
    /// </summary>
    public class cls_TEMA
    {
        #region "Variaveis"

        private int _TEMA = -1;
        private String _NOME = String.Empty;
        private String _DESCRICAO = String.Empty;

        private String _mensagem = "";

        #endregion

        #region "Construtures"

        public cls_TEMA()
        {
        }

        /// <summary>
        /// Construtor da Classe TEMA com passagem de parametros da Chave Primaria
        /// </summary>
        public cls_TEMA(int par_TEMA)
        {
            try
            {
                this.TEMA = par_TEMA;

            }
            catch (Exception ex)
            {
                this.mensagem = ex.Message;
            }
        }

        #endregion

        #region "Propriedades"
        public int TEMA
        {
            get { return _TEMA; }
            set { _TEMA = value; }
        }

        public String NOME
        {
            get { return _NOME; }
            set { _NOME = value; }
        }

        public String DESCRICAO
        {
            get { return _DESCRICAO; }
            set { _DESCRICAO = value; }
        }


        public String mensagem
        {
            get { return _mensagem; }
            set { _mensagem = value; }
        }
        #endregion

        #region "Metodos Basicos"

        /// <summary>
        /// public Boolean Insert()
        /// Este metodo realiza o "insert" no objeto TEMA do banco de dados
        /// </summary>
        public Boolean Insert()
        {
            try
            {
                cls_comando comando = new cls_comando();
                ConnectionInfo conexao = new ConnectionInfo();


                String Query = "";
                Boolean retorno = false;

                Query += " insert into TEMA(";
                Query += " NOME,";
                Query += " DESCRICAO";
                Query += " ) values ( ";
                Query += "'" + ConnectionInfo.FormataString(NOME) + "'" + ",";
                Query += "'" + ConnectionInfo.FormataString(DESCRICAO) + "'";
                Query += " )";


                comando.CallSql(Query, ConnectionInfo.Conexao);

                mensagem = comando.LastError;

                if (this.mensagem == String.Empty)
                    retorno = true;
                else
                    retorno = false;

                return retorno;

            }
            catch (Exception ex)
            {
                this.mensagem = ex.Message;
                return false;
            }
        }

        /// <summary>
        /// public Boolean Update()
        /// Este metodo realiza o "Update" no objeto TEMA do banco de dados
        /// </summary>
        public Boolean Update()
        {
            try
            {
                cls_comando comando = new cls_comando();
                ConnectionInfo conexao = new ConnectionInfo();
                String Query = "";
                Boolean retorno = false;

                Query += " Update TEMA set ";
                Query += "NOME = " + "'" + ConnectionInfo.FormataString(NOME) + "'" + ",";
                Query += "DESCRICAO = " + "'" + ConnectionInfo.FormataString(DESCRICAO) + "'";
                Query += " Where  TEMA = " + _TEMA;


                comando.CallSql(Query, ConnectionInfo.Conexao);

                mensagem = comando.LastError;

                if (this.mensagem == String.Empty)
                    retorno = true;
                else
                    retorno = false;

                return retorno;
            }
            catch (Exception ex)
            {
                this.mensagem = ex.Message;
                return false;
            }
        }

        /// <summary>
        /// public Boolean Delete()
        /// Este metodo realiza o "Delete" no objeto TEMA do banco de dados
        /// </summary>
        public Boolean Delete()
        {
            try
            {
                cls_comando comando = new cls_comando();
                ConnectionInfo conexao = new ConnectionInfo();
                String Query = "";
                Boolean retorno = false;

                Query += " Delete TEMA ";
                Query += " Where  TEMA = " + _TEMA;


                comando.CallSql(Query, ConnectionInfo.Conexao);

                mensagem = comando.LastError;

                if (this.mensagem == String.Empty)
                    retorno = true;
                else
                    retorno = false;

                return retorno;

            }
            catch (Exception ex)
            {
                this.mensagem = ex.Message;
                return false;
            }
        }

        /// <summary>
        /// public Boolean DeleteMasterDetail()
        /// Este metodo realiza o "Delete" no objeto TEMA do banco de dados
        /// </summary>
        public Boolean DeleteMasterDetail()
        {
            try
            {
                cls_comando comando = new cls_comando();
                ConnectionInfo conexao = new ConnectionInfo();
                String Query = "";
                Boolean retorno = false;

                Query += " Delete TEMA ";
                Query += " Where  TEMA = " + _TEMA;


                comando.CallSql(Query, ConnectionInfo.Conexao);

                this.mensagem = comando.LastError;

                if (this.mensagem == String.Empty)
                    retorno = true;
                else
                    retorno = false;

                return retorno;

            }
            catch (Exception ex)
            {
                this.mensagem = ex.Message;
                return false;
            }
        }

        /// <summary>
        /// public DataSet GetAll()
        /// Este metodo realiza o "Select" no objeto TEMA do banco de dados
        /// </summary>
        public DataSet GetAll()
        {
            try
            {
                cls_comando comando = new cls_comando();
                ConnectionInfo conexao = new ConnectionInfo();

                String Query = "";
                String Conector = " Where ";

                Query += " Select";
                Query += " TEMA,";
                Query += " NOME,";
                Query += " DESCRICAO";
                Query += " From [TEMA]";
                if (TEMA != -1)
                {
                    Query += " " + Conector + "TEMA = " + TEMA;
                    Conector = " And ";
                }
                if (NOME != String.Empty)
                {
                    Query += " " + Conector + "NOME = " + "'" + ConnectionInfo.FormataString(NOME) + "'";
                    Conector = " And ";
                }
                if (DESCRICAO != String.Empty)
                {
                    Query += " " + Conector + "DESCRICAO = " + "'" + ConnectionInfo.FormataString(DESCRICAO) + "'";
                    Conector = " And ";
                }
                Query += " Order By";
                Query += " TEMA ";


                DataSet retorno = comando.CallSql(Query, ConnectionInfo.Conexao);

                mensagem = comando.LastError;

                if (this.mensagem != String.Empty)
                    retorno = null;

                return retorno;

            }
            catch (Exception ex)
            {
                this.mensagem = ex.Message;
                return null;
            }
        }

        /// public DataSet GetAllMasterDetail()
        /// Este metodo realiza o "Select" no objeto TEMA do banco de dados, 
        /// para preenchimento nos formularios 'Master Detail'
        /// </summary>
        public DataSet GetAllMasterDetail()
        {
            try
            {
                cls_comando comando = new cls_comando();
                ConnectionInfo conexao = new ConnectionInfo();

                String Query = "";
                String Conector = " Where ";

                Query += " Select";
                Query += " TEMA,";
                Query += " NOME,";
                Query += " DESCRICAO";
                Query += " From [TEMA]";
                if (TEMA != -1)
                {
                    Query += " " + Conector + "TEMA = " + TEMA;
                    Conector = " And ";
                }
                if (NOME != String.Empty)
                {
                    Query += " " + Conector + "NOME = " + "'" + ConnectionInfo.FormataString(NOME) + "'";
                    Conector = " And ";
                }
                if (DESCRICAO != String.Empty)
                {
                    Query += " " + Conector + "DESCRICAO = " + "'" + ConnectionInfo.FormataString(DESCRICAO) + "'";
                    Conector = " And ";
                }
                Query += " Order By";
                Query += " TEMA ";


                DataSet retorno = comando.CallSql(Query, ConnectionInfo.Conexao);

                mensagem = comando.LastError;

                if (this.mensagem != String.Empty)
                    retorno = null;

                return retorno;

            }
            catch (Exception ex)
            {
                this.mensagem = ex.Message;
                return null;
            }
        }

        /// <summary>
        /// public DataSet FindAll()
        /// Realiza o "Select" no objeto TEMA do banco de dados
        /// 
        /// e feita uma busca avancada nos registros da Tabela. 
        /// </summary>
        public DataSet FindAll()
        {
            try
            {
                cls_comando comando = new cls_comando();
                ConnectionInfo conexao = new ConnectionInfo();

                String Query = "";
                String Conector = " Where ";

                Query += " Select";
                Query += " TEMA,";
                Query += " NOME,";
                Query += " DESCRICAO";
                Query += " From [TEMA]";
                if (TEMA != -1)
                {
                    Query += " " + Conector + "TEMA = " + TEMA;
                    Conector = " And ";
                }
                if (NOME != String.Empty)
                {
                    Query += " " + Conector + "NOME Like " + "'%" + NOME + "%'";
                    Conector = " And ";
                }
                if (DESCRICAO != String.Empty)
                {
                    Query += " " + Conector + "DESCRICAO Like " + "'%" + DESCRICAO + "%'";
                    Conector = " And ";
                }
                Query += " Order By";
                Query += " TEMA ";


                DataSet retorno = comando.CallSql(Query, ConnectionInfo.Conexao);

                mensagem = comando.LastError;

                if (this.mensagem != String.Empty)
                    retorno = null;

                return retorno;

            }
            catch (Exception ex)
            {
                this.mensagem = ex.Message;
                return null;
            }
        }

        /// <summary>
        /// public DataSet FindAll()
        /// Realiza o "Select" no objeto TEMA do banco de dados
        /// 
        /// e feita uma busca avancada nos registros da Tabela. 
        /// </summary>
        public DataSet FindAllGrid()
        {
            try
            {
                cls_comando comando = new cls_comando();
                ConnectionInfo conexao = new ConnectionInfo();

                String Query = "";
                String Conector = " Where ";

                Query += " Select";
                Query += " TEMA,";
                Query += " NOME,";
                Query += " DESCRICAO";
                Query += " From [TEMA]";
                if (TEMA != -1)
                {
                    Query += " " + Conector + "TEMA = " + TEMA;
                    Conector = " And ";
                }
                if (NOME != String.Empty)
                {
                    Query += " " + Conector + "NOME Like " + "'%" + NOME + "%'";
                    Conector = " And ";
                }
                if (DESCRICAO != String.Empty)
                {
                    Query += " " + Conector + "DESCRICAO Like " + "'%" + DESCRICAO + "%'";
                    Conector = " And ";
                }
                Query += " Order By";
                Query += " TEMA ";


                DataSet retorno = comando.CallSql(Query, ConnectionInfo.Conexao);

                mensagem = comando.LastError;

                if (this.mensagem != String.Empty)
                    retorno = null;

                return retorno;

            }
            catch (Exception ex)
            {
                this.mensagem = ex.Message;
                return null;
            }
        }

        /// <summary>
        /// public DataSet Load()
        /// Este metodo realiza o "Select" no objeto TEMA do banco de dados
        /// 
        /// e feito um select no registro definido pela chave primaria fornececida
        /// </summary>
        public DataSet Load()
        {
            try
            {
                cls_comando comando = new cls_comando();
                ConnectionInfo conexao = new ConnectionInfo();

                String Query = "";
                String Conector = " Where ";

                Query += " Select";
                Query += " TEMA,";
                Query += " NOME,";
                Query += " DESCRICAO";
                Query += " From [TEMA]";
                if (TEMA != -1)
                {
                    Query += " " + Conector + "TEMA = " + TEMA;
                    Conector = " And ";
                }


                DataSet retorno = comando.CallSql(Query, ConnectionInfo.Conexao);

                mensagem = comando.LastError;

                if (this.mensagem != String.Empty)
                    retorno = null;

                return retorno;

            }
            catch (Exception ex)
            {
                this.mensagem = ex.Message;
                return null;
            }
        }

        /// <summary>
        /// public String ToString()
        /// Este metodo retorna uma string com os nomes e os valores de todas as propriedades da classe
        /// 
        /// </summary>
        public new String ToString()
        {
            try
            {
                String retorno = "";
                retorno += "TEMA:		" + this.TEMA.ToString().Trim();
                retorno += "NOME:		" + this.NOME.ToString().Trim();
                retorno += "DESCRICAO:		" + this.DESCRICAO.ToString().Trim();

                return retorno;

            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        #endregion

        #region "Metodos para trazer os verbetes de um tema"

        /// <summary>
        /// public DataSet RetornaVerbetesTema()
        /// Este metodo realiza o "Select" no objeto TEMA do banco de dados
        /// </summary>
        public DataSet RetornaVerbetesTema()
        {
            try
            {
                cls_comando comando = new cls_comando();
                ConnectionInfo conexao = new ConnectionInfo();

                String Query = "";

                Query += " Select";
                Query += " VERBETE.VERBETE,";
                Query += " VERBETE.NOME,";
                Query += " VERBETE.NOMEORDENACAO";
                Query += " From VERBETE, TEMAVERBETE";
                Query += " Where VERBETE.VERBETE = TEMAVERBETE.VERBETE";
                Query += " And TEMAVERBETE.TEMA = " + TEMA;
                Query += " Order By VERBETE.NOMEORDENACAO";


                DataSet retorno = comando.CallSql(Query, ConnectionInfo.Conexao);

                mensagem = comando.LastError;

                if (this.mensagem != String.Empty)
                    retorno = null;

                return retorno;

            }
            catch (Exception ex)
            {
                this.mensagem = ex.Message;
                return null;
            }
        }
        #endregion
    }
}