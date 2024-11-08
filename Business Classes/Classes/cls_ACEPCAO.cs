using System;
using System.Data;
using Business_DataBase;
using System.Drawing;
using BusinessClass;

namespace EnciclopediaJuridica.BusinessClass
{

	/// <summary>
	/// Definicao da Classe cls_ACEPCAO
	/// Esta classe representa o objeto ACEPCAO no banco de dados
	/// Todas as operacoes basicas (Inclusao, Alteracao, Exclusao, Consulta) sao feitas por esta classe
	/// Que utilizada internamente pela clase rul_ACEPCAO
	/// 
	/// Nota: Esta classe nao deve ser instanciada dentro do projeto, pois a arquitetura de camadas
	/// Define a classe rul_ACEPCAO para utilizacao na camada de apresentacao do projeto
	/// 
	/// </summary>
	public class cls_ACEPCAO
	{
        #region "Variaveis" 

			private  int _ACEPCAO = -1;
			private  int _VERBETE = -1;
			private  String _DEFINICAO = String.Empty;
			private  DateTime _DATAINCLUSAO = new DateTime();
			private  DateTime _DATAALTERACAO = new DateTime();
			private  String _NOME = String.Empty;

        private String _mensagem = "";

        #endregion

        #region "Construtures" 

        public cls_ACEPCAO()
        {
        }

        /// <summary>
        /// Construtor da Classe ACEPCAO com passagem de parametros da Chave Primaria
        /// </summary>
        public cls_ACEPCAO(  int par_ACEPCAO)
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

			public  int VERBETE
			{
				get {return _VERBETE;}
				set {_VERBETE = value;}
			}

			public  String DEFINICAO
			{
				get {return _DEFINICAO;}
				set {_DEFINICAO = value;}
			}

			public  DateTime DATAINCLUSAO
			{
				get {return _DATAINCLUSAO;}
				set {_DATAINCLUSAO = value;}
			}

			public  DateTime DATAALTERACAO
			{
				get {return _DATAALTERACAO;}
				set {_DATAALTERACAO = value;}
			}

