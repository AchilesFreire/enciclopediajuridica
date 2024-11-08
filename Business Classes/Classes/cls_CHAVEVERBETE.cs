using System;
using System.Data;
using Business_DataBase;
using System.Drawing;
using BusinessClass;

namespace EnciclopediaJuridica.BusinessClass
{

	/// <summary>
	/// Definicao da Classe cls_CHAVEVERBETE
	/// Esta classe representa o objeto CHAVEVERBETE no banco de dados
	/// Todas as operacoes basicas (Inclusao, Alteracao, Exclusao, Consulta) sao feitas por esta classe
	/// Que utilizada internamente pela clase rul_CHAVEVERBETE
	/// 
	/// Nota: Esta classe nao deve ser instanciada dentro do projeto, pois a arquitetura de camadas
	/// Define a classe rul_CHAVEVERBETE para utilizacao na camada de apresentacao do projeto
	/// 
	/// </summary>
	public class cls_CHAVEVERBETE
	{
        #region "Variaveis" 

			private  int _CHAVE = -1;
			private  int _VERBETE = -1;

        private String _mensagem = "";

        #endregion

        #region "Construtures" 

        public cls_CHAVEVERBETE()
        {
        }

        /// <summary>
        /// Construtor da Classe CHAVEVERBETE com passagem de parametros da Chave Primaria
        /// </summary>
        public cls_CHAVEVERBETE(  int par_CHAVE,  int par_VERBETE)
        {
            try
            {
					this.CHAVE = par_CHAVE;
 					this.VERBETE = par_VERBETE;
 
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

			public  int VERBETE
			{
				get {return _VERBETE;}
				set {_VERBETE = value;}
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
			/// Este metodo realiza o "insert" no objeto CHAVEVERBETE do banco de dados
			/// </summary>
			public Boolean Insert()
			{
				try
				{
					cls_comando comando = new cls_comando();
					ConnectionInfo conexao = new ConnectionInfo();


					String Query = "";
					Boolean retorno = false;

					Query += " insert into CHAVEVERBETE(";
					Query += " CHAVE,";
					Query += " VERBETE";
					Query += " ) values ( ";
					Query += CHAVE+ ",";
					Query += VERBETE;
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
			/// Este metodo realiza o "Update" no objeto CHAVEVERBETE do banco de dados
			/// </summary>
			public Boolean Update()
			{
				try
				{
					cls_comando comando = new cls_comando();
					ConnectionInfo conexao = new ConnectionInfo();
					String Query = "";
					Boolean retorno = false;

					Query += " Update CHAVEVERBETE set ";
					Query += " Where  CHAVE = "  + _CHAVE;
					Query += " And  VERBETE = "  + _VERBETE;


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
			/// Este metodo realiza o "Delete" no objeto CHAVEVERBETE do banco de dados
			/// </summary>
			public Boolean Delete()
			{
				try
				{
					cls_comando comando = new cls_comando();
					ConnectionInfo conexao = new ConnectionInfo();
					String Query = "";
					Boolean retorno = false;

					Query += " Delete CHAVEVERBETE ";
					Query += " Where  CHAVE = "  + _CHAVE;
					Query += " And  VERBETE = "  + _VERBETE;


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
			/// Este metodo realiza o "Delete" no objeto CHAVEVERBETE do banco de dados
			/// </summary>
			public Boolean DeleteMasterDetail()
			{
				try
				{
					cls_comando comando = new cls_comando();
					ConnectionInfo conexao = new ConnectionInfo();
					String Query = "";
					Boolean retorno = false;

					Query += " Delete CHAVEVERBETE ";
					Query += " Where  CHAVE = "  + _CHAVE;
					Query += " And  VERBETE = "  + _VERBETE;


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
			/// Este metodo realiza o "Select" no objeto CHAVEVERBETE do banco de dados
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
					 Query += " VERBETE";
					 Query += " From [CHAVEVERBETE]";
					if ( CHAVE !=-1  )
					{
						Query += " " + Conector + "CHAVE = " + CHAVE;
						Conector = " And ";
					}
					if ( VERBETE !=-1  )
					{
						Query += " " + Conector + "VERBETE = " + VERBETE;
						Conector = " And ";
					}
					Query += " Order By";
					Query += " CHAVE ,";
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
			/// Este metodo realiza o "Select" no objeto CHAVEVERBETE do banco de dados, 
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
					 Query += " VERBETE";
					 Query += " From [CHAVEVERBETE]";
					if ( CHAVE !=-1  )
					{
						Query += " " + Conector + "CHAVE = " + CHAVE;
						Conector = " And ";
					}
					if ( VERBETE !=-1  )
					{
						Query += " " + Conector + "VERBETE = " + VERBETE;
						Conector = " And ";
					}
					Query += " Order By";
					Query += " CHAVE ,";
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
			/// Realiza o "Select" no objeto CHAVEVERBETE do banco de dados
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
					 Query += " VERBETE";
					 Query += " From [CHAVEVERBETE]";
					if ( CHAVE !=-1  )
					{
						Query += " " + Conector + "CHAVE = " + CHAVE;
						Conector = " And ";
					}
					if ( VERBETE !=-1  )
					{
						Query += " " + Conector + "VERBETE = " + VERBETE;
						Conector = " And ";
					}
					Query += " Order By";
					Query += " CHAVE ,";
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
			/// Realiza o "Select" no objeto CHAVEVERBETE do banco de dados
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
					 Query += " VERBETE";
					 Query += " From [CHAVEVERBETE]";
					if ( CHAVE !=-1  )
					{
						Query += " " + Conector + "CHAVE = " + CHAVE;
						Conector = " And ";
					}
					if ( VERBETE !=-1  )
					{
						Query += " " + Conector + "VERBETE = " + VERBETE;
						Conector = " And ";
					}
					Query += " Order By";
					Query += " CHAVE ,";
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
			/// Este metodo realiza o "Select" no objeto CHAVEVERBETE do banco de dados
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
					 Query += " VERBETE";
					 Query += " From [CHAVEVERBETE]";
					if ( CHAVE !=-1  )
					{
						Query += " " + Conector + "CHAVE = " + CHAVE;
						Conector = " And ";
					}
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
					retorno += "CHAVE:		" + this.CHAVE.ToString().Trim();
					retorno += "VERBETE:		" + this.VERBETE.ToString().Trim();

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
