using System;
using System.Drawing;
using EnciclopediaJuridica.BusinessClass;
using EnciclopediaJuridica.BusinessCollection;


namespace EnciclopediaJuridica.BusinessRule
{
	public class rul_ACEPCAO
	{

		#region "Variaveis" 

			private  int _ACEPCAO = -1;
			private  int _VERBETE = -1;
			private  String _DEFINICAO = String.Empty;
			private  DateTime _DATAINCLUSAO = new DateTime();
			private  DateTime _DATAALTERACAO = new DateTime();
			private  String _NOME = String.Empty;


			private String _mensagem = "";
			private Boolean _NovoRegistro = true;

		#endregion

		#region "Construtures"
 
		public rul_ACEPCAO()
		{
		}
		public rul_ACEPCAO( int par_ACEPCAO)
		{
			try
				{
					this.ACEPCAO = par_ACEPCAO;
 
					this.NovoRegistro = !this.Load();
				}
			catch(Exception ex)
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
				get { return _mensagem; }
				set { _mensagem = value; }
			}
	
			public Boolean NovoRegistro
			{
				get { return _NovoRegistro; }
				set { _NovoRegistro = value;  }
			}

		#endregion

		#region "Metodos Publicos" 

		public Boolean ValidateInsert()
		{
			try
			{
				// Validacao para o insert e o update
				if (! Validate())
					return false;
				
				//
				// TODO: Adicionar regras de validacao aqui
				//
				cls_ACEPCAO ACEPCAO = new cls_ACEPCAO();
				
				ACEPCAO.ACEPCAO = this.ACEPCAO;
				ACEPCAO.VERBETE = this.VERBETE;
				ACEPCAO.DEFINICAO = this.DEFINICAO;
				ACEPCAO.DATAINCLUSAO = this.DATAINCLUSAO;
				ACEPCAO.DATAALTERACAO = this.DATAALTERACAO;
				ACEPCAO.NOME = this.NOME;

				this.mensagem="";

				Boolean retorno = ACEPCAO.Insert();

				this.mensagem = ACEPCAO.mensagem;

				return retorno;
			}
			catch(Exception ex)
			{
			this.mensagem = ex.Message;
			return false;
			}
		}

		public Boolean ValidateUpdate()
		{
			try
			{
				// Validacao para o insert e o update
				if (! Validate())
					return false;
				
				//
				// TODO: Adicionar regras de validacao aqui
				//
				cls_ACEPCAO ACEPCAO = new cls_ACEPCAO();
				
				ACEPCAO.ACEPCAO = this.ACEPCAO;
				ACEPCAO.VERBETE = this.VERBETE;
				ACEPCAO.DEFINICAO = this.DEFINICAO;
				ACEPCAO.DATAINCLUSAO = this.DATAINCLUSAO;
				ACEPCAO.DATAALTERACAO = this.DATAALTERACAO;
				ACEPCAO.NOME = this.NOME;

				this.mensagem= "";
				
				Boolean retorno = ACEPCAO.Update();

				this.mensagem = ACEPCAO.mensagem;

				return retorno;
			}
			catch(Exception ex)
			{
			this.mensagem = ex.Message;
			return false;
			}
		}

		public Boolean Validate()
		{
			try
			{

				if (  this.VERBETE == -1)
				{
					this.mensagem = "O Campo VERBETE tem que ser preenchido com Inteiro";
					return false;
				}
				if (  this.DEFINICAO == String.Empty)
				{
					this.mensagem = "O Campo DEFINICAO tem que ser preenchido com Texto";
					return false;
				}
				if (  this.DATAINCLUSAO == new DateTime())
				{
					this.mensagem = "O Campo DATAINCLUSAO tem que ser preenchido com Data";
					return false;
				}
				if (  this.DATAALTERACAO == new DateTime())
				{
					this.mensagem = "O Campo DATAALTERACAO tem que ser preenchido com Data";
					return false;
				}
				if (  this.NOME == String.Empty)
				{
					this.mensagem = "O Campo NOME tem que ser preenchido com Texto";
					return false;
				}


				return true;
			}
			catch(Exception ex)
			{
			this.mensagem = ex.Message;
			return false;
			}
		}

