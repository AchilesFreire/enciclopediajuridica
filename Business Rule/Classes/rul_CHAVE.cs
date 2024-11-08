using System;
using System.Drawing;
using EnciclopediaJuridica.BusinessClass;
using EnciclopediaJuridica.BusinessCollection;


namespace EnciclopediaJuridica.BusinessRule
{
	public class rul_CHAVE
	{

		#region "Variaveis" 

			private  int _CHAVE = -1;
			private  String _NOME = String.Empty;


			private String _mensagem = "";
			private Boolean _NovoRegistro = true;

		#endregion

		#region "Construtures"
 
		public rul_CHAVE()
		{
		}
		public rul_CHAVE( int par_CHAVE)
		{
			try
				{
					this.CHAVE = par_CHAVE;
 
					this.NovoRegistro = !this.Load();
				}
			catch(Exception ex)
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
				cls_CHAVE CHAVE = new cls_CHAVE();
				
				CHAVE.CHAVE = this.CHAVE;
				CHAVE.NOME = this.NOME;

				this.mensagem="";

				Boolean retorno = CHAVE.Insert();

				this.mensagem = CHAVE.mensagem;

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
				cls_CHAVE CHAVE = new cls_CHAVE();
				
				CHAVE.CHAVE = this.CHAVE;
				CHAVE.NOME = this.NOME;

				this.mensagem= "";
				
				Boolean retorno = CHAVE.Update();

				this.mensagem = CHAVE.mensagem;

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
				cls_CHAVE CHAVE = new cls_CHAVE();

				
				CHAVE.CHAVE = this.CHAVE;
				CHAVE.NOME = this.NOME;


				if (VerifyForeignKeys())
					{

						this.mensagem= "";
				
						Boolean retorno = CHAVE.Delete();

						this.mensagem = CHAVE.mensagem;

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
				cls_CHAVE CHAVE = new cls_CHAVE();
				

				this.mensagem= "";
				
				Boolean retorno = CHAVE.DeleteMasterDetail();

				this.mensagem = CHAVE.mensagem;

				return retorno;

			}
			catch(Exception ex)
			{
			this.mensagem = ex.Message;
			return false;
			}
		}

		public col_CHAVE GetAll()
		{
			try
			{
				cls_CHAVE CHAVE = new cls_CHAVE();
				col_CHAVE colecao = new col_CHAVE();
				
				CHAVE.CHAVE = this.CHAVE;
				CHAVE.NOME = this.NOME;

				System.Data.DataSet ds = CHAVE.GetAll();

                		if (CHAVE.mensagem != String.Empty)
		                {
		                    this.mensagem = CHAVE.mensagem;
		                    return null;
		                }

				for ( int i =0 ; i <  ds.Tables[0].Rows.Count ; i++)
				{
					rul_CHAVE item = new rul_CHAVE();
					if( ds.Tables[0].Rows[i].ItemArray[0].ToString() != String.Empty)
						item.CHAVE = Convert.ToInt32(ds.Tables[0].Rows[i].ItemArray[0]);

					if( ds.Tables[0].Rows[i].ItemArray[1].ToString() != String.Empty)
						item.NOME = Convert.ToString(ds.Tables[0].Rows[i].ItemArray[1]).Trim();


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
				cls_CHAVE CHAVE = new cls_CHAVE();			
				
				CHAVE.CHAVE = this.CHAVE;
				CHAVE.NOME = this.NOME;

				System.Data.DataSet ds = CHAVE.GetAll();

				this.mensagem = CHAVE.mensagem;

				return ds;
			}
			catch (Exception ex)
			{
				this.mensagem = ex.Message;
				return null;
			}
		}

		public col_CHAVE FindAll()
		{

			cls_CHAVE CHAVE = new cls_CHAVE();
			col_CHAVE colecao = new col_CHAVE();
				
				CHAVE.CHAVE = this.CHAVE;
				CHAVE.NOME = this.NOME;

			System.Data.DataSet ds = CHAVE.FindAll();

               		if (CHAVE.mensagem != String.Empty)
	                {
	                    this.mensagem = CHAVE.mensagem;
	                    return null;
	                }


			for ( int i =0 ; i <  ds.Tables[0].Rows.Count ; i++)
			{
				rul_CHAVE item = new rul_CHAVE();
					if( ds.Tables[0].Rows[i].ItemArray[0].ToString() != String.Empty)
						item.CHAVE = Convert.ToInt32(ds.Tables[0].Rows[i].ItemArray[0]);

					if( ds.Tables[0].Rows[i].ItemArray[1].ToString() != String.Empty)
						item.NOME = Convert.ToString(ds.Tables[0].Rows[i].ItemArray[1]).Trim();


				item.NovoRegistro = false;
				colecao.Add(item);
			}
			
			return colecao;

		}


		public col_CHAVE FindAllGrid()
		{

			cls_CHAVE CHAVE = new cls_CHAVE();
			col_CHAVE colecao = new col_CHAVE();
				
				CHAVE.CHAVE = this.CHAVE;
				CHAVE.NOME = this.NOME;

			System.Data.DataSet ds = CHAVE.FindAllGrid();

               		if (CHAVE.mensagem != String.Empty)
	                {
	                    this.mensagem = CHAVE.mensagem;
	                    return null;
	                }


			for ( int i =0 ; i <  ds.Tables[0].Rows.Count ; i++)
			{
				rul_CHAVE item = new rul_CHAVE();
					if( ds.Tables[0].Rows[i].ItemArray[0].ToString() != String.Empty)
						item.CHAVE = Convert.ToInt32(ds.Tables[0].Rows[i].ItemArray[0]);

					if( ds.Tables[0].Rows[i].ItemArray[1].ToString() != String.Empty)
						item.NOME = Convert.ToString(ds.Tables[0].Rows[i].ItemArray[1]).Trim();


				item.NovoRegistro = false;
				colecao.Add(item);
			}
			
			return colecao;

		}

		public System.Data.DataSet FindAllInDataSet()
		{
			try
			{
				cls_CHAVE CHAVE = new cls_CHAVE();			
				
				CHAVE.CHAVE = this.CHAVE;
				CHAVE.NOME = this.NOME;

				System.Data.DataSet ds = CHAVE.FindAll();

				this.mensagem = CHAVE.mensagem;

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
				cls_CHAVE CHAVE = new cls_CHAVE();			
				

				System.Data.DataSet ds = CHAVE.GetAllMasterDetail();

				this.mensagem = CHAVE.mensagem;

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
				cls_CHAVE CHAVE = new cls_CHAVE();


				
				CHAVE.CHAVE = this.CHAVE;


				System.Data.DataSet ds = CHAVE.Load();


                		if (CHAVE.mensagem != String.Empty)
		                {
		                    this.mensagem = CHAVE.mensagem;
		                    return false;
		                }


				if( ds.Tables[0].Rows.Count ==1)
				{
										if( ds.Tables[0].Rows[0].ItemArray[0].ToString() != String.Empty)
						this.CHAVE = Convert.ToInt32(ds.Tables[0].Rows[0].ItemArray[0]);

					if( ds.Tables[0].Rows[0].ItemArray[1].ToString() != String.Empty)
						this.NOME = Convert.ToString(ds.Tables[0].Rows[0].ItemArray[1]);


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