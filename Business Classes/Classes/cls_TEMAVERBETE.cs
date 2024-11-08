using System;
using System.Data;
using Business_DataBase;
using System.Drawing;
using BusinessClass;

namespace EnciclopediaJuridica.BusinessClass
{

	/// <summary>
	/// Definicao da Classe cls_TEMAVERBETE
	/// Esta classe representa o objeto TEMAVERBETE no banco de dados
	/// Todas as operacoes basicas (Inclusao, Alteracao, Exclusao, Consulta) sao feitas por esta classe
	/// Que utilizada internamente pela clase rul_TEMAVERBETE
	/// 
	/// Nota: Esta classe nao deve ser instanciada dentro do projeto, pois a arquitetura de camadas
	/// Define a classe rul_TEMAVERBETE para utilizacao na camada de apresentacao do projeto
	/// 
	/// </summary>
	public class cls_TEMAVERBETE
	{
        #region "Variaveis" 

			private  int _TEMAVERBETE = -1;
			private  int _TEMA = -1;
			private  int _VERBETE = -1;

        private String _mensagem = "";

        #endregion

        #region "Construtures" 

        public cls_TEMAVERBETE()
        {
        }

        /// <summary>
        /// Construtor da Classe TEMAVERBETE com passagem de parametros da Chave Primaria
        /// </summary>
        public cls_TEMAVERBETE(  int par_TEMAVERBETE)
        {
            try
            {
					this.TEMAVERBETE = par_TEMAVERBETE;
 
            }
            catch (Exception ex)
            {
                this.mensagem = ex.Message;
            }
        }

        #endregion

        #region "Propriedades" 
			public  int TEMAVERBETE
			{
				get {return _TEMAVERBETE;}
				set {_TEMAVERBETE = value;}
			}

			public  int TEMA
			{
				get {return _TEMA;}
				set {_TEMA = value;}
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
			/// Este metodo realiza o "insert" no objeto TEMAVERBETE do banco de dados
			/// </summary>
			public Boolean Insert()
			{
				try
				{
					cls_comando comando = new cls_comando();
					ConnectionInfo conexao = new ConnectionInfo();


					String Query = "";
					Boolean retorno = false;

					Query += " insert into TEMAVERBETE(";
					Query += " TEMA,";
					Query += " VERBETE";
					Query += " ) values ( ";
					Query += TEMA+ ",";
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
			/// Este metodo realiza o "Update" no objeto TEMAVERBETE do banco de dados
			/// </summary>
			public Boolean Update()
			{
				try
				{
					cls_comando comando = new cls_comando();
					ConnectionInfo conexao = new ConnectionInfo();
					String Query = "";
					Boolean retorno = false;

					Query += " Update TEMAVERBETE set ";
					Query += "TEMA = " + TEMA+ ",";
					Query += "VERBETE = " + VERBETE;
					Query += " Where  TEMAVERBETE = "  + _TEMAVERBETE;


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
			/// Este metodo realiza o "Delete" no objeto TEMAVERBETE do banco de dados
			/// </summary>
			public Boolean Delete()
			{
				try
				{
					cls_comando comando = new cls_comando();
					ConnectionInfo conexao = new ConnectionInfo();
					String Query = "";
					Boolean retorno = false;

					Query += " Delete TEMAVERBETE ";
					Query += " Where  TEMAVERBETE = "  + _TEMAVERBETE;


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
			/// Este metodo realiza o "Delete" no objeto TEMAVERBETE do banco de dados
			/// </summary>
			public Boolean DeleteMasterDetail()
			{
				try
				{
					cls_comando comando = new cls_comando();
					ConnectionInfo conexao = new ConnectionInfo();
					String Query = "";
					Boolean retorno = false;

					Query += " Delete TEMAVERBETE ";
					Query += " Where  TEMAVERBETE = "  + _TEMAVERBETE;


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
			/// Este metodo realiza o "Select" no objeto TEMAVERBETE do banco de dados
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
					 Query += " TEMAVERBETE,";
					 Query += " TEMA,";
					 Query += " VERBETE";
					 Query += " From [TEMAVERBETE]";
					if ( TEMAVERBETE !=-1  )
					{
						Query += " " + Conector + "TEMAVERBETE = " + TEMAVERBETE;
						Conector = " And ";
					}
					if ( TEMA !=-1  )
					{
						Query += " " + Conector + "TEMA = " + TEMA;
						Conector = " And ";
					}
					if ( VERBETE !=-1  )
					{
						Query += " " + Conector + "VERBETE = " + VERBETE;
						Conector = " And ";
					}
					Query += " Order By";
					Query += " TEMAVERBETE ";


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
			/// Este metodo realiza o "Select" no objeto TEMAVERBETE do banco de dados, 
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
					 Query += " TEMAVERBETE,";
					 Query += " TEMA,";
					 Query += " VERBETE";
					 Query += " From [TEMAVERBETE]";
					if ( TEMAVERBETE !=-1  )
					{
						Query += " " + Conector + "TEMAVERBETE = " + TEMAVERBETE;
						Conector = " And ";
					}
					if ( TEMA !=-1  )
					{
						Query += " " + Conector + "TEMA = " + TEMA;
						Conector = " And ";
					}
					if ( VERBETE !=-1  )
					{
						Query += " " + Conector + "VERBETE = " + VERBETE;
						Conector = " And ";
					}
					Query += " Order By";
					Query += " TEMAVERBETE ";


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
			/// Realiza o "Select" no objeto TEMAVERBETE do banco de dados
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
					 Query += " TEMAVERBETE,";
					 Query += " TEMA,";
					 Query += " VERBETE";
					 Query += " From [TEMAVERBETE]";
					if ( TEMAVERBETE !=-1  )
					{
						Query += " " + Conector + "TEMAVERBETE = " + TEMAVERBETE;
						Conector = " And ";
					}
					if ( TEMA !=-1  )
					{
						Query += " " + Conector + "TEMA = " + TEMA;
						Conector = " And ";
					}
					if ( VERBETE !=-1  )
					{
						Query += " " + Conector + "VERBETE = " + VERBETE;
						Conector = " And ";
					}
					Query += " Order By";
					Query += " TEMAVERBETE ";


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
			/// Realiza o "Select" no objeto TEMAVERBETE do banco de dados
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
					 Query += " TEMAVERBETE,";
					 Query += " TEMA,";
					 Query += " VERBETE";
					 Query += " From [TEMAVERBETE]";
					if ( TEMAVERBETE !=-1  )
					{
						Query += " " + Conector + "TEMAVERBETE = " + TEMAVERBETE;
						Conector = " And ";
					}
					if ( TEMA !=-1  )
					{
						Query += " " + Conector + "TEMA = " + TEMA;
						Conector = " And ";
					}
					if ( VERBETE !=-1  )
					{
						Query += " " + Conector + "VERBETE = " + VERBETE;
						Conector = " And ";
					}
					Query += " Order By";
					Query += " TEMAVERBETE ";


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
			/// Este metodo realiza o "Select" no objeto TEMAVERBETE do banco de dados
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
					 Query += " TEMAVERBETE,";
					 Query += " TEMA,";
					 Query += " VERBETE";
					 Query += " From [TEMAVERBETE]";
					if ( TEMAVERBETE !=-1  )
					{
						Query += " " + Conector + "TEMAVERBETE = " + TEMAVERBETE;
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
					retorno += "TEMAVERBETE:		" + this.TEMAVERBETE.ToString().Trim();
					retorno += "TEMA:		" + this.TEMA.ToString().Trim();
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
