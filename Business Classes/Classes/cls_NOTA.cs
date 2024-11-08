using System;
using System.Data;
using Business_DataBase;
using System.Drawing;
using BusinessClass;

namespace EnciclopediaJuridica.BusinessClass
{

	/// <summary>
	/// Definicao da Classe cls_NOTA
	/// Esta classe representa o objeto NOTA no banco de dados
	/// Todas as operacoes basicas (Inclusao, Alteracao, Exclusao, Consulta) sao feitas por esta classe
	/// Que utilizada internamente pela clase rul_NOTA
	/// 
	/// Nota: Esta classe nao deve ser instanciada dentro do projeto, pois a arquitetura de camadas
	/// Define a classe rul_NOTA para utilizacao na camada de apresentacao do projeto
	/// 
	/// </summary>
	public class cls_NOTA
	{
        #region "Variaveis" 

			private  int _NOTA = -1;
			private  int _VERBETE = -1;
			private  String _DEFINICAO = String.Empty;

        private String _mensagem = "";

        #endregion

        #region "Construtures" 

        public cls_NOTA()
        {
        }

        /// <summary>
        /// Construtor da Classe NOTA com passagem de parametros da Chave Primaria
        /// </summary>
        public cls_NOTA(  int par_NOTA)
        {
            try
            {
					this.NOTA = par_NOTA;
 
            }
            catch (Exception ex)
            {
                this.mensagem = ex.Message;
            }
        }

        #endregion

        #region "Propriedades" 
			public  int NOTA
			{
				get {return _NOTA;}
				set {_NOTA = value;}
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


        public String mensagem
            {
                get {	return _mensagem; }
                set {	_mensagem = value; }
            }
        #endregion

        #region "Metodos Basicos"
 
			/// <summary>
			/// public Boolean Insert()
			/// Este metodo realiza o "insert" no objeto NOTA do banco de dados
			/// </summary>
			public Boolean Insert()
			{
				try
				{
					cls_comando comando = new cls_comando();
					ConnectionInfo conexao = new ConnectionInfo();


					String Query = "";
					Boolean retorno = false;

					Query += " insert into NOTA(";
					Query += " VERBETE,";
					Query += " DEFINICAO";
					Query += " ) values ( ";
					Query += VERBETE+ ",";
					Query += "'" + ConnectionInfo.FormataString(DEFINICAO) + "'";
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
			/// Este metodo realiza o "Update" no objeto NOTA do banco de dados
			/// </summary>
			public Boolean Update()
			{
				try
				{
					cls_comando comando = new cls_comando();
					ConnectionInfo conexao = new ConnectionInfo();
					String Query = "";
					Boolean retorno = false;

					Query += " Update NOTA set ";
					Query += "VERBETE = " + VERBETE+ ",";
					Query += "DEFINICAO = " + "'" + ConnectionInfo.FormataString(DEFINICAO) + "'";
					Query += " Where  NOTA = "  + _NOTA;


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
			/// Este metodo realiza o "Delete" no objeto NOTA do banco de dados
			/// </summary>
			public Boolean Delete()
			{
				try
				{
					cls_comando comando = new cls_comando();
					ConnectionInfo conexao = new ConnectionInfo();
					String Query = "";
					Boolean retorno = false;

					Query += " Delete NOTA ";
					Query += " Where  NOTA = "  + _NOTA;


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
			/// Este metodo realiza o "Delete" no objeto NOTA do banco de dados
			/// </summary>
			public Boolean DeleteMasterDetail()
			{
				try
				{
					cls_comando comando = new cls_comando();
					ConnectionInfo conexao = new ConnectionInfo();
					String Query = "";
					Boolean retorno = false;

					Query += " Delete NOTA ";
					Query += " Where  NOTA = "  + _NOTA;


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
			/// Este metodo realiza o "Select" no objeto NOTA do banco de dados
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
					 Query += " NOTA,";
					 Query += " VERBETE,";
					 Query += " DEFINICAO";
					 Query += " From [NOTA]";
					if ( NOTA !=-1  )
					{
						Query += " " + Conector + "NOTA = " + NOTA;
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
					Query += " Order By";
					Query += " NOTA ";


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
			/// Este metodo realiza o "Select" no objeto NOTA do banco de dados, 
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
					 Query += " NOTA,";
					 Query += " VERBETE,";
					 Query += " DEFINICAO";
					 Query += " From [NOTA]";
					if ( NOTA !=-1  )
					{
						Query += " " + Conector + "NOTA = " + NOTA;
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
					Query += " Order By";
					Query += " NOTA ";


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
			/// Realiza o "Select" no objeto NOTA do banco de dados
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
					 Query += " NOTA,";
					 Query += " VERBETE,";
					 Query += " DEFINICAO";
					 Query += " From [NOTA]";
					if ( NOTA !=-1  )
					{
						Query += " " + Conector + "NOTA = " + NOTA;
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
					Query += " Order By";
					Query += " NOTA ";


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
			/// Realiza o "Select" no objeto NOTA do banco de dados
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
					 Query += " NOTA,";
					 Query += " VERBETE,";
					 Query += " DEFINICAO";
					 Query += " From [NOTA]";
					if ( NOTA !=-1  )
					{
						Query += " " + Conector + "NOTA = " + NOTA;
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
					Query += " Order By";
					Query += " NOTA ";


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
			/// Este metodo realiza o "Select" no objeto NOTA do banco de dados
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
					 Query += " NOTA,";
					 Query += " VERBETE,";
					 Query += " DEFINICAO";
					 Query += " From [NOTA]";
					if ( NOTA !=-1  )
					{
						Query += " " + Conector + "NOTA = " + NOTA;
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
					retorno += "NOTA:		" + this.NOTA.ToString().Trim();
					retorno += "VERBETE:		" + this.VERBETE.ToString().Trim();
					retorno += "DEFINICAO:		" + this.DEFINICAO.ToString().Trim();

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