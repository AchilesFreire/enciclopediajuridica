using System;
using System.Data;
using Business_DataBase;
using System.Drawing;
using BusinessClass;

using System.Collections.Generic;

namespace EnciclopediaJuridica.BusinessClass
{

	/// <summary>
	/// Definicao da Classe cls_VERBETE
	/// Esta classe representa o objeto VERBETE no banco de dados
	/// Todas as operacoes basicas (Inclusao, Alteracao, Exclusao, Consulta) sao feitas por esta classe
	/// Que utilizada internamente pela clase rul_VERBETE
	/// 
	/// Nota: Esta classe nao deve ser instanciada dentro do projeto, pois a arquitetura de camadas
	/// Define a classe rul_VERBETE para utilizacao na camada de apresentacao do projeto
	/// 
	/// </summary>
	public class cls_VERBETE
	{
        #region "Variaveis" 

			private  int _VERBETE = -1;
			private  String _NOME = String.Empty;
			private  String _NOMEORDENACAO = String.Empty;
			private  DateTime _DATACRIACAO = new DateTime();
			private  DateTime _DATAALTERACAO = new DateTime();
			private  DateTime _DATAINCLUSAO = new DateTime();

        private String _mensagem = "";

        #endregion

        #region "Construtures" 

        public cls_VERBETE()
        {
        }

        /// <summary>
        /// Construtor da Classe VERBETE com passagem de parametros da Chave Primaria
        /// </summary>
        public cls_VERBETE(  int par_VERBETE)
        {
            try
            {
					this.VERBETE = par_VERBETE;
 
            }
            catch (Exception ex)
            {
                this.mensagem = ex.Message;
            }
        }

        #endregion

        #region "Propriedades" 
			public  int VERBETE
			{
				get {return _VERBETE;}
				set {_VERBETE = value;}
			}

			public  String NOME
			{
				get {return _NOME;}
				set {_NOME = value;}
			}

			public  String NOMEORDENACAO
			{
				get {return _NOMEORDENACAO;}
				set {_NOMEORDENACAO = value;}
			}

			public  DateTime DATACRIACAO
			{
				get {return _DATACRIACAO;}
				set {_DATACRIACAO = value;}
			}

			public  DateTime DATAALTERACAO
			{
				get {return _DATAALTERACAO;}
				set {_DATAALTERACAO = value;}
			}

			public  DateTime DATAINCLUSAO
			{
				get {return _DATAINCLUSAO;}
				set {_DATAINCLUSAO = value;}
			}


        public String mensagem
            {
                get {	return _mensagem; }
                set {	_mensagem = value; }
            }
        #endregion

        #region "Metodos Basicos"
 
