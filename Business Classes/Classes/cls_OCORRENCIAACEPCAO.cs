using System;
using System.Data;
using Business_DataBase;
using System.Drawing;
using BusinessClass;

namespace EnciclopediaJuridica.BusinessClass
{

	/// <summary>
	/// Definicao da Classe cls_OCORRENCIAACEPCAO
	/// Esta classe representa o objeto OCORRENCIAACEPCAO no banco de dados
	/// Todas as operacoes basicas (Inclusao, Alteracao, Exclusao, Consulta) sao feitas por esta classe
	/// Que utilizada internamente pela clase rul_OCORRENCIAACEPCAO
	/// 
	/// Nota: Esta classe nao deve ser instanciada dentro do projeto, pois a arquitetura de camadas
	/// Define a classe rul_OCORRENCIAACEPCAO para utilizacao na camada de apresentacao do projeto
	/// 
	/// </summary>
	public class cls_OCORRENCIAACEPCAO
	{
        #region "Variaveis" 

			private  int _ACEPCAO = -1;
			private  String _PALAVRAS = String.Empty;

        private String _mensagem = "";

        #endregion

        #region "Construtures" 

        public cls_OCORRENCIAACEPCAO()
        {
        }

        /// <summary>
        /// Construtor da Classe OCORRENCIAACEPCAO com passagem de parametros da Chave Primaria
        /// </summary>
        public cls_OCORRENCIAACEPCAO(  int par_ACEPCAO)
        {
            try
            {
					this.ACEPCAO = par_ACEPCAO;
 
            }
            catch (Exception ex)
            {
                this.mensagem = ex.Message;
            }
        }

        #endregion

        #region "Propriedades" 
			public  int ACEPCAO
			{
				get {return _ACEPCAO;}
				set {_ACEPCAO = value;}
			}

			public  String PALAVRAS
			{
				get {return _PALAVRAS;}
				set {_PALAVRAS = value;}
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
			/// Este metodo realiza o "insert" no objeto OCORRENCIAACEPCAO do banco de dados
			/// </summary>
			public Boolean Insert()
			{
				try
				{
					cls_comando comando = new cls_comando();
					ConnectionInfo conexao = new ConnectionInfo();


					String Query = "";
					Boolean retorno = false;

					Query += " insert into OCORRENCIAACEPCAO(";
					Query += " PALAVRAS";
					Query += " ) values ( ";
					Query += "'" + ConnectionInfo.FormataString(PALAVRAS) + "'";
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
			/// Este metodo realiza o "Update" no objeto OCORRENCIAACEPCAO do banco de dados
			/// </summary>
			public Boolean Update()
			{
				try
				{
					cls_comando comando = new cls_comando();
					ConnectionInfo conexao = new ConnectionInfo();
					String Query = "";
					Boolean retorno = false;

					Query += " Update OCORRENCIAACEPCAO set ";
					Query += "PALAVRAS = " + "'" + ConnectionInfo.FormataString(PALAVRAS) + "'";
					Query += " Where  ACEPCAO = "  + _ACEPCAO;


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
			/// Este metodo realiza o "Delete" no objeto OCORRENCIAACEPCAO do banco de dados
			/// </summary>
			public Boolean Delete()
			{
				try
				{
					cls_comando comando = new cls_comando();
					ConnectionInfo conexao = new ConnectionInfo();
					String Query = "";
					Boolean retorno = false;

					Query += " Delete OCORRENCIAACEPCAO ";
					Query += " Where  ACEPCAO = "  + _ACEPCAO;


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
			/// Este metodo realiza o "Delete" no objeto OCORRENCIAACEPCAO do banco de dados
			/// </summary>
			public Boolean DeleteMasterDetail()
			{
				try
				{
					cls_comando comando = new cls_comando();
					ConnectionInfo conexao = new ConnectionInfo();
					String Query = "";
					Boolean retorno = false;

					Query += " Delete OCORRENCIAACEPCAO ";
					Query += " Where  ACEPCAO = "  + _ACEPCAO;


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
			/// Este metodo realiza o "Select" no objeto OCORRENCIAACEPCAO do banco de dados
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
					 Query += " ACEPCAO,";
					 Query += " PALAVRAS";
					 Query += " From [OCORRENCIAACEPCAO]";
					if ( ACEPCAO !=-1  )
					{
						Query += " " + Conector + "ACEPCAO = " + ACEPCAO;
						Conector = " And ";
					}
					if ( PALAVRAS !=String.Empty  )
					{
						Query += " " + Conector + "PALAVRAS = "+"'" + ConnectionInfo.FormataString(PALAVRAS)+"'";
						Conector = " And ";
					}
					Query += " Order By";
					Query += " ACEPCAO ";


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
			/// Este metodo realiza o "Select" no objeto OCORRENCIAACEPCAO do banco de dados, 
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
					 Query += " ACEPCAO,";
					 Query += " PALAVRAS";
					 Query += " From [OCORRENCIAACEPCAO]";
					if ( ACEPCAO !=-1  )
					{
						Query += " " + Conector + "ACEPCAO = " + ACEPCAO;
						Conector = " And ";
					}
					if ( PALAVRAS !=String.Empty  )
					{
						Query += " " + Conector + "PALAVRAS = "+"'" + ConnectionInfo.FormataString(PALAVRAS)+"'";
						Conector = " And ";
					}
					Query += " Order By";
					Query += " ACEPCAO ";


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
			/// Realiza o "Select" no objeto OCORRENCIAACEPCAO do banco de dados
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
					 Query += " ACEPCAO,";
					 Query += " PALAVRAS";
					 Query += " From [OCORRENCIAACEPCAO]";
					if ( ACEPCAO !=-1  )
					{
						Query += " " + Conector + "ACEPCAO = " + ACEPCAO;
						Conector = " And ";
					}
					if ( PALAVRAS !=String.Empty  )
					{
						Query += " " + Conector + "PALAVRAS Like "+"'%" + PALAVRAS+"%'";
						Conector = " And ";
					}
					Query += " Order By";
					Query += " ACEPCAO ";


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
			/// Realiza o "Select" no objeto OCORRENCIAACEPCAO do banco de dados
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
					 Query += " ACEPCAO,";
					 Query += " PALAVRAS";
					 Query += " From [OCORRENCIAACEPCAO]";
					if ( ACEPCAO !=-1  )
					{
						Query += " " + Conector + "ACEPCAO = " + ACEPCAO;
						Conector = " And ";
					}
					if ( PALAVRAS !=String.Empty  )
					{
						Query += " " + Conector + "PALAVRAS Like "+"'%" + PALAVRAS+"%'";
						Conector = " And ";
					}
					Query += " Order By";
					Query += " ACEPCAO ";


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
			/// Este metodo realiza o "Select" no objeto OCORRENCIAACEPCAO do banco de dados
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
					 Query += " ACEPCAO,";
					 Query += " PALAVRAS";
					 Query += " From [OCORRENCIAACEPCAO]";
					if ( ACEPCAO !=-1  )
					{
						Query += " " + Conector + "ACEPCAO = " + ACEPCAO;
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
					retorno += "ACEPCAO:		" + this.ACEPCAO.ToString().Trim();
					retorno += "PALAVRAS:		" + this.PALAVRAS.ToString().Trim();

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