		public Boolean ValidateDelete()
		{
			try
			{
				
				//
				// TODO: Adicionar regras de validacao aqui
				//
				cls_ACEPCAO ACEPCAO = new cls_ACEPCAO();

				
				ACEPCAO.ACEPCAO = this.ACEPCAO;
				ACEPCAO.VERBETE = this.VERBETE;
				ACEPCAO.DEFINICAO = this.DEFINICAO;
				ACEPCAO.DATAINCLUSAO = this.DATAINCLUSAO;
				ACEPCAO.DATAALTERACAO = this.DATAALTERACAO;
				ACEPCAO.NOME = this.NOME;


				if (VerifyForeignKeys())
					{

						this.mensagem= "";
				
						Boolean retorno = ACEPCAO.Delete();

						this.mensagem = ACEPCAO.mensagem;

						return retorno;
					}	
				else
					{
						return false;
					}

			}
			catch(Exception ex)
			{
			this.mensagem = ex.Message;
			return false;
			}
		}

		public Boolean ValidateDeleteMasterDetail()
		{
			try
			{
				
				//
				// TODO: Adicionar regras de validacao aqui
				//
				cls_ACEPCAO ACEPCAO = new cls_ACEPCAO();
				

				this.mensagem= "";
				
				Boolean retorno = ACEPCAO.DeleteMasterDetail();

				this.mensagem = ACEPCAO.mensagem;

				return retorno;

			}
			catch(Exception ex)
			{
			this.mensagem = ex.Message;
			return false;
			}
		}

		public col_ACEPCAO GetAll()
		{
			try
			{
				cls_ACEPCAO ACEPCAO = new cls_ACEPCAO();
				col_ACEPCAO colecao = new col_ACEPCAO();
				
				ACEPCAO.ACEPCAO = this.ACEPCAO;
				ACEPCAO.VERBETE = this.VERBETE;
				ACEPCAO.DEFINICAO = this.DEFINICAO;
				ACEPCAO.DATAINCLUSAO = this.DATAINCLUSAO;
				ACEPCAO.DATAALTERACAO = this.DATAALTERACAO;
				ACEPCAO.NOME = this.NOME;

				System.Data.DataSet ds = ACEPCAO.GetAll();

                		if (ACEPCAO.mensagem != String.Empty)
		                {
		                    this.mensagem = ACEPCAO.mensagem;
		                    return null;
		                }

				for ( int i =0 ; i <  ds.Tables[0].Rows.Count ; i++)
				{
					rul_ACEPCAO item = new rul_ACEPCAO();
					if( ds.Tables[0].Rows[i].ItemArray[0].ToString() != String.Empty)
						item.ACEPCAO = Convert.ToInt32(ds.Tables[0].Rows[i].ItemArray[0]);

					if( ds.Tables[0].Rows[i].ItemArray[1].ToString() != String.Empty)
						item.VERBETE = Convert.ToInt32(ds.Tables[0].Rows[i].ItemArray[1]);

					if( ds.Tables[0].Rows[i].ItemArray[2].ToString() != String.Empty)
						item.DEFINICAO = Convert.ToString(ds.Tables[0].Rows[i].ItemArray[2]).Trim();

					if( ds.Tables[0].Rows[i].ItemArray[3].ToString() != String.Empty)
						item.DATAINCLUSAO = Convert.ToDateTime(ds.Tables[0].Rows[i].ItemArray[3]);

					if( ds.Tables[0].Rows[i].ItemArray[4].ToString() != String.Empty)
						item.DATAALTERACAO = Convert.ToDateTime(ds.Tables[0].Rows[i].ItemArray[4]);

					if( ds.Tables[0].Rows[i].ItemArray[5].ToString() != String.Empty)
						item.NOME = Convert.ToString(ds.Tables[0].Rows[i].ItemArray[5]).Trim();


					item.NovoRegistro = false;
					colecao.Add(item);
				}
				
				return colecao;
			}
			catch (Exception ex)
			{
				this.mensagem = ex.Message;
				return null;
			}
		}

		public System.Data.DataSet GetAllInDataSet()
		{
			try
			{
				cls_ACEPCAO ACEPCAO = new cls_ACEPCAO();			
				
				ACEPCAO.ACEPCAO = this.ACEPCAO;
				ACEPCAO.VERBETE = this.VERBETE;
				ACEPCAO.DEFINICAO = this.DEFINICAO;
				ACEPCAO.DATAINCLUSAO = this.DATAINCLUSAO;
				ACEPCAO.DATAALTERACAO = this.DATAALTERACAO;
				ACEPCAO.NOME = this.NOME;

				System.Data.DataSet ds = ACEPCAO.GetAll();

				this.mensagem = ACEPCAO.mensagem;

				return ds;
			}
			catch (Exception ex)
			{
				this.mensagem = ex.Message;
				return null;
			}
		}

