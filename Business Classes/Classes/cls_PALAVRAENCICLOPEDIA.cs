using System;
using System.Data;
using Business_DataBase;
using System.Drawing;
using BusinessClass;

namespace EnciclopediaJuridica.BusinessClass
{

	/// <summary>
	/// Definicao da Classe cls_PALAVRAENCICLOPEDIA
	/// Esta classe representa o objeto PALAVRAENCICLOPEDIA no banco de dados
	/// Todas as operacoes basicas (Inclusao, Alteracao, Exclusao, Consulta) sao feitas por esta classe
	/// Que utilizada internamente pela clase rul_PALAVRAENCICLOPEDIA
	/// 
	/// Nota: Esta classe nao deve ser instanciada dentro do projeto, pois a arquitetura de camadas
	/// Define a classe rul_PALAVRAENCICLOPEDIA para utilizacao na camada de apresentacao do projeto
	/// 
	/// </summary>
	public class cls_PALAVRAENCICLOPEDIA
	{
        #region "Variaveis" 

			private  int _PALAVRAENCICLOPEDIA = -1;
			private  String _NOME = String.Empty;
			private  DateTime _DATAINCLUSAO = new DateTime();

        private String _mensagem = "";

        #endregion

        #region "Construtures" 

        public cls_PALAVRAENCICLOPEDIA()
        {
        }

        /// <summary>
        /// Construtor da Classe PALAVRAENCICLOPEDIA com passagem de parametros da Chave Primaria
        /// </summary>
        public cls_PALAVRAENCICLOPEDIA(  int par_PALAVRAENCICLOPEDIA)
        {
            try
            {
					this.PALAVRAENCICLOPEDIA = par_PALAVRAENCICLOPEDIA;
 
            }
            catch (Exception ex)
            {
                this.mensagem = ex.Message;
            }
        }

        #endregion

        #region "Propriedades" 
			public  int PALAVRAENCICLOPEDIA
			{
				get {return _PALAVRAENCICLOPEDIA;}
				set {_PALAVRAENCICLOPEDIA = value;}
			}

