using System;
using System.Data;
using Business_DataBase;
using System.Drawing;
using BusinessClass;

namespace EnciclopediaJuridica.BusinessClass
{

	/// <summary>
	/// Definicao da Classe cls_VERBETEUSUARIO
	/// Esta classe representa o objeto VERBETEUSUARIO no banco de dados
	/// Todas as operacoes basicas (Inclusao, Alteracao, Exclusao, Consulta) sao feitas por esta classe
	/// Que utilizada internamente pela clase rul_VERBETEUSUARIO
	/// 
	/// Nota: Esta classe nao deve ser instanciada dentro do projeto, pois a arquitetura de camadas
	/// Define a classe rul_VERBETEUSUARIO para utilizacao na camada de apresentacao do projeto
	/// 
	/// </summary>
	public class cls_VERBETEUSUARIO
	{
        #region "Variaveis" 

			private  int _VERBETEUSUARIO = -1;
			private  String _NOME = String.Empty;
			private  String _DEFINICAO = String.Empty;
			private  String _BIBLIOGRAFIA = String.Empty;

        private String _mensagem = "";

        #endregion

        #region "Construtures" 

        public cls_VERBETEUSUARIO()
        {
        }

        /// <summary>
        /// Construtor da Classe VERBETEUSUARIO com passagem de parametros da Chave Primaria
        /// </summary>
        public cls_VERBETEUSUARIO(  int par_VERBETEUSUARIO)
        {
            try
            {
					this.VERBETEUSUARIO = par_VERBETEUSUARIO;
 
            }
            catch (Exception ex)
            {
                this.mensagem = ex.Message;
            }
        }

        #endregion

        #region "Propriedades" 
			public  int VERBETEUSUARIO
			{
				get {return _VERBETEUSUARIO;}
				set {_VERBETEUSUARIO = value;}
			}

			public  String NOME
			{
				get {return _NOME;}
				set {_NOME = value;}
			}

			public  String DEFINICAO
			{
				get {return _DEFINICAO;}
				set {_DEFINICAO = value;}
			}