		public col_ACEPCAO FindAll()
		{

			cls_ACEPCAO ACEPCAO = new cls_ACEPCAO();
			col_ACEPCAO colecao = new col_ACEPCAO();
				
				ACEPCAO.ACEPCAO = this.ACEPCAO;
				ACEPCAO.VERBETE = this.VERBETE;
				ACEPCAO.DEFINICAO = this.DEFINICAO;
				ACEPCAO.DATAINCLUSAO = this.DATAINCLUSAO;
				ACEPCAO.DATAALTERACAO = this.DATAALTERACAO;
				ACEPCAO.NOME = this.NOME;

			System.Data.DataSet ds = ACEPCAO.FindAll();

               		if (ACEPCAO.mensagem != String.Empty)
	                {
	                    this.mensagem = ACEPCAO.mensagem;
	                    return null;
	                }


			for ( int i =0 ; i <  ds.Tables[0].Rows.Count ; i++)
			{
				rul_ACEPCAO item = new rul_ACEPCAO();
					if( ds.Tables[0].Rows[i].ItemArray[0].ToString() != String.Empty)
						item.ACEPCAO = Convert.ToInt32(ds.Tables[0].Rows[i].ItemArray[0]);

					if( ds.Tables[0].Rows[i].ItemArray[1].ToString() != String.Empty)
						item.VERBETE = Convert.ToInt32(ds.Tables[0].Rows[i].ItemArray[1]);

					if( ds.Tables[0].Rows[i].ItemArray[2].ToString() != String.Empty)
						item.DEFINICAO = Convert.ToString(ds.Tables[0].Rows[i].ItemArray[2]).Trim();

					if( ds.Tables[0].Rows[i].ItemArray[3].ToString() != String.Empty)
						item.DATAINCLUSAO = Convert.ToDateTime(ds.Tables[0].Rows[i].ItemArray[3]);

					if( ds.Tables[0].Rows[i].ItemArray[4].ToString() != String.Empty)
						item.DATAALTERACAO = Convert.ToDateTime(ds.Tables[0].Rows[i].ItemArray[4]);

					if( ds.Tables[0].Rows[i].ItemArray[5].ToString() != String.Empty)
						item.NOME = Convert.ToString(ds.Tables[0].Rows[i].ItemArray[5]).Trim();


				item.NovoRegistro = false;
				colecao.Add(item);
			}
			
			return colecao;

		}


		public col_ACEPCAO FindAllGrid()
		{

			cls_ACEPCAO ACEPCAO = new cls_ACEPCAO();
			col_ACEPCAO colecao = new col_ACEPCAO();
				
				ACEPCAO.ACEPCAO = this.ACEPCAO;
				ACEPCAO.VERBETE = this.VERBETE;
				ACEPCAO.DEFINICAO = this.DEFINICAO;
				ACEPCAO.DATAINCLUSAO = this.DATAINCLUSAO;
				ACEPCAO.DATAALTERACAO = this.DATAALTERACAO;
				ACEPCAO.NOME = this.NOME;

			System.Data.DataSet ds = ACEPCAO.FindAllGrid();

               		if (ACEPCAO.mensagem != String.Empty)
	                {
	                    this.mensagem = ACEPCAO.mensagem;
	                    return null;
	                }


			for ( int i =0 ; i <  ds.Tables[0].Rows.Count ; i++)
			{
				rul_ACEPCAO item = new rul_ACEPCAO();
					if( ds.Tables[0].Rows[i].ItemArray[0].ToString() != String.Empty)
						item.ACEPCAO = Convert.ToInt32(ds.Tables[0].Rows[i].ItemArray[0]);

					if( ds.Tables[0].Rows[i].ItemArray[1].ToString() != String.Empty)
						item.VERBETE = Convert.ToInt32(ds.Tables[0].Rows[i].ItemArray[1]);

					if( ds.Tables[0].Rows[i].ItemArray[2].ToString() != String.Empty)
						item.DEFINICAO = Convert.ToString(ds.Tables[0].Rows[i].ItemArray[2]).Trim();

					if( ds.Tables[0].Rows[i].ItemArray[3].ToString() != String.Empty)
						item.DATAINCLUSAO = Convert.ToDateTime(ds.Tables[0].Rows[i].ItemArray[3]);

					if( ds.Tables[0].Rows[i].ItemArray[4].ToString() != String.Empty)
						item.DATAALTERACAO = Convert.ToDateTime(ds.Tables[0].Rows[i].ItemArray[4]);

					if( ds.Tables[0].Rows[i].ItemArray[5].ToString() != String.Empty)
						item.NOME = Convert.ToString(ds.Tables[0].Rows[i].ItemArray[5]).Trim();


				item.NovoRegistro = false;
				colecao.Add(item);
			}
			
			return colecao;

		}