			public  String NOME
			{
				get {return _NOME;}
				set {_NOME = value;}
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
			/// Este metodo realiza o "insert" no objeto PALAVRAENCICLOPEDIA do banco de dados
			/// </summary>
			public Boolean Insert()
			{
				try
				{
					cls_comando comando = new cls_comando();
					ConnectionInfo conexao = new ConnectionInfo();


					String Query = "";
					Boolean retorno = false;

					Query += " insert into PALAVRAENCICLOPEDIA(";
					Query += " NOME,";
					Query += " DATAINCLUSAO";
					Query += " ) values ( ";
					Query += "'" + ConnectionInfo.FormataString(NOME) + "'"+ ",";
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
			/// Este metodo realiza o "Update" no objeto PALAVRAENCICLOPEDIA do banco de dados
			/// </summary>
			public Boolean Update()
			{
				try
				{
					cls_comando comando = new cls_comando();
					ConnectionInfo conexao = new ConnectionInfo();
					String Query = "";
					Boolean retorno = false;

					Query += " Update PALAVRAENCICLOPEDIA set ";
					Query += "NOME = " + "'" + ConnectionInfo.FormataString(NOME) + "'"+ ",";
					Query += "DATAINCLUSAO = " + "'" + ConnectionInfo.FormataData(DATAINCLUSAO) + "'";
					Query += " Where  PALAVRAENCICLOPEDIA = "  + _PALAVRAENCICLOPEDIA;


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
			/// Este metodo realiza o "Delete" no objeto PALAVRAENCICLOPEDIA do banco de dados
			/// </summary>
			public Boolean Delete()
			{
				try
				{
					cls_comando comando = new cls_comando();
					ConnectionInfo conexao = new ConnectionInfo();
					String Query = "";
					Boolean retorno = false;

					Query += " Delete PALAVRAENCICLOPEDIA ";
					Query += " Where  PALAVRAENCICLOPEDIA = "  + _PALAVRAENCICLOPEDIA;


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
			/// Este metodo realiza o "Delete" no objeto PALAVRAENCICLOPEDIA do banco de dados
			/// </summary>
			public Boolean DeleteMasterDetail()
			{
				try
				{
					cls_comando comando = new cls_comando();
					ConnectionInfo conexao = new ConnectionInfo();
					String Query = "";
					Boolean retorno = false;

					Query += " Delete PALAVRAENCICLOPEDIA ";
					Query += " Where  PALAVRAENCICLOPEDIA = "  + _PALAVRAENCICLOPEDIA;


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
			/// Este metodo realiza o "Select" no objeto PALAVRAENCICLOPEDIA do banco de dados
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
					 Query += " PALAVRAENCICLOPEDIA,";
					 Query += " NOME,";
					 Query += " DATAINCLUSAO";
					 Query += " From [PALAVRAENCICLOPEDIA]";
					if ( PALAVRAENCICLOPEDIA !=-1  )
					{
						Query += " " + Conector + "PALAVRAENCICLOPEDIA = " + PALAVRAENCICLOPEDIA;
						Conector = " And ";
					}
					if ( NOME !=String.Empty  )
					{
						Query += " " + Conector + "NOME = "+"'" + ConnectionInfo.FormataString(NOME)+"'";
						Conector = " And ";
					}
					if ( DATAINCLUSAO !=new DateTime()  )
					{
						Query += " " + Conector + "DATAINCLUSAO = "+"'" + ConnectionInfo.FormataData(DATAINCLUSAO)+"'";
						Conector = " And ";
					}
					Query += " Order By";
					Query += " PALAVRAENCICLOPEDIA ";


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
			/// Este metodo realiza o "Select" no objeto PALAVRAENCICLOPEDIA do banco de dados, 
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
					 Query += " PALAVRAENCICLOPEDIA,";
					 Query += " NOME,";
					 Query += " DATAINCLUSAO";
					 Query += " From [PALAVRAENCICLOPEDIA]";
					if ( PALAVRAENCICLOPEDIA !=-1  )
					{
						Query += " " + Conector + "PALAVRAENCICLOPEDIA = " + PALAVRAENCICLOPEDIA;
						Conector = " And ";
					}
					if ( NOME !=String.Empty  )
					{
						Query += " " + Conector + "NOME = "+"'" + ConnectionInfo.FormataString(NOME)+"'";
						Conector = " And ";
					}
					if ( DATAINCLUSAO !=new DateTime()  )
					{
						Query += " " + Conector + "DATAINCLUSAO = "+"'" + ConnectionInfo.FormataData(DATAINCLUSAO)+"'";
						Conector = " And ";
					}
					Query += " Order By";
					Query += " PALAVRAENCICLOPEDIA ";


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
			/// Realiza o "Select" no objeto PALAVRAENCICLOPEDIA do banco de dados
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
					 Query += " PALAVRAENCICLOPEDIA,";
					 Query += " NOME,";
					 Query += " DATAINCLUSAO";
					 Query += " From [PALAVRAENCICLOPEDIA]";
					if ( PALAVRAENCICLOPEDIA !=-1  )
					{
						Query += " " + Conector + "PALAVRAENCICLOPEDIA = " + PALAVRAENCICLOPEDIA;
						Conector = " And ";
					}
					if ( NOME !=String.Empty  )
					{
						Query += " " + Conector + "NOME Like "+"'%" + NOME+"%'";
						Conector = " And ";
					}
					if ( DATAINCLUSAO !=new DateTime()  )
					{
						Query += " " + Conector + "DATAINCLUSAO = "+"'" +ConnectionInfo.FormataData(DATAINCLUSAO)+"'";
						Conector = " And ";
					}
					Query += " Order By";
					Query += " PALAVRAENCICLOPEDIA ";


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
			/// Realiza o "Select" no objeto PALAVRAENCICLOPEDIA do banco de dados
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
					 Query += " PALAVRAENCICLOPEDIA,";
					 Query += " NOME,";
					 Query += " DATAINCLUSAO";
					 Query += " From [PALAVRAENCICLOPEDIA]";
					if ( PALAVRAENCICLOPEDIA !=-1  )
					{
						Query += " " + Conector + "PALAVRAENCICLOPEDIA = " + PALAVRAENCICLOPEDIA;
						Conector = " And ";
					}
					if ( NOME !=String.Empty  )
					{
						Query += " " + Conector + "NOME Like "+"'%" + NOME+"%'";
						Conector = " And ";
					}
					if ( DATAINCLUSAO !=new DateTime()  )
					{
						Query += " " + Conector + "DATAINCLUSAO = "+"'" +ConnectionInfo.FormataData(DATAINCLUSAO)+"'";
						Conector = " And ";
					}
					Query += " Order By";
					Query += " PALAVRAENCICLOPEDIA ";


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
			/// Este metodo realiza o "Select" no objeto PALAVRAENCICLOPEDIA do banco de dados
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
					 Query += " PALAVRAENCICLOPEDIA,";
					 Query += " NOME,";
					 Query += " DATAINCLUSAO";
					 Query += " From [PALAVRAENCICLOPEDIA]";
					if ( PALAVRAENCICLOPEDIA !=-1  )
					{
						Query += " " + Conector + "PALAVRAENCICLOPEDIA = " + PALAVRAENCICLOPEDIA;
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
					retorno += "PALAVRAENCICLOPEDIA:		" + this.PALAVRAENCICLOPEDIA.ToString().Trim();
					retorno += "NOME:		" + this.NOME.ToString().Trim();
					retorno += "DATAINCLUSAO:		" + this.DATAINCLUSAO.ToString().Trim();

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
