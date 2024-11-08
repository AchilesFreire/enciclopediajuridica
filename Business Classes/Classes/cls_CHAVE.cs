using System;
using System.Data;
using Business_DataBase;
using System.Drawing;
using BusinessClass;

namespace EnciclopediaJuridica.BusinessClass
{

	/// <summary>
	/// Definicao da Classe cls_CHAVE
	/// Esta classe representa o objeto CHAVE no banco de dados
	/// Todas as operacoes basicas (Inclusao, Alteracao, Exclusao, Consulta) sao feitas por esta classe
	/// Que utilizada internamente pela clase rul_CHAVE
	/// 
	/// Nota: Esta classe nao deve ser instanciada dentro do projeto, pois a arquitetura de camadas
	/// Define a classe rul_CHAVE para utilizacao na camada de apresentacao do projeto
	/// 
	/// </summary>
	public class cls_CHAVE
	{
        #region "Variaveis" 

			private  int _CHAVE = -1;
			private  String _NOME = String.Empty;

        private String _mensagem = "";

        #endregion

        #region "Construtures" 

        public cls_CHAVE()
        {
        }

        /// <summary>
        /// Construtor da Classe CHAVE com passagem de parametros da Chave Primaria
        /// </summary>
        public cls_CHAVE(  int par_CHAVE)
        {
            try
            {
					this.CHAVE = par_CHAVE;
 
            }
            catch (Exception ex)
            {
                this.mensagem = ex.Message;
            }
        }

        #endregion

        #region "Propriedades" 
			public  int CHAVE
			{
				get {return _CHAVE;}
				set {_CHAVE = value;}
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
			/// Este metodo realiza o "insert" no objeto CHAVE do banco de dados
			/// </summary>
			public Boolean Insert()
			{
				try
				{
					cls_comando comando = new cls_comando();
					ConnectionInfo conexao = new ConnectionInfo();


					String Query = "";
					Boolean retorno = false;

					Query += " insert into CHAVE(";
					Query += " NOME";
					Query += " ) values ( ";
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
			/// Este metodo realiza o "Update" no objeto CHAVE do banco de dados
			/// </summary>
			public Boolean Update()
			{
				try
				{
					cls_comando comando = new cls_comando();
					ConnectionInfo conexao = new ConnectionInfo();
					String Query = "";
					Boolean retorno = false;

					Query += " Update CHAVE set ";
					Query += "NOME = " + "'" + ConnectionInfo.FormataString(NOME) + "'";
					Query += " Where  CHAVE = "  + _CHAVE;


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
			/// Este metodo realiza o "Delete" no objeto CHAVE do banco de dados
			/// </summary>
			public Boolean Delete()
			{
				try
				{
					cls_comando comando = new cls_comando();
					ConnectionInfo conexao = new ConnectionInfo();
					String Query = "";
					Boolean retorno = false;

					Query += " Delete CHAVE ";
					Query += " Where  CHAVE = "  + _CHAVE;


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
			/// Este metodo realiza o "Delete" no objeto CHAVE do banco de dados
			/// </summary>
			public Boolean DeleteMasterDetail()
			{
				try
				{
					cls_comando comando = new cls_comando();
					ConnectionInfo conexao = new ConnectionInfo();
					String Query = "";
					Boolean retorno = false;

					Query += " Delete CHAVE ";
					Query += " Where  CHAVE = "  + _CHAVE;


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
			/// Este metodo realiza o "Select" no objeto CHAVE do banco de dados
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
					 Query += " CHAVE,";
					 Query += " NOME";
					 Query += " From [CHAVE]";
					if ( CHAVE !=-1  )
					{
						Query += " " + Conector + "CHAVE = " + CHAVE;
						Conector = " And ";
					}
					if ( NOME !=String.Empty  )
					{
						Query += " " + Conector + "NOME = "+"'" + ConnectionInfo.FormataString(NOME)+"'";
						Conector = " And ";
					}
					Query += " Order By";
					Query += " CHAVE ";


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
			/// Este metodo realiza o "Select" no objeto CHAVE do banco de dados, 
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
					 Query += " CHAVE,";
					 Query += " NOME";
					 Query += " From [CHAVE]";
					if ( CHAVE !=-1  )
					{
						Query += " " + Conector + "CHAVE = " + CHAVE;
						Conector = " And ";
					}
					if ( NOME !=String.Empty  )
					{
						Query += " " + Conector + "NOME = "+"'" + ConnectionInfo.FormataString(NOME)+"'";
						Conector = " And ";
					}
					Query += " Order By";
					Query += " CHAVE ";


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
			/// Realiza o "Select" no objeto CHAVE do banco de dados
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
					 Query += " CHAVE,";
					 Query += " NOME";
					 Query += " From [CHAVE]";
					if ( CHAVE !=-1  )
					{
						Query += " " + Conector + "CHAVE = " + CHAVE;
						Conector = " And ";
					}
					if ( NOME !=String.Empty  )
					{
						Query += " " + Conector + "NOME Like "+"'%" + NOME+"%'";
						Conector = " And ";
					}
					Query += " Order By";
					Query += " CHAVE ";


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
			/// Realiza o "Select" no objeto CHAVE do banco de dados
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
					 Query += " CHAVE,";
					 Query += " NOME";
					 Query += " From [CHAVE]";
					if ( CHAVE !=-1  )
					{
						Query += " " + Conector + "CHAVE = " + CHAVE;
						Conector = " And ";
					}
					if ( NOME !=String.Empty  )
					{
						Query += " " + Conector + "NOME Like "+"'%" + NOME+"%'";
						Conector = " And ";
					}
					Query += " Order By";
					Query += " CHAVE ";


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
			/// Este metodo realiza o "Select" no objeto CHAVE do banco de dados
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
					 Query += " CHAVE,";
					 Query += " NOME";
					 Query += " From [CHAVE]";
					if ( CHAVE !=-1  )
					{
						Query += " " + Conector + "CHAVE = " + CHAVE;
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
					retorno += "CHAVE:		" + this.CHAVE.ToString().Trim();
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
