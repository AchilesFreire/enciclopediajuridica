using System;
using System.Data;
using Business_DataBase;
using System.Drawing;
using BusinessClass;

namespace EnciclopediaJuridica.BusinessClass
{

    /// <summary>
    /// Definicao da Classe cls_REFERENCIA
    /// Esta classe representa o objeto REFERENCIA no banco de dados
    /// Todas as operacoes basicas (Inclusao, Alteracao, Exclusao, Consulta) sao feitas por esta classe
    /// Que utilizada internamente pela clase rul_REFERENCIA
    /// 
    /// Nota: Esta classe nao deve ser instanciada dentro do projeto, pois a arquitetura de camadas
    /// Define a classe rul_REFERENCIA para utilizacao na camada de apresentacao do projeto
    /// 
    /// </summary>
    public class cls_REFERENCIA
    {
        #region "Variaveis"

        private int _REFERENCIA = -1;
        private int _VERBETEORIGEM = -1;
        private int _VERBETEDESTINO = -1;

        private String _mensagem = "";

        #endregion

        #region "Construtures"

        public cls_REFERENCIA()
        {
        }

        /// <summary>
        /// Construtor da Classe REFERENCIA com passagem de parametros da Chave Primaria
        /// </summary>
        public cls_REFERENCIA(int par_REFERENCIA)
        {
            try
            {
                this.REFERENCIA = par_REFERENCIA;

            }
            catch (Exception ex)
            {
                this.mensagem = ex.Message;
            }
        }

        #endregion

        #region "Propriedades"
        public int REFERENCIA
        {
            get { return _REFERENCIA; }
            set { _REFERENCIA = value; }
        }

        public int VERBETEORIGEM
        {
            get { return _VERBETEORIGEM; }
            set { _VERBETEORIGEM = value; }
        }