			/// <summary>
			/// public Boolean Insert()
			/// Este metodo realiza o "insert" no objeto VERBETE do banco de dados
			/// </summary>
			public Boolean Insert()
			{
				try
				{
					cls_comando comando = new cls_comando();
					ConnectionInfo conexao = new ConnectionInfo();


					String Query = "";
					Boolean retorno = false;

					Query += " insert into VERBETE(";
					Query += " NOME,";
					Query += " NOMEORDENACAO,";
					Query += " DATACRIACAO,";
					Query += " DATAALTERACAO,";
					Query += " DATAINCLUSAO";
					Query += " ) values ( ";
					Query += "'" + ConnectionInfo.FormataString(NOME) + "'"+ ",";
					Query += "'" + ConnectionInfo.FormataString(NOMEORDENACAO) + "'"+ ",";
					Query += "'" + ConnectionInfo.FormataData(DATACRIACAO) + "'"+ ",";
					Query += "'" + ConnectionInfo.FormataData(DATAALTERACAO) + "'"+ ",";
					Query += "'" + ConnectionInfo.FormataData(DATAINCLUSAO) + "'";
					Query += " )";


					comando.CallSql(Query,ConnectionInfo.Conexao);

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
			/// Este metodo realiza o "Update" no objeto VERBETE do banco de dados
			/// </summary>
			public Boolean Update()
			{
				try
				{
					cls_comando comando = new cls_comando();
					ConnectionInfo conexao = new ConnectionInfo();
					String Query = "";
					Boolean retorno = false;

					Query += " Update VERBETE set ";
					Query += "NOME = " + "'" + ConnectionInfo.FormataString(NOME) + "'"+ ",";
					Query += "NOMEORDENACAO = " + "'" + ConnectionInfo.FormataString(NOMEORDENACAO) + "'"+ ",";
					Query += "DATACRIACAO = " + "'" + ConnectionInfo.FormataData(DATACRIACAO) + "'"+ ",";
					Query += "DATAALTERACAO = " + "'" + ConnectionInfo.FormataData(DATAALTERACAO) + "'"+ ",";
					Query += "DATAINCLUSAO = " + "'" + ConnectionInfo.FormataData(DATAINCLUSAO) + "'";
					Query += " Where  VERBETE = "  + _VERBETE;


					comando.CallSql(Query,ConnectionInfo.Conexao);

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
			/// Este metodo realiza o "Delete" no objeto VERBETE do banco de dados
			/// </summary>
			public Boolean Delete()
			{
				try
				{
					cls_comando comando = new cls_comando();
					ConnectionInfo conexao = new ConnectionInfo();
					String Query = "";
					Boolean retorno = false;

					Query += " Delete VERBETE ";
					Query += " Where  VERBETE = "  + _VERBETE;


					comando.CallSql(Query,ConnectionInfo.Conexao);

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
			/// Este metodo realiza o "Delete" no objeto VERBETE do banco de dados
			/// </summary>
			public Boolean DeleteMasterDetail()
			{
				try
				{
					cls_comando comando = new cls_comando();
					ConnectionInfo conexao = new ConnectionInfo();
					String Query = "";
					Boolean retorno = false;

					Query += " Delete VERBETE ";
					Query += " Where  VERBETE = "  + _VERBETE;


					comando.CallSql(Query,ConnectionInfo.Conexao);

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
			/// Este metodo realiza o "Select" no objeto VERBETE do banco de dados
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
					 Query += " VERBETE,";
					 Query += " NOME,";
					 Query += " NOMEORDENACAO,";
					 Query += " DATACRIACAO,";
					 Query += " DATAALTERACAO,";
					 Query += " DATAINCLUSAO";
					 Query += " From [VERBETE]";
					if ( VERBETE !=-1  )
					{
						Query += " " + Conector + "VERBETE = " + VERBETE;
						Conector = " And ";
					}
					if ( NOME !=String.Empty  )
					{
						Query += " " + Conector + "NOME = "+"'" + ConnectionInfo.FormataString(NOME)+"'";
						Conector = " And ";
					}
					if ( NOMEORDENACAO !=String.Empty  )
					{
						Query += " " + Conector + "NOMEORDENACAO = "+"'" + ConnectionInfo.FormataString(NOMEORDENACAO)+"'";
						Conector = " And ";
					}
					if ( DATACRIACAO !=new DateTime()  )
					{
						Query += " " + Conector + "DATACRIACAO = "+"'" + ConnectionInfo.FormataData(DATACRIACAO)+"'";
						Conector = " And ";
					}
					if ( DATAALTERACAO !=new DateTime()  )
					{
						Query += " " + Conector + "DATAALTERACAO = "+"'" + ConnectionInfo.FormataData(DATAALTERACAO)+"'";
						Conector = " And ";
					}
					if ( DATAINCLUSAO !=new DateTime()  )
					{
						Query += " " + Conector + "DATAINCLUSAO = "+"'" + ConnectionInfo.FormataData(DATAINCLUSAO)+"'";
						Conector = " And ";
					}
					Query += " Order By";
					Query += " VERBETE ";


					DataSet retorno = comando.CallSql(Query,ConnectionInfo.Conexao);

					mensagem = comando.LastError;

					if (this.mensagem !=String.Empty)
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
			/// Este metodo realiza o "Select" no objeto VERBETE do banco de dados, 
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
					 Query += " VERBETE,";
					 Query += " NOME,";
					 Query += " NOMEORDENACAO,";
					 Query += " DATACRIACAO,";
					 Query += " DATAALTERACAO,";
					 Query += " DATAINCLUSAO";
					 Query += " From [VERBETE]";
					if ( VERBETE !=-1  )
					{
						Query += " " + Conector + "VERBETE = " + VERBETE;
						Conector = " And ";
					}
					if ( NOME !=String.Empty  )
					{
						Query += " " + Conector + "NOME = "+"'" + ConnectionInfo.FormataString(NOME)+"'";
						Conector = " And ";
					}
					if ( NOMEORDENACAO !=String.Empty  )
					{
						Query += " " + Conector + "NOMEORDENACAO = "+"'" + ConnectionInfo.FormataString(NOMEORDENACAO)+"'";
						Conector = " And ";
					}
					if ( DATACRIACAO !=new DateTime()  )
					{
						Query += " " + Conector + "DATACRIACAO = "+"'" + ConnectionInfo.FormataData(DATACRIACAO)+"'";
						Conector = " And ";
					}
					if ( DATAALTERACAO !=new DateTime()  )
					{
						Query += " " + Conector + "DATAALTERACAO = "+"'" + ConnectionInfo.FormataData(DATAALTERACAO)+"'";
						Conector = " And ";
					}
					if ( DATAINCLUSAO !=new DateTime()  )
					{
						Query += " " + Conector + "DATAINCLUSAO = "+"'" + ConnectionInfo.FormataData(DATAINCLUSAO)+"'";
						Conector = " And ";
					}
					Query += " Order By";
					Query += " VERBETE ";


					DataSet retorno = comando.CallSql(Query,ConnectionInfo.Conexao);

					mensagem = comando.LastError;

					if (this.mensagem !=String.Empty)
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
			/// Realiza o "Select" no objeto VERBETE do banco de dados
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
					 Query += " VERBETE,";
					 Query += " NOME,";
					 Query += " NOMEORDENACAO,";
					 Query += " DATACRIACAO,";
					 Query += " DATAALTERACAO,";
					 Query += " DATAINCLUSAO";
					 Query += " From [VERBETE]";
					if ( VERBETE !=-1  )
					{
						Query += " " + Conector + "VERBETE = " + VERBETE;
						Conector = " And ";
					}
					if ( NOME !=String.Empty  )
					{
						Query += " " + Conector + "NOME Like "+"'%" + NOME+"%'";
						Conector = " And ";
					}
					if ( NOMEORDENACAO !=String.Empty  )
					{
						Query += " " + Conector + "NOMEORDENACAO Like "+"'%" + NOMEORDENACAO+"%'";
						Conector = " And ";
					}
					if ( DATACRIACAO !=new DateTime()  )
					{
						Query += " " + Conector + "DATACRIACAO = "+"'" +ConnectionInfo.FormataData(DATACRIACAO)+"'";
						Conector = " And ";
					}
					if ( DATAALTERACAO !=new DateTime()  )
					{
						Query += " " + Conector + "DATAALTERACAO = "+"'" +ConnectionInfo.FormataData(DATAALTERACAO)+"'";
						Conector = " And ";
					}
					if ( DATAINCLUSAO !=new DateTime()  )
					{
						Query += " " + Conector + "DATAINCLUSAO = "+"'" +ConnectionInfo.FormataData(DATAINCLUSAO)+"'";
						Conector = " And ";
					}
					Query += " Order By";
					Query += " VERBETE ";


					DataSet retorno = comando.CallSql(Query,ConnectionInfo.Conexao);

					mensagem = comando.LastError;

					if (this.mensagem !=String.Empty)
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
			/// Realiza o "Select" no objeto VERBETE do banco de dados
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
					 Query += " VERBETE,";
					 Query += " NOME,";
					 Query += " NOMEORDENACAO,";
					 Query += " DATACRIACAO,";
					 Query += " DATAALTERACAO,";
					 Query += " DATAINCLUSAO";
					 Query += " From [VERBETE]";
					if ( VERBETE !=-1  )
					{
						Query += " " + Conector + "VERBETE = " + VERBETE;
						Conector = " And ";
					}
					if ( NOME !=String.Empty  )
					{
						Query += " " + Conector + "NOME Like "+"'%" + NOME+"%'";
						Conector = " And ";
					}
					if ( NOMEORDENACAO !=String.Empty  )
					{
						Query += " " + Conector + "NOMEORDENACAO Like "+"'%" + NOMEORDENACAO+"%'";
						Conector = " And ";
					}
					if ( DATACRIACAO !=new DateTime()  )
					{
						Query += " " + Conector + "DATACRIACAO = "+"'" +ConnectionInfo.FormataData(DATACRIACAO)+"'";
						Conector = " And ";
					}
					if ( DATAALTERACAO !=new DateTime()  )
					{
						Query += " " + Conector + "DATAALTERACAO = "+"'" +ConnectionInfo.FormataData(DATAALTERACAO)+"'";
						Conector = " And ";
					}
					if ( DATAINCLUSAO !=new DateTime()  )
					{
						Query += " " + Conector + "DATAINCLUSAO = "+"'" +ConnectionInfo.FormataData(DATAINCLUSAO)+"'";
						Conector = " And ";
					}
					Query += " Order By";
					Query += " VERBETE ";


					DataSet retorno = comando.CallSql(Query,ConnectionInfo.Conexao);

					mensagem = comando.LastError;

					if (this.mensagem !=String.Empty)
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
			/// Este metodo realiza o "Select" no objeto VERBETE do banco de dados
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
					 Query += " VERBETE,";
					 Query += " NOME,";
					 Query += " NOMEORDENACAO,";
					 Query += " DATACRIACAO,";
					 Query += " DATAALTERACAO,";
					 Query += " DATAINCLUSAO";
					 Query += " From [VERBETE]";
					if ( VERBETE !=-1  )
					{
						Query += " " + Conector + "VERBETE = " + VERBETE;
						Conector = " And ";
					}


					DataSet retorno = comando.CallSql(Query,ConnectionInfo.Conexao);

					mensagem = comando.LastError;

					if (this.mensagem !=String.Empty)
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
					retorno += "VERBETE:		" + this.VERBETE.ToString().Trim();
					retorno += "NOME:		" + this.NOME.ToString().Trim();
					retorno += "NOMEORDENACAO:		" + this.NOMEORDENACAO.ToString().Trim();
					retorno += "DATACRIACAO:		" + this.DATACRIACAO.ToString().Trim();
					retorno += "DATAALTERACAO:		" + this.DATAALTERACAO.ToString().Trim();
					retorno += "DATAINCLUSAO:		" + this.DATAINCLUSAO.ToString().Trim();

					return retorno;

				}
				catch (Exception ex)
				{
					return ex.Message;
				}
			}

			#endregion

        #region "Metodos para as pesquisas"

        /// <summary>
            /// public DataSet Pesquisa_E(List<String> ListaCodigos)
        /// Realiza o "Select" no objeto VERBETE do banco de dados
        /// 
        /// e feita uma busca avancada nos registros da Tabela. 
        /// </summary>
        public DataSet Pesquisa_E(List<String> ListaCodigos)
        {
            try
            {
                cls_comando comando = new cls_comando();
                ConnectionInfo conexao = new ConnectionInfo();

                String Query = "";
                String Condicao = "";

                Query += " Select distinct";
                Query += " VERBETE.VERBETE,";
                Query += " VERBETE.NOME,";
                Query += " VERBETE.NOMEORDENACAO";
                Query += " FROM VERBETE, ACEPCAO, OCORRENCIAACEPCAO";
                Query += " WHERE VERBETE.VERBETE = ACEPCAO.VERBETE";
                Query += " AND ACEPCAO.ACEPCAO = OCORRENCIAACEPCAO.ACEPCAO";
                foreach (String codigo in ListaCodigos)
                {
                    Condicao += "OCORRENCIAACEPCAO.PALAVRAS Like '%{" +  codigo + "}%' AND ";
                }
                //retirando o ultimo OR 
                Condicao = Condicao.Substring(0, Condicao.Length - 4);

                Query += " AND (" + Condicao + ")";
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

        /// <summary>
        /// public DataSet Pesquisa_OU(List<String> ListaCodigos)
        /// Realiza o "Select" no objeto VERBETE do banco de dados
        /// 
        /// e feita uma busca avancada nos registros da Tabela. 
        /// </summary>
        public DataSet Pesquisa_OU(List<String> ListaCodigos)
        {
            try
            {
                cls_comando comando = new cls_comando();
                ConnectionInfo conexao = new ConnectionInfo();

                String Query = "";
                String Condicao = "";

                Query += " Select distinct";
                Query += " VERBETE.VERBETE,";
                Query += " VERBETE.NOME,";
                Query += " VERBETE.NOMEORDENACAO";
                Query += " FROM VERBETE, ACEPCAO, OCORRENCIAACEPCAO";
                Query += " WHERE VERBETE.VERBETE = ACEPCAO.VERBETE";
                Query += " AND ACEPCAO.ACEPCAO = OCORRENCIAACEPCAO.ACEPCAO";

                foreach (String codigo in ListaCodigos)
                {
                    Condicao += "OCORRENCIAACEPCAO.PALAVRAS Like '%{" +  codigo  + "}%' OR ";
                }
                //retirando o ultimo OR 
                Condicao = Condicao.Substring(0, Condicao.Length-3); 

                Query += " AND (" + Condicao + ")";
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

        /// <summary>
        /// public DataSet Pesquisa_EE(List<String> ListaCodigos)
        /// Realiza o "Select" no objeto VERBETE do banco de dados
        /// 
        /// e feita uma busca avancada nos registros da Tabela. 
        /// </summary>
        public DataSet Pesquisa_EE(List<String> ListaCodigos)
        {
            try
            {
                cls_comando comando = new cls_comando();
                ConnectionInfo conexao = new ConnectionInfo();

                String Query = "";
                String Condicao = "";

                Query += " Select distinct";
                Query += " VERBETE.VERBETE,";
                Query += " VERBETE.NOME,";
                Query += " VERBETE.NOMEORDENACAO";
                Query += " FROM VERBETE, ACEPCAO, OCORRENCIAACEPCAO";
                Query += " WHERE VERBETE.VERBETE = ACEPCAO.VERBETE";
                Query += " AND ACEPCAO.ACEPCAO = OCORRENCIAACEPCAO.ACEPCAO";
                foreach (String codigo in ListaCodigos)
                {
                    Condicao +=  codigo ;
                }              

                Query += " AND OCORRENCIAACEPCAO.PALAVRAS Like '%" + Condicao + "%'";
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


        /// <summary>
        /// public DataSet Pesquisa_TIT(List<String> ListaCodigos)
        /// Realiza o "Select" no objeto VERBETE do banco de dados
        /// 
        /// e feita uma busca avancada nos registros da Tabela. 
        /// </summary>
        public DataSet Pesquisa_TIT(List<String> ListaCodigos)
        {
            try
            {
                cls_comando comando = new cls_comando();
                ConnectionInfo conexao = new ConnectionInfo();

                String Query = "";
                String Condicao = "";

                Query += " Select distinct";
                Query += " VERBETE.VERBETE,";
                Query += " VERBETE.NOME,";
                Query += " VERBETE.NOMEORDENACAO";
                Query += " FROM VERBETE, ACEPCAO, OCORRENCIAACEPCAO";
                Query += " WHERE VERBETE.VERBETE = ACEPCAO.VERBETE";
                Query += " AND ACEPCAO.ACEPCAO = OCORRENCIAACEPCAO.ACEPCAO";
                foreach (String codigo in ListaCodigos)
                {
                    Condicao +=  codigo ;
                }              

                Query += " AND OCORRENCIAACEPCAO.PALAVRAS Like '%" + Condicao + "%'";
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