			public  String BIBLIOGRAFIA
			{
				get {return _BIBLIOGRAFIA;}
				set {_BIBLIOGRAFIA = value;}
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
			/// Este metodo realiza o "insert" no objeto VERBETEUSUARIO do banco de dados
			/// </summary>
			public Boolean Insert()
			{
				try
				{
					cls_comando comando = new cls_comando();
					ConnectionInfo conexao = new ConnectionInfo();


					String Query = "";
					Boolean retorno = false;

					Query += " insert into VERBETEUSUARIO(";
					Query += " NOME,";
					Query += " DEFINICAO,";
					Query += " BIBLIOGRAFIA";
					Query += " ) values ( ";
					Query += "'" + ConnectionInfo.FormataString(NOME) + "'"+ ",";
					Query += "'" + ConnectionInfo.FormataString(DEFINICAO) + "'"+ ",";
					Query += "'" + ConnectionInfo.FormataString(BIBLIOGRAFIA) + "'";
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
			/// Este metodo realiza o "Update" no objeto VERBETEUSUARIO do banco de dados
			/// </summary>
			public Boolean Update()
			{
				try
				{
					cls_comando comando = new cls_comando();
					ConnectionInfo conexao = new ConnectionInfo();
					String Query = "";
					Boolean retorno = false;

					Query += " Update VERBETEUSUARIO set ";
					Query += "NOME = " + "'" + ConnectionInfo.FormataString(NOME) + "'"+ ",";
					Query += "DEFINICAO = " + "'" + ConnectionInfo.FormataString(DEFINICAO) + "'"+ ",";
					Query += "BIBLIOGRAFIA = " + "'" + ConnectionInfo.FormataString(BIBLIOGRAFIA) + "'";
					Query += " Where  VERBETEUSUARIO = "  + _VERBETEUSUARIO;


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
			/// Este metodo realiza o "Delete" no objeto VERBETEUSUARIO do banco de dados
			/// </summary>
			public Boolean Delete()
			{
				try
				{
					cls_comando comando = new cls_comando();
					ConnectionInfo conexao = new ConnectionInfo();
					String Query = "";
					Boolean retorno = false;

					Query += " Delete VERBETEUSUARIO ";
					Query += " Where  VERBETEUSUARIO = "  + _VERBETEUSUARIO;


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
			/// Este metodo realiza o "Delete" no objeto VERBETEUSUARIO do banco de dados
			/// </summary>
			public Boolean DeleteMasterDetail()
			{
				try
				{
					cls_comando comando = new cls_comando();
					ConnectionInfo conexao = new ConnectionInfo();
					String Query = "";
					Boolean retorno = false;

					Query += " Delete VERBETEUSUARIO ";
					Query += " Where  VERBETEUSUARIO = "  + _VERBETEUSUARIO;


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
			/// Este metodo realiza o "Select" no objeto VERBETEUSUARIO do banco de dados
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
					 Query += " VERBETEUSUARIO,";
					 Query += " NOME,";
					 Query += " DEFINICAO,";
					 Query += " BIBLIOGRAFIA";
					 Query += " From [VERBETEUSUARIO]";
					if ( VERBETEUSUARIO !=-1  )
					{
						Query += " " + Conector + "VERBETEUSUARIO = " + VERBETEUSUARIO;
						Conector = " And ";
					}
					if ( NOME !=String.Empty  )
					{
						Query += " " + Conector + "NOME = "+"'" + ConnectionInfo.FormataString(NOME)+"'";
						Conector = " And ";
					}
					if ( DEFINICAO !=String.Empty  )
					{
						Query += " " + Conector + "DEFINICAO = "+"'" + ConnectionInfo.FormataString(DEFINICAO)+"'";
						Conector = " And ";
					}
					if ( BIBLIOGRAFIA !=String.Empty  )
					{
						Query += " " + Conector + "BIBLIOGRAFIA = "+"'" + ConnectionInfo.FormataString(BIBLIOGRAFIA)+"'";
						Conector = " And ";
					}
					Query += " Order By";
					Query += " VERBETEUSUARIO ";


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
			/// Este metodo realiza o "Select" no objeto VERBETEUSUARIO do banco de dados, 
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
					 Query += " VERBETEUSUARIO,";
					 Query += " NOME,";
					 Query += " DEFINICAO,";
					 Query += " BIBLIOGRAFIA";
					 Query += " From [VERBETEUSUARIO]";
					if ( VERBETEUSUARIO !=-1  )
					{
						Query += " " + Conector + "VERBETEUSUARIO = " + VERBETEUSUARIO;
						Conector = " And ";
					}
					if ( NOME !=String.Empty  )
					{
						Query += " " + Conector + "NOME = "+"'" + ConnectionInfo.FormataString(NOME)+"'";
						Conector = " And ";
					}
					if ( DEFINICAO !=String.Empty  )
					{
						Query += " " + Conector + "DEFINICAO = "+"'" + ConnectionInfo.FormataString(DEFINICAO)+"'";
						Conector = " And ";
					}
					if ( BIBLIOGRAFIA !=String.Empty  )
					{
						Query += " " + Conector + "BIBLIOGRAFIA = "+"'" + ConnectionInfo.FormataString(BIBLIOGRAFIA)+"'";
						Conector = " And ";
					}
					Query += " Order By";
					Query += " VERBETEUSUARIO ";


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
			/// Realiza o "Select" no objeto VERBETEUSUARIO do banco de dados
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
					 Query += " VERBETEUSUARIO,";
					 Query += " NOME,";
					 Query += " DEFINICAO,";
					 Query += " BIBLIOGRAFIA";
					 Query += " From [VERBETEUSUARIO]";
					if ( VERBETEUSUARIO !=-1  )
					{
						Query += " " + Conector + "VERBETEUSUARIO = " + VERBETEUSUARIO;
						Conector = " And ";
					}
					if ( NOME !=String.Empty  )
					{
						Query += " " + Conector + "NOME Like "+"'%" + NOME+"%'";
						Conector = " And ";
					}
					if ( DEFINICAO !=String.Empty  )
					{
						Query += " " + Conector + "DEFINICAO Like "+"'%" + DEFINICAO+"%'";
						Conector = " And ";
					}
					if ( BIBLIOGRAFIA !=String.Empty  )
					{
						Query += " " + Conector + "BIBLIOGRAFIA Like "+"'%" + BIBLIOGRAFIA+"%'";
						Conector = " And ";
					}
					Query += " Order By";
					Query += " VERBETEUSUARIO ";


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
			/// Realiza o "Select" no objeto VERBETEUSUARIO do banco de dados
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
					 Query += " VERBETEUSUARIO,";
					 Query += " NOME,";
					 Query += " DEFINICAO,";
					 Query += " BIBLIOGRAFIA";
					 Query += " From [VERBETEUSUARIO]";
					if ( VERBETEUSUARIO !=-1  )
					{
						Query += " " + Conector + "VERBETEUSUARIO = " + VERBETEUSUARIO;
						Conector = " And ";
					}
					if ( NOME !=String.Empty  )
					{
						Query += " " + Conector + "NOME Like "+"'%" + NOME+"%'";
						Conector = " And ";
					}
					if ( DEFINICAO !=String.Empty  )
					{
						Query += " " + Conector + "DEFINICAO Like "+"'%" + DEFINICAO+"%'";
						Conector = " And ";
					}
					if ( BIBLIOGRAFIA !=String.Empty  )
					{
						Query += " " + Conector + "BIBLIOGRAFIA Like "+"'%" + BIBLIOGRAFIA+"%'";
						Conector = " And ";
					}
					Query += " Order By";
					Query += " VERBETEUSUARIO ";


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
			/// Este metodo realiza o "Select" no objeto VERBETEUSUARIO do banco de dados
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
					 Query += " VERBETEUSUARIO,";
					 Query += " NOME,";
					 Query += " DEFINICAO,";
					 Query += " BIBLIOGRAFIA";
					 Query += " From [VERBETEUSUARIO]";
					if ( VERBETEUSUARIO !=-1  )
					{
						Query += " " + Conector + "VERBETEUSUARIO = " + VERBETEUSUARIO;
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
					retorno += "VERBETEUSUARIO:		" + this.VERBETEUSUARIO.ToString().Trim();
					retorno += "NOME:		" + this.NOME.ToString().Trim();
					retorno += "DEFINICAO:		" + this.DEFINICAO.ToString().Trim();
					retorno += "BIBLIOGRAFIA:		" + this.BIBLIOGRAFIA.ToString().Trim();

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
