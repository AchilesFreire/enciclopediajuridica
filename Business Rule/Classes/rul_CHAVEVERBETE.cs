using System;
using System.Drawing;
using EnciclopediaJuridica.BusinessClass;
using EnciclopediaJuridica.BusinessCollection;


namespace EnciclopediaJuridica.BusinessRule
{
	public class rul_CHAVEVERBETE
	{

		#region "Variaveis" 

			private  int _CHAVE = -1;
			private  int _VERBETE = -1;


			private String _mensagem = "";
			private Boolean _NovoRegistro = true;

		#endregion

		#region "Construtures"
 
		public rul_CHAVEVERBETE()
		{
		}
		public rul_CHAVEVERBETE( int par_CHAVE,  int par_VERBETE)
		{
			try
				{
					this.CHAVE = par_CHAVE;
 					this.VERBETE = par_VERBETE;
 
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

			public  int VERBETE
			{
				get {return _VERBETE;}
				set {_VERBETE = value;}
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
				cls_CHAVEVERBETE CHAVEVERBETE = new cls_CHAVEVERBETE();
				
				CHAVEVERBETE.CHAVE = this.CHAVE;
				CHAVEVERBETE.VERBETE = this.VERBETE;

				this.mensagem="";

				Boolean retorno = CHAVEVERBETE.Insert();

				this.mensagem = CHAVEVERBETE.mensagem;

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
				cls_CHAVEVERBETE CHAVEVERBETE = new cls_CHAVEVERBETE();
				
				CHAVEVERBETE.CHAVE = this.CHAVE;
				CHAVEVERBETE.VERBETE = this.VERBETE;

				this.mensagem= "";
				
				Boolean retorno = CHAVEVERBETE.Update();

				this.mensagem = CHAVEVERBETE.mensagem;

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

				if (  this.CHAVE == -1)
				{
					this.mensagem = "O Campo CHAVE tem que ser preenchido com Inteiro";
					return false;
				}
				if (  this.VERBETE == -1)
				{
					this.mensagem = "O Campo VERBETE tem que ser preenchido com Inteiro";
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
				cls_CHAVEVERBETE CHAVEVERBETE = new cls_CHAVEVERBETE();

				
				CHAVEVERBETE.CHAVE = this.CHAVE;
				CHAVEVERBETE.VERBETE = this.VERBETE;


				if (VerifyForeignKeys())
					{

						this.mensagem= "";
				
						Boolean retorno = CHAVEVERBETE.Delete();

						this.mensagem = CHAVEVERBETE.mensagem;

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
				cls_CHAVEVERBETE CHAVEVERBETE = new cls_CHAVEVERBETE();
				

				this.mensagem= "";
				
				Boolean retorno = CHAVEVERBETE.DeleteMasterDetail();

				this.mensagem = CHAVEVERBETE.mensagem;

				return retorno;

			}
			catch(Exception ex)
			{
			this.mensagem = ex.Message;
			return false;
			}
		}

		public col_CHAVEVERBETE GetAll()
		{
			try
			{
				cls_CHAVEVERBETE CHAVEVERBETE = new cls_CHAVEVERBETE();
				col_CHAVEVERBETE colecao = new col_CHAVEVERBETE();
				
				CHAVEVERBETE.CHAVE = this.CHAVE;
				CHAVEVERBETE.VERBETE = this.VERBETE;

				System.Data.DataSet ds = CHAVEVERBETE.GetAll();

                		if (CHAVEVERBETE.mensagem != String.Empty)
		                {
		                    this.mensagem = CHAVEVERBETE.mensagem;
		                    return null;
		                }

				for ( int i =0 ; i <  ds.Tables[0].Rows.Count ; i++)
				{
					rul_CHAVEVERBETE item = new rul_CHAVEVERBETE();
					if( ds.Tables[0].Rows[i].ItemArray[0].ToString() != String.Empty)
						item.CHAVE = Convert.ToInt32(ds.Tables[0].Rows[i].ItemArray[0]);

					if( ds.Tables[0].Rows[i].ItemArray[1].ToString() != String.Empty)
						item.VERBETE = Convert.ToInt32(ds.Tables[0].Rows[i].ItemArray[1]);


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
				cls_CHAVEVERBETE CHAVEVERBETE = new cls_CHAVEVERBETE();			
				
				CHAVEVERBETE.CHAVE = this.CHAVE;
				CHAVEVERBETE.VERBETE = this.VERBETE;

				System.Data.DataSet ds = CHAVEVERBETE.GetAll();

				this.mensagem = CHAVEVERBETE.mensagem;

				return ds;
			}
			catch (Exception ex)
			{
				this.mensagem = ex.Message;
				return null;
			}
		}

		public col_CHAVEVERBETE FindAll()
		{

			cls_CHAVEVERBETE CHAVEVERBETE = new cls_CHAVEVERBETE();
			col_CHAVEVERBETE colecao = new col_CHAVEVERBETE();
				
				CHAVEVERBETE.CHAVE = this.CHAVE;
				CHAVEVERBETE.VERBETE = this.VERBETE;

			System.Data.DataSet ds = CHAVEVERBETE.FindAll();

               		if (CHAVEVERBETE.mensagem != String.Empty)
	                {
	                    this.mensagem = CHAVEVERBETE.mensagem;
	                    return null;
	                }


			for ( int i =0 ; i <  ds.Tables[0].Rows.Count ; i++)
			{
				rul_CHAVEVERBETE item = new rul_CHAVEVERBETE();
					if( ds.Tables[0].Rows[i].ItemArray[0].ToString() != String.Empty)
						item.CHAVE = Convert.ToInt32(ds.Tables[0].Rows[i].ItemArray[0]);

					if( ds.Tables[0].Rows[i].ItemArray[1].ToString() != String.Empty)
						item.VERBETE = Convert.ToInt32(ds.Tables[0].Rows[i].ItemArray[1]);


				item.NovoRegistro = false;
				colecao.Add(item);
			}
			
			return colecao;

		}


		public col_CHAVEVERBETE FindAllGrid()
		{

			cls_CHAVEVERBETE CHAVEVERBETE = new cls_CHAVEVERBETE();
			col_CHAVEVERBETE colecao = new col_CHAVEVERBETE();
				
				CHAVEVERBETE.CHAVE = this.CHAVE;
				CHAVEVERBETE.VERBETE = this.VERBETE;

			System.Data.DataSet ds = CHAVEVERBETE.FindAllGrid();

               		if (CHAVEVERBETE.mensagem != String.Empty)
	                {
	                    this.mensagem = CHAVEVERBETE.mensagem;
	                    return null;
	                }


			for ( int i =0 ; i <  ds.Tables[0].Rows.Count ; i++)
			{
				rul_CHAVEVERBETE item = new rul_CHAVEVERBETE();
					if( ds.Tables[0].Rows[i].ItemArray[0].ToString() != String.Empty)
						item.CHAVE = Convert.ToInt32(ds.Tables[0].Rows[i].ItemArray[0]);

					if( ds.Tables[0].Rows[i].ItemArray[1].ToString() != String.Empty)
						item.VERBETE = Convert.ToInt32(ds.Tables[0].Rows[i].ItemArray[1]);


				item.NovoRegistro = false;
				colecao.Add(item);
			}
			
			return colecao;

		}

		public System.Data.DataSet FindAllInDataSet()
		{
			try
			{
				cls_CHAVEVERBETE CHAVEVERBETE = new cls_CHAVEVERBETE();			
				
				CHAVEVERBETE.CHAVE = this.CHAVE;
				CHAVEVERBETE.VERBETE = this.VERBETE;

				System.Data.DataSet ds = CHAVEVERBETE.FindAll();

				this.mensagem = CHAVEVERBETE.mensagem;

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
				cls_CHAVEVERBETE CHAVEVERBETE = new cls_CHAVEVERBETE();			
				

				System.Data.DataSet ds = CHAVEVERBETE.GetAllMasterDetail();

				this.mensagem = CHAVEVERBETE.mensagem;

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
				cls_CHAVEVERBETE CHAVEVERBETE = new cls_CHAVEVERBETE();


				
				CHAVEVERBETE.CHAVE = this.CHAVE;
				CHAVEVERBETE.VERBETE = this.VERBETE;


				System.Data.DataSet ds = CHAVEVERBETE.Load();


                		if (CHAVEVERBETE.mensagem != String.Empty)
		                {
		                    this.mensagem = CHAVEVERBETE.mensagem;
		                    return false;
		                }


				if( ds.Tables[0].Rows.Count ==1)
				{
										if( ds.Tables[0].Rows[0].ItemArray[0].ToString() != String.Empty)
						this.CHAVE = Convert.ToInt32(ds.Tables[0].Rows[0].ItemArray[0]);

					if( ds.Tables[0].Rows[0].ItemArray[1].ToString() != String.Empty)
						this.VERBETE = Convert.ToInt32(ds.Tables[0].Rows[0].ItemArray[1]);


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