        public int VERBETEDESTINO
        {
            get { return _VERBETEDESTINO; }
            set { _VERBETEDESTINO = value; }
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
        /// Este metodo realiza o "insert" no objeto REFERENCIA do banco de dados
        /// </summary>
        public Boolean Insert()
        {
            try
            {
                cls_comando comando = new cls_comando();
                ConnectionInfo conexao = new ConnectionInfo();


                String Query = "";
                Boolean retorno = false;

                Query += " insert into REFERENCIA(";
                Query += " VERBETEORIGEM,";
                Query += " VERBETEDESTINO";
                Query += " ) values ( ";
                Query += VERBETEORIGEM + ",";
                Query += VERBETEDESTINO;
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
        /// Este metodo realiza o "Update" no objeto REFERENCIA do banco de dados
        /// </summary>
        public Boolean Update()
        {
            try
            {
                cls_comando comando = new cls_comando();
                ConnectionInfo conexao = new ConnectionInfo();
                String Query = "";
                Boolean retorno = false;

                Query += " Update REFERENCIA set ";
                Query += "VERBETEORIGEM = " + VERBETEORIGEM + ",";
                Query += "VERBETEDESTINO = " + VERBETEDESTINO;
                Query += " Where  REFERENCIA = " + _REFERENCIA;


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
        /// Este metodo realiza o "Delete" no objeto REFERENCIA do banco de dados
        /// </summary>
        public Boolean Delete()
        {
            try
            {
                cls_comando comando = new cls_comando();
                ConnectionInfo conexao = new ConnectionInfo();
                String Query = "";
                Boolean retorno = false;

                Query += " Delete REFERENCIA ";
                Query += " Where  REFERENCIA = " + _REFERENCIA;


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
        /// Este metodo realiza o "Delete" no objeto REFERENCIA do banco de dados
        /// </summary>
        public Boolean DeleteMasterDetail()
        {
            try
            {
                cls_comando comando = new cls_comando();
                ConnectionInfo conexao = new ConnectionInfo();
                String Query = "";
                Boolean retorno = false;

                Query += " Delete REFERENCIA ";
                Query += " Where  REFERENCIA = " + _REFERENCIA;


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
        /// Este metodo realiza o "Select" no objeto REFERENCIA do banco de dados
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
                Query += " REFERENCIA,";
                Query += " VERBETEORIGEM,";
                Query += " VERBETEDESTINO";
                Query += " From [REFERENCIA]";
                if (REFERENCIA != -1)
                {
                    Query += " " + Conector + "REFERENCIA = " + REFERENCIA;
                    Conector = " And ";
                }
                if (VERBETEORIGEM != -1)
                {
                    Query += " " + Conector + "VERBETEORIGEM = " + VERBETEORIGEM;
                    Conector = " And ";
                }
                if (VERBETEDESTINO != -1)
                {
                    Query += " " + Conector + "VERBETEDESTINO = " + VERBETEDESTINO;
                    Conector = " And ";
                }
                Query += " Order By";
                Query += " REFERENCIA ";


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
        /// Este metodo realiza o "Select" no objeto REFERENCIA do banco de dados, 
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
                Query += " REFERENCIA,";
                Query += " VERBETEORIGEM,";
                Query += " VERBETEDESTINO";
                Query += " From [REFERENCIA]";
                if (REFERENCIA != -1)
                {
                    Query += " " + Conector + "REFERENCIA = " + REFERENCIA;
                    Conector = " And ";
                }
                if (VERBETEORIGEM != -1)
                {
                    Query += " " + Conector + "VERBETEORIGEM = " + VERBETEORIGEM;
                    Conector = " And ";
                }
                if (VERBETEDESTINO != -1)
                {
                    Query += " " + Conector + "VERBETEDESTINO = " + VERBETEDESTINO;
                    Conector = " And ";
                }
                Query += " Order By";
                Query += " REFERENCIA ";


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
        /// Realiza o "Select" no objeto REFERENCIA do banco de dados
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
                Query += " REFERENCIA,";
                Query += " VERBETEORIGEM,";
                Query += " VERBETEDESTINO";
                Query += " From [REFERENCIA]";
                if (REFERENCIA != -1)
                {
                    Query += " " + Conector + "REFERENCIA = " + REFERENCIA;
                    Conector = " And ";
                }
                if (VERBETEORIGEM != -1)
                {
                    Query += " " + Conector + "VERBETEORIGEM = " + VERBETEORIGEM;
                    Conector = " And ";
                }
                if (VERBETEDESTINO != -1)
                {
                    Query += " " + Conector + "VERBETEDESTINO = " + VERBETEDESTINO;
                    Conector = " And ";
                }
                Query += " Order By";
                Query += " REFERENCIA ";


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
        /// Realiza o "Select" no objeto REFERENCIA do banco de dados
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
                Query += " REFERENCIA,";
                Query += " VERBETEORIGEM,";
                Query += " VERBETEDESTINO";
                Query += " From [REFERENCIA]";
                if (REFERENCIA != -1)
                {
                    Query += " " + Conector + "REFERENCIA = " + REFERENCIA;
                    Conector = " And ";
                }
                if (VERBETEORIGEM != -1)
                {
                    Query += " " + Conector + "VERBETEORIGEM = " + VERBETEORIGEM;
                    Conector = " And ";
                }
                if (VERBETEDESTINO != -1)
                {
                    Query += " " + Conector + "VERBETEDESTINO = " + VERBETEDESTINO;
                    Conector = " And ";
                }
                Query += " Order By";
                Query += " REFERENCIA ";


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
        /// public DataSet GetAll()
        /// Este metodo realiza o "Select" no objeto REFERENCIA do banco de dados
        /// </summary>
        public DataSet RetornaReferencias()
        {
            try
            {
                cls_comando comando = new cls_comando();
                ConnectionInfo conexao = new ConnectionInfo();

                String Query = "";
                String Conector = " And ";

                Query += " Select";
                Query += " REFERENCIA.REFERENCIA,";
                Query += " REFERENCIA.VERBETEORIGEM,";
                Query += " REFERENCIA.VERBETEDESTINO,";
                Query += " VERBETE.NOME,";
                Query += " VERBETE.NOMEORDENACAO";
                Query += " From REFERENCIA, VERBETE";
                Query += " Where REFERENCIA.VERBETEDESTINO = VERBETE.VERBETE";
                if (REFERENCIA != -1)
                {
                    Query += " " + Conector + "REFERENCIA.REFERENCIA = " + REFERENCIA;
                    Conector = " And ";
                }
                if (VERBETEORIGEM != -1)
                {
                    Query += " " + Conector + "REFERENCIA.VERBETEORIGEM = " + VERBETEORIGEM;
                    Conector = " And ";
                }
                if (VERBETEDESTINO != -1)
                {
                    Query += " " + Conector + "REFERENCIA.VERBETEDESTINO = " + VERBETEDESTINO;
                    Conector = " And ";
                }
                Query += " Order By";
                Query += " REFERENCIA ";


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
        /// Este metodo realiza o "Select" no objeto REFERENCIA do banco de dados
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
                Query += " REFERENCIA,";
                Query += " VERBETEORIGEM,";
                Query += " VERBETEDESTINO";
                Query += " From [REFERENCIA]";
                if (REFERENCIA != -1)
                {
                    Query += " " + Conector + "REFERENCIA = " + REFERENCIA;
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
                retorno += "REFERENCIA:		" + this.REFERENCIA.ToString().Trim();
                retorno += "VERBETEORIGEM:		" + this.VERBETEORIGEM.ToString().Trim();
                retorno += "VERBETEDESTINO:		" + this.VERBETEDESTINO.ToString().Trim();

                return retorno;

            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        #endregion
    }
}