		public System.Data.DataSet FindAllInDataSet()
		{
			try
			{
				cls_ACEPCAO ACEPCAO = new cls_ACEPCAO();			
				
				ACEPCAO.ACEPCAO = this.ACEPCAO;
				ACEPCAO.VERBETE = this.VERBETE;
				ACEPCAO.DEFINICAO = this.DEFINICAO;
				ACEPCAO.DATAINCLUSAO = this.DATAINCLUSAO;
				ACEPCAO.DATAALTERACAO = this.DATAALTERACAO;
				ACEPCAO.NOME = this.NOME;

				System.Data.DataSet ds = ACEPCAO.FindAll();

				this.mensagem = ACEPCAO.mensagem;

				return ds;
			}
			catch (Exception ex)
			{
				this.mensagem = ex.Message;
				return null;
			}
		}

		public System.Data.DataSet GetAllMasterDetail()
		{
			try
			{
				cls_ACEPCAO ACEPCAO = new cls_ACEPCAO();			
				

				System.Data.DataSet ds = ACEPCAO.GetAllMasterDetail();

				this.mensagem = ACEPCAO.mensagem;

				return ds;
			}
			catch (Exception ex)
			{
				this.mensagem = ex.Message;
				return null;
			}
		}

		public Boolean Load()
		{
			try
			{
				cls_ACEPCAO ACEPCAO = new cls_ACEPCAO();


				
				ACEPCAO.ACEPCAO = this.ACEPCAO;


				System.Data.DataSet ds = ACEPCAO.Load();


                		if (ACEPCAO.mensagem != String.Empty)
		                {
		                    this.mensagem = ACEPCAO.mensagem;
		                    return false;
		                }


				if( ds.Tables[0].Rows.Count ==1)
				{
										if( ds.Tables[0].Rows[0].ItemArray[0].ToString() != String.Empty)
						this.ACEPCAO = Convert.ToInt32(ds.Tables[0].Rows[0].ItemArray[0]);

					if( ds.Tables[0].Rows[0].ItemArray[1].ToString() != String.Empty)
						this.VERBETE = Convert.ToInt32(ds.Tables[0].Rows[0].ItemArray[1]);

					if( ds.Tables[0].Rows[0].ItemArray[2].ToString() != String.Empty)
						this.DEFINICAO = Convert.ToString(ds.Tables[0].Rows[0].ItemArray[2]);

					if( ds.Tables[0].Rows[0].ItemArray[3].ToString() != String.Empty)
						this.DATAINCLUSAO = Convert.ToDateTime(ds.Tables[0].Rows[0].ItemArray[3]);

					if( ds.Tables[0].Rows[0].ItemArray[4].ToString() != String.Empty)
						this.DATAALTERACAO = Convert.ToDateTime(ds.Tables[0].Rows[0].ItemArray[4]);

					if( ds.Tables[0].Rows[0].ItemArray[5].ToString() != String.Empty)
						this.NOME = Convert.ToString(ds.Tables[0].Rows[0].ItemArray[5]);


					this.NovoRegistro = false;
					return true;
				}
				else
				{
					this.mensagem = "Load retornou mais de uma linha";
					this.NovoRegistro = true;
					return false;
				}

			}
			catch (Exception ex)
			{
				this.mensagem = ex.Message;
				return false;
			}
		}

		#endregion

		#region "Metodos Privados"

		private Boolean VerifyForeignKeys()
		{
			try
			{
				
				Boolean retorno = true;

				

				return retorno;

			}
			catch(Exception ex)
			{
			this.mensagem = ex.Message;
			return false;
			}
		}

		#endregion
	}
}