			public  String NOME
			{
				get {return _NOME;}
				set {_NOME = value;}
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
			/// Este metodo realiza o "insert" no objeto ACEPCAO do banco de dados
			/// </summary>
			public Boolean Insert()
			{
				try
				{
					cls_comando comando = new cls_comando();
					ConnectionInfo conexao = new ConnectionInfo();


					String Query = "";
					Boolean retorno = false;

					Query += " insert into ACEPCAO(";
					Query += " VERBETE,";
					Query += " DEFINICAO,";
					Query += " DATAINCLUSAO,";
					Query += " DATAALTERACAO,";
					Query += " NOME";
					Query += " ) values ( ";
					Query += VERBETE+ ",";
					Query += "'" + ConnectionInfo.FormataString(DEFINICAO) + "'"+ ",";
					Query += "'" + ConnectionInfo.FormataData(DATAINCLUSAO) + "'"+ ",";
					Query += "'" + ConnectionInfo.FormataData(DATAALTERACAO) + "'"+ ",";
					Query += "'" + ConnectionInfo.FormataString(NOME) + "'";
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
			/// Este metodo realiza o "Update" no objeto ACEPCAO do banco de dados
			/// </summary>
			public Boolean Update()
			{
				try
				{
					cls_comando comando = new cls_comando();
					ConnectionInfo conexao = new ConnectionInfo();
					String Query = "";
					Boolean retorno = false;

					Query += " Update ACEPCAO set ";
					Query += "VERBETE = " + VERBETE+ ",";
					Query += "DEFINICAO = " + "'" + ConnectionInfo.FormataString(DEFINICAO) + "'"+ ",";
					Query += "DATAINCLUSAO = " + "'" + ConnectionInfo.FormataData(DATAINCLUSAO) + "'"+ ",";
					Query += "DATAALTERACAO = " + "'" + ConnectionInfo.FormataData(DATAALTERACAO) + "'"+ ",";
					Query += "NOME = " + "'" + ConnectionInfo.FormataString(NOME) + "'";
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
			/// Este metodo realiza o "Delete" no objeto ACEPCAO do banco de dados
			/// </summary>
			public Boolean Delete()
			{
				try
				{
					cls_comando comando = new cls_comando();
					ConnectionInfo conexao = new ConnectionInfo();
					String Query = "";
					Boolean retorno = false;

					Query += " Delete ACEPCAO ";
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
			/// Este metodo realiza o "Delete" no objeto ACEPCAO do banco de dados
			/// </summary>
			public Boolean DeleteMasterDetail()
			{
				try
				{
					cls_comando comando = new cls_comando();
					ConnectionInfo conexao = new ConnectionInfo();
					String Query = "";
					Boolean retorno = false;

					Query += " Delete ACEPCAO ";
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
			/// Este metodo realiza o "Select" no objeto ACEPCAO do banco de dados
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
					 Query += " VERBETE,";
					 Query += " DEFINICAO,";
					 Query += " DATAINCLUSAO,";
					 Query += " DATAALTERACAO,";
					 Query += " NOME";
					 Query += " From [ACEPCAO]";
					if ( ACEPCAO !=-1  )
					{
						Query += " " + Conector + "ACEPCAO = " + ACEPCAO;
						Conector = " And ";
					}
					if ( VERBETE !=-1  )
					{
						Query += " " + Conector + "VERBETE = " + VERBETE;
						Conector = " And ";
					}
					if ( DEFINICAO !=String.Empty  )
					{
						Query += " " + Conector + "DEFINICAO = "+"'" + ConnectionInfo.FormataString(DEFINICAO)+"'";
						Conector = " And ";
					}
					if ( DATAINCLUSAO !=new DateTime()  )
					{
						Query += " " + Conector + "DATAINCLUSAO = "+"'" + ConnectionInfo.FormataData(DATAINCLUSAO)+"'";
						Conector = " And ";
					}
					if ( DATAALTERACAO !=new DateTime()  )
					{
						Query += " " + Conector + "DATAALTERACAO = "+"'" + ConnectionInfo.FormataData(DATAALTERACAO)+"'";
						Conector = " And ";
					}
					if ( NOME !=String.Empty  )
					{
						Query += " " + Conector + "NOME = "+"'" + ConnectionInfo.FormataString(NOME)+"'";
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
			/// Este metodo realiza o "Select" no objeto ACEPCAO do banco de dados, 
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
					 Query += " VERBETE,";
					 Query += " DEFINICAO,";
					 Query += " DATAINCLUSAO,";
					 Query += " DATAALTERACAO,";
					 Query += " NOME";
					 Query += " From [ACEPCAO]";
					if ( ACEPCAO !=-1  )
					{
						Query += " " + Conector + "ACEPCAO = " + ACEPCAO;
						Conector = " And ";
					}
					if ( VERBETE !=-1  )
					{
						Query += " " + Conector + "VERBETE = " + VERBETE;
						Conector = " And ";
					}
					if ( DEFINICAO !=String.Empty  )
					{
						Query += " " + Conector + "DEFINICAO = "+"'" + ConnectionInfo.FormataString(DEFINICAO)+"'";
						Conector = " And ";
					}
					if ( DATAINCLUSAO !=new DateTime()  )
					{
						Query += " " + Conector + "DATAINCLUSAO = "+"'" + ConnectionInfo.FormataData(DATAINCLUSAO)+"'";
						Conector = " And ";
					}
					if ( DATAALTERACAO !=new DateTime()  )
					{
						Query += " " + Conector + "DATAALTERACAO = "+"'" + ConnectionInfo.FormataData(DATAALTERACAO)+"'";
						Conector = " And ";
					}
					if ( NOME !=String.Empty  )
					{
						Query += " " + Conector + "NOME = "+"'" + ConnectionInfo.FormataString(NOME)+"'";
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
			/// Realiza o "Select" no objeto ACEPCAO do banco de dados
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
					 Query += " VERBETE,";
					 Query += " DEFINICAO,";
					 Query += " DATAINCLUSAO,";
					 Query += " DATAALTERACAO,";
					 Query += " NOME";
					 Query += " From [ACEPCAO]";
					if ( ACEPCAO !=-1  )
					{
						Query += " " + Conector + "ACEPCAO = " + ACEPCAO;
						Conector = " And ";
					}
					if ( VERBETE !=-1  )
					{
						Query += " " + Conector + "VERBETE = " + VERBETE;
						Conector = " And ";
					}
					if ( DEFINICAO !=String.Empty  )
					{
						Query += " " + Conector + "DEFINICAO Like "+"'%" + DEFINICAO+"%'";
						Conector = " And ";
					}
					if ( DATAINCLUSAO !=new DateTime()  )
					{
						Query += " " + Conector + "DATAINCLUSAO = "+"'" +ConnectionInfo.FormataData(DATAINCLUSAO)+"'";
						Conector = " And ";
					}
					if ( DATAALTERACAO !=new DateTime()  )
					{
						Query += " " + Conector + "DATAALTERACAO = "+"'" +ConnectionInfo.FormataData(DATAALTERACAO)+"'";
						Conector = " And ";
					}
					if ( NOME !=String.Empty  )
					{
						Query += " " + Conector + "NOME Like "+"'%" + NOME+"%'";
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
			/// Realiza o "Select" no objeto ACEPCAO do banco de dados
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
					 Query += " VERBETE,";
					 Query += " DEFINICAO,";
					 Query += " DATAINCLUSAO,";
					 Query += " DATAALTERACAO,";
					 Query += " NOME";
					 Query += " From [ACEPCAO]";
					if ( ACEPCAO !=-1  )
					{
						Query += " " + Conector + "ACEPCAO = " + ACEPCAO;
						Conector = " And ";
					}
					if ( VERBETE !=-1  )
					{
						Query += " " + Conector + "VERBETE = " + VERBETE;
						Conector = " And ";
					}
					if ( DEFINICAO !=String.Empty  )
					{
						Query += " " + Conector + "DEFINICAO Like "+"'%" + DEFINICAO+"%'";
						Conector = " And ";
					}
					if ( DATAINCLUSAO !=new DateTime()  )
					{
						Query += " " + Conector + "DATAINCLUSAO = "+"'" +ConnectionInfo.FormataData(DATAINCLUSAO)+"'";
						Conector = " And ";
					}
					if ( DATAALTERACAO !=new DateTime()  )
					{
						Query += " " + Conector + "DATAALTERACAO = "+"'" +ConnectionInfo.FormataData(DATAALTERACAO)+"'";
						Conector = " And ";
					}
					if ( NOME !=String.Empty  )
					{
						Query += " " + Conector + "NOME Like "+"'%" + NOME+"%'";
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
			/// Este metodo realiza o "Select" no objeto ACEPCAO do banco de dados
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
					 Query += " VERBETE,";
					 Query += " DEFINICAO,";
					 Query += " DATAINCLUSAO,";
					 Query += " DATAALTERACAO,";
					 Query += " NOME";
					 Query += " From [ACEPCAO]";
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
					retorno += "VERBETE:		" + this.VERBETE.ToString().Trim();
					retorno += "DEFINICAO:		" + this.DEFINICAO.ToString().Trim();
					retorno += "DATAINCLUSAO:		" + this.DATAINCLUSAO.ToString().Trim();
					retorno += "DATAALTERACAO:		" + this.DATAALTERACAO.ToString().Trim();
					retorno += "NOME:		" + this.NOME.ToString().Trim();